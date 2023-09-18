using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    internal class DataBase
    {

        SqlConnection SqlConnection = new SqlConnection(@"Data Source = DESKTOP-262LE0I\MSSQLSERVER01; Initial Catalog = electronik; Integrated Security = True");
        public static string type = "";
        public void openConnection()
        {
            if (SqlConnection.State == System.Data.ConnectionState.Closed)            
                SqlConnection.Open();         
        }

        public void closeConnection()
        {
            if (SqlConnection.State == System.Data.ConnectionState.Open)
                SqlConnection.Close();
        }

        public SqlConnection getConnection()
        { 
                return SqlConnection;
        }
    }
}
