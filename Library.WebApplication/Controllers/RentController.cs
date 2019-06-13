using Library.WebApplication.Helpers;
using Library.WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Library.WebApplication.Controllers
{
    public class RentController : Controller
    {
        public ActionResult Index()
        {
            var rents = new ApiClient().GetData<List<RentViewModel>>("rent/GetAll");
            return View(rents);
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(RentViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            new ApiClient().PostData<RentViewModel>("rent/New", model);
            return RedirectToAction("Index");
        }
    }
}