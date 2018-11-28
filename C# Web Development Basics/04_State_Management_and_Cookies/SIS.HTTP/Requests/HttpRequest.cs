using SIS.HTTP.Contracts;
using SIS.HTTP.Cookies;
using SIS.HTTP.Sessions;

namespace SIS.HTTP.Requests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Common;
    using Enums;
    using Exceptions;
    using Headers;


    public class HttpRequest : IHttpRequest
    {
        public HttpRequest(string requestString)
        {
            this.FormData = new Dictionary<string, object>();
            this.QueryData = new Dictionary<string, object>();
            this.Headers = new HttpHeaderCollection();
            this.Cookies = new HttpCookieCollection();
            ParseRequest(requestString);
        }

        public string Path { get; private set; }

        public string Url { get; private set; }

        public Dictionary<string, object> FormData { get; }

        public Dictionary<string, object> QueryData { get; }

        public IHttpHeaderCollection Headers { get; }

        public IHttpCookieCollection Cookies { get; }

        public HttpRequestMethod RequestMethod { get; private set; }

        public HttpSession Session { get; set; }
        
        private void ParseRequest(string requestString)
        {
            string[] requestContent = requestString.Split(new []{"\r\n"}, StringSplitOptions.None);
            string[] requestLine = requestContent[0].Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (!IsValidRequestLine(requestLine))
            {
                throw new BadRequestException();
            }

            ParseRequestMethod(requestLine);
            ParseRequestUrl(requestLine);
            ParseRequestPath();

            ParseHeaders(requestContent.Skip(1).ToArray());
            bool requestHasBody = requestContent.Last() != string.Empty;
            ParseCookies();
            ParseRequestParameters(requestContent[requestContent.Length - 1], requestHasBody);
        }

        private void ParseCookies()
        {
            if (!this.Headers.ContainsHeader(GlobalConstants.CookieRequestHeaderName))
            {
                return;
            }

            var cookiesRaw = this.Headers.GetHeader(GlobalConstants.CookieRequestHeaderName).ToString();
            var cookies = cookiesRaw.Split("; ", 2, StringSplitOptions.RemoveEmptyEntries);

            foreach (var cookie in cookies)
            {
                var cookieKeyValuePair = cookie.Split('=', StringSplitOptions.RemoveEmptyEntries);
                if (cookieKeyValuePair.Length != 2)
                {
                    throw new BadRequestException();
                }

                var cookieName = cookieKeyValuePair[0];
                var cookieValue = cookieKeyValuePair[1];
                this.Cookies.Add(new HttpCookie(cookieName, cookieValue));
            }
        }

        private static bool IsValidRequestLine(string[] requestLine)
        {
            return requestLine.Length == 3 && requestLine[2] == GlobalConstants.HttpOneProtocolFragment;
        }

        private static bool IsValidRequestQueryString(string queryString, string[] queryParameters)
        {
            return !string.IsNullOrEmpty(queryString) && queryParameters.Length > 0;
        }

        private void ParseRequestMethod(string[] requestLine)
        {
            if (Enum.TryParse(requestLine[0], true, out HttpRequestMethod method))
            {
                RequestMethod = method;
            }
            else
            {
                throw new BadRequestException();
            }
        }

        private void ParseRequestUrl(string[] requestLine)
        {
            if (!requestLine.Any())
            {
                throw new BadRequestException();
            }

            Url = requestLine[1];
        }

        private void ParseRequestPath()
        {
            string path = Url.Split(new[] { '?' }, StringSplitOptions.RemoveEmptyEntries)[0];

            if (string.IsNullOrEmpty(path))
            {
                throw new BadRequestException();
            }

            Path = path;
        }

        private void ParseHeaders(string[] requestContent)
        {
            if (!requestContent.Any())
            {
                throw new BadRequestException();
            }

            foreach (string line in requestContent)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    return;
                }

                string[] parts = line.Split(new[] { ": " }, StringSplitOptions.RemoveEmptyEntries);
                HttpHeader header = new HttpHeader(parts[0], parts[1]);
                Headers.Add(header);
            }

            if (!Headers.ContainsHeader(GlobalConstants.HostHeaderKey))
            {
                throw new BadRequestException();
            }
        }

        private void ParseQueryParameters()
        {
            string[] query = Url.Split(new[] { '?' }, StringSplitOptions.RemoveEmptyEntries);

            if (query.Length <= 1)
            {
                return;
            }

            string queryString = query[1];
            if (query.Contains("#"))
            {
                queryString = query[1].Split(new[] { '#' }, StringSplitOptions.RemoveEmptyEntries)[0];
            }

            if (string.IsNullOrEmpty(queryString))
            {
                throw new BadRequestException();
            }

            string[] queryParameters = queryString.Split(new[] { '&' }, StringSplitOptions.RemoveEmptyEntries);
            IsValidRequestQueryString(queryString, queryParameters);

            ExtractRequestParameters(queryParameters, QueryData);
        }

        private void ParseFormDataParameters(string formData)
        {
            if (string.IsNullOrEmpty(formData))
            {
                return;
            }

            string[] requestBodyParts = formData.Split(new[] { '&' }, StringSplitOptions.RemoveEmptyEntries);
            ExtractRequestParameters(requestBodyParts, FormData);
        }

        private void ExtractRequestParameters(string[] requestBodyParts, Dictionary<string, object> parametersCollection)
        {
            foreach (string[] parts in requestBodyParts.Select(pair => pair.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries)))
            {
                if (parts.Length != 2)
                {
                    throw new BadRequestException();
                }

                parametersCollection.Add(parts[0], parts[1]);
            }
        }

        private void ParseRequestParameters(string formData, bool requestHasBody)
        {
            ParseQueryParameters();
            if (requestHasBody)
            {
                ParseFormDataParameters(formData);
            }
        }
    }
}
