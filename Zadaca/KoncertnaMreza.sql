use master;
go
drop database if exists koncertnamreza;
go
create database koncertnamreza collate CROATIAN_CI_AS;
go
use koncertnamreza;

create table korisnici(
id int not null primary key identity(1,1),
fotografija int,
naziv varchar(50),
sifra varchar(50),
opis int,
rezervacije int
);

create table inbox(
korisnikPosiljatelj int not null,
poruka varchar(500) not null,
korisnikPrimatelj int not null,
datumSlanja datetime not null,
jeVideno bit not null 
);

create table glazbeniDogadaji(
id int not null primary key identity(1,1),
naziv varchar(100) not null,
tekst varchar(1000) not null,
datumObjave datetime,
datumDogadaja datetime,
naslovnaFotografija varchar(200),
galerijaFotografija int,
komentariObjave int
);

create table rezervacije(
korisnik int,
glazbeniDogadaj int
);

create table fotografije (
id int not null primary key identity(1,1),
lokacijaFotografije varchar(200)
);
create table galerije(
id int not null primary key identity(1,1),
naziv varchar(100)
);
create table galerijeFotografija(
id int not null primary key,
galerija int,
fotografija int
);

create table komentari(
id int not null primary key identity(1,1),
korisnik int,
nastao datetime,
tekst varchar(500)
);

create table komentarigrupa(
komentar int, 
glazbeniDogadaj int
);

alter table galerijeFotografija add foreign key (galerija) references galerije(id);
alter table galerijeFotografija add foreign key (fotografija) references fotografije(id);
alter table inbox add foreign key (korisnikPosiljatelj) references korisnici(id);
alter table inbox add foreign key (korisnikPrimatelj) references korisnici(id);
alter table korisnici add foreign key (fotografija) references fotografije(id); 
alter table komentari add foreign key (korisnik) references korisnici (id);
alter table komentarigrupa add foreign key (komentar) references komentari(id);
alter table komentarigrupa add foreign key (glazbenidogadaj) references glazbeniDogadaji(id);
alter table rezervacije add foreign key (korisnik) references korisnici(id);
alter table rezervacije add foreign key (glazbenidogadaj) references glazbenidogadaji(id); 
alter table glazbenidogadaji add foreign key (galerijaFotografija) references galerijeFotografija(id);