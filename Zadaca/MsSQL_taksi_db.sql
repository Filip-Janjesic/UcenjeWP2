--create database taksi;

use taksi;

--create table vozila(
--id int, 
--registracija varchar(20),
--marka varchar(20),
--model varchar(20),
--maksBrPutnika int 
--);

--create table vozaci (
--id int, 
--ime varchar(20),
--prezime varchar(20),
--oib char(11),
--iban varchar(50),
--vozilo varchar(50)
--);

--create table poziv(
--id int, 
--narucioU datetime,
--narucioZa datetime,
--brMobitelja varchar(50),
--pocetnaLokacija varchar(50),
--destinacija varchar(50),
--brPutnika int
--);

--create table dodatnaDestinacija(
--vožnje varchar(50),
--poziv varchar(50)
--);

--create table vožnje(
--vozač varchar(50),
--poziv varchar(50) 

----);

--alter table dodatnaDestinacija drop column vožnje; 

--alter table dodatnaDestinacija add voznja varchar(50); 

alter table vožnje drop column vozač;

alter table vožnje add vozac varchar(50); 
