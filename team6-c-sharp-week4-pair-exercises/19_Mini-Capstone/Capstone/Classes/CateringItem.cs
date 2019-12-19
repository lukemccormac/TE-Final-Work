using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class CateringItem
    {
        // This class should contain the definition for one catering item
        public string ProductCode { get; set; } = "";
        public string ProductName { get; set; } = "";
        public double ProductPrice { get; set; } = 0;
        public string ProductType { get; set; } = "";
        public int Quantity { get; set; } = 50;

        public CateringItem()
        {

        }
        public CateringItem(string productCode, string productName, double productPrice, string productType)
        {
            ProductCode = productCode;
            ProductName = productName;
            ProductPrice = productPrice;
            ProductType = productType; 
        }
      
    }
}
