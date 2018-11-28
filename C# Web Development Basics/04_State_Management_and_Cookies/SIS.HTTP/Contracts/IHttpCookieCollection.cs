using SIS.HTTP.Cookies;

namespace SIS.HTTP.Contracts
{
    public interface IHttpCookieCollection
    {
        void Add(HttpCookie cookie);

        bool ContainsCookie(string key);

        HttpCookie GetCookie(string key);

        bool HasCookies();
    }
}
