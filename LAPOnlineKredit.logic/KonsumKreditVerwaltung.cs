using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAPOnlineKredit.logic
{
    public class KonsumKreditVerwaltung
    {

        //Die Methode um einen Kudnen zu erzeugen. 
        //Anfangs leer, mit muster Daten gefüllt. Anschließend werden die Daten vom User eingetragen.
        public static Kunde ErzeugeKunde() //Muss einen Rückgabewert haben. 
        {
            Debug.WriteLine("KonsumKreditVerwaltung, Erzeuge Kunde");

            Kunde neuerKunde = null; //Wird mit null initializiert.

            try
            {
                using (var context = new OnlineKreditEntities())
                {
                    neuerKunde = new Kunde()
                    {
                        Vorname = "Johann",
                        Nachname = "Berger",
                        Geschlecht = "m"
                    };
                    context.alleKunden.Add(neuerKunde); 
                    context.SaveChanges(); //Füge den dummy der Datenbank hinzu
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debugger.Break();
            }
         return neuerKunde;
        }


        public static Kredit KreditRahmenLaden(int id)
        {
            Debug.WriteLine("KonsumKreditVerwaltung, KreditRahmenLaden");
            Kredit wunschKredit = null;

            try //Versucht Code auszuführen. Wenns fehlschlägt Catch
            {
                using (var context = new OnlineKreditEntities())
                {
                    wunschKredit = context.alleKredite.Where(x => x.ID == id).FirstOrDefault(); //Sucht in der Liste alleKredite nach der ID die als Parameter mit kommt. x ist hier eine erzeugte Variable. Könnte auch hugo heißen
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debugger.Break();
            }
          return wunschKredit;
        }


        public static bool KreditRahmenSpeichern(int Betrag, int laufzeit, int idKunde)
        {
            Debug.WriteLine("KonsumKreditVerwaltung, KreditRahmenSpeichern");
            
            bool erfolgreich = false; //Unser return wert, wird im lauf des programmes verändert

            try
            {
                using (var context = new OnlineKreditEntities())
                {
                    Kunde aktuellerKunde = context.alleKunden.Where(x => x.ID == idKunde).FirstOrDefault(); //Suche nach den Kunden mit der idKunde (Aktuelle Kunden ID). 

                    if (aktuellerKunde != null)
                    {
                        Kredit wunschKredit = context.alleKredite.FirstOrDefault(x => x.ID == idKunde);  // Schaue ob der Kunde bereits einene Betrag gewählt hat den er beantragen möchte.

                        if (wunschKredit == null) //Wenn es noch keinen Kredit gibt leg einen neuen an.
                        {
                            wunschKredit = new Kredit();
                            context.alleKredite.Add(wunschKredit); // Erzeuge einen neuen Betrag und speichere diesen.
                        }
                        //Fülle Kundenkonto mit Daten.
                        wunschKredit.Betrag = Betrag;
                        wunschKredit.Laufzeit = (short)laufzeit;
                        wunschKredit.ID = idKunde;
                    }
                    int betroffeneZeilen = context.SaveChanges(); // Speichere die Daten in die Datenbank.
                    erfolgreich = betroffeneZeilen >= 0; 
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debugger.Break();
            }
            
            return erfolgreich;
        }
        

        public static FinanzielleSituation FinanzielleSituationLaden(int id) //Methoden zum Laden sämtlicher FinanzielleSituation Daten der mitgegebenen ID
        {
            Debug.WriteLine("KonsumKReditVerwaltung, FinanzielleSituationLaden");

            FinanzielleSituation finanzielleSituation = null;

            try
            {
                using (var context = new OnlineKreditEntities())
                {
                    finanzielleSituation = context.alleFinanzielleSituationen.Where(x => x.ID == id).FirstOrDefault(); //Lade alle Daten aus der Datenbank mit der 
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Fehler in FinanzielleSituationLaden");
                Debug.WriteLine(ex.Message);
                Debugger.Break();

            }

            return finanzielleSituation;
        }


        //Speichert die Daten vom FinanzielleSituation Formular zum entsprechenden Kunden ab, wenn erfolgreich(true)
        public static bool FinanzielleSituationSpeichern(double nettoEinkommen, double ratenVerpflichtungen, double wohnkosten, double einkünfteAlimenteUnterhalt, double unterhaltsZahlungen, int idKunde)
        {
            Debug.WriteLine("KonsumKreditVerwaltung, FinanzielleSituationSpeichern");

            bool erfolgreich = false;

            try
            {
                using (var context = new OnlineKreditEntities())
                {
                    Kunde aktuellerKunde = context.alleKunden.Where(x => x.ID == idKunde).FirstOrDefault(); //Suche nach Kunden mit aktueller id

                    if (aktuellerKunde != null) 
                    {
                        FinanzielleSituation finanzielleSituation = context.alleFinanzielleSituationen.FirstOrDefault(x => x.ID == idKunde);

                        if(finanzielleSituation == null) //Wenns noch keinen Kunden gibt, erstell einen
                        {
                            finanzielleSituation = new FinanzielleSituation();
                            context.alleFinanzielleSituationen.Add(finanzielleSituation);
                        }

                        //Wenns schon einen Kunden gibt, trage die Daten von der Datenbank ein (im Formular)

                        finanzielleSituation.MonatsEinkommen = (decimal)nettoEinkommen;
                        finanzielleSituation.SonstigeAusgaben = (decimal)unterhaltsZahlungen;
                        finanzielleSituation.SonstigeEinkommen = (decimal)einkünfteAlimenteUnterhalt;
                        finanzielleSituation.Wohnkosten = (decimal)wohnkosten;
                        finanzielleSituation.Raten = (decimal)ratenVerpflichtungen;
                        finanzielleSituation.ID = idKunde;

                        int anzahlZeilenBetroffen = context.SaveChanges();
                        erfolgreich = anzahlZeilenBetroffen >= 0; //Wenn alles geklappt hat liefert die Methode true zurück
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debugger.Break();
            }

            return erfolgreich;
        }

        // Liefert alle Branchen aus der Datenbank oder null zurück
        public static List<Branche> BranchenLaden()
        {
            Debug.WriteLine("KosnumKreditVerwaltung, BranchenLaden");

            List<Branche> branchen = null; // Erzeuge leere Liste

            try
            {
                using (var context = new OnlineKreditEntities())
                {
                    branchen = context.alleBranchen.ToList(); //Speichere alle Brachen von der Datenbank in unsere Liste branchen
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debugger.Break();
            }

            return branchen;
        }


        // Liefert alle BeschaeftigungsArten aus der Datenbank oder null zurück
        public static List<BeschaeftigungsArt> BeschaeftigungsArtenLaden()
        {
            Debug.WriteLine("KosnumKreditVerwaltung, BeschaeftigungsArtenLaden");

            List<BeschaeftigungsArt> beschaeftigungsArten = null; 

            try
            {
                using (var context = new OnlineKreditEntities())
                {
                    beschaeftigungsArten = context.alleBeschaeftigungsArten.ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debugger.Break();
            }

            return beschaeftigungsArten;
        }


        // Liefert alle Abschlüsse aus der Datenbank oder null zurück
        public static List<Abschluss> AbschluesseLaden()
        {
            Debug.WriteLine("KosnumKreditVerwaltung, AbschluesseLaden");

            List<Abschluss> abschluesse = null;

            try
            {
                using (var context = new OnlineKreditEntities())
                {
                    abschluesse = context.alleAbschluesse.ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debugger.Break();
            }

            return abschluesse;
        }


        // Liefert alle FamilienStandAngaben aus der Datenbank oder null zurück
        public static List<Familienstand> FamilienStandAngabenLaden()
        {
            Debug.WriteLine("KosnumKreditVerwaltung, FamilienStandAngabenLaden");

            List<Familienstand> familienstand = null;

            try
            {
                using (var context = new OnlineKreditEntities())
                {
                    familienstand = context.alleFamilienstandAngaben.ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debugger.Break();
            }

            return familienstand;
        }


        // Liefert alle Länder aus der Datenbank oder null zurück
        public static List<Land> LaenderLaden()
        {
            Debug.WriteLine("KosnumKreditVerwaltung, LaenderLaden");

            List<Land> laender = null;

            try
            {
                using (var context = new OnlineKreditEntities())
                {
                    laender = context.alleLänder.ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debugger.Break();
            }

            return laender;
        }


        // Liefert alle Länder aus der Datenbank oder null zurück
        public static List<Wohnart> WohnartenLaden()
        {
            Debug.WriteLine("KosnumKreditVerwaltung, WohnartenLaden");

            List<Wohnart> wohnarten = null;

            try
            {
                using (var context = new OnlineKreditEntities())
                {
                    wohnarten = context.alleWohnarten.ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debugger.Break();
            }

            return wohnarten;
        }


        // Liefert alle Identifikiations Angaben aus der Datenbank oder null zurück
        public static List<Identifikationsart> IdentifikiationsAngabenLaden()
        {
            Debug.WriteLine("KosnumKreditVerwaltung, IdentifikiationsAngabenLaden");

            List<Identifikationsart> identifikationsArten = null;

            try
            {
                using (var context = new OnlineKreditEntities())
                {
                    identifikationsArten = context.alleIdentifikationsarten.ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debugger.Break();
            }

            return identifikationsArten;
        }


        // Liefert alle Titel Angaben aus der Datenbank oder null zurück
        public static List<Titel> TitelLaden()
        {
            Debug.WriteLine("KosnumKreditVerwaltung, TitelLaden");

            List<Titel> titel = null;

            try
            {
                using (var context = new OnlineKreditEntities())
                {
                    titel = context.alleTitel.ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debugger.Break();
            }

            return titel;
        }

        // Suche anhand der ID den Kunden. Liefere alle Persönliche Daten oder null zurück.
        public static Kunde PersönlicheDatenLaden(int id)
        {
            Debug.WriteLine("KonsumKreditVerwaltung, PersönlicheDatenLaden");

            Kunde persönlicheDaten = null;

            try
            {
                using (var context = new OnlineKreditEntities())
                {
                    persönlicheDaten = context.alleKunden.Where(x => x.ID == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                
                Debug.WriteLine(ex.Message);
                Debugger.Break();
            }
            
            return persönlicheDaten;
        }


        public static bool PersönlicheDatenSpeichern(int? idTitel, string geschlecht, DateTime geburtsDatum, string vorname, string nachname, int idBildung, int idFamilienstand, int idIdentifikationsart, string identifikationsNummer, string idStaatsbuergerschaft, int idWohnart, int idKunde)
        {
            Debug.WriteLine("KonsumKReditVerwaltung, PersönlicheDatenSpeichern");

            var erfolgreich = false;

            try
            {
                using (var context = new OnlineKreditEntities())
                {
                    Kunde aktuellerKunde = context.alleKunden.Where(x => x.ID == idKunde).FirstOrDefault();

                    if (aktuellerKunde != null) // Daten werden aus dem Formular genommen und in die Datenbank gespeichert
                    {
                        aktuellerKunde.Vorname = vorname;
                        aktuellerKunde.Nachname = nachname;
                        aktuellerKunde.FKFamilienstand = idFamilienstand;
                        aktuellerKunde.FKAbschluss = idBildung;
                        aktuellerKunde.Staatsbuergerschaft = idStaatsbuergerschaft;
                        aktuellerKunde.FKTitel = idTitel;
                        aktuellerKunde.FKIdentifikationsart = idIdentifikationsart;
                        aktuellerKunde.Identifikationsnummer = identifikationsNummer;
                        aktuellerKunde.Geschlecht = geschlecht;
                        aktuellerKunde.FKWohnart = idWohnart;
                    }

                    int anzahlZeilenBetroffen = context.SaveChanges();
                    erfolgreich = anzahlZeilenBetroffen >= 0;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debugger.Break();
            }

            return erfolgreich;
        }

        //Läd die Arbeitgeberangaben zum Kunden mit der ID
        public static Arbeitgeber ArbeitgeberDatenLaden(int id)
        {
            Debug.WriteLine("KonsumKreditVerwaltung, ArbeitgeberAngabenLaden");

            Arbeitgeber arbeitgeber = null;

            try
            {
                using (var context = new OnlineKreditEntities())
                {
                    arbeitgeber = context.alleArbeitgeber.Where(x => x.ID == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debugger.Break();
                
            }

            return arbeitgeber;
        }

        //Methode zum Speichern der ArbeitgeberDaten zur ID des Kunden
        public static bool ArbeitgeberDatenSpeichern(string firmenname, int idBeschaeftigungsart, int idbranche, string beschaeftigtSeit, int idKunde)
        {
            Debug.WriteLine("KonsumKReditVerwaltung, ArbeitgeberDatenSpeichern");

            bool erfolgreich = false;

            try
            {
                using (var context = new OnlineKreditEntities())
                {
                    Kunde aktuellerKunde = context.alleKunden.Where(x => x.ID == idKunde).FirstOrDefault();

                    if(aktuellerKunde != null)
                    {
                        Arbeitgeber arbeitgeber = context.alleArbeitgeber.FirstOrDefault();

                        if (arbeitgeber == null) //Wenn es mit der aktuellen ID vom Kunden noch keine Daten zum Arbeitgeber gibt, erstell einen neuen. Sonst lade sie aus der DB
                        {
                            arbeitgeber = new Arbeitgeber();
                            context.alleArbeitgeber.Add(arbeitgeber);
                        }

                        //Speichere die Daten vom Formular in die Datenbank
                        arbeitgeber.BeschaeftigtSeit = DateTime.Parse(beschaeftigtSeit);
                        arbeitgeber.FKBranche = idbranche;
                        arbeitgeber.FKBeschaeftigungsArt = idBeschaeftigungsart;
                        arbeitgeber.Firmenname = firmenname;

                        aktuellerKunde.Arbeitgeber = arbeitgeber;
                    }

                    int anzahlZeilenBetroffen = context.SaveChanges();
                    erfolgreich = anzahlZeilenBetroffen >= 0;

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debugger.Break();
            }

            return erfolgreich;
        }


        //Methode zum Laden der KontoInformationen. KundenID muss mitgegeben werden.
        public static Konto KontoInformationenLaden(int kundenID)
        {
            Debug.WriteLine("KonsumKreditVerwaltung, KontoInformationenLaden");

            Konto konto = null;  //leeres Konto erzeugt

            try
            {
                using (var context = new OnlineKreditEntities()) //Baue die Verbindung zur Datenbank auf.
                {
                    konto = context.alleKonten.Where(x => x.ID == kundenID).FirstOrDefault(); //Lade alle Konto Daten von der KundenID
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debugger.Break();
            }

            return konto; //Liefert das Konto mit den KontoDaten zurück - zur KundenID
        }

















        }
}
