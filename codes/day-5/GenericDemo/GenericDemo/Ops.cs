namespace GenericDemo
{
    internal class Ops<T> : IOps<T> where T : struct
    {
        public T[] FilterValues(T[] elements)
        {
            T[] values = [];

            //foreach (T item in values)
            //{
            //    if(typeof(T) == typeof(Int32))
            //    {
            //        int value = (int)T;
            //        if (item % 2 == 0)
            //        {

            //        }
            //    }
            //}
            return values;
        }
    }
}
