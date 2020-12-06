using EmployeeManagement.BLL.Mappers.Base;
using EmployeeManagement.BLL.Models;
using EmployeeManagement.DAL.Entities;

namespace EmployeeManagement.BLL.Mappers
{
    public class EmployeeMapper : BaseMapper<EmployeeModel, Employee>
    {
        public override EmployeeModel Map(Employee item)
        {
            return new EmployeeModel
            {
                Id = item.Id,
                FirstName = item.FirstName,
                LastName = item.LastName,
                Salary = item.Salary,
                PositionId = item.PositionId,
                HiringDate = item.HiringDate,
                DismissalDate = item.DismissalDate
            };
        }

        public override Employee Map(EmployeeModel item)
        {
            return new Employee
            {
                Id = item.Id,
                FirstName = item.FirstName,
                LastName = item.LastName,
                Salary = item.Salary,
                PositionId = item.PositionId,
                HiringDate = item.HiringDate,
                DismissalDate = item.DismissalDate
            };
        }
    }
}