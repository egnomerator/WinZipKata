using System;

namespace WinZipKata.Core
{
    public class SubFolderTracker
    {
        public class Stats
        {
            public int Total { get; }
            public int ProcessedCount { get; }
            public double ProcessedPercent { get; }
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
