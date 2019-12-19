using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class UserInterface
    {
        // This class provides all user communications, but not much else.
        // All the "work" of the application should be done elsewhere
        // All instance of Console.ReadLine and Console.WriteLine should be in this class.

        private Catering catering = new Catering();


        public void RunInterface()
        {

            bool done = false;
            DisplayMainMenu();
            Console.WriteLine();
            string selection = Console.ReadLine();
            while (!done)
            {
                switch (selection)
                {
                    case "1":
                        foreach (CateringItem item in catering.Items)
                        {
                            Console.WriteLine(item.ProductCode.PadRight(5) + item.ProductName.PadRight(25) + "$" + item.ProductPrice.ToString("F").PadRight(10));
                        }

                        break;
                    case "2":
                        OrderMenu();
                        break;
                    case "3":
                        done = true;
                        return;
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Please make valid selection");
                        Console.WriteLine();
                        break;
                }
                Console.WriteLine();
                DisplayMainMenu();
                selection = Console.ReadLine();
            }
        }
        public void DisplayMainMenu()
        {
            Console.WriteLine("(1) Display Catering Items");
            Console.WriteLine("(2) Order");
            Console.WriteLine("(3) Quit");

        }
        public void DisplayOrderMenu()
        {
            Console.WriteLine("(1) Add Money");
            Console.WriteLine("(2) Select Products");
            Console.WriteLine("(3) Complete Transactions");
            Console.WriteLine($"Current Account Balance: ${catering.Balance.ToString("F")}");
        }
        public void OrderMenu() { 
            string input = "";
            bool orderDone = false;
            DisplayOrderMenu();
            input = Console.ReadLine();
            while (!orderDone)
            {
                switch (input)
                {
                    case "1":
                        Console.WriteLine("Please enter the dollar amount you would like to deposite.  ");
                        catering.AddMoney(int.Parse(Console.ReadLine()));
                        break;
                    case "2":
                        SelectProducts();
                        break;
                    case "3":
                        PrintReport();
                        Console.WriteLine();
                        Console.WriteLine($"Change due: ${catering.Balance.ToString("F")}");
                        Console.WriteLine();
                        catering.ReturnChange();
                        DisplayChange();
                        orderDone = true;
                        return;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Please make valid selection");
                        Console.WriteLine();
                        break;
                }
                Console.WriteLine();
                DisplayOrderMenu();
                input = Console.ReadLine();
                Console.WriteLine();
            }
            return;
        }
        public void SelectProducts()
        {
            Console.Write("Please enter item code:  ");
            string itemSelection = Console.ReadLine().ToUpper();
            AccessFiles fileAccess = new AccessFiles();
            foreach (CateringItem item in catering.Items)
            {
                if (item.ProductCode == itemSelection)
                {
                    Console.Write("Please enter desired quantity:  ");
                    int itemQuantity = int.Parse(Console.ReadLine());
                    if (itemQuantity <= item.Quantity &&
                        catering.Balance > (decimal)item.ProductPrice * itemQuantity)
                    {
                        catering.Cart.Add(item);
                        item.Quantity -= itemQuantity;
                        catering.Balance -= (decimal)item.ProductPrice * itemQuantity;
                        catering.Cart[catering.Cart.Count - 1].Quantity = itemQuantity;
                        fileAccess.WriteToLog(itemQuantity, item.ProductName, item.ProductCode, item.ProductPrice);
                        return;
                    }
                    else if (catering.Balance < (decimal)item.ProductPrice * itemQuantity)
                    {
                        Console.WriteLine("Insufficient money.");
                    }
                    else if (item.Quantity > 0)
                    {
                        Console.WriteLine("Insufficient stock.");
                    }
                    else if (item.Quantity == 0)
                    {
                        Console.WriteLine("SOLD OUT");
                    }
                    else
                    {
                        Console.WriteLine("Item not found.");
                    }
                }

            }

        }
        public void PrintReport()
        {
            string type = "";
            foreach (CateringItem item in catering.Cart)
            {
                if (item.ProductType == "A")
                {
                    type = "Appetizer";
                }
                else if (item.ProductType == "B")
                {
                    type = "Beverage";
                }
                else if (item.ProductType == "E")
                {
                    type = "Entree";
                }
                else if (item.ProductType == "D")
                {
                    type = "Dessert";
                }
                Console.WriteLine(item.Quantity.ToString().PadRight(5) + type.PadRight(15) + item.ProductName.PadRight(25) +
               "$" + item.ProductPrice.ToString("F").PadRight(10) + "$" + (item.ProductPrice * item.Quantity).ToString("F").PadRight(10));
            }
        }

        public void DisplayChange()
        {
            Console.WriteLine();
            foreach(KeyValuePair<string, int> kvp in catering.Change)
            {
                if (kvp.Value > 0)
                {
                    Console.WriteLine(kvp.Value.ToString().PadRight(5) + kvp.Key);
                }
            }
        }
    }
}
