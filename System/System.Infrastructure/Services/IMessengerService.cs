using System.Common;
using System.Common.Dialogs;

namespace System.Infrastructure.Services
{
    public interface IMessengerService
    {
        event EventHandler<VMOpenCloseEventArgs> ShowViewRequested;

        event EventHandler<ShowDialogViewMessengerEventArgs> ShowChildDialog;

        event EventHandler<VMOpenCloseEventArgs> ShowStandAloneDialog;

        event EventHandler<VMOpenCloseEventArgs> CloseViewRequested;

        event EventHandler ApplicationShutDownRequested;

        void ShowView<TViewModel>(object dataContext, string region = null);

        void ShowViewAsChildDialog<TViewModel, TViewModelParent>(object dataContext);

        void ShowViewAsStandAloneDialog<TViewModel>(object dataContext);

        void CloseView<TViewModel>(string region = null);

        DialogResult ShowMessageBox(string title, string message, MessageBoxButtons messageBoxButtons, MessageBoxIcon mesageBoxIcon = MessageBoxIcon.None);

        DialogResult ShowMessageBox(string title);

        string ShowSelectFileDialog<TParentViewModel>(bool multiselect, FileSelectionFilter fileSelectionFilter);

        void ShutDownApplication();

        IResult<string> ShowSelectFolderDialog(string message);
    }
}