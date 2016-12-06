using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LAPOnlineKredit.web.Models
{
    public class KreditRahmenModel
    {
        // Wird jetzt beim Controller - KreditRahmen benötigt. 
        // 
        [Required(ErrorMessage = "Pflichtfeld")]
        [Display(Name = "Ihr Gewünschter Betrag")]
        [Range(10000, 100000, ErrorMessage = "Der Betrag muss zwischen 10.000€ - 100.000€ liegen.")]
        public int GewünschterBetrag { get; set; }

        [Required(ErrorMessage = "Pflichtfeld")]
        [Display(Name = "Kreditlaufzeit")]
        [Range(12, 120, ErrorMessage = "Die Laufzeit muss mindestens 12 Monate und maximal 120 Monate lang sein.")]
        public int Laufzeit { get; set; }


    }
}