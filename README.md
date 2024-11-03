
# PayrollProcessingApp

`PayrollProcessingApp` is a C# console application designed to process payroll data across multiple departments. It handles each department's payroll data stored in separate CSV files, validating the data, calculating payroll for each employee, and generating a summary report. It features asynchronous processing for handling multiple files concurrently and logs validation errors separately.

## Table of Contents
- [Features](#features)
- [Project Structure](#project-structure)
- [Prerequisites](#prerequisites)
- [Setup and Configuration](#setup-and-configuration)
- [Running the Application](#running-the-application)
- [Output Files](#output-files)
- [Running Tests](#running-tests)
- [Example Input and Output](#example-input-and-output)

## Features
- **Concurrent Processing:** Processes multiple department files asynchronously.
- **Data Validation:** Ensures each payroll entry has required fields and correct data types.
- **Payroll Calculation:** Calculates total payroll for each department and identifies the highest-paid employee.
- **Error Logging:** Logs validation errors to a dedicated error log file.
- **Configuration File:** Customizable paths for input files, reports, and error logs through `appsettings.json`.

## Project Structure
```
PayrollProcessingApp/
│
├── reports/
│   ├── Finance_report.txt            # Output report for the Finance department
│   └── HR_report.txt                 # Output report for HR department
│
├── src/
│   ├── ConsoleApp.cs                 # Main application entry point
│   ├── Common/
│   │   └── ServiceConstants.cs       # Constants used across the application
│   ├── Models/
│   │   └── Employee.cs               # Employee data model
│   ├── Services/
│   │   └── PayrollService.cs         # Service to process payroll data
│   └── Utils/
│       └── Logger.cs                 # Utility for logging errors
│
└── tests/
    └── PayrollServiceTests.cs        # Unit tests for payroll processing
```

## Prerequisites
- .NET SDK (version 5.0 or later)

## Setup and Configuration
Clone the repository and navigate to the application folder:
```bash
git clone https://github.com/sushilkumar162/PayrollProcessingApp.git
cd PayrollProcessingApp
```

## Running the Application
Execute the following command in the project directory to run the application:
```bash
dotnet run --project src/ConsoleApp.cs
```

## Output Files
- **PayrollReport.txt (in Reports directory):** Summary report for each department with total payroll and the highest-paid employee.
- **ErrorLog.txt (in ErrorLogs directory):** Logs validation errors encountered during processing.

## Running Tests
Navigate to the project root and run the tests:
```bash
dotnet test
```

## Example Input and Output
### Example Input (CSV Files in PayrollFiles Directory)
- **Finance.csv**
  ```
  EmployeeId,Name,HoursWorked,HourlyRate
  1001,Roma Jaiswal,40,25.50
  1002,Amit Bharti,35,30.00
  1003,Ritesh Kumar,45,20.00
  ```

- **HR.csv**
  ```
  EmployeeId,Name,HoursWorked,HourlyRate
  2001,Rakesh Pandey,40,28.00
  2002,Raghu Ram,38,32.50
  2003,Dinesh Kartik,41,26.00
  ```

### Example Output
- **Finance_Report.txt**
  ```
  Department: Finance
  Total Payroll: $2975.00
  Highest Paid Employee: John Doe ($1020.00)
  ```

- **HR_Report.txt**
  ```
  Department: HR
  Total Payroll: $2690.00
  Highest Paid Employee: Patricia Kim ($1008.00)
  ```

- **ErrorLog.txt (if any validation errors are encountered)**
  ```
  Error in Finance.csv: Invalid HoursWorked for Employee 1004 (not a valid decimal)
  ```
