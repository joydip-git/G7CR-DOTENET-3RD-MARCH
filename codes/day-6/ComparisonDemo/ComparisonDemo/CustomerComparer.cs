using Entities;

namespace ComparisonDemo
{
    public class CustomerComparer : IComparer<Customer>
    {
        public int Choice { get; set; } = 1;
        public int Compare(Customer? x, Customer? y)
        {
            if (x == null || y == null)
                throw new NullReferenceException("x or y is NULL");

            if (x == y)
                return 0;

            //if (x.Name.CompareTo(y.Name) == 0)
            //    return x.Mobile.CompareTo(y.Mobile);
            //else
            //    return x.Name.CompareTo(y.Name);
            int result = 0;
            switch (Choice)
            {
                case 1:
                    result = x.Name.CompareTo(y.Name);
                    break;

                case 2:
                    result = x.Mobile.CompareTo(y.Mobile);
                    break;

                default:
                    result = x.Name.CompareTo(y.Name);
                    break;
            }
            return result;
        }
    }
}
