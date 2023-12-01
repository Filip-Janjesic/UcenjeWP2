use master;
go
drop database fakultet;
go
create database fakultet;
go
alter database fakultet collate Croatian_CI_AS;
go
use fakultet;


create table studenti (
id int not null primary key identity(1,1), 
ime varchar (20) not null,
prezime varchar(20) not null,
brStudomat varchar(20) not null 
);

create table kolegiji(
id int not null primary key identity(1,1), 
naziv varchar(50) not null,
pocetak datetime,
kraj datetime
);

create table rokovi (
id int not null primary key identity(1,1), 
vrijemeOdrzavanja datetime not null,
kolegij int not null
);

create table prijavaNaIspit(
id int not null primary key identity(1,1), 
student int not null,
rok int not null
);

alter table prijavaNaIspit add foreign key (student) references studenti(id); 
alter table prijavaNaIspit add foreign key (rok) references rokovi(id);
alter table rokovi add foreign key (kolegij) references kolegiji(id);