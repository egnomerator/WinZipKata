using System;
using System.Collections.Generic;
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
                return;
            }

            // TODO: update list of folders
            _subFolders = new DirectoryInfo(parentPath).GetDirectories().ToList();
            DisplaySubFolders();
        }

        private void DisplaySubFolders()
        {
            _subFolders.ForEach(d =>
            {
                SubFoldersListing.Items.Add(d.Name);
            });
        }
    }
}
