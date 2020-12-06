using System;

namespace EmployeeManagement.DAL.Entities
{
    public class Employee : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long PositionId { get; set; }
        public Position Position { get; set; }
        public double Salary { get; set; }
        public DateTime HiringDate { get; set; }
        public DateTime? DismissalDate { get; set; }
    }
}