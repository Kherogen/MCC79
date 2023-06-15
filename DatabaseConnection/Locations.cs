using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnection
{
    public class Locations
    {
        static string connectionString = "Data Source=DESKTOP-QR71B46;Database=db_hr;Integrated Security=True;Connect Timeout=30;";
        static SqlConnection connection;

        public List<Locations> GettAllLoc()
        {
            var locations = new List<Locations>();
            try
            {
                connection = new SqlConnection(connectionString);
                //Membuat Instance Untuk Command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_m_locations";
                //Membuka Koneksi
                connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var loc = new Locations();
                        loc.id = reader.GetInt32(0);
                        loc.street = reader.GetString(1);
                        loc.post = reader.GetString(2);
                        loc.city = reader.GetString(3);
                        loc.state = reader.GetString(4);
                        loc.co_id = reader.GetString(5);

                        locations.Add(loc);
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
            return locations;
        }
        public void MenuLocations()
        {
            Menu menu = new Menu();
            Console.Clear();
            connection = new SqlConnection(connectionString);
            List<Locations> locations = GettAllLoc();
            foreach (Locations location in locations)
            {
                Console.WriteLine("Id : " + location.id + " Street : " + location.street + " Postal Code : " + location.post + " City : " + location.city + " State Province : " + location.state + " Country Id : " + location.co_id);
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
        public string street { get; set; }
        public string post { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string co_id { get; set; }


    }

}
