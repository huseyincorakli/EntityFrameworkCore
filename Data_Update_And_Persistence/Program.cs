using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

ECommerceDbContext context = new();

#region Veri Güncelleme
//Product? product = await context.Products.FirstOrDefaultAsync(p => p.Id == 431);

//if (product != null)
//{
//    product.Name = "Güncellenmiş Product";
//    product.Stock = 999;
//}
//else
//{
//    Console.WriteLine("Product Bulunamadı");
//}

//await context.SaveChangesAsync();
#endregion

#region Track edilmeyen veriyi güncelleme

//Product product = new()
//{
//    Id = 3,
//    Name = "Contextsiz Güncelleme",
//    Stock = 123
//};

//context.Products.Update(product);
//await context.SaveChangesAsync();
#endregion

#region EFCore Açısından Bir Verinin Eklenmesi Gerektiği Nasıl Anlaşılıyor?

//Product? product = await context.Products.FirstOrDefaultAsync(product => product.Id == 5);
//Console.WriteLine("Güncellenmeden Önce:"+ context.Entry(product).State);
//if (product != null)
//{

//    product.Name = "Veri Güncellemesi Product X";
//    product.Stock = 99;
//    Console.WriteLine("Güncellenmeden Sonra:" + context.Entry(product).State);
//}
//else
//    Console.WriteLine("Product Bulunamadı");

//await context.SaveChangesAsync();
//Console.WriteLine("Save Sonrası:" + context.Entry(product).State);

#endregion

#region Çoklu Güncelleme
List<Product> products = await context.Products.ToListAsync(); ;

foreach (var product in products)
{
    if (product.Id==4)
    {
        product.Name = "Çoklu güncelleme ID";
    }
    else
        product.Name= "Diğerlerinin ismi aynı olsun";
}
//Her ürün güncellemesi sonrasında SaveChangesAsync çağırmak yerine tüm modified işlemlerinden sonra çağırmak 
//bize bu transaction açısından yararlı olacaktır. Hali hazırda context nesnesi üzerinden verileri çektiğimiz için 
// verilerimiz takip edildiğini unutmayalım.
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

