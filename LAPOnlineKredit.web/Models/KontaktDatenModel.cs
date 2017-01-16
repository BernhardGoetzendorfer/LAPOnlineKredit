using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LAPOnlineKredit.web.Models
{
    public class KontaktDatenModel
    {
        
        [Display(Name = "Ihr Wohnort")]
        public int IDWohnort { get; set; }

        [Required]
        [Display(Name = "Straße und Hausnummer*")]
        public string Strasse { get; set; }

        [Display(Name = "Emailadresse*")]
        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        
        [Required(ErrorMessage = "Telefonnummer ist erforderlich")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Please enter valid phone no.")]
        [Display(Name = "Telefonnummer*")]
        public string Telefonnummer { get; set; }

        [HiddenInput(DisplayValue = false)]
        [Required]
        public int ID_Kunde { get; set; }


        public List<WohnortModel> AlleWohnorte { get; set; }

    }
}