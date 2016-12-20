
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/14/2016 15:00:01
-- Generated from EDMX file: C:\Users\Martin.Jakubetz\Desktop\20161114\ITIN19LAP-master (1)\ITIN19LAP-master\onlineKredit\onlineKredit.logic\OnlineKreditModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [dbLAP_itin19];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__tblArbeit__FKBes__33D4B598]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblArbeitgeber] DROP CONSTRAINT [FK__tblArbeit__FKBes__33D4B598];
GO
IF OBJECT_ID(N'[dbo].[FK__tblArbeit__FKBra__34C8D9D1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblArbeitgeber] DROP CONSTRAINT [FK__tblArbeit__FKBra__34C8D9D1];
GO
IF OBJECT_ID(N'[dbo].[FK__tblArbeit__IDArb__32E0915F]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblArbeitgeber] DROP CONSTRAINT [FK__tblArbeit__IDArb__32E0915F];
GO
IF OBJECT_ID(N'[dbo].[FK__tblFinanz__IDFin__3D5E1FD2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblFinanzielleSituation] DROP CONSTRAINT [FK__tblFinanz__IDFin__3D5E1FD2];
GO
IF OBJECT_ID(N'[dbo].[FK__tblKontak__FKOrt__2C3393D0]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblKontaktDaten] DROP CONSTRAINT [FK__tblKontak__FKOrt__2C3393D0];
GO
IF OBJECT_ID(N'[dbo].[FK__tblKontak__IDKon__2B3F6F97]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblKontaktDaten] DROP CONSTRAINT [FK__tblKontak__IDKon__2B3F6F97];
GO
IF OBJECT_ID(N'[dbo].[FK__tblKontoD__IDKon__37A5467C]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblKontoDaten] DROP CONSTRAINT [FK__tblKontoD__IDKon__37A5467C];
GO
IF OBJECT_ID(N'[dbo].[FK__tblKredit__IDKre__3A81B327]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblKredit] DROP CONSTRAINT [FK__tblKredit__IDKre__3A81B327];
GO
IF OBJECT_ID(N'[dbo].[FK__tblKunde__FKFami__24927208]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblKunde] DROP CONSTRAINT [FK__tblKunde__FKFami__24927208];
GO
IF OBJECT_ID(N'[dbo].[FK__tblKunde__FKIden__286302EC]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblKunde] DROP CONSTRAINT [FK__tblKunde__FKIden__286302EC];
GO
IF OBJECT_ID(N'[dbo].[FK__tblKunde__FKSchu__276EDEB3]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblKunde] DROP CONSTRAINT [FK__tblKunde__FKSchu__276EDEB3];
GO
IF OBJECT_ID(N'[dbo].[FK__tblKunde__FKStaa__25869641]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblKunde] DROP CONSTRAINT [FK__tblKunde__FKStaa__25869641];
GO
IF OBJECT_ID(N'[dbo].[FK__tblKunde__FKTite__22AA2996]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblKunde] DROP CONSTRAINT [FK__tblKunde__FKTite__22AA2996];
GO
IF OBJECT_ID(N'[dbo].[FK__tblKunde__FKTite__239E4DCF]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblKunde] DROP CONSTRAINT [FK__tblKunde__FKTite__239E4DCF];
GO
IF OBJECT_ID(N'[dbo].[FK__tblKunde__FKWohn__267ABA7A]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblKunde] DROP CONSTRAINT [FK__tblKunde__FKWohn__267ABA7A];
GO
IF OBJECT_ID(N'[dbo].[FK__tblOrt__FKLand__145C0A3F]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblOrt] DROP CONSTRAINT [FK__tblOrt__FKLand__145C0A3F];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[tblArbeitgeber]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblArbeitgeber];
GO
IF OBJECT_ID(N'[dbo].[tblBeschaeftigungsart]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblBeschaeftigungsart];
GO
IF OBJECT_ID(N'[dbo].[tblBranche]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblBranche];
GO
IF OBJECT_ID(N'[dbo].[tblEinstellungen]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblEinstellungen];
GO
IF OBJECT_ID(N'[dbo].[tblFamilienstand]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblFamilienstand];
GO
IF OBJECT_ID(N'[dbo].[tblFinanzielleSituation]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblFinanzielleSituation];
GO
IF OBJECT_ID(N'[dbo].[tblIdentifikationsArt]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblIdentifikationsArt];
GO
IF OBJECT_ID(N'[dbo].[tblKontaktDaten]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblKontaktDaten];
GO
IF OBJECT_ID(N'[dbo].[tblKontoDaten]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblKontoDaten];
GO
IF OBJECT_ID(N'[dbo].[tblKredit]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblKredit];
GO
IF OBJECT_ID(N'[dbo].[tblKunde]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblKunde];
GO
IF OBJECT_ID(N'[dbo].[tblLand]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblLand];
GO
IF OBJECT_ID(N'[dbo].[tblOrt]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblOrt];
GO
IF OBJECT_ID(N'[dbo].[tblSchulabschluss]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblSchulabschluss];
GO
IF OBJECT_ID(N'[dbo].[tblTitel]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblTitel];
GO
IF OBJECT_ID(N'[dbo].[tblTitelNachstehend]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblTitelNachstehend];
GO
IF OBJECT_ID(N'[dbo].[tblWohnart]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblWohnart];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'AlleArbeitgeber'
CREATE TABLE [dbo].[AlleArbeitgeber] (
    [ID] int  NOT NULL,
    [Firma] varchar(30)  NULL,
    [FKBeschaeftigungsArt] int  NULL,
    [FKBranche] int  NULL,
    [BeschaeftigtSeit] datetime  NULL
);
GO

-- Creating table 'AlleBeschaeftigungsarten'
CREATE TABLE [dbo].[AlleBeschaeftigungsarten] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Bezeichnung] varchar(15)  NULL
);
GO

-- Creating table 'AlleBranchen'
CREATE TABLE [dbo].[AlleBranchen] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Bezeichnung] varchar(25)  NULL
);
GO

-- Creating table 'AlleEinstellungen'
CREATE TABLE [dbo].[AlleEinstellungen] (
    [IDEinstellungen] int IDENTITY(1,1) NOT NULL,
    [NormalZins] decimal(3,2)  NOT NULL,
    [EffektiverZins] decimal(3,2)  NOT NULL,
    [Datum] datetime  NULL
);
GO

-- Creating table 'AlleFamilienStandAngaben'
CREATE TABLE [dbo].[AlleFamilienStandAngaben] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Bezeichnung] varchar(25)  NOT NULL
);
GO

-- Creating table 'AlleFinanzielleSituationen'
CREATE TABLE [dbo].[AlleFinanzielleSituationen] (
    [ID] int  NOT NULL,
    [MonatsEinkommen] decimal(10,2)  NULL,
    [Wohnkosten] decimal(10,2)  NULL,
    [EinkuenfteAlimenteUnterhalt] decimal(10,2)  NULL,
    [AusgabenALIUNT] decimal(10,2)  NULL
);
GO

-- Creating table 'AlleIdentifikationsArten'
CREATE TABLE [dbo].[AlleIdentifikationsArten] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [IdentifikationsArt] varchar(20)  NOT NULL
);
GO

-- Creating table 'AlleKontaktDaten'
CREATE TABLE [dbo].[AlleKontaktDaten] (
    [ID] int  NOT NULL,
    [FKOrt] int  NULL,
    [Strasse] varchar(30)  NOT NULL,
    [Hausnummer] varchar(3)  NOT NULL,
    [Stiege] varchar(2)  NULL,
    [Tuer] varchar(2)  NULL,
    [EMail] varchar(max)  NULL,
    [Telefonnummer] varchar(20)  NULL
);
GO

-- Creating table 'AlleKontoDaten'
CREATE TABLE [dbo].[AlleKontoDaten] (
    [ID] int  NOT NULL,
    [BIC] varchar(25)  NULL,
    [IBAN] varchar(25)  NULL,
    [IstDB_Kunde] bit  NULL,
    [BankName] varchar(30)  NULL
);
GO

-- Creating table 'AlleKreditWünsche'
CREATE TABLE [dbo].[AlleKreditWünsche] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Betrag] decimal(10,2)  NULL,
    [Laufzeit] int  NULL
);
GO

-- Creating table 'AlleKunden'
CREATE TABLE [dbo].[AlleKunden] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Vorname] varchar(30)  NOT NULL,
    [Nachname] varchar(30)  NOT NULL,
    [FKTitel] int  NULL,
    [FKTitelNachstehend] int  NULL,
    [FKFamilienstand] int  NULL,
    [FKStaatsangehoerigkeit] char(3)  NULL,
    [FKWohnart] int  NULL,
    [FKSchulabschluss] int  NULL,
    [IdentifikationsNummer] varchar(30)  NULL,
    [FKIdentifikationsArt] int  NULL
);
GO

-- Creating table 'AlleLänder'
CREATE TABLE [dbo].[AlleLänder] (
    [ID] char(3)  NOT NULL,
    [Bezeichnung] varchar(30)  NOT NULL,
    [Vorwahl] char(4)  NOT NULL
);
GO

-- Creating table 'AlleOrte'
CREATE TABLE [dbo].[AlleOrte] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [PLZ] varchar(10)  NOT NULL,
    [FKLand] char(3)  NULL
);
GO

-- Creating table 'AlleSchulabschlüsse'
CREATE TABLE [dbo].[AlleSchulabschlüsse] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Bezeichnung] varchar(20)  NOT NULL
);
GO

-- Creating table 'AlleTitel'
CREATE TABLE [dbo].[AlleTitel] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Bezeichnung] varchar(20)  NOT NULL
);
GO

-- Creating table 'AlleTitelNachstehend'
CREATE TABLE [dbo].[AlleTitelNachstehend] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Bezeichnung] varchar(20)  NOT NULL
);
GO

-- Creating table 'AlleWohnarten'
CREATE TABLE [dbo].[AlleWohnarten] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Bezeichnung] varchar(20)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'AlleArbeitgeber'
ALTER TABLE [dbo].[AlleArbeitgeber]
ADD CONSTRAINT [PK_AlleArbeitgeber]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'AlleBeschaeftigungsarten'
ALTER TABLE [dbo].[AlleBeschaeftigungsarten]
ADD CONSTRAINT [PK_AlleBeschaeftigungsarten]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'AlleBranchen'
ALTER TABLE [dbo].[AlleBranchen]
ADD CONSTRAINT [PK_AlleBranchen]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [IDEinstellungen] in table 'AlleEinstellungen'
ALTER TABLE [dbo].[AlleEinstellungen]
ADD CONSTRAINT [PK_AlleEinstellungen]
    PRIMARY KEY CLUSTERED ([IDEinstellungen] ASC);
GO

-- Creating primary key on [ID] in table 'AlleFamilienStandAngaben'
ALTER TABLE [dbo].[AlleFamilienStandAngaben]
ADD CONSTRAINT [PK_AlleFamilienStandAngaben]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'AlleFinanzielleSituationen'
ALTER TABLE [dbo].[AlleFinanzielleSituationen]
ADD CONSTRAINT [PK_AlleFinanzielleSituationen]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'AlleIdentifikationsArten'
ALTER TABLE [dbo].[AlleIdentifikationsArten]
ADD CONSTRAINT [PK_AlleIdentifikationsArten]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'AlleKontaktDaten'
ALTER TABLE [dbo].[AlleKontaktDaten]
ADD CONSTRAINT [PK_AlleKontaktDaten]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'AlleKontoDaten'
ALTER TABLE [dbo].[AlleKontoDaten]
ADD CONSTRAINT [PK_AlleKontoDaten]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'AlleKreditWünsche'
ALTER TABLE [dbo].[AlleKreditWünsche]
ADD CONSTRAINT [PK_AlleKreditWünsche]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'AlleKunden'
ALTER TABLE [dbo].[AlleKunden]
ADD CONSTRAINT [PK_AlleKunden]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'AlleLänder'
ALTER TABLE [dbo].[AlleLänder]
ADD CONSTRAINT [PK_AlleLänder]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'AlleOrte'
ALTER TABLE [dbo].[AlleOrte]
ADD CONSTRAINT [PK_AlleOrte]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'AlleSchulabschlüsse'
ALTER TABLE [dbo].[AlleSchulabschlüsse]
ADD CONSTRAINT [PK_AlleSchulabschlüsse]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'AlleTitel'
ALTER TABLE [dbo].[AlleTitel]
ADD CONSTRAINT [PK_AlleTitel]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'AlleTitelNachstehend'
ALTER TABLE [dbo].[AlleTitelNachstehend]
ADD CONSTRAINT [PK_AlleTitelNachstehend]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'AlleWohnarten'
ALTER TABLE [dbo].[AlleWohnarten]
ADD CONSTRAINT [PK_AlleWohnarten]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [FKBeschaeftigungsArt] in table 'AlleArbeitgeber'
ALTER TABLE [dbo].[AlleArbeitgeber]
ADD CONSTRAINT [FK__tblArbeit__FKBes__35BCFE0A]
    FOREIGN KEY ([FKBeschaeftigungsArt])
    REFERENCES [dbo].[AlleBeschaeftigungsarten]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__tblArbeit__FKBes__35BCFE0A'
CREATE INDEX [IX_FK__tblArbeit__FKBes__35BCFE0A]
ON [dbo].[AlleArbeitgeber]
    ([FKBeschaeftigungsArt]);
GO

-- Creating foreign key on [FKBranche] in table 'AlleArbeitgeber'
ALTER TABLE [dbo].[AlleArbeitgeber]
ADD CONSTRAINT [FK__tblArbeit__FKBra__36B12243]
    FOREIGN KEY ([FKBranche])
    REFERENCES [dbo].[AlleBranchen]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__tblArbeit__FKBra__36B12243'
CREATE INDEX [IX_FK__tblArbeit__FKBra__36B12243]
ON [dbo].[AlleArbeitgeber]
    ([FKBranche]);
GO

-- Creating foreign key on [ID] in table 'AlleArbeitgeber'
ALTER TABLE [dbo].[AlleArbeitgeber]
ADD CONSTRAINT [FK__tblArbeit__IDArb__34C8D9D1]
    FOREIGN KEY ([ID])
    REFERENCES [dbo].[AlleKunden]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [FKFamilienstand] in table 'AlleKunden'
ALTER TABLE [dbo].[AlleKunden]
ADD CONSTRAINT [FK__tblKunde__FKFami__267ABA7A]
    FOREIGN KEY ([FKFamilienstand])
    REFERENCES [dbo].[AlleFamilienStandAngaben]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__tblKunde__FKFami__267ABA7A'
CREATE INDEX [IX_FK__tblKunde__FKFami__267ABA7A]
ON [dbo].[AlleKunden]
    ([FKFamilienstand]);
GO

-- Creating foreign key on [ID] in table 'AlleFinanzielleSituationen'
ALTER TABLE [dbo].[AlleFinanzielleSituationen]
ADD CONSTRAINT [FK__tblFinanz__IDFin__3F466844]
    FOREIGN KEY ([ID])
    REFERENCES [dbo].[AlleKunden]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [FKIdentifikationsArt] in table 'AlleKunden'
ALTER TABLE [dbo].[AlleKunden]
ADD CONSTRAINT [FK__tblKunde__FKIden__2A4B4B5E]
    FOREIGN KEY ([FKIdentifikationsArt])
    REFERENCES [dbo].[AlleIdentifikationsArten]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__tblKunde__FKIden__2A4B4B5E'
CREATE INDEX [IX_FK__tblKunde__FKIden__2A4B4B5E]
ON [dbo].[AlleKunden]
    ([FKIdentifikationsArt]);
GO

-- Creating foreign key on [FKOrt] in table 'AlleKontaktDaten'
ALTER TABLE [dbo].[AlleKontaktDaten]
ADD CONSTRAINT [FK__tblKontak__FKOrt__2E1BDC42]
    FOREIGN KEY ([FKOrt])
    REFERENCES [dbo].[AlleOrte]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__tblKontak__FKOrt__2E1BDC42'
CREATE INDEX [IX_FK__tblKontak__FKOrt__2E1BDC42]
ON [dbo].[AlleKontaktDaten]
    ([FKOrt]);
GO

-- Creating foreign key on [ID] in table 'AlleKontaktDaten'
ALTER TABLE [dbo].[AlleKontaktDaten]
ADD CONSTRAINT [FK__tblKontak__IDKon__2D27B809]
    FOREIGN KEY ([ID])
    REFERENCES [dbo].[AlleKunden]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ID] in table 'AlleKontoDaten'
ALTER TABLE [dbo].[AlleKontoDaten]
ADD CONSTRAINT [FK__tblKontoD__IDKon__398D8EEE]
    FOREIGN KEY ([ID])
    REFERENCES [dbo].[AlleKunden]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ID] in table 'AlleKreditWünsche'
ALTER TABLE [dbo].[AlleKreditWünsche]
ADD CONSTRAINT [FK__tblKredit__IDKre__3C69FB99]
    FOREIGN KEY ([ID])
    REFERENCES [dbo].[AlleKunden]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [FKSchulabschluss] in table 'AlleKunden'
ALTER TABLE [dbo].[AlleKunden]
ADD CONSTRAINT [FK__tblKunde__FKSchu__29572725]
    FOREIGN KEY ([FKSchulabschluss])
    REFERENCES [dbo].[AlleSchulabschlüsse]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__tblKunde__FKSchu__29572725'
CREATE INDEX [IX_FK__tblKunde__FKSchu__29572725]
ON [dbo].[AlleKunden]
    ([FKSchulabschluss]);
GO

-- Creating foreign key on [FKTitel] in table 'AlleKunden'
ALTER TABLE [dbo].[AlleKunden]
ADD CONSTRAINT [FK__tblKunde__FKTite__24927208]
    FOREIGN KEY ([FKTitel])
    REFERENCES [dbo].[AlleTitel]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__tblKunde__FKTite__24927208'
CREATE INDEX [IX_FK__tblKunde__FKTite__24927208]
ON [dbo].[AlleKunden]
    ([FKTitel]);
GO

-- Creating foreign key on [FKTitelNachstehend] in table 'AlleKunden'
ALTER TABLE [dbo].[AlleKunden]
ADD CONSTRAINT [FK__tblKunde__FKTite__25869641]
    FOREIGN KEY ([FKTitelNachstehend])
    REFERENCES [dbo].[AlleTitelNachstehend]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__tblKunde__FKTite__25869641'
CREATE INDEX [IX_FK__tblKunde__FKTite__25869641]
ON [dbo].[AlleKunden]
    ([FKTitelNachstehend]);
GO

-- Creating foreign key on [FKWohnart] in table 'AlleKunden'
ALTER TABLE [dbo].[AlleKunden]
ADD CONSTRAINT [FK__tblKunde__FKWohn__286302EC]
    FOREIGN KEY ([FKWohnart])
    REFERENCES [dbo].[AlleWohnarten]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__tblKunde__FKWohn__286302EC'
CREATE INDEX [IX_FK__tblKunde__FKWohn__286302EC]
ON [dbo].[AlleKunden]
    ([FKWohnart]);
GO

-- Creating foreign key on [FKLand] in table 'AlleOrte'
ALTER TABLE [dbo].[AlleOrte]
ADD CONSTRAINT [FK__tblOrt__FKLand__145C0A3F]
    FOREIGN KEY ([FKLand])
    REFERENCES [dbo].[AlleLänder]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__tblOrt__FKLand__145C0A3F'
CREATE INDEX [IX_FK__tblOrt__FKLand__145C0A3F]
ON [dbo].[AlleOrte]
    ([FKLand]);
GO

-- Creating foreign key on [FKStaatsangehoerigkeit] in table 'AlleKunden'
ALTER TABLE [dbo].[AlleKunden]
ADD CONSTRAINT [FK__tblKunde__FKStaa__25869641]
    FOREIGN KEY ([FKStaatsangehoerigkeit])
    REFERENCES [dbo].[AlleLänder]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__tblKunde__FKStaa__25869641'
CREATE INDEX [IX_FK__tblKunde__FKStaa__25869641]
ON [dbo].[AlleKunden]
    ([FKStaatsangehoerigkeit]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------