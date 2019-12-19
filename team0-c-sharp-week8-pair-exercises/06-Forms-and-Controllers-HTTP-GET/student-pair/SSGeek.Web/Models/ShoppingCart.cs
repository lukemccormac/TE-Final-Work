using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSGeek.Web.Models
{
    public class ShoppingCart
    {
        public IList<ShoppingCartItem> Items { get; } = new List<ShoppingCartItem>();

        /// <summary>
        /// Adds a product to a shopping cart
        /// </summary>
        /// <param name="p"></param>
        /// <param name="quantity"></param>
        public void AddToCart(Product p, int quantity)
        {
            // Find the current item in the cart (if it exists)
            var shoppingCartItem = Items.FirstOrDefault(i => i.Product.ProductId == p.ProductId);

            // If it doesn't exist add it as a "Shopping Cart Item"
            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem() { Product = p, Quantity = 0 };
                Items.Add(shoppingCartItem);
            }

            // Update the Quantity            
            shoppingCartItem.Quantity += quantity;

        }

        /// <summary>
        /// Calculates the grand total.
        /// </summary>
        public decimal GrandTotal
        {
            get
            {
                decimal total = 0.0M;

                foreach (var item in Items)
                {
                    total += (item.Product.Price) * item.Quantity;
                }

                return total;
            }
        }
    }
}
