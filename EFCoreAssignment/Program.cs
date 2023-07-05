// See https://aka.ms/new-console-template for more information
using EFCoreAssignment;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

var connection = "Data Source=localhost;Initial Catalog=EFCoreMastersSession1;Integrated Security=True"; // TODO : Add your connection string here
var optionsBuilder =
    new DbContextOptionsBuilder
           <AppDbContext>();
optionsBuilder.UseSqlServer(connection);

var options = optionsBuilder.Options;

var dbContext = new AppDbContext(options);

Filtering(dbContext);
SingleOrDefault(dbContext);
LoadingRelatedData_Manual(dbContext);
LoadingRelatedData_ExplicitLoading(dbContext);
LoadingRelatedData_EagerLoading(dbContext);

static void Filtering(AppDbContext dbContext)
{
    // TODO : Filter by Product Name
    var shop = dbContext.Shops
        .Where(s => s.Name == "Nintendo eShop")
        .ToList();
}

static void SingleOrDefault(AppDbContext dbContext)
{
    // TODO : Select using SingleOrDefault by Product Id 
    var prod = dbContext.Products
        .SingleOrDefault(p => p.Id == 11);
}

static void LoadingRelatedData_Manual(AppDbContext dbContext)
{
    // TODO : Load Product with related shop data manually
    var prod = dbContext.Products
        .FirstOrDefault();
    prod.Shop = dbContext.Shops
        .Single(s => s.Id == prod.ShopId);
}

static void LoadingRelatedData_ExplicitLoading(AppDbContext dbContext)
{
    // TODO : Load Product with related shop data explicitly
    var prod = dbContext.Products
        .FirstOrDefault();
    dbContext.Entry(prod)
        .Reference(p => p.Shop)
        .Load();
    dbContext.Entry(prod)
        .Collection(p => p.Reviews)
        .Load();
}

static void LoadingRelatedData_EagerLoading(AppDbContext dbContext)
{
    var output = dbContext.Products
        .Include(p => p.Shop)
        .Include(p => p.Reviews)
        .FirstOrDefault();
}


Console.WriteLine("EF Core is the best");
