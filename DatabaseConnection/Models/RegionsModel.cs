using DatabaseConnection.Contexts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnection.Models
{
    public class RegionsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public RegionsModel(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public RegionsModel() { }

        public List<RegionsModel> GetAll()

        {
            var region = new List<RegionsModel>();
            SqlConnection connection = MyConnection.Get();
            connection.Open();
            try
            {
                //Membuat Instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_m_regions";


                //Membuka koneksi

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var reg = new RegionsModel();
                        reg.Id = reader.GetInt32(0);
                        reg.Name = reader.GetString(1);

                        region.Add(reg);
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
            return region;

        }

        public RegionsModel GetById(int id)
        {
            SqlConnection connection = MyConnection.Get();
            var region = new RegionsModel();
            connection.Open();
            /*connection = new SqlConnection(connectionString);*/
            try
            {

                //Membuat Instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_m_regions WHERE id = @region_id ";

                //Membuat Parameter
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@region_id";
                pId.Value = id;
                pId.SqlDbType = SqlDbType.Int;
                //Menambahkan Parameter Ke Command
                command.Parameters.Add(pId);
                //Menjalankan COmmand
                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    region.Id = reader.GetInt32(0);
                    region.Name = reader.GetString(1);

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
            return region;
        }
        public int Update(int id, string name)
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
                command.CommandText = "UPDATE tb_m_regions SET name = @regions_name WHERE id = @id ";
                command.Transaction = transaction;

                //Membuat Parameter
                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@regions_name";
                pName.Value = name;
                pName.SqlDbType = SqlDbType.VarChar;

                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.Value = id;
                pId.SqlDbType = SqlDbType.Int;

                //Menambah parameter ke command
                command.Parameters.Add(pName);
                command.Parameters.Add(pId);

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
        public int Delete(int id)
        {
            int result = 0;
            SqlConnection connection = MyConnection.Get();
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();
           
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "DELETE from tb_m_regions where id = @id ";
                command.Transaction = transaction;

                //Membuat Parameter
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.Value = id;
                pId.SqlDbType = SqlDbType.Int;
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




            return result;
        }

        public int Insert(string name)
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
                command.CommandText = "Insert Into tb_m_regions (name) VALUES (@region_name)";
                command.Transaction = transaction;

                //Membuat Paramaeter
                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@region_name";
                pName.Value = name;
                pName.SqlDbType = SqlDbType.VarChar;

                //Menambahkan paramater ke command
                command.Parameters.Add(pName);

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

    }
}
