using System;
using System.IO;

namespace WinZipKata
{
    public static class Zipper
    {
        public static bool ValidateParentPath(string parentPath)
        {
            return Directory.Exists(parentPath);
        }
    }
}
