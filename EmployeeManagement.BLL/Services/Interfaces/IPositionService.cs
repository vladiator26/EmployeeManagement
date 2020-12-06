using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeManagement.BLL.Models;

namespace EmployeeManagement.BLL.Services.Interfaces
{
    public interface IPositionService
    {
        Task AddAsync(PositionModel model);
        Task<List<PositionModel>> GetAllAsync();
    }
}