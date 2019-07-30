using System;
using System.Windows.Forms;

namespace WinZipKata
{
    public class ParentPath
    {
        public string Path { get; private set; }
        private TextBox PathSource { get; }

        public ParentPath(TextBox pathSource)
        {
            PathSource = pathSource;
            Path = PathSource.Text;
        }

        public bool IsChanged()
        {
            return !PathSource.Text.Equals(Path, StringComparison.Ordinal);
        }

        public void Update(string newPath)
        {
            Path = newPath;
            new Action(() => { PathSource.Text = newPath; }).NonBlockingThreadSafeUiUpdate(PathSource);
        }

        public void Reset()
        {
            Update(string.Empty);
        }
    }
}
