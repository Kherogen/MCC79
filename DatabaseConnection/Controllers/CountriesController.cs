using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseConnection.Models;
using DatabaseConnection.Views;

namespace DatabaseConnection.Controllers
{
    public class CountriesController
    {
        private CountriesModel _CModel = new CountriesModel();
        private Handling _handling = new Handling();
        private CountriesView _CView = new CountriesView();
        private InputView _InputView = new InputView();
        /*private Models.CountriesModel _CModel = new Models.CountriesModel();*/

        public void GetAll()
        {
           
            bool result = false;
            var list = _CModel.GetAll();
            if (list != null)
            {
                result = true;
                foreach (var data in list) 
                {
                    _CView.Result(data.Id, data.Name, data.RegionId);
                }
            }
            else
            {
                _handling.NotSuccess();
            }

        }

        public CountriesModel GetById()
        {
            _CView.InputID();
            string id = Console.ReadLine();

            var data = _CModel.GetById(id);
            bool result = false;

            if (data != null)
            {
                _CView.Result(data.Id, data.Name, data.RegionId);
                result = true;
            }
            else { _handling.NotFoundByID(id); }

            return data;
        }

        public void Insert()
        {
            _CView.InputID();
            _CModel.Id = Console.ReadLine();

            _CView.InputName();
            _CModel.Name = Console.ReadLine();

            _CView.InputRegionId();
            _CModel.RegionId = _InputView.InputInt();

            int result = _CModel.Insert(_CModel.Id, _CModel.Name, _CModel.RegionId);

            if (result != 0)
            {
                _handling.Success();
            }
            else
            {
                _handling.NotFound();
            }
        }

        public void Update()
        {
            var data = GetById();
            if (data != null)
            {
                _CView.InputID();
                _CModel.Id = Console.ReadLine();
                _CView.InputName();
                _CModel.Name = Console.ReadLine();
                _CView.InputRegionId();
                _CModel.RegionId = _InputView.InputInt();

                int status = _CModel.Update(data.Id, data.Name, data.RegionId);
                if (status != 0)
                {
                    _handling.Success();
                }    
                else { _handling.NotFound(); }
            }
            else
            {
                _handling.NotSuccess();
            }
        }

        public void Delete()
        {
            var data = GetById();
            if (data != null)
            {
                int status = _CModel.Delete(data.Id);
                if (status != 0)
                {
                    _handling.Success();
                }
                else { _handling.NotSuccess(); }
            }
            else
            {
                _handling.NotFound();
            }
        }
    }
}
       