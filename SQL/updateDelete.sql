
-- UPDATE NAREDBA

select * from polaznici;

-- mijenjao sam samo jednu kolonu (prezime)
update polaznici set prezime='Kartik' 
where sifra=17;

-- mjenjam tri kolone (prezime, oib, brojugovora)
update polaznici set prezime='Šuler',
oib='80352353849' , brojugovora='25/20023'
where sifra=17;

select * from polaznici where sifra=17;


select * from smjerovi;

update smjerovi set cijena=1000
where sifra in (2,3);

-- uveæanje svih cijena za 20%
update smjerovi set cijena=cijena*1.2;

-- umanjenje svih cijena za 20%
update smjerovi set cijena=cijena*0.8;


-- Smanjite cijenu svim smjerovima za 15 eura
update smjerovi set cijena=cijena-15;

-- Uveæajte cijenu svim smjerovima za 15 eura
update smjerovi set cijena=cijena+15;

select * from  smjerovi;

-- svaku upisninu smjera postavitina 10% od cijene smjera
update smjerovi set upisnina=cijena*0.1;

--Postavite da je Java programiranje 1489.52

update smjerovi set cijena=1489.52 where sifra=2;



-- DELETE NAREDBA

select * from smjerovi;

-- unesite novi smjer: Python programiranje

insert into smjerovi (naziv)
values ('Python programiranje');

delete from smjerovi where sifra=4;

-- neæe obrisati niti jedan red jer je smjer VK u grupe
delete from smjerovi;

-- Obrišite sebe kao èlana grupe WP2

select * from clanovi;

select * from polaznici;

delete from clanovi where polaznik=9;

