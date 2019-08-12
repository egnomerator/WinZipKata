using System;

namespace WinZipKata.Core
{
    public class ParentPath
    {
        public string Path { get; private set; }

        public ParentPath() { }

        public ParentPath(string path)
        {
            Path = path;
        }

        public bool IsChanged(string newParentPath)
        {
            return !newParentPath.Equals(Path, StringComparison.Ordinal);
        }

        public void Update(string newParentPath)
        {
            Path = newParentPath;
        }

        public void Reset()
        {
            Update(string.Empty);
        }
    }
}
