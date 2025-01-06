using System.Text.Json.Serialization;

namespace EmployeeAPI.Models
{
    public class Employee
    {
        public  int EmployeeId { get; set; }
        public string? Name { get; set; }
        public int? DepartmentId { get; set; }
        public int? DesignationId { get; set; }
        [JsonIgnore]
        public  Department? Department { get; set; }
        [JsonIgnore]
        public  Designation? Designation { get; set; }
    }

}
