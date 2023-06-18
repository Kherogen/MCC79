using DatabaseConnection.Models;
using DatabaseConnection.Views;
using DatabaseConnection.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnection.Controllers
{
    public class LinqController
    {
        private LinqViewModel _LinqModel = new LinqViewModel();
        private LinqViewModel _LinqViewModel = new LinqViewModel();
        private Handling _handling = new Handling();
        private LinqView _LinqView = new LinqView();

        public void GetSoal1()
        {
            bool hasil = false;
            var list = _LinqViewModel.Soal1();
            if (list != null)
            {
                var filtered = list.Take(5).ToList();

                foreach (var item in filtered)
                {
                    _LinqView.Result1(item.Id, item.FullName, item.Email, item.Phone, item.Salary, item.DName,item.LStreet, item.CName, item.RName);
                }
            }
            else
            {
                _handling.NotSuccess();
            }

        }
        public void GetSoal2()
        {
            bool hasil = false;
            var list = _LinqViewModel.Soal2();
            if (list != null)
            {
                

                foreach (var item in list)
                {
                    _LinqView.Result2(item.DName,item.TotalEmp, item.MinSalary, item.MaxSalary, item.AvgSalary);
                }
            }
            else
            {
                _handling.NotSuccess();
            }

        }
    }
}
