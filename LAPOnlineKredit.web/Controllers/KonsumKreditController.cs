using LAPOnlineKredit.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LAPOnlineKredit.logic;


namespace LAPOnlineKredit.Web.Controllers
{
    public class KonsumKreditController : Controller
    {
        // GET: KonsumKredit
        [HttpGet]
        public ActionResult KreditRahmen()
        {
            Debug.WriteLine("GET - KonsumKredit - KreditRahmen");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult KreditRahmen(KreditRahmenModel model)
        {
            Debug.WriteLine("POST - KonsumKredit - KreditRahmen");

            if (ModelState.IsValid)
            {
                /// speichere Daten über BusinessLogic
                Kunde neuerKunde = KonsumKreditVerwaltung.ErzeugeKunde();

                /// Für alle weiteren schritte ist die ID des Kunden wichtig!
                /// deshalb wird er hier im cookie gespeichert.
                Response.Cookies.Add(new HttpCookie("idKunde", neuerKunde.ID.ToString()));

                /// gehe zum nächsten Schritt
                return RedirectToAction("FinanzielleSituation");
            }

            /// falls der ModelState NICHT valid ist, bleibe hier und
            /// gib die Daten (falls vorhanden) wieder auf das UI
            return View(model);
        }

        [HttpGet]
        public ActionResult FinanzielleSituation()
        {
            Debug.WriteLine("GET - KonsumKredit - FinanzielleSituation");

            FinanzielleSituationModel model = new FinanzielleSituationModel()
            {
                ID_Kunde = int.Parse(Request.Cookies["idKunde"].Value)
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FinanzielleSituation(FinanzielleSituationModel model)
        {
            Debug.WriteLine("POST - KonsumKredit - FinanzielleSituation");

            if (ModelState.IsValid)
            {

                //Hier speichere ich Daten über die Businesslogic!
                if (KonsumKreditVerwaltung.FinanzielleSituationSpeichern(
                                            model.NettoEinkommen,
                                            model.RatenVerpflichtungen,
                                            model.Wohnkosten,
                                            model.EinkünfteAlimenteUnterhalt,
                                            model.UnterhaltsZahlungen,
                                            model.ID_Kunde
                    ))
                {
                    return RedirectToAction("PersönlicheDaten");
                }

            }

            return View(model);
        }

        [HttpGet]
        public ActionResult PersönlicheDaten()
        {
            Debug.WriteLine("GET - KonsumKredit - PersönlicheDaten");

            List<BildungsModel> alleBildungsAngaben = new List<BildungsModel>();
            List<FamilienStandModel> alleFamilienStandAngaben = new List<FamilienStandModel>();
            List<IdentifikationsModel> alleIdentifikationsAngaben = new List<IdentifikationsModel>();
            List<StaatsbuergerschaftsModel> alleStaatsbuergerschaftsAngaben = new List<StaatsbuergerschaftsModel>();
            List<TitelModel> alleTitelAngaben = new List<TitelModel>();
            List<WohnartModel> alleWohnartAngaben = new List<WohnartModel>();

            /// Lade Daten aus Logic
            foreach (var bildungsAngabe in KonsumKreditVerwaltung.BildungsAngabenLaden())
            {
                alleBildungsAngaben.Add(new BildungsModel()
                {
                    ID = bildungsAngabe.ID.ToString(),
                    Bezeichnung = bildungsAngabe.Bezeichnung
                });
            }

            foreach (var familienStand in KonsumKreditVerwaltung.FamilienStandAngabenLaden())
            {
                alleFamilienStandAngaben.Add(new FamilienStandModel()
                {
                    ID = familienStand.ID.ToString(),
                    Bezeichnung = familienStand.Bezeichnung
                });
            }
            foreach (var identifikationsAngabe in KonsumKreditVerwaltung.IdentifikiationsAngabenLaden())
            {
                alleIdentifikationsAngaben.Add(new IdentifikationsModel()
                {
                    ID = identifikationsAngabe.ID.ToString(),
                    Bezeichnung = identifikationsAngabe.Bezeichnung
                });
            }
            foreach (var land in KonsumKreditVerwaltung.LaenderLaden())
            {
                alleStaatsbuergerschaftsAngaben.Add(new StaatsbuergerschaftsModel()
                {
                    ID = land.ID,
                    Bezeichnung = land.Bezeichnung
                });
            }
            foreach (var titel in KonsumKreditVerwaltung.TitelLaden())
            {
                alleTitelAngaben.Add(new TitelModel()
                {
                    ID = titel.ID.ToString(),
                    Bezeichnung = titel.Bezeichnung
                });
            }
            foreach (var wohnart in KonsumKreditVerwaltung.WohnartenLaden())
            {
                alleWohnartAngaben.Add(new WohnartModel()
                {
                    ID = wohnart.ID.ToString(),
                    Bezeichnung = wohnart.Bezeichnung
                });
            }



            PersönlicheDatenModel model = new PersönlicheDatenModel()
            {
                AlleBildungAngaben = alleBildungsAngaben,
                AlleFamilienStandAngaben = alleFamilienStandAngaben,
                AlleIdentifikationsAngaben = alleIdentifikationsAngaben,
                AlleStaatsbuergerschaftsAngaben = alleStaatsbuergerschaftsAngaben,
                AlleTitelAngaben = alleTitelAngaben,
                AlleWohnartAngaben = alleWohnartAngaben,
                ID_Kunde = int.Parse(Request.Cookies["idKunde"].Value)
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PersönlicheDaten(PersönlicheDatenModel model)
        {
            Debug.WriteLine("POST - KonsumKredit - PersönlicheDaten");

            if (ModelState.IsValid)
            {
                if (KonsumKreditVerwaltung.PersönlicheDatenSpeichern(
                                                model.ID_Titel,
                                                model.Geschlecht == Geschlecht.Männlich ? "m" : "w",
                                                model.GeburtsDatum,
                                                model.Vorname,
                                                model.Nachname,
                                                model.ID_Bildung,
                                                model.ID_Familienstand,
                                                model.ID_Identifikationsart,
                                                model.IdentifikationsNummer,
                                                model.ID_Staatsbuergerschaft,
                                                model.ID_Wohnart,
                                                model.ID_Kunde
                    ))


                    return RedirectToAction("Arbeitgeber");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Arbeitgeber()
        {
            Debug.WriteLine("GET - KonsumKredit - Arbeitgeber");

            List<BeschaeftigungsArtModel> alleBeschaeftigungen = new List<BeschaeftigungsArtModel>();
            List<BrancheModel> alleBranchen = new List<BrancheModel>();

            foreach (var branche in KonsumKreditVerwaltung.BranchenLaden())
            {
                alleBranchen.Add(new BrancheModel()
                {
                    ID = branche.ID.ToString(),
                    Bezeichnung = branche.Bezeichnung
                });
            }

            foreach (var beschaeftigungsArt in KonsumKreditVerwaltung.BeschaeftigungsArtenLaden())
            {
                alleBeschaeftigungen.Add(new BeschaeftigungsArtModel()
                {
                    ID = beschaeftigungsArt.ID.ToString(),
                    Bezeichnung = beschaeftigungsArt.Bezeichnung
                });
            }

            ArbeitgeberModel model = new ArbeitgeberModel()
            {
                AlleBeschaeftigungen = alleBeschaeftigungen,
                AlleBranchen = alleBranchen,
                ID_Kunde = int.Parse(Request.Cookies["idKunde"].Value)
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Arbeitgeber(ArbeitgeberModel model)
        {
            Debug.WriteLine("POST - KonsumKredit - Arbeitgeber");

            if (ModelState.IsValid)
            {
                if (KonsumKreditVerwaltung.ArbeitgeberAngabenSpeichern(
                                                  model.FirmenName,
                                                  model.ID_BeschäftigungsArt,
                                                  model.ID_Branche,
                                                  model.BeschäftigtSeit,
                                                  model.ID_Kunde))
                {
                    return RedirectToAction("KontoInformationen");
                }
            }


            return View();
        }

        [HttpGet]
        public ActionResult KontoInformationen()
        {
            Debug.WriteLine("GET - KonsumKredit - KontoInformationen");

            KontoInformationenModel model = new KontoInformationenModel()
            {
                ID_Kunde = int.Parse(Request.Cookies["idKunde"].Value)
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult KontoInformationen(KontoInformationenModel model)
        {
            Debug.WriteLine("POST - KonsumKredit - KontoInformationen");

            if (ModelState.IsValid)
            {
                /// speichere Daten über BusinessLogic
                if (KonsumKreditVerwaltung.KontoInformationenSpeichern(
                                                model.Bankname,
                                                model.IBAN,
                                                model.BIC,
                                                model.NeuesKonto,
                                                model.ID_Kunde))
                {
                    return RedirectToAction("Zusammenfassung");
                }
            }

            return View();
        }

        [HttpGet]
        public ActionResult Zusammenfassung()
        {
            Debug.WriteLine("GET - KonsumKredit - Zusammenfassung");

            /// ermittle für diese Kunden_ID
            /// alle gespeicherten Daten (ACHTUNG! das sind viele ....)
            /// gib Sie alle in das ZusammenfassungsModel (bzw. die UNTER-Modelle) 
            /// hinein.
            ZusammenfassungModel model = new ZusammenfassungModel();
            model.ID_Kunde = int.Parse(Request.Cookies["idKunde"].Value);


            /// gib model an die View
            return View(model);
        }

        [HttpPost]
        public ActionResult Zusammenfassung(ZusammenfassungModel model)
        {
            Debug.WriteLine("POST - KonsumKredit - Zusammenfassung");

            return View();
        }
    }
}