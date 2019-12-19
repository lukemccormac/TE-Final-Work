using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SSGeek.Web.DAL;
using SSGeek.Web.Extensions;
using SSGeek.Web.Models;

namespace SSGeek.Web.Controllers
{
    public class StoreController : Controller
    {
        private IProductDAO ProductDAO;

        public StoreController(IProductDAO productDAO)
        {
            ProductDAO = productDAO;
        }

        public IActionResult Index()
        {
            IList<Product> list = ProductDAO.GetProducts();
            return View(list);
        }

        public IActionResult Detail(int id)
        {
            Product product = ProductDAO.GetProduct(id);
            return View(product);
        }
        [HttpPost]
        public ActionResult AddToCart(Product product, int quantity)
        {
            // Add whichever Product productId represents to the shopping cart

            //1.  Get the Product associated with id
            product = ProductDAO.GetProduct(product.ProductId);

            //2.  Add Product, qty 1 to our active shopping cart
            ShoppingCart cart = GetActiveShoppingCart();
            cart.AddToCart(product, 1);

            //3. Save shopping cart
            SaveActiveShoppingCart(cart);

            return RedirectToAction("AddToCart");
        }
        public ActionResult AddToCart()
        {
            ShoppingCart cart = GetActiveShoppingCart();
            return View(cart);
        }

        private ShoppingCart GetActiveShoppingCart()
        {
            ShoppingCart cart = null;

            // See if the user has a shopping cart stored in session            
            if (HttpContext.Session.Get<ShoppingCart>("Shopping_Cart") == null)
            {
                cart = new ShoppingCart();
                SaveActiveShoppingCart(cart);
            }
            else
            {
                cart = HttpContext.Session.Get<ShoppingCart>("Shopping_Cart"); // <-- gets the shopping cart out of session
            }

            // If not, create one for them

            return cart;
        }

        private void SaveActiveShoppingCart(ShoppingCart cart)
        {
            HttpContext.Session.Set("Shopping_Cart", cart);        // <-- saves the shopping cart into session
        }


        //public ActionResult AddToCart(Product product) //productId
        //{
        //    product = ProductDAO.GetProduct(product.ProductId);
        //    ShoppingCart cart = AddToList(product);
        //    cart.AddToCart(product, 1);

        //    //List<ShoppingCartItem> result = AddToCar(product.ProductId);
        //    return View(cart);
        //}

        //private ShoppingCart AddToList(Product product)
        //{
        //    List<ShoppingCart> result = new List<ShoppingCart>();

        //    List<ShoppingCart> current = HttpContext.Session.Get<List<ShoppingCart>>("ShoppingCart");

        //    if (current == null)
        //    {
        //        //HttpContext.Session.Set<List<int>>("ShoppingCart", result);
        //        current = result;
        //    }
        //    ShoppingCartItem shoppingCartItem = new ShoppingCartItem();

        //    shoppingCartItem.Product = product;
        //    shoppingCartItem.Quantity = 1;



        //    //current.Add(shoppingCart);
        //    //HttpContext.Session.Set<List<ShoppingCartItem>>("ShoppingCart", current);

        //    //return current;
        //}
    }
}