using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using FileParserAdv;
using Contracts;

namespace ThreadingExample
{
    internal class Program
    {
        public static FileParser parser = new FileParser();
        public static DateTime startingPoint = DateTime.Now;

        static void Main(string[] args)
        {
            Task task1 = Task.Run(() => ExecuteThreadTask("C:\\Users\\mdgon\\source\\repos\\C# Training\\ThreadingExample\\Excell Books\\DataSet1.xlsx"));

            Task task2 = Task.Run(() => ExecuteThreadTask("C:\\Users\\mdgon\\source\\repos\\C# Training\\ThreadingExample\\Excell Books\\DataSet2.xlsx"));

            Task task3 = Task.Run(() => ExecuteThreadTask("C:\\Users\\mdgon\\source\\repos\\C# Training\\ThreadingExample\\Excell Books\\DataSet3.xlsx"));

            Console.ReadKey();

        }

        private static void ExecuteThreadTask(string path)
        {
            Console.WriteLine($"Thread={Thread.CurrentThread.ManagedThreadId}");
            List<CustomerOrders> orders = parser.ReadFile(path);
            DateTime endpoint = DateTime.Now;
            TimeSpan timespan = endpoint - startingPoint;
            Console.WriteLine($"Time Elapsed for thread, {Thread.CurrentThread.ManagedThreadId}: {timespan.Milliseconds} ms");
        }
    }
}
