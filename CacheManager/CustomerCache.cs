using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// 自定义实现的缓存
    /// 
    /// 缓存的过期
    /// 
    /// </summary>
    public class CustomerCache : ICache
    {
        /// <summary>
        /// 数据容器
        /// key, vakue, time
        /// </summary>
        // static Dictionary<string, object> _CacheDictionary = new Dictionary<string, object>();
        private static Dictionary<string, KeyValuePair<object,DateTime>> _CacheDictionary = new Dictionary<string, KeyValuePair<object, DateTime>>();


        public object this[string key]
        {   get => _CacheDictionary[key];
            set => _CacheDictionary[key] = new KeyValuePair<object, DateTime>(value, DateTime.Now.AddMinutes(30));
        }

        public void Add(string key, object data, int cacheTime)
        {
            _CacheDictionary[key] = new KeyValuePair<object, DateTime>(data, DateTime.Now.AddMinutes(cacheTime));
        }


        /// <summary>
        /// 主动过期，定时清除过期数据
        /// </summary>
        static CustomerCache()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    Thread.Sleep(1000);
                    if(_CacheDictionary != null)
                    {
                        List<string> keys = new List<string>();
                        foreach (var key in _CacheDictionary.Keys)
                        {
                            keys.Add(key);
                        }
                        for (int i = 0; i < _CacheDictionary.Keys.Count;i++)
                        {
                            string key = keys[i];
                            KeyValuePair<object, DateTime> valueTime = _CacheDictionary[key];
                            if (valueTime.Value < DateTime.Now)
                            {
                                _CacheDictionary.Remove(key);
                            }
                        }
                    }
                }
            });
        }


        /// <summary>
        /// 1 时间到了，直接过期  主动
        /// 2 查询的时候，过期    被动
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T GetData<T>(string key)
        {
            if (!this.Contains(key))
            {
                return default(T);
            }
            else
            {
                KeyValuePair<object, DateTime> valueTime = _CacheDictionary[key];
                if(valueTime.Value < DateTime.Now)
                {
                    _CacheDictionary.Remove(key);
                    return default(T);
                }

                return (T)valueTime.Key;
            }
        }



        public long Count { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

       

        public bool Contains(string key)
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
