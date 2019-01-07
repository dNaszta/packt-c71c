using static System.Console; 
using Packt.CS7; 
using Microsoft.EntityFrameworkCore; 
using System.Linq;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Infrastructure; 
using Microsoft.Extensions.DependencyInjection; 
using Microsoft.Extensions.Logging; 

namespace WorkingWithEFCore
{
    class Program
    {
        static void QueryingCategories()
        { 
            using (var db = new Northwind()) 
            {
                // var loggerFactory = db.GetService<ILoggerFactory>(); 
                // loggerFactory.AddProvider(new ConsoleLoggerProvider());
                WriteLine("Categories and how many products they have:"); 
 
                IQueryable<Category> cats;  
                // = db.Categories;//.Include(c => c.Products); 
 
                Write("Enable eager loading? (Y/N): "); 
                bool eagerloading = (ReadKey().Key == ConsoleKey.Y); 
                bool explicitloading = false; 
                WriteLine(); 
                if (eagerloading) 
                { 
                    cats = db.Categories.Include(c => c.Products); 
                } 
                else 
                { 
                    cats = db.Categories; 
                    Write("Enable explicit loading? (Y/N): "); 
                    explicitloading = (ReadKey().Key == ConsoleKey.Y); 
                    WriteLine(); 
                }
 
                foreach (Category c in cats) 
                { 
                    WriteLine($"{c.CategoryName} has {c.Products.Count} products."); 
                } 
            }
        }

        static void QueryProducts()
        {
            using (var db = new Northwind())
            {
                var loggerFactory = db.GetService<ILoggerFactory>(); 
                loggerFactory.AddProvider(new ConsoleLoggerProvider());
                WriteLine("Products that cost more than a price, and sorted."); 
                string input; 
                decimal price; 
                do 
                {
                    Write("Enter a product price: "); 
                    input = ReadLine(); 
                } while(!decimal.TryParse(input, out price)); 
 
                IQueryable<Product> prods = db.Products 
                    .Where(product => product.Cost > price) 
                    .OrderByDescending(product => product.Cost);
 
                foreach (Product item in prods)  
                { 
                    WriteLine($"{item.ProductID}: {item.ProductName} costs {item.Cost:$#,##0.00} and has {item.Stock} units in stock."); 
                } 
            }
        }
        
        static bool AddProduct(int categoryID, string productName, decimal? price)
        {
            using (var db = new Northwind())
            {
                var newProduct = new Product 
                { 
                    CategoryID = categoryID,
                    ProductName = productName, 
                    Cost = price
                }; 

                // mark product as added in change tracking 
                db.Products.Add(newProduct); 
                // save tracked changes to database 
                int affected = db.SaveChanges(); 
                return (affected == 1);
            }
        }
        
        static void ListProducts()
        {
            using (var db = new Northwind())
            {
                WriteLine("------------------------------------------------------------------------");
                WriteLine("| ID | Product Name | Cost | Stock | Disc. |");
                WriteLine("------------------------------------------------------------------------");
                foreach (var item in db.Products.OrderByDescending(p => p.Cost))
                {
                    WriteLine($"| {item.ProductID:000} | {item.ProductName,-35} | {item.Cost,8:$#,##0.00} | {item.Stock, 5} | {item.Discontinued} |");
                
                }
                WriteLine("------------------------------------------------------------------------");
            }
        }
        
        static bool IncreaseProductPrice(string name, decimal amount)
        {
            using (var db = new Northwind())
            {
                Product updateProduct = db.Products.First(p => p.ProductName.StartsWith(name)); 
                updateProduct.Cost += amount; 
                int affected = db.SaveChanges();
                return (affected == 1); 
            }
        }
        
        static int DeleteProducts(string name)
        {
            using (var db = new Northwind())
            {
                IEnumerable<Product> products = db.Products.Where(p => p.ProductName.StartsWith(name)); 
                db.Products.RemoveRange(products); 
                int affected = db.SaveChanges();
                return affected; 
            }
        }
        
        static void Main(string[] args)
        {
            // QueryingCategories();
            // QueryProducts();
            
            // AddProduct(6, "Bob's Burgers", 500M);
            // IncreaseProductPrice("Bob", 20M);
            
            int deleted = DeleteProducts("Bob");
            WriteLine($"{deleted} product(s) were deleted.");
            
            ListProducts();
        }
    }
}