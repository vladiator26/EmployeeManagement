using EmployeeManagement.BLL.Mappers.Base;
using EmployeeManagement.BLL.Models;
using EmployeeManagement.DAL.Entities;

namespace EmployeeManagement.BLL.Mappers
{
    public class PositionMapper : BaseMapper<PositionModel, Position>
    {
        public override PositionModel Map(Position item)
        {
            return new PositionModel
            {
                Id = item.Id,
                Name = item.Name
            };
        }

        public override Position Map(PositionModel item)
        {
            return new Position
            {
                Id = item.Id,
                Name = item.Name
            };
        }
    }
}