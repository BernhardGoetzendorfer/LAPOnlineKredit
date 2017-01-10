using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LAPOnlineKredit.web.Models
{
    public class AnmeldeModel
    {

        [StringLength(20, ErrorMessage = "max. 20 Zeichen erlaubt.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Pflichtfeld")]
        public string Benutzername { get; set; }

        [StringLength(20, ErrorMessage = "max. 20 Zeichen erlaubt.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Pflichtfeld")]
        [DataType(DataType.Password)]
        public string Passwort { get; set; }


    }
}