using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnection.Views
{
    public class RegionsView
    {
        public void InputId()
        {
            Console.Write("INPUT ID : ");
        }
        
        public void InputName()
        {
            Console.Write("INPUT NAME : ");
        }

        public void Result(int id, string name)
        {
            Console.WriteLine($"|ID : {id} | COUNTRY NAME : {name} ");
        }
    }
}
