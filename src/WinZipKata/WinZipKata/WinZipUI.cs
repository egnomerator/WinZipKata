using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WinZipKata.Core;

namespace WinZipKata
{
    public partial class WinZipUI : Form, IWinZipUI
    {
        private Presenter _presenter;

        public WinZipUI()
        {
            InitializeComponent();

            _presenter = new Presenter(this, new ParentPath(), new ParentPathValidator());
        }

        public void DisplaySubFolderNames(List<string> names)
        {
            SubFoldersListing.Items.Clear();

            names.ForEach(n => SubFoldersListing.Items.Add(n));
        }

        public void UpdateParentPath(string path)
        {
            ParentPathInput.Text = path;
        }

        public void DisplayMessage(string message, string caption)
        {
            MessageBox.Show(message, caption ?? string.Empty);
        }

        public void DisableZipping()
        {
            Zip.Enabled = false;
        }

        public void DisableParentPathEditing()
        {
            ParentPathInput.ReadOnly = true;
        }

        public void IndicateSubFolderProcessed(int index, bool isProcessed)
        {
            if (InvokeRequired) Invoke(new Action(() => IndicateSubFolderProcessed(index, isProcessed)));
            else SubFoldersListing.Items[index].BackColor = isProcessed ? Color.LightGreen : Color.Red;
        }

        public void EnableAbort()
        {
            Abort.Enabled = true;
        }

        public void DisableAbort()
        {
            Abort.Enabled = false;
        }

        private void ParentPathInputChanged(object sender, EventArgs e)
        {
            var newParentPath = ParentPathInput.Text;
            _presenter.ParentPathChanged(newParentPath);
        }

        private void ZipSubFolders(object sender, EventArgs e)
        {
            _presenter.ZipSubFolders();
        }

        private void AbortProcessing(object sender, EventArgs e)
        {
            _presenter.Abort();
        }
    }
}
