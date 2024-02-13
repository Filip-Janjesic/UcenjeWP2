use master;
go
drop database if exists muzej;
go
create database muzej;
go
alter database muzej collate CROATIAN_CI_AS;
go
use muzej;

create table djela(
ID int not null primary key identity(1,1),
naziv varchar(50),
autorIme varchar (20),
autorPrezime varchar(20), 
tip varchar(20)
);

create table sponzori (
ID int not null primary key identity(1,1),
ime varchar(20),
prezime varchar(20),
oib char(11),
spol char(1),

);

create table kustosi (
ID int not null primary key identity(1,1),
ime varchar(50),
prezime varchar(50),
iban varchar(50),
oib char(11)

);

create table grupe (
djelo int,
izlozba int
);


create table izlozbe(
ID int not null primary key identity(1,1), 
naziv varchar(50), 
grupa int,
sponzor int,
prostor varchar(50),
kustos int
);

alter table grupe add foreign key (djelo) references djela(id);
alter table grupe add foreign key (izlozba) references izlozbe(id); 
alter table izlozbe add foreign key (sponzor) references sponzori(id);
alter table izlozbe add foreign key (kustos) references kustosi(id); 