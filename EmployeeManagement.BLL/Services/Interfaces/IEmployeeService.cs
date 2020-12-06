using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeManagement.BLL.Models;

namespace EmployeeManagement.BLL.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task AddAsync(EmployeeModel model);
        Task<List<EmployeeModel>> GetAllAsync();
    }
}