// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

//Task<int> getDataTask = new Task<int>(GetData);
//getDataTask.Start();
CancellationTokenSource tokenSource = new CancellationTokenSource(2000);
CancellationToken cancellationToken = tokenSource.Token;

Task<int> getDataTask = Task.Run<int>(GetData, cancellationToken);

//getDataTask.ConfigureAwait(ConfigureAwaitOptions.None);
getDataTask
    .ContinueWith(
    (task) =>
    {
        switch (task.Status)
        {
            //case TaskStatus.Created:
            //    Console.WriteLine("task created");
            //    break;
            //case TaskStatus.WaitingForActivation:
            //    Console.WriteLine("WaitingForActivation");
            //    break;
            //case TaskStatus.WaitingToRun:
            //    Console.WriteLine("WaitingToRun");
            //    break;
            //case TaskStatus.Running:
            //    Console.WriteLine("Running");
            //    break;
            //case TaskStatus.WaitingForChildrenToComplete:
            //    Console.WriteLine("WaitingForChildrenToComplete");
            //    break;
            case TaskStatus.RanToCompletion:
                Console.WriteLine("RanToCompletion");
                int result = getDataTask.Result;
                Console.WriteLine(result);
                break;
            case TaskStatus.Canceled:
                Console.WriteLine("Canceled");
                break;
            case TaskStatus.Faulted:
                Console.WriteLine("Faulted for " + task.Exception.Message);
                break;
            default:
                break;
        }
    }
    );

//Thread.Sleep(2000);
//tokenSource.Cancel();


Console.WriteLine("for exiting press any key...");
Console.ReadKey();

static int GetData()
{
    Thread.Sleep(4000);
    int sum = 0;
    for (global::System.Int32 i = 0; i < 100000000; i++)
    {
        sum += i;
        throw new Exception("sorry...");
    }
    return sum;
}
