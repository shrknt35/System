using System.Common.EventArguments;

namespace System.Common
{
    public abstract class ProcessBase : IProcess
    {
        public abstract void Start();

        public virtual void Pause()
        {
            ThrowUnsupportedAction();
        }

        public virtual void Stop()
        {
            ThrowUnsupportedAction();
        }

        #region Events

        public event EventHandler Started;

        protected virtual void RaiseStartedEvent()
        {
            var handler = Started;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        public event EventHandler<ProcessFailedEventArgs> Failed;

        protected virtual void RaiseFailedEvent(ProcessFailedEventArgs e)
        {
            var handler = Failed;
            if (handler != null)
                handler(this, e);
        }

        public event EventHandler Stopped;

        protected virtual void RaiseStoppedEvent()
        {
            var handler = Stopped;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        public event EventHandler Completed;

        protected virtual void RaiseCompletedEvent()
        {
            var handler = Completed;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        #endregion Events

        protected static void ThrowUnsupportedAction()
        {
            throw new NotSupportedException("This action is not supported!");
        }
    }
}