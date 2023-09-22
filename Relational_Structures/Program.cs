
class Employee
{
    public int Id { get; set; }
    public string EmployeeName { get; set; }
    public int DepartmantId { get; set; }
    public Departmant Departmant { get; set; }
}
class Departmant
{
    public int Id { get; set; }
    public string DepartmantName { get; set; }
    public ICollection<Employee> Employees { get; set; }
}