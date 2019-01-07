using System;
using System.Collections.Generic;
using static System.Console;

namespace Packt.CS7
{
    public partial class Person : object
    {
        public const string Species = "Homo Sapiens";
        public readonly string HomePlanet = "Earth"; 
        
        public string Name;
        public DateTime DateOfBirth;
        public WondersOfTheAnchientWorld BucketList;
        public List<Person> Children = new List<Person>();
        public readonly DateTime Instantiated;

        public Person()
        {
            Name = "Unknown";
            Instantiated = DateTime.Now;
        }
        
        public Person(string initialName) 
        { 
            Name = initialName; 
            Instantiated = DateTime.Now; 
        }

        public void WriteToConsole()
        {
            WriteLine($"{Name} was born on {DateOfBirth:dddd, d MMMM yyyy}");
        }

        public string GetOrigin()
        {
            return $"{Name} was born on {HomePlanet}";
        }
        
        public void PassingParameters(int x, ref int y, out int z) 
        { 
            // out parameters cannot have a default  
            // AND must be initialized inside the method 
            z = 99; 
 
            // increment each parameter 
            x++; 
            y++; 
            z++; 
        } 
    }
}
