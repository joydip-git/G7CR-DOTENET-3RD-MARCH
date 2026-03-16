// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var customers = new List<Customer>
{
    new() { Id = 1, Name = "anil" },
    new() { Id = 2, Name = "sunil" },
    new() { Id = 3, Name = "joydip" }
};

var orders = new List<Order>
{
    new(){ Id=100, CustomerId=customers[0].Id, Customer=customers[0], Date=new DateTime(2026,3,10), Amount=1000 },
    new(){ Id=101, CustomerId=customers[0].Id, Customer=customers[0], Date=new DateTime(2026,3,11), Amount=2000 },
    new(){ Id=102, CustomerId=customers[1].Id, Customer=customers[1], Date=new DateTime(2026,3,10), Amount=1500 },
    new(){ Id=103, CustomerId=customers[1].Id, Customer=customers[1], Date=new DateTime(2026,3,12), Amount=2500 }
};
//select isnull(sum(amount),0) from orders where date=
var total = orders
    .Where(o => o.Date == new DateTime(2026, 3, 10))
    .Sum(o => o.Amount);
Console.WriteLine("\n\n");

var query = (from c in customers
             join o in orders on c.Id equals o.CustomerId into coGroup
             from g in coGroup.DefaultIfEmpty(new Order() { Customer = c, CustomerId = c.Id, Date = DateTime.MinValue, Id = 0 })
             select new
             {
                 CustomerName = g.Customer?.Name,
                 Total = coGroup.Sum(o1 => o1.Amount)
             }).Distinct();

var query1 =
    customers
    .GroupJoin(
        orders,
        c => c.Id,
        o => o.CustomerId,
        (Customer cust, IEnumerable<Order> orderGroup) => new
        {
            CustomerName = cust.Name,
            Total = orderGroup.Sum(order => order.Amount)
        });

query1.ToList().ForEach(record => Console.WriteLine(record.CustomerName + ":" + record.Total));

/*
 * anil  3000
 * sunil 4000
 * joydip 0
 */

Console.WriteLine(total ?? 0);


class Customer
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public ICollection<Order>? Orders { get; set; }
}
class Order
{
    public required int Id { get; set; }
    public required DateTime Date { get; set; }
    public decimal? Amount { get; set; }
    public required int CustomerId { get; set; }
    public required Customer Customer { get; set; }
}