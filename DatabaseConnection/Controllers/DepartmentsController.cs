using DatabaseConnection.Models;
using DatabaseConnection.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnection.Controllers
{
    public class DepartmentsController
    {
        private DepartmentsModel _LModel = new DepartmentsModel();
        private Handling _handling = new Handling();
        private DepartmentsView _LView = new DepartmentsView();

        public void GetAll()
        {
            bool hasil = false;
            var list = _LModel.GetAll();
            if (list != null)
            {
                foreach (var item in list)
                {
                    _LView.Result(item.Id, item.Name, item.LocationId, item.ManagerId);
                }
            }
            else
            {
                _handling.NotSuccess();
            }
        }
    }
}
