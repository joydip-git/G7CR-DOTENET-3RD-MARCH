using BusinessLayer;
using BusinessEntities;

IManager<ProductDTO, int>? manager = null;
try
{
    char toContinue = 'n';
    do
    {
        ShowMenu();
        int choice = GetChoice();
        manager = new ProductManager();
        Execute(manager, choice);
        Decide(ref toContinue);
    } while (toContinue != 'n');
}
catch (Exception e)
{
    Console.WriteLine(e);
}

#region Local Utility Functions
static void ShowMenu() => Console.WriteLine(
    "1. Show all Products\n2. Show a Product \n3. Add new Product \n4. Update a Product \n5. Delete a Product");

static int GetChoice()
{
    Console.Write("enter choice[1/2/3/4/5]: ");
    _ = int.TryParse(Console.ReadLine() ?? "1", out int choice);
    return choice;
}

static void ShowAllProducts(IManager<ProductDTO, int> manager)
{
    var allProducts = manager.FetchAll(3);
    //if (allProducts != null && allProducts.Count() > 0)
    //{
    //    foreach (var item in allProducts)
    //    {
    //        Console.WriteLine(item);
    //    }
    //}
    if (allProducts != null && allProducts.Count() > 0)
    {
        Action<ProductDTO> printProduct = p => Console.WriteLine(p);
        allProducts.ToList().ForEach(printProduct);
    }
}
static void ShowARecord(IManager<ProductDTO, int> manager)
{
    Console.WriteLine("\n\n");
    var product = manager.Fetch(100);
    Console.WriteLine(product?.ToString());
}
static void AddProduct(IManager<ProductDTO, int> manager)
{
    var status = manager.Insert(
        new ProductDTO { Name = "Pillars of the Earth", Price = 699.00M, Description = "New book from Ken Follet" }
        );
    Console.WriteLine(status ? "Product Added Successfully" : "Operation failed");
}
static void UpdateProduct(IManager<ProductDTO, int> manager)
{
    var status = manager.Modify(103,
        new ProductDTO { Name = "The Alchemist", Price = 799.00M, Description = "New book from Paul Cohelo" }
        );
    Console.WriteLine(status ? "Product Updated Successfully" : "Operation failed");
}
static void DeleteProduct(IManager<ProductDTO, int> manager)
{
    Console.Write("\nenter id:");
    bool done = int.TryParse(Console.ReadLine(), out int id);
    if (done)
    {
        var status = manager.Remove(id);
        Console.WriteLine(status ? "Product deleted Successfully" : "Operation failed");
    }
}

static void Execute(IManager<ProductDTO, int> manager, int choice)
{
    switch (choice)
    {
        case 1:
            ShowAllProducts(manager);
            break;

        case 2:
            ShowARecord(manager);
            break;

        case 3:
            AddProduct(manager);
            break;

        case 4:
            UpdateProduct(manager);
            break;

        case 5:
            DeleteProduct(manager);
            break;

        default:
            ShowAllProducts(manager);
            break;
    }
}
static void Decide(ref char decision)
{
    Console.Write("\nContinue[y/Y/n/N]? ");
    decision = char.Parse(Console.ReadLine() ?? "y");
    if (char.IsUpper(decision))
        decision = char.ToLower(decision);
}

#endregion