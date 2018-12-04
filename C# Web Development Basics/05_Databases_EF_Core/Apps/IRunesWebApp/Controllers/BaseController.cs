using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using IRunesWebApp.Data;
using Services;
using SIS.HTTP.Cookies;
using SIS.HTTP.Enums;
using SIS.HTTP.Requests;
using SIS.HTTP.Responses;
using SIS.WebServer.Results;

namespace IRunesWebApp.Controllers
{
    public abstract class BaseController
    {
        private const string RootDirectoryRelativePath = "../../../";
        private const string ViewsFolderName = "Views";
        private const string HtmlFileExtension = ".html";

        private readonly UserCookieService cookieService;
        protected IRunesDbContext Context { get; set; }

        protected BaseController()
        {
            this.Context = new IRunesDbContext();
            this.cookieService = new UserCookieService();
            this.ViewBag = new Dictionary<string, string>();
        }

        protected IDictionary<string, string> ViewBag { get; set; }

        private string GetCurrentControllerName() => this.GetType().Name.Replace("Controller", string.Empty);

        public void SignInUser(string username, IHttpRequest request)
        {
            request.Session.AddParameter("username", username);
            var userCookieValue = this.cookieService.GetUserCookie(username);
            request.Cookies.Add(new HttpCookie("IRunes_auth", userCookieValue));
        }

        protected IHttpResponse View([CallerMemberName] string viewName = "")
        {
            string filePath =
                $"{RootDirectoryRelativePath}/{ViewsFolderName}/{this.GetCurrentControllerName()}/{viewName}{HtmlFileExtension}";

            if (!File.Exists(filePath))
            {
                return new BadRequestResult($"View {viewName} not found!", HttpResponseStatusCode.NotFound);
            }

            var fileContent = File.ReadAllText(filePath);
            foreach (var viewBagKey in this.ViewBag.Keys)
            {
                var dynamicDataPlaceholder = $"{{{{viewBagKey}}}}";
                if (fileContent.Contains(dynamicDataPlaceholder))
                {
                    fileContent = fileContent.Replace(dynamicDataPlaceholder, this.ViewBag[viewBagKey]);
                }
            }

            var response = new HtmlResult(fileContent, HttpResponseStatusCode.Ok);
            return response;
        }

        public bool IsAuthenticated(IHttpRequest request)
        {
            return request.Session.ContainsParameter("username");
        }
    }
}
