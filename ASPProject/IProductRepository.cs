using System.Collections.Generic;
using System;
using ASPProject.Models;
using System.Data;


namespace ASPProject
{
    //Provide the framework for CRUD functionality
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAllProducts(); //show all products
        public Product GetProduct(int id); //READ product
        public void UpdateProduct(Product product); //UPDATE product
        //Next, we set up code to CREATE products:
        public void InsertProduct(Product productToInsert);
        public IEnumerable<Category> GetCategories();
        public Product AssignCategory();
    }
}
