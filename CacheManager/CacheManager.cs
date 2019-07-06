using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class CacheManager
    {
        private CacheManager() { }

        private static ICache cache = null;

        static CacheManager()
        {
            Console.WriteLine("开始缓存的初始化");

            cache = (ICache)Activator.CreateInstance(typeof(MemoryCacheCache));

        }

        /// <summary>
        /// 当前缓存数据项的个数
        /// </summary>
        public static long Count
        {
            get {
                return cache.Count;
            }
        }

        /// <summary>
        /// 缓存是否命中
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool Contains(string key)
        {
            return cache.Contains(key);
        }


        /// <summary>
        /// 获取数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T GetData<T>(string key)
        {
            return cache.GetData<T>(key);
        }


        public  static T Get<T>(string key,Func<T> acquire,int cacheTime = 30)
        {
            if (cache.Contains(key))
            {
                return GetData<T>(key);
            }
            else
            {
                T result = acquire.Invoke();  // 执行委托，获取结果，加入缓存
                cache.Add(key, result, cacheTime);
                return result;
            }
        }

        public static void Add(string key,object value)
        {

        }

    }
}
