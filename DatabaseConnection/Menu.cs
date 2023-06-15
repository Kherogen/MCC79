using Microsoft.VisualBasic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DatabaseConnection
{
    public class Menu
    {
        Regions reg = new Regions();
        Countries cou = new Countries();
        Locations loc = new Locations();
        Jobs job = new Jobs();
        Departments dep = new Departments();
        Employees emp = new Employees();
        Histories his = new Histories();
        LINQ linq = new LINQ();
        public void MenuDb()
        {
            Console.Clear();
            Console.WriteLine("1.Countries");
            Console.WriteLine("2.Regions");
            Console.WriteLine("3.Locations");
            Console.WriteLine("4.Jobs");
            Console.WriteLine("5.Departments");
            Console.WriteLine("6.Employees");
            Console.WriteLine("7.Histories");
            Console.WriteLine("8.LINQ");
            Console.WriteLine("9.EXIT");

            try
            {
                Console.Write("Pilih Tabel : ");
                int InputPilihan = Convert.ToInt32(Console.ReadLine());

                switch (InputPilihan)
                {
                    case 1:
                        Console.Clear();
                        cou.MenuCountries();
                        break;
                    case 2:
                        Console.Clear();
                        reg.MenuRegion();
                        break;
                    case 3:
                        Console.Clear();
                        loc.MenuLocations();
                        break;
                    case 4:
                        Console.Clear();
                        job.MenuJobs();
                        break;
                    case 5:
                        Console.Clear();
                        dep.MenuDep();
                        break;
                    case 6:
                        Console.Clear();
                        emp.MenuEmp();
                        break;
                    case 7:
                        Console.Clear();
                        his.MenuHist();
                        break;
                    case 8:
                        linq.MenuLINQ();
                        break;
                    case 9:
                        System.Environment.Exit(0);
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


    }
}
