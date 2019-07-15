using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace WinZipKata.TestUtilities
{
    public static class Support
    {
        public static class Fixture
        {
            private const string CDrive = "C";
            private const string ParentFolder = "Parent";
            private const string Output = "Output";
            private static string _solutionProjectBasePath;
            public static string BaseCDrivePath;
            public static string ParentPath;
            public static string OutputFolder;
            public static string FirstFolderToZipPath;
            public static string SecondFolderToZipPath;

            [ExcludeFromCodeCoverage]
            public static void Setup()
            {
                var localPath = Path.GetDirectoryName(new Uri(typeof(Support).Assembly.CodeBase).LocalPath);
                if (localPath == null) throw new Exception();
                _solutionProjectBasePath = new DirectoryInfo(localPath).Parent?.Parent?.FullName;
                if (_solutionProjectBasePath == null) throw new Exception();

                BaseCDrivePath = Path.Combine(_solutionProjectBasePath, CDrive);
                ParentPath = Path.Combine(BaseCDrivePath, ParentFolder);
                OutputFolder = Path.Combine(ParentPath, Output);
                FirstFolderToZipPath = Path.Combine(ParentPath, @"FolderToZip1");
                SecondFolderToZipPath = Path.Combine(ParentPath, @"FolderToZip2");
            }

            [ExcludeFromCodeCoverage]
            public static void Cleanup()
            {
                if (Directory.Exists(OutputFolder)) Directory.Delete(OutputFolder, recursive: true);
            }
        }

        public static class FileSystem
        {
            public static string GetZipFilePathFrom(string folderTozipPath, string destinationPath)
            {
                return Path.Combine(destinationPath, $"{GetFolderName(folderTozipPath)}.zip");
            }

            private static string GetFolderName(string folderPath)
            {
                return Path.GetFileName(folderPath);
            }

            public static void CreateZipOutput(string zipFilePath)
            {
                CreateFolder(Path.GetDirectoryName(zipFilePath));
                CreateFile(zipFilePath);
            }

            private static void CreateFolder(string folderPath)
            {
                Directory.CreateDirectory(folderPath);
            }

            private static void CreateFile(string filePath)
            {
                if (File.Exists(filePath)) return;

                FileStream createdFile;
                createdFile = File.Create(filePath);
                createdFile.Close();
            }
        }
    }
}
