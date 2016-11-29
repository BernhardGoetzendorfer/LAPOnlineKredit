using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LAPOnlineKredit.Web.Models
{
    public class FinanzielleSituationModel
    {
     
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
      

    }
}