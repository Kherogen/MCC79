using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* NOTE KHUSUS : Maaf Kaka atau Abang Trainer Saya Hanya Gabut Dan Memberikan Emote Love dan Kalimat BEB pada Aplikasi saya
    Saya tidak bermaksud merugikan atau menghina pihak manapun, tujuan saya hanya bercanda dan menghibur diri sendiri,
    kurang lebihnya mohon maaf Terima Kasih <3

                                                                                                            Tertanda Tangan

                                                                                                            Saya Sendiri Kherogen :)*/
namespace Authentication
{
    internal class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public User(string firstName, string lastName, string password)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.UserName = firstName.Substring(0, 2) + lastName.Substring(0, 2);
            this.Password = password;
        }

        public User()
        {
        }

    }

   
}
