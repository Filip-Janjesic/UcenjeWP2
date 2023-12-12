--create database urarSilvija; 

use urarSilvija;

--create table satovi (
--id int,
--model varchar(50),
--proizvodac varchar(50),
--serijskiBroj varchar(50)
--);

--create table kvarovi(
--id int,
--satSerijskiBroj varchar(50), 
--naziv varchar(50), 
--opisKvara varchar(500)
--);

--create table korisnik(
--id int, 
--ime varchar(50),
--prezime varchar(50),
--kontakt varchar(50),
 
--);

--create table popravak(
--id int, 
--kvar varchar(50),
--klijent varchar(50),
--cijena varchar(50),
--datumPreuzimanja datetime, 
--datumZavrsetka datetime
--);


--create table pracenjeSegrta(
--kvarID int,
--ucinak varchar(200)
--);

--alter table popravak alter column cijena decimal(6,2); 

alter table popravak drop column klijent;
alter table popravak add korisnik varchar(50);