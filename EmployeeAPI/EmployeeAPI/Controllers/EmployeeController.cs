using EmployeeAPI.Models;
using EmployeeAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeRepository _employeeRepo;

    public EmployeeController(IEmployeeRepository employeeRepo)
    {
        _employeeRepo = employeeRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var employees = await _employeeRepo.GetAllAsync();
        return Ok(employees);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEmployeeById(int id)
    {
        var employee = await _employeeRepo.GetByIdAsync(id);
        if (employee == null) return NotFound();
        return Ok(employee);
    }

    [HttpPost]
    public async Task<IActionResult> CreateEmployee([FromBody] Employee employee)
    {
        if (employee == null) return BadRequest();
        await _employeeRepo.AddAsync(employee);
        return Ok(new { message = "Employee created successfully", employee });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEmployee(int id, [FromBody] Employee employee)
    {
        if (employee == null || id != employee.EmployeeId) return BadRequest();
        await _employeeRepo.UpdateAsync(employee);
        return Ok(employee);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmployee(int id)
    {
        await _employeeRepo.DeleteAsync(id);
        return Ok();
    }
}