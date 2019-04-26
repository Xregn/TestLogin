using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows;

namespace TestLogin
{
    public class LoginViewModel
    {
        public string login { get; set; }
        public string password { get; set; }

        public LoginViewModel()
        {
            EnterCommand = new DelegateCommand(Enter);
            CancelCommand = new DelegateCommand(Cancel);
        }
        public DelegateCommand EnterCommand { get; private set; }
        public DelegateCommand CancelCommand { get; set; }
        private void Enter(object obj)
        {
            System.Windows.Application.Current.Shutdown();
        }
        private void Cancel(object obj)
        {
            MessageBox.Show("jnvyf");
        }

        
    }

    

}
