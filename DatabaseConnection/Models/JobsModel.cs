using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseConnection.Contexts;

namespace DatabaseConnection.Models
{
    public class JobsModel
    {
        public string Id { get; set; }
        public string Tittle { get; set; }
        public int MinSalary { get; set; }
        public int MaxSalary { get; set; }

        public JobsModel(string id, string tittle, int MinSalary, int MaxSalary)
        {
            this.Id = id;
            this.Tittle = tittle;
            this.MinSalary = MinSalary;
            this.MaxSalary = MaxSalary;
        }

        public JobsModel() { }

        public List<JobsModel> GetAll()
        {
            SqlConnection connection = MyConnection.Get();
            connection.Open();
            var jobs = new List<JobsModel>();
            try
            {

                //Membuat Instance Untuk Command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_m_jobs";
                //Membuka Koneksi

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var job = new JobsModel();
                        job.Id = reader.GetString(0);
                        job.Tittle = reader.GetString(1);
                        job.MinSalary = reader.GetInt32(2);
                        job.MaxSalary = reader.GetInt32(3);

                        jobs.Add(job);
                    }
                }
                else
                {
                    Console.WriteLine("Data Not Found!!!");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            connection.Close();
            return jobs;
        }
    }
}
