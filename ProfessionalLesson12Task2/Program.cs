using System;
using System.Text;
using System.Threading;

namespace ProfessionalLesson12Task2
{
    internal class Program
    {
        AutoResetEvent auto;

        Program(string name, AutoResetEvent autoResetEvent)
        {
            Thread thread = new Thread(() => Function1()) { Name = name };
            this.auto = autoResetEvent;
            thread.Start();
        }

        static void Main()
        {
            AutoResetEvent are = new AutoResetEvent(false);
            Program program = new Program("1", are);
            are.WaitOne();
            Console.WriteLine($"Main is currently managing this app.");
            Program program2 = new Program("2", are);
            are.WaitOne();
            Console.WriteLine($"Main is currently managing this app.");
        }

        void Function1()
        {
            Console.WriteLine($"Not main thread with name {Thread.CurrentThread.Name} started.");
            for (int i = 0; i < 20; i++)
            {
                Console.Write(". ");
                Thread.Sleep(100);
            }
            Console.WriteLine($"\nNot main thread with name {Thread.CurrentThread.Name} ended.");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey(true);
            auto.Set();
        }

    }
}
