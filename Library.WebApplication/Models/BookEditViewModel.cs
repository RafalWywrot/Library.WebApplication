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
        [Required]
        [Display(Name = "Tytuł")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Ilość stron")]
        public int PageCount { get; set; }
        [Display(Name = "Rok wydania")]
        [Required]
        public int Year { get; set; }
        [Required]
        [Display(Name = "Wydawnictwo")]
        public int PublishHouseId { get; set; }
        [Required]
        [Display(Name = "Autor")]
        public int ArtistId { get; set; }
        [Required]
        [Display(Name = "Kategoria")]
        public int CategoryId { get; set; }
        public IEnumerable<SelectListItem> PublishHouses { get; set; }
        public IEnumerable<SelectListItem> Artists { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}