
use master
go

drop database dbOnlineKredit
go

create database dbOnlineKredit
go

use dbOnlineKredit
go



create table tblEinstellungen
(
	IDEinstellungen int identity(1,1) primary key,
	NormalZins float,
	EffektiverZins float,
	Datum date
)


create table tblTitel
(
	IDTitel int identity(1,1) primary key,
	Titel varchar(30) not null unique
)

create table tblFamilienstand
(
	IDFamilienstand int identity(1,1) primary key,
	Familienstand varchar(30) not null unique
)

create table tblWohnart
(
	IDWohnart int identity(1,1) primary key,
	Wohnart varchar(40) not null unique
)

create table tblAbschluss
(
	IDAbschluss int identity(1,1) primary key,
	Abschluss varchar(40) not null unique
)

create table tblIdentifikationsart
(
	IDIdentifikationsart int identity(1,1) primary key,
	Identifikationsart varchar(30) not null unique
)

create table tblLand
(
	IDLand char(3) primary key not null,
	Land varchar(75) not null unique
)
go

create table tblKunde
(
	IDKunde int identity(1,1) primary key,
	FKTitel int foreign key references tblTitel,
	FKFamilienstand int foreign key references tblFamilienstand,
	FKWohnart int foreign key references tblWohnart,
	FKAbschluss int foreign key references tblAbschluss,
	FKIdentifikationsart int foreign key references tblIdentifikationsart,
	Staatsbuergerschaft char(3) foreign key references tblLand,
	Geschlecht char(1) not null check(Geschlecht in ('m','w')),
	Vorname nvarchar(50) not null,
	Nachname nvarchar(50) not null,
	Geburtsdatum date not null check(Geburtsdatum <= dateadd(year,-18,getdate())),
	UnterhaltpflichtigeKinder int default 0,
	Identifikationsnummer varchar(30)
)
go

create table tblLogin
(
	IDLogin int  primary key references tblKunde,
	Benutzername nvarchar(30) not null unique,
	Passwort varchar(30)

)

create table tblKredit
(
	IDKredit int primary key references tblKunde,
	FKKunde int references tblKunde,
	Betrag int not null,
	Laufzeit int not null check(Laufzeit > 0),
	KreditBewilligt bit default 0
)
go

create table tblFinanzielleSituation
(
	IDFinanzielleSituation int primary key references tblKunde,
	MonatsEinkommen decimal(10,2),
	Wohnkosten decimal(10,2),
	SonstigeEinkommen decimal(10,2),
	SonstigeAusgaben decimal(10,2),
	Raten DECIMAL(10,2)
)
go


create table tblBeschaeftigungsArt
(
	IDBeschaeftigungsArt int identity(1,1) primary key,
	BeschaeftigungsArt nvarchar(75) not null unique
)
go

create table tblBranche
(
	IDBranche int identity(1,1) primary key,
	Branche nvarchar(30) not null unique
)
go

create table tblArbeitgeber 
(
	IDArbeitgeber int primary key references tblKunde,
	FKBeschaeftigungsArt int foreign key references tblBeschaeftigungsArt,
	Firmenname nvarchar(75) not null, 
	FKBranche int foreign key references tblBranche,
	BeschaeftigtSeit date
)
go



create table tblOrt
(
	IDOrt int identity(1,1) primary key,
	FKLand char(3) foreign key references tblLand,
	Ort varchar(100) not null,
	PLZ varchar(5)
)
go



create table tblKontakt
(
	IDKontakt int primary key references tblKunde,
	FKOrt int foreign key references tblOrt,
	Strasse varchar(40) not null,
	eMail nvarchar(100),
	Telefonnummer nvarchar(30)
)
go



create table tblKonto
(
	IDKonto int primary key references tblKunde,
	Bankname varchar(50), 
	KreditArt varchar(30),
	IstKunde bit default 0,
	IBAN varchar(30),
	BIC varchar(30)
)
go

/* Tabellen vom Bak einfügen */
insert into tblLand
select [Spalte 0], [Spalte 1]
from landort.dbo.Länderneu
where [Spalte 0] <> ''
go

insert into tblOrt(FKLand, PLZ, Ort)
select 'AUT', PLZ, Ort
from landort.dbo.tblOrt
go


/* Insert sample values */

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
('Dipl.Päd.'),
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
('Führerschein'),
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
(1, 1110, 'Straße 1', 'aisdjoas1@asd.at', '0660 2878 9828'),
(2, 1110, 'Straße 2', 'aisdjoas2@asd.at', '0660 5531 9828'),
(3, 1110, 'Straße 3', 'aisdjoas3@asd.at', '0660 233 22 98 28')
go

insert into tblKonto
values
(1, '', 'Konsumkredit', 0, '', ''),
(2, 'Sparkassa', 'Konsumkredit', 1, '12890390128391', 'asd1203912'),
(3, '', 'Konsumkredit', 0, '', '')
go

insert into tblKredit
values
(1, 1, 500, 12, 1),
(2, 2, 1500, 24, 1),
(3, 3, 2500, 18, 0)
go

insert into tblArbeitgeber
values
(1, 1, 'yay', 1, '1.1.2014'),
(2, 2, 'Hutson', 2, '5.7.2012'),
(3, 3, 'Microsoft', 3, '1.6.2010')
go




