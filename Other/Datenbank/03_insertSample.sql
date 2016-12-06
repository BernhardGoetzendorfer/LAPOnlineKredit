use dbOnlineKredit
go

insert into tblAbschluss
values
('Hauptschule'),
('Gymnasium'),
('Studium')
go

insert into tblBranche
values
('Informatik'),
('Einzelhandel'),
('Metall')
go

insert into tblBeschaeftigungsArt
values
('Angestellt'),
('Pensionist'),
('Arbeitslos')
go

insert into tblFamilienstand
values
('ledig'),
('verheiratet'),
('geschieden')
go

insert into tblTitel(Titel)
values
('DI'),
('Dipl.Ta.'),
('Dipl.Vw.'),
('Dir.'),
('Dkfm.'),
('Dr.'),
('Ing.'),
('Mag.'),
('Prof.'),
('Univ.-Prof.'),
('Gen.Dir.'),
('Gen.Manager'),
('DI(FH)'),
('DDr.'),
('Dipl.HTL-Ing.'),
('Mag.(FH)'),
('Dipl.Kffr.'),
('MBA'),
('Dipl.P‰d.'),
('MA'),
('MMag.'),
('MSc'),
('Dipl.Oek.'),
('BA'),
('Bakk.'),
('Bakk.(FH)'),
('BSc'),
('PhD')
go

insert into tblIdentifikationsart
values
('F¸hrerschein'),
('Personalausweis'),
('Reisepass')
go

insert into tblWohnart
values
('Miete'),
('Eigentum'),
('Wohngemeinschaft')
go

insert into tblKunde(FKTitel, FKFamilienstand, FKWohnart, FKAbschluss, FKIdentifikationsart, Staatsbuergerschaft, Geschlecht, Vorname, Nachname,Geburtsdatum, UnterhaltpflichtigeKinder, Identifikationsnummer)
values
(1, 1, 1, 1, 1, 'AUT', 'm', 'Bernhard', 'Goetzendorfer', '5-1-1995', 0, '1829037912'),
(2, 3, 2, 1, 3, 'AUT', 'w', 'Julia', 'Mair', '6-9-1990', 6, '1823223912'),
(1, 1, 1, 1, 1, 'AUT', 'm', 'Thomas', 'Lehner', '28-8-1975', 0, '1829037912')
go

insert into tblFinanzielleSituation
values
(1, 5000, 100, 5000, 150, 8),
(2, 2000, 1000, 300, 650, 200),
(3, 3000, 1500, 800, 350, 377)
go

insert into tblKontakt
values
(1, 1110, 'Straﬂe 1', 'aisdjoas1@asd.at', '0660 2878 9828'),
(2, 1110, 'Straﬂe 2', 'aisdjoas2@asd.at', '0660 5531 9828'),
(3, 1110, 'Straﬂe 3', 'aisdjoas3@asd.at', '0660 233 22 98 28')
go

insert into tblKonto
values
(1, '', 'Konsumkredit', 0, '', ''),
(2, 'Sparkassa', 'Konsumkredit', 1, '12890390128391', 'asd1203912'),
(3, '', 'Konsumkredit', 0, '', '')
go

insert into tblKredit(FKKunde, Betrag, Laufzeit, KreditBewilligt)
values
(1, 500, 12, 1),
(2, 1500, 24, 1),
(3, 2500, 18, 0),
go

insert into tblArbeitgeber
values
(1, 1, 'yay', 1, '1.1.2014'),
(2, 2, 'Hutson', 2, '5.7.2012'),
(3, 3, 'Microsoft', 3, '1.6.2010')
go
