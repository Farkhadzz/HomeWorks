using StoreApp.Model;
using StoreApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Services.Classes
{
    class UserManageService : IUserManageService
    {
        private List<User> Users = new();
        private readonly ISerializeService _serializeService;

        public UserManageService(ISerializeService service)
        {
            _serializeService = service;
        }

        public void Add(User user)
        {
            using FileStream fs = new("data.json", FileMode.OpenOrCreate);
            using StreamReader sr = new(fs);
            using StreamWriter sw = new(fs);

            var json = sr.ReadToEnd();

            if (String.IsNullOrEmpty(json))
            {
                Users.Add(user);
            }

            json = _serializeService.Serialize<List<User>>(Users);

            sw.Write(json);
        }
    }
}
