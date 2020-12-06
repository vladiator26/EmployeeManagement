using System.Threading.Tasks;
using EmployeeManagement.DAL.Entities;

namespace EmployeeManagement.DAL.Repositories.Interfaces
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<Employee> FindByFirstAndLastNameAsync(string firstName, string lastName);
    }
}