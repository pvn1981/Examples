using AppWithLocks.Infrastructure.Abstractions;
using GalaSoft.MvvmLight;

namespace AppWithLocks.DesignTime
{
    internal class MockWindowService : IWindowService
    {
        public void OpenDialog<T>(string viewName, object model = null) where T : ViewModelBase
        {
        }

        public void OpenDialog<T>(object model = null) where T : ViewModelBase
        {
        }

        public void OpenWindow<T>(string viewName, object model = null) where T : ViewModelBase
        {
        }

        public void OpenWindow<T>(object model = null) where T : ViewModelBase
        {
        }
    }
}