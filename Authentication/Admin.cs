using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication
{
    internal class Admin
    {

        public string UserNameAdmin { get; set; }
        public string PasswordAdmin { get; set; }

        public Admin(string usernameadmin, string passwordadmin)
        {
  
            this.UserNameAdmin = usernameadmin;
            this.PasswordAdmin = passwordadmin;

        }

        public Admin()
        {
        }
    }
}
