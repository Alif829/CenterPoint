using CenterPoint.Data;
using CenterPoint.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CenterPoint.Repository
{
    public class EmployeeRepositoryEF: IEmployeeRepository
    {
        private readonly ApplicationDbContext _db;

        public EmployeeRepositoryEF(ApplicationDbContext db)
        {
            _db = db;
        }
        public Employee Add(Employee employee)
        {
            _db.Employees.Add(employee);
            _db.SaveChanges();
            return employee;
        }

        public void Delete(int id)
        {
            Employee employee = _db.Employees.Find(id);
            //employee.IsDeleted=true;
            _db.Employees.Remove(employee);
            _db.SaveChanges();
            return;
        }

        public Employee Find(int id)
        {
            return _db.Employees.Find(id);
        }

        public List<Employee> Get(string name)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAll()
        {
            return _db.Employees.ToList();
        }


        public Employee Update(Employee employee)
        {
            _db.Employees.Update(employee);
            _db.SaveChanges();
            return employee;
        }
    }
}
