using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DebugViewer
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Console.WriteLine("Start Console Worker!");
            ConsoleWorker worker = new ConsoleWorker();
            worker.InitDB();
            worker.StartWork();

        }
    }
}
