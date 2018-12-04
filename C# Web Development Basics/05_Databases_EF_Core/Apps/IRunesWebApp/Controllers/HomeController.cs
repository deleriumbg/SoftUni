using SIS.HTTP.Requests;
using SIS.HTTP.Responses;

namespace IRunesWebApp.Controllers
{
    public class HomeController : BaseController
    {
        public IHttpResponse Index(IHttpRequest request)
        {
            if (IsAuthenticated(request))
            {
                var username = request.Session.GetParameter("username");
                this.ViewBag["username"] = username.ToString();
                return this.View("IndexLoggedIn");
            }

            return this.View();
        }
    }
}
