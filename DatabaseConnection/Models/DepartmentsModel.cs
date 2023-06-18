using DatabaseConnection.Contexts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnection.Models
{
    public class DepartmentsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LocationId { get; set; }
        public int ManagerId { get; set; }

        public DepartmentsModel(int Id, string Name, int LocationId, int ManagerId)
        {
            this.Id = Id;
            this.Name = Name;
            this.LocationId = LocationId;
            this.ManagerId = ManagerId;
        }

        public DepartmentsModel() { }

        public List<DepartmentsModel> GetAll()
        {
            var deps = new List<DepartmentsModel>();
            SqlConnection connection = MyConnection.Get();
            connection.Open();
            try
            {
                //Membuat Instance Untuk Command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_m_departments";
                //Membuka Koneksi

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var dep = new DepartmentsModel();
                        dep.Id = reader.GetInt32(0);
                        dep.Name = reader.GetString(1);
                        dep.LocationId = reader.GetInt32(2);
                        dep.ManagerId = reader.GetInt32(3);

                        deps.Add(dep);
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
            return deps;
        }
    }
}
