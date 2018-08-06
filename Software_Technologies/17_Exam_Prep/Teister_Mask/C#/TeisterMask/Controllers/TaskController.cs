namespace TeisterMask.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using System.Collections.Generic;
    using System.Linq;

    public class TaskController : Controller
    {
        private readonly TeisterMaskDbContext dbContext;

        public TaskController(TeisterMaskDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            List<Task> tasks = this.dbContext.Tasks.ToList();
            return View(tasks);
        }

        [HttpGet]
        [Route("/create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("/create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Task task)
        {
            this.dbContext.Add(task);
            this.dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("/edit/{id}")]
        public IActionResult Edit(int id)
        {
            Task task = this.dbContext.Tasks.Find(id);
            return View(task);
        }

        [HttpPost]
        [Route("/edit/{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult EditConfirm(Task taskModel)
        {
            this.dbContext.Tasks.Update(taskModel);
            this.dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
