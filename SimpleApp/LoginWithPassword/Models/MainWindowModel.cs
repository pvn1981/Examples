
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
        public string DbHost
        {
            get
            {
                return dbModel.Host;
            }

            set
            {
                dbModel.Host = value;
                Properties.Settings.Default.Host = dbModel.Host;
                Properties.Settings.Default.Save();
            }
        }

        public string DbUser
        {
            get
            {
                return dbModel.User;
            }

            set
            {
                dbModel.User = value;
                Properties.Settings.Default.User = dbModel.User;
                Properties.Settings.Default.Save();
            }
        }

        public string DbPassword
        {
            get
            {
                return dbModel.Password;
            }

            set
            {
                dbModel.Password = value;
                Properties.Settings.Default.Password = dbModel.Password;
                Properties.Settings.Default.Save();
            }
        }

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

                        if (IsConnected)
                        {
                            dbModel.CreateDatabase();
                            dbModel.CreateTable();
                        }
                    } 
                    else
                    {
                        dbModel.Disconnect();
                        OnPropertyChanged(nameof(IsConnected));
                    }
                });
            }
        }

        public ICommand AddUserCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if (!dbModel.Connected)
                    {
                        throw new Exception("Not implimented");
                    }
                });
            }
        }
        

        public int IndexNumber { get; set; }

        public List<RakursUser> Users { get; set; }

        private DatabaseModel dbModel;
    }
}
