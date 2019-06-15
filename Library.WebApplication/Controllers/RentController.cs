using Library.WebApplication.Helpers;
using Library.WebApplication.Models;
using System.Collections.Generic;
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
            var availableBooks = new ApiClient().GetData<List<BookViewModel>>("book/GetAvailableBooks");
            var model = new NewRentViewModel()
            {
                Books = availableBooks.ToSelectListItems(x => x.Id, x => x.Title) 
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Add(NewRentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Books = new ApiClient().GetData<List<BookViewModel>>("book/GetAvailableBooks").ToSelectListItems(x => x.Id, x => x.Title);
                return View(model);
            }

            new ApiClient().PostData<NewRentViewModel>("rent/New", model);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult ReturnBook(int bookId)
        {
            new ApiClient().PostData<DeleteById>("rent/Remove", new DeleteById() { Id = bookId });
            return RedirectToAction("Index");
        }
    }
}