using DataAccessLayer;
using BusinessEntities;

IRepository<Product,int>? repository = null;
try
{
    repository = new ProductRepository();
    var allProducts = repository.GetAll();

    if (allProducts != null && allProducts.Count() > 0)
    {
        foreach (var item in allProducts)
        {
            Console.WriteLine(item);
        }
    }
    Console.WriteLine("\n\n");
    var product =  repository.Get(100);
    Console.WriteLine(product?.ToString());
    
}
catch (Exception e)
{
    Console.WriteLine(e);
}