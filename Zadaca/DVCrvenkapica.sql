use master;
go
drop database if exists DVCrvenkapica;
go
create database DVCrvenkapica collate croatian_ci_as;
go
use DVCrvenkapica;

create table djeca(
id int not null primary key identity(1,1),
ime varchar(50),
prezime varchar(50),
godinarodenja datetime,
spol char(1),
odgojnaSkupina int 
);

create table roditelji(
id int not null primary key identity(1,1),
ime varchar(50) not null,
prezime varchar(50) not null,
oib char(11) not null,
adresa varchar(100) not null,
brMob varchar(50),
email varchar(100)
);

create table prijave(
dijete int not null,
roditelj int not null,
datumUpisa datetime not null
);

create table odgojneSkupine(
id int not null primary key identity(1,1),
naziv varchar(50) not null,
odgajateljica varchar(50),
maksBrpolaznica int,
);

create table dogadaji(
id int not null primary key identity(1,1),
naslov varchar(100) not null,
tekst varchar(1000) not null,
lokacijaNaslovneFotografije varchar(200),
galerijaFotografija int,

);

create table fotografije(
id int not null primary key identity(1,1),
lokacija varchar(200) not null
);

create table galerije(
id int not null primary key identity(1,1),
naziv varchar(100)
);

create table galerijeFotografija(
galerija int,
fotografija int
);

alter table djeca add foreign key (odgojnaSkupina) references odgojneSkupine(id); 
alter table prijave add foreign key (dijete) references djeca(id);
alter table prijave add foreign key (roditelj) references roditelji(id);
alter table galerijeFotografija add foreign key (fotografija) references fotografije(id);
alter table galerijeFotografija add foreign key (galerija) references galerije(id);  
alter table dogadaji add foreign key (galerijaFotografija) references galerije(id);

insert into odgojneSkupine(naziv, odgajateljica, maksBrpolaznica) values 
('Plavi','Maja Majić',22),('Zeleni','Darko Darkić',20),('Crveni','Tiho Tihić',23);

insert into djeca (ime, prezime, godinarodenja, spol, odgojnaSkupina) values
('Tamara','Anić','2017-10-9','ž',1),
('Dinko','Dinić','2016-4-7','M',1),
('Janko','Stanko','2017-5-1','M',1),
('Dubravka','Dubrava','2018-5-6','Ž',2),
('Janica','Janić','2019-5-6','Ž',2),
('Dobrica','Zloćko','2018-8-9','M',2),
('Janez','Janša','2020-4-17','M',3),
('Mile','Mali','2020-4-21','M',3);

insert into roditelji (ime, prezime, oib, adresa, brMob, email) values 
('Anita','Anić','12345678910','Kolodvorska ulica 137a, 32236 Ilok', '095 111 222', 'aa78@gmail,com'),
('Vinko','Anić','12345678911','Kolodvorska ulica 137a, 32236 Ilok','095 222 111','va77@gmail.com'),
('Dina','Dinić','12345678912','Ulica Ulice 12, 32236 Ilok','091 767 842','zastoulicanemasvojuulicu@gmail.com'),
('Marko','Dinić','12345678913','Ulica Ulice 12, 32236 Ilok','091 678 999','ghostrider@hotmail.com');

insert into prijave (dijete, roditelj, datumUpisa) values 
(1,1,'2020-11-5'), 
(1,2,'2020-11-5'), 
(2,3,'2019-5-11'), 
(2,4,'2019-5-11');

insert into fotografije(lokacija) values 
('d:/foto/radionica1/1.jpg'),
('d:/foto/radionica1/2.jpg'),
('d:/foto/radionica2/1.jpg'),
('d:/foto/radionica2/2.jpg');

insert into galerije (naziv) values ('Radionica 1'),
('Radionica 1'),('Radionica 2'),('Radionica 2');

insert into galerijeFotografija (galerija, fotografija) values 
(1,1), (1,2), (2,3),(2,4);

insert into dogadaji(naslov, tekst, lokacijaNaslovneFotografije, galerijaFotografija) 
values 
('Radionica1','Odrzana radionica 1 grupe Plavi','d:/foto/radionica1/5.jpg',1),
('Radionica2','Odrzana radionica 1 grupe Zeleni','d:/foto/radionica2/3.jpg',2);
 