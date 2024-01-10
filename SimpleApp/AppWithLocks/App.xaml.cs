using AppWithLocks.Infrastructure;
using AppWithLocks.Infrastructure.Abstractions;
using AppWithLocks.ViewModel;
using GalaSoft.MvvmLight.Threading;
using Ninject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AppWithLocks
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            DispatcherHelper.Initialize();
            AppWithLocksApplication.Current.Bootstrap();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            AppWithLocksApplication.Current.Container.Get<IWindowService>().OpenWindow<MainViewModel>();
        }
    }
}
