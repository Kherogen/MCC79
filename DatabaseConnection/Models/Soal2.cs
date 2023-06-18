using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnection.Models
{
    public class Soal2
    {
        public string DName { get; set; }
        public int TotalEmp { get; set; }
        public int MinSalary { get; set; }
        public int MaxSalary { get; set; }
        public int AvgSalary { get; set; }

        public Soal2(string dName, int totalEmp, int minSalary, int maxSalary, int avgSalary)
        {
            DName = dName;
            TotalEmp = totalEmp;
            MinSalary = minSalary;
            MaxSalary = maxSalary;
            AvgSalary = avgSalary;
        }

        public Soal2() { }
    }
}
