use master;
go
drop database if exists opg;
go
create database opg;
go
alter database opg collate croatian_ci_as;
go
use opg;

create table sirovine(
id int not null primary key identity(1,1), 
naziv varchar(50),
cijena decimal (12,2)
);

create table postupci (
sirovina int,
proizvod int,
djelatnik int
);

create table proizvodi(
id int not null primary key identity(1,1),
naziv varchar(50), 
postupak varchar(50),
cijena decimal (12,2)
);

create table djelatnici(
id int not null primary key identity(1,1), 
ime varchar(50) not null,
prezime varchar(50) not null,
oib char(11) not null,
iban varchar(50)
);

alter table postupci add foreign key (sirovina) references sirovine(id);
alter table postupci add foreign key (proizvod) references proizvodi(id);
alter table postupci add foreign key (djelatnik) references djelatnici(id); 