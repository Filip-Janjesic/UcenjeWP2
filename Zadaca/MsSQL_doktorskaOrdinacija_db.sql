use master;
go
drop database doktorskaOrdinacija;
go
create database doktorskaOrdinacija;
go
alter database doktorskaOrdinacija collate Croatian_CI_AS; 
go
use  doktorskaOrdinacija;


create table pacijenti(
id int not null primary key identity (1,1), 
ime varchar(50) not null,
prezime varchar(50) not null,
oib char (11) not null,
spol char (1) not null,
brojMedOsiguranja varchar(50) not null 
);

create table doktor (
id int not null primary key identity(1,1), 
ime varchar(50) not null,
prezime varchar(50) not null,
oib char(11) not null, 
specijalizacija varchar(50) not null
);

create table medSestre(
id int not null primary key identity(1,1), 
ime varchar(50) not null,
prezime varchar(50) not null,
oib char(11) not null,
tim int
);

create table lijecenje(
tim int,
pacijent int,
doktor int
);

create table timovi (
timID int not null primary key, 
medSestra int
);


alter table timovi add foreign key (medSestra) references medSestre(id);
alter table lijecenje add foreign key (tim) references timovi(timID);
alter table lijecenje add foreign key (pacijent) references pacijenti(id);
alter table lijecenje add foreign key (doktor) references doktor(id); 