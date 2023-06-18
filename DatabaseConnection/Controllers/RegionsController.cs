using DatabaseConnection.Models;
using DatabaseConnection.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnection.Controllers
{
    public class RegionsController
    {
        private RegionsModel _RModel = new RegionsModel();
        private Handling _handling = new Handling();
        private RegionsView _RView = new RegionsView();
        private InputView _InputView = new InputView();

        public void GetAll()
        {
            bool result = false;
            var list = _RModel.GetAll();

            if (list != null)
            {
                result = true;
                foreach (var data in list)
                {
                    _RView.Result(data.Id, data.Name);
                }
            }
            else
            {
                _handling.NotSuccess();
            }
        }

        public RegionsModel GetById()
        {

            _RView.InputId();
            int id = _InputView.InputInt();

            var data = _RModel.GetById(id);
            bool result = false;

            if (data != null)
            {
                _RView.Result(data.Id, data.Name);
                result = true;
            }
            else
            {
                _handling.NotFoundByID(id);
            }
            return data;
        }

        public void Insert()
        {
            _RView.InputName();
            _RModel.Name = Console.ReadLine();

            int result = _RModel.Insert(_RModel.Name);

            if (result != 0)
            {
                _handling.Success();
            }
            else
            {
                _handling.NotSuccess();
            }
        }

        public void Update()
        {
            var data = GetById();

            if (data != null)
            {
                _RView.InputName();
                _RModel.Name = Console.ReadLine();

                int status = _RModel.Update(data.Id, _RModel.Name);
                if (status != 0)
                {
                    _handling.Success();
                }
                else { _handling.NotFound(); }
            }
            else { _handling.NotSuccess(); }
        }

        public void Delete()
        {
            var data = GetById();

            if (data != null)
            {
                int status = _RModel.Delete(data.Id);
                if (status != 0)
                {
                    _handling.Success();
                }
                else { _handling.NotSuccess(); }

            }
            else { _handling.NotFound(); }
        }
    }
}
