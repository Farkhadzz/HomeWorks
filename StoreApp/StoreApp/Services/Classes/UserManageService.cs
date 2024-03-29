﻿using StoreApp.Model;
using StoreApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace StoreApp.Services.Classes
{
    public class UserManageService : IUserManageService
    {
        private List<User> Users { get; set; } = new();
        private readonly ISerializeService _serializeService;

        public UserManageService(ISerializeService service)
        {
            _serializeService = service;
        }

        private string CheckLength()
        {
            var res = File.ReadAllText("data.json");
            return res;
        }
        public void Add(User user)
        {
            var check = CheckLength();
            
            using FileStream fs = new("data.json", FileMode.OpenOrCreate);
            using StreamReader sr = new(fs);
            using StreamWriter sw = new(fs);

            var json = sr.ReadToEnd();

            fs.Position = 0;
            if (check.Length > 10)
            {
                fs.Position = 0;
                Users = (List<User>)_serializeService.Deserialize<List<User>>(check);
            }
            if(Users == null)
            {
                Users = new();
            }
            Users.Add(user);
            json = _serializeService.Serialize<List<User>>(Users);
            sw.Write(json);
        }

        private User? DownloadData(string login, string password)
        {
            using FileStream fs = new("data.json", FileMode.Open);
            using StreamReader sr = new(fs);

            Users = (List<User>)_serializeService.Deserialize<List<User>>(sr.ReadToEnd());
            if (Users == null)
            {
                Users = new();
            }
            var result = Users.Find(x => x.Login == login && x.Password == password);

            return result;
        }

        public bool CheckExists(string login, string password)
        {
            var user = DownloadData(login, password);

            if (user != null)
            {
                return true;
            }
            return false;
        }

        public User GetUser(string login, string password)
        {
            var user = DownloadData(login, password);

            if (user != null)
            {
                return user;
            }
            throw new NullReferenceException();
        }
    }
}
