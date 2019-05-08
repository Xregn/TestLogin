using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace TestLogin
{
    public class LoginViewModel
    {
        public string login { get; set; }//binding на поле login формы входа
        public string password { get; set; }//binding на поле pass формы входа

        //создаем элемент второго окна
        public NomencView nomencView = new NomencView();

        public LoginViewModel()//происходит при инициализации класса
        {
            EnterCommand = new DelegateCommand(Enter);
            CancelCommand = new DelegateCommand(Cancel);
        }
        public DelegateCommand EnterCommand { get; private set; }
        public DelegateCommand CancelCommand { get; set; }

        private void Enter(object obj)
        {
            //запрос для извлечения списка всех поьзователей
            string query = "select * from [TestLoginDb].[dbo].[user]";

            DbControl dbControl = new DbControl();

            Boolean insert = false; //переменная для вывода сообщения об ошибки один раз в конце

            var DataTable = new DataTable();
            DataTable = dbControl.query(query);

            int i = 0;
            while (i < DataTable.Rows.Count)
            {
              //чтение каждой строки логин/пароль
                if (this.login == DataTable.Rows[i][1].ToString() & this.password == DataTable.Rows[i][2].ToString())
                {
                    //открывем второе окно
                    NomencView nomencView = new NomencView();
                    nomencView.Show();
                    insert = true;
                    //закрываем текущее
                    break;
                }
                else
                {
                    insert = false;
                }
                i++;
            }

            if (insert == false)
            {
                MessageBox.Show("Логин и/или пароли не верны!");
            }
        }
        private void Cancel(object obj)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
