using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnection
{
    public class Departments
    {
        SqlConnection connection = MyConnection.Get();

        public List<Departments> GetAllDep()
        {
            SqlConnection connection = MyConnection.Get();
            var deps = new List<Departments>();
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
                        var dep = new Departments();
                        dep.id = reader.GetInt32(0);
                        dep.name = reader.GetString(1);
                        dep.location_id = reader.GetInt32(2);
                        dep.manager_id = reader.GetInt32(3);

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
        public void MenuDep()
        {
            Console.Clear();
            Menu menu = new Menu();
            List<Departments> deps = GetAllDep();
            foreach (Departments dep in deps)
            {
                Console.WriteLine(" Id : " + dep.id + " NAME : " + dep.name + " LOCATION ID : " + dep.location_id+ " MANAGER ID : " + dep.manager_id);
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
        public int id { get; set; }
        public string name { get; set; }
        public int location_id { get; set; }
        public int manager_id { get; set; }
    }
}
