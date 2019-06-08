using Library.WebApplication.Helpers;
using Library.WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var grades = new ApiClient().GetData<StudentViewModel>("home/index");
            return View(grades);
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