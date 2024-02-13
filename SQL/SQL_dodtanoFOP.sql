-- Svim polaznicima na Web programiranju
-- imenu dodaj slovo W
update a 
set
a.ime = concat(a.ime,'W')
from polaznik a
inner join clan b on a.sifra =b.polaznik 
inner join grupa c on b.grupa =c.sifra 
inner join smjer d on c.smjer =d.sifra 
where d.naziv = 'Web programiranje';

-- Obriši sve članove na smjeru JAVA programiranje
delete c
from smjer a
inner join grupa b on a.sifra =b.smjer 
inner join clan c on b.sifra =c.grupa 
where a.naziv='Web programiranje';


-- funkcije

select getdate();

select dateadd(day,-45,getdate());

select upper(ime) from polaznici;

select concat(ime, ' ', prezime) as polaznik from polaznici
order by prezime;

SELECT * FROM smjerovi;

update smjerovi set cijena=rand()*1000;

select rand();

-- dodavanje nove kolone u tablicu smjer
alter table smjerovi add iznos decimal(18,2) ;

select * from smjerovi;

update smjerovi set iznos=1;

--zabraniti nepoznavanje iznos
alter table smjerovi alter column iznos decimal(18,2) not null ;


-- čitati: https://learn.microsoft.com/en-us/sql/t-sql/functions/functions?view=sql-server-ver16

CREATE FUNCTION email(
	@ime varchar(50), @prezime varchar(50)
	)
RETURNS varchar(150) AS
BEGIN
    return concat(left(lower(@ime),1), lower(
			replace(
			replace(
			replace(
			replace(
			replace(replace(upper(@prezime),' ',''),'Č','C')
			,'Š','S')
			,'Đ','D')
			,'Ć','C')
			,'Ž','Z')
			), '@edunova.hr');
END;

drop function email;


select dbo.email(ime,prezime) as mail from polaznici;


-- koliko sam star dana
select datediff(day, '1980-12-07',getdate());


-- OKIDAČI

create table logiranje(
tko varchar(255),
sto varchar(255),
kada datetime default getdate()
);

select * from logiranje;

CREATE TRIGGER polaznik_unos
ON polaznici
AFTER INSERT
AS
BEGIN
	insert into logiranje (tko,sto) 
	select 'Unos nove osobe', concat(ime, ' ', prezime) from inserted;

END

insert into polaznici (ime,prezime,email) 
values ('Pero','Perić','email');

select top 1 sifra from polaznici order by 1 desc;


CREATE TRIGGER polaznik_promjena
ON polaznici
AFTER Update
AS
BEGIN
	insert into logiranje (tko,sto) 
	SELECT 'Promjena imena osobe', concat(a.ime, ' - ', b.ime)
      FROM Inserted a
      INNER JOIN Deleted b ON a.sifra = b.sifra;
END;


update polaznici set ime='Marko' where sifra=31;


CREATE TRIGGER polaznik_brisanje
ON polaznici
AFTER delete
AS
BEGIN
	insert into logiranje (tko,sto) 
	SELECT 'Brisanje osobe', concat(ime, ' - ', ime) FROM Deleted;
END;

delete from polaznici where sifra=31;

select * from polaznici;


-- Procedure

CREATE PROCEDURE brisismjer @sifrasmjera int
AS
	delete from clanovi where 
	grupa in (select sifra from grupe where smjer=@sifrasmjera);

	delete from grupe where smjer = @sifrasmjera;

	delete from smjerovi where sifra=@sifrasmjera;
GO

exec brisismjer 1;

select * from smjerovi;