﻿using SIS.HTTP.Enums;
using SIS.HTTP.Responses.Contracts;
using SIS.WebServer.Results;

namespace SIS.Demo
{
    public class HomeController
    {
        public IHttpResponse Index()
        {
            const string content = "<h1>Hello, World!</h1>";

            return new HtmlResult(content, HttpResponseStatusCode.OK);
        }
    }
}
