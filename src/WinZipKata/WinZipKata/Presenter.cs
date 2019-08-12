using System.Collections.Generic;
using System.IO;
using System.Linq;
using WinZipKata.Core;

namespace WinZipKata
{
    public class Presenter
    {
        private readonly IWinZipUI _view;
        private ParentPath _parentPath;
        private ParentPathValidator _parentPathValidator;
        private List<DirectoryInfo> _subFolders;

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
                _parentPath.Reset();
                _view.UpdateParentPath(_parentPath.Path);
                _subFolders = new List<DirectoryInfo>();
                _view.DisplaySubFolderNames(new List<string>());
                _view.DisplayMessage($"Path must exist and not contain an \"{ParentPathValidator.OutputFolder}\" SubFolder", "Invalid Parent Path");
                return;
            }

            _parentPath.Update(newParentPath);
            _subFolders = new DirectoryInfo(_parentPath.Path).GetDirectories().ToList();
            _view.DisplaySubFolderNames(_subFolders.Select(f => f.Name).ToList());
        }

        public void ZipSubFolders()
        {
            _view.DisableZipping();

            var outputPath = Path.Combine(_parentPath.Path, ParentPathValidator.OutputFolder);
            Directory.CreateDirectory(outputPath);
            ZipEachSubFolder(_subFolders.Select(f => f.FullName).ToList(), outputPath);
        }

        private void ZipEachSubFolder(List<string> subFolderPaths, string outputPath)
        {
            subFolderPaths.ForEach(p =>
            {
                var didZip = ZipSubFolder(p, outputPath);

                var index = subFolderPaths.IndexOf(p);
                _view.IndicateSubFolderProcessed(index, didZip);
            });
        }

        private bool ZipSubFolder(string subFolderPath, string destinationPath)
        {
            if (!Directory.Exists(subFolderPath)) return false;

            var zipValidator = new ZipValidator(subFolderPath, destinationPath);
            var zipPath = zipValidator.GetZipFilePath();
            if (!zipValidator.ZipFileCanBeCreated()) return false;

            new Zipper(subFolderPath, zipPath).ZipFolder();
            return true;
        }
    }
}
