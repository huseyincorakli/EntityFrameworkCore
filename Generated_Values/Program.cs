using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Emit;

ApplicationDbContext context = new();

Person person = new Person()
{
	PersonId= 1,
	Name= "Test",
	Surname= "Test",
	TotalGain= 452,
	Salary=453,
	PersonCode=Guid.NewGuid(),
	Premium=123,
	
	
};

await context.Persons.AddAsync(person);
await context.SaveChangesAsync();
class Person
{
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int PersonId { get; set; }
	public string Name { get; set; }
	public string Surname { get; set; }
	public int Premium { get; set; }
	public int Salary { get; set; }
	[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
	public int? TotalGain { get; set; }
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public Guid PersonCode { get; set; }
	public int Deneme { get; set; }
}

class ApplicationDbContext : DbContext
{
	public DbSet<Person> Persons { get; set; }
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		#region HasDefaultValue & HasDefaultValueSql
		//modelBuilder.Entity<Person>()
		//	.Property(p => p.Salary)
		//	//.HasDefaultValue(100);
		//	.HasDefaultValueSql("FLOOR(RAND()*1000)");
		#endregion
		#region HasComputedColumn
		modelBuilder.Entity<Person>()
			.Property(p => p.TotalGain)
			.HasComputedColumnSql("([Salary]+[Premium]*10)");
		#endregion
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlServer("Server=(LocalDb)\\HcSqlServer; Database=ExampleDatabase");
	}
}