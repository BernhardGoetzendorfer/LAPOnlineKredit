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
    
    public partial class Land
    {
        public Land()
        {
            this.AlleKunden_Staatsangehoerigkeit = new HashSet<Kunde>();
            this.alleOrte = new HashSet<Ort>();
        }
    
        public string ID { get; set; }
        public string Bezeichnung { get; set; }
    
        public virtual ICollection<Kunde> AlleKunden_Staatsangehoerigkeit { get; set; }
        public virtual ICollection<Ort> alleOrte { get; set; }
    }
}
