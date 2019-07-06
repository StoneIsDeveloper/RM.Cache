using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class MemoryCacheCache : ICache
    {
        public MemoryCacheCache() { }



        protected ObjectCache Cache
        {
            get {
                return MemoryCache.Default;
            }
        }


        public long Count { get ; set; }

        public object this[string key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool Contains(string key)
        {
            throw new NotImplementedException();
        }

        public T GetData<T>(string key)
        {
            return default(T);
        }

        public void Add(string key, object result, int cacheTime)
        {
            throw new NotImplementedException();
        }

        public void Remove(string key)
        {
            throw new NotImplementedException();
        }

        public void RemoveAll()
        {
            throw new NotImplementedException();
        }
    }
}
