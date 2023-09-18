using Microsoft.EntityFrameworkCore;
ECommerceDbContext context = new();

#region contextten çekerek silme

//Product? product = await context.Products.FirstOrDefaultAsync(p => p.Id == 1);
//if (product != null)
//{
//    context.Products.Remove(product);
//}
//await context.SaveChangesAsync();
#endregion

#region track edilmeyen veri nasıl silinir
//Product product = new Product()
//{
//    Id= 3,
//};
//context.Products.Remove(product);
//context.SaveChanges();
#endregion

#region EntityState üzerinden silme
//Product product= new Product()
//{
//    Id= 2,
//};
//context.Products.Entry(product).State=EntityState.Deleted;
//await context.SaveChangesAsync();

#endregion

#region RemoveRange

List<Product> products= await context.Products.Where(p => p.Id < 8 && p.Id >= 4).ToListAsync();

context.Products.RemoveRange(products);
await context.SaveChangesAsync();

#endregion


public class ECommerceDbContext : DbContext{
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