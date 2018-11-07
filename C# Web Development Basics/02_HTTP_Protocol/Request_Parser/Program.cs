using System;
using System.Collections.Generic;
using System.Net;

namespace Request_Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            var routes = new Dictionary<string, HashSet<string>>();

            string input = Console.ReadLine();
            while (input != "END")
            {
                var splittedInput = input.Split("/", StringSplitOptions.RemoveEmptyEntries);

                string endPoint = $"/{splittedInput[0]}";
                string httpMethod = splittedInput[1].ToUpper();

                if (!routes.ContainsKey(httpMethod))
                {
                    routes.Add(httpMethod, new HashSet<string>());
                }

                routes[httpMethod].Add(endPoint);
                input = Console.ReadLine();
            }

            string request = Console.ReadLine();
            string[] reqParts = request.Split();

            string requestMethod = reqParts[0];
            string requestEndPoint = reqParts[1];
            string requestProtocol = reqParts[2];

            int responseCode = (int)HttpStatusCode.NotFound;
            string responseStatusText = "NotFound";

            if (routes.ContainsKey(requestMethod) && routes[requestMethod].Contains(requestEndPoint))
            {
                responseCode = (int)HttpStatusCode.OK;
                responseStatusText = "OK";
            }

            Console.WriteLine($"{requestProtocol} {responseCode} {responseStatusText}");
            Console.WriteLine($"Content-Length: {responseStatusText.Length}");
            Console.WriteLine("Content-Type: text/plain\r\n");
            Console.WriteLine(responseStatusText);
        }
    }
}
