using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePayroll.CLasses
{
    public class SalaryWorker : IWorker
    {
        public string FirstName { get; }
        public string LastName { get; }
        public double AnnualSalary { get; }
        double pay = 0;

        public SalaryWorker(double annualSalary, string firstName, string lastName)
        {
            AnnualSalary = annualSalary;
            FirstName = firstName;
            LastName = lastName;
        }

        public double CalculateWeeklyPay(int hoursWorked)
        {
            pay = AnnualSalary / 52;
            pay = Math.Round(pay, 2); 
            return pay;
        }

    }
}
