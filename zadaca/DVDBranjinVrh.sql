use master;
go
drop database if exists DVDBranjinVrh;
go
create database DVDBranjinVrh collate croatian_CI_AS;
go
use DVDBranjinVrh;

-- mogu li korisnici biti i posluzitelji informacija

create table dogadanja (
id int not null primary key identity(1,1),
naziv varchar(100) not null,
opis varchar(2000),
foto varchar(200),
datumDogadaja datetime not null,
datumObjave datetime not null,
lokacija varchar(50),
posluziteljInformacija int,
DVD int
);

create table vijesti(
id int not null primary key identity(1,1),
naslov varchar(100),
tekst varchar(2000),
foto varchar(200),
datumObjave datetime,
posluziteljInformacija int,
DVD int
);

create table kontaktForma(
id int not null primary key identity(1,1),
ime varchar(50),
prezime varchar(50),
email varchar(200),
upit varchar(2000)
);


create table posluziteljiInformacija(
id int not null primary key identity(1,1),
ime varchar(50) not null,
prezime varchar(50) not null,
userName varchar(50) not null,
password varchar(20) not null,
email varchar(200) not null
);
create table DVDi (
id int not null primary key identity(1,1),
naziv varchar(60) not null,
logotip varchar(200),
adresa varchar(100) not null,
email varchar(200),
link varchar(200)
);

alter table dogadanja add foreign key (posluziteljInformacija) references 
posluziteljiInformacija(id);
alter table dogadanja add foreign key (posluziteljInformacija) references 
DVDi(id);
alter table vijesti add foreign key (posluziteljInformacija) references 
posluziteljiInformacija(id);
alter table vijesti add foreign key (posluziteljInformacija) references 
DVDi(id);
insert into DVDi (naziv, logotip, adresa, email, link) values 
('DVD Branjin vrh', 
'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSLs-vnDDRxAPScI113q1nWihmq9Ws_bfe9rUsDbSf1mrSwiiTiDKmaqja33lYPjVQYrgE&usqp=CAU',
'SVETOG KRIŽA 57/A, 31301, Branjin Vrh', 'dvdbranjingvrh@gmail.com', 'www.DVDBranjinVrh.com'),
('DVD Osijek - Gornji grad','http://dvdosgg.hr/wp-content/uploads/2017/04/dvd-logo.png',
'Ul. Pavla Pejačevića 44','dvdosgg@gmail.com', 'https://dvdosgg.hr/'),
('DVD Retfala Osijek','https://dvd-retfala-osijek.spis.hvz.hr/storage/spis_113/logo.png',
'Ul. Šandora Petefija 1','dvdretfalaos@gmail.com','https://dvd-retfala-osijek.spis.hvz.hr/'),
('DVD Osijek Tenja','https://web.facebook.com/photo/?fbid=586169339579647&set=a.108075787389007',
'Ul. Vladka Mačeka 18, 31207, Tenja','dvdostenja@gmail.com',null),
('JPVP Grada Belog Manastira','http://vatrogasci-bm.hr/FOTOrazno/grbokrugli.gif',
'Ul. Vladana Desnice 2, 31300, Beli Manastir','jpvpbelimanastir@gmail.com',
'http://vatrogasci-bm.hr/naslovnica.htm');

insert into posluziteljiInformacija(ime, prezime, userName, password, email) values
('Tomislav','Tomić','Sef007','gasimSVEu16','ttomic@gmail.com'),
('Ivan','Ivić','IvanImotski','malaplavaizbirtije','iivic@gmail.com'),
('Robert','Robić','Bonaparte','Waterloo1815','rrobic@gmail.com');

insert into dogadanja (naziv, opis, foto, datumDogadaja, datumObjave, lokacija, posluziteljInformacija, DVD) 
values ('Dan DVD Branjin Vrh','Poštovani čitatelji pozivamo Vas na obljetnicu osnivanja DVD Branjin vrh...', null,
'2023-10-11 18:00:00', '2023-10-3 9:00:00', 'SVETOG KRIŽA 57/A, 31301, Branjin Vrh', 1, 1),
('Javna radionica JPVP Beli Manastir','Svi zainteresirani građani moći će na trgu Slobode prisustvovati
radionici JPVP gdje će stručnjaci kroz demonstracije prikazivati pravilna postupanja u situacijama poput
prometnih nesreća, požara u višestambenim zgradama ...',null,'2022-8-11 11:00:00','2022-8-11 11:00:00',
'Trg Slobode Beli Manastir', 3, 5),
('Dani otvorenih vrata DVD Osijek - Gorni Grad',null,null,'2022-6-2 09:00:00','2022-5-27 11:00:00',
'Ul. Pavla Pejačevića 44', 2, 2);

insert into vijesti (naslov, tekst, foto, datumObjave, posluziteljInformacija, DVD) values
('Nova oprema za DVD Retfala Osijek','Projektom Hrvatske vatrogasne zajednice i MUP-a DVD Retfala Osijek
opremljeno je  ....',null, '2174-7-11 10:00:00', 1, 3),
('Članovi DVD Tenja gasili požar kod Zadra','...',null,'2023-7-11 09:00:00', 2, 4),
('Upozorenje za građane','Zbog ekstemnih vrućina preporučujemo ...',null,'2023-7-15 09:00:00', 1,1);