using System;
using System.Net.NetworkInformation;
using System.Threading;
using System.IO;

namespace SimpleInternetConnectionLogger
{
    class Program
    {
        static void Main(string[] args)
        {
           // File.Create("log.txt");
             

            while (true) {
                TextWriter tw = new StreamWriter("log.txt", true);
                DateTime currentTime = DateTime.Now;
                try
            {
                Ping myPing = new Ping();
                PingReply reply = myPing.Send("bertrand.pl", 1000);
                if (reply != null)
                {
                    Console.WriteLine(currentTime + " Status: " + reply.Status + " Ping:" + reply.RoundtripTime.ToString() + " ms " + " Address : " + reply.Address);
                    tw.WriteLine(currentTime + " Status: " + reply.Status + " Ping:" + reply.RoundtripTime.ToString() + " ms " + " Address : " + reply.Address);
                        tw.Close();
                }
            }
            catch
            {
                Console.WriteLine(currentTime + " TIMEOUT ");
                tw.WriteLine(currentTime + " TIMEOUT ");
                tw.Close();
            }
                Thread.Sleep(10000);
            }
        }
    }
}
