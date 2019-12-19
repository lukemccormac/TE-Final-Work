using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individual.Exercises.Classes
{
    public class Employee
    {
        private int employeeId = 0;
        private string firstName = "";
        private string lastName = "";
        private string fullName = "";
        private string department = "";
        private double annualSalary = 0;

        public int EmployeeId
        {
            get
            {
                return employeeId; 
            }
        }
        public string FirstName
        {
            get
            {
                return firstName;
            }
        }
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }
        public string FullName
        {
            get
            {
                return lastName + ", " + firstName;   
            }
        }
        public string Department
        {
            get
            {
                return department; 
            }
            set
            {
                department = value; 
            }
        }
        public double AnnualSalary
        {
            get
            {
                return annualSalary;
            }
            private set
            {
                annualSalary = value; 
            }
        }
       public Employee (int employeeId, string firstName, string lastName, double salary)
        {
            this.employeeId = employeeId;
            this.firstName = firstName;
            this.lastName = lastName;
            annualSalary = salary; 
        }
        public void RaiseSalary(double percent)
        {
            annualSalary = (annualSalary * percent/100)+annualSalary;  
        }
    } 
}
