using System; 
using System.Threading; 
using System.Threading.Tasks; 
using System.Diagnostics; 
using static System.Console;

namespace SynchronizingResourceAccess
{   
    class Program
    {
        
        static object conch = new object();
        
        static Random r = new Random(); 
        static string Message; // a shared resource 
        static int Counter; // another shared resource 
        
        static void MethodA() 
        { 
            for (int i = 0; i < 5; i++) 
            { 
                Thread.Sleep(r.Next(2000)); 
                Message += "A"; 
                Write("."); 
            } 
        }
        
        static void lockMethodAVer() 
        {
            try 
            { 
                Monitor.TryEnter(conch, TimeSpan.FromSeconds(15));
                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(r.Next(2000));
                    Message += "A";
                    Write(".");
                    Interlocked.Increment(ref Counter);
                }
            }
            finally
            { 
                Monitor.Exit(conch); 
            }
        }
        
        static void lockMethodA() 
        {
            lock (conch)
            {
                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(r.Next(2000));
                    Message += "A";
                    Write(".");
                }
            }
        } 

        static void MethodB() 
        { 
            for (int i = 0; i < 5; i++) 
            { 
                Thread.Sleep(r.Next(2000)); 
                Message += "B"; 
                Write("."); 
            } 
        }
        
        static void lockMethodB() 
        {
            lock (conch)
            {
                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(r.Next(2000));
                    Message += "B";
                    Write(".");
                }
            }
        }
        
        static void lockMethodBVer() 
        {
            try 
            { 
                Monitor.TryEnter(conch, TimeSpan.FromSeconds(15));
                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(r.Next(2000));
                    Message += "B";
                    Write(".");
                    Interlocked.Increment(ref Counter);
                }
            }
            finally
            { 
                Monitor.Exit(conch); 
            }
        } 

        static void Main(string[] args) 
        { 
            WriteLine("Please wait for the tasks to complete."); 
            Stopwatch watch = Stopwatch.StartNew(); 

            /* Task a = Task.Factory.StartNew(MethodA); 
            Task b = Task.Factory.StartNew(MethodB); */
            
            /* Task a = Task.Factory.StartNew(lockMethodA); 
            Task b = Task.Factory.StartNew(lockMethodB); */   
            
            Task a = Task.Factory.StartNew(lockMethodAVer); 
            Task b = Task.Factory.StartNew(lockMethodBVer); 

            Task.WaitAll(new Task[] { a, b }); 
            WriteLine(); 
            WriteLine($"Results: {Message}."); 
            WriteLine($"{Counter} string modifications.");
            
            WriteLine($"{watch.ElapsedMilliseconds:#,##0} elapsed milliseconds."); 
        }
    }
}