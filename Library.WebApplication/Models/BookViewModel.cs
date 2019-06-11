using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library.WebApplication.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Tytuł")]
        public string Title { get; set; }
        [Display(Name = "Ilość stron")]
        public int PageCount { get; set; }
        [Display(Name = "Rok wydania")]
        public int Year { get; set; }
        public CategoryViewModel Category { get; set; }
        public PublishHouseViewModel PublishHouse { get; set; }
        public ArtistViewModel Artist { get; set; }
    }
}