﻿using System;
using System.Collections.Generic;
using ASPProject.Models;
using System.Data;
using Dapper;

namespace ASPProject
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnection _conn;

        public ProductRepository(IDbConnection conn) //Gets connection from Startup file
        {
            _conn = conn;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _conn.Query<Product>("SELECT * FROM PRODUCTS;");
        }

        public Product GetProduct(int id)
        {
            return (Product)_conn.QuerySingle<Product>("SELECT * FROM PRODUCTS WHERE PRODUCTID = @id",
                new { id = id });
        }

        public void UpdateProduct(Product product)//snubbed-out method
        {
            _conn.Execute("UPDATE products SET Name = @name, Price = @price WHERE ProductID = @id",
                new { name = product.Name, price = product.Price, id = product.ProductID });
        }

        public void InsertProduct(Product productToInsert)
        {
            _conn.Execute("INSERT INTO products (NAME, PRICE, CATEGORYID) VALUES(@name, @price, @categoryID);",
            new { name = productToInsert.Name, price = productToInsert.Price, categoryID = productToInsert.CategoryID });
        }

        public IEnumerable<Category> GetCategories()
        {
            return _conn.Query<Category>("SELECT * FROM categories;");
        }

        public Product AssignCategory()
        {
            var categoryList = GetCategories();
            var product = new Product();
            product.Categories = categoryList;

            return product;
        }

        //Finally, we arrange to DELETE products:
        public void DeleteProduct(Product product)
        {
            _conn.Execute("DELETE FROM Reviews WHERE ProductID = @id;",
                new { id = product.ProductID });
            _conn.Execute("DELETE FROM Sales WHERE ProductID = @id;",
                new { id = product.ProductID });
            _conn.Execute("DELETE FROM Products WHERE ProductID = @id;",
                new { id = product.ProductID });
        }
    }
}
