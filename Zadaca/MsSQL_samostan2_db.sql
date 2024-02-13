use samostan;

--alter table svecenici drop column posao; 
--alter table svecenici drop column nadredeni;

--create table nadredeni (
--id int, 
--ime varchar(20),
--prezime varchar(20),
--oib char(11),
--iban varchar (50)
--);

--create table grupe (
--svecenci varchar(50),
--nadredeni varchar(50),
--skupina varchar(50)


alter table grupe add posao varchar(50); 