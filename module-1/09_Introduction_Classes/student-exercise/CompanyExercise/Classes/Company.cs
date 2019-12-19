using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechElevator.Classes
{
    public class Company

    {


        private string name = "";
        private int numberOfEmployees = 0;
        private decimal revenue = 0;
        private decimal expenses = 0;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public int NumberOfEmployees
        {
            get
            {
                return numberOfEmployees;
            }
            set
            {
                numberOfEmployees = value;
            }
        }
        public decimal Revenue
        {
            get
            {
                return revenue;
            }
            set
            {
                revenue = value;
            }
        }
        public decimal Expenses
        {
            get
            {
                return expenses;
            }
            set
            {
                expenses = value;
            }
        }

        public decimal GetProfit()
        {
            return revenue-expenses; 
        }

        public string GetCompanySize()

        {
            if (NumberOfEmployees < 50)
            {
                return "small";
            }
            else if (NumberOfEmployees >= 50 && NumberOfEmployees <= 250)
            {
                return "medium";
            }
            else if (NumberOfEmployees > 250) 
            {
                return "large";
            }
            else
            {
                return ""; 
            }
          
        }      

    }
}


        

      
        
       
        


    
   

