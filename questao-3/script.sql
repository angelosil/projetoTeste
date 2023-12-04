
--1 - Exiba a placa e o nome dos donos de todos os veiculos
SELECT V.placa, C.nome FROM Cliente C
INNER JOIN Veiculo V ON C.cpf = V.Cliente_cpf

--2 - Exiba o endereço, a data de entrada e de saída dos estacionamentos do veiculo de placa 'BTG-2022'

SELECT P.ender, CONCAT(E.dtEntrada, ' ', E.hsEntrada) as DtEntrada, CONCAT(E.dtSaida, ' ', E.hsSaida) as DtSaida FROM Estaciona E
INNER JOIN Patio P ON P.num = E.Patio_num
INNER JOIN Veiculo V ON V.placa = E.Veiculo_placa
where V.placa = 'BTG-2022'




