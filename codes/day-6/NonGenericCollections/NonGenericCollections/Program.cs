using System.Collections;
//following namespaces are included by default (known as Implicit usings)
//using System;
//using System.Collections.Generic;

namespace NonGenericCollections
{
    internal class Program
    {
        static void Main()
        {
            List<int> ints = new();
            ArrayList list = new();
            //list.Add(12);
            int x = 12;
            //boxing
            Object obj = x;
            //unboxing
            int y = (int)obj;

            //list.Add(obj);
            list.Add(12);
            list.Add('a');
            list.Add(12.34);
            list.Add("hello");
            list.Sort();
            foreach (object item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
