using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Classes
{
    public class Catering
    {
        public List<CateringItem> Items
        {
            get
            {
                return items;
            }
        }
        // This class should contain all the "work" for catering
        private List<CateringItem> items = new List<CateringItem>();

        public List<CateringItem> Cart { get; set; } = new List<CateringItem>();

        public Dictionary<string, int> Change { get; set; }
  
        public Catering()
        {
            AccessFiles fileAccess = new AccessFiles();
            items = fileAccess.ReadFromFile();


        }

        public decimal Balance { get; set; } = 0;

        public decimal AddMoney(int deposite)
        {
            AccessFiles fileAccess = new AccessFiles();
            if (Balance + deposite <= 5000 && deposite > 0)
            {

                Balance += deposite;
                fileAccess.WriteToLog(deposite, Balance);
            }
            else
            {
                Console.WriteLine("Balance cannot be over $5000.");
            }
            return Balance;
        }

        public Dictionary<string, int> ReturnChange()
        {
            Change = new Dictionary<string, int>() { { "", 0 } };

            AccessFiles fileAccess = new AccessFiles();
            fileAccess.WriteToLog(Balance);
            int count = 0;
            while (Balance >= 100)
            {
                Balance -= 100;
                count++;
            }
            if (count == 1)
            {
                Change.Add("hundred dollar bill", count);
            }
            else if (count > 1)
            {
                Change.Add("hundred dollar bills", count);
            }
            count = 0;
            while (Balance >= 50)
            {
                Balance -= 50;
                count++;
            }
            if (count == 1)
            {
                Change.Add("fifty dollar bill", count);
            }
            else if (count > 1)
            {
                Change.Add("fifty dollar bills", count);
            }
            count = 0;
            while (Balance >= 20)
            {
                Balance -= 20;
                count++;
            }
            if (count == 1)
            {
                Change.Add("twenty dollar bill", count);
            }
            else if (count > 1)
            {
                Change.Add("twenty dollar bills", count);
            }
            count = 0;
            while (Balance >= 10)
            {
                Balance -= 10;
                count++;
            }
            if (count == 1)
            {
                Change.Add("ten dollar bill", count);
            }
            else if (count > 1)
            {
                Change.Add("ten dollar bills", count);
            }
            count = 0;
            while (Balance >= 5)
            {
                Balance -= 5;
                count++;
            }
            if (count == 1)
            {
                Change.Add("five dollar bill", count);
            }
            else if (count > 1)
            {
                Change.Add("five dollar bills", count);
            }
            count = 0;
            while (Balance >= 1)
            {
                Balance -= 1;
                count++;
            }
            if (count == 1)
            {
                Change.Add("one dollar bill", count);
            }
            else if (count > 1)
            {
                Change.Add("one dollar bills", count);
            }
            count = 0;
            while (Balance >= 0.25M)
            {
                Balance -= 0.25M;
                count++;
            }
            if (count == 1)
            {
                Change.Add("quarter", count);
            }
            else if (count > 1)
            {
                Change.Add("quarters", count);
            }
            count = 0;
            while (Balance >= 0.10M)
            {
                Balance -= 0.10M;
                count++;
            }
            if (count == 1)
            {
                Change.Add("dime", count);
            }
            else if (count > 1)
            {
                Change.Add("dimes", count);
            }
            count = 0;
            while (Balance >= 0.05M)
            {
                Balance -= 0.05M;
                count++;
            }
            if (count == 1)
            {
                Change.Add("nickle", count);
            }
            else if (count > 1)
            {
                Change.Add("nickles", count);
            }
            count = 0;
            while (Balance >= 0.01M)
            {
                Balance -= 0.01M;
                count++;
            }
            if (count == 1)
            {
                Change.Add("penny", count);
            }
            else if (count > 1)
            {
                Change.Add("pennies", count);
            }
            
            return Change;
        }

       
        
    }
}

