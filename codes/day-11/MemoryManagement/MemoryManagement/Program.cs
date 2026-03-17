using MemoryManagement;

try
{
   
    //using block
    //Dispose method is called at the end of the scope created by using block. this gurantees that the object has released unmanaged resources.
    using (FileHandler fileHandler = new())
    {
        string data = fileHandler.GetData(@"data.txt");
        //fileHandler.Dispose();
        Console.WriteLine(data);
        //GC.Collect();
        //Console.ReadLine();
        
    }
    GC.Collect();
    GCMemoryInfo memoryInfo = GC.GetGCMemoryInfo();
    //GC.AddMemoryPressure(12506743930);
    //GC.AddMemoryPressure(12337733877);
    Console.WriteLine(memoryInfo.MemoryLoadBytes);
}
catch (FileNotFoundException e)
{
    Console.WriteLine(e);
}
catch (IOException e)
{
    Console.WriteLine(e);
}
catch (Exception e)
{
    Console.WriteLine(e);
}
