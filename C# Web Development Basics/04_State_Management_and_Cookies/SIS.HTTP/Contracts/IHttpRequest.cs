using System.Collections.Generic;
using SIS.HTTP.Enums;
using SIS.HTTP.Sessions;

namespace SIS.HTTP.Contracts
{
    public interface IHttpRequest
    {
        string Path { get; }

        string Url { get; }

        Dictionary<string, object> FormData { get; }

        Dictionary<string, object> QueryData { get; }

        IHttpHeaderCollection Headers { get; }

        IHttpCookieCollection Cookies { get; }

        HttpRequestMethod RequestMethod { get; }

        HttpSession Session { get; set; }
    }
}
