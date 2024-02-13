use master; 
go
drop database djecjaigraonica;
go
create database djecjaigraonica; 
go 
alter database djecjaigraonica collate Croatian_CI_AS;
go
use djecjaigraonica;

create table skupine(
skupineID int not null primary key identity(1,1),
naziv varchar(50) not null,
grupa varchar(50) not null,
soba varchar(50),
tetaID int
);

create table djeca(
id int not null primary key identity(1,1),
ime varchar(50) not null,
prezime varchar(50) not null,
imeRoditelja varchar(50) not null,
prezimeRoditelja varchar(50) not null,
vrijemeDolaska datetime

);

create table grupe(
skupina int,
djete int
);

create table tete(
id int not null primary key identity(1,1), 
ime varchar(50) not null,
prezime varchar(50) not null,
oib char(11) not null
);

alter table grupe add foreign key (skupina) references skupine(skupineID);
alter table grupe add foreign key (djete) references djeca(id); 
alter table skupine add foreign key(tetaID) references tete(id); 