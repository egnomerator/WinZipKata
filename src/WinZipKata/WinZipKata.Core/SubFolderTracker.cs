using System;
using System.Collections.Generic;

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
            throw new NotImplementedException();
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
