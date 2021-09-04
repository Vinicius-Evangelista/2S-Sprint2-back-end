CREATE DATABASE T_Rental;
GO

USE T_Rental;
GO

--DROP TABLE MARCA;
--GO
--TRUNCATE TABLE MARCA;
--GO

CREATE TABLE MARCA (
idMarca SMALLINT PRIMARY KEY IDENTITY (1,1),
nomeMarca VARCHAR(40) NOT NULL UNIQUE,
);
GO

--DROP TABLE MODELO;
--GO
--TRUNCATE TABLE MODELO;
--GO

CREATE TABLE MODELO (
idModelo SMALLINT PRIMARY KEY IDENTITY (1,1),
idMarca SMALLINT FOREIGN KEY REFERENCES MARCA (idMarca) NOT NULL,
nomeModelo VARCHAR(20) NOT NULL,
);
GO

--DROP TABLE EMPRESA;
--GO
--TRUNCATE TABLE EMPRESA;
--GO

CREATE TABLE EMPRESA (
idEmpresa TINYINT PRIMARY KEY IDENTITY (1,1),
nomeEmpresa VARCHAR(50) NOT NULL,
);
GO

--DROP TABLE CLIENTE;
--GO
--TRUNCATE TABLE CLIENTE;
--GO

CREATE TABLE CLIENTE (
idCliente SMALLINT PRIMARY KEY IDENTITY (1,1),
nomeCliente VARCHAR (20) NOT NULL,
sobreNomeCliente VARCHAR (50) NOT NULL,
cnh CHAR(11) NOT NULL UNIQUE,
);
GO

--DROP TABLE CARRO;
--GO
--TRUNCATE TABLE CARRO;
--GO

CREATE TABLE CARRO (
idCarro INT PRIMARY KEY IDENTITY (1,1),
idModelo SMALLINT FOREIGN KEY REFERENCES MODELO (idModelo) NOT NULL,
placaCarro CHAR(7) NOT NULL UNIQUE,
idEmpresa TINYINT FOREIGN KEY REFERENCES EMPRESA (idEmpresa) NOT NULL,
);
GO

--DROP TABLE ALUGUEL;
--GO
--TRUNCATE TABLE ALUGUEL;
--GO

CREATE TABLE ALUGUEL (
idAluguel INT PRIMARY KEY IDENTITY (1,1),
idCarro INT FOREIGN KEY REFERENCES CARRO (idCarro) NOT NULL,
idCliente SMALLINT FOREIGN KEY REFERENCES CLIENTE (idCliente) NOT NULL,
dataAluguel DATE, 
);
GO