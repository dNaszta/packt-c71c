using System;
using System.Net;
using System.Net.NetworkInformation;
using static System.Console;

namespace WorkingWithNetworkResources
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Enter a valid ip address: ");
            string url = ReadLine();

            if (string.IsNullOrWhiteSpace(url))
            {
                url = "http://world.episerver.com/cms/?q=pagetype";
            }
            
            var uri = new Uri(url);
            
            WriteLine($"Scheme: {uri.Scheme}");
            WriteLine($"Port: {uri.Port}");
            WriteLine($"Host: {uri.Host}");
            WriteLine($"Path: {uri.AbsolutePath}");
            WriteLine($"Query: {uri.Query}");
            
            IPHostEntry entry = Dns.GetHostEntry(uri.Host);
            WriteLine($"{entry.HostName} has the following IP addresses:");
            foreach (IPAddress address in entry.AddressList)
            {
                WriteLine($" {address}");
            }

            var ping = new Ping();
            PingReply reply = ping.Send(uri.Host);
            WriteLine($"{uri.Host} was pinged, and replied: {reply.Status}.");
            if (reply.Status == IPStatus.Success)
            {
                WriteLine($"Reply from {reply.Address} took {reply.RoundtripTime:N0}ms");
            }
        }
    }
}