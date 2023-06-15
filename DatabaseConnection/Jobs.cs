using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnection
{
   public class Jobs
    {
        SqlConnection connection = MyConnection.Get();

        public List<Jobs> GetAllJob()
        {
  /*          SqlConnection connection = MyConnection.Get();*/
            var jobs = new List<Jobs>();
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
                        var job = new Jobs();
                        job.id = reader.GetString(0);
                        job.tittle = reader.GetString(1);
                        job.min_salary= reader.GetInt32(2);
                        job.max_salary = reader.GetInt32(3);

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
        public void MenuJobs()
        {
            Console.Clear();
            Menu menu = new Menu();
            List<Jobs> jobs = GetAllJob();
            foreach (Jobs job in jobs)
            {
                Console.WriteLine("Id : " + job.id + " Tittle : " + job.tittle + " Min Salary : " + job.min_salary + " Max Salary : " + job.max_salary);
            }
            Console.WriteLine("\n");
            Console.WriteLine("1.Kembali");
            try
            {

                Console.Write("Pilih Menu : ");
                int InputPilihan = int.Parse(Console.ReadLine());

                switch (InputPilihan)
                {
                    case 1:
                        menu.MenuDb();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public string id { get; set; }
        public string tittle { get; set; }
        public int min_salary { get; set; }
        public int max_salary { get; set; }
    }
}
