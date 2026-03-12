namespace CustomExceptionHandling
{
    public class DLApplicationForm
    {
        public string Name { get; set; } = string.Empty;

        private int age;
        private DateTime dateOfBirth;
       
        public DateTime DateOfBirth 
        {
            get => dateOfBirth;
            set 
            {
                dateOfBirth = value;
                DateTime current = DateTime.Now;
                TimeSpan difference = current - dateOfBirth;
                int diffInDays = difference.Days;
                Age = diffInDays / 365;
            }
                
        }

        public int Age
        {
            private set 
            {
                if (value < 18)
                {
                    var e = new InvalidAgeException($"applicant age: {value} which is less than the permissible age of 18");
                    //var e = new InvalidAgeException();
                    throw e;
                }
                else
                    age = value;
            }
            get => age;
        }

    }
}
