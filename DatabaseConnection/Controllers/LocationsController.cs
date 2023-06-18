using DatabaseConnection.Models;
using DatabaseConnection.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DatabaseConnection.Controllers
{
    public class LocationsController
    {
        private LocationsModel _LModel = new LocationsModel();
        private Handling _handling = new Handling();
        private LocationsView _LView = new LocationsView();
        public void GetAll()
        {
            bool hasil = false;
            var list = _LModel.GetAll();
            if (list != null)
            {
                foreach ( var item in list) 
                {
                    _LView.Result(item.Id, item.Street, item.Post, item.City,item.State, item.CountryId);
                }
            }
            else
            {
                _handling.NotSuccess();
            }
        }
    }
}
