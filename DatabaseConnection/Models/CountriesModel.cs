using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseConnection.Contexts;

namespace DatabaseConnection.Models
{
    public class CountriesModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int RegionId { get; set; }


        public CountriesModel() { }

        public CountriesModel(string id, string name, int regionId)
        {
            if (Id.Length > 3)
            {
                throw new ArgumentException("THE LENGTH OF ID MUST NOT EXCEED 2 CHARACTERS");
            }
            Id = id;
            Name = name;
            RegionId = regionId;
        }

        public List<CountriesModel> GetAll()
        {
            var countries = new List<CountriesModel>();
            SqlConnection connection = MyConnection.Get();
            connection.Open();
            try
            {
                //Membuat Instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_m_countries";


                //Membuka koneksi

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var cou = new CountriesModel();
                        cou.Id = reader.GetString(0);
                        cou.Name = reader.GetString(1);
                        cou.RegionId = reader.GetInt32(2);

                        countries.Add(cou);
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
            return countries;

        }
        public CountriesModel GetById(string id)
        {
            SqlConnection connection = MyConnection.Get();
                        connection.Open();
            var countries = new CountriesModel();

            /*connection = new SqlConnection(connectionString);*/
            try
            {

                //Membuat Instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_m_countries WHERE id = @country_id ";


                //Membuat Parameter
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@country_id";
                pId.Value = id;
                pId.SqlDbType = SqlDbType.VarChar;
                //Menambahkan Parameter Ke Command
                command.Parameters.Add(pId);
                //Menjalankan COmmand
                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    countries.Id = reader.GetString(0);
                    countries.Name = reader.GetString(1);
                    countries.RegionId = reader.GetInt32(2);


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
            return countries;
        }
        public int Insert(string id, string name, int reg_id)
        {
            int result = 0;
            SqlConnection connection = MyConnection.Get();
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();
           

            try
            {
                //Membuat Instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Insert Into tb_m_countries (id, name, region_id) VALUES (@country_id, @country_name, @country_region_id)";
                command.Transaction = transaction;

                //Membuat Paramaeter
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@country_id";
                pId.Value = id;
                pId.SqlDbType = SqlDbType.VarChar;

                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@country_name";
                pName.Value = name;
                pName.SqlDbType = SqlDbType.VarChar;

                SqlParameter pRid = new SqlParameter();
                pRid.ParameterName = "@country_region_id";
                pRid.Value = reg_id;
                pRid.SqlDbType = SqlDbType.Int;
                //Menambahkan paramater ke command

                command.Parameters.Add(pId);
                command.Parameters.Add(pName);
                command.Parameters.Add(pRid);
                //Menjalankan command
                result = command.ExecuteNonQuery();
                transaction.Commit();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                try
                {
                    transaction.Rollback();
                }
                catch (Exception rollback)
                {
                    Console.WriteLine(rollback.Message);
                }
            }
            connection.Close();
            return result;


        }
        public int Update(string id, string name, int reg_id)
        {
            int result = 0;
            SqlConnection connection = MyConnection.Get();
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();
         

            try
            {

                /* connection.Open();
                 //Instance Command
                 connection = new SqlConnection(connectionString);*/
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "UPDATE tb_m_countries SET name = @country_name, region_id = @country_reg_id WHERE id = @Country_id ";
                command.Transaction = transaction;

                //Membuat Parameter
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@country_id";
                pId.Value = id;
                pId.SqlDbType = SqlDbType.VarChar;

                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@country_name";
                pName.Value = name;
                pName.SqlDbType = SqlDbType.VarChar;

                SqlParameter pRid = new SqlParameter();
                pRid.ParameterName = "@country_reg_id";
                pRid.Value = reg_id;
                pRid.SqlDbType = SqlDbType.Int;
                /*
                                SqlParameter pRid = new SqlParameter();
                                pRid.ParameterName = "@regions_id";
                                pRid.Value = region_id;
                                pRid.SqlDbType = SqlDbType.Int;
                */
                //Menambah parameter ke command
                command.Parameters.Add(pId);
                command.Parameters.Add(pName);
                command.Parameters.Add(pRid);
                //Menjalankan Command
                result = command.ExecuteNonQuery();
                transaction.Commit();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                try
                {
                    transaction.Rollback();
                }
                catch (Exception rollback)
                {
                    Console.WriteLine(rollback.Message);
                }
            }
            connection.Close();
            return result;
        }
        public int Delete(string id)
        {
            int result = 0;

            SqlConnection connection = MyConnection.Get();
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();
           
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "DELETE from tb_m_countries where id = @country_id ";
                command.Transaction = transaction;

                //Membuat Parameter
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@country_id";
                pId.Value = id;
                pId.SqlDbType = SqlDbType.VarChar;
                /*
                                SqlParameter pRid = new SqlParameter();
                                pRid.ParameterName = "@regions_id";
                                pRid.Value = region_id;
                                pRid.SqlDbType = SqlDbType.Int;
                */
                //Menambah parameter ke command
                command.Parameters.Add(pId);
                /*     command.Parameters.Add(pRid);*/

                //Menjalankan Command
                result = command.ExecuteNonQuery();
                transaction.Commit();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                try
                {
                    transaction.Rollback();
                }
                catch (Exception rollback)
                {
                    Console.WriteLine(rollback.Message);
                }
            }



            connection.Close();
            return result;
        }
    }
}
