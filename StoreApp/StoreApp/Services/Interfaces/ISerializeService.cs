using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Services.Interfaces
{
    public interface ISerializeService
    {
        string Serialize<T>(object obj);
        object Deserialize<T>(string json);
    }
}
