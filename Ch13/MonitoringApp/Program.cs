using System.Linq;
using Packt.CS7;
using static System.Console;

namespace MonitoringApp
{
    class Program
    {
        private static void firstTest()
        {
            Write("Press ENTER to start the timer: "); 
            ReadLine(); 
            Recorder.Start();
            
            int[] largeArrayOfInts = Enumerable.Range(1, 10000).ToArray();
            Write("Press ENTER to stop the timer: "); 
            ReadLine();
            Recorder.Stop(); 
            ReadLine(); 
        }

        private static void concatenateString()
        {
            int[] numbers = Enumerable.Range(1, 50000).ToArray(); 
            Recorder.Start(); 
            WriteLine("Using string"); 
            string s = ""; 
            for (int i = 0; i < numbers.Length; i++) 
            { 
                s += numbers[i] + ", "; 
            } 
            Recorder.Stop(); 
            Recorder.Start(); 
            WriteLine("Using StringBuilder"); 
            var builder = new System.Text.StringBuilder(); 
            for (int i = 0; i < numbers.Length; i++) 
            { 
                builder.Append(numbers[i]); 
                builder.Append(", "); 
            } 
            Recorder.Stop(); 
            ReadLine();
        }
        
        static void Main(string[] args)
        {
            // firstTest();
            concatenateString();
        }
    }
}