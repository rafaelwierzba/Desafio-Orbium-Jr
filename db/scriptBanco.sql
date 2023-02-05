/*  DATABASE: POSTGRES 15 - localhost:5432
User => postgres 
Pass => 0707  */

CREATE DATABASE desafio_orbium_jr;
USE desafio_orbium_jr;

CREATE TABLE funcionario(
	func_id SERIAL,
	func_nome VARCHAR(150),
	func_email VARCHAR(150),
	func_cargo VARCHAR(100),
	func_salario DECIMAL,
	func_dataContratacao DATE

);

/* DADOS INSERIDOS PARA TESTE */

INSERT INTO funcionario(func_nome, func_email, func_cargo, func_salario, func_dataContratacao)
VALUES('Fulano', 'fulano@gmail.com', 'cargo W', 10000.00, '01/02/2023');

INSERT INTO funcionario(func_nome, func_email, func_cargo, func_salario, func_dataContratacao)
VALUES('Siclano', 'siclano@gmail.com', 'cargo X', 10000.00, '01/02/2023');

INSERT INTO funcionario(func_nome, func_email, func_cargo, func_salario, func_dataContratacao)
VALUES('Beltrano', 'beltrano@gmail.com', 'cargo Y', 10000.00, '01/02/2023');

INSERT INTO funcionario(func_nome, func_email, func_cargo, func_salario, func_dataContratacao)
VALUES('Zé', 'ze@gmail.com', 'cargo Z', 10000.00, '01/02/2023');
