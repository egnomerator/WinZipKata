using System.IO;

namespace WinZipKata.Core
{
    public class ParentPathValidator
    {
        public const string OutputFolder = "Output";

        public bool ParentPathIsValid(string parentPath)
        {
            return Directory.Exists(parentPath) && !Directory.Exists(Path.Combine(parentPath, OutputFolder));
        }
    }
}
