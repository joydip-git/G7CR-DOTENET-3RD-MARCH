using System.Collections;

namespace GenericCollectionsDemo
{
    internal class MyList<T> : IEnumerable<T> //,ICollection<T>
    {
        T[] items = new T[4];
        int position = 0;

        public void Add(T item)
        {
            if (position == items.Length)
            {
                T[]? temp = items;
                items = new T[items.Length * 2];
                temp.CopyTo(items, 0);
                //temp = null;
            }

            items[position] = item;
            position++;
        }

        public int Count => position;
        public int Capacity => items.Length;

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < position; i++)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
