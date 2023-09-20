using Microsoft.EntityFrameworkCore;
ECommerceDbContext context = new();

#region Change Tracker

#region Change Tracker Prop
//var products = await context.Products.ToListAsync();

//products[1].Name = "Product 123123"; //Update
//context.Products.Remove(products[7]);// Delete
//products[28].Price = 100; //Update


//var x = context.ChangeTracker.Entries();
//Console.WriteLine();

//await context.SaveChangesAsync();

#endregion

#region DetectChanges
//Product product = await context.Products.FirstOrDefaultAsync(p => p.Id == 14);
//if (product != null)
//{
//    product.Name = "Product Detect Changes 123";
//}

//context.ChangeTracker.DetectChanges();
//await context.SaveChangesAsync();


#endregion

#region Entries Metodu
//List<Product> products = await context.Products.ToListAsync();
//products.FirstOrDefault(p => p.Id == 14).Name = "Product 1414";
//context.Products.Remove(products.FirstOrDefault(p => p.Id == 13));
//products.FirstOrDefault(p => p.Id == 15).Stock = 1515;

//context.ChangeTracker.Entries().ToList().ForEach(p =>
//{
//    if (p.State == EntityState.Modified)
//    {
//        //...
//    }
//    else if (p.State == EntityState.Added)
//    {
//        //...
//    }
//    //...
//});


#endregion

#region AcceptAllChanges Metodu

//List<Product> products = await context.Products.ToListAsync();

//products.FirstOrDefault(p => p.Id == 5).Name = "Product 4646";
//context.Products.Remove(products.FirstOrDefault(p => p.Id == 8));

//await context.SaveChangesAsync(false);
//var x = context.ChangeTracker.Entries();
//Console.WriteLine();
//context.ChangeTracker.AcceptAllChanges();

#endregion

#region HasChanges Metodu
//var change = context.ChangeTracker.HasChanges(); 
#endregion

#region EntityStates

#region Detached

//Product product = new();
//var x = context.Entry(product).State;


#endregion
#region Added

//Product product = new()
//{
//    Name= "Test",
//    Price=123,
//    Stock=321
//};

//await context.Products.AddAsync(product);
//var x = context.Entry(product).State;
//Console.WriteLine();
//await context.SaveChangesAsync();
#endregion
#region Deleted

//Product? product= await context.Products.FirstOrDefaultAsync(p=>p.Id==5);
//if (product!=null)
//{
//    context.Products.Remove(product);
//}

//var x = context.Entry(product).State;

//Console.WriteLine();

//await context.SaveChangesAsync();

#endregion
#region Modified

//Product? product = await context.Products.FirstOrDefaultAsync(p => p.Id == 10);
//Console.WriteLine(context.Entry(product).State);
//if (product != null)
//{
//    product.Name = "Product 325";
//}

//Console.WriteLine(context.Entry(product).State);
//await context.SaveChangesAsync();
//Console.WriteLine(context.Entry(product).State);
#endregion

#region Entry Properties

//Product? product = await context.Products.FirstOrDefaultAsync(p=>p.Id==5);
//product.Name = "Product 825";
//product.Stock = 321;

//var productNameOrg = context.Entry(product).OriginalValues.GetValue<string>(nameof(product.Name));
//var productNameCur = context.Entry(product).CurrentValues.GetValue<string>(nameof(product.Name));
//var productNameDb = await context.Entry(product).GetDatabaseValuesAsync();
//var productNameDbData= productNameDb.GetValue<string>(nameof(product.Name));
//Console.WriteLine("Original:"+productNameOrg);
//Console.WriteLine("Current:" + productNameCur);
//Console.WriteLine("Db:"+ productNameDbData);

#endregion
#endregion
Console.WriteLine();
#endregion

#region Context & Entities

public class ECommerceDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductComp> ProductComps { get; set; }
    public DbSet<CompItem> CompItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(LocalDb)\\HcSqlServer; Database=ExampleDatabase");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CompItem>().HasKey(ci => new { ci.ProductId, ci.ProductCompId });
    }
}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Stock { get; set; }
    public int Price { get; set; }
    public ICollection<ProductComp>? ProductComps { get; set; }


}

public class ProductComp
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class CompItem
{
    public int ProductId { get; set; }
    public int ProductCompId { get; set; }
    public Product Product { get; set; }
    public ProductComp ProductComp { get; set; }
}
public class X
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string ProductCompName { get; set; }
}
#endregion