--create database samostan;

use samostan; 

create table svecenici (
id int,
ime varchar(20),
prezime varchar(20),
oib char(11),
nadredeni bit, 
grupa varchar(20),
posao varchar(50) 
);

create table poslovi (
id int, 
naziv varchar(50),
vrsta varchar(50),
napomena varchar(200) 
);
