using Library.WebApplication.Helpers;
using Library.WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Library.WebApplication.Controllers
{
    public class ArtistController : Controller
    {
        public ActionResult Index()
        {
            var artists = new ApiClient().GetData<List<ArtistViewModel>>("artist/GetAll");
            return View(artists);
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(ArtistViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            new ApiClient().PostData<ArtistViewModel>("artist/New", model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var artist = new ApiClient().GetData<ArtistViewModel>(String.Format("artist/GetById?id={0}", id));
            return View(artist);
        }

        [HttpPost]
        public ActionResult Edit(ArtistViewModel artist)
        {
            if (!ModelState.IsValid)
                return View(artist);

            new ApiClient().PostData<ArtistViewModel>("artist/Update", artist);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            new ApiClient().PostData<DeleteById>("artist/Remove", new DeleteById() { Id = id });
            return RedirectToAction("Index");
        }
    }
}