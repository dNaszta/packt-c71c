using static System.Console;
using System;
using Packt.CS7;

namespace PeopleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            /**
            var p1 = new Person();
            p1.Name = "Bob Smith";
            p1.DateOfBirth = new System.DateTime(1965, 12, 22);
            p1.BucketList = WondersOfTheAnchientWorld.HangingGardensOfBabylon | WondersOfTheAnchientWorld.MausoleumAtHalicarnassus;
            p1.Children.Add(new Person { Name = "Alfred" });
            p1.Children.Add(new Person { Name = "Zoe" });
            
            WriteLine($"{p1.Name} was born on {p1.DateOfBirth: dddd, d MMMM yyyy}");
            WriteLine($"{p1.Name}'s bucket list is {p1.BucketList}");
            WriteLine($"{p1.Name} has {p1.Children.Count} children:");
            
            for (int child = 0; child < p1.Children.Count; child++)
            {
                WriteLine($"    {p1.Children[child].Name}");
            }

            BankAccount.InterestRate = 0.012M;
            var ba1 = new BankAccount();
            ba1.AccountName = "Mrs. Jones";
            ba1.Balance = 2400;
            WriteLine($"{ba1.AccountName} earned {ba1.Balance * BankAccount.InterestRate:C}");
            var ba2 = new BankAccount();
            ba2.AccountName = "Ms. Gerrier";
            ba2.Balance = 98;
            WriteLine($"{ba2.AccountName} earned {ba2.Balance * BankAccount.InterestRate:C}");
            
            WriteLine($"{p1.Name} is a {Person.Species}");
            WriteLine($"{p1.Name} was born on {p1.HomePlanet}");
            
            p1.WriteToConsole();
            
            int a = 10; 
            int b = 20; 
            int c = 30; 
            WriteLine($"Before: a = {a}, b = {b}, c = {c}"); 
            p1.PassingParameters(a, ref b, out c); 
            WriteLine($"After: a = {a}, b = {b}, c = {c}"); 
            
            var p2 = new Person();
            WriteLine($"{p2.Name} was instantiated at  {p2.Instantiated:hh:mm:ss} on {p2.Instantiated:dddd, d MMMM yyyy}");
            
            var p3 = new Person("Lofasz");
            WriteLine($"{p3.Name} was instantiated at  {p3.Instantiated:hh:mm:ss} on {p3.Instantiated:dddd, d MMMM yyyy}");
            */
            useProperties();
        }

        private static void useProperties()
        {
            var sam = new Person 
            { 
                Name = "Sam",  
                DateOfBirth = new DateTime(1972, 1, 27) 
            }; 
            WriteLine(sam.Origin); 
            WriteLine(sam.Greeting); 
            WriteLine(sam.Age);
            
            sam.FavoriteIceCream = "Chocolate Fudge"; 
            WriteLine($"Sam's favorite ice-cream flavor is {sam.FavoriteIceCream}."); 
            sam.FavoritePrimaryColor = "Red"; 
            WriteLine($"Sam's favorite primary color is {sam.FavoritePrimaryColor}.");
            
            sam.Children.Add(new Person { Name = "Charlie" }); 
            sam.Children.Add(new Person { Name = "Ella" }); 
            WriteLine($"Sam's first child is {sam.Children[0].Name}"); 
            WriteLine($"Sam's second child is {sam.Children[1].Name}"); 
            WriteLine($"Sam's first child is {sam[0].Name}"); 
            WriteLine($"Sam's second child is {sam[1].Name}"); 
        }
    }
}