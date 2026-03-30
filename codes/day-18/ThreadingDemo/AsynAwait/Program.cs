namespace AsyncAwait
{
    class Program
    {
        public static void Main(string[] args)
        {
            CallAsync();
            Console.WriteLine("other job");
            Console.WriteLine("press any key to terminate..");
            Console.ReadKey();
        }
        static async void CallAsync()
        {
            Console.WriteLine($"Thread Id of CallAsync: {Environment.CurrentManagedThreadId}");
            try
            {
                //waits the task to be completed "successfully" and returns the data from the task

                //Task<int> resultTask = GetData();
                //int result = await resultTask;

                //or
                int result = await GetData();
                //Console.WriteLine(result);
                await PrintResult(result);
                Console.WriteLine("all done...");
            }
            catch (Exception e)
            {
                //if the task is faulted then the catch block will catch the exception
                Console.WriteLine(e);
            }
        }
        static Task<int> GetData()
        {
            Console.WriteLine($"Thread Id of GetData: {Environment.CurrentManagedThreadId}");

            Task<int> longRunningTask = Task.Run<int>(
                () =>
                {
                    Console.WriteLine($"Calculation starts in Thread Id: {Environment.CurrentManagedThreadId}");
                    //Thread.Sleep(4000);
                    int threshold = 1000000000;
                    int sum = 0;
                    for (global::System.Int32 i = 0; i < threshold; i++)
                    {
                        sum += i;
                        //throw new Exception("sorry...");
                    }
                    return sum;
                });
            Console.WriteLine("get data call is over");
            return longRunningTask;
        }
        static Task PrintResult(int result)
        {
            Console.WriteLine($"Thread Id of PrintResult: {Environment.CurrentManagedThreadId}");
            var task = Task.Run(() =>
            {
                Console.WriteLine($"Thread Id for printing result: {Environment.CurrentManagedThreadId}");
                Console.WriteLine(result);
            });
            Console.WriteLine("print task call is over");
            return task;
        }
    }

}



//resultTask
//    .ContinueWith(
//        (task) =>
//        {
//            try
//            {
//                if(task.IsCompltedSuccesfully){
//                PrintResult(task.Result)
//                .ContinueWith((task1) => Console.WriteLine(task1.IsCompletedSuccessfully ? "done" : "not done"));
//                  }else{}
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e);
//            }
//        });


/*
static int GetData()
{
    Thread.Sleep(4000);
    int sum = 0;
    for (global::System.Int32 i = 0; i < 100000000; i++)
    {
        sum += i;
        //throw new Exception("sorry...");
    }
    return Task.FromResult<int>(sum);
}*/
