using DatabaseConnection.Contexts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnection.Models
{
    public class HistoriesModel
    {
        public DateTime StartDate { get; set; }
        public int EmployeeId { get; set; }
        public DateTime? EndDate { get; set; }
        public int DepartmentId { get; set; }
        public string JobId { get; set; }

        public HistoriesModel(DateTime StartDate, int EmployeeId, DateTime? EndDate, int DepartmentId, string JobId)
        {
            this.StartDate = StartDate;
            this.EmployeeId =   EmployeeId;
            this.EndDate = EndDate;
            this.DepartmentId = DepartmentId;
            this.JobId = JobId;
        }

        public HistoriesModel() { }

        public List<HistoriesModel> GetAll()
        {
            var hist = new List<HistoriesModel>();
            SqlConnection connection = MyConnection.Get();
            connection.Open();
            try
            {
                //Membuat Instance Untuk Command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_tr_histories";
                //Membuka Koneksi

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var his = new HistoriesModel();
                        his.StartDate = reader.GetDateTime(0);
                        his.EmployeeId = reader.GetInt32(1);
                        if (reader.IsDBNull(2))
                        {
                            his.EndDate = null; // Atur sebagai null jika nilainya null
                        }
                        else
                        {
                            his.EndDate = reader.GetDateTime(2);
                        }

                        his.DepartmentId = reader.GetInt32(3);
                        his.JobId = reader.GetString(4);

                        hist.Add(his);
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
            return hist;
        }

    }
  
}
