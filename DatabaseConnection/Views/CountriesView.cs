using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnection.Views
{
    public class CountriesView
    {

        public void InputID()
        {
            Console.Write("INPUT ID : ");
        }
        public void InputName()
        {
            Console.Write("INPUT NAME : ");
        }
        public void InputRegionId()
        {
            Console.Write("INPUT REGION ID : ");
        }

        public void Result(string id, string name, int regionId)
        {
            Console.WriteLine($"|ID : {id} | Country : {name} | Region ID : {regionId}");

        }
    }
}
