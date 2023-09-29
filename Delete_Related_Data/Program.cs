using Microsoft.EntityFrameworkCore;
ApplicationDbContext context = new();
Console.WriteLine("Hello, World!");
#region 1-1
//Person? person = await context.Persons
//                      .Include(p => p.Address)
//                      .FirstOrDefaultAsync(p=>p.Id==1);
//if(person!=null)
//    context.Addresses.Remove(person.Address);
//await context.SaveChangesAsync();
#endregion
#region 1-n
//Blog? blog = await context.Blogs
//                   .Include(b => b.Posts)
//                   .FirstOrDefaultAsync(b => b.Id == 1);
//Post? post= blog.Posts.FirstOrDefault(p => p.Id == 2);
//blog.Posts.Remove(post);
//await context.SaveChangesAsync();
#endregion
#region n-n
//Author? author = await context.Authors.Include(a => a.Books).FirstOrDefaultAsync(a => a.Id == 2);
//Book? book=author.Books.FirstOrDefault(b => b.Id == 2);
//author.Books.Remove(book);
//await context.SaveChangesAsync();  
#endregion
#region Cascade Delete

#region Cascade
//Blog? blog = await context.Blogs.FindAsync(1);
//context.Blogs.Remove(blog); 
//await context.SaveChangesAsync();
#endregion
#region SetNull
//Blog? blog = await context.Blogs.FindAsync(2);
//context.Blogs.Remove(blog);
//await context.SaveChangesAsync();
#endregion

#endregion
#region Saving Data
//Person person = new()
//{
//    Name = "Hüseyin Çoraklı",
//    Address = new()
//    {
//        PersonAddress = "Dulkadiroğlu/Kahramanmaraş"
//    }
//};

//Person person2 = new()
//{
//    Name = "Hacı Ahmet Fedakar"
//};

//await context.AddAsync(person);
//await context.AddAsync(person2);

//Blog blog = new()
//{
//    Name = "Hacı Blog",
//    Posts = new List<Post>
//    {
//        new(){ Title = "1. Post" },
//        new(){ Title = "2. Post" },
//        new(){ Title = "3. Post" },
//    }
//};

//await context.Blogs.AddAsync(blog);

//Book book1 = new() { BookName = "1. Kitap" };
//Book book2 = new() { BookName = "2. Kitap" };
//Book book3 = new() { BookName = "3. Kitap" };

//Author author1 = new() { AuthorName = "1. Yazar" };
//Author author2 = new() { AuthorName = "2. Yazar" };
//Author author3 = new() { AuthorName = "3. Yazar" };

//book1.Authors.Add(author1);
//book1.Authors.Add(author2);

//book2.Authors.Add(author1);
//book2.Authors.Add(author2);
//book2.Authors.Add(author3);

//book3.Authors.Add(author3);

//await context.AddAsync(book1);
//await context.AddAsync(book2);
//await context.AddAsync(book3);
//await context.SaveChangesAsync();
#endregion

class Person
{
    public int Id { get; set; }
    public string Name { get; set; }

    public Address Address { get; set; }
}
class Address
{
    public int Id { get; set; }
    public string PersonAddress { get; set; }

    public Person Person { get; set; }
}
class Blog
{
    public Blog()
    {
        Posts = new HashSet<Post>();
    }
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<Post> Posts { get; set; }
}
class Post
{
    public int Id { get; set; }
    public int? BlogId { get; set; }
    public string Title { get; set; }

    public Blog Blog { get; set; }
}
class Book
{
    public Book()
    {
        Authors = new HashSet<Author>();
    }
    public int Id { get; set; }
    public string BookName { get; set; }

    public ICollection<Author> Authors { get; set; }
}
class Author
{
    public Author()
    {
        Books = new HashSet<Book>();
    }
    public int Id { get; set; }
    public string AuthorName { get; set; }

    public ICollection<Book> Books { get; set; }
}
class ApplicationDbContext : DbContext
{
    public DbSet<Person> Persons { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(LocalDb)\\HcSqlServer; Database=ExampleDatabase");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>()
            .HasOne(a => a.Person)
            .WithOne(p => p.Address)
            .HasForeignKey<Address>(a => a.Id)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Post>()
            .HasOne(b => b.Blog)
            .WithMany(x => x.Posts)
            .OnDelete(DeleteBehavior.SetNull)
            .IsRequired(false);
    }
}