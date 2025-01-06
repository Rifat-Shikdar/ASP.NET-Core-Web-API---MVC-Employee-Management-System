using System.ComponentModel.DataAnnotations;

namespace EmployeeMVC.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public  string? Name { get; set; } 

        [Required(ErrorMessage = "Department ID is required.")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Designation ID is required.")]
        public int DesignationId { get; set; }
        
        public  Department? Department { get; set; }
       
        public  Designation? Designation { get; set; }
    }
}

// Add properties to hold the department and designation names
//public string? DepartmentName { get; set; }
//public string? DesignationName { get; set; }