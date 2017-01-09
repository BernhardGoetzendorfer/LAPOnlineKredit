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
        [Required]
        [Display(Name = "Ihr Wohnort")]
        public int IDWohnort { get; set; }

        [Required]
        [Display(Name = "Straße und Hausnummer")]
        public string Strasse { get; set; }

        [Display(Name = "Emailadresse")]
        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        /* [DataType(DataType.EmailAddress, ErrorMessage ="hey")] */
        public string Email { get; set; }

        [Required]
        [Display(Name = "Telefonnummer")]
        public string Telefonnummer { get; set; }

        [HiddenInput(DisplayValue = false)]
        [Required]

        public int ID_Kunde { get; set; }


        public List<WohnortModel> AlleWohnorte { get; set; }

    }
}