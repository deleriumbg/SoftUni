using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sumator.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Calculate(string numA, string numB)
        {
            ViewBag.NumberA = numA;
            ViewBag.NumberB = numB;
            try
            {
                var sum = decimal.Parse(numA) + decimal.Parse(numB);
                ViewBag.Sum = sum;
            }
            catch (Exception)
            {
                ViewBag.Sum = "КОР!";
            }
            
            
            return View("Index");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}