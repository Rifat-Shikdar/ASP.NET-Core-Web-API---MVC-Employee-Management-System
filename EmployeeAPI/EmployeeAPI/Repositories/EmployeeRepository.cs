using Dapper;
using EmployeeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            using (var connection = _context.Database.GetDbConnection())
            {
                var sql = "SELECT * FROM Employees";
                return (await connection.QueryAsync<Employee>(sql)).AsList();
            }
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            using (var connection = _context.Database.GetDbConnection())
            {
                var sql = "SELECT * FROM Employees WHERE EmployeeId = @Id";
                return await connection.QueryFirstOrDefaultAsync<Employee>(sql, new { Id = id });
            }
        }

        public async Task AddAsync(Employee employee)
        {
            using (var connection = _context.Database.GetDbConnection())
            {
                var sql = "INSERT INTO Employees (Name, DepartmentId, DesignationId) VALUES (@Name, @DepartmentId, @DesignationId)";
                await connection.ExecuteAsync(sql, employee);
            }
        }

        public async Task UpdateAsync(Employee employee)
        {
            using (var connection = _context.Database.GetDbConnection())
            {
                var sql = "UPDATE Employees SET Name = @Name, DepartmentId = @DepartmentId, DesignationId = @DesignationId WHERE EmployeeId = @EmployeeId";
                await connection.ExecuteAsync(sql, employee);
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = _context.Database.GetDbConnection())
            {
                var sql = "DELETE FROM Employees WHERE EmployeeId = @Id";
                await connection.ExecuteAsync(sql, new { Id = id });
            }
        }
    }
}