/// <author>Sushil Kumar</author>
using PayrollProcessingApp.src.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollProcessingApp.src.Utils
{
    public static class Logger
    {
        private static readonly string logFilePath = ServiceConstants.ERROR_LOG_FILE_PATH;

        public static void LogError(string message)
        {
            File.AppendAllText(logFilePath, $"{DateTime.Now}: {message}\n");
        }

        public static void LogError(string fileName, string errorType, string details)
        {
            var message = $"Error in {fileName}: {errorType} for {details}";
            File.AppendAllText(logFilePath, message + Environment.NewLine);
        }
    }
}
