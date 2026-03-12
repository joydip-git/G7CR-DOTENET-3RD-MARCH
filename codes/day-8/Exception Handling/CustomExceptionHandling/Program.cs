namespace CustomExceptionHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ShowInnerException();
            try
            {
                DLApplicationForm joydipForm = new() { Name = "joydip", DateOfBirth = new DateTime(2010, 1, 1) };
                Console.WriteLine($"congrats: {joydipForm.Name} has submitted form for DL");
            }
            catch (InvalidAgeException e)
            {
                Console.WriteLine(e);
            }
        }
        static void ShowInnerException()
        {
            List<Person>? people = null;
            try
            {
                people = [
                    new Person{ Name= "anil", Id=1},
                new Person{ Name= "sunil", Id=2}
                    ];

                people.Sort();
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e);
                Console.WriteLine("\n inner exception details \n");
                Console.WriteLine(e.InnerException);
            }
        }
    }
}
