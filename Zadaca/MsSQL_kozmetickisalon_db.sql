use master;
go 
drop database if exists kozmeticki;
go
create database kozmeticki;
go 
alter database kozmeticki collate CROATIAN_CI_AS; 
go 
use kozmeticki;


create table posjeta(
id int not null primary key identity(1,1),
korisnik int,
termin datetime, 
djelatnik int,
usluga int
);

create table korisnici (
id int not null primary key identity(1,1), 
brmobitel varchar(50),
spol char(1),
tipkoze varchar(50),
dob int, 
napomena varchar(100)
);

create table djelatnici (
ID int not null primary key identity(1,1),
ime varchar (50),
prezime varchar(50),
specijaliziranZa varchar(50)
);

create table usluge (
ID int not null primary key identity(1,1),
naziv varchar (50),
cijena decimal (10,2)
);

alter table posjeta add foreign key (korisnik) references korisnici(id); 
alter table posjeta add foreign key (djelatnik) references djelatnici(id);
alter table posjeta add foreign key (usluga) references usluge(id);