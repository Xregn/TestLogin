using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;


namespace TestLogin
{
    class DbControl
    {
        private string connectionString = @"Data Source=DESKTOP-AI8VOIA\SQLEXPRESS;Integrated Security=false;;Initial Catalog=GameOfLifeDb;User ID=root; Password=123;";
       public string connectString {
            set { connectionString = value; } }

        public SqlDataReader conf(string connectionString, string queryString)
        {
            this.connectionString = @"Data Source=DESKTOP-AI8VOIA\SQLEXPRESS;Integrated Security=false;;Initial Catalog=GameOfLifeDb;User ID=root; Password=123;";
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection = new SqlConnection(this.connectionString);
            sqlConnection.Open();

            SqlCommand command = new SqlCommand(queryString, sqlConnection);
            SqlDataReader read = command.ExecuteReader();
            read.Read();
            
            //while (read.Read())
            //{ Console.WriteLine("{0}\t{1}", read.GetInt32(0), read.GetString(1));}

            //sqlConnection.Close();
            //sqlConnection.Dispose();

              return read;
        }

    }
    
   
}
