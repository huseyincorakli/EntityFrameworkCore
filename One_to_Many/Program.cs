using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

Console.WriteLine("Hello, World!");
#region Default Convention
//public class Calisan
//{
//    public int Id { get; set; }
//    public string Adi { get; set; }
//    public Departman Departman { get; set; }
//}

//public class Departman
//{
//    public int Id { get; set; }
//    public string DepartmanAdi { get; set; }
//    public ICollection<Calisan> Calisanlar { get; set; }
//} 
#endregion
#region Data Annotations
//public class Calisan
//{
//    public int Id { get; set; }
//    [ForeignKey(nameof(Departman))]
//    public int DId { get; set; }
//    public string Adi { get; set; }
//    public Departman Departman { get; set; }
//}

//public class Departman
//{
//    public int Id { get; set; }

//    public string DepartmanAdi { get; set; }
//    public ICollection<Calisan> Calisanlar { get; set; }
//}
#endregion
#region Fluent API
public class Calisan
{
    public int Id { get; set; }
    public int DId { get; set; }
    public string Adi { get; set; }
    public Departman Departman { get; set; }
}

public class Departman
{
    public int Id { get; set; }

    public string DepartmanAdi { get; set; }
    public ICollection<Calisan> Calisanlar { get; set; }
}

#endregion

public class ExampleDBContext : DbContext
{
    public DbSet<Calisan> Calisanlar { get; set; }
    public DbSet<Departman> Departmanlar { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(LocalDb)\\HcSqlServer; Database=ExampleDatabase");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Departman>()
            .HasMany(a => a.Calisanlar)
            .WithOne(a => a.Departman)
            .HasForeignKey (a=>a.DId);
    }
}