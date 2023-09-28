using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

Console.WriteLine();
#region Default Convention
//public class Kitap
//{
//    public int Id { get; set; }
//    public string KitapAdi { get; set; }
//    public ICollection<Yazar> Yazarlar { get; set; }
//}

//public class Yazar 
//{

//    public int Id { get; set; }
//    public string YazarAdi { get; set; }
//    public ICollection<Kitap> Kitaplar { get; set; }
//}
#endregion
#region Data Annotations 
//public class Kitap
//{
//    public int Id { get; set; }
//    public string KitapAdi { get; set; }
//    public ICollection<KitapYazar> Yazarlar { get; set; }
//}

//public class KitapYazar
//{
//    [ForeignKey(nameof(Yazar))]
//    public int YId { get; set; }

//    [ForeignKey(nameof(Kitap))]
//    public int KId { get; set; }

//    public Kitap Kitap { get; set; }
//    public Yazar Yazar { get; set; }
//}

//public class Yazar
//{

//    public int Id { get; set; }
//    public string YazarAdi { get; set; }
//    public ICollection<KitapYazar> Kitaplar { get; set; }
//}
#endregion
#region Fluent API
public class Kitap
{
    public int Id { get; set; }
    public string KitapAdi { get; set; }
    public ICollection<KitapYazar> Yazarlar { get; set; }
}
public class KitapYazar
{
  
    public int YazarId { get; set; }

    
    public int KitapId { get; set; }

    public Kitap Kitap { get; set; }
    public Yazar Yazar { get; set; }
}
public class Yazar
{

    public int Id { get; set; }
    public string YazarAdi { get; set; }
    public ICollection<KitapYazar> Kitaplar { get; set; }
}
#endregion

#region DbContext
class ExampleDbContext : DbContext
{
    public DbSet<Yazar> Yazarlar { get; set; }
    public DbSet<Kitap> Kitaplar { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(LocalDb)\\HcSqlServer; Database=ExampleDatabase");
    }
    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<KitapYazar>()
    //        .HasKey(ky => new { ky.YazarId, ky.KitapId });
    //}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<KitapYazar>().HasKey(ky => new { ky.YazarId, ky.KitapId });

        modelBuilder.Entity<KitapYazar>()
            .HasOne(ky => ky.Kitap)
            .WithMany(k => k.Yazarlar)
            .HasForeignKey(ky => ky.KitapId);

        modelBuilder.Entity<KitapYazar>()
            .HasOne(ky => ky.Yazar)
            .WithMany(y => y.Kitaplar)
            .HasForeignKey(ky => ky.YazarId);

    }
}
#endregion