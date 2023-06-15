using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
/* NOTE KHUSUS : Maaf Kaka atau Abang Trainer Saya Hanya Gabut Dan Memberikan Emote Love dan Kalimat BEB pada Aplikasi saya
    Saya tidak bermaksud merugikan atau menghina pihak manapun, tujuan saya hanya bercanda dan menghibur diri sendiri,
    kurang lebihnya mohon maaf Terima Kasih <3

                                                                                                            Tertanda Tangan

                                                                                                            Saya Sendiri Kherogen :)*/
namespace Authentication
{
    internal class Crud
    {

        private string NotFound() => "USER NOT FOUND!!!";
        private string Success(string value) => "User Success to " + value + "!!!";
        private string Success(string value, string error) => value + " failure, " + error + " already exists!!!";

        public string Create(List<User> users, User user)
        {
            if (new Auth().UserAuth(users, user.UserName))
                return this.Success(nameof(Create), "Username");
            users.Add(user);
            return this.Success("Created");
        }
        public string Edit(List<User> users, User user, int id)
        {

            bool namaPengguna = Auth.EditAuth(users, user.FirstName + user.LastName);
            if (!namaPengguna)
            {
                users[id - 1].FirstName = new Auth().NameAuthF(user.FirstName);
                users[id - 1].LastName = new Auth().NameAuthL(user.LastName);
                users[id - 1].UserName = user.FirstName.Substring(0, 2) + user.LastName.Substring(0, 2);
                users[id - 1].Password = new Auth().PasswordAuth(user.Password);
                return this.Success("Edited");
            }
            else 
            {
                return "ITS ALREADY EXISTS!!!";
            }
            

        }

        public string Delete(List<User> users, int id)
        {
            if (id > users.Count)
                return this.NotFound();
            users.RemoveAt(id - 1);
            return this.Success("Deleted");
        }
        public void View(List<User> Users)
        {
            int num = 0;
            foreach (User user in Users)
            {
                ++num;
                Console.WriteLine("========================");
                DefaultInterpolatedStringHandler StringHandler = new DefaultInterpolatedStringHandler(5, 1);
                StringHandler.AppendLiteral("ID\t: ");
                StringHandler.AppendFormatted<int>(num);
                Console.WriteLine(StringHandler.ToStringAndClear());
                Console.WriteLine("Name\t: " + user.FirstName + " " + user.LastName);
                Console.WriteLine("UserName: " + user.UserName);
                Console.WriteLine("Password: " + user.Password);
                Console.WriteLine("========================");
            }
        }
 


    }

}
