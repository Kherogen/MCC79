using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnection.Models
{
    public class Soal1
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Salary { get; set; }
        public string DName { get; set; }
        public string LStreet { get; set; }
        public string CName { get; set; }
        public string RName { get; set; }

        public Soal1 (int id, string fullName, string email, string phone, int salary, string dName, string lStreet, string cName, string rName)
        {
            Id = id;
            FullName = fullName;
            Email = email;
            Phone = phone;
            Salary = salary;
            DName = dName;
            LStreet = lStreet;
            CName = cName;
            RName = rName;
        }

        public Soal1 ()
        {

        }
    }
}
