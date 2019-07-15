using System.IO;

namespace WinZipKata.Core
{
    public class ZipValidator
    {
        private string FolderToZipPath { get; }
        private string DestinationPath { get; }

        public ZipValidator(string folderToZipPath, string destinationPath)
        {
            FolderToZipPath = folderToZipPath;
            DestinationPath = destinationPath;
        }

        public bool ZipFileCanBeCreated()
        {
            var zipFileName = $"{new DirectoryInfo(FolderToZipPath).Name}.zip";
            return !File.Exists(Path.Combine(DestinationPath, zipFileName));
        }
    }
}
