using System.Common;
using System.Linq;
using System.Windows.Forms;
using DialogResult = System.Common.Dialogs.DialogResult;

namespace System.Infrastructure.Services
{
    public sealed class MessengerService : IMessengerService
    {
        public void CloseView<TViewModel>(string region = null)
        {
            var handler = CloseViewRequested;
            if (handler != null)
                handler(this, new VMOpenCloseEventArgs(typeof(TViewModel), null, region));
        }

        public void ShowViewAsChildDialog<TViewModel, TViewModelParent>(object dataContext)
        {
            var handler = ShowChildDialog;
            if (handler != null)
                handler(this, new ShowDialogViewMessengerEventArgs(typeof(TViewModel), typeof(TViewModelParent), dataContext));
        }

        public void ShowViewAsStandAloneDialog<TViewModel>(object dataContext)
        {
            var handler = ShowStandAloneDialog;
            if (handler != null)
                handler(this, new VMOpenCloseEventArgs(typeof(TViewModel), dataContext, string.Empty));
        }

        public void ShowView<TViewModel>(object dataContext, string region = null)
        {
            var handler = ShowViewRequested;
            if (handler != null)
                handler(this, new VMOpenCloseEventArgs(typeof(TViewModel), dataContext, region));
        }

        public void ShutDownApplication()
        {
            var handler = ApplicationShutDownRequested;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        public IResult<string> ShowSelectFolderDialog(string message)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.Description = message;
                dialog.ShowNewFolderButton = false;
                var dialogResult = dialog.ShowDialog();

                return dialogResult == Windows.Forms.DialogResult.OK
                    ? new Result<string>(dialog.SelectedPath, true)
                    : Result<string>.False;
            }
        }

        public DialogResult ShowMessageBox(string title, string message, MessageBoxButtons messageBoxButtons,
            MessageBoxIcon mesageBoxIcon = MessageBoxIcon.None)
        {
            return
                GetDialogResult(MessageBox.Show(message, title, GetMessageBoxButtons(messageBoxButtons),
                    GetMessageBoxImage(mesageBoxIcon)));
        }

        public DialogResult ShowMessageBox(string title)
        {
            return GetDialogResult(MessageBox.Show(title));
        }

        public string ShowSelectFileDialog<TParentViewModel>(bool multiselect, FileSelectionFilter fileSelectionFilter)
        {
            using (var selectFileDialog = new OpenFileDialog())
            {
                selectFileDialog.Multiselect = multiselect;

                selectFileDialog.Filter = GetFilterString(fileSelectionFilter);

                selectFileDialog.ShowDialog();

                return selectFileDialog.FileName;
            }
        }

        private static string GetFilterString(FileSelectionFilter fileSelectionFilter)
        {
            var filter = fileSelectionFilter.Title + "|";

            return fileSelectionFilter.Extensions.Aggregate(filter, (current, extension) => current + ("*." + extension + ";"));
        }

        private static DialogResult GetDialogResult(Windows.Forms.DialogResult dialogResult)
        {
            switch (dialogResult)
            {
                case Windows.Forms.DialogResult.None:
                    return DialogResult.None;

                case Windows.Forms.DialogResult.OK:
                    return DialogResult.OK;

                case Windows.Forms.DialogResult.Cancel:
                    return DialogResult.Cancel;

                case Windows.Forms.DialogResult.Abort:
                    return DialogResult.Abort;

                case Windows.Forms.DialogResult.Retry:
                    return DialogResult.Retry;

                case Windows.Forms.DialogResult.Ignore:
                    return DialogResult.Ignore;

                case Windows.Forms.DialogResult.Yes:
                    return DialogResult.Yes;

                case Windows.Forms.DialogResult.No:
                    return DialogResult.No;

                default:
                    throw new ArgumentOutOfRangeException("dialogResult");
            }
        }

        private static Windows.Forms.MessageBoxButtons GetMessageBoxButtons(MessageBoxButtons messageBoxButtons)
        {
            switch (messageBoxButtons)
            {
                case MessageBoxButtons.OK:
                    return Windows.Forms.MessageBoxButtons.OK;

                case MessageBoxButtons.OKCancel:
                    return Windows.Forms.MessageBoxButtons.OKCancel;

                case MessageBoxButtons.YesNo:
                    return Windows.Forms.MessageBoxButtons.YesNo;

                default:
                    throw new ArgumentOutOfRangeException("messageBoxButtons");
            }
        }

        private static Windows.Forms.MessageBoxIcon GetMessageBoxImage(MessageBoxIcon mesageBoxIcon)
        {
            switch (mesageBoxIcon)
            {
                case MessageBoxIcon.None:
                    return Windows.Forms.MessageBoxIcon.None;

                case MessageBoxIcon.Error:
                    return Windows.Forms.MessageBoxIcon.Error;

                case MessageBoxIcon.Hand:
                    return Windows.Forms.MessageBoxIcon.Hand;

                case MessageBoxIcon.Stop:
                    return Windows.Forms.MessageBoxIcon.Stop;

                case MessageBoxIcon.Question:
                    return Windows.Forms.MessageBoxIcon.Question;

                case MessageBoxIcon.Exclamation:
                    return Windows.Forms.MessageBoxIcon.Exclamation;

                case MessageBoxIcon.Warning:
                    return Windows.Forms.MessageBoxIcon.Warning;

                case MessageBoxIcon.Asterisk:
                    return Windows.Forms.MessageBoxIcon.Asterisk;

                case MessageBoxIcon.Information:
                    return Windows.Forms.MessageBoxIcon.Information;

                default:
                    throw new ArgumentOutOfRangeException("mesageBoxIcon");
            }
        }

        #region EVENTS

        public event EventHandler<VMOpenCloseEventArgs> CloseViewRequested;

        public event EventHandler<VMOpenCloseEventArgs> ShowViewRequested;

        public event EventHandler<ShowDialogViewMessengerEventArgs> ShowChildDialog;

        public event EventHandler<VMOpenCloseEventArgs> ShowStandAloneDialog;

        public event EventHandler ApplicationShutDownRequested;

        #endregion EVENTS
    }
}