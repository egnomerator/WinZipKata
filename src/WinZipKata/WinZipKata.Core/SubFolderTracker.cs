using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WinZipKata.Core
{
    public class SubFolderTracker
    {
        private List<SubFolder> _subFolders;

        public class Stats
        {
            public int Total { get; }
            public int ProcessedCount { get; }
            public double ProcessedPercent { get; }
        }

        public SubFolderTracker()
        {
            _subFolders = new List<SubFolder>();
        }

        public List<SubFolder> GetSubFolders()
        {
            return _subFolders;
        }

        public void FindSubFolders(string parentPath)
        {
            var subDirs = new DirectoryInfo(parentPath).GetDirectories();
            _subFolders = subDirs.Select(dir => new SubFolder(dir.Name)).ToList();
        }

        public bool IsSubFolderProcessed(int index)
        {
            throw new NotImplementedException();
        }

        public Stats GetStats()
        {
            throw new NotImplementedException();
        }
    }
}
