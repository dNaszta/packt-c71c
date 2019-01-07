using System;
using Packt.CS7; 
using static System.Console; 

namespace PeopleApp
{
    class Program
    {
        private static void useCompare()
        {
            Person[] people =
            {
                new Person {Name = "Simon"},
                new Person {Name = "Jenny"},
                new Person {Name = "Adam"},
                new Person {Name = "Richard"}
            };
            
            WriteLine("Initial list of People:");
            writePeople(people);
            
            WriteLine("Use Person's IComparable implementation to sort:");
            Array.Sort(people, new PersonComparer());
            writePeople(people);
        }

        private static void writePeople(Person[] people)
        {
            foreach (var person in people)
            {
                WriteLine($"{person.Name}");
            }
        }
        
        private static void useProcreate()
        {
            var harry = new Person{ Name = "Harry" };
            var mary = new Person{ Name = "Mary" };
            var jill = new Person{ Name = "Jill" };

            // call instance method 
            var baby1 = mary.ProcreateWith(harry);
    
            // call static method
            var baby2 = Person.Procreate(harry, jill);
            
            // call an operator
            var baby3 = harry * mary;
     
            WriteLine($"{mary.Name} has {mary.Children.Count} children.");
            WriteLine($"{harry.Name} has {harry.Children.Count} children.");
            WriteLine($"{jill.Name} has {jill.Children.Count} children.");
            WriteLine($"{mary.Name}'s first child is named \"{mary.Children[0].Name}\".");
            
            WriteLine($"3 fractional is {Person.Factorial(3)}");

            harry.Shout += Harry_Shout;
            harry.Poke(); 
            harry.Poke(); 
            harry.Poke(); 
            harry.Poke();
        }

        private static void Harry_Shout(object sender, System.EventArgs e)
        {
            Person p = (Person)sender;
            WriteLine($"{p.Name} is this angry: {p.AngerLevel}.");
        }

        private static void useDisplacementVector()
        {
            var dv1 = new DisplacementVector(3, 5);
            var dv2 = new DisplacementVector(-2, 7);
            var dv3 = dv1 + dv2;
            
            WriteLine($"({dv1.X}, {dv1.Y}) + ({dv2.X}, {dv2.Y}) = ({dv3.X}, {dv3.Y})");
        }

        private static void useEmployee()
        {
            Employee e1 = new Employee
            {
                Name = "John Doe",
                DateOfBirth = new DateTime(1990, 7, 21)
            };
            
            e1.WriteToConsole();
            
            e1.EmployeeCode = "JJ001"; 
            e1.HireDate = new DateTime(2014, 11, 23); 
            WriteLine($"{e1.Name} was hired on {e1.HireDate:dd/MM/yy}");
            WriteLine(e1.ToString());
        }
        
        static void Main(string[] args)
        {
            useProcreate();
            useCompare();
            useDisplacementVector();
            useEmployee();
        }
    }
}
