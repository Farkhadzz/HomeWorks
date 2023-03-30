using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Model
{
    public class User
    {
        public string Login { get; set; } = "Farkhadzz";
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Mail { get; set; } = "zulfu@gmail.com";
    }
}
