using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeManagement.BLL.Mappers;
using EmployeeManagement.BLL.Models;
using EmployeeManagement.BLL.Services.Interfaces;
using EmployeeManagement.DAL.Entities;
using EmployeeManagement.DAL.Repositories.Interfaces;

namespace EmployeeManagement.BLL.Services
{
    public class PositionService : IPositionService
    {
        private readonly IPositionRepository _positionRepository;
        private readonly PositionMapper _positionMapper;

        public PositionService(IPositionRepository positionRepository, PositionMapper positionMapper)
        {
            _positionRepository = positionRepository;
            _positionMapper = positionMapper;
        }
        
        public async Task AddAsync(PositionModel model)
        {
            Position position = await _positionRepository.FindByNameAsync(model.Name);
            if (position == null)
            {
                position = _positionMapper.Map(model);
                await _positionRepository.AddAsync(position);
            }
        }

        public async Task<List<PositionModel>> GetAllAsync()
        {
            List<Position> positions = await _positionRepository.GetAllAsync();
            return _positionMapper.Map(positions);
        }
    }
}