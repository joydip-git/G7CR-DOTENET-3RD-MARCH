
Console.WriteLine($"In Main. Thread Id:{Thread.CurrentThread.ManagedThreadId}");
Console.WriteLine($"Available Threads currently for this app at {DateTime.Now.ToShortTimeString()}: {ThreadPool.ThreadCount}");
Thread increseThread = new(IncreaseValue);
Thread decreaseThread = new(DecreaseValue);

increseThread.Start();
decreaseThread.Start();


static void IncreaseValue()
{
    Console.WriteLine($"In {nameof(IncreaseValue)}. Thread Id:{Thread.CurrentThread.ManagedThreadId}");
    Shared.Mutex.WaitOne();

    Console.WriteLine($"Available Threads currently for this app at {DateTime.Now.ToShortTimeString()}: {ThreadPool.ThreadCount}");
    for (int i = 0; i < 5; i++)
    {
        ++Shared.SharedValue;
        Console.WriteLine($"Shared Value in {nameof(IncreaseValue)}: {Shared.SharedValue}");
        Thread.Sleep(5000);
    }
    Shared.Mutex.ReleaseMutex();
}
static void DecreaseValue()
{ 
    Console.WriteLine($"In {nameof(DecreaseValue)}. Thread Id:{Thread.CurrentThread.ManagedThreadId}");
    Shared.Mutex.WaitOne();

    Console.WriteLine($"Available Threads currently for this app at {DateTime.Now.ToShortTimeString()}: {ThreadPool.ThreadCount}");
    for (int i = 0; i < 5; i++)
    {
        --Shared.SharedValue;
        Console.WriteLine($"Shared Value in {nameof(DecreaseValue)}: {Shared.SharedValue}");
        Thread.Sleep(1000);
    }
    Shared.Mutex.ReleaseMutex();
}
class Shared
{
    public static Mutex Mutex = new();
    public static int SharedValue { set; get; } = 1;
}
