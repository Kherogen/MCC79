using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnection.Views
{
    public class HistoriesView
    {
        public void Result(DateTime StartDate, int EmployeeId, DateTime? EndDate, int DepartmentId, string JobId)
        {
            Console.WriteLine($"||START DATE : {StartDate} || Employee ID : {EmployeeId} || END DATE : {EndDate} || Department ID : {DepartmentId} || JOB ID : {JobId} ");

        }
    }
}
