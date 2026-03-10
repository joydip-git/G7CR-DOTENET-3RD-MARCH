using System.Collections;

namespace SetDemo
{
    class Person
    {
        public string Name { get; set; } = string.Empty;
        public int Id { get; set; }


        public override int GetHashCode()
        {
            //keyed hashing
            const int prime = 32;
            int hash = this.Id.GetHashCode() * prime;
            hash = (this.Name ?? string.Empty).GetHashCode() * hash;
            return hash;

            //plain hashing
            //return this.Id.GetHashCode();
        }
        public override bool Equals(object? obj)
        {
            //if (obj == null)
            //    throw new ArgumentNullException($"argument:{nameof(obj)} is NULL");
            ArgumentNullException.ThrowIfNull(obj);

            if (obj is Person other)
            {
                if (this == other)
                    return true;

                if (!this.Id.Equals(other.Id))
                    return false;

                if (!this.Name.Equals(other.Name))
                    return false;

                return true;
            }
            else
                throw new ArgumentException($"{nameof(obj)} is not of type {nameof(Person)}");
        }

        public override string? ToString()
        {
            return $"{Name}, {Id}";
            //return base.ToString();
            //return this.GetType().FullName;
        }
    }
    internal class Program
    {
        static void Main()
        {
            Person? anilPerson = new() { Id = 1, Name = "anil" };
            Person? sunilPerson = new() { Id = 2, Name = "sunil" };

            //if(anilPerson == sunilPerson)
            //anilPerson.Equals(null);
            //anilPerson.Equals(12);
            //anilPerson.Equals(sunilPerson)

            //if (anilPerson.Equals(sunilPerson))
            //if (anilPerson.GetHashCode() == sunilPerson.GetHashCode())
            //{
            //    Console.WriteLine("same");
            //}
            //else
            //    Console.WriteLine("not same");


            HashSet<int> set = new();

            //adds the first element simply and calculates an unique hash value using GetHashCode() method for that element
            set.Add(12);
            //for the next item onwards it calculates an unique hash value  using GetHashCode() method for that element and then checks whether that hash value is same as that of hash value of any previous element.
            //if the hash value of the current element is NOT same as that of hash value of any previous element, then the element will be added
            //if the hash values are same, in that case, it also checks whether both the elements are identical by using Equals() method. if the elemnts are identical then the current element will not be added. otherwise that will be added
            set.Add(13);
            set.Add(1);
            set.Add(12);

            //do not use for loop as the HashSet does not indexing
            foreach (int item in set)
            {
                Console.WriteLine(item);
            }

            HashSet<Person?> peopleSet = new();
            peopleSet.Add(anilPerson);
            peopleSet.Add(sunilPerson);

            foreach (Person? person in peopleSet)
            {
                //Console.WriteLine($"{person?.Name}, {person?.Id}");
                //Console.WriteLine(person?.ToString());
                Console.WriteLine(person);
            }
            
            List<Person?> people = peopleSet.ToList<Person?>();
            //.....
        }
    }
}
