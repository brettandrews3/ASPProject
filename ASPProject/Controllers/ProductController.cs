﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}
