using System;
using System.Reflection;
using System.Threading;

namespace ProfessionalLesson12Task3
{
    internal class Program
    {
        static bool createdNew;
        static string mutexName = "ProfessionalLesson12Task3Mutex";
        static Mutex mutex = new Mutex(true, mutexName, out createdNew);
        static void Main(string[] args)
        {
            if (createdNew)
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine(i);
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
