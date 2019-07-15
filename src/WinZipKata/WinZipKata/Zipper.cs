using System.IO;

namespace WinZipKata
{
    public static class Zipper
    {
        public static bool ZipFileCanBeCreated(string zipFileName, string outputFolder)
        {
            var outputFile = Path.Combine(outputFolder, zipFileName);
            return !File.Exists(outputFile);
        }
    }
}
