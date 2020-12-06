using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeManagement.BLL.Mappers;
using EmployeeManagement.BLL.Models;
using EmployeeManagement.BLL.Services.Interfaces;
using EmployeeManagement.DAL.Entities;
using EmployeeManagement.DAL.Repositories.Interfaces;

namespace EmployeeManagement.BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly EmployeeMapper _employeeMapper;

        public EmployeeService(IEmployeeRepository employeeRepository, EmployeeMapper employeeMapper)
        {
            _employeeRepository = employeeRepository;
            _employeeMapper = employeeMapper;
        }
        
        public async Task AddAsync(EmployeeModel model)
        {
            Employee employee = await _employeeRepository.FindByFirstAndLastNameAsync(model.FirstName, model.LastName);
            if (employee != null)
            {
                employee.DismissalDate = DateTime.UtcNow;
                await _employeeRepository.UpdateAsync(employee);
            }
            employee = _employeeMapper.Map(model);
            await _employeeRepository.AddAsync(employee);
        }

        public async Task<List<EmployeeModel>> GetAllAsync()
        {
            List<Employee> employees = await _employeeRepository.GetAllAsync();
            return _employeeMapper.Map(employees);
        }
    }
}