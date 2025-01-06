namespace EmployeeAPI.Models
{
    public class Department
    {
        public  int DepartmentId { get; set; }
        public string? Name { get; set; }
        public required List<Employee> Employees { get; set; }
    }

}
