using AppWithLocks.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWithLocks.DesignTime
{
    class DesignTimeData
    {
        #region Application ViewModels

        internal static MainViewModel MainViewModelDesignDevice
        {
            get
            {
                MainViewModel device = new MainViewModel(new MockWindowService(), new MockMessageBoxService());
                device.TypeAppMode = Primitives.TypeAppMode.DemoMode;
                device.TypeActivate = Primitives.TypeActivate.ActivateTypeDisk;

                return device;
            }
        }

        #endregion Application ViewModels
    }
}
