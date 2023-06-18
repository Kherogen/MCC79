using DatabaseConnection.Models;
using DatabaseConnection.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnection.Controllers
{
   
    public class JobsController
    {
        private JobsModel _JModel = new JobsModel();
        private Handling _handling = new Handling();
        private JobsView _LView = new JobsView();

        public void GetAll()
        {
            bool hasil = false;
            var list = _JModel.GetAll();
            if (list != null)
            {
                foreach (var item in list)
                {
                    _LView.Result(item.Id, item.Tittle, item.MinSalary, item.MaxSalary);
                }
            }
            else
            {
                _handling.NotSuccess();
            }
        }
    }
}
