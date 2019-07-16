using Ionic.Zip;

namespace WinZipKata.Core
{
    public class Zipper
    {
        private string FolderToZipPath { get; }
        private string ZipFilePath { get; }

        public Zipper(string folderToZipPath, string zipFilePath)
        {
            FolderToZipPath = folderToZipPath;
            ZipFilePath = zipFilePath;
        }

        public void ZipFolder()
        {
            using (var zip = new ZipFile(ZipFilePath))
            {
                zip.UseZip64WhenSaving = Zip64Option.AsNecessary;
                zip.CompressionLevel = Ionic.Zlib.CompressionLevel.BestCompression;
                zip.AddDirectory(FolderToZipPath);
                zip.Save();
            }
        }
    }
}
