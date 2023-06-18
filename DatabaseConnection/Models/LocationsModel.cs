using DatabaseConnection.Contexts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnection.Models
{
    public class LocationsModel
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string Post { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string CountryId { get; set; }

        public LocationsModel(int id, string street, string post, string city, string state, string CountryId)
        {
            this.Id = id;
            this.Street = street;
            this.Post = post;
            this.City = city;
            this.State = state;
            this.CountryId = CountryId;
        }

        public LocationsModel() { }
        public List<LocationsModel> GetAll()
        {
            var locations = new List<LocationsModel>();
            SqlConnection connection = MyConnection.Get();
            connection.Open();
            try
            {

                //Membuat Instance Untuk Command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_m_locations";
                //Membuka Koneksi

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var loc = new LocationsModel();
                        loc.Id = reader.GetInt32(0);
                        loc.Street = reader.GetString(1);
                        loc.Post = reader.GetString(2);
                        loc.City = reader.GetString(3);
                        loc.State = reader.GetString(4);
                        loc.CountryId = reader.GetString(5);

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
    }
}
