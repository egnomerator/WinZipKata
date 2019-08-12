using Ionic.Zip;
using System.Threading;

namespace WinZipKata.Core
{
    public class Zipper
    {
        private string FolderToZipPath { get; }
        private string ZipFilePath { get; }
        private CancellationToken Token { get; set; }

        public Zipper(string folderToZipPath, string zipFilePath)
        {
            FolderToZipPath = folderToZipPath;
            ZipFilePath = zipFilePath;
        }

        public void ZipFolder(CancellationToken token)
        {
            Token = token;

            using (var zip = new ZipFile(ZipFilePath))
            {
                zip.SaveProgress += SaveProgress;
                zip.UseZip64WhenSaving = Zip64Option.AsNecessary;
                zip.CompressionLevel = Ionic.Zlib.CompressionLevel.BestCompression;
                zip.AddDirectory(FolderToZipPath);
                zip.Save();
            }
        }

        private void SaveProgress(object sender, SaveProgressEventArgs e)
        {
            if (Token.IsCancellationRequested) e.Cancel = true;
        }
    }
}
