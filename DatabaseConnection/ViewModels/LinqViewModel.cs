using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseConnection.Models;

namespace DatabaseConnection.ViewModels
{
    public class LinqViewModel
    {
        public List<Soal1> Soal1()
        {
            var employee = new EmployeesModel();
            var job = new JobsModel();
            var department = new DepartmentsModel();
            var country = new CountriesModel();
            var reg = new RegionsModel();
            var loc = new LocationsModel();

            var employees = (from e in employee.GetAll()
                             join d in department.GetAll() on e.DepartmentId equals d.Id
                             join l in loc.GetAll() on d.LocationId equals l.Id
                             join c in country.GetAll() on l.CountryId equals c.Id
                             join r in reg.GetAll() on c.RegionId equals r.Id
                             select new Soal1
                             {
                                 Id = e.Id,
                                 FullName = e.FirstName + "" + e.LastName,
                                 Email = e.Email,
                                 Phone = e.PhoneNumber,
                                 Salary = (int)e.Salary,
                                 DName = d.Name,
                                 LStreet = l.Street,
                                 CName = c.Name,
                                 RName = r.Name
                             });


            return employees.ToList();
        }

        public List<Soal2> Soal2()
        {
            var employee = new EmployeesModel();
            var job = new JobsModel();
            var department = new DepartmentsModel();
            var country = new CountriesModel();
            var reg = new RegionsModel();
            var loc = new LocationsModel();

            var soal2 = (from e in employee.GetAll()
                         join d in department.GetAll() on e.DepartmentId equals d.Id
                         group e by d.Name into DGroup
                         where DGroup.Count() > 3
                         select new Soal2
                         {
                             DName = DGroup.Key,
                             TotalEmp = DGroup.Count(),
                             MinSalary = (int)DGroup.Min(e => e.Salary),
                             MaxSalary = (int)DGroup.Max(e => e.Salary),
                             AvgSalary = (int)DGroup.Average(e => e.Salary),
                         });

            return soal2.ToList();
        }
    }
}
