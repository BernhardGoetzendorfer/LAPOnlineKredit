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
                        Kredit wunschKredit = context.alleKredite.First(x => x.ID == idKunde);  // Schaue ob der Kunde bereits einene Betrag gewählt hat den er beantragen möchte.

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
                    int betroffeneZeilen = context.SaveChanges();
                    erfolgreich = betroffeneZeilen >= 0; // Speichere die Daten in die Datenbank.
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debugger.Break();
            }
            
            return erfolgreich;
        }
        
    }
}
