using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace freigabe
{
    class KreditFreigabe
    {
        /// <summary>
        /// Gibt zurück ob für die angegebenen Daten eine Kreditfreigabe erteilt wird
        /// </summary>
        /// <param name="Vorname">der Vorname des Antragsteller</param>
        /// <param name="Nachname">der Nachname des Antragsteller</param>
        /// <param name="MonatsEinkommen">das monatliche Netto-Einkommen des Antragsteller</param>
        /// <param name="WohnKosten">die monatlichen Wohnkosten  des Antragsteller</param>
        /// <param name="SonstigeEinkommen">die monatlichen Einkünfte aus Alimente, Unterhalt des Antragsteller</param>
        /// <param name="SonstigeAusgaben">die monatlichen Ausgaben für Alimente, Unterhalt des Antragsteller</param>
        /// <param name="Raten">die monatlichen Ratenzahlungen des Antragsteller</param>
        /// <returns></returns>
        public static bool FreigabeErteilt(
            string geschlecht,
            string vorname,
            string nachname,
            string familienStand,
            double MonatsEinkommen,
            double WohnKosten,
            double SonstigeEinkommen,
            double SonstigeAusgaben,
            double Raten)
        {
            Debug.WriteLine("KreditFreigabe - FreigabeErteilt");
            Debug.Indent();
            bool freigabe = false;

            if (string.IsNullOrEmpty(vorname))
                throw new ArgumentNullException(nameof(vorname));
            if (string.IsNullOrEmpty(nachname))
                throw new ArgumentNullException(nameof(nachname));
            if (MonatsEinkommen <= 0 || MonatsEinkommen > 50000)
                throw new ArgumentException($"Ungültigter Wert für {nameof(MonatsEinkommen)}");
            if (WohnKosten <= 0 || WohnKosten > 10000)
                throw new ArgumentException($"Ungültigter Wert für {nameof(WohnKosten)}");
            if (SonstigeEinkommen <= 0 || SonstigeEinkommen > 10000)
                throw new ArgumentException($"Ungültigter Wert für {nameof(SonstigeEinkommen)}");
            if (SonstigeAusgaben <= 0 || SonstigeAusgaben > 10000)
                throw new ArgumentException($"Ungültigter Wert für {nameof(SonstigeAusgaben)}");
            if (Raten <= 0 || Raten > 10000)
                throw new ArgumentException($"Ungültigter Wert für {nameof(Raten)}");

            double verfügbarerBetrag = MonatsEinkommen + SonstigeEinkommen - WohnKosten - SonstigeEinkommen - SonstigeAusgaben - Raten;
            double verhältnisWohkostenVerfügbarerBetrag = WohnKosten / verfügbarerBetrag;

            switch (familienStand)
            {
                case "ledig":
                case "verwitwet":
                    switch (geschlecht)
                    {
                        case "m":
                            freigabe = verfügbarerBetrag > WohnKosten * 2;
                            break;
                        case "w":
                            freigabe = verfügbarerBetrag > WohnKosten * 1.8;
                            break;
                        default:
                            throw new ArgumentException($"Ungültiger Wert für {nameof(geschlecht)}!\n\nNur 'm' oder 'w' erlaubt.");
                           
                    }

                    break;
                case "in Partnerschaft":
                case "verheiratet":
                    if (verhältnisWohkostenVerfügbarerBetrag < 0.5)
                    {
                        freigabe = verfügbarerBetrag > WohnKosten * 2.5;
                    }
                    else
                    {
                        freigabe = verfügbarerBetrag > WohnKosten * 3.5;
                    }
                    break;
                default:
                    throw new ArgumentException($"Ungültiger Wert für {nameof(familienStand)}!\n\nNur 'ledig', 'verwitwet', 'in Partnerschaft', 'verheiratet' erlaubt.");
                    
            }

            Debug.Unindent();
            return freigabe;

        }
    }
}
