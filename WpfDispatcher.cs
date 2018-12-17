using System;

namespace ObservableMvvm
{
    public class WpfDispatcher
    {

        public WpfDispatcher()
        {
        }

        #region IDispatcher Members

        public void BeginInvoke(Action action)
        {
            App.Current?.Dispatcher?.Invoke(action);
        }

        #endregion
    }

}
