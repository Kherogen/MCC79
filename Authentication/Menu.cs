using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
#nullable enable
namespace Authentication
/* NOTE KHUSUS : Maaf Kaka atau Abang Trainer Saya Hanya Gabut di jam 03.43 subuh per tanggal 11/06/2023 saat city sudah menang 1 : 0 
 * Dan Memberikan Emote Love dan Kalimat BEB pada Aplikasi saya
   Saya tidak bermaksud merugikan atau menghina pihak manapun, tujuan saya hanya bercanda dan menghibur diri sendiri,
   kurang lebihnya mohon maaf Terima Kasih <3

                                                                                                            Tertanda Tangan

                                                                                                            Saya Sendiri Kherogen :)*/


{
    internal class Menu
    {
        private Crud crud = new Crud();
        private List<User> listusers = new List<User>();
        private List<Admin> admins = new List<Admin>() { new Admin("Admin", "Admin") };
        public void App()
        {
            Console.Clear();
            Console.WriteLine("======BASIC AUTH========");
            Console.WriteLine("1. Create User");
            Console.WriteLine("2. Login");


            Console.WriteLine("5. LogOut");
            Console.WriteLine("6. Exit");
            Console.Write("Boleh Diinput : ");
            try
            {
                int InputPilihan = Convert.ToInt32(Console.ReadLine());

                switch (InputPilihan)
                {
                    case 1:
                        this.CreateUser(this.listusers);
                        break;
                    case 2:
                        this.Login(this.listusers, this.admins);
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Anda Telah Logout!");
                        Console.ReadKey();
                        Thread.Sleep(1000);
                        this.App();
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Salah Input !!!");
                        Console.ReadKey();
                        this.App();
                        break;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : Input Not Valid !!!");
                Console.ReadKey();
                this.App();
            }
        }

        public void MenuAdmin()
        {
            Console.Clear();
            Console.WriteLine("======BASIC AUTH========");
            Console.WriteLine("1. Create User");
            Console.WriteLine("2. Search User");
            Console.WriteLine("3. View User");
            Console.WriteLine("4. Menu User");
            Console.WriteLine("5. LogOut");
            Console.WriteLine("6. Exit");
            Console.Write("Boleh Diinput : ");
            try
            {
                int InputPilihan = Convert.ToInt32(Console.ReadLine());

                switch (InputPilihan)
                {
                    case 1:
                        this.CreateUserAdmin(this.listusers);
                        break;
                    case 2:
                        this.Cari(this.listusers);
                        break;
                    case 3:
                        this.ViewUser(this.listusers);
                        break;
                    case 4:
                        this.AppUser();
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Anda Telah Logout!");
                        Console.ReadKey();
                        Thread.Sleep(1000);
                        this.App();
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Salah Input !!!");
                        Console.ReadKey();
                        this.MenuAdmin();
                        break;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : Input Not Valid !!!");
                Console.ReadKey();
                this.App();
            }
        }
        private void Cari(List<User> listUsers)
        {
            List<User> userList = new List<User>();
            Console.Clear();
            Console.WriteLine("======SEARCH USER========");
            Console.Write("Masukan Nama : ");
            string name = Console.ReadLine();
            this.crud.View(listUsers.Where<User>((Func<User, bool>)
                (i => i.FirstName.ToLower().Contains(name.ToLower())
                || i.LastName.ToLower().Contains(name.ToLower())))
                .Select<User, User>((Func<User, User>)(g => new User()
                {
                    FirstName = g.FirstName,
                    LastName = g.LastName,
                    UserName = g.UserName,
                    Password = g.Password
                })).ToList<User>());
            Console.ReadKey();
            this.MenuAdmin();
        }

        public void CreateUser(List<User> listuser)
        {
            Auth auth = new Auth();
            Console.Clear();
            Console.WriteLine("=========================");
            Console.Write("First Name : ");
            string firstName = auth.NameAuthF(Console.ReadLine());
            Console.Write("Last Name : ");
            string lastName = auth.NameAuthL(Console.ReadLine());
            Console.Write("Password : ");
            string password = auth.PasswordAuth(Console.ReadLine());
            User user = new User(firstName, lastName, password);
            Console.WriteLine(this.crud.Create(listuser, user));
            Console.ReadKey();
            this.App();
        }
        public void CreateUserAdmin(List<User> listuser)
        {
            Auth auth = new Auth();
            Console.Clear();
            Console.WriteLine("=========================");
            Console.Write("First Name : ");
            string firstName = auth.NameAuthF(Console.ReadLine());
            Console.Write("Last Name : ");
            string lastName = auth.NameAuthL(Console.ReadLine());
            Console.Write("Password : ");
            string password = auth.PasswordAuth(Console.ReadLine());
            User user = new User(firstName, lastName, password);
            Console.WriteLine(this.crud.Create(listuser, user));
            Console.ReadKey();
            this.MenuAdmin();
        }

        public void Login(List<User> listUser, List<Admin> admins)
        {
            Auth login = new Auth();
            Console.Clear();
            Console.WriteLine("======LOGIN========");
            Console.Write("USERNAME : ");
            string stru = Console.ReadLine();
            Console.Write("PASSWORD : ");
            string katasandi = Auth.HasingPassword();
            List<User> listUser1 = listUser;
            List<Admin> admins1 = admins;
            string namaUser = stru;
            string admin = "Admin";
            string password = "Admin";

            if (login.Authentication(listUser1, namaUser, katasandi))
            {

                Console.WriteLine("\nLOGINNYA BERHASIL !");
                Console.ReadKey();
                Console.Clear();
                AppUser();
            }
            if (login.AuthenticationAdmin(admins1, admin, password))
            {

                Console.WriteLine("\nLOGINNYA BERHASIL !");
                Console.ReadKey();
                Console.Clear();
                this.MenuAdmin();
            }
            else
            {
                Console.WriteLine("Username Atau Passowrd Tidak Ditemukan !!!");
                Console.ReadKey();
                this.App();
            }

        }

        private void EditUser(List<User> users, User user)
        {
            bool flag;
            do
            {
                Console.WriteLine("=========================");
                Console.Write("Id Yang Ingin Diubah : ");
                int int32 = Convert.ToInt32(Console.ReadLine());
                if (int32 <= users.Count)
                {
                    Auth edit = new Auth();
                    Console.WriteLine("=========================");
                    Console.Write("First Name : ");
                    user.FirstName = edit.NameAuthF(Console.ReadLine());
                    new Auth().NameAuthF(user.FirstName);
                    Console.Write("Last Name : ");
                    user.LastName = edit.NameAuthL(Console.ReadLine());
                    new Auth().NameAuthL(user.LastName);
                    Console.Write("Password : ");
                    user.Password = edit.PasswordAuth(Console.ReadLine());
                    new Auth().PasswordAuth(user.Password);
                    Console.WriteLine(this.crud.Edit(users, user, int32));
                    flag = false;

                }
                else
                {
                    Console.WriteLine(" User Tidak Ditemukan !!!");
                    flag = true;
                }

            }
            while (flag);
            Console.ReadKey();
            this.ViewUser(users);
        }
        private void DeleteUser(List<User> users)
        {
            Console.WriteLine("=========================");
            Console.Write("Hayooo Id Mana Yang Ingin Dihapus : ");
            int int32 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(this.crud.Delete(users, int32));
            Console.ReadKey();
            this.ViewUser(users);
        }

        private void ViewUser(List<User> users)
        {
            User user = new User();
            Console.Clear();
            Console.WriteLine("======SHOW USERS========");
            this.crud.View(users);
            Console.WriteLine("\nMenu");
            Console.WriteLine("1. Edit User");
            Console.WriteLine("2. Delete User");
            Console.WriteLine("3. Back");
            Console.WriteLine("=========================");
            Console.Write("Ayoo Di Input say : ");
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    this.EditUser(users, user);
                    break;
                case 2:
                    this.DeleteUser(users);
                    break;
                case 3:
                    this.MenuAdmin();
                    break;
                default:
                    Console.WriteLine("");
                    Console.ReadKey();
                    this.ViewUser(users);
                    break;
            }
            Console.ReadKey();
        }
        public void AppUser()
        {
            Console.Clear();
            Console.WriteLine("===========================================================");
            Console.WriteLine("".PadRight(20) + "Menu Ganjil Genap".PadRight(30));
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("1. Cek Ganjil Genap ");
            Console.WriteLine("2. Print Ganjil / Genap (dengan limit)");
            Console.WriteLine("3. Logout!"); ;
            Console.WriteLine("-----------------------------------------------------------");

            Console.Write("Pilihan: ");
                try
                {
                    int InputPilihan = Convert.ToInt32(Console.ReadLine());
                    switch (InputPilihan)
                    {
                        case 1:
                            Console.Clear();
                            Console.Write("Masukan Bilangan Yang Ingin Dicek : ");

                            string input_number = Console.ReadLine();
                            int number;

                            if (!int.TryParse(input_number, out number))
                            {
                                Console.WriteLine("Input Pilihan Tidak Valid. Harap Masukkan Bilangan Bulat.");
                                Thread.Sleep(2000);
                                Console.Clear();
                                AppUser();
                            }
                            Console.WriteLine(EvenOddCheck(number));
                            Thread.Sleep(2000);
                            Console.Clear();
                            AppUser();
                            break;
                        case 2:
                            Console.Write("Pilih (Ganjil/Genap) : ");
                            string even_or_odd = Console.ReadLine().Trim();
                            Console.Write("Masukan limit : ");
                            string input_limit = Console.ReadLine();
                            int limit;

                            if (!int.TryParse(input_limit, out limit))
                            {
                                Console.WriteLine("Input Pilihan Tidak Valid. Harap Masukkan Bilangan Bulat.");
                                Thread.Sleep(2000);
                                Console.Clear();
                                AppUser();
                            }
                            PrintEvenOdd(limit, even_or_odd);
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("Anda Telah Logout!");
                            Console.ReadKey();
                            Thread.Sleep(1000);
                            this.App();
                            break;
                        default:
                            Console.WriteLine("Input Pilihan Tidak Valid!!!");
                            Thread.Sleep(2000);
                            Console.Clear();
                            AppUser();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR : Input Not Valid !!!");
                    Console.ReadKey();
                    this.AppUser();
                }
            

        }
        /*Pada method ini saya menggunakan if else decission dan menampung nilai atau inputan limit kedalam List 
         * foreach looping digunakan untuk menghitung angka ganjil/genap berdasarkan limit yang ditentukan
         * dengan melakukan increment += 2 jika bilangan ganjil maka increment dimulai dari 1 lalu di increment +2 sesuai limit
         * jika bilangan genap maka increment dimulai dari 2 dan di increment +2 sesuai limit */
        public void PrintEvenOdd(int limit, string choice)

        {
            if (limit <= 0)
            {
                Console.WriteLine("Print bilangan 1 - " + limit);
                Console.WriteLine("Input Limit Tidak Valid!!!");

            }

            List<int> numberList = new List<int>();

            if (choice.ToLower() == "ganjil")
            {
                for (int i = 1; i <= limit; i += 2)
                {
                    numberList.Add(i);
                }

                Console.WriteLine("Print bilangan 1 - " + limit);

                foreach (int i in numberList)
                {
                    Console.Write(", " + i);
                }
                Thread.Sleep(2000);
                Console.Clear();
                AppUser();
            }
            else if (choice.ToLower() == "genap")
            {
                for (int i = 2; i <= limit; i += 2)
                {
                    numberList.Add(i);
                }

                Console.WriteLine("Print bilangan 1 - " + limit);

                foreach (int i in numberList)
                {
                    Console.Write(", " + i);
                }
                Thread.Sleep(2000);
                Console.Clear();
                AppUser();
            }
            else
            {
                Console.WriteLine("Invalid input (silahkan pilih Ganjil atau Genap)!");
                Thread.Sleep(2000);
                Console.Clear();
                AppUser();
            }
        }
        /*Pada method ini saya menggunakan if else function dimana return valuenya berupa string dan
         * menggunakan modulus untuk pengecekkan ganjil atau genap */
        public string EvenOddCheck(int input)
        {
            if (input % 2 == 0)
            {
                return "Genap";
            }
            if (input % 2 == 1)
            {
                return "Ganjil";
            }
            else
            {
                return "Bilangan Tidak Valid";
            }

        }
    }


}

