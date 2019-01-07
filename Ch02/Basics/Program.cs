using System;

namespace Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // let the heightInMetres variable become equal to the value 1.88 
            double heightInMetres = 1.88;
            Console.WriteLine($"The variable {nameof(heightInMetres)} has the value {heightInMetres}.");
            
            uint naturalNumber = 23; // unsigned integer means positive whole number
            int integerNumber = -23; // integer means negative or positive whole number
            double realNumber = 2.3; // double means double-precision floating point
            
            int decimalNotation = 2_000_000; // 2 million 
            int binaryNotation = 0b0001_1110_1000_0100_1000_0000; // 2 million 
            int hexadecimalNotation = 0x001E_8480; // 2 million
            Console.WriteLine($"{decimalNotation == binaryNotation}"); // => true
            Console.WriteLine($"{decimalNotation == hexadecimalNotation}"); // => true
            
            Console.WriteLine($"int uses {sizeof(int)} bytes and can store numbers in the range {int.MinValue:N0} to {int.MaxValue:N0}."); 
            Console.WriteLine($"double uses {sizeof(double)} bytes and can store numbers in the range {double.MinValue:N0} to {double.MaxValue:N0}."); 
            Console.WriteLine($"decimal uses {sizeof(decimal)} bytes and can store numbers in the range {decimal.MinValue:N0} to {decimal.MaxValue:N0}.");
            
            Console.Write("Type your first name and press ENTER: "); 
            string firstName = Console.ReadLine(); 
            Console.Write("Type your age and press ENTER: "); 
            string age = Console.ReadLine(); 
            Console.WriteLine($"Hello {firstName}, you look good for {age}."); 
        }
    }
}
