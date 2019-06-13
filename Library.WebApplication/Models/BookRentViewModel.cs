using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.WebApplication.Models
{
    public class BookRentViewModel
    {
        public BookViewModel Book { get; set; }
        public bool Available { get; set; }
    }
}