using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseConnection.Models;
using DatabaseConnection.Views;


namespace DatabaseConnection.Controllers
{

    public class MenuController
    {
        private CountriesController _CController = new CountriesController();
        private RegionsController _RController = new RegionsController();
        private LocationsController _LController = new LocationsController();
        private JobsController _JController = new JobsController();
        private DepartmentsController _DController = new DepartmentsController();
        private EmployeesController _EController = new EmployeesController();
        private HistoriesController _HController = new HistoriesController();
        private LinqController _LinqController = new LinqController();
        private InputView _InputView = new InputView();
        private Handling _handling = new Handling();

        public void MainMenu()
        {
            bool ulang = true;
            do
            {
                Console.Clear();
                MenuView.MainMenu();
                int PilihMenu = _InputView.InputInt();
                switch (PilihMenu)
                {
                    case 1:
                        SubMenuCountries();
                        break;
                    case 2:
                        SubMenuRegions();
                        break;
                    case 3:
                        SubMenuLocations();
                        break;
                    case 4:
                        SubMenuJobs();
                        break;
                    case 5:
                        SubMenuDepartments();
                        break;
                    case 6:
                        SubMenuEmployees();
                        break;
                    case 7:
                        SubMenuHistories();
                        break;
                    case 8:
                        SubMenuLinq();
                        break;
                    case 0:
                        ulang = false;
                        break;
                    default:
                        _handling.WrongInput();
                        break;
                }

            } while (ulang);
        }

        public void SubMenuRegions()
        {
            bool ulang = true;
            do
            {
                Console.Clear();
                _RController.GetAll();

                MenuView.SubMenu();
                int PilihMenu = _InputView.InputInt();

                switch (PilihMenu)
                {
                    case 1:
                        Console.Clear();
                        _RController.GetById();
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.Clear();
                        _RController.Insert();
                        Console.ReadLine();
                        break;
                    case 3:
                        Console.Clear();
                        _RController.Update();
                        Console.ReadLine();
                        break;
                    case 4:
                        Console.Clear();
                        _RController.Delete();
                        Console.ReadLine();
                        break;
                    case 0:
                        ulang = false;
                        break;
                    default:
                        _handling.WrongInput();
                        Console.ReadLine();
                        break;
                }

            } while (ulang);
        }

        public void SubMenuCountries()
        {
            bool ulang = true;
            do
            {
                Console.Clear();
                _CController.GetAll();

                MenuView.SubMenu();
                int PilihMenu = _InputView.InputInt();

                switch (PilihMenu)
                {

                    case 1:
                        Console.Clear();
                        _CController.GetById();
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.Clear();
                        _CController.Insert();
                        Console.ReadLine();
                        break;
                    case 3:
                        Console.Clear();
                        _CController.Update();
                        Console.ReadLine();
                        break;
                    case 4:
                        Console.Clear();
                        _CController.Delete();
                        Console.ReadLine();
                        break;
                    case 0:
                        ulang = false;
                        break;

                    default:
                        _handling.WrongInput();
                        Console.ReadLine();
                        break;
                }
            } while (ulang);
        }
        public void SubMenuLocations()
        {
            bool ulang = true;
            do
            {
                Console.Clear();
                _LController.GetAll();

                MenuView.ExitMenu();
                int PilihMenu = _InputView.InputInt();

                switch (PilihMenu)
                {
                    case 0:
                        ulang = false;
                        break;
                    default:
                        _handling.WrongInput();
                        Console.ReadLine();
                        break;
                }
            } while (ulang);
        }
        public void SubMenuDepartments()
        {
            bool ulang = true;
            do
            {
                Console.Clear();
                _DController.GetAll();

                MenuView.ExitMenu();
                int PilihMenu = _InputView.InputInt();

                switch (PilihMenu)
                {
                    case 0:
                        ulang = false;
                        break;
                    default:
                        _handling.WrongInput();
                        Console.ReadLine();
                        break;
                }
            } while (ulang);
        }
        public void SubMenuJobs()
        {
            bool ulang = true;
            do
            {
                Console.Clear();
                _JController.GetAll();

                MenuView.ExitMenu();
                int PilihMenu = _InputView.InputInt();

                switch (PilihMenu)
                {
                    case 0:
                        ulang = false;
                        break;
                    default:
                        _handling.WrongInput();
                        Console.ReadLine();
                        break;
                }
            } while (ulang);
        }
        public void SubMenuEmployees()
        {
            bool ulang = true;
            do
            {
                Console.Clear();
                _EController.GetAll();

                MenuView.ExitMenu();
                int PilihMenu = _InputView.InputInt();

                switch (PilihMenu)
                {
                    case 0:
                        ulang = false;
                        break;
                    default:
                        _handling.WrongInput();
                        Console.ReadLine();
                        break;
                }
            } while (ulang);
        }
        public void SubMenuHistories()
        {
            bool ulang = true;
            do
            {
                Console.Clear();
                _HController.GetAll();

                MenuView.ExitMenu();
                int PilihMenu = _InputView.InputInt();

                switch (PilihMenu)
                {
                    case 0:
                        ulang = false;
                        break;
                    default:
                        _handling.WrongInput();
                        Console.ReadLine();
                        break;
                }
            } while (ulang);
        }

        public void SubMenuLinq()
        {
            bool ulang = true;
            do
            {
                Console.Clear();

                MenuView.LinqMenu();
                int PilihMenu = _InputView.InputInt();

                switch (PilihMenu)
                {
                    case 1:
                     Console.Clear();
                        _LinqController.GetSoal1();
                        Console.ReadLine();
                        break;

                    case 2:
                        Console.Clear();
                        _LinqController.GetSoal2();
                        Console.ReadLine();
                        break;
                    case 0:
                        ulang = false;
                        break;
                    default:
                        _handling.WrongInput();
                        Console.ReadLine();
                        break;
                }
            } while (ulang);
        }
    }
}
