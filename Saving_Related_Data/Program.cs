using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
ExampleDbContext context = new();

Console.WriteLine("Hello, World!");

#region ONE TO ONE
#region principal üzerinden dependent ekleme
//Person person = new();
//person.Name = "Hüseyin Çoraklı";
//person.Address = new() { PersonAddress = "Kahramanmaraş/Dulkadiroğlu" };
//await context.People.AddAsync(person);
//await context.SaveChangesAsync();
#endregion
#region dependent üzerinden principal ekleme
//Address address = new();
//address.PersonAddress = "Kahramanmaraş/Pazarcık";
//address.Person = new()
//{
//    Name = "Mustafa Arı"
//};
//await context.Addresses.AddAsync(address);
//await context.SaveChangesAsync();
#endregion
//class Person
//{
//    public int Id { get; set; }
//    public string Name { get; set; }
//    public Address Address { get; set; }

//}
//class Address
//{
//    public int Id { get; set; }
//    public string PersonAddress { get; set; }
//    public Person Person { get; set; }

//}
//class ExampleDbContext:DbContext
//{
//    public DbSet<Person> People { get; set; }
//    public DbSet<Address> Addresses { get; set; }
//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//    {
//        optionsBuilder.UseSqlServer("Server=(LocalDb)\\HcSqlServer; Database=ExampleDatabase");
//    }
//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        modelBuilder.Entity<Address>()
//            .HasOne(a => a.Person)
//            .WithOne(p => p.Address)
//            .HasForeignKey<Address>(a => a.Id);
//    }

//}
#endregion
#region ONE TO MANY
#region principal üzerinden dependent ekleme
#region nesne referansı üzerinden ekleme
//Blog blog = new();
//blog.Name = "Hacının Blogu";
//blog.Posts.Add(new() { Title = "İttihad ve Terakki" });
//blog.Posts.Add(new() { Title = "Cemal Paşa Kimdir?" });
//blog.Posts.Add(new() { Title = "Enver Paşa Kimdir?" });
////bu yöntem için blog constructor da Post koleksiyonel yapıda newlenmeli
//await context.Blogs.AddAsync(blog);
//await context.SaveChangesAsync();
#endregion
#region object initialzer üzerinden ekleme

//Blog blog2 = new()
//{
//    Name = "Mustafanın Blogu",
//    Posts = new HashSet<Post>() { new() { Title="Bitcoin Nedir?"},new() { Title= "Order Block Nedir?" } }
//};
//await context.AddAsync(blog2);
//await context.SaveChangesAsync();
//Console.WriteLine("Veriler eklendi!");

#endregion

#endregion
#region dependent üzerinden principal ekleme
//Post post = new()
//{
//    Title = "Nihilizm Nedir?",
//    Blog = new() { Name="Çağatayın Blogu"}
//};
//await context.Posts.AddAsync(post);
//await context.SaveChangesAsync();
#endregion
#region Foreign key üzerinden  ekleme
//Post post = new();
//post.Title = "Roger Penrose Kimdir?";
//post.BlogId = 3;
//await context.Posts.AddAsync(post);
//await context.SaveChangesAsync();
#endregion
//class Blog
//{
//    public Blog()
//    {
//        Posts = new HashSet<Post>();
//    }
//    public int Id { get; set; }
//    public string Name { get; set; }
//    public ICollection<Post> Posts { get; set; }
//}
//class Post
//{
//    public int Id { get; set; }
//    public int BlogId { get; set; }
//    public string Title { get; set; }
//    public Blog Blog { get; set; }
//}
//class ExampleDbContext : DbContext
//{
//    public DbSet<Blog> Blogs { get; set; }
//    public DbSet<Post> Posts { get; set; }
//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//    {
//        optionsBuilder.UseSqlServer("Server=(LocalDb)\\HcSqlServer; Database=ExampleDatabase");
//    }
//}
#endregion
#region MANY TO MANY
#region Fluent API

Author author = new()
{
    AuthorName = "Alper Karataş",
    Books = new HashSet<BookAuthor>()
    {
        new(){BookId=3},
        new(){Book=new(){BookName="Uşak Nerededir?"}}
    }
};
await context.AddAsync(author);
await context.SaveChangesAsync();

class Book
{
    public Book()
    {
        Authors = new HashSet<BookAuthor>();
    }
    public int Id { get; set; }
    public string BookName { get; set; }
    public ICollection<BookAuthor> Authors { get; set; }
}
class BookAuthor
{
    public int BookId { get; set; }
    public int AuthorId { get; set; }
    public Book Book { get; set; }
    public Author Author { get; set; }
}
class Author
{
    public Author()
    {
        Books = new HashSet<BookAuthor>();
    }
    public int Id { get; set; }
    public string AuthorName { get; set; }
    public ICollection<BookAuthor> Books { get; set; }

}

class ExampleDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(LocalDb)\\HcSqlServer; Database=ExampleDatabase");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookAuthor>()
            .HasKey(ba => new { ba.AuthorId, ba.BookId });

        modelBuilder.Entity<BookAuthor>()
            .HasOne(b => b.Book)
            .WithMany(b => b.Authors)
            .HasForeignKey(b => b.BookId);

        modelBuilder.Entity<BookAuthor>()
            .HasOne(a => a.Author)
            .WithMany(a => a.Books)
            .HasForeignKey(a => a.AuthorId);
    }

}
#endregion
#region Default Convention

//Book book = new();
//book.BookName = "Beyaz Geceler";
//book.Authors.Add(new() { AuthorName="Hacı" });
//book.Authors.Add(new() { AuthorName="Mustafa" });
//book.Authors.Add(new() { AuthorName="Çağatay" });

//await context.Books.AddAsync(book);
//await context.SaveChangesAsync();
//class Book
//{
//    public Book()
//    {
//        Authors=new HashSet<Author>();
//    }
//    public int Id { get; set; }
//    public string BookName { get; set; }
//    public ICollection<Author> Authors { get; set; }
//}
//class Author
//{
//    public Author()
//    {
//        Books=new HashSet<Book>();
//    }
//    public int Id { get; set; }
//    public string AuthorName { get; set; }
//    public ICollection<Book> Books { get; set; }

//}

//class ExampleDbContext : DbContext
//{
//    public DbSet<Book> Books { get; set; }
//    public DbSet<Author> Authors { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//    {
//        optionsBuilder.UseSqlServer("Server=(LocalDb)\\HcSqlServer; Database=ExampleDatabase");
//    }

//}
#endregion
#endregion