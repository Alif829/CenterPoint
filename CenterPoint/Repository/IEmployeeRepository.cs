using CenterPoint.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CenterPoint.Repository
{
    public interface IEmployeeRepository
    {
        Employee Find(int id);
        List<Employee> GetAll();
        List<Employee> Get(String name);
        Employee Add(Employee employee);
        Employee Update(Employee employee);
        void Delete(int id);
    }
}
