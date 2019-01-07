using Microsoft.EntityFrameworkCore;
using static System.Console;
 
namespace Packt.CS7 
{ 
    // this manages the connection to the database 
    public class Northwind : DbContext 
    { 
        // these properties map to tables in the database 
        public DbSet<Category> Categories { get; set; } 
        public DbSet<Product> Products { get; set; } 
 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        { 
            // to use SQLite, uncomment the following 
            string path = System.IO.Path.Combine(
                System.IO.Directory.GetParent(System.IO.Directory.GetParent(System.Environment.CurrentDirectory).ToString()).ToString(),
                "Northwind.db");
            // WriteLine(path);
            optionsBuilder.UseSqlite($"Filename={path}"); 
        } 
 
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        { 
            // example of using Fluent API instead of attributes
            // to limit the length of a category name to under 40 
            modelBuilder.Entity<Category>() 
                .Property(category => category.CategoryName) 
                .IsRequired() 
                .HasMaxLength(40);
            
            // global filter to remove discontinued products
            modelBuilder.Entity<Product>().HasQueryFilter(p => !p.Discontinued);
        } 
    } 
}