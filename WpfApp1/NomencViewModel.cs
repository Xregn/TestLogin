using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows;

namespace TestLogin
{
    class NomencViewModel
    {
        public static DataTable ItemSource { get; set; }//binding на datagtid
        public static string SelectIndex { get; set; }//binding на выделенную строку 
        public static string addName { get; set; } //binding для добавления
        public static string addEr { get; set; }//binding для добавления
        public static string addTd { get; set; }//binding для добавления
        public DataTable DataTable { get; set; }//таблица в которой храним все данные полученные из класса dbControl
        public DelegateCommand AddCommand { get; set; }
        public DelegateCommand DeleteCommand { get; set; }
        DbControl dbControl = new DbControl();//создаем объект класса подключения
       
        
        public NomencViewModel()//происходит при инициализации класса
        {
            AddCommand = new DelegateCommand(Add);
            DeleteCommand = new DelegateCommand(Del);

            //заполнение datagrid 
            string query = "select * from [TestLoginDb].[dbo].[nomenclature]";                      
            DataTable = dbControl.query(query);
            ItemSource = DataTable;      
        }
        
        private void Add(object obj)
        {
            //добавление в базу данных
            string query = @"INSERT INTO [TestLoginDb].[dbo].[nomenclature] ([Name], [Er], [Td]) VALUES ('" + addName + "' ,'" + addEr + "' ,'" + addTd + "')";
            dbControl.query(query);
            //добавления в таблицу из базы последней добавленной строки для отображения на форме
            query = @"select * from [TestLoginDb].[dbo].[nomenclature] order by id Desc";
            DataRow dataRow = dbControl.query(query).Rows[0];
            DataTable.ImportRow(dataRow);
        }
        private void Del(object obj)
        {
            //удаление из базы по binding SelectIndex
            int id = Convert.ToInt16(DataTable.Rows[Convert.ToInt16( SelectIndex)][0]);
            string query = "DELETE FROM [TestLoginDb].[dbo].[nomenclature] WHERE ID = " + id + "";
            dbControl.query(query);
            //удаление из таблицы
            DataTable.Rows[Convert.ToInt16(SelectIndex)].Delete();
        }
    }
}
