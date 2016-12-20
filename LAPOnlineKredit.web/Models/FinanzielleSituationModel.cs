using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LAPOnlineKredit.web.Models
{
    public class FinanzielleSituationModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Pflichtfeld")]
        [DataType(DataType.Currency, ErrorMessage = "Bitte Ihr Monatseinkommen angeben.")]
        [Range(500, 10000, ErrorMessage = "Wert muss zwischen 500€ und 10.000€ liegen")]
        [Display(Name = "Ihr Netto Monatseinkommen(14x)")]
        public double NettoEinkommen { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Pflichtfeld")]
        [DataType(DataType.Currency, ErrorMessage = "Bitte Ihre Wohnkosten angeben.")]
        [Range(0, 10000, ErrorMessage = "Der Betrag muss zwischen 0€ und 10.000€ liegen.")]
        [Display(Name = "Wohnkosten (Miete, Heizung, Strom)")]
        public double Wohnkosten { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Pflichtfeld")]
        [DataType(DataType.Currency, ErrorMessage = "Bitte Ihre Sonstigen Einkünfte angeben.")]
        [Range(0, 10000, ErrorMessage = "Der Betrag muss zwischen 0€ und 10.000€ liegen.")]
        [Display(Name = "Einkünfte aus Alimenten, Unterhalte usw.")]
        public double SonstigesEinkommen { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Pflichtfeld")]
        [DataType(DataType.Currency, ErrorMessage = "Bitte Ihre Sonstigen Einkünfte angeben.")]
        [Range(0, 10000, ErrorMessage = "Der Betrag muss zwischen 0€ und 10.000€ liegen.")]
        [Display(Name = "Zahlungen für Unterhalt, Alimente usw.")]
        public double SonstigeAusgaben { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Pflichtfeld")]
        [DataType(DataType.Currency, ErrorMessage = "Bitte Ihre Monatlichen Raten angeben.")]
        [Range(0, 10000, ErrorMessage = "Der Betrag muss zwischen 0€ und 10.000€ liegen.")]
        [Display(Name = "Raten-Verpflichtungen")]
        public double Raten { get; set; }

        [HiddenInput(DisplayValue = false)]
        [Required]
        public int ID_Kunde { get; set; }





    }
}