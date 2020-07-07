IF DB_ID('PizzaRestourant') IS NULL
CREATE DATABASE PizzaRestourant
GO

USE PizzaRestourant
IF EXISTS (SELECT NAME FROM sys.sysobjects WHERE NAME = 'tblOrders')
DROP TABLE tblOrders
IF EXISTS (SELECT NAME FROM sys.sysobjects WHERE NAME = 'tblGuests')
DROP TABLE tblGuests
IF EXISTS (SELECT NAME FROM sys.sysobjects WHERE NAME = 'tblEmployees')
DROP TABLE tblEmployees

CREATE TABLE tblGuests(
Id int PRIMARY KEY IDENTITY(1,1),
Username nvarchar(30),
Password nvarchar(30)
);

CREATE TABLE tblEmployees(
Id int PRIMARY KEY IDENTITY(1,1),
Username nvarchar(30),
Password nvarchar(30)
);

CREATE TABLE tblOrders(
Id int PRIMARY KEY IDENTITY(1,1),
Price int,
State nvarchar(20),
Created Date,
FKGuest int
);

ALTER TABLE tblOrders ADD FOREIGN KEY(FKGuest) REFERENCES tblGuests(Id);

USE PizzaRestourant
GO
INSERT INTO tblGuests(Username, Password) VALUES ('2201996800109','Gost');
INSERT INTO tblEmployees(Username, Password) VALUES('Zaposleni','Zaposleni');
