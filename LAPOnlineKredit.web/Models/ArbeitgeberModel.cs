using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LAPOnlineKredit.web.Models
{
    public class ArbeitgeberModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Pflichtfeld")]
        [StringLength(30, ErrorMessage = "Maximal 30 Zeichen")]
        [Display(Name = "Der Name Ihrer Firma")]
        public string FirmenName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Pflichtfeld")]
        [Display(Name = "Ihre Angestelltenverhältnis")]
        public int ID_BeschäftigungsArt { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Pflichtfeld")]
        [Display(Name = "Die Branche in der Sie Arbeiten")]
        public int ID_Branche { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Pflichtfeld")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "MM.yyyy")]
        [Display(Name = "Seit wann sind Sie beschäftigt? (MM.YYYY)")]
        public string BeschäftigtSeit { get; set; }

        //In die Listen kommen Später die Lookup Tabellen aus der Datenbank - Dropdown in der View
        public List<BeschaeftigungsArtModel> AlleBeschaeftigungen { get; set; }
        public List<BrancheModel> AlleBranchen { get; set; }

        public int ID_Kunde { get; set; }




    }
}