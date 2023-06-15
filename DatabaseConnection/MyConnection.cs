using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnection
{
    public class MyConnection
    {
        static string connectionString = "Data Source=DESKTOP-QR71B46;Database=db_hr;Integrated Security=True;Connect Timeout=30;";
        static SqlConnection connection;
        public static SqlConnection Get()
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}
