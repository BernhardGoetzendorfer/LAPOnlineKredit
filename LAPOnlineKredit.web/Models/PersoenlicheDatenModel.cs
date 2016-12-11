    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    namespace LAPOnlineKredit.web.Models
    {
    //Enum fürs Geschlecht
    public enum Geschlecht
    {
        [Display(Name = "Herr")]
        Männlich,
        [Display(Name = "Frau")]
        Weiblich
    }

    public class PersoenlicheDatenModel
    {
        [EnumDataType(typeof(Geschlecht))]
        public Geschlecht Geschlecht { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "max. 50 Zeichen")]
        public string Vorname { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "max. 50 Zeichen")]
        public string Nachname { get; set; }

        [Display(Name = "Titel")]
        public int? ID_Titel { get; set; }

        [DataType(DataType.Date)]
        public DateTime GeburtsDatum { get; set; }

        [Required]
        [Display(Name = "Staatsbürgerschaft")]
        public string ID_Staatsbuergerschaft { get; set; }

        [Display(Name = "Anzahl unterhaltspflichtiger Kinder")]
        public int AnzahlUnterhaltspflichtigeKinder { get; set; }

        [Required]
        [Display(Name = "aktueller Familienstand")]
        public int ID_Familienstand { get; set; }

        [Required]
        [Display(Name = "aktuelle Wohnsituation")]
        public int ID_Wohnart { get; set; }

        [Required]
        [Display(Name = "aktuelle Bildung")]
        public int ID_Bildung { get; set; }

        [Required]
        [Display(Name = "Identifikationstyp")]
        public int ID_Identifikationsart { get; set; }

        [StringLength(20, ErrorMessage = "max. 20 Zeichen erlaubt")]
        [Display(Name = "Identifikations-Nummer")]
        public string IdentifikationsNummer { get; set; }

        [HiddenInput(DisplayValue = false)]
        [Required]
        public int ID_Kunde { get; set; }

        public List<FamilienStandModel> AlleFamilienStandAngaben { get; set; }
        public List<StaatsbuergerschaftsModel> AlleStaatsbuergerschaftsAngaben { get; set; }
        public List<WohnartModel> AlleWohnartAngaben { get; set; }
        public List<BildungsModel> AlleBildungAngaben { get; set; }
        public List<IdentifikationsModel> AlleIdentifikationsAngaben { get; set; }
        public List<TitelModel> AlleTitelAngaben { get; set; }


    }
}
