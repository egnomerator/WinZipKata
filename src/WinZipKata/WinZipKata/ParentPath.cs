﻿using System;
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
            throw new NotImplementedException();
        }

        public void Update(string newPath)
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
