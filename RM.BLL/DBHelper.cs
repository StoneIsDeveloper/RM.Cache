using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RM.BLL
{
    public class DBHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> Query<T>()
        {
            Console.WriteLine("This is {0} query", typeof(DBHelper));
            long result = 0;
            for (int i = 0; i < 100000; i++)
            {
                result += i;
            }

            return new List<T>(){
                default(T),default(T),default(T),default(T)
            };

        }
    }
}
