using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RM.BLL
{
    public class FileHelper
    {
        public static List<T> Query<T>()
        {
            Console.WriteLine("This is {0} query", typeof(FileHelper));
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
