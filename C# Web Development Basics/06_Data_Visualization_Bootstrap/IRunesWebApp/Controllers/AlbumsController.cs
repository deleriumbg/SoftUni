using System.Linq;
using SIS.HTTP.Requests;
using SIS.HTTP.Responses;
using SIS.WebServer.Results;

namespace IRunesWebApp.Controllers
{
    public class AlbumsController : BaseController
    {
        public IHttpResponse All(IHttpRequest request)
        {
            if (!this.IsAuthenticated(request))
            {
                new RedirectResult("/users/login");
            }

            var albums = this.Context.Albums;
            var listOfAlbums = string.Empty;

            if (albums.Any())
            {
                foreach (var album in albums)
                {
                    var albumHtml = $"<h1>{album.Name}</h1>";
                    listOfAlbums += albumHtml;
                }
                this.ViewBag["albumsList"] = listOfAlbums;
            }
            else
            {
                this.ViewBag["albumsList"] = "There are currently no albums.";
            }

            
            return this.View();
        }
    }
}
