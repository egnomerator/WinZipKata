using System.Collections.Generic;

namespace WinZipKata
{
    public interface IWinZipUI
    {
        void DisplaySubFolderNames(List<string> names);
        void UpdateParentPath(string path);
        void DisplayMessage(string message, string caption);
        void DisableZipping();
        void DisableParentPathEditing();
        void EnableAbort();
        void DisableAbort();
        void IndicateSubFolderProcessed(int index, bool isProcessed);
    }
}
