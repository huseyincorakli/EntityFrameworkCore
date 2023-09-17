
using Microsoft.EntityFrameworkCore;


Urun urun = new()
{
    UrunAdi = "A urunu",
    Fiyat = 1000,
    Adet = 10
};
ETicaretContext _context = new();
_context.Urunler.AddAsync(urun);
public class Urun
{
    public int Id { get; set; }
    public  string UrunAdi { get; set; }
    public float Fiyat { get; set; }
    public int Adet { get; set; }
}

public class ETicaretContext : DbContext
{
    public DbSet<Urun> Urunler { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("server=DESKTOP-A0FLVHH\\SQLEXPRESS ; Database=Ticaret1 ;Integrated Security = true; Encrypt=False; TrustServerCertificate=True");
    }
}


