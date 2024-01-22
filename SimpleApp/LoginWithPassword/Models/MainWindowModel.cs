
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace LoginWithPassword.Models
{
    class RakursUser
    {
        public int Number { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
    }

    class MainWindowModel : ObservableObject
    {
        public MainWindowModel()
        {
            dbModel = new DatabaseModel();
        }

        public bool IsConnected
        {
            get
            {
                if(dbModel == null)
                {
                    return false;
                }

                
                return dbModel.Connected;
            }
        }

        public ICommand ConnectDBCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if (!dbModel.Connected)
                    {
                        dbModel.Connect();
                        OnPropertyChanged(nameof(IsConnected));
                    } 
                    else
                    {
                        dbModel.Disconnect();
                        OnPropertyChanged(nameof(IsConnected));
                    }
                });
            }
        }

        public int IndexNumber { get; set; }

        public List<RakursUser> Users { get; set; }

        private DatabaseModel dbModel;
    }
}
