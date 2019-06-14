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
            //pobierz wszystkie wypozyczenia
            var rents = new ApiClient().GetData<List<RentViewModel>>("rent/GetAll");
            return View(rents);
        }
        [HttpGet]
        public ActionResult Add()
        {
            //pobierz wszystkie ksiazki
            //stworz model z lista tych ksiazek
            var model = new NewRentViewModel()
            {
                Books = new List<BookViewModel>()
                {
                    new BookViewModel { Title = "aa" },
                    new BookViewModel { Title = "aa" },
                    new BookViewModel { Title = "aa" },
                }.ToSelectListItems(x => x.Id, x => x.Title),
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Add(NewRentViewModel model)
        {
            //jesli zostala wybrana ksiazka to wyslij do Api [bookId, name, surname , ...]
            if (!ModelState.IsValid)
                return View(model);

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