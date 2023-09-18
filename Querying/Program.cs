using Microsoft.EntityFrameworkCore;
ECommerceDbContext context = new();

#region Method Syntax

//var products = await context.Products.ToListAsync();

#endregion

#region Query Syntax

//var products2 = await (from product in context.Products
//                 select product).ToListAsync();

#endregion

#region IQueryable & IEnumerable

//var products = from product in context.Products
//               select product;
//var iqueryable = products;
//var ienumerable = await products.ToListAsync();

#endregion

#region Deffered Execution

//int prouductId = 15;
//var products = from product in context.Products
//               where product.Id > prouductId
//               select product;

//prouductId = 250;
//foreach (var product in products)
//{
//    Console.WriteLine(product.Name);
//}
#endregion

#region Çoğul veri getiren sorgulama fonksiyonları

#region ToList
//List<Product> products = await context.Products.ToListAsync();
#endregion

#region Where

#region Method syntax
//var products = await context.Products.Where(p => p.Stock > 254).ToListAsync();
#endregion

#region Query sytnax
//var products = await (from product in context.Products
//                      where product.Stock > 254
//                      select product).ToListAsync();

#endregion

#endregion

#region OrderBy
#region Method Syntax
//var products = await context.Products
//               .Where(p => p.Stock > 250 && p.Name.EndsWith("5"))
//               .OrderByDescending(p => p.Stock).ToListAsync();

//foreach (var product in products)
//{
//    Console.WriteLine("ProductName:"+product.Name+" "+"Stock:"+product.Stock);
//}
#endregion
#region Query Syntax
//var products = await (from product in context.Products
//                      where product.Stock > 250 && product.Name.EndsWith("5")
//                      orderby product.Stock
//                      select product).ToListAsync();
//foreach (var item in products)
//{
//    Console.WriteLine(item.Name+" "+item.Stock);
//}
#endregion
#endregion

#region ThenBy
//var products = await context.Products
//               .Where(p => p.Stock > 250 && p.Name.EndsWith("5"))
//               .OrderBy(p => p.Stock).ThenBy(p=>p.Id).ToListAsync();
//foreach (var item in products)
//{
//    Console.WriteLine(item.Id+" "+item.Name+" "+item.Stock);
//}

#endregion

#endregion

#region Tekil veri getiren sorgulama fonskiyonları

#region Single Fonksiyonları
#region SingleAsync

//var data = await context.Products.SingleAsync(p => p.Id == 33);

#endregion
#region SingleOrDefault
//var data=  await context.Products.SingleOrDefaultAsync(p => p.Id == 33);

#endregion




#endregion
#region First Fonksiyonları
#region First
//var data = await context.Products.FirstAsync(p => p.Name.Contains("P"));
#endregion

#region FirstOrDefault  
//var data = await context.Products.FirstOrDefaultAsync(p => p.Name.Contains("XYZ"));
#endregion


#endregion
#region Find Fonksiyonları
#region FindAsync
//var data = await context.Products.FindAsync(53634);

#endregion

#endregion
#region Last

 var data  = await context.Products.OrderBy(p=>p.Stock).LastAsync(p=>p.Id>1);
#endregion
#endregion

#region Diğer sorgulama fonksiyonları

#endregion

Console.WriteLine();
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
    public ICollection<ProductComp> ProductComps { get; set; }


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