using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginWithPassword.Models
{
    class RakursUser
    {
        public int Number { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
    }

    class MainWindowModel
    {
        public int IndexNumber { get; set; }
        public List<RakursUser> Users { get; set; }
    }
}
