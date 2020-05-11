using System.Collections.Generic;
using System;
using ASPProject.Models;

namespace ASPProject
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAllProducts();
        public Product GetProduct(int id);
    }
}
