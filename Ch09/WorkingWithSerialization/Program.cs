using System; // DateTime
using System.Collections.Generic; // List<T>, HashSet<T>
using System.Xml.Serialization; // XmlSerializer
using System.IO;
using System.Threading.Tasks.Sources;
// FileStream
using Packt.CS7; // Person
using static System.Console;
using static System.Environment;
using static System.IO.Path;
using Newtonsoft.Json;

namespace WorkingWithSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = new List<Person>
            {
                new Person(30000M)
                {
                    FirstName = "Alice", 
                    LastName = "Smith",
                    DateOfBirth = new DateTime(1974, 3, 14)
                },
                new Person(40000M)
                {
                    FirstName = "Bob", 
                    LastName = "Jones",
                    DateOfBirth = new DateTime(1969, 11, 23) 
                },
                new Person(20000M)
                {
                    FirstName = "Charlie", LastName = "Rose",
                    DateOfBirth = new DateTime(1964, 5, 4),
                    Children = new HashSet<Person>{
                        new Person(0M)
                        {
                            FirstName = "Sally",
                            LastName = "Rose",
                            DateOfBirth = new DateTime(1990, 7, 12)
                        } 
                    }
                }
            };
            
            serializeJson(people);
            
        }

        static void serializeXml(List<Person> people)
        {
            // create a file to write to
            string path = Combine(CurrentDirectory, "people.xml");
            
            FileStream stream = File.Create(path);
            
            // create an object that will format as List of Persons as XML
            var xs = new XmlSerializer(typeof(List<Person>));
            
            // serialize the object graph to the stream
            xs.Serialize(stream, people);
            
            // you must close the stream to release the file lock
            stream.Close();
            WriteLine($"Written {new FileInfo(path).Length} bytes of XML to {path}");
            WriteLine();
            // Display the serialized object graph
            WriteLine(File.ReadAllText(path));
        }
        
        static void serializeJson(List<Person> people)
        {
            // create a file to write to
            // create a file to write to
            string jsonPath = Combine(CurrentDirectory, "people.json");
            StreamWriter jsonStream = File.CreateText(jsonPath);
            // create an object that will format as JSON
            var jss = new JsonSerializer();
            // serialize the object graph into a string
            jss.Serialize(jsonStream, people);
            jsonStream.Close(); // release the file lock
            WriteLine();
            WriteLine($"Written {new FileInfo(jsonPath).Length} bytes of JSON to: {jsonPath}");
            // Display the serialized object graph
            WriteLine(File.ReadAllText(jsonPath));
        }
    }
}