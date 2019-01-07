using static System.Console;

namespace IterationStatements
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 0; 
            while (x < 10) 
            { 
                WriteLine(x); 
                x++; 
            }
            
            string[] names = { "Adam", "Barry", "Charlie" };
            foreach (string name in names)
            {
                WriteLine($"{name} has {name.Length} characters.");
            }
            
            string password = string.Empty; 
            do 
            { 
                Write("Enter your password: "); 
                password = ReadLine(); 
            } while (password != "secret"); 
            WriteLine("Correct!"); 
        }
    }
}
