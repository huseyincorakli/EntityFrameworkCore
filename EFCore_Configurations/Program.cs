using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
ApplicationDbContext context = new();
Console.WriteLine("Hello, World!");

class Personn
{
	public int Id { get; set; }
	public int Id2 { get; set; }
	public string Name { get; set; }

	[ConcurrencyCheck]
	public int ConcurrencyToken { get; set; }

}

class Person
{
	public int PrimaryKeyOlsun { get; set; }
	//[NotMapped]
	//public int KolonOlmasın { get; set; }
	//[Key]
	public int Id { get; set; }

	//[ForeignKey(nameof(Department))]
	//public int DId { get; set; }
	//[Column("Adi", TypeName = "metin", Order = 7)]
	public int DepartmentId { get; set; }
	public string _name;
	public string Name { get => _name; set => _name = value; }
	//[Required()]
	//[MaxLength(13)]
	//[StringLength(14)]
	[Unicode]
	public string? Surname { get; set; }
	//[Precision(5, 3)]
	public decimal Salary { get; set; }
	//Yazılımsal amaçla oluşturduğum bir property
	//[NotMapped]
	//public string Laylaylom { get; set; }

	[Timestamp]
	public byte[] RowVersion { get; set; }

	//[ConcurrencyCheck]
	//public int ConcurrencyCheck { get; set; }

	public DateTime CreatedDate { get; set; }
	public Department Department { get; set; }
}
class Department
{
	public int Id { get; set; }
	//[Column("DepartmentName", TypeName = "text", Order = 7)]
	public string Name { get; set; }
	public ICollection<Person> Persons { get; set; }
}
class Example
{
	public int Id { get; set; }
	public int X { get; set; }
	public int Y { get; set; }
	public int Computed { get; set; }
}
class Entity
{
	public int Id { get; set; }
	public string X { get; set; }
}
class A : Entity
{
	public int Y { get; set; }
}
class B : Entity
{
	public int Z { get; set; }
}
class ApplicationDbContext : DbContext
{
	//public DbSet<Entity> Entities { get; set; }
	//public DbSet<A> As { get; set; }
	//public DbSet<B> Bs { get; set; }

	public DbSet<Person> Persons { get; set; }
	public DbSet<Department> Departments { get; set; }
	//public DbSet<Flight> Flights { get; set; }
	//public DbSet<Airport> Airports { get; set; }
	//public DbSet<Example> Examples { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		#region GetEntityTypes
		//var entities = modelBuilder.Model.GetEntityTypes();
		//foreach (var entity in entities)
		//{
		//	Console.WriteLine(entity.Name);
		//}
		#endregion
		#region ToTable
		//modelBuilder.Entity<Person>().ToTable("Kisiler");
		#endregion
		#region Column

		//modelBuilder.Entity<Department>()
		//	.Property(p => p.Name)
		//	.HasColumnName("DepartmentName")
		//	.HasColumnType("text")
		//	.HasColumnOrder(7);

		#endregion
		#region HasForeingKey
		//modelBuilder.Entity<Person>()
		//	.HasOne(p => p.Department)
		//	.WithMany(d => d.Persons)
		//	.HasForeignKey(p => p.DId);
		#endregion
		#region Ignore
		//modelBuilder.Entity<Person>().Ignore(p=>p.KolonOlmasın);
		#endregion
		#region HasKey
		//modelBuilder.Entity<Person>().HasKey(p => p.PrimaryKeyOlsun);
		#endregion
		#region IsRowVersion

		//modelBuilder.Entity<Person>()
		//	.Property(p => p.RowVersion)
		//	.IsRowVersion();

		#endregion
		#region IsRequired
		//modelBuilder.Entity<Person>().Property(p => p.Surname).IsRequired();
		#endregion
		#region HasMaxLenght
		//modelBuilder.Entity<Person>()
		//	.Property(p => p.Surname)
		//	.HasMaxLength(30);
		#endregion
		#region HasPrecision
		//modelBuilder.Entity<Person>()
		//	.Property(p => p.Salary)
		//	.HasPrecision(5, 3);
		#endregion
		#region IsUnicode
		//modelBuilder.Entity<Person>().Property(p => p.Surname).IsUnicode();
		#endregion
		#region HasComment
		//modelBuilder.Entity<Personn>()
		//	.Property(p => p.X)
		//	.HasComment("Bu kolon X kolonudur");
		#endregion
		#region IsConcurrencyToken
		//modelBuilder.Entity<Personn>()
		//	.Property(p => p.ConcurrencyToken)
		//	.IsConcurrencyToken();
		#endregion
		#region CompositeKey
		//modelBuilder.Entity<Personn>().HasKey(p => new{ p.Id, p.Id2 });
		#endregion
		#region HasDefaultSchema
		//modelBuilder.HasDefaultSchema("DBOX");
		#endregion
		#region HasDefaultValue
		//modelBuilder.Entity<Personn>()
		//	.Property(p => p.Name)
		//	.HasDefaultValue("Person Name");
		#endregion
		#region HasDefaultValueSql
		//modelBuilder.Entity<Personn>()
		//	.Property(p => p.Name)
		//	.HasDefaultValueSql("GETDATE()");
		#endregion
		#region HasComputedColumnSql
		//modelBuilder.Entity<Example>()
		//	.Property(e => e.Computed)
		//	.HasComputedColumnSql("[X]+[Y]");
		#endregion
		#region HasData
		//modelBuilder.Entity<Department>()
		//	.HasData(new Department() { Id = 1, Name = "Abc" });
		//modelBuilder.Entity<Person>()
		//	.HasData(
		//	new Person { 
		//		Id = 1,
		//		Name = "AAA",
		//		DepartmentId = 1,
		//		Surname = "BBB" },
		//	new Person { 
		//		Id = 2,
		//		Name = "BBB", 
		//		DepartmentId = 1, 
		//		Surname = "BBB" }
		//	);
		#endregion
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlServer("Server=(LocalDb)\\HcSqlServer; Database=ExampleDatabase");
	}
}

public class Flight
{
	public int FlightID { get; set; }
	public int DepartureAirportId { get; set; }
	public int ArrivalAirportId { get; set; }
	public string Name { get; set; }
	public Airport DepartureAirport { get; set; }
	public Airport ArrivalAirport { get; set; }
}

public class Airport
{
	public int AirportID { get; set; }
	public string Name { get; set; }
	[InverseProperty(nameof(Flight.DepartureAirport))]
	public virtual ICollection<Flight> DepartingFlights { get; set; }

	[InverseProperty(nameof(Flight.ArrivalAirport))]
	public virtual ICollection<Flight> ArrivingFlights { get; set; }
}