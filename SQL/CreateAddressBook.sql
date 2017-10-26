--create database AddressBook

USE AddressBook
GO

create table Contact(
Id int identity primary key,
Name nvarchar(50) not null,
Type varchar(15) not null
)


create table Address (
Id int identity primary key,
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
)

create table Email (
Id int identity primary key,
Email varchar(30) not null,
ContactId int not null foreign key references Contact(Id)
)