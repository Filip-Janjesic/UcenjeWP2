use master;
go
drop database if exists kud;
go
create database kud;
go
alter database kud collate CROATIAN_CI_AS;
go
use kud;

create table nastupi(
id int not null primary key identity(1,1), 
mjesto int,
naziv varchar(50),
skupina int
);

create table mjesta(
id int not null primary key identity(1,1),
adresa varchar(50) not null,
naziv varchar(50) not null,
koordinati varchar(50),
inozemstvo bit 
);

create table clanovi(
id int not null primary key identity(1,1), 
ime varchar(50) not null,
prezime varchar(50) not null,
oib char(11),
datumIstekaPutovnice datetime,
iban varchar(50)
);

create table skupine(
clan int,
nastup int
);

alter table skupine add foreign key (clan) references clanovi(id); 
alter table skupine add foreign key (nastup) references nastupi(id);
alter table nastupi add foreign key (mjesto) references mjesta(id); 