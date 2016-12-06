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
                Debug.WriteLine("Fehler in KonsumKreditVerwaltung, ErzeugeKunde");
                Debug.WriteLine(ex.Message);
                Debugger.Break();
            }
         return neuerKunde;
        }


    }
}
