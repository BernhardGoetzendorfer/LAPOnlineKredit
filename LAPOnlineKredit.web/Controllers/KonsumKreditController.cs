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
                // Wenn er die ID im Cookie gefunden hat werden die Daten daraus geladen und angezeigt.
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
        public ActionResult FinanzielleSituation()
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

        [HttpGet]
        public ActionResult PersönlicheDaten()
        {
            Debug.WriteLine("GET, KonsumKreditController");

            //Listen 
            List<BildungsModel> alleBildungsAngaben = new List<BildungsModel>();
            List<FamilienStandModel> alleFamilienStandAngaben = new List<FamilienStandModel>();
            List<IdentifikationsModel> alleIdentifikationsAngaben = new List<IdentifikationsModel>();
            List<StaatsbuergerschaftsModel> alleStaatsbuergerschaftsAngaben = new List<StaatsbuergerschaftsModel>();
            List<TitelModel> alleTitelAngaben = new List<TitelModel>();
            List<WohnartModel> alleWohnartAngaben = new List<WohnartModel>();


            //Aus den sämtlichen Lookup Tabellen werden hier die Daten geladen und anschließend dem User im Formular als Dropdown angezeigt.

            foreach (var bildungsAngabe in KonsumKreditVerwaltung.AbschluesseLaden()) //Schleife zum druchlaufen aller Daten
            {
                alleBildungsAngaben.Add(new BildungsModel() //Solange Daten vorhanden sind werden diese durchlaufen und zu alleBildungsAngaben hinzugefügt
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

            // Hier hole ich die Listen aus dem Model und befülle sie mit dem inhalt der zuvor durchlaufenen schleifen(Listen) 
            // Jetzt liegen die Daten aus der Datenbank in der BL(AlleBildungAngaben) und können verwendet werden.
            PersoenlicheDatenModel model = new PersoenlicheDatenModel()
            {
                AlleBildungAngaben = alleBildungsAngaben,
                AlleFamilienStandAngaben = alleFamilienStandAngaben,
                AlleIdentifikationsAngaben = alleIdentifikationsAngaben,
                AlleStaatsbuergerschaftsAngaben = alleStaatsbuergerschaftsAngaben,
                AlleTitelAngaben = alleTitelAngaben,
                AlleWohnartAngaben = alleWohnartAngaben,
                ID_Kunde = int.Parse(Request.Cookies["idKunde"].Value)
            };


            Kunde kunde = KonsumKreditVerwaltung.PersönlicheDatenLaden(model.ID_Kunde); //Lade von einem Kunden alle Persönlichen Daten
            if (kunde != null) //Wenn es den Kunden schon gibt, lade die Daten aus der Datenbank
            {
                model.Geschlecht = !string.IsNullOrEmpty(kunde.Geschlecht) && kunde.Geschlecht == "m" ? Geschlecht.Männlich : Geschlecht.Weiblich; //Wenn Geschlecht gleich m ist dann .Männlich sonst .Weiblich
                model.Vorname = kunde.Vorname;
                model.Nachname = kunde.Nachname;
                model.ID_Titel = kunde.FKTitel.HasValue ? kunde.FKTitel.Value : 0; //Wenn FKTitel einen Wert hat nimm diesen, sonst 0
                model.ID_Staatsbuergerschaft = kunde.Staatsbuergerschaft;
                model.ID_Familienstand = kunde.FKFamilienstand.HasValue ? kunde.FKFamilienstand.Value : 0;
                model.ID_Wohnart = kunde.FKWohnart.HasValue ? kunde.FKWohnart.Value : 0;
                model.ID_Bildung = kunde.FKAbschluss.HasValue ? kunde.FKAbschluss.Value : 0;
                model.ID_Identifikationsart = kunde.FKIdentifikationsart.HasValue ? kunde.FKIdentifikationsart.Value : 0;
                model.IdentifikationsNummer = kunde.Identifikationsnummer;
            }

            return View(model);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PersönlicheDaten(PersoenlicheDatenModel model)
        {
            Debug.WriteLine("POST - KonsumKredit - PersönlicheDaten");

            if (ModelState.IsValid)
            {
                /// speichere Daten über BusinessLogic
                if (KonsumKreditVerwaltung.PersönlicheDatenSpeichern(
                                                model.ID_Titel,
                                                model.Geschlecht == Geschlecht.Männlich ? "m" : "w", //Wenn Geschlecht Männlich, dann "m", ansonsten "w"
                                                model.GeburtsDatum,
                                                model.Vorname,
                                                model.Nachname,
                                                model.ID_Bildung,
                                                model.ID_Familienstand,
                                                model.ID_Identifikationsart,
                                                model.IdentifikationsNummer,
                                                model.ID_Staatsbuergerschaft,
                                                model.ID_Wohnart,
                                                model.ID_Kunde))
                {
                    return RedirectToAction("Arbeitgeber");
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Arbeitgeber()
        {
            Debug.WriteLine("GET, KonsumKreditController, Arbeitgeber");

            List<BeschaeftigungsArtModel> beschaeftigungen = new List<BeschaeftigungsArtModel>();
            List<BrancheModel> branchen = new List<BrancheModel>();

            //Durchlaufe die Datenbank einträge und speicher diese in unserer Liste zB branchen[0] = "Informatik"
            foreach (var branche in KonsumKreditVerwaltung.BranchenLaden())
            {
                branchen.Add(new BrancheModel()
                {
                    ID = branche.ID.ToString(),
                    Bezeichnung = branche.Bezeichnung
                });
            }

            foreach (var beschaeftigungsArt in KonsumKreditVerwaltung.BeschaeftigungsArtenLaden())
            {
                beschaeftigungen.Add(new BeschaeftigungsArtModel()
                {
                    ID = beschaeftigungsArt.ID.ToString(),
                    Bezeichnung = beschaeftigungsArt.Bezeichnung
                });
            }

            ArbeitgeberModel arbeitgeberModel = new ArbeitgeberModel()
            {
                AlleBeschaeftigungen = beschaeftigungen, //Speicher die zuvor erzeugt Liste in die BL und verwend diese später weiter
                AlleBranchen = branchen,
                ID_Kunde = int.Parse(Request.Cookies["idKunde"].Value)
            };

            //Alle vorhandenen daten zum aktuellen Kunden werden geladen
            Arbeitgeber arbeitgeberDaten = KonsumKreditVerwaltung.ArbeitgeberDatenLaden(arbeitgeberModel.ID_Kunde);

            //Wenn Daten vorhanden sind übergib sie dem Model und anschließend der View
            if(arbeitgeberDaten != null)
            {
                arbeitgeberModel.BeschäftigtSeit = arbeitgeberDaten.BeschaeftigtSeit.Value.ToString("MM.yyyy");
                arbeitgeberModel.FirmenName = arbeitgeberDaten.Firmenname;
                arbeitgeberModel.ID_BeschäftigungsArt = arbeitgeberDaten.FKBeschaeftigungsArt.Value;
                arbeitgeberModel.ID_Branche = arbeitgeberDaten.FKBranche.Value;
            }


            return View(arbeitgeberModel);
        }

        // Nimm die Daten der Arbeitgeber View, speicher sie zum aktuellen Kunden in die DB.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Arbeitgeber(ArbeitgeberModel arbeitgeberModel)
        {
            Debug.WriteLine("POST, KonsumKreditController, Arbeitgeber");

            if(ModelState.IsValid) //Wenn die Daten übereinstimmen/ keine Fehler liefern
            {
                //Speichere die Daten von der View/dem Formular in die DB

                if (KonsumKreditVerwaltung.ArbeitgeberDatenSpeichern(arbeitgeberModel.FirmenName, arbeitgeberModel.ID_BeschäftigungsArt, arbeitgeberModel.ID_Branche, arbeitgeberModel.BeschäftigtSeit, arbeitgeberModel.ID_Kunde))
                {
                    return RedirectToAction("KontoInformationen");
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult KontoInformationen()
        {
            Debug.WriteLine("GET, KonsumKredit, KontoInformationen");

            KontoInformationenModel kontoInfoModel = new KontoInformationenModel()
            {
                ID_Kunde = int.Parse(Request.Cookies["idKunde"].Value) // Lade den Cookie und leg ihn in ID_Kunde
            };

            Konto kontoDaten = KonsumKreditVerwaltung.KontoInformationenLaden(kontoInfoModel.ID_Kunde); //Lade alle vorhandenen Daten von KontoInformationen nach kontoDaten
            if (kontoDaten != null)
            {
                kontoInfoModel.BankName = kontoDaten.Bankname;
                kontoInfoModel.BIC = kontoDaten.BIC;
                kontoInfoModel.IBAN = kontoDaten.IBAN;
                kontoInfoModel.NeuesKonto = !kontoDaten.IstKunde.Value;
            }
            return View(kontoInfoModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult KontoInformationen(KontoInformationenModel model)
        {
            Debug.WriteLine("POST, KonsumKredit, KontoInformationen");

            if (ModelState.IsValid)
            {
                /// speichere Daten über BusinessLogic
                if (KonsumKreditVerwaltung.KontoInformationenSpeichern(
                                                model.BankName,
                                                model.IBAN,
                                                model.BIC,
                                                model.NeuesKonto,
                                                model.ID_Kunde))
                {
                    return RedirectToAction("KontaktDaten");
                }
            }

            return View();
        }


        [HttpGet]
        public ActionResult KontaktDaten()
        {
            Debug.WriteLine("GET, KonsumKredit, KontaktDaten");

            List<WohnortModel> orte = new List<WohnortModel>();

            //Durchlaufe die Datenbank einträge und speicher diese in unserer Liste zB branchen[0] = "Informatik"
            foreach (var ort in KonsumKreditVerwaltung.OrteLaden())
            {
                orte.Add(new WohnortModel()
                {
                    ID = ort.ID.ToString(),
                    Bezeichnung = ort.Bezeichnung
                });
            }


            KontaktDatenModel model = new KontaktDatenModel()
            {
                ID_Kunde = int.Parse(Request.Cookies["idKunde"].Value)
                
            };

            model.AlleWohnorte = orte;

            return View(model);
        }

        [HttpPost]
        public ActionResult KontaktDaten(KontaktDatenModel model)
        {
            Debug.WriteLine("POST, KonsumKredit, KontaktDaten");

            if (ModelState.IsValid)
            {
                /// speichere Daten über BusinessLogic
                if (KonsumKreditVerwaltung.KontaktDatenSpeichern(
                                                model.IDWohnort,
                                                model.Strasse,
                                                model.Email,
                                                model.Telefonnummer,
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
            Debug.WriteLine("GET, KonsumKreditController, Zusammenfassung");

            // Find für den aktuellen Kunden ALLE Daten und übergib sie dem Zusammenfassungs Model

            ZusammenfassungModel zusammenfassungsModel = new ZusammenfassungModel(); //Erzeuge eine instanz aus dem Model
            
            zusammenfassungsModel.ID_Kunde = int.Parse(Request.Cookies["idKunde"].Value); //Hol die die ID aus dem Cookie und arbeite mit diesem Kunden weiter.

            //Jetzt lade ALLE Daten die zum Kunden gehören aus der Datenbank in unser Model, das anschließend der View gegeben wird.

            Kunde aktuellerKunde = KonsumKreditVerwaltung.KundeLaden(zusammenfassungsModel.ID_Kunde); // führ die Methode KundeLaden aus und speichere die Rückgabe nach aktuellerKunde

            //Kunden Daten des Kredites werden der Zusammenfassungs View übergeben.
            zusammenfassungsModel.Betrag = aktuellerKunde.Kredit.Betrag;
            zusammenfassungsModel.Laufzeit = aktuellerKunde.Kredit.Laufzeit;

            //Kunden Daten der FinanziellenSituation werden der Zusammenfassungs View übergeben.
            zusammenfassungsModel.Nettoeinkommen = (double)aktuellerKunde.FinanzielleSituation.MonatsEinkommen;
            zusammenfassungsModel.Wohnkosten = (double)aktuellerKunde.FinanzielleSituation.Wohnkosten;
            zusammenfassungsModel.SonstigesEinkommen = (double)aktuellerKunde.FinanzielleSituation.SonstigeEinkommen;
            zusammenfassungsModel.SonstigeAusgaben = (double)aktuellerKunde.FinanzielleSituation.SonstigeAusgaben;
            zusammenfassungsModel.Raten = (double)aktuellerKunde.FinanzielleSituation.Raten;

            //Kunden Daten der KontoInformation werden der Zusammenfassungs View übergeben.
            zusammenfassungsModel.Geschlecht = aktuellerKunde.Geschlecht == "m" ? "Herr" : "Frau";
            zusammenfassungsModel.Vorname = aktuellerKunde.Vorname;
            zusammenfassungsModel.Nachname = aktuellerKunde.Nachname;
            zusammenfassungsModel.Titel = aktuellerKunde.Titel?.Bezeichnung; //? Weil es Null sein kann, Bezeichnung weil er sonst die ID anzeigt
            zusammenfassungsModel.Geburtstag = aktuellerKunde.Geburtsdatum;
            zusammenfassungsModel.Staatsbuergerschaft = aktuellerKunde.Staatsbuergerschaft;
            zusammenfassungsModel.AnzahlUnterhaltpflichteKinder = -1;
            zusammenfassungsModel.familienstand = aktuellerKunde.Familienstand?.Bezeichnung;
            zusammenfassungsModel.Wohnart = aktuellerKunde.Wohnart?.Bezeichnung;
            zusammenfassungsModel.Bildung = aktuellerKunde.Abschluss?.Bezeichnung;
            zusammenfassungsModel.IdentifikationsArt = aktuellerKunde.Identifikationsart?.Bezeichnung;
            zusammenfassungsModel.Identifikationsnummer = aktuellerKunde.Identifikationsnummer;


            //Kunden Daten des Arbeitgebers werden der Zusammenfassungs View übergeben.
            zusammenfassungsModel.Firmenname = aktuellerKunde.Arbeitgeber.Firmenname;
            zusammenfassungsModel.BeschaeftigungsArt = aktuellerKunde.Arbeitgeber.BeschaeftigungsArt.Bezeichnung;
            zusammenfassungsModel.Branche = aktuellerKunde.Arbeitgeber.Branche.Bezeichnung;
            zusammenfassungsModel.BeschaeftigtSeit = aktuellerKunde.Arbeitgeber.BeschaeftigtSeit.Value.ToShortDateString();

            //Kunden Daten der KontaktDaten werden der Zusammenfassungs View übergeben.
            zusammenfassungsModel.Strasse = aktuellerKunde.Kontakt?.Strasse;
            zusammenfassungsModel.Ort = aktuellerKunde.Kontakt?.Ort.Bezeichnung;
            zusammenfassungsModel.Mail = aktuellerKunde.Kontakt?.eMail;
            zusammenfassungsModel.Telefonnummer = aktuellerKunde.Kontakt?.Telefonnummer;

            //Kunden Daten der KontoDaten werden der Zusammenfassungs View übergeben.
            zusammenfassungsModel.NeuesKonto = aktuellerKunde.Konto.IstKunde.Value;
            zusammenfassungsModel.Bankname = aktuellerKunde.Konto.Bankname;
            zusammenfassungsModel.IBAN = aktuellerKunde.Konto.IBAN;
            zusammenfassungsModel.BIC = aktuellerKunde.Konto.BIC;
            

            return View(zusammenfassungsModel); //Liefere der View alle zuvor geladenen Daten 
        }




    }
}