using DatabaseConnection.Models;
using DatabaseConnection.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnection.Controllers
{
    public class EmployeesController
    {
        private EmployeesModel _EModel = new EmployeesModel();
        private Handling _handling = new Handling();
        private EmployeesView _EView = new EmployeesView();
        public void GetAll()
        {
            bool hasil = false;
            var list = _EModel.GetAll();
            if (list != null)
            {
                foreach (var item in list)
                {
                    _EView.Result(item.Id, item.FirstName, item.LastName, item.Email, item.PhoneNumber, item.HireDate, item.Salary, item.ComissionPct, item.ManagerId, item.JobId, item.DepartmentId);
                }
            }
            else
            {
                _handling.NotSuccess();
            }
        }
    }
}
