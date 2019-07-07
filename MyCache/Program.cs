using Common;
using RM.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCache
{
    /// <summary>
    /// 1 负载均衡、读写分离、分库分表 表分区
    /// 2 各种缓存
    /// 3 本地缓存原理和实现
    /// 
    /// 1 查询多
    /// 2 及时性要求不能太高
    /// 3 缓存的数据不能太多
    /// 4 远程接口的， 硬盘文件  复杂计算的结果都可以缓存
    /// 5 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            {
                for (int i = 0; i < 5; i++)
                {
                    List<Program> programs = DBHelper.Query<Program>();
                    if (CacheManager.Contains("DBHelper"))
                    {
                        List<Program> programList = DBHelper.Query<Program>();
                        CacheManager.Add("DBHelper", programList);
                    }
                    List<Program> programResult = CacheManager.GetData<List<Program>>("DBHelper");

                    List<Program> result = CacheManager.Get<List<Program>>("DBHelper", 
                        () => DBHelper.Query<Program>(), 30);


                }
                for (int i = 0; i < 5; i++)
                {
                    List<Program> programs = FileHelper.Query<Program>();
                }
                for (int i = 0; i < 5; i++)
                {
                    List<Program> programs = RemoteHelper.Query<Program>();
                }
            }

            Console.ReadKey();



        }
    }
}
