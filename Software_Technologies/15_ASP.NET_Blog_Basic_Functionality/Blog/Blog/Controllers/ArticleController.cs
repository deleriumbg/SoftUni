using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Blog.Data;
using Blog.Models;
using Microsoft.AspNetCore.Authorization;

namespace Blog.Controllers
{
    public class ArticleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArticleController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Article
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        // GET: Article/List
        public ActionResult List()
        {
            var articles = _context.Articles.Include(x => x.Author).ToList();
            return View(articles);
        }

        // GET: Article/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Articles
                .Include(a => a.Author)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // GET: Article/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Article/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        public ActionResult Create(Article article)
        {
            if (ModelState.IsValid)
            {
                // get user ID
                var autorId = _context.Users
                    .Where(x => x.UserName == this.User.Identity.Name)
                    .First()
                    .Id;

                // set article author
                article.AuthorId = autorId;

                // save article
                _context.Articles.Add(article);
                _context.SaveChanges();
                
                return RedirectToAction("Index");
            }
            return View(article);
        }

        // GET: Article/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // get article form database
            var article = _context.Articles
                .Where(a => a.Id == id)
                .First();

            // check if article exists
            if (article == null)
            {
                return NotFound();
            }

            // create the view model
            var model = new ArticleViewModel();
            model.Id = article.Id;
            model.Title = article.Title;
            model.Content = article.Content;

            // pass the view model to view
            return View(model);
        }

        // POST: Article/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit(ArticleViewModel model)
        {
            if (ModelState.IsValid)
            {
                // get article
                var article = _context.Articles
                .FirstOrDefault(m => m.Id == model.Id);

                // set new values
                article.Title = model.Title;
                article.Content = model.Content;

                // save changes
                _context.Update(article);
                _context.SaveChanges();

                // redirect to index page
                return RedirectToAction("Index");
            }

            // if model is invalid return the same view
            return View(model);
        }

        // GET: Article/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = _context.Articles
                .Include(a => a.Author)
                .First(m => m.Id == id);

            if (IsUserAutorizedToEdit(article) == false)
            {
                return Forbid();
            }

            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // POST: Article/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            // get article
            var article = _context.Articles
                .Include(a => a.Author)
                .First(m => m.Id == id);

            // check if the article exists
            if (article == null)
            {
                return NotFound();
            }

            // delete article
            _context.Articles.Remove(article);
            _context.SaveChanges();

            // redirect to index
            return RedirectToAction("Index");
        }

        private bool ArticleExists(int id)
        {
            return _context.Articles.Any(e => e.Id == id);
        }

        private bool IsUserAutorizedToEdit(Article article)
        {
            bool isAdmin = this.User.IsInRole("Admin");
            bool isAuthor = article.IsAuthor(this.User.Identity.Name);

            return isAdmin || isAuthor;
        }
    }
}
