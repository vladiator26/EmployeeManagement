using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeManagement.BLL.Models;
using EmployeeManagement.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [ApiController, Route("api/employee")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        
        [HttpPost("Add")]
        public async Task AddAsync(EmployeeModel employeeModel)
        {
            await _employeeService.AddAsync(employeeModel);
        }

        [HttpGet("GetAll")]
        public async Task<List<EmployeeModel>> GetAllAsync()
        {
            return await _employeeService.GetAllAsync();
        }
    }
}