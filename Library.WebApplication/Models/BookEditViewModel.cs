using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.WebApplication.Models
{
    public class BookEditViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Tytuł")]
        public string Title { get; set; }
        [Display(Name = "Ilość stron")]
        public int PageCount { get; set; }
        [Display(Name = "Rok wydania")]
        public int Year { get; set; }
        public int PublishHouseId { get; set; }
        public int ArtistId { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<SelectListItem> PublishHouses { get; set; }
        public IEnumerable<SelectListItem> Artists { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}