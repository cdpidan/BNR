using System;
using BNR;

namespace BNRCore.TestConsole
{
    class Program
    {
        static long mCount;

        static void Main(string[] args)
        {
            string[] rule = new string[]
            {
                "{S:OD}{CN:广州}{D:yyyyMM}{N:{S:ORDER}{CN:广州}{D:yyyyMM}/00000000}{N:{S:ORDER_SUB}{CN:广州}{D:yyyyMM}/00000000}",
                "{S:FXSJ}{D:yyyyMM}{N:{S:FXSJ}{D:yyyy}/0000}"
            };
            foreach (string item in rule)
            {
                string value = BNRFactory.Default.Create(item);
                Console.WriteLine(item);
                Console.WriteLine(value);
            }

            System.Threading.ThreadPool.QueueUserWorkItem(o =>
            {
                while (true)
                {
                    foreach (string item in rule)
                    {
                        string value = BNRFactory.Default.Create(item);
                        // Console.WriteLine("{0}={1}", item, value);
                        System.Threading.Interlocked.Increment(ref mCount);
                    }
                }
            });
            while (true)
            {
                Console.WriteLine(mCount);
                System.Threading.Thread.Sleep(1000);
            }

            Console.Read();
        }
    }
}