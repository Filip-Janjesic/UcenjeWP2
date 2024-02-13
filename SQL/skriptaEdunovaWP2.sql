
use master;
go
drop database if exists edunovawp2;
go

create database edunovawp2;
go
alter database edunovawp2 collate Croatian_CI_AS;
go
use edunovawp2;

create table smjerovi(
sifra int not null primary key identity(1,1),
naziv varchar(60) not null,
brojsati int,
cijena decimal(18,2),
upisnina decimal(18,2),
verificiran bit
);


create table grupe(
sifra int not null primary key identity(1,1),
naziv varchar(50) not null,
predavac int,
smjer int not null,
maksimalnopolaznika int,
datumpocetka datetime
);


create table predavaci(
sifra int not null primary key identity(1,1),
ime varchar(50) not null,
prezime varchar(50) not null,
oib char(11),
email varchar(100) not null,
iban varchar(50)
);


create table polaznici(
sifra int not null primary key identity(1,1),
ime varchar(50) not null,
prezime varchar(50) not null,
oib char(11),
email varchar(100) not null,
brojugovora varchar(20)
);

create table clanovi(
grupa int not null,
polaznik int not null
);

-- vanjski ključevi
alter table grupe add foreign key (smjer) references smjerovi(sifra);
alter table grupe add foreign key (predavac) references predavaci(sifra);
alter table clanovi add foreign key (grupa) references grupe(sifra);
alter table clanovi add foreign key (polaznik) references polaznici(sifra);



-- Za početnike najbolja opcija
-- Ova naredba je unijela jedan red u tablicu
-- 1
insert into smjerovi (naziv,brojsati,cijena,upisnina,verificiran)
values ('Web programiranje',225,1325.85,null,1);

-- minimalni unos
-- primjer unosa više redova: 2
insert into smjerovi (naziv) values
-- 2
('Java programiranje'),
-- 3
('Serviser');

insert into predavaci (ime,prezime,email) values
-- 1
('Tomislav','Jakopec','tjakopec@gmail.com'),
-- 2
('Shaquille', 'O''Neal','shaki@gmail.com');



insert into polaznici (prezime,ime,email) values
('Božić','Petra','bozic.petra35@gmail.com'),
('Farkaš','Dominik','sinisartf13@gmail.com'),
('Glavaš','Natalija','natalija-glavas@hotmail.com'),
('Janić','Miroslav','miroslav.janic@gmail.com'),
('Janješić','Filip','filip.janjesic@gmail.com'),
('Jović','Nataša','natasajovic238@gmail.com'),
('Barić','Luka','lukabaric15@gmail.com'),
('Kelava','Antonio','kelava.antonio392@gmail.com'),
('Kešinović','Marijan','kesinovic957@gmail.com'),
('Leninger','Ivan','ileninger@live.com'),
('Macanga','Antonio','macanga.antonio@gmail.com'),
('Miloloža','Antonio','milolozaantonio@yahoo.com'),
('Pavković','Matija','matijapavkovic74@gmail.com'),
('Peterfaj','Karlo','karlo.peterfaj@gmail.com'),
('Plečaš','Adriana','adriana.plecas@gmail.com'),
('Senčić','Ivan','ivan.sencic2000@gmail.com'),
('Šuler','Zvonimir','zvonimir.suler@gmail.com'),
('Turček','Mario','mario.turcek@gmail.com'),
('Veseli','Domagoj','dveseli555@gmail.com'),
('Vuković','Kristijan','alanford700@gmail.com'),
('Vukušić','Ivan','ivukusic27@gmail.com'),
('Žarić','Roman','roman.zaric@gmail.com'),
('Pavlović','Ivan','ipavlovic6437@gmail.com'),
('Županić','Andrea','andrea.zupanic10@gmail.com'),
('Županić','Tomislav','tomislav.zupanic333@gmail.com'),
('Petak','Martina','petak.martina@gmail.com'),
('Perak','Marko','markoperak469@gmail.com'),
('Mokriš','Bartol','bartol567@gmail.com'),
('Jularić','Ljubomir','ljubojularic93@gmail.com'),
('Ćelić','Ivor','ivorcelic@gmail.com');



insert into grupe (naziv,smjer,datumpocetka) values
-- 1
('WP1',1,'2023-04-24 17:00:00'),
-- 2
('WP2',1,'2023-10-30 17:00:00'),
-- 3
('JP28',2,'2023-04-24 19:00:00');


insert into clanovi (grupa,polaznik) values
(2,1),(2,2),(2,3),(2,4),(2,5),(2,6),(2,7),
(2,8),(2,9),(2,10),(2,11),(2,12),(2,13),(2,14),
(2,15),(2,16),(2,17),(2,18),(2,19),(2,20),(2,21),
(2,22),(2,23),(2,24),(2,25),(2,26),(2,27),(2,28),
(2,29),(2,30);

