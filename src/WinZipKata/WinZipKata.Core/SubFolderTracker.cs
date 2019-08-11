using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WinZipKata.Core
{
    public class SubFolderTracker
    {
        private List<SubFolder> SubFolders { get; set; }

        public class Stats
        {
            public int Total { get; }
            public int ProcessedCount { get; }
            public double ProcessedPercent { get; }
        }

        public SubFolderTracker()
        {
            SubFolders = new List<SubFolder>();
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
