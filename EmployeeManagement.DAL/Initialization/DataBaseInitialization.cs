using System;
using EmployeeManagement.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.DAL.Initialization
{
    public static class DataBaseInitialization
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            var positions = new[]
            {
                new Position { Id = 1, Name = "Junior Dev" },
                new Position { Id = 2, Name = "Middle Dev" },
                new Position { Id = 3, Name = "Senior Dev" }, 
            };

            var employees = new[]
            {
                new Employee { Id = 1, FirstName = "Денис", LastName = "Нещеретный", PositionId = 1 , Salary = 200, HiringDate = new DateTime(2020,4,26), DismissalDate = new DateTime(2020, 5, 1) }, 
                new Employee { Id = 2, FirstName = "Леонид", LastName = "Пшеничный", PositionId = 2, Salary = 500, HiringDate = new DateTime(2020, 2, 1), DismissalDate = null }, 
                new Employee { Id = 3, FirstName = "Денис", LastName = "Нещеретный", PositionId = 3, Salary = 1000, HiringDate = new DateTime(2020, 5, 1), DismissalDate = null }
            };

            modelBuilder.Entity<Position>().HasData(positions);
            modelBuilder.Entity<Employee>().HasData(employees);
        }
    }
}