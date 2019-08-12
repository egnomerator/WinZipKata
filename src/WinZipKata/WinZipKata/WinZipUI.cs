using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WinZipKata.Core;

namespace WinZipKata
{
    public partial class WinZipUI : Form
    {
        private ParentPath _parentPath;
        private ParentPathValidator _parentPathValidator;
        private List<DirectoryInfo> _subFolders;

        public WinZipUI()
        {
            InitializeComponent();

            _parentPath = new ParentPath(ParentPathInput);
            _parentPathValidator = new ParentPathValidator();
            _subFolders = new List<DirectoryInfo>();
        }

        private void ParentPathInputChanged(object sender, EventArgs e)
        {
            var parentPath = ParentPathInput.Text;
            if (!_parentPath.IsChanged()) return;

            if (!_parentPathValidator.ParentPathIsValid(parentPath))
            {
                _parentPath.Reset();
                _subFolders = new List<DirectoryInfo>();
                DisplaySubFolders();
                return;
            }

            _parentPath.Update(parentPath);
            _subFolders = new DirectoryInfo(parentPath).GetDirectories().ToList();
            DisplaySubFolders();
        }

        private void ZipSubFolders(object sender, EventArgs e)
        {
            Zip.Enabled = false;

            var outputPath = Path.Combine(_parentPath.Path, ParentPathValidator.OutputFolder);
            Directory.CreateDirectory(outputPath);
            ZipEachSubFolder(_subFolders.Select(f=>f.FullName).ToList(), outputPath);
        }

        private void ZipEachSubFolder(List<string> subFolderPaths, string outputPath)
        {
            subFolderPaths.ForEach(p =>
            {
                var didZip = ZipSubFolder(p, outputPath);

                var index = subFolderPaths.IndexOf(p);
                SubFoldersListing.Items[index].BackColor = didZip ? Color.LightGreen : Color.Red;
            });
        }

        private bool ZipSubFolder(string subFolderPath, string destinationPath)
        {
            var zipValidator = new ZipValidator(subFolderPath, destinationPath);
            var zipPath = zipValidator.GetZipFilePath();

            if (!zipValidator.ZipFileCanBeCreated()) return false;

            new Zipper(subFolderPath, zipPath).ZipFolder();
            return true;
        }

        private void DisplaySubFolders()
        {
            SubFoldersListing.Items.Clear();

            _subFolders.ForEach(d =>
            {
                SubFoldersListing.Items.Add(d.Name);
            });
        }
    }
}
