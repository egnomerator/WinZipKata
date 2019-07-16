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
            return !File.Exists(GetZipFilePathToUse());
        }

        public string GetZipFilePathToUse()
        {
            var zipFileName = $"{new DirectoryInfo(FolderToZipPath).Name}.zip";
            return Path.Combine(DestinationPath, zipFileName);
        }
    }
}
