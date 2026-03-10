namespace Entities
{
    public class Customer  //: IComparable<Customer>
    {
        public Customer()
        {

        }
        public Customer(string name, long mobile)
        {
            Name = name;
            Mobile = mobile;
        }

        public string Name { get; set; } = string.Empty;
        public long Mobile { get; set; }

        //public int CompareTo(Customer? other)
        //{
        //    if (other == null)
        //        throw new NullReferenceException("other is NULL");

        //    if (this == other)
        //        return 0;

        //    if (this.Name.CompareTo(other.Name) == 0)
        //        return this.Mobile.CompareTo(other.Mobile);
        //    else
        //        return this.Name.CompareTo(other.Name);
        //}
    }
}
