using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechElevator.Classes
{
    public class ShoppingCart
    {
        private int totalNumberOfItems = 0;
        private decimal totalAmountOwed = 0;

        public int TotalNumberOfItems
        {
            get
            {
                return totalNumberOfItems;
            }
            private set
            {
                totalNumberOfItems = value; 
            }
        }
        public decimal TotalAmountOwed
        {
            get
            {
                return totalAmountOwed;
            }
            private set
            {
                totalAmountOwed = value; 
            }
        }



        public decimal GetAveragePricePerItem()
        {
            if (TotalAmountOwed > 0 && TotalNumberOfItems > 0)

            {
                return TotalAmountOwed / TotalNumberOfItems;
            }

            else
            {
                return 0; 
            }
        }

    public void AddItems(int numberOfItems, decimal pricePerItem)
        {
            totalNumberOfItems +=numberOfItems;
            totalAmountOwed = totalAmountOwed + pricePerItem * numberOfItems;
            
        }
        public void Empty ()
        {
            totalNumberOfItems = 0;
            totalAmountOwed = 0; 
        }
    }
}
