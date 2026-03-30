using System.Diagnostics;

namespace ThreadingDemo
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("in main");
            Process currentProcess = Process.GetCurrentProcess();
            Console.WriteLine($"Process Id: {currentProcess.Id}\nProcess Name:{currentProcess.ProcessName}");


            Thread currentThread = Thread.CurrentThread;
            Console.WriteLine($"Thread Id:{currentThread.ManagedThreadId}\nThread Name: {currentThread.Name}");

            //creating a new thread to run the Run() method
            ThreadStart runThreadRef = new ThreadStart(Run);
            Thread runThread = new Thread(runThreadRef);
            runThread.Start();
            runThread.Join();
            //Thread.Sleep(500);

            ParameterizedThreadStart runWithArgThreadRef = new(RunWithArgument);
            Thread runWithArgThread = new Thread(runWithArgThreadRef);
            runWithArgThread.Start(5);
            runWithArgThread.Join();

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Main value: " + i);
            }
            Console.WriteLine("press any key to terminate...");
            Console.ReadKey();
        }
        static void Run()
        {
            Console.WriteLine("in run method...");
            Thread currentThread = Thread.CurrentThread;
            Console.WriteLine($"Run Thread Id:{currentThread.ManagedThreadId}\nRun Thread Name: {currentThread.Name}");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Run value: " + i);
            }
        }
        static void RunWithArgument(object? arg)
        {
            Console.WriteLine("in RunWithArgument method...");
            Thread currentThread = Thread.CurrentThread;
            Console.WriteLine($"RunWithArgument Thread Id:{currentThread.ManagedThreadId}\nRunWithArgument Thread Name: {currentThread.Name}");

            int value = 1;
            if (arg != null)
                value = (int)arg;

            for (int i = 0; i < value; i++)
            {
                Console.WriteLine("RunWithArgument value: " + i);
            }
        }
    }
}
