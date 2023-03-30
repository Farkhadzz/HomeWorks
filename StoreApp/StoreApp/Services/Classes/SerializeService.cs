﻿using StoreApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace StoreApp.Services.Classes
{
   public class SerializeService : ISerializeService 
    {
        public object Deserialize<T>(string json)
        {
            try
            {
                return JsonSerializer.Deserialize<T>(json);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string Serialize<T>(object obj)
        {
            if (obj != null)
            {
                return JsonSerializer.Serialize(obj);
            }
            throw new NullReferenceException("Object Is Null");
        }
    }
}