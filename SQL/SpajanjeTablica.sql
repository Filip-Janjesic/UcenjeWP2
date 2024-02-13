select * from grupe;

select * from smjerovi where sifra=1;
-- baza edunovawp2
select a.sifra,a.naziv, b.naziv as smjer,
a.datumpocetka, c.ime, c.prezime,
concat(e.ime, ' ', e.prezime) as polaznik
from grupe a inner join smjerovi b 
on b.sifra=a.smjer left join predavaci c
on c.sifra=a.predavac
inner join clanovi d on a.sifra=d.grupa
inner join polaznici e on d.polaznik=e.sifra;

-- baza knjiznica
use knjiznica;

select * from katalog;

select a.naslov, b.ime, b.prezime, c.naziv,
d.naziv
from katalog a inner join autor b
on a.autor = b.sifra
inner join izdavac c on a.izdavac=c.sifra
inner join mjesto d on a.mjesto = d.sifra
where a.naslov like '%ljubav%'
;

--baza svastara
use svastara;

select count(*) from kupci;

-- izvucite sve kupce koji se zovu kao i Vi.

-- izvucite jedinstvena imena i prezimena kupaca
-- koji se zovu kao i Vi

select distinct ime, prezime
from kupci where ime='Tomislav';



-- baza svaštara
-- Idete u svatove i planirate kupiti poklon
-- u rasponu 1000 - 1100 eura, koliko artikala možete kupiti?

select count(*) from artikli
where cijena between 1000 and 1100;

-- Izlistati sva mjesta u općini Čepin
select b.*
from opcine a inner join mjesta b
on a.sifra = b.opcina
where a.naziv='Čepin';

-- postavite Beketincima poštanski broj 31431
update mjesta set postanskiBroj='31431' where sifra=1945;

-- Izlistajte imena i prezimena svih kupaca iz mjesta Livana
select b.ime, b.prezime
from mjesta a inner join kupci b
on b.mjesto = a.sifra
where a.naziv='Osijek';

-- koliko je bilo primki u 2016
select top 1 * from primke where 
datum between '2017-01-01' and '2017-12-31';

-- Što smo sve zaprimili na primci 14778/2017
select c.kratkinaziv, b.kolicina, b.cijena,
b.kolicina * b.cijena as iznos
from primke a 
inner join artiklinaprimci b on a.sifra=b.primka
inner join artikli c on b.artikl = c.sifra
where a.rednibroj='14778/2017'
order by 4 desc;


-- ovo je istovjetno gornjem upitu
select artikli.kratkinaziv, artiklinaprimci.kolicina, artiklinaprimci.cijena,
artiklinaprimci.kolicina * artiklinaprimci.cijena as iznos
from primke 
inner join artiklinaprimci on primke.sifra=artiklinaprimci.primka
inner join artikli on artiklinaprimci.artikl = artikli.sifra
where primke.rednibroj='14778/2017'
order by 4 desc;


-- zanima me ukupni iznos na toj primci

select sum(b.kolicina * b.cijena) as ukupniIznos
from primke a 
inner join artiklinaprimci b on a.sifra=b.primka
inner join artikli c on b.artikl = c.sifra
where a.rednibroj='14778/2017';

-- koliki su iznosi na svim primkama u sijećnju 2017. godine
select a.rednibroj, sum(b.kolicina * b.cijena) as ukupniIznos
from primke a 
inner join artiklinaprimci b on a.sifra=b.primka
inner join artikli c on b.artikl = c.sifra
where a.datum between '2017-01-01' and '2017-01-31'
group by a.rednibroj
order by 2 desc;


-- dovucite naziv dobavljača u upit

select a.rednibroj, d.naziv,
sum(b.kolicina * b.cijena) as ukupniIznos,
avg(b.kolicina * b.cijena) as prosjek,
min(b.kolicina * b.cijena) as minimalno,
max(b.kolicina * b.cijena) as maksimalno
from primke a 
inner join artiklinaprimci b on a.sifra=b.primka
inner join artikli c on b.artikl = c.sifra
inner join dobavljaci d on a.dobavljac=d.sifra
where a.datum between '2017-01-01' and '2017-12-31'
group by a.rednibroj, d.naziv
having sum(b.kolicina * b.cijena)>7000000
order by 3 desc;

-- traženje igle u plastu sijena
-- Obrisa<ti sve artikle koji nisu nikada nabavljeni
select count(*) from artikli;
select distinct artikl from artiklinaprimci;
-- podupit
select * from artikli where sifra
not in (select distinct artikl from artiklinaprimci);

--  Obrišite ta dva artikla
delete from artikli where sifra
not in (select distinct artikl from artiklinaprimci);

-- DZ
-- update i delete pomoću spajanja tablica

