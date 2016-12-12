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

        [StringLength(20, ErrorMessage = "max. 20 Zeichen erlaubt")]
        public string IBAN { get; set; }

        [StringLength(20, ErrorMessage = "max. 20 Zeichen erlaubt")]
        public string BIC { get; set; }

    }
}