using System;
using System.Text;
using System.Threading;

namespace ProfessionalLesson12Task2
{
    internal class Program
    {
        static AutoResetEvent auto = new AutoResetEvent(false);

        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            new Thread(Function1).Start();
            new Thread(Function2).Start();

            Thread.Sleep(500);  

            Console.WriteLine("Нажмите на любую клавишу для перевода ManualResetEvent в сигнальное состояние.\n");
            Console.ReadKey(true);
            auto.Set();
            auto.Set();

            Console.ReadKey();
        }

        static void Function1()
        {
            Console.WriteLine("Поток 1 запущен и ожидает сигнала.");
            auto.WaitOne();
            Console.WriteLine("Поток 1 завершается.");
        }

        static void Function2()
        {
            Console.WriteLine("Поток 2 запущен и ожидает сигнала.");
            auto.WaitOne();
            Console.WriteLine("Поток 2 завершается.");
        }
    }
}
