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

#region AcceptAll Metodu

#endregion

#endregion
Console.WriteLine();
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