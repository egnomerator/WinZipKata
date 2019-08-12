using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WinZipKata.Core;

namespace WinZipKata
{
    public class Presenter
    {
        private readonly IWinZipUI _view;
        private ParentPath _parentPath;
        private ParentPathValidator _parentPathValidator;
        private List<DirectoryInfo> _subFolders;
        private CancellationTokenSource Cts { get; set; }

        public Presenter(IWinZipUI view, ParentPath parentPath, ParentPathValidator parentPathValidator)
        {
            _view = view;
            _parentPath = parentPath;
            _parentPathValidator = parentPathValidator;
            _subFolders = new List<DirectoryInfo>();
        }

        public void ParentPathChanged(string newParentPath)
        {
            if (!_parentPath.IsChanged(newParentPath)) return;

            if (!_parentPathValidator.ParentPathIsValid(newParentPath))
            {
                Reset();
                _view.DisplayMessage($"Path must exist and not contain an \"{ParentPathValidator.OutputFolder}\" SubFolder", "Invalid Parent Path");
                return;
            }

            _parentPath.Update(newParentPath);
            _subFolders = new DirectoryInfo(_parentPath.Path).GetDirectories().ToList();
            _view.DisplaySubFolderNames(_subFolders.Select(f => f.Name).ToList());
        }

        public async void ZipSubFolders()
        {
            _view.DisableZipping();
            _view.DisableParentPathEditing();
            _view.EnableAbort();
            var outputPath = CreateOutputFolder();

            var isCanceled = false;
            try
            {
                Cts = new CancellationTokenSource();
                isCanceled = await Task.Run(() => ZipEachSubFolder(_subFolders.Select(f => f.FullName).ToList(), outputPath));
            }
            finally
            {
                Cts.Dispose();
                Cts = null;
                _view.DisableAbort();

                if (isCanceled) _view.DisplayMessage("Stopped zipping SubFolders", "Processing Canceled");
                else _view.DisplayMessage("Finished zipping SubFolders", "Processing Complete");
            }
        }

        public void Abort()
        {
            _view.DisableAbort();
            Cts.Cancel();
        }

        private void Reset()
        {
            _parentPath.Reset();
            _view.UpdateParentPath(_parentPath.Path);
            _subFolders = new List<DirectoryInfo>();
            _view.DisplaySubFolderNames(new List<string>());
        }

        private string CreateOutputFolder()
        {
            var outputPath = Path.Combine(_parentPath.Path, ParentPathValidator.OutputFolder);
            Directory.CreateDirectory(outputPath);
            return outputPath;
        }

        private bool ZipEachSubFolder(List<string> subFolderPaths, string outputPath)
        {
            var parallelOptions = new ParallelOptions
            {
                CancellationToken = Cts.Token
            };

            try
            {
                Parallel.ForEach(subFolderPaths, parallelOptions, (p, state, index) =>
                {
                    var didZip = ZipSubFolder(p, outputPath, parallelOptions.CancellationToken);
                    if(!parallelOptions.CancellationToken.IsCancellationRequested) _view.IndicateSubFolderProcessed((int)index, didZip);
                });
            }
            catch (OperationCanceledException)
            {
                return true;
            }

            return false;
        }

        private bool ZipSubFolder(string subFolderPath, string destinationPath, CancellationToken token)
        {
            if (!Directory.Exists(subFolderPath)) return false;

            var zipValidator = new ZipValidator(subFolderPath, destinationPath);
            var zipPath = zipValidator.GetZipFilePath();
            if (!zipValidator.ZipFileCanBeCreated()) return false;

            new Zipper(subFolderPath, zipPath).ZipFolder(token);
            return true;
        }
    }
}
