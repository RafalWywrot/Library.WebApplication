using Library.WebApplication.Helpers;
using Library.WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Library.WebApplication.Controllers
{
    public class CategoryController : Controller
    {
        public ActionResult Index()
        {
            var categories = new ApiClient().GetData<List<CategoryViewModel>>("category/GetAll");
            return View(categories);
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(CategoryViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            new ApiClient().PostData<CategoryViewModel>("category/New", model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var category = new ApiClient().GetData<CategoryViewModel>(String.Format("category/GetById?id={0}", id));
            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(CategoryViewModel category)
        {
            new ApiClient().PostData<CategoryViewModel>("category/Update", category);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            new ApiClient().PostData<DeleteById>("category/Remove", new DeleteById() { Id = id });
            return RedirectToAction("Index");
        }
    }
}