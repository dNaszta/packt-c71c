using System; 
using System.Threading; 
using System.Threading.Tasks; 
using System.Diagnostics; 
using static System.Console; 

namespace NestedAndChildTasks
{
    class Program
    {
        private static void independentSubTask()
        {
            var outer = Task.Factory.StartNew(() => 
            { 
                WriteLine("Outer task starting..."); 
                var inner = Task.Factory.StartNew(() => 
                { 
                    WriteLine("Inner task starting..."); 
                    Thread.Sleep(2000); 
                    WriteLine("Inner task finished."); 
                }); 
            }); 
            outer.Wait(); 
            WriteLine("Outer task finished."); 
            WriteLine("Press ENTER to end."); 
            ReadLine();
        }
        
        private static void attachedSubTask()
        {
            var outer = Task.Factory.StartNew(() => 
            { 
                WriteLine("Outer task starting..."); 
                var inner = Task.Factory.StartNew(() => 
                { 
                    WriteLine("Inner task starting..."); 
                    Thread.Sleep(2000); 
                    WriteLine("Inner task finished."); 
                }, TaskCreationOptions.AttachedToParent); 
            }); 
            outer.Wait(); 
            WriteLine("Outer task finished."); 
            WriteLine("Press ENTER to end."); 
            ReadLine();
        }
        
        static void Main(string[] args)
        {
            // independentSubTask();
            attachedSubTask();
        }
    }
}