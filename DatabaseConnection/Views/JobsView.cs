using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnection.Views
{
    public class JobsView
    {
        public void Result(string id, string tittle, int MinSalary, int MaxSalary)
        {
            Console.WriteLine($"||ID : {id} || Tittle : {tittle} || MIN SALARY : {MinSalary} || MAX SALARY : {MaxSalary} ");

        }
    }
}
