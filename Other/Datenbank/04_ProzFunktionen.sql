-- Funktion, die ausrechnet wie viel Geld
-- dem Kunden zur Verfügung steht (Input: IDKunde, Output: Betrag)
drop procedure dbo.GeldzurVerfuegung
go

create proc GeldzurVerfuegung
(
	@idkunde int
)
as
begin

select  Vorname, Nachname, (MonatsEinkommen - Wohnkosten + SonstigeEinkommen - SonstigeAusgaben) as [Geld zur Verfügung]
from tblKunde
	join tblFinanzielleSituation on IDFinanzielleSituation = IDKunde
	where IDKunde = @idkunde
end

exec GeldzurVerfuegung 3



-- Prozedur, die einen Kunden einträgt


-- Proz, die einen Kredit bewilligt oder ablehnt (update)


-- Proz, die die Kreditrate berechnet (einfach!!!)


-- Proz, die den Login überprüft 







CREATE PROCEDURE HumanResources.uspGetEmployeesTest2   
    @LastName nvarchar(50),   
    @FirstName nvarchar(50)   
AS   

    SET NOCOUNT ON;  
    SELECT FirstName, LastName, Department  
    FROM HumanResources.vEmployeeDepartmentHistory  
    WHERE FirstName = @FirstName AND LastName = @LastName  
    AND EndDate IS NULL;  
GO  