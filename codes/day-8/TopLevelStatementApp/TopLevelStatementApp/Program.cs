using static TopLevelStatementApp.Utilities.Utility;

Show(args);
Person p = new() { Name = "anil", Id = 1 };
Console.WriteLine(p);
LogicDel<int> evenDel = num => num % 2 == 0;
Console.WriteLine(evenDel(13));
//return 0;

class Person
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public override string ToString() => $"{Name}, {Id}";
}
delegate bool LogicDel<in T>(T x);
