using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LAPOnlineKredit.Web.Models
{
    public class KontoInformationenModel
    {
       
        [HiddenInput(DisplayValue = false)]
        [Required]
        public int ID_Kunde { get; set; }

        //Wenn der Kunde ein neues Konto möchte, dann True. - Bankname, Iban, Bic ausgegraut.
        //ansonsten false, Bankname iban und bic muss eingegeben werden.
        [Display(Name = "Neues Konto?")]
        public bool NeuesKonto { get; set; }

        [StringLength(20, ErrorMessage = "max. 20 Zeichen erlaubt")]
        [Display(Name = "Name Ihrer Bank")]
        public string Bankname { get; set; }

        [StringLength(20, ErrorMessage = "max. 20 Zeichen erlaubt")]
        [Display(Name = "Ihr IBAN der bestehenden Bank")]
        public string IBAN { get; set; }

        [StringLength(20, ErrorMessage = "max. 20 Zeichen erlaubt")]
        [Display(Name = "Ihr BIC der bestehenden Bank")]
        public string BIC { get; set; }

        

        /*
        [Required(AllowEmptyStrings = false, ErrorMessage = "Pflichtfeld")]
        [DataType(DataType.Currency, ErrorMessage = "Bitte eine Zahl eingeben")]
        [Range(500, 10000, ErrorMessage = "Wert muss zwischen 500 und 10000 liegen")]
        [Display(Name = "Netto-Einkommen (14x jährlich)")]
        public double NettoEinkommen { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Pflichtfeld")]
        [DataType(DataType.Currency, ErrorMessage = "Bitte eine Zahl eingeben")]
        [Range(0, 10000, ErrorMessage = "Wert muss zwischen 0 und 10000 liegen")]
        [Display(Name = "Wohnkosten (Miete, Heizung, Strom)")]
        public double Wohnkosten { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Pflichtfeld")]
        [DataType(DataType.Currency, ErrorMessage = "Bitte eine Zahl eingeben")]
        [Range(0, 10000, ErrorMessage = "Wert muss zwischen 0 und 10000 liegen")]
        [Display(Name = "Einkünfte aus Alimenten, Unterhalte usw.")]
        public double EinkünfteAlimenteUnterhalt { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Pflichtfeld")]
        [DataType(DataType.Currency, ErrorMessage = "Bitte eine Zahl eingeben")]
        [Range(0, 10000, ErrorMessage = "Wert muss zwischen 0 und 10000 liegen")]
        [Display(Name = "Zahlungen für Unterhalt, Alimente usw.")]
        public double UnterhaltsZahlungen { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Pflichtfeld")]
        [DataType(DataType.Currency, ErrorMessage = "Bitte eine Zahl eingeben")]
        [Range(0, 10000, ErrorMessage = "Wert muss zwischen 0 und 10000 liegen")]
        [Display(Name = "Raten-Verpflichtungen")]
        public double RatenVerpflichtungen { get; set; }

        [HiddenInput(DisplayValue = false)]
        [Required]
        public int ID_Kunde { get; set; }
        */
    }
}