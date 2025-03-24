-- Crear la base de datos
CREATE DATABASE DB_Login;
GO

-- Usar la base de datos recién creada
USE DB_Login;
GO

-- Crear un esquema dentro de la base de datos
CREATE SCHEMA sis;
GO

-- Crear la tabla Usuarios
CREATE TABLE sis.Usuarios (
    Id INT PRIMARY KEY IDENTITY(1,1),
    UserName VARCHAR(50) NOT NULL,
    Password VARCHAR(100) NOT NULL,
	Email VARCHAR(100) NULL,
    DateCreated DATETIME NULL,
	DateModify DATETIME NULL,
	Status int
);
GO

