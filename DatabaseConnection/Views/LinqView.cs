using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnection.Views
{
    public class LinqView
    {
      public void Result1(int id, string fullName, string email, string phone, int salary, string dName, string lStreet, string cName, string rName)
        {
            Console.WriteLine($"||ID : {id} || FULL NAME : {fullName} || Email : {email} || Phone Number : {phone} || Salary : {salary} ||  Department Name : {dName} || STREET : {lStreet} || Country Name : {cName} || Region Name : {rName}");
        }

        public void Result2(string dName, int totalEmp, int minSalary, int maxSalary, int avgSalary)
        {
            Console.WriteLine($"|| Department Name : {dName} || TOTAL EMPLOYEE : {totalEmp} ||  || MIN SALARY : {minSalary} || MAX SALARY : {maxSalary} || AVERAGE SALARY : {avgSalary}");
        }
    }
}
