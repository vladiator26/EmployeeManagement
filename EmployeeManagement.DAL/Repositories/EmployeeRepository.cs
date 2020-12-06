using System.Threading.Tasks;
using EmployeeManagement.DAL.AppContext;
using EmployeeManagement.DAL.Entities;
using EmployeeManagement.DAL.Repositories.Base;
using EmployeeManagement.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.DAL.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<Employee> FindByFirstAndLastNameAsync(string firstName, string lastName)
        {
            return await DbSet.FirstOrDefaultAsync(item => item.FirstName == firstName && item.LastName == lastName);
        }
    }
}