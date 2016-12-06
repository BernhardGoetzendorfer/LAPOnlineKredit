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

        // GET: KonsumKredit
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



























































    }
}