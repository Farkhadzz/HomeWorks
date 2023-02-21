using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Practice_3
{
    internal class User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }

        public User(string login, string password, string mail)
        {
            Login = login;
            Password = password;
            Mail = mail;
        }

        public User(){}
    }
}
