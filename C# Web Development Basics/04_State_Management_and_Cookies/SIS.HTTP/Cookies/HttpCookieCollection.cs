using System;
using System.Collections.Generic;
using System.Linq;
using SIS.HTTP.Contracts;

namespace SIS.HTTP.Cookies
{
    public class HttpCookieCollection : IHttpCookieCollection
    {
        private readonly IDictionary<string, HttpCookie> cookies;

        public HttpCookieCollection()
        {
            this.cookies = new Dictionary<string, HttpCookie>();
        }

        public void Add(HttpCookie cookie)
        {
            if (cookie == null)
            {
                throw new ArgumentNullException();
            }
            this.cookies.Add(cookie.Key, cookie);
        }

        public bool ContainsCookie(string key)
        {
            return this.cookies.ContainsKey(key);
        }

        public HttpCookie GetCookie(string key)
        {
            return !this.ContainsCookie(key) ? null : this.cookies[key];
        }

        public bool HasCookies()
        {
            return this.cookies.Any();
        }

        public override string ToString()
        {
            return string.Join(", ", this.cookies.Values);
        }
    }
}
