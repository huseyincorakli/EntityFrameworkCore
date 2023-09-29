using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
ApplicationDbContext context = new ApplicationDbContext();
Console.WriteLine();
#region 1-1
#region Saving
//Person person = new()
//{
//    Name = "Hüseyin Çoraklı",
//    Address = new() { PersonAddress = "Kahramanmaraş/Dulkadiroğlu" }
//};

//Person p2 = new()
//{
//    Name = "Hacı Ahmet Fedakar"
//};

//await context.AddRangeAsync(person, p2);
//await context.SaveChangesAsync();

#endregion
#region Dependent veriyi Principal veri üzerinden güncelleme
//Person? person = await context.Persons
//                .Include(p => p.Address)
//                .FirstOrDefaultAsync(p => p.Id == 1);
//if (person!=null)
//{
//    context.Remove(person.Address);
//    person.Address = new() { PersonAddress = "Yeni Adres" };
//    await context.SaveChangesAsync();
//}


#endregion
#region Dependent verinin bağımlı olduğu principal verisini değiştirme
//Address? address = await context.Addresses.FindAsync(3);
//context.Remove(address);
//await context.SaveChangesAsync();
//Person person = await context.Persons.FindAsync(4);
//person.Address = new() { PersonAddress = address.PersonAddress };
//await context.SaveChangesAsync();
#endregion

#endregion
#region 1-N
#region Saving
//Blog blog = new()
//{
//    Name = "Blog 1",
//    Posts = new List<Post>() 
//    {
//        new() {Title="Post-1" },
//        new() {Title="Post-2" },
//        new() {Title="Post-3" },
//    }
//};

//await context.Blogs.AddAsync(blog);
//await context.SaveChangesAsync();
#endregion
#region Dependent verileri Principal veri üzerinden güncelleme
#region x
//Blog? blog = await context.Blogs.Include(b => b.Posts).FirstOrDefaultAsync(b => b.Id == 1);
//if (blog!=null)
//{
//    int a = 1;
//    foreach (var post in blog.Posts)
//    {
//        post.Title = $"Yeni Post{a}";
//        a++;
//    }
//}
//await context.SaveChangesAsync();
#endregion

//Blog? blog = await context.Blogs.Include(b => b.Posts).FirstOrDefaultAsync(b => b.Id == 1);
//Post? silinecekPost = blog.Posts.FirstOrDefault(p=>p.Id == 2);
//blog.Posts.Remove(silinecekPost);


//blog.Posts.Add(new() { Title="Yeni Blog4"});
//blog.Posts.Add(new() { Title="Yeni Blog5"});
//await context.SaveChangesAsync();
#endregion
#region Dependent verilerin bağımlı olduğu principal verisini değiştirme
#region var olmayan
//Post? post4 = await context.Posts.FindAsync(4);
//post4.Blog = new()
//{
//    Name = "Blog 2"
//};
//await context.SaveChangesAsync();
#endregion
#region var olan
//Post? post5 = await context.Posts.FindAsync(5);
//Blog? blog2 = await context.Blogs.FindAsync(2);
//post5.Blog = blog2;
//await context.SaveChangesAsync();
#endregion
#endregion

#endregion
#region N-N
#region Saving
//Book b1 = new() { BookName = "BOOK 1" };
//Book b2 = new() { BookName = "BOOK 2" };
//Book b3 = new() { BookName = "BOOK 3" };

//Author a1 = new() { AuthorName = "AUTHOR 1" };
//Author a2 = new() { AuthorName = "AUTHOR 2" };
//Author a3 = new() { AuthorName = "AUTHOR 3" };

//b1.Authors.Add(a1);
//b1.Authors.Add(a2);

//b2.Authors.Add(a1);
//b2.Authors.Add(a2);
//b2.Authors.Add(a3);

//b3.Authors.Add(a3);

//await context.Books.AddRangeAsync(b1, b2, b3);
//await context.SaveChangesAsync();
#endregion
#region 1.Örnek
////1 idli kitaba 3 idli yazarıda ekleme
//Book? book = await context.Books.FindAsync(1);
//Author? author = await context.Authors.FindAsync(3);
//book.Authors.Add(author);
//await context.SaveChangesAsync();


#endregion
#region 2.Örnek
//3 idsine sahip  yazarın 1 idli kitap haricinde diğer kitaplarla ilişiği olmasın
//Author? author = await context.Authors.Include(a => a.Books).FirstOrDefaultAsync(a => a.Id == 3);
//foreach (var book in author.Books)
//{
//    if (book.Id!=1)
//    {
//        author.Books.Remove(book);
//    }
//}
//await context.SaveChangesAsync();
#endregion
#region 3.Örnek
// 2 idsine sahip olan kitabın yazarlarından idsi 2 olanı silip 4. Yazar adlı bir yazar ekle
//Book? book = await context.Books.Include(b => b.Authors).FirstOrDefaultAsync(b => b.Id == 2);
//Author? silinecekAuthor= book.Authors.FirstOrDefault(a => a.Id == 2);
//book.Authors.Remove(silinecekAuthor);
//book.Authors.Add(new() { AuthorName = "4.Yazar" });

//await context.SaveChangesAsync();


#endregion
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
    public int BlogId { get; set; }
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
            .HasForeignKey<Address>(a => a.Id);
    }
}