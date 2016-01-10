using System.Common;
using System.Common.Dialogs;

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
            var handler = ShowSelectionFolderDialogRequested;

            var result = new Result<string>();

            handler?.Invoke(this, result);

            return result;
        }

        public DialogResult ShowMessageBox(MessageBoxData messageBoxData)
        {
            var handler = ShowMessageBoxRequested;

            handler?.Invoke(this, messageBoxData);

            return messageBoxData.DialogResult;
        }

        public DialogResult ShowMessageBox(string title)
        {
            var handler = ShowMessageBoxRequested;

            var messageBoxData = new MessageBoxData { Title = title };
            handler?.Invoke(this, messageBoxData);

            return messageBoxData.DialogResult;
        }

        public string ShowSelectFileDialog<TParentViewModel>(bool multiselect, FileSelectionFilter fileSelectionFilter)
        {
            var selectFileDialogData = new SelectFileDialogData { MultiSelect = multiselect, FileSelectionFilter = fileSelectionFilter };

            var handler = ShowSelectFileDialogRequested;
            handler?.Invoke(this, selectFileDialogData);

            return selectFileDialogData.SelectedFilePath;
        }

        #region EVENTS

        public event EventHandler<VMOpenCloseEventArgs> CloseViewRequested;

        public event EventHandler<VMOpenCloseEventArgs> ShowViewRequested;

        public event EventHandler<ShowDialogViewMessengerEventArgs> ShowChildDialog;

        public event EventHandler<VMOpenCloseEventArgs> ShowStandAloneDialog;

        public event EventHandler ApplicationShutDownRequested;

        public event EventHandler<IResult<string>> ShowSelectionFolderDialogRequested;

        public event EventHandler<MessageBoxData> ShowMessageBoxRequested;

        public event EventHandler<SelectFileDialogData> ShowSelectFileDialogRequested;

        #endregion EVENTS
    }
}