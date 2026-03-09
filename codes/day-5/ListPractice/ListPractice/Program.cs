namespace ListPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //object initializer
            Profesor anilProfessor = new Profesor { FirstName = "anil", LastName = "gupta", College = "AMC", MobileNo = 9090909091 };
            Profesor sunilProfessor = new Profesor { FirstName = "sunil", LastName = "mishra", College = "St. Johns", MobileNo = 9090909090 };
            Profesor joydipProfessor = new Profesor { FirstName = "joydip", LastName = "mondal", College = "Christ", MobileNo = 9090909092 };

            //anilProfessor.CompareTo(null);
            //anilProfessor.CompareTo(anilProfessor);

            //List<Profesor> profesors = new List<Profesor>();
            //profesors.Add(anilProfessor);
            //profesors.Add(sunilProfessor);
            //profesors.Add(joydipProfessor);

            //collection intiliazer
            //List<Profesor> profesors = new List<Profesor> { anilProfessor, sunilProfessor, joydipProfessor };

            //collection expression
            List<Profesor> profesors =
                [
                anilProfessor, sunilProfessor, joydipProfessor
                ];
            /*
            for (int i = 0; i < profesors.Count; i++)
            {
                for (int j = i + 1; j < profesors.Count; j++)
                {
                    //if (profesors[i].MobileNo > profesors[j].MobileNo)
                    //if (profesors[i].MobileNo.CompareTo(profesors[j].MobileNo) > 0)
                    //if (profesors[i].FirstName.CompareTo(profesors[j].FirstName) > 0)
                    if (profesors[i].CompareTo(profesors[j]) > 0)
                    {
                        Profesor temp = profesors[i];
                        profesors[i] = profesors[j];
                        profesors[j] = temp;
                    }
                }
            }
            */

            profesors.Sort();
            foreach (Profesor p in profesors)
            {
                Console.WriteLine($"{p.FirstName}, {p.LastName}, {p.College}, {p.MobileNo}");
            }
        }
    }
}
