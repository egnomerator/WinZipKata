using System.IO;

namespace WinZipKata.Core
{
    public class ParentPathValidator
    {
        private string ParentPath { get; }

        public ParentPathValidator(string parentPath)
        {
            ParentPath = parentPath;
        }

        public bool ParentPathIsValid()
        {
            const string output = "Output";
            return Directory.Exists(ParentPath) && !Directory.Exists(Path.Combine(ParentPath, output));
        }
    }
}
