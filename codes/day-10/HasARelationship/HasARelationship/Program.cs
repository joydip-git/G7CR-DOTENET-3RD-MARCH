Category laptop = new() { CategoryId = 1, CategoryName = "Laptop" };
Category mobile = new() { CategoryId = 2, CategoryName = "Mobile" };
Category book = new() { CategoryId = 3, CategoryName = "Book" };


Product dellLaptop = new() { ProductId = 1, Price = 120000.00M, ProductName = "Dell Xps 15", Category = laptop, CategoryId = laptop.CategoryId };

Product onePlusMobile = new() { ProductId = 2, Price = 50000.00M, ProductName = "One PLus 13", Category = mobile, CategoryId = mobile.CategoryId };

Product alchemistBook = new() { ProductId = 3, Price = 700.00M, ProductName = "The Alchemist", Category = book, CategoryId = book.CategoryId };

Console.WriteLine(dellLaptop.Category.CategoryName);

//if the Products property is assigned to a collection already
laptop.Products.Add(dellLaptop);
mobile.Products.Add(onePlusMobile);
book.Products.Add(alchemistBook);

//if the Products property is null
//laptop.Products = [dellLaptop];
//mobile.Products = [onePlusMobile];
//book.Products = [alchemistBook];

//individual book records
Book book1 = new() { BookIsbn = 100, Price = 1000, Title = "The Alchemist" };
Book book2 = new() { BookIsbn = 201, Price = 899, Title = "some book" };
//books table
var books = new List<Book> { book1, book2 };

//individual customer records
Customer anilCust = new() { CustomerId = 1, CustomerName = "anil" };
Customer sunilCust = new() { CustomerId = 2, CustomerName = "sunil" };
//customers table
var cutsomers = new List<Customer> { anilCust, sunilCust };

//individual entry records
LedgerEntry entry1 = new() { EntryId = 1, BorrowDate = new DateTime(2026, 3, 7), Customer = anilCust, CustomerId = anilCust.CustomerId, Book = book1, BookIsbn = book1.BookIsbn };
entry1.ReturnDate = DateTime.Now;

LedgerEntry entry2 = new() { EntryId = 2, BorrowDate = new DateTime(2026, 3, 9), Customer = sunilCust, CustomerId = sunilCust.CustomerId, Book = book2, BookIsbn = book2.BookIsbn };
//entries tables
var entries = new List<LedgerEntry>() { entry1, entry2 };

class Category
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;

    //public ICollection<Product>? Products { get; set; }
    public ICollection<Product> Products { get; set; } = [];
}

class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public decimal? Price { get; set; }
    public int? CategoryId { get; set; }

    //navigation property
    public Category? Category { get; set; }
}

class Book
{
    public int BookIsbn { get; set; }
    public string Title { get; set; } = string.Empty;
    public decimal? Price { get; set; }
    public ICollection<Author>? Authors { get; set; }
    //public ICollection<Customer>? Customers { get; set; }
}

class Author
{
    public long MobileNo { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<Book>? Books { get; set; }
}
class Customer
{
    public int CustomerId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    //public ICollection<Book>? Books { get; set; }
}

//Association class
class LedgerEntry
{
    public int EntryId { get; set; }
    public int CustomerId { get; set; }
    public int BookIsbn { get; set; }
    public DateTime BorrowDate { get; set; }
    public DateTime? ReturnDate { get; set; }

    //navigation properties
    public Customer? Customer { get; set; }
    public Book? Book { get; set; }
}
