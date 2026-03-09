namespace ListPractice
{
    internal class Person
    {
        private string FirstName_BackingField;
        //private string LastName_BackingField;
        //private string Location_BackingField;
        //private long MobileNo_BackingField;

        public Person()
        {

        }

        public Person(string firstName, string lastName, string location, long mobileNo)
        {
            this.FirstName_BackingField = firstName;
            this.LastName = lastName;
            this.Location = location;
            this.MobileNo = mobileNo;
            //this.LastName_BackingField = lastName;
            //this.Location_BackingField = location;
            //this.MobileNo_BackingField = mobileNo;
        }

        //automatic properties/auto properties
        //public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Location { get; set; }
        public long MobileNo { get; set; }
        /*
       public string LastName 
       { 
           get => LastName_BackingField; 
           set => LastName_BackingField = value; 
       }
       public string Location 
       { 
           get => Location_BackingField; 
           set => Location_BackingField = value; 
       }
       public long MobileNo 
       { 
           get => MobileNo_BackingField; 
           set => MobileNo_BackingField = value; 
       }
       */

        public string FirstName
        {
            get => FirstName_BackingField;
            set
            {
                if (value != string.Empty)
                    throw new Exception("name can't be empty");
                else
                    FirstName_BackingField = value;
            }

        }
    }
}
