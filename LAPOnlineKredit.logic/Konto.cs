//------------------------------------------------------------------------------
// <auto-generated>
//    Dieser Code wurde aus einer Vorlage generiert.
//
//    Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten Ihrer Anwendung.
//    Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LAPOnlineKredit.logic
{
    using System;
    using System.Collections.Generic;
    
    public partial class Konto
    {
        public int ID { get; set; }
        public string Bankname { get; set; }
        public string KreditArt { get; set; }
        public Nullable<bool> IstKunde { get; set; }
        public string IBAN { get; set; }
        public string BIC { get; set; }
        public string Kreditkartennummer { get; set; }
    
        public virtual Kunde Kunde { get; set; }
    }
}
