using System;
using System.Windows.Forms;

namespace WinZipKata
{
    public partial class WinZipUI : Form
    {
        public WinZipUI()
        {
            InitializeComponent();
        }
    }

    internal static class UIInteractionExtensions
    {
        public static void NonBlockingThreadSafeUiUpdate(this Action uiInteraction, Control control)
        {
            if (control.InvokeRequired) control.BeginInvoke(uiInteraction);
            else uiInteraction();
        }
    }
}
