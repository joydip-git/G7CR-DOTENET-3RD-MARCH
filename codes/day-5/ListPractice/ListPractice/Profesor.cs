namespace ListPractice
{
    internal class Profesor(int id) : IComparable<Profesor>
    {
        private readonly int id = id;
        public int Id => id;

        //public Profesor() { }
        //public Profesor(string firstName, string lastName, string college, long mobileNo)
        //{
        //    FirstName = firstName;
        //    LastName = lastName;
        //    College = college;
        //    MobileNo = mobileNo;
        //}

        //private string FirstName_BF = string.Empty;
        //auto properties and property setter
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string College { get; set; } = string.Empty;
        public long MobileNo { get; set; }

        //writing the logic of comparsion betwen two instances of Professor class: internalization of comparison
        public int CompareTo(Profesor? other)
        {
            if (other != null)
            {
                if (other == this)
                    return 0;
                else
                {
                    return this.FirstName.CompareTo(other.FirstName);
                }
            }
            else
                throw new NullReferenceException("other is NULL");
        }
    }
}
