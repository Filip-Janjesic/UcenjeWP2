use master;
go

drop database if exists webshop;
go

create database webshop;
go

alter database webshop collate Croatian_CI_AS;
go

use webshop;

create table proizvodi (

	sifra int not null primary key identity(1,1),
	naslov varchar(50) not null,
	autor varchar(50) not null,
	slika varchar(255) not null,
	cijena decimal(18,2) not null,
	kategorija int not null,
	sadrzaj text not null,
	vrijeme_kreiranja varchar(50) not null,

);

create table korisnici (

	sifra int not null primary key identity(1,1),
	ime varchar(50) not null,
	prezime varchar(50) not null,
	lozinka char (60) not null,
	uloga varchar(50) not null,
	email varchar(100),
	vrijeme_registracije varchar(50) ,
	--potvrdite_email_token varchar(255),
	--reset_lozinke_token varchar(255),
	--upamtime_token varchar(255)
	
);

create table narudzbe(

	sifra int not null primary key identity(1,1),
	status varchar(50) not null,
	kolicina varchar(50) not null,
	transakcijski_id varchar(50) not null,
	datum_narudzbe date not null,
	korisnik int
	
);

create table kategorije(

	sifra int not null primary key identity(1,1),
	naziv varchar(50)

);

create table komentari(

	sifra int not null primary key identity(1,1),
	korisnik int,
	proizvod int,
	komentar text,
	komentar_datum date,
	odobreno varchar(100)

);

create table ocjene(

	korisnik int,
	proizvod int,
	ocjena int

);

create table kupljeno(

	narudzbe int,
	proizvod int,
	cijena decimal(18,2)

);

alter table kupljeno add foreign key (narudzbe) references narudzbe(sifra);
alter table kupljeno add foreign key (proizvod) references proizvodi(sifra);

alter table proizvodi add foreign key (kategorija) references kategorije(sifra);
alter table narudzbe add foreign key (korisnik) references korisnici(sifra);

alter table komentari add foreign key (proizvod) references proizvodi(sifra);
alter table komentari add foreign key (korisnik) references korisnici(sifra);

alter table ocjene add foreign key (proizvod) references proizvodi(sifra);
alter table ocjene add foreign key (korisnik) references korisnici(sifra);
