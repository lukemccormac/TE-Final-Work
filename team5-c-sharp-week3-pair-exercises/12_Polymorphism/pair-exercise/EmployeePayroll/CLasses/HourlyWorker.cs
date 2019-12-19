using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePayroll.CLasses
{
    public class HourlyWorker : IWorker
    {
        public string FirstName { get; }
        public string LastName { get; }
        public double HourlyRate { get; }
        double pay = 0;
        double overtime = 0;

        public HourlyWorker(double hourlyRate, string firstName, string lastName)
        {
            HourlyRate = hourlyRate;
            FirstName = firstName;
            LastName = lastName;
        }

        public double CalculateWeeklyPay(int hoursWorked)
        {
            if (hoursWorked <= 40)
            {
                pay = HourlyRate * hoursWorked;
                pay = Math.Round(pay, 2); 
                return pay;
            }
            else
            {
                pay = HourlyRate * hoursWorked;
                overtime = hoursWorked - 40;
                pay = pay + (HourlyRate * overtime * .5);
                pay = Math.Round(pay, 2); 
                return pay;
            }
        }
    }
}
