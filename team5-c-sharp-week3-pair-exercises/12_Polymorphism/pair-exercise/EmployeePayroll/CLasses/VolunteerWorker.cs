using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePayroll.CLasses
{
    public class VolunteerWorker : IWorker
    {
        public string FirstName { get; }
        public string LastName { get; }
        double pay = 0;

        public VolunteerWorker(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public double CalculateWeeklyPay(int hoursWorked)
        {
            pay = hoursWorked * 0;
            return pay;
        }
    }
}
