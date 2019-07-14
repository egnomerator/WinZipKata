using System.IO;

namespace WinZipKata
{
    public static class Zipper
    {
        public static bool ValidateParentPath(string parentPath)
        {
            const string output = "Output";
            return Directory.Exists(parentPath) && !Directory.Exists(Path.Combine(parentPath, output));
        }
    }
}
