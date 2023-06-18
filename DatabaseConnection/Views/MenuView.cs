using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnection.Views
{
    public class MenuView
    {
        public static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("MAIN MENU ");
            Console.WriteLine("==================================================");
            Console.WriteLine("1.Countries");
            Console.WriteLine("2.Regions");
            Console.WriteLine("3.Locations");
            Console.WriteLine("4.Jobs");
            Console.WriteLine("5.Departments");
            Console.WriteLine("6.Employees");
            Console.WriteLine("7.Histories");
            Console.WriteLine("8.LINQ");
            Console.WriteLine("0.EXIT");
            Console.WriteLine("==================================================");
            Console.Write("PILIH MENU : ");

        }

        public static void SubMenu()
        {
            Console.WriteLine("\n");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("MENU CRUD");
            Console.WriteLine("==================================================");
            Console.WriteLine("1. Get Data By Id");
            Console.WriteLine("2. Insert Data");
            Console.WriteLine("3. Update Data By Id");
            Console.WriteLine("4. Delete Data By Id");
            Console.WriteLine("0. Exit");
            Console.WriteLine("==================================================");
            Console.Write("PILIH MENU : ");
        }
        public static void LinqMenu()
        {
            Console.WriteLine("\n");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("MENU LINQ");
            Console.WriteLine("==================================================");
            Console.WriteLine("1. HASIL SOAL LINQ 1");
            Console.WriteLine("2. HASIL SOAL LINQ 2");
            Console.WriteLine("0. Exit");
            Console.Write("PILIH MENU : ");
        }
        public static void ExitMenu()
        {
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("MAIN MENU");
            Console.WriteLine("==================================================");
            Console.WriteLine("0. Exit");
            Console.WriteLine("==================================================");
            Console.Write("PILIH MENU : ");
        }
    }
}
