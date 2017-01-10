/*
use master
go

drop database dbOnlineKredit
go

create database dbOnlineKredit
go

use dbOnlineKredit
*/

create table tblEinstellungen
(
	IDEinstellungen int identity(1,1) primary key,
	Normalzins float,
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

create table tblidentifikationsart
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

create table tblKredit
(
	IDKredit int primary key references tblKunde,
	Betrag decimal(10,2) not null,
	Laufzeit smallint not null check(Laufzeit > 0),
	KreditBewilligt bit default 0
)
go

create table tblFinanzielleSituation
(
	IDFinanzielleSituation int identity(1,1) primary key references tblKunde,
	NettoEinkommen decimal(10,2),
	Wohnkosten decimal(10,2),
	SonstigesEinkommen decimal(10,2),
	Unterhalt decimal(10,2),
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
	IDKontakt int identity(1,1) primary key references tblKunde,
	FKOrt int foreign key references tblOrt,
	Strasse varchar(40) not null,
	eMail nvarchar(100),
	Telefonnummer nvarchar(30)
)
go



create table tblKonto
(
	IDKonto int primary key references tblKunde,
	KreditArt varchar(30),
	HatKonto bit default 0,
	IBAN varchar(30),
	BIC varchar(30)
)
go


