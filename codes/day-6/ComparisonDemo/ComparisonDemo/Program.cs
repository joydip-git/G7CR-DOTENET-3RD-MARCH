using Entities;
namespace ComparisonDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = [10, 21, 12, 31, 23, 41];
            //for (int i = 0; i < numbers.Count; i++)
            //{
            //    for (int j = i + 1; j < numbers.Count; j++)
            //    {
            //        if (numbers[i].CompareTo(numbers[j]) > 0)
            //        {
            //            int temp = numbers[i];
            //            numbers[i] = numbers[j];
            //            numbers[j] = temp;
            //        }
            //    }
            //}
            numbers.Sort();
            List<Customer> customers =
                [
                    new Customer{ Name="anil", Mobile=9090909092},
                    new Customer{ Name="sunil", Mobile=9090909091},
                    new Customer{ Name="joy", Mobile=9090909090}
                ];

            //for (int i = 0; i < customers.Count; i++)
            //{
            //    for (int j = i + 1; j < customers.Count; j++)
            //    {
            //        if (customers[i].CompareTo(customers[j]) > 0)
            //        {
            //            Customer temp = customers[i];
            //            customers[i] = customers[j];
            //            customers[j] = temp;
            //        }
            //    }
            //}

            //1. Sort() method expects that at least one object has implemented CompareTo from IComparable interface
            //customers.Sort();

            //2. choice based sorting
            Console.WriteLine("1. sort by name\n2. sort by mobile");
            Console.Write("enter choice[1/2]: ");
            int choice = int.Parse(Console.ReadLine() ?? "1");

            CustomerComparer customerComparer = new() { Choice = choice };
            //this version of Sort() method expects that you pass an instance of a class which implements the IComparer<T> interface and has implemented the Compare() method
            customers.Sort(customerComparer);

            foreach (Customer customer in customers)
            {
                Console.WriteLine(customer.Name + " " + customer.Mobile);
            }
        }
    }
}
