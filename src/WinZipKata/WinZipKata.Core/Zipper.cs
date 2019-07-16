using Ionic.Zip;

namespace WinZipKata.Core
{
    public static class Zipper
    {
        public static void ZipFolder(string folderToZipPath, string zipFilePath)
        {
            using (var zip = new ZipFile(zipFilePath))
            {
                zip.UseZip64WhenSaving = Zip64Option.AsNecessary;
                zip.CompressionLevel = Ionic.Zlib.CompressionLevel.BestCompression;
                zip.AddDirectory(folderToZipPath);
                zip.Save();
            }
        }
    }
}
