using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

ExampleDBContext context = new();


#region Shadow Property

//var data = await context.Blogs.Include(b => b.Posts).ToListAsync();

//Console.WriteLine();


#endregion
#region Shadow Property Erişim Sağlama

////Değere erişme
//Blog? blog=await context.Blogs.FindAsync(1);
//PropertyEntry createdDate= context.Entry(blog).Property("CreatedDate");
//Console.WriteLine(createdDate.CurrentValue);

////Değerini değiştirme
//createdDate.CurrentValue= DateTime.Now;
//await context.SaveChangesAsync();
//Console.WriteLine(createdDate.CurrentValue);
#endregion
#region EF.Property ile erişim
var blog = await context.Blogs.OrderBy(b => EF.Property<DateTime>(b, "CreatedDate")).ToListAsync();

Console.WriteLine();
#endregion

Console.WriteLine();
class Blog
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Post> Posts { get; set; }
}

class Post
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime LastUpdated { get; set; }
    public Blog Blog { get; set; }
}

class ExampleDBContext:DbContext
{
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(LocalDb)\\HcSqlServer; Database=ExampleDatabase");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blog>()
            .Property<DateTime>("CreatedDate");
    }
}