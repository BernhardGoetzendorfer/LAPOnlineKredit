use dbOnlineKredit
go

insert into tblLand
select [Spalte 0], [Spalte 1]
from landort.dbo.Länderneu
where [Spalte 0] <> ''
go

insert into tblOrt(FKLand, PLZ, Ort)
select 'AUT', PLZ, Ort
from landort.dbo.tblOrt
go
 


