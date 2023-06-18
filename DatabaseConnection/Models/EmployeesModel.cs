using DatabaseConnection.Contexts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnection.Models
{
    public class EmployeesModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime HireDate { get; set; }
        public int Salary { get; set; }
        public Decimal? ComissionPct { get; set; }
        public int ManagerId { get; set; }
        public string JobId { get; set; }
        public int DepartmentId { get; set; }

        public EmployeesModel(int Id, string FirstName, string LastName, string Email, string PhoneNumber, DateTime HireDate, int Salary, decimal? ComissionPct, int ManagerId, string JobId, int DepartmentId)
        {
            this.Id = Id;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.PhoneNumber = PhoneNumber;
            this.HireDate = HireDate;
            this.Salary = Salary;
            this.ComissionPct = ComissionPct;
            this.ManagerId = ManagerId;
            this.JobId = JobId;
            this.DepartmentId = DepartmentId;
        }

        public EmployeesModel() { }

        public List<EmployeesModel> GetAll()
        {
            var emp = new List<EmployeesModel>();
            SqlConnection connection = MyConnection.Get();
            connection.Open();
            try
            {
                //Membuat Instance Untuk Command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_m_employees";
                //Membuka Koneksi

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var emps = new EmployeesModel();
                        emps.Id = reader.GetInt32(0);
                        emps.FirstName = reader.GetString(1);
                        emps.LastName = reader.GetString(2);
                        emps.Email = reader.GetString(3);
                        emps.PhoneNumber = reader.GetString(4);
                        emps.HireDate = reader.GetDateTime(5);
                        emps.Salary = reader.GetInt32(6);
                        if (reader.IsDBNull(7))
                        {
                            emps.ComissionPct = null;
                        }
                        else
                        {
                            emps.ComissionPct = reader.GetDecimal(7);
                        }
                        emps.ManagerId = reader.GetInt32(8);
                        emps.JobId = reader.GetString(9);
                        emps.DepartmentId = reader.GetInt32(10);

                        emp.Add(emps);
                    }
                }
                else
                {
                    Console.WriteLine("Data Not Found!");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            connection.Close();
            return emp;
        }
    }
}
