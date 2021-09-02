USE T_Rental;
GO

INSERT INTO EMPRESA (nomeEmpresa)
VALUES ('eita'),('localiza');
GO


INSERT INTO CLIENTE (nomeCliente, sobreNomeCliente ,cnh)
VALUES ('Siverino', 'Silva do Nascimento',97392487898),('Gilberto','Souza de Laranjeiras', 77049587913);
GO


INSERT INTO MARCA (nomeMarca)
VALUES ('fiat'),('VW');
GO

INSERT INTO MODELO (nomeModelo, idMarca)
VALUES ('Gol', 1),('Sedan',1);
GO

INSERT INTO CARRO (placaCarro, idEmpresa, idModelo)
VALUES ('1211000',1,1),('1211990',1,2);
GO

INSERT INTO ALUGUEL (idCarro, idCliente, dataAluguel)
VALUES (2,1, '10/09/2021'),(1,2, '10/09/2021');
GO