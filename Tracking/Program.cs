using Microsoft.EntityFrameworkCore;
ETicaretContext context = new();


#region AsNoTracking

//var persons = await context.Kullanicilar.AsNoTracking().ToListAsync();

//foreach (var person in persons)
//{
//    Console.WriteLine(person.Adi);
//    person.Adi = $"AsNoTracking Kullanıcı-{person.Adi}";
//    context.Kullanicilar.Update(person);
//}
//await context.SaveChangesAsync();
#endregion
#region AsNoTrackingWithIdentityResolution
//var books = await context.Kullanicilar.Include(k => k.Roller).ToListAsync();
//var books = await context.Kullanicilar.Include(k => k.Roller).AsNoTracking().ToListAsync();
//var books = await context.Kullanicilar.Include(k => k.Roller).AsNoTrackingWithIdentityResolution().ToListAsync();

#endregion


#region Context-Entity


public class ETicaretContext : DbContext
{
    #region Dbsets
    public DbSet<Kullanici> Kullanicilar { get; set; }
    public DbSet<Rol> Roller { get; set; }
    public DbSet<Kitap> Kitaplar { get; set; }
    public DbSet<Yazar> Yazarlar { get; set; }
    #endregion
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(LocalDb)\\HcSqlServer; Database=ExampleDatabase");
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

    }
}
public class Kullanici
{
    public Kullanici()
    {
        Console.WriteLine("Kullanıcı oluşturuldu");
    }
    public int Id { get; set; }
    public string Adi { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public ICollection<Rol> Roller { get; set; }
}
public class Rol
{
    public Rol()
    {
        Console.WriteLine("Rol oluşturuldu");
    }
    public int Id { get; set; }
    public string RolAdi { get; set; }
    public ICollection<Kullanici> Kullanicilar { get; set; }
}
public class Kitap
{
    public Kitap() => Console.WriteLine("Kitap nesnesi oluşturuldu.");
    public int Id { get; set; }
    public string KitapAdi { get; set; }
    public int SayfaSayisi { get; set; }

    public ICollection<Yazar> Yazarlar { get; set; }
}
public class Yazar
{
    public Yazar() => Console.WriteLine("Yazar nesnesi oluşturuldu.");
    public int Id { get; set; }
    public string YazarAdi { get; set; }

    public ICollection<Kitap> Kitaplar { get; set; }
}
#endregion