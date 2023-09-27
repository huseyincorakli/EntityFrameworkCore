using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

ECommerceDbContext context = new();
#region Default Convention

//public class Calisan
//{
//    public int Id { get; set; }
//    public string Adi { get; set; }
//    public CalisanAdres CalisanAdres { get; set; }
//}

//public class CalisanAdres
//{
//    public int Id { get; set; }
//    public int CalisanId { get; set; }
//    public string Adres { get; set; }
//    public Calisan Calisan { get; set; }

//}
#endregion

#region Data Annotations
//public class Calisan
//{
//    public int Id { get; set; }
//    public string Adi { get; set; }
//    public CalisanAdres CalisanAdres { get; set; }
//}

//public class CalisanAdres
//{
//    [Key, ForeignKey(nameof(Calisan))]
//    public int Id { get; set; }
//    public string Adres { get; set; }
//    public Calisan Calisan { get; set; }

//}
#endregion

#region Fluent API
public class Calisan
{
    public int Id { get; set; }
    public string Adi { get; set; }
    public CalisanAdres CalisanAdres { get; set; }
}

public class CalisanAdres
{

    public int Id { get; set; }
    public string Adres { get; set; }
    public Calisan Calisan { get; set; }

}
#endregion

#region Context
public class ECommerceDbContext : DbContext
{
    public DbSet<Calisan> Calisanlar { get; set; }
    public DbSet<CalisanAdres> CalisanAdresleri { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(LocalDb)\\HcSqlServer; Database=ExampleDatabase");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CalisanAdres>().HasKey(ca => ca.Id);

        modelBuilder.Entity<Calisan>()
            .HasOne(c => c.CalisanAdres)
            .WithOne(c => c.Calisan)
            .HasForeignKey<CalisanAdres>(ca => ca.Id);
    }

}
#endregion
