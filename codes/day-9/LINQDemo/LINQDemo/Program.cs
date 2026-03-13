List<int> numbers = [1, 4, 5, 2, 8, 6, 0, 9, 3, 7];

//1. Method syntax
//-----------------------------------------------------
//IOrderedEnumerable<int> sortedNumbers = numbers.OrderByDescending(num => num);
//IEnumerable<int> filteredNumbers = sortedNumbers.Where(num => num % 2 == 0);
//IEnumerable<string> transformedValues = filteredNumbers.Select(num => (num * 3).ToString());


//var sortedNumbers = numbers.OrderByDescending(num => num);
//var filteredNumbers = sortedNumbers.Where(num => num % 2 == 0);
//var transformedValues = filteredNumbers.Select(num => (num * 3).ToString());

//var res = numbers
//    .OrderByDescending(num => num)
//    .Where(num => num % 2 == 0)
//    .Select(num => (num * 3).ToString())
//    .ToList<string>();


//2. Quety syntax
//---------------------------------------
//numbers -> source of data
//num -> range variable
var res = (from num in numbers
           orderby num descending
           where num % 2 == 0
           select (num * 3).ToString()).ToList<string>();

foreach (var item in res)
{
    Console.WriteLine(item);
}


List<string> names = ["anil", "sunil", "amnit", "suraj", "joy", "ramesh"];

IEnumerable<IGrouping<char, string>> nameGroups =
    names
    .OrderBy(name => name)
    .GroupBy(name => name[0]);

foreach (var group in nameGroups)
{
    Console.WriteLine($"{group.Key}");
    Console.WriteLine("---------------------------------");
    foreach (var name in group)
    {
        Console.WriteLine(name);
    }
}

List<Customer> customers = [
    new() { Name = "sunil", CustomerId = 2 },
    new() { Name = "joydip", CustomerId = 1 },
    new() { Name = "anil", CustomerId = 3 }
    ];
List<Order> orders = [
    new (){ Customer = customers[0], CustomerId=customers[0].CustomerId, OrderAmount =1000, OrderDate = DateTime.Now, OrderId=1012},
    new (){ Customer = customers[0], CustomerId=customers[0].CustomerId, OrderAmount =2000, OrderDate =new DateTime(2026,3,10), OrderId=2123},
    new (){ Customer = customers[1], CustomerId=customers[1].CustomerId, OrderAmount =1500, OrderDate = new DateTime(2026,2,27), OrderId=1345}
    ];

//var joinQuery = from c in customers
//                join o in orders on c.CustomerId equals o.CustomerId
//                where c.CustomerId == 2
//                orderby o.OrderDate ascending
//                select new { CustomerName = c.Name, OrderedOn = o.OrderDate.Date, TotalAmount = o.OrderAmount };

var joinQuery = customers
    .Where(c => c.CustomerId == 2)
    .Join(
    orders,
        c => c.CustomerId,
        o => o.CustomerId,
        (c, o) => new { CustomerName = c.Name, OrderedOn = o.OrderDate.Date, TotalAmount = o.OrderAmount })
    .OrderBy(ano => ano.OrderedOn);

foreach (var item in joinQuery)
{
    Console.WriteLine($"{item.CustomerName} placed order on {item.OrderedOn.ToShortDateString()} worth INR. {item.TotalAmount}");
}


class Customer
{
    public int CustomerId { get; set; }
    public string Name { get; set; } = string.Empty;
    //navigation property (establishes has-a relationship (1:M)
    public IEnumerable<Order>? Orders { get; set; }
}
class Order
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal OrderAmount { get; set; }
    public int CustomerId { get; init; }
    //navigation property (establishes has-a relationship (1:1)
    public Customer? Customer { get; set; }
    //public IEnumerable<Product> Products { get; set; } = [];
}

class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal? Price { get; set; }
    //public IEnumerable<Order>? Orders { get; set; }
    //public Order? Order { get; set; }
}