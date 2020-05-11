using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPProject.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPProject.Controllers
{
    //Automagically passes into this constructor when we start the app
    public class ProductController : Controller
    {
        private readonly IProductRepository repo;

        public ProductController(IProductRepository repo)
        {
            this.repo = repo;
        }

        // GET: /<controller>/; returns that View file for us from the Product folder
        public IActionResult Index()
        {
            var products = repo.GetAllProducts();

            return View(products);
        }

        //Each method needs to have a View of the same name
        public IActionResult ViewProduct(int id)
        {
            var product = repo.GetProduct(id);

            return View(product);
        }

        //Creating the UPDATE method within the ProductController
        public IActionResult UpdateProduct(int id)
        {
            Product prod = repo.GetProduct(id);

            repo.UpdateProduct(prod);

            if(prod == null) //If there's no product to update...
            {
                return View("ProductNotFound"); //...say so.
            }
            return View(prod); //Otherwise, return the product
        }

        //Adding UpdateProductToDatabase() to link with UpdateProduct.cshtml
        public IActionResult UpdateProductToDatabase(Product product)
        {
            repo.UpdateProduct(product);

            return RedirectToAction("ViewProduct", new { id = product.ProductID });
        }
    }
}
