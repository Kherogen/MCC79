using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnection.Contexts
{
    public class MyConnection
    {
        static string connectionString = "Data Source=DESKTOP-QR71B46;Database=db_hr;Integrated Security=True;Connect Timeout=30;";
        public static SqlConnection Get()
        {
           return new SqlConnection(connectionString);
        }
    }
}
