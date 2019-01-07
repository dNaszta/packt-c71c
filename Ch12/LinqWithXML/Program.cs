using System;
using System.Linq;
using System.Xml.Linq;
using Packt.CS7;
using static System.Console;

namespace LinqWithXML
{
    class Program
    {
        private static void createXml()
        {
            using (var db = new Northwind())
            {
                var productsForXml = db.Products.ToArray(); 
 
                var xml = new XElement("products", 
                    from p in productsForXml 
                    select new XElement("product", 
                        new XAttribute("id", p.ProductID), 
                        new XAttribute("price", p.UnitPrice), 
                        new XElement("name", p.ProductName))); 
 
                WriteLine(xml.ToString());
            }
        }

        private static void readFromXml()
        {
            XDocument doc = XDocument.Load("settings.xml"); 
 
            var appSettings = doc
                .Descendants("appSettings")
                .Descendants("add")
                .Select(node => new { 
                    Key = node.Attribute("key").Value, 
                    Value = node.Attribute("value").Value 
                })
                .ToArray(); 
 
            foreach (var item in appSettings) 
            { 
                WriteLine($"{item.Key}: {item.Value}"); 
            } 
        }
        
        static void Main(string[] args)
        {
            // createXml();
            readFromXml();
        }
    }
}