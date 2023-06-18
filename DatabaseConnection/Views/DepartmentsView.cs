using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnection.Views
{
    public class DepartmentsView
    {
        public void Result(int Id, string Name, int LocationId, int ManagerId)
        {
            Console.WriteLine($"|ID : {Id} | Country : {Name} | Region ID : {LocationId} | MANAGER ID : {ManagerId} ");
        }
    }
}
