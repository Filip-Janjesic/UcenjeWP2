use master;
go
drop database if exists odvjetnik;
go
create database odvjetnik;
go
alter database odvjetnik collate croatian_ci_as;
go
use odvjetnik;

create table klijenti(
id int not null primary key identity(1,1), 
ime varchar(50),
prezime varchar(50),
);

create table postupci(
klijent int,
obrana int
);

create table obrane(
id int not null primary key identity(1,1), 
naziv varchar(50) not null,
brojPostupka varchar(50) not null
);

create table sudionici(
obrana int,
suradnik int
);

create table suradnici(
id int not null primary key identity(1,1), 
ime varchar (50) not null,
prezime varchar(50) not null,
oib char(11) not null
);

alter table sudionici add foreign key (obrana) references obrane(id); 
alter table sudionici add foreign key (suradnik) references suradnici(id);
alter table postupci add foreign key (klijent) references klijenti(id);
alter table postupci add foreign key (obrana) references obrane(id); 