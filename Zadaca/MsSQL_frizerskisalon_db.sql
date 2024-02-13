use master;
go
drop database frizerskisalon;
go
create database frizerskisalon;
go
alter database frizerskisalon collate Croatian_CI_AS;
go
use frizerskisalon;

create table posjete (
id int not null primary key identity(1,1),
korisnik int,
termin datetime not null, 
djelatnik int not null,
usluga int
);

create table djelatnici (
ID int not null primary key identity(1,1), 
ime varchar(50) not null,
prezime varchar(50) not null,

);

create table korisnici (
id int not null primary key identity(1,1),
brojmobitela varchar(50) not null,
spol char(1) not null, 
tipkose varchar(50) not null
); 

create table usluge (
ID int not null primary key identity(1,1), 
naziv varchar(50) not null,
cijena decimal (10,2) not null
);

alter table posjete add foreign key (korisnik) references korisnici(id); 
alter table posjete add foreign key (djelatnik) references djelatnici(id);
alter table posjete add foreign key (usluga) references usluge(id);
