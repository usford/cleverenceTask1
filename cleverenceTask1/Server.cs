using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cleverenceTask1
{
    static public class Server
    {
        public static object locker = new();
        public static bool writingInProgress = false;
        private static int Count { get; set; } = 0;
        public static int GetCount()
        {
            //Симуляция чтения
            Thread.Sleep(1000);
            Console.WriteLine($"Идёт чтение: {Count}");

            return Count;
        }
        public static int AddToCount(int value)
        {
            lock (locker)
            {
                writingInProgress = true;

                //Симуляция записи
                Thread.Sleep(1000);
                Console.WriteLine($"Идёт запись: {Count + value}");

                writingInProgress = false;

                return Count += value;
            }
        }
    }
}
