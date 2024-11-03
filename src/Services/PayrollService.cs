/// <author>Sushil Kumar</author>
using PayrollProcessingApp.src.Common;
using PayrollProcessingApp.src.Models;
using PayrollProcessingApp.src.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollProcessingApp.src.Services
{
    public class PayrollService(string directoryPath)
    {
        private string DirectoryPath { get; } = directoryPath;

        public async Task ProcessPayrollsAsync()
        {
            var files = Directory.GetFiles(DirectoryPath, "*.csv");
            var tasks = files.Select(ProcessFileAsync).ToList();
            await Task.WhenAll(tasks);
        }

        private async Task ProcessFileAsync(string filePath)
        {
            var department = Path.GetFileNameWithoutExtension(filePath);
            var employees = new List<Employee>();

            var lines = await File.ReadAllLinesAsync(filePath);
            foreach (var line in lines.Skip(1))
            {
                try
                {
                    var parts = line.Split(',');
                    if (parts.Length != ServiceConstants.CSV_HEADER_NUM)
                    {
                        Logger.LogError($"{department}.csv", "Missing fields", $"Line: {line}");
                        continue;
                    }

                    var employee = new Employee
                    {
                        EmployeeId = parts[0],
                        Name = parts[1]
                    };

                    if (!decimal.TryParse(parts[2], NumberStyles.Any, CultureInfo.InvariantCulture, out decimal hoursWorked))
                    {
                        Logger.LogError($"{department}.csv", "Invalid HoursWorked", $"Employee {employee.EmployeeId} ({parts[2]} is not a valid decimal)");
                        continue;
                    }

                    if (!decimal.TryParse(parts[3], NumberStyles.Any, CultureInfo.InvariantCulture, out decimal hourlyRate))
                    {
                        Logger.LogError($"{department}.csv", "Invalid HourlyRate", $"Employee {employee.EmployeeId} ({parts[3]} is not a valid decimal)");
                        continue;
                    }

                    employee.HoursWorked = hoursWorked;
                    employee.HourlyRate = hourlyRate;

                    employees.Add(employee);
                }
                catch (Exception ex)
                {
                    Logger.LogError($"Error in {department}.csv: {ex.Message}");
                }
            }

            if (employees.Count != 0)
            {
                var totalPayroll = employees.Sum(emp => emp.CalculatePay());
                var highestPaid = employees.OrderByDescending(emp => emp.CalculatePay()).First();

                var report = $"Department: {department}\n" +
                             $"Total Payroll: ${totalPayroll:F2}\n" +
                             $"Highest Paid Employee: {highestPaid.Name} (${highestPaid.CalculatePay():F2})";

                var reportFilePath = Path.Combine(ServiceConstants.REPORT_PATH, $"{department}_report.txt");
                await File.WriteAllTextAsync(reportFilePath, report);
            }
        }
    }
}
