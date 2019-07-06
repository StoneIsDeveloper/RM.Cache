using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public interface ICache
    {
       long Count { get; set; }

        bool Contains(string key);

        T GetData<T>(string key);

        void Add(string key, object result, int cacheTime);

        void Remove(string key);

        void RemoveAll();

        object this[string key] { get;set; }


    }
}
