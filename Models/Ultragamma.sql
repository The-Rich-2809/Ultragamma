Create DataBase Ultragamma 
Go
Use Ultragamma 
Go
Set Nocount on 
Go

CREATE TABLE Usuarios
(Correo NVARCHAR (100) PRIMARY KEY NOT NULL,
Contrasena  NVARCHAR (100) NOT NULL,
Nombre NVARCHAR (15) NOT NULL,
Nivel INT NOT NULL) 
Go

CREATE TABLE Productos
(IdProducto INT PRIMARY KEY NOT NULL,
Nombre  NVARCHAR (50) NOT NULL,
Precio MONEY NOT NULL,
Categoria NVARCHAR (30) NOT NULL,
Cantidad INT NOT NULL) 
Go

delete from Usuarios
Go
Select * From Usuarios
Go

Insert Into Usuarios Values (LOWER('ricardo_138@outlook.com'),'1234','Rich',1)
Go

Insert Into Productos Values ('1','Pantalon Vaquero',225,'Pantalones',15)