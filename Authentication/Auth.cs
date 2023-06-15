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
    internal class Auth
    {



        public static bool EditAuth(List<User> users, string nameUser)

        {
            foreach (var user in users)
            {
                if (user.UserName == nameUser)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        public bool Authentication(List<User> listUser, string namaUser, string katasandi)
        {
            bool flag = false;
            for (int index = 0; index < listUser.Count; ++index)
            {
                if (namaUser == listUser[index].UserName && katasandi == listUser[index].Password)
                {
                    flag = true;
                    break;
                }

            }

            return flag;
        }
        public bool AuthenticationAdmin(List<Admin> listAdmin, string namaAdmin, string katasandi)
        {
            bool flag = false;
            for (int index = 0; index < listAdmin.Count; ++index)
            {
                if (namaAdmin == listAdmin[index].UserNameAdmin && katasandi == listAdmin[index].PasswordAdmin)
                {
                    flag = true;
                    break;
                }

            }

            return flag;
        }


        public string NameAuthF(string nama)
        {
            bool flag = true;
            if (nama.Length < 2)
            {
                        Console.WriteLine("\nName has to bea at least consisting 2 characters or more.");
                        Console.Write("First Name : ");
                        nama = this.NameAuthF(Console.ReadLine());
                        flag = false;
                        return nama;
            }
            flag = true;
            return nama;
        }
        public string NameAuthL(string nama)
        {
            bool flag = true;
            if (nama.Length < 2)
            {
                Console.WriteLine("\nName has to bea at least consisting 2 characters or more.");
                Console.Write("Last Name : ");
                nama = this.NameAuthL(Console.ReadLine());
                flag = false;
                return nama;
            }
            flag = true;
            return nama;
        }

        public string PasswordAuth(string katasandi)
        {
            bool flag;
            do
            {
                if (katasandi.Length > 7 &&
             katasandi.Any(char.IsUpper) &&
             katasandi.Any(char.IsLower) &&
             katasandi.Any(char.IsNumber))

                {
                    flag = false;
                }
                else
                {
                    Console.WriteLine("Kata sandi tidak memenuhi persyaratan.");
                    Console.Write("Masukkan kembali kata sandi: ");
                    katasandi = this.PasswordAuth(Console.ReadLine());
                    flag = true;
                }
            }
            while (flag);
            return katasandi;
        }

        public bool UserAuth(List<User> users, string userName)
        {
            for (int index = 0; index < users.Count; index++)
            {
                if (users[index].UserName == userName)
                    return true;
            }
            return false;
        }
        public static string HasingPassword()
        {
            string password = "";
            ConsoleKeyInfo keyInfo;

            do
            {
                keyInfo = Console.ReadKey(true);
                // Skip if Backspace or Enter is Pressed
                if (keyInfo.Key != ConsoleKey.Backspace && keyInfo.Key != ConsoleKey.Enter)
                {
                    password += keyInfo.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (keyInfo.Key == ConsoleKey.Backspace && password.Length > 0)
                    {
                        // Remove last charcter if Backspace is Pressed
                        password = password.Substring(0, (password.Length - 1));
                        Console.Write("\b \b");
                    }
                }
            }
            // Stops Getting Password Once Enter is Pressed
            while (keyInfo.Key != ConsoleKey.Enter);
            return password;
        }

    }
}
