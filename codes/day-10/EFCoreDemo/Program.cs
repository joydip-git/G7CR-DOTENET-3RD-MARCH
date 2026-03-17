using EFCoreDemo.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

AppDbContext? db = null;
try
{
    //db = new AppDbContext(@"server=joydip-pc\sqlexpress;database=appdb;integrated security=true; trust server certificate=true;");
    using (db = new AppDbContext())
    {
        if (db.Database.EnsureCreated())
        {
            //first fetch all the records (behind the scene SQL SELECT quey will be fired to fetch all the records)
            DbSet<Product> setOfProducts = db.Products;

            #region Operations    

            //1. add a new record
            //AddProduct(db, setOfProducts);

            //2. update an existing record
            //UpdateProduct(db, setOfProducts);

            //3. delete an existing product
            //DeleteProduct(db, setOfProducts);

            //4. show all records
            ShowProducts(setOfProducts);
            //ShowCategories(db);

            #endregion
        }
    }
}
catch (Exception e)
{
    Console.WriteLine(e);
}
//finally
//{
//    db?.Dispose();
//}
static void ShowCategories(AppDbContext? db)
{
    var all = db?.Categories;
    all?.ToList().ForEach(c =>
    {
        Console.WriteLine(c.CategoryId + ":" + c.CategoryName);
        //Console.WriteLine("--------------------------------------");
        //c.Products.ToList().ForEach(p => Console.WriteLine(p.ProductName));
        Console.WriteLine("\n\n");
    });
}
static void AddProduct(AppDbContext? db, DbSet<Product> setOfProducts)
{
    var newProduct = new Product { ProductId = 105, ProductName = "i phone 16", Description = "new phone from apple", Price = 115000.00M };

    EntityEntry<Product> entityEntry = setOfProducts.Add(newProduct);
    entityEntry.State = EntityState.Added;

    //Saves all changes made in this context to the database.
    //This method will automatically call ChangeTracker.DetectChanges() to discover any changes to entity instances before saving to the underlying database. This can be disabled via ChangeTracker.AutoDetectChangesEnabled.
    int addRes = db.SaveChanges();
    System.Console.WriteLine(addRes > 0 ? "record added" : "add failed");
}

static void UpdateProduct(AppDbContext? db, DbSet<Product> setOfProducts)
{
    Product? found = setOfProducts.Find(105);
    if (found != null)
    {
        found.Price = 125000.00M;
        setOfProducts.Update(found);
        int updateRes = db.SaveChanges();
        System.Console.WriteLine(updateRes > 0 ? "updated" : "update failed");
    }
    else
        Console.WriteLine($"product with id:105 not found...");
}

static void DeleteProduct(AppDbContext? db, DbSet<Product> setOfProducts)
{
    var found = setOfProducts.Find(105);
    if (found != null)
    {
        setOfProducts.Remove(found);
        int deleteRes = db.SaveChanges();
        Console.WriteLine(deleteRes > 0 ? "deleted" : "delete failed");
    }
    else
        Console.WriteLine("product with id: 105 not found...");
}

static void ShowProducts(DbSet<Product> setOfProducts)
{
    foreach (var product in setOfProducts)
    {
        System.Console.WriteLine(product.ProductId + ":" + product.ProductName + ":" + product.Price + ":" + product.Category.CategoryName);
    }
}