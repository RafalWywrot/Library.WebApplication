using Library.WebApplication.Helpers;
using Library.WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Library.WebApplication.Controllers
{
    public class PublishHouseController : Controller
    {
        public ActionResult Index()
        {
            var publishHouses = new ApiClient().GetData<List<PublishHouseViewModel>>("publishHouse/GetAll");
            return View(publishHouses);
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(PublishHouseViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            new ApiClient().PostData<PublishHouseViewModel>("publishHouse/New", model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var artist = new ApiClient().GetData<PublishHouseViewModel>(String.Format("publishHouse/GetById?id={0}", id));
            return View(artist);
        }

        [HttpPost]
        public ActionResult Edit(PublishHouseViewModel publishHouse)
        {
            if (!ModelState.IsValid)
                return View(publishHouse);

            new ApiClient().PostData<PublishHouseViewModel>("publishHouse/Update", publishHouse);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            new ApiClient().PostData<DeleteById>("publishHouse/Remove", new DeleteById() { Id = id });
            return RedirectToAction("Index");
        }
    }
}