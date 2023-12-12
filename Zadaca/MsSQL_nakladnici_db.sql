use master;
go 
drop database if exists nakladnici;
go
create database nakladnici;
go
alter database nakladnici collate croatian_ci_as;
go
use nakladnici;

create table nakladnici (
id int not null primary key identity(1,1), 
naziv varchar(50),
lokacija int,
ponuda int

);

create table lokacije(
nakladnik int,
mjesto int
);

create table mjesta(
id int not null primary key identity(1,1),
adresa varchar(50),
naziv varchar(50),
koordinati varchar(50)
);

create table djela(
id int not null primary key identity(1,1), 
naziv varchar(50),
autor varchar(50),
cijena decimal(8,2)
);

create table ponuda(
nakladnik int,
djelo int
);

alter table ponuda add foreign key (nakladnik) references nakladnici(id);
alter table ponuda add foreign key (djelo) references djela(id);
alter table lokacije add foreign key (nakladnik) references nakladnici(id); 
alter table lokacije add foreign key (mjesto) references mjesta(id); 