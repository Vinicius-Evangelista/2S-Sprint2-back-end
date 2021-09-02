USE T_Rental;
GO

SELECT * FROM MODELO;
GO
SELECT * FROM EMPRESA;
GO
SELECT * FROM CLIENTE;
GO
SELECT * FROM ALUGUEL;
GO
SELECT * FROM CARRO;
GO

SELECT idAluguel, r.placaCarro, nomeModelo, c.nomeCliente, dataAluguel 
FROM ALUGUEL
JOIN CLIENTE c
ON ALUGUEL.idCliente = c.idCliente
JOIN CARRO r
ON ALUGUEL.idCarro = r.idCarro
JOIN MODELO
ON MODELO.idModelo = r.idModelo