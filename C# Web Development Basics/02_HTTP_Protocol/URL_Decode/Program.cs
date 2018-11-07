using System;
using System.Net;

namespace URL_Decode
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = Console.ReadLine();
            string decodedUrl = WebUtility.UrlDecode(url);
            Console.WriteLine(decodedUrl);
        }
    }
}
