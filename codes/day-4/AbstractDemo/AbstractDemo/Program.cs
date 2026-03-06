using DataAccessLibrary;

namespace AbstractDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1. data from database\n2. data from xml file");
            Console.Write("enter choice[1/2]: ");
            int choice = int.Parse(Console.ReadLine());

            DataAccess dataAccess = DataAccessFactory.CreateDataAccessObject(choice);
            if (dataAccess != null)
            {
                Console.WriteLine(dataAccess.GetData());
            }
        }
    }
}
