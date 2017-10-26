--create database AddressBook

USE AddressBook
GO

--drop table Contact_Address
--drop table Email
--drop table Telephone
--drop table Contact
--drop table Address

create table Contact(
Id int identity(1,1) primary key,
Name nvarchar(50) not null,
ContactType varchar(15) not null
CHECK (ContactType in ('Personlig','Jobb','Övrig'))
)


create table Address (
Id int identity(1,1) primary key,
Street nvarchar(30) not null,
City nvarchar(30) not null,
PostalCode varchar(10) not null
)

create table Contact_Address (
ContactId int not null foreign key references Contact(Id)
on delete cascade,
AddressId int not null foreign key references Address(Id)
on delete cascade
)

create table Telephone (
Id int identity primary key,
CountryCode char(3) not null,
DiallingCode char(3) not null,
TelephoneNumber char(7) not null,
ContactId int not null foreign key references Contact(Id)
on delete cascade
)

create table Email (
Id int identity primary key,
Email varchar(30) not null,
ContactId int not null foreign key references Contact(Id)
on delete cascade
)


--Input data

--Personlig kontakt, Jobb kontakt, Övriga kontakter. 
USE AddressBook
GO

--delete from Contact

insert into contact (Name, ContactType)
values
('Sandra Kassman', 'Personlig'),
('Viktor Samuelsson', 'Jobb'),
('David Ahlbom', 'Personlig'),
('Erik Ström', 'Personlig'),
('Gustav Hoffer', 'Övrig')

insert into Address (Street,City,PostalCode)
values
('Meteorvägen 56','Täby','18333'),
('Kometvägen 56','Täby','18333'),
('Sveavägen 1','Stockholm','18250'),
('BlasieholmsTorg 12','Stockholm','18250'),
('Skönavägen','Göteborg','12555')


insert into Contact_Address (ContactId,AddressId)
values
(1,1),
(2,4),
(3,2),
(4,1),
(5,5)

insert into Telephone (CountryCode,DiallingCode,TelephoneNumber,ContactId)
values
('+46','070','1234567',1),
('+46','073','9876543',2),
('+46','076','1111111',3),
('+46','076','2222222',4),
('+46','073','3333333',5),
('+46','070','4444444',1),
('+46','070','5555555',2)

insert into Email (Email, ContactId)
values
('Sandra@gmail.com',1),
('SandraOchMarkus@gmail.com',1),
('Sandra@hotmail.com',1),
('Virre@gmail.com',2),
('Dave@gmail.com',3),
('Ström@gmail.com',4),
('Gurra@gmail.com',5),
('GurraG@live.com',5)




