using System;
using System.IO;

namespace SelectionStatements
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
                Console.WriteLine("There are no arguments.");
            else
                Console.WriteLine("There is at least one argument.");
            
            object o = 3;
            int j = 4;
 
            if(o is int i)
            { 
                Console.WriteLine($"{i} x {j} = {i * j}");
            } 
            else
            { 
                Console.WriteLine("o is not an int so it cannot multiply!");
            }
            
            
            A_label:
            var number = (new Random()).Next(1, 7);
            Console.WriteLine($"My random number is {number}");
            switch (number)
            {
                case 1:
                    Console.WriteLine("One");
                    break; // jumps to end of switch statement
                case 2:
                    Console.WriteLine("Two");
                    goto case 1;
                case 3:
                case 4:
                    Console.WriteLine("Three or four");
                    goto case 1;
                case 5:
                    // go to sleep for half a second
                    System.Threading.Thread.Sleep(500); 
                    goto A_label;
                default:
                    Console.WriteLine("Default");
                    break;
            } // end of switch statement
            
            
            string path = "";
    
            Stream s = File.Open(
                Path.Combine(path, "file.txt"),
                FileMode.OpenOrCreate);
 
            switch(s)
            {
                case FileStream writeableFile when s.CanWrite:
                    Console.WriteLine("The stream is to a file that I can write to.");
                    break;
                case FileStream readOnlyFile:
                    Console.WriteLine("The stream is to a read-only file.");
                    break;
                case MemoryStream ms:
                    Console.WriteLine("The stream is to a memory address.");
                    break;
                default: // always evaluated last despite its current position
                    Console. WriteLine("The stream is some other type.");
                    break;
                case null:
                    Console.WriteLine("The stream is null.");
                    break;
            } 
        }
    }
}