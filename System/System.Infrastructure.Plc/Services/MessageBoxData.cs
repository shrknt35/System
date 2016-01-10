using System.Common.Dialogs;

namespace System.Infrastructure.Services
{
    public struct MessageBoxData
    {
        public string Title;
        public string Message;
        public MessageBoxButtons MessageBoxButtons;
        public MessageBoxIcon MesageBoxIcon;

        public DialogResult DialogResult;
    }
}