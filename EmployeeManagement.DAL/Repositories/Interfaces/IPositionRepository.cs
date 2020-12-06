using System.Threading.Tasks;
using EmployeeManagement.DAL.Entities;

namespace EmployeeManagement.DAL.Repositories.Interfaces
{
    public interface IPositionRepository : IRepository<Position>
    {
        Task<Position> FindByNameAsync(string name);
    }
}