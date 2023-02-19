

CREATE DATABASE StoreDB
go 
use StoreDB
go

CREATE TABLE Product(
Id int identity(1,1),
[name] varchar(50),
[description] varchar(250),
constraint Pk_IdProducto primary key (Id));
go 
CREATE TABLE Client(
Id int identity(1,1),
[name] varchar(80),
[lastName] varchar(100),
telephone varchar(15),
constraint Pk_IdCliente primary key(Id))
go
CREATE TABLE Orders(
Id int identity (1,1),
IdProduct int,
IdClient int,
ordersDate datetime,
constraint Pk_IdOrdenes primary key(Id),
constraint Fk_IdProduct FOREIGN KEY (IdProduct) references Product(Id), 
constraint Fk_IdClient FOREIGN key (IdClient) references Client(Id))

go

INSERT INTO Client VALUES ('Pablo', 'Dominguez', '1809555555')
INSERT INTO Client VALUES ('Juano', 'Martes', '18495555555')
INSERT INTO Client VALUES ('Maria', 'Santander', '18495655555')
INSERT INTO Client VALUES ('Pepe', 'Garcia', '18495555559')
INSERT INTO Client VALUES ('Jose', 'Lamcuerdo', '184955555550')

GO
INSERT INTO Product VALUES ('Cable USB', 'cargador para bocina y telefonos.')
INSERT INTO Product VALUES ('Bocina bluetooth', 'bocinas XZW5525.')
INSERT INTO Product VALUES ('Samsung Galaxy s22', 'Modelo sm-858 con pantalla retina.')
INSERT INTO Product VALUES ('Xiaomi redmit note 11', 'Equipo con 64gb de disco y 8gb de ram.')
INSERT INTO Product VALUES ('Audifonos sony m3', 'Cancelación de ruido, dos días de carga.')
GO
INSERT INTO ORDERS VALUES (1,2, GETDATE())
INSERT INTO ORDERS VALUES (2,2, GETDATE())
INSERT INTO ORDERS VALUES (3,3, GETDATE())
INSERT INTO ORDERS VALUES (4,4, GETDATE())
INSERT INTO ORDERS VALUES (5,1, GETDATE())



SELECT*FROM Client
SELECT*FROM Orders
SELECT*FROM Product