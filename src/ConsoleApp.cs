/// <author>Sushil Kumar</author>
using Microsoft.Extensions.Configuration;
using PayrollProcessingApp.src.Common;
using PayrollProcessingApp.src.Services;
using System;
using System.IO;
using System.Threading.Tasks;

class ConsoleApp
{   
    static async Task Main(string[] args)
    {
        try
        {
            var payrollService = new PayrollService(ServiceConstants.DATA_PATH);
            await payrollService.ProcessPayrollsAsync();


            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            Console.WriteLine($"Base Directory: {basePath}");
            int binIndex = basePath.IndexOf("\\bin", StringComparison.OrdinalIgnoreCase);
            
            if (binIndex >= 0)
            {
                string newPath = basePath.Substring(0, binIndex);
                Console.WriteLine("Modified Path: " + newPath);
                
            }

            
            Console.WriteLine("Payroll processing completed. Please check output under reports and logs directory.");

        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }
    }
}

