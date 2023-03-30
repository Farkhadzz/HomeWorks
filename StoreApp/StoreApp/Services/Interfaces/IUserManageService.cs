using System;
using StoreApp.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Services.Interfaces
{
    public interface IUserManageService
    {
        void Add(User user);

        User GetUser(string login, string password);
        bool CheckExists(string login, string password);
    }
}
