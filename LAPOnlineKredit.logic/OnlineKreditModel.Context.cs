﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class OnlineKreditEntities : DbContext
    {
        public OnlineKreditEntities()
            : base("name=OnlineKreditEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Abschluss> alleAbschluesse { get; set; }
        public DbSet<Arbeitgeber> alleArbeitgeber { get; set; }
        public DbSet<BeschaeftigungsArt> alleBeschaeftigungsArten { get; set; }
        public DbSet<Branche> alleBranchen { get; set; }
        public DbSet<Einstellungen> alleEinstellungen { get; set; }
        public DbSet<Familienstand> alleFamilienstandAngaben { get; set; }
        public DbSet<FinanzielleSituation> alleFinanzielleSituationen { get; set; }
        public DbSet<Identifikationsart> alleIdentifikationsarten { get; set; }
        public DbSet<Kontakt> alleKontaktDaten { get; set; }
        public DbSet<Konto> alleKonten { get; set; }
        public DbSet<Kredit> alleKredite { get; set; }
        public DbSet<Kunde> alleKunden { get; set; }
        public DbSet<Land> alleLänder { get; set; }
        public DbSet<Login> alleLoginDaten { get; set; }
        public DbSet<Ort> alleOrte { get; set; }
        public DbSet<Titel> alleTitel { get; set; }
        public DbSet<Wohnart> alleWohnarten { get; set; }
    }
}
