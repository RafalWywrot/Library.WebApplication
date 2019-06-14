using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.WebApplication.Models
{
    public class RentViewModel : User
    {
        public int Id { get; set; }
        public BookViewModel Book { get; set; }
        public BookEditViewModel BookEdit { get; set; }
        public bool Available { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
    }
}