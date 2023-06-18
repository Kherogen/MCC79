using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnection.Views
{
    public class EmployeesView
    {
        public void Result(int Id, string FirstName, string LastName, string Email, string PhoneNumber, DateTime HireDate, int Salary, decimal? ComissionPct, int ManagerId, string JobId, int DepartmentId)
        {
            Console.WriteLine($"||ID : {Id} || FirstName : {FirstName} || Last Name : {LastName} || Email : {Email} || Phone Number : {PhoneNumber} || Hire Date : {HireDate} || Salary : {Salary} || Comission PCT : {ComissionPct} || Manager ID : {ManagerId} || JOB ID : {JobId} || Department ID : {DepartmentId}");

        }
    }
}
