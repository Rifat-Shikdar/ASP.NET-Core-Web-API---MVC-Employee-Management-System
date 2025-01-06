namespace EmployeeAPI.Models
{
    public class Register
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string ConfirmPassword { get; set; }
    }
}
