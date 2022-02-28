using System;
using StandardClient;
using StandardCommon;

namespace Net5Client
{
    class Program
    {
        static void Main(string[] args)
        {
            string hostname = args.Length >= 1 ? args[0] : null;

            // Console.Title = "WCF .Net Core Client"; //not supported on non-windows
            Settings settings = ClientLogic.BuildClientSettings(hostname);

            static void log(string value) => Console.WriteLine(value);
            ClientLogic.InvokeEchoServiceUsingWcf(settings, log);

            string rawSoapResponse = ClientLogic.InvokeEchoServiceUsingWebRequest(settings.basicHttpAddress);
            Console.WriteLine($"Http SOAP Response:\n{rawSoapResponse}");

            Console.WriteLine("Hit enter to exit");
            Console.ReadLine();
        }
    }
}