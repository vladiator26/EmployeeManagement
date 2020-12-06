using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeManagement.BLL.Models;
using EmployeeManagement.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [ApiController, Route("api/position")]
    public class PositionController : Controller
    {
        private readonly IPositionService _positionService;

        public PositionController(IPositionService positionService)
        {
            _positionService = positionService;
        }
        
        [HttpPost("Add")]
        public async Task AddAsync(PositionModel model)
        {
            await _positionService.AddAsync(model);
        }

        [HttpGet("GetAll")]
        public async Task<List<PositionModel>> GetAllAsync()
        {
            return await _positionService.GetAllAsync();
        }
    }
}