use master;
go
drop database klubcitateljaknjiga;
go
create database klubcitateljaknjiga;
go
alter database klubcitateljaknjiga collate Croatian_CI_AS;
go
use klubcitateljaknjiga;

create table citatelji(
id int not null primary key identity(1,1), 
serijskiBrojIskaznice int not null,
ime varchar(20) not null,
prezime varchar(20) not null,
evidencijaPosudbe int
);

create table vlasnici(
id int not null primary key identity(1,1),
citatelj int,
evidencijaVlasnistva int
);

create table knjige(
id int not null primary key identity(1,1),
barkodBroj int not null,
naziv varchar(50) not null,
autor varchar(50) not null,
cijena decimal (6,2) not null
);

create table evidencijaVlasnistva(
vlasnik int,
knjiga int
);

create table evidencijaPosudivanja(
citatelj int,
knjiga int,
datumPosudivanja datetime
);

alter table evidencijaVlasnistva add foreign key (vlasnik) references vlasnici(id);
alter table evidencijaVlasnistva add foreign key (knjiga) references knjige(id);
alter table evidencijaPosudivanja add foreign key (citatelj) references citatelji(id);
alter table evidencijaPosudivanja add foreign key (knjiga) references knjige(id);
alter table vlasnici add foreign key (citatelj) references citatelji(id);