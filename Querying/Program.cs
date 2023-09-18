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

int prouductId = 15;
var products = from product in context.Products
               where product.Id > prouductId
               select product;

prouductId = 250;
foreach (var product in products)
{
    Console.WriteLine(product.Name);
}
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
    public ICollection<ProductComp> ProductComps { get; set; }

}

public class ProductComp
{
    public int Id { get; set; }
    public string Name { get; set; }
}
