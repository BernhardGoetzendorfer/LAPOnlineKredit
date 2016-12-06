using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LAPOnlineKredit.web.Models;
using LAPOnlineKredit.logic;

namespace LAPOnlineKredit.web.Controllers
{
    public class KonsumKreditController : Controller
    {

        [HttpGet]
        public ActionResult KreditRahmen()
        {
            Debug.WriteLine("GET - KonsumKredit - KreditRahmen");

            KreditRahmenModel kreditModel = new KreditRahmenModel()
            {
                //Standartwerte für den Slider
                GewünschterBetrag = 50000,
                Laufzeit = 50
            };

            int id = -1; // ID wird mit null initialisiert
            if (Request.Cookies["idKunde"] != null && int.TryParse(Request.Cookies["idKunde"].Value, out id)) // Es wird geschaut ob in den Cookies schon eine idKunde vorhanden ist - mit der dann weitergearbeitet wird.
            {
                /// Wenn er die ID im Cookie gefunden hat werden die Daten daraus geladen und angezeigt.
                Kredit wunschKredit = KonsumKreditVerwaltung.KreditRahmenLaden(id);
                kreditModel.GewünschterBetrag = wunschKredit.Betrag; //Es werden die bereits vorhandenen Daten von der DB in das kreditModel geladen.
                kreditModel.Laufzeit = wunschKredit.Laufzeit;
            }
            return View(kreditModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //Notwendig für den HttpCookie
        public ActionResult KreditRahmen(KreditRahmenModel kreditModel)
        {
            Debug.WriteLine("POST, KonsumKreditController, KreditRahmen");

            if (ModelState.IsValid) // Schaut ob im kreditModel alles Gültig ist. (bzw ob irgendwelche error dort aufgetaucht sind.)
            {
                if (Request.Cookies["idkunde"] == null) //Wird ausgeführt wenn es kein "bestehender Kunde" ist.
                {
                    Kunde neuerKunde = KonsumKreditVerwaltung.ErzeugeKunde(); //Erzeuge neuen Kunden.

                    if (neuerKunde != null && KonsumKreditVerwaltung.KreditRahmenSpeichern(kreditModel.GewünschterBetrag, kreditModel.Laufzeit, neuerKunde.ID))
                    {
                        Response.Cookies.Add(new HttpCookie("idkunde", neuerKunde.ID.ToString())); //Nimm die idkunde und speichere diese in die cookies.
                        return RedirectToAction("FinanzielleSituation");
                    }

                }
                else //sonst nimm den bestehenden Kunden und bring ihn zur FinanziellenSituation
                {
                    int idkunde = int.Parse(Request.Cookies["idkunde"].Value);

                    if (KonsumKreditVerwaltung.KreditRahmenSpeichern(kreditModel.GewünschterBetrag, kreditModel.Laufzeit, idkunde))
                    {
                        return RedirectToAction("FinanzielleSituation");
                    }
                }
            }
            return View(kreditModel); //Falls das Modelstate nicht Gültig ist bleib hier und forder erneute Dateneingabe
        } 






















































    }
}