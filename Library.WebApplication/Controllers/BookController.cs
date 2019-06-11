using Library.WebApplication.Helpers;
using Library.WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Library.WebApplication.Controllers
{
    public class BookController : Controller
    {
        public ActionResult Index()
        {
            var books = new ApiClient().GetData<List<BookViewModel>>("book/GetAll");
            return View(books);
        }
        [HttpGet]
        public ActionResult Add()
        {
            var model = new BookEditViewModel();
            SetBookDropdownOptions(model);
            return View(model);
        }
        [HttpPost]
        public ActionResult Add(BookEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                SetBookDropdownOptions(model);
                return View(model);
            }

            new ApiClient().PostData<BookEditViewModel>("book/New", model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var book = new ApiClient().GetData<BookEditViewModel>(String.Format("book/GetById?id={0}", id));
            SetBookDropdownOptions(book);
            return View(book);
        }

        [HttpPost]
        public ActionResult Edit(BookEditViewModel book)
        {
            if (!ModelState.IsValid)
            {
                SetBookDropdownOptions(book);
                return View(book);
            }

            new ApiClient().PostData<BookEditViewModel>("book/Update", book);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            new ApiClient().PostData<DeleteById>("book/Remove", new DeleteById() { Id = id });
            return RedirectToAction("Index");
        }
        private void SetBookDropdownOptions(BookEditViewModel model)
        {
            var publishHouses = new ApiClient().GetData<List<PublishHouseViewModel>>("publishHouse/GetAll");
            var artists = new ApiClient().GetData<List<ArtistViewModel>>("artist/GetAll");
            var categories = new ApiClient().GetData<List<CategoryViewModel>>("category/GetAll");
            model.PublishHouses = publishHouses.ToSelectListItems(x => x.Id, x => x.Name);
            model.Artists = artists.ToSelectListItems(x => x.Id, x => x.FullName);
            model.Categories = categories.ToSelectListItems(x => x.Id, x => x.Name);
        }
    }
}