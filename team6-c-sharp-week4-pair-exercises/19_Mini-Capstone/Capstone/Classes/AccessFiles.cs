using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Classes
{
    public class AccessFiles
    {
        static string directory = "C:\\Catering";
        static string filename = "cateringsystem.csv";
        public string FullPath { get; set; } = Path.Combine(directory, filename);

        public List<CateringItem> ReadFromFile()
        {
            List<CateringItem> result = new List<CateringItem>();

            try
            {
                using (StreamReader sr = new StreamReader(FullPath))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] values = line.Split('|');

                        CateringItem item = new CateringItem();

                        item.ProductCode = values[0];
                        item.ProductName = values[1];
                        item.ProductPrice = double.Parse(values[2]);
                        item.ProductType = values[3];

                        result.Add(item);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Error reading the file");
                Console.WriteLine(e.Message);
            }

            return result;
        }
        public void WriteToLog(int quantity, string name, string code, double price)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(@"C:\Catering\Log.txt", true))
                {
                    string log = $"{DateTime.Now}  {quantity}  {name}  {code}  ${price.ToString("F")}  ${(quantity * price).ToString("F")}";
                    sw.WriteLine(log);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void WriteToLog(int deposite, decimal balance)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(@"C:\Catering\Log.txt", true))
                {
                    string log = $"{DateTime.Now}  ADD MONEY:  ${deposite}  ${balance}";
                    sw.WriteLine(log);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void WriteToLog(decimal balance)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(@"C:\Catering\Log.txt", true))
                {
                    string log = $"{DateTime.Now}  GIVE CHANGE:  ${balance.ToString("F")}  $0.00";
                    sw.WriteLine(log);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
