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
    public class HistoriesController
    {
        private HistoriesModel _HModel = new HistoriesModel();
        private Handling _handling = new Handling();
        private HistoriesView _LView = new HistoriesView();

        public void GetAll()
        {
            bool hasil = false;
            var list = _HModel.GetAll();
            if (list != null)
            {
                foreach (var item in list)
                {
                    _LView.Result(item.StartDate, item.EmployeeId, item.EndDate, item.DepartmentId, item.JobId);
                }
            }
            else
            {
                _handling.NotSuccess();
            }
        }
    }
}
