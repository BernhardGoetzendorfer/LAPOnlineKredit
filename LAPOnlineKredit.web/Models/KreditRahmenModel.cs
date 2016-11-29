using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LAPOnlineKredit.Web.Models
{
    public class KreditRahmenModel
    {
        [Required(ErrorMessage = "Pflichtfeld")]
        [Display(Name = "Gewünschter Betrag")]
        [Range(10000, 100000, ErrorMessage = "Betrag muss zwischen 10.000 € und 100.000 € liegen")]
        public int GewünschterBetrag { get; set; }

        [Required(ErrorMessage = "Pflichtfeld")]
        [Display(Name = "Laufzeit in Monaten")]
        [Range(12, 120, ErrorMessage = "Laufzeit muss zwischen 12 und 120 Monaten liegen")]
        public int Laufzeit { get; set; }
    }
}