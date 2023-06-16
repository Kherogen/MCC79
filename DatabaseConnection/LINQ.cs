using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnection
{
    public class LINQ
    {
        public void MenuLINQ()
        {
            Console.Clear();
            Console.WriteLine("1.Soal 1");
            Console.WriteLine("2.Soal 2");

            try
            {
                Console.Write("PILIH MENU : ");
                int Pilihan = int.Parse(Console.ReadLine());
                switch (Pilihan)
                {
                    case 1:
                        Soal1();
                        break;
                    case 2:
                        Soal2();
                        break;
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
            

            // var employees = employee.GetAllEmployee().Where(e => e.first_name.Contains("J"));
            /*var employees = from e in employee.GetAllEmployee()
                            where e.first_name.Contains("J")
                            select e;*/

            /*var employees = employee.GetAllEmployee()
                                    .Join(job.GetAllJob(),
                                          e => e.job_id,
                                          j => j.id,
                                          (e, j) => new {
                                              FirstName = e.first_name,
                                              LastName = e.last_name,
                                              Job = j.title
                                          }).LastOrDefault(e => e.FirstName.Contains("J"));*/


           

            // Console.WriteLine($"{employees.FirstName} {employees.LastName} {employees.Job} {employees.Department}");

           

          
            /* var huruf = "J";
             var angka = 1;*/
        }
        public void Soal1()
        {
            var employee = new Employees();
            var job = new Jobs();
            var department = new Departments();
            var country = new Countries();
            var reg = new Regions();
            var loc = new Locations();

            var employees = (from e in employee.GetAllEmp()
                             join d in department.GetAllDep() on e.department_id equals d.id
                             join l in loc.GettAllLoc() on d.location_id equals l.id
                             join c in country.GetAllCountries() on l.co_id equals c.Id
                             join r in reg.GetAllRegions() on c.RegionId equals r.Id
                             select new Soal1
                             {
                                 Id = e.id,
                                 FullName = e.first_name + "" + e.last_name,
                                 Email = e.email,
                                 Phone = e.phone_number,
                                 Salary = (int)e.salary,
                                 DName = d.name,
                                 LStreet = l.street,
                                 CName = c.Name,
                                 RName = r.Name
                             });
            var filtered = employees.Take(5).ToList();

            /*         Console.WriteLine(employees.Count() == 0);*/
            foreach (var emp in filtered)
            {
                Console.WriteLine($"ID : {emp.Id} NAME : {emp.FullName} EMAIL : {emp.Email} PHONE : {emp.Phone} SALARY : {emp.Salary} DEPARTMENT : {emp.DName} STREET : {emp.LStreet} COUNTRY :  {emp.CName} REGION : {emp.RName} ");
            }
            Console.ReadKey();
            MenuLINQ();
        }
        public void Soal2()
        {
            var employee = new Employees();
            var job = new Jobs();
            var department = new Departments();
            var country = new Countries();
            var reg = new Regions();
            var loc = new Locations();

            var soal2 = (from e in employee.GetAllEmp()
                         join d in department.GetAllDep() on e.department_id equals d.id
                         group e by d.name into DGroup
                         where DGroup.Count() > 3
                         select new Soal2
                         {
                             DName = DGroup.Key,
                             TotalEmp = DGroup.Count(),
                             MinSalary = (int)DGroup.Min(e => e.salary),
                             MaxSalary = (int)DGroup.Max(e => e.salary),
                             AvgSalary = (int)DGroup.Average(e => e.salary),
                         });
            var filtered = soal2.ToList();

            foreach (var soal in filtered)
            {
                Console.WriteLine($"DEPARTMEN : {soal.DName} TOTAL : {soal.TotalEmp} MIN SALARY : {soal.MinSalary} MAX SALARY : {soal.MaxSalary} AVERAGE SALARY : {soal.AvgSalary}");
            }
            Console.ReadKey();
            MenuLINQ();



        }
    }
}
