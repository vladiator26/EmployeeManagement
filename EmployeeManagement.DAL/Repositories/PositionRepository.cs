using System.Threading.Tasks;
using EmployeeManagement.DAL.AppContext;
using EmployeeManagement.DAL.Entities;
using EmployeeManagement.DAL.Repositories.Base;
using EmployeeManagement.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.DAL.Repositories
{
    public class PositionRepository : BaseRepository<Position>, IPositionRepository
    {
        public PositionRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<Position> FindByNameAsync(string name)
        {
            return await DbSet.FirstOrDefaultAsync(item => item.Name == name);
        }
    }
}