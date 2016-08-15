using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.CacheSample
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var ctx = new AdventureContext())
            {
                ReadTop100Employees(ctx);

                ReadTop100Employees(ctx);
            }
            Console.ReadLine();
        }

        private static void ReadTop100Employees(AdventureContext ctx)
        {
            var stopWatcher = new Stopwatch();
            stopWatcher.Start();
            Console.WriteLine("Select top 100 employees");
            var result = ctx.Employees.Take(100).ToList();
            stopWatcher.Stop();
            Console.WriteLine("Total time:{0:G}", stopWatcher.Elapsed);
        }
    }
}
