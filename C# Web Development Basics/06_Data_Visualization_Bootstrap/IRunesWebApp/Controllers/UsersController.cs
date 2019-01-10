using System;
using System.Linq;
using IRunesWebApp.Models;
using Services;
using SIS.HTTP.Enums;
using SIS.HTTP.Requests;
using SIS.HTTP.Responses;
using SIS.WebServer.Results;

namespace IRunesWebApp.Controllers
{
    public class UsersController : BaseController
    {
        private readonly HashService hashService;
        
        public UsersController()
        {
            this.hashService = new HashService();
        }

        public IHttpResponse Login(IHttpRequest request) => this.View();

        public IHttpResponse LoginPost(IHttpRequest request)
        {
            var username = request.FormData["username"].ToString();
            var password = request.FormData["password"].ToString();

            var hashedPassword = this.hashService.Hash(password);
            var user = this.Context.Users.FirstOrDefault(u =>
                u.Username == username && u.HashedPassword == hashedPassword);

            if (user == null)
            {
                return new RedirectResult("/users/login");
            }
            this.SignInUser(username, request);
            return new RedirectResult("/");
        }

        public IHttpResponse Register(IHttpRequest request) => this.View();

        public IHttpResponse RegisterPost(IHttpRequest request)
        {
            var userName = request.FormData["username"].ToString().Trim();
            var password = request.FormData["password"].ToString();
            var confirmPassword = request.FormData["confirmPassword"].ToString();
            var email = request.FormData["email"].ToString();

            // Validate
            if (password != confirmPassword)
            {
                return new BadRequestResult("Passwords do not match.", HttpResponseStatusCode.SeeOther);
            }

            // Hash password
            var hashedPassword = this.hashService.Hash(password);

            // Create user
            var user = new User
            {
                Username = userName,
                HashedPassword = hashedPassword,
                Email = email
            };
            this.Context.Users.Add(user);

            try
            {
                this.Context.SaveChanges();
            }
            catch (Exception e)
            {
                return new BadRequestResult(e.Message, HttpResponseStatusCode.InternalServerError);
            }

            // Sign in user
            this.SignInUser(userName, request);

            // Redirect
            return new RedirectResult("/");
        }
    }
}
