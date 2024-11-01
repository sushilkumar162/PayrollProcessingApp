# Payroll Processing Application

This application reads payroll data from CSV files, processes the information, and generates a summary report for each department. It handles errors gracefully by logging them and continues processing other files.

## Setup

Clone this repository and ensure you have .NET SDK installed on your machine.

git clone https://github.com/sushilkumar162/PayrollProcessingApp.git cd PayrollProcessingApp


## Running the Application

Navigate to the `src` directory and run the application:

cd src dotnet run

The output will be written to the `data` directory as summary files for each department, and errors will be logged in `errors.log`.

## Contributing

Contributions are welcome. Please fork the repository and submit pull requests with your changes.
