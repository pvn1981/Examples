using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LoginWithPassword.Models;

namespace LoginWithPassword.DesignTime
{
    public static class DesignTimeData
    {
        internal static MainWindowModel MainWindowModel
        {
            get
            {
                MainWindowModel model = new MainWindowModel();
                
                RakursUser user1 = new RakursUser() { Number = 0, Id = 1, Name = "User1"};
                RakursUser user2 = new RakursUser() { Number = 1, Id = 2, Name = "User2" };
                RakursUser user3 = new RakursUser() { Number = 2, Id = 3, Name = "User3" };

                model.Users = new List<RakursUser>();
                model.Users.Add(user1);
                model.Users.Add(user2);
                model.Users.Add(user3);

                return model;
            }
        }
    }
}
