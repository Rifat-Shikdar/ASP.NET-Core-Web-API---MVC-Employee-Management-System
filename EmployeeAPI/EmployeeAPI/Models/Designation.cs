namespace EmployeeAPI.Models
{
    public class Designation
    {
        public  int DesignationId { get; set; }
        public string? Name { get; set; }
        public required List<Employee> Employees { get; set; }
    }

}
