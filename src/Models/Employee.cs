/// <author>Sushil Kumar</author>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollProcessingApp.src.Models
{
    public class Employee
    {
        public required string EmployeeId { get; set; }
        public required string Name { get; set; }
        public decimal HoursWorked { get; set; }
        public decimal HourlyRate { get; set; }

        public decimal CalculatePay() => HoursWorked * HourlyRate;
    }
}
