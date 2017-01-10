using LAPOnlineKredit.logic;
using LAPOnlineKredit.web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LAPOnlineKredit.web.Controllers
{
    public class AdministrationController : Controller
    {
        [HttpGet]
        public ActionResult Anmelden()
        {
            Debug.WriteLine("GET - Administration - Anmelden");

            return View();
        }

        [HttpGet]
        
        public ActionResult KreditAnträge()
        {
            Debug.WriteLine("GET - Administration - KreditAnträge");

            /// lade aus der DB die letzten 10 Kreditanträge
            /// 

            List<Kunde> alleKunden = KonsumKreditVerwaltung.KundenLaden();
            List<ZusammenfassungModel> alleKundenModel = new List<ZusammenfassungModel>();

            foreach (var aktKunde in alleKunden)
            {
                ZusammenfassungModel model = new ZusammenfassungModel();

                model.ID_Kunde = aktKunde.ID;

                model.Betrag = aktKunde.Kredit.Betrag;
                model.Laufzeit = aktKunde.Kredit.Laufzeit;

                model.Nettoeinkommen = (double)aktKunde.FinanzielleSituation.MonatsEinkommen.Value;
                model.Wohnkosten = (double)aktKunde.FinanzielleSituation.Wohnkosten.Value;
                model.SonstigesEinkommen = (double)aktKunde.FinanzielleSituation.SonstigeEinkommen.Value;
                model.SonstigeAusgaben = (double)aktKunde.FinanzielleSituation.SonstigeAusgaben.Value;
                model.Raten = (double)aktKunde.FinanzielleSituation.Raten.Value;

                model.Geschlecht = aktKunde.Geschlecht == "m" ? "Herr" : "Frau";
                model.Vorname = aktKunde.Vorname;
                model.Nachname = aktKunde.Nachname;
                model.Titel = aktKunde.Titel?.Bezeichnung;
                model.Geburtstag = DateTime.Now;
                model.Staatsbuergerschaft = aktKunde.Land?.Bezeichnung;
                model.familienstand = aktKunde.Familienstand?.Bezeichnung;
                model.Wohnart = aktKunde.Wohnart?.Bezeichnung;
                model.Bildung = aktKunde.Abschluss?.Bezeichnung;
                model.IdentifikationsArt = aktKunde.Identifikationsart?.Bezeichnung;
                model.Identifikationsnummer = aktKunde.Identifikationsnummer;

                model.Firmenname = aktKunde.Arbeitgeber?.Firmenname;
                model.BeschaeftigungsArt = aktKunde.Arbeitgeber?.BeschaeftigungsArt?.Bezeichnung;
                model.Branche = aktKunde.Arbeitgeber?.Branche?.Bezeichnung;
                model.BeschaeftigtSeit = aktKunde.Arbeitgeber?.BeschaeftigtSeit.Value.ToShortDateString();

                model.Strasse = aktKunde.Kontakt?.Strasse;
                model.Mail = aktKunde.Kontakt?.eMail;
                model.Telefonnummer = aktKunde.Kontakt?.Telefonnummer;

                model.NeuesKonto = (bool)aktKunde.Konto?.IstKunde.Value;
                model.Bankname = aktKunde.Konto?.Bankname;
                model.IBAN = aktKunde.Konto?.IBAN;
                model.BIC = aktKunde.Konto?.BIC;

                alleKundenModel.Add(model);
            }

            return View(alleKundenModel);
        
    }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Anmelden(AnmeldeModel model)
        {
            Debug.WriteLine("POST - Administration - Anmelden");
           
            
            //if (ModelState.IsValid)
            //{
                if (model.Benutzername == "admin"
                    && model.Passwort == "123user!")
                {
                    //FormsAuthentication.SetAuthCookie("admin", true);
                    return RedirectToAction("KreditAnträge");
                }
                else
                {
                    ModelState.AddModelError("Benutzername", "Ungültiger Benutzername/Passwort!");
                }
            //}
            
            return View();
        }

    }
}