using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using CommunityToolkit.Mvvm.Input;

namespace FirstApp
{
    class MainWindowModel
    {
        public string VersionAppStr
        {
            get
            {
                Version version = Assembly.GetEntryAssembly().GetName().Version;
                string versionApp = string.Format("Версия приложения: {0}", version.ToString());
                return versionApp;
            }
        }

        private void ExitApp()
        {
            System.Windows.Application.Current.Shutdown();
        }

        public ICommand ExitCommand
        {
            get
            {
                return new RelayCommand(() => ExitApp());
            }
        }
    }
}
