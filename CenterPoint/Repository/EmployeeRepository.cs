using CenterPoint.Models;
using Microsoft.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Data;
using Dapper;

namespace CenterPoint.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private IDbConnection db;

        public EmployeeRepository(IConfiguration configuration)
        {
            this.db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }
        public Employee Add(Employee employee)
        {
            var sql = "INSERT INTO Employees (Name,Age,Gender,DateOfBirth) VALUES(@Name,@Age,@Gender,@DateOfBirth);" +
                "SELECT CAST(SCOPE_IDENTITY() as int); ";
           
            int id = db.Query<int>(sql, employee).Single();
            employee.ID = id;
            return employee;
        }

        public void Delete(int id)
        {
            var sql = "DELETE FROM Employees WHERE ID=@Id";
            db.Execute(sql, new { id });
        }

        public Employee Find(int id)
        {
            var sql = "SELECT * FROM Employees WHERE ID=@ID";
            return db.Query<Employee>(sql, new { @ID = id }).Single();

        }

        public List<Employee> Get(string name)
        {
            var sql = "SELECT * FROM Employees WHERE Name IN (@Name)";
            
            return db.Query<Employee>(sql, new { @Name = name }).ToList();
        }

        public List<Employee> GetAll()
        {
            var sql = "SELECT * FROM Employees";
            return db.Query<Employee>(sql).ToList();
        }

        public Employee Update(Employee employee)
        {
            var sql = "UPDATE Employees SET Name=@Name,Age=@Age,Gender=@Gender,DateOfBirth=@DateOfBirth " +
                "WHERE ID=@ID";
            db.Execute(sql, employee);
            return employee;
        }

    }
}
