using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library.WebApplication.Models
{
    public class ArtistViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Imię")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Nazwisko")]
        public string Surname { get; set; }

        public string FullName {
            get
            {
                return string.Format("{0} {1}", Name, Surname);
            }
        }
    }
}