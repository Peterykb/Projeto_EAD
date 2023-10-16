create database Cursos
use Cursos

/*Criando tabelas*/

create table categorias(
id_categoria int primary key identity, 
categoria varchar(45))

create table Curso(
id_curso int primary key identity,
nome varchar(45) not null, 
criador varchar(45) not null,
data_criacao datetime,
categoria_id_categoria int foreign key references categorias)

create table Modulos(
id_modulo int primary key identity,
modulo varchar(45) not null,
aula varchar(255) not null,
curso_id_curso int foreign key references Curso)

/*Selects*/

SELECT Curso.nome
FROM Curso
JOIN categorias ON Curso.categoria_id_categoria = categorias.id_categoria
WHERE categorias.categoria = 'machine learn';

SELECT Modulos.modulo
FROM Modulos
JOIN Curso ON curso_id_curso = Curso.id_curso
WHERE Curso.nome = 'Dotnet - zero ao avançado';

SELECT * from Modulos
SELECT * from Curso