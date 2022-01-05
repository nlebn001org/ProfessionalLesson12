using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace ProfessionalLesson12Task1
{
    internal class Program
    {
        static FileInfo file = new FileInfo("Logs.log");
        static Semaphore semaphore = new Semaphore(2, 4);
        static List<string> list = new List<string>();
        static object locker = new object();
        static int counter = 0;

        static void Main(string[] args)
        {
            if (file.Exists)
                File.Delete(file.FullName);
            for (int i = 0; i < 10; i++)
                new Thread(() => WriteLog(file)).Start();

        }

        static void WriteLog(FileInfo fileInfo)
        {
            semaphore.WaitOne();
            list.Add($"Thread with HC {Thread.CurrentThread.GetHashCode()} has written to the logfile at {DateTime.Now}");
            Console.WriteLine($"Thread with HC {Thread.CurrentThread.GetHashCode()} has written to the logfile at {DateTime.Now}");
            lock (locker)
            {
                if (list.Count > counter)
                    using (StreamWriter sw = new StreamWriter(new FileStream(fileInfo.FullName, FileMode.Append, FileAccess.Write, FileShare.ReadWrite)))
                        sw.WriteLine(list[counter]);
                counter++;
            }
            Thread.Sleep(1000);
            semaphore.Release();
        }
    }
}
