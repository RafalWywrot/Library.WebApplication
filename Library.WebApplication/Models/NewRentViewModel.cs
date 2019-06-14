using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.WebApplication.Models
{
    public class NewRentViewModel : User
    {
        public IEnumerable<SelectListItem> Books { get; set; }
        [Required]
        public int BookId { get; set; }
    }
}