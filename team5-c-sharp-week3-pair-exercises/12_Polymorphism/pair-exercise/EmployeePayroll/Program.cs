using System;
using System.Collections.Generic;
using System.Text;
using EmployeePayroll.CLasses; 

namespace EmployeePayroll
{
    class Program 
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Employee     Hours Worked     Pay");
            Console.WriteLine("======================================"); 
            Random rnd = new Random();
            int hoursWorked = 0;
            int totalHours = 0;
            double totalPay = 0; 

            
            List<IWorker> workers = new List<IWorker> { new HourlyWorker(25.00, "John", "Smith"),
                new SalaryWorker(25000.00, "Joe", "Schmo"), new VolunteerWorker("Lebron", "James") };
            foreach (IWorker worker in workers)
            {
                hoursWorked = rnd.Next(0, 50);
                Console.Write(worker.LastName + ", " + worker.FirstName.PadRight(8) + "" + hoursWorked +"".PadLeft(12)+ "$"+ worker.CalculateWeeklyPay(hoursWorked));
                Console.WriteLine();

                totalHours = totalHours + hoursWorked;
                totalPay = totalPay + worker.CalculateWeeklyPay(hoursWorked); 

            }
            Console.WriteLine(); 
            Console.WriteLine("Total Hours: " + totalHours);
            Console.Write("Total pay: " + "$" + totalPay); 
            
            


            Console.ReadLine(); 
        }
    }
}
