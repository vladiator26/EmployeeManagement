using System;

namespace EmployeeManagement.BLL.Models
{
    public class EmployeeModel : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long PositionId { get; set; }
        public double Salary { get; set; }
        public DateTime HiringDate { get; set; }
        public DateTime? DismissalDate { get; set; }
    }
}