using Microsoft.EntityFrameworkCore;
ECommerceDbContext context = new();

#region Ekleme


//Product product = new()
//{
//    Name = "Product 2",
//    Stock = 2
//};

////await context.AddAsync(product);

//await context.Products.AddAsync(product);
//await context.SaveChangesAsync();
#endregion

#region EFCore Açısından Bir Verinin Eklenmesi Gerektiği Nasıl Anlaşılıyor?
//Product product = new Product()
//{
//    Name = "Test",
//    Stock = 1,
//};
//Console.WriteLine("Add İşlemi Öncesi:" + context.Entry(product).State);
//await context.Products.AddAsync(product);
//Console.WriteLine("Add İşlemi Sonrası, SaveChangesAsync Öncesi:" + context.Entry(product).State);
//await context.SaveChangesAsync();
//Console.WriteLine("SaveChangesAsync Sonrası:" + context.Entry(product).State);
#endregion

#region SaveChanges Verimli Kullanma
Product product1 = new()
{
    Name = "Test",
    Stock = 2,
};
Product product2 = new()
{
    Name = "Test",
    Stock = 3,
};
Product product3 = new()
{
    Name = "Test",
    Stock = 4,
};

await context.Products.AddRangeAsync(product1, product2, product3);
await context.SaveChangesAsync();

#endregion

public class ECommerceDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(LocalDb)\\HcSqlServer; Database=ExampleDatabase");
    }
}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Stock { get; set; }
}
