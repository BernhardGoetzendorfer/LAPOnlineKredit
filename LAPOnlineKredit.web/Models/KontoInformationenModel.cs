using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LAPOnlineKredit.web.Models
{
    public class KontoInformationenModel
    {
        public int ID_Kunde { get; set; }
        public bool NeuesKonto { get; set; }

        [StringLength(20, ErrorMessage = "max. 20 Zeichen erlaubt")]
        public string BankName { get; set; }

        [StringLength(34, ErrorMessage = "max. 34 Zeichen erlaubt")]
        [MinLength(15, ErrorMessage = "min. 15 Zeichen erforderlich")]
        public string IBAN { get; set; }

        [StringLength(15, ErrorMessage = "max. 15 Zeichen erlaubt")]
        [MinLength(10, ErrorMessage = "min. 10 Zeichen erforderlich")]
        public string BIC { get; set; }

        [StringLength(50, ErrorMessage = "max. 50 Zeichen erlaubt")]
        public string KreditKartenInhaber { get; set; }

        [StringLength(23, ErrorMessage = "max. 23 Zeichen erlaubt")]
        public string KreditKartenNummer { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "MM.yyyy")]
        [Display(Name = "gültig bis")]
        public string KreditKartenGültigBis { get; set; }


    }
}