using System;
using System.Windows.Forms;

namespace WinZipKata
{
    public class ParentPath
    {
        private string Path { get; set; }
        private TextBox PathSource { get; }

        public ParentPath(TextBox pathSource)
        {
            PathSource = pathSource;
            Path = PathSource.Text;
        }

        public void Reset() { }
        public bool IsChanged() { throw new NotImplementedException(); }
    }
}
