using static System.Console;
using Packt.CS7;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LinqWithEFCore
{
    class Program
    {
        private static void useSelect()
        {
            using (var db = new Northwind())
            {
                var query = db.Products
                    .Where(product => product.UnitPrice < 10M)
                    .OrderByDescending(product => product.UnitPrice)
                    .Select(product => new
                    {
                        product.ProductID,
                        product.ProductName,
                        product.UnitPrice
                    });
                
                WriteLine("Products that cost less than $10:");
                foreach (var item in query)
                {
                    WriteLine($"{item.ProductID}: {item.ProductName} costs {item.UnitPrice:$#,##0.00}");
                }
                WriteLine();
            }
        }
        
        private static void useJoin()
        {
            using (var db = new Northwind())
            {
                // create two sequences that we want to join together
                var categories = db.Categories
                    .Select(c => new { c.CategoryID, c.CategoryName })
                    .ToArray();
                
                var products = db.Products
                    .Select(p => new { p.ProductID, p.ProductName,p.CategoryID })
                    .ToArray();
                
                // join every product to its category to return 77 matches
                var queryJoin = categories
                    .Join(
                        products,
                        category => category.CategoryID,
                        product => product.CategoryID,
                        (c, p) => new { c.CategoryName, p.ProductName, p.ProductID })
                    .OrderBy(cp => cp.ProductID);
                
                foreach (var item in queryJoin)
                {
                    WriteLine($"{item.ProductID}: {item.ProductName} is in {item.CategoryName}.");
                }
            }
        }
        
        private static void useGroupJoin()
        {
            using (var db = new Northwind())
            {
                // create two sequences that we want to join together
                var categories = db.Categories
                    .Select(c => new { c.CategoryID, c.CategoryName })
                    .ToArray();
                
                var products = db.Products
                    .Select(p => new { p.ProductID, p.ProductName,p.CategoryID })
                    .ToArray();
                
                // group all products by their category to return 8 matches
                var queryGroup = categories.GroupJoin(products,
                    category => category.CategoryID,
                    product => product.CategoryID,
                    (c, Products) => new { c.CategoryName, Products = Products.OrderBy(p => p.ProductName) });
                
                foreach (var item in queryGroup)
                {
                    WriteLine($"{item.CategoryName} has {item.Products.Count()} products.");
                    foreach (var product in item.Products)
                    {
                        WriteLine($" {product.ProductName}");
                    }
                }
            }
        }
        
        static void Main(string[] args)
        {
            // useSelect();
            // useJoin();
            useGroupJoin();
        }
    }
}