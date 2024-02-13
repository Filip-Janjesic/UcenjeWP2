use master;
go
drop database if exists osnovnaskola;
go
create database osnovnaskola;
go
alter database osnovnaskola collate croatian_CI_AS;
go 
use osnovnaskola;

create table djeca(
id int not null primary key identity(1,1), 
ime varchar(50),
prezime varchar(50),
spol char(1)
);

create table uciteljice(
id int not null primary key identity(1,1), 
ime varchar(20),
prezime varchar(20),

);

create table radionice(
id int not null primary key identity(1,1), 
naziv varchar(50),
tema varchar(50),
grupa int,
uciteljica int
); 

create table grupa(
dijete int,
radionica int
);

alter table grupa add foreign key (dijete) references djeca(id);
alter table grupa add foreign key (radionica) references radionice(id);
alter table radionice add foreign key(uciteljica) references uciteljice(id); 
