using System.IO;

namespace WinZipKata.Core
{
    public class ParentPathValidator
    {
        public bool ParentPathIsValid(string parentPath)
        {
            const string output = "Output";
            return Directory.Exists(parentPath) && !Directory.Exists(Path.Combine(parentPath, output));
        }
    }
}
