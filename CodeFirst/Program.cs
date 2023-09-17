
using Microsoft.EntityFrameworkCore;

ExampleDbContext context = new ExampleDbContext();
await context.Database.MigrateAsync();

public class ExampleDbContext : DbContext
{
    public DbSet<ExampleEntity> ExampleEntities { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(LocalDb)\\HcSqlServer; Database=ExampleDatabase");
    }
}


public class ExampleEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int MyProperty { get; set; }

}

