// See https://aka.ms/new-console-template for more information
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using EFCoreAssignment;
using EFCoreAssignment.Entities;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

var connection = "Data Source=localhost;Initial Catalog=EFCoreMastersSession1;Integrated Security=True"; // TODO : Add your connection string here
var optionsBuilder =
    new DbContextOptionsBuilder
           <AppDbContext>();
optionsBuilder.UseSqlServer(connection);

var options = optionsBuilder.Options;

var dbContext = new AppDbContext(options);

//Filtering(dbContext);
//SingleOrDefault(dbContext);
//LoadingRelatedData_Manual(dbContext);
//LoadingRelatedData_ExplicitLoading(dbContext);
//LoadingRelatedData_EagerLoading(dbContext);
InsertProduct(dbContext);
InsertProductWithNewShop(dbContext);
UpdateProduct(dbContext);
DeleteProduct(dbContext);
DeleteProductByKey(dbContext);

//static void Filtering(AppDbContext dbContext)
//{
//// TODO : Filter by Product Name
//var shop = dbContext.Shops
//    .Where(s => s.Name == "Nintendo eShop")
//    .ToList();
//}

//static void SingleOrDefault(AppDbContext dbContext)
//{
//// TODO : Select using SingleOrDefault by Product Id 
//var prod = dbContext.Products
//    .SingleOrDefault(p => p.Id == 11);
//}

//static void LoadingRelatedData_Manual(AppDbContext dbContext)
//{
//// TODO : Load Product with related shop data manually
//var prod = dbContext.Products
//    .FirstOrDefault();
//prod.Shop = dbContext.Shops
//    .Single(s => s.Id == prod.ShopId);
//}

//static void LoadingRelatedData_ExplicitLoading(AppDbContext dbContext)
//{
//// TODO : Load Product with related shop data explicitly
//var prod = dbContext.Products
//    .FirstOrDefault();
//dbContext.Entry(prod)
//    .Reference(p => p.Shop)
//    .Load();
//dbContext.Entry(prod)
//    .Collection(p => p.Reviews)
//    .Load();
//}

//static void LoadingRelatedData_EagerLoading(AppDbContext dbContext)
//{
//var output = dbContext.Products
//    .Include(p => p.Shop)
//    .Include(p => p.Reviews)
//    .FirstOrDefault();
//}

static void InsertProduct(AppDbContext dbContext)
{
    // TODO: Insert a new Product
    var product = new Product()
    {
        Name = "Pokemon Scarlet",
        ShopId = 3
    };
    using (dbContext)
    {
        dbContext.Add(product);
        dbContext.SaveChanges();
    }
}

static void InsertProductWithNewShop(AppDbContext dbContext)
{
    // TODO: Insert a new Product with a new Shop
    var shop = new Shop()
    {
        Name = "Bethesda shop"
    };

    var product = new Product()
    {
        Name = "Final Fantasy XIV",
        ShopId = 8
    };

    using (dbContext)
    {
        dbContext.Add(shop);
        dbContext.Add(product);
        dbContext.SaveChanges();
    }
}

static void UpdateProduct(AppDbContext dbContext)
{
    // TODO: Update a Product
    var productId = 18;

    var product = dbContext.Products.Single(p => p.Id == productId);
    product.Name = "Final Fantasy IX Remake";
    dbContext.SaveChanges();
}

static void DeleteProduct(AppDbContext dbContext)
{
    // TODO: Delete a Product
    var productId = 17;
    var product = dbContext.Products
        .IgnoreQueryFilters()
        .Single(p => p.Id == productId);
    dbContext.Remove(product);
    dbContext.SaveChanges();
}

static void DeleteProductByKey(AppDbContext dbContext)
{
    // TODO: Delete a Product with just having a key
    var bookId = 18;

    var book = new Product { Id = bookId };
    dbContext.Remove(book);
    dbContext.SaveChanges();
}

Console.WriteLine("EF Core is the best");
