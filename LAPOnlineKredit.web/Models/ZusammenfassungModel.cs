using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LAPOnlineKredit.web.Models
{
    public class ZusammenfassungModel
    {
        // Allgemein
        public int ID_Kunde { get; set; }


        //KreditRahmen
        public int Betrag { get; set; }

        public int Laufzeit { get; set; }


        //Finanzielle Situtation
        public double Nettoeinkommen { get; set; }

        public double SonstigesEinkommen { get; set; }

        public double Wohnkosten { get; set; }

        public double SonstigeAusgaben { get; set; }

        public double Raten { get; set; }

        //Persönliche Daten

        public string Geschlecht { get; set; }

        public string Vorname { get; set; }

        public string Nachname { get; set; }

        public string Titel { get; set; }

        public DateTime Geburtstag { get; set; }

        public string Staatsbuergerschaft { get; set; }

        public int AnzahlUnterhaltpflichteKinder { get; set; }

        public string familienstand { get; set; }

        public string Wohnart { get; set; }

        public string Bildung { get; set; }

        public string IdentifikationsArt { get; set; }

        public string Identifikationsnummer { get; set; }


        //Arbeitgeber
        public string Firmenname { get; set; }

        public string BeschaeftigungsArt { get; set; }

        public string Branche { get; set; }

        public string BeschaeftigtSeit { get; set; }


        //KontaktDaten
        public string Strasse { get; set; }

        public string Ort { get; set; }

        public string Mail { get; set; }

        public string Email { get; set; }

        public string Telefonnummer { get; set; }

        //KontoInformationen
        public bool NeuesKonto { get; set; }

        public string Bankname { get; set; }

        public string IBAN { get; set; }

        public string BIC { get; set; }

        
    }
}