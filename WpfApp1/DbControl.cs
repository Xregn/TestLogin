using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Windows;
using System.IO;


namespace TestLogin
{
    class DbControl
    {
        private string conDataSource = @"DESKTOP - AI8VOIA\SQLEXPRESS";
        private string conCatalog = "TestLoginDb";
        private string conUser = "root";
        private string conPassword = "123";
        private string connectionString;
        SqlConnection sqlConnection = new SqlConnection();

        public DbControl()
        {
            if (File.Exists("DBInfo.txt"))
            { ReadDBInfo(); }
            else
            {
                WriteDBInfo();
                MessageBox.Show("Заполните файл DBInfo.");
                System.Windows.Application.Current.Shutdown();
            }   

            connectionString = @"Data Source=" + conDataSource + ";Integrated Security=false;;Initial Catalog=" + conCatalog + ";User ID=" + conUser + "; Password=" + conPassword + ";";
        }

        public string ConDataSource { get
            { return conDataSource; }
            set { conDataSource = value; } }
        public string ConCatalog { get
            { return conCatalog; }
            set { conCatalog = value; } }
        public string ConUser { get
            { return conUser; }
            set { conUser = value; } }
        public string ConPassword { get
            { return conPassword; }
            set { conPassword = value; } }
        public string ConnectionString { get; set; }

        public DataTable query(string queryString)//получаем sql запрос и возвращаем datatable
        {
           // this.connectionString = @"Data Source=DESKTOP-AI8VOIA\SQLEXPRESS;Integrated Security=false;;Initial Catalog=GameOfLifeDb;User ID=root; Password=123;";
            
            sqlConnection = new SqlConnection(this.connectionString);
            sqlConnection.Open();

            SqlCommand command = new SqlCommand(queryString, sqlConnection);
            SqlDataReader read = command.ExecuteReader();

            DataTable DataTable = new DataTable();
            DataTable.Load(read);//передаем все содержимое запроса в таблицу

            sqlConnection.Close();//закрываем соеденение
            sqlConnection.Dispose();

            return DataTable;
        }
        private void WriteDBInfo()
        {
            StreamWriter streamWriter = new StreamWriter("DBInfo.txt");
            streamWriter.WriteLine(conDataSource);
            streamWriter.WriteLine(conCatalog);
            streamWriter.WriteLine(conUser);
            streamWriter.WriteLine(conPassword);
            streamWriter.WriteLine("");
            streamWriter.WriteLine("Порядок запили данных для подключения к базе данных");
            streamWriter.WriteLine("1-DataSource 2-Catalog 3-User 4-Password");
            streamWriter.Close();
        }
        private void ReadDBInfo()
        {
            StreamReader streamReader = new StreamReader("DBInfo.txt");
            conDataSource = streamReader.ReadLine();
            conCatalog = streamReader.ReadLine();
            conUser = streamReader.ReadLine();
            conPassword = streamReader.ReadLine();
            streamReader.Close();
        }
    }
}
