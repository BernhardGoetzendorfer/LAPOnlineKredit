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

        [HttpGet] //Wird aufgerufen, wenn /KreditRahmen geladen wird
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

        [HttpPost] //Wird aufgerufen, wenn /KreditRahmen zu einer anderen View geht. (Wenn das Formular abgeschickt wird)
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


        [HttpGet]
        public ActionResult FinanzielleSituatuion()
        {
            Debug.WriteLine("Get, Konsumkredit, FinanzielleSituation");

            FinanzielleSituationModel finanzModel = new FinanzielleSituationModel() //FinanzielleSituationModel muss jetzt mit Daten gefüttert werden, anschließend kann ich die ID übergeben.
            {
                ID_Kunde = int.Parse(Request.Cookies["idKunde"].Value)
            };

            FinanzielleSituation fSituation = KonsumKreditVerwaltung.FinanzielleSituationLaden(finanzModel.ID_Kunde); //Es wird geschaut ob mit der ID_Kunde schon ein Eintrag in der DAtenbank ist
            if (fSituation != null)
            {
                finanzModel.NettoEinkommen = (double)fSituation.MonatsEinkommen;
                finanzModel.SonstigesEinkommen = (double)fSituation.SonstigeEinkommen;
                finanzModel.Wohnkosten = (double)fSituation.Wohnkosten;
                finanzModel.SonstigeAusgaben = (double)fSituation.SonstigeAusgaben;
                finanzModel.Raten = (double)fSituation.Raten;
            }
            return View(finanzModel);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FinanzielleSituation(FinanzielleSituationModel finanzModel)
        {
            Debug.WriteLine("POST, KonsumKreditController, FinanzielleSituation");

            if(ModelState.IsValid)
            {
                if(KonsumKreditVerwaltung.FinanzielleSituationSpeichern(
                                        finanzModel.NettoEinkommen,
                                        finanzModel.Raten,
                                        finanzModel.Wohnkosten,
                                        finanzModel.SonstigesEinkommen,
                                        finanzModel.SonstigeAusgaben,
                                        finanzModel.ID_Kunde))
                {
                    return RedirectToAction("PersönlicheDaten");
                }
                    
            }

            return View(finanzModel);
        }









































    }
}