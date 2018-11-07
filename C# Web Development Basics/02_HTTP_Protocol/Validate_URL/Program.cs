using System;
using System.Net;
using System.Text;

namespace Validate_URL
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Uri uri = new Uri(WebUtility.UrlDecode(Console.ReadLine()));

                StringBuilder result = new StringBuilder();

                if (!uri.IsWellFormedOriginalString())
                {
                    result.AppendLine("Invalid URL");
                }

                bool validHttp = uri.Port == 80 && uri.Scheme == "http";
                bool validHttps = uri.Port == 443 && uri.Scheme == "https";

                if (validHttps || validHttp)
                {
                    result.AppendLine($"Protocol: {uri.Scheme}");
                    result.AppendLine($"Host: {uri.DnsSafeHost}");
                    result.AppendLine($"Port: {uri.Port}");
                    string path = WebUtility.UrlDecode(uri.LocalPath);
                    result.AppendLine($"Path: {path}");

                    string query = WebUtility.UrlDecode(uri.Query);
                    if (uri.Query != string.Empty)
                    {
                        result.AppendLine($"Query: {query.TrimStart('?')}");
                    }

                    string fragment = WebUtility.UrlDecode(uri.Fragment);
                    if (uri.Fragment != string.Empty)
                    {
                        result.AppendLine($"Fragment: {fragment.TrimStart('#')}");
                    }
                }
                else
                {
                    result.AppendLine("Invalid URL");
                }

                Console.WriteLine(result.ToString().Trim());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid URL");
            }
        }
    }
}
