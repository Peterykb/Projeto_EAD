create database Projeto
use Projeto

create table Categorias(
id_categoria int primary key identity,
nome_categoria varchar(255) not null);

create table Cursos(
id_curso int primary key identity, 
nome_curso varchar(45) not null,
criador varchar(45) not null,
data_criacao int not null,
categoria_id_categoria int foreign key references Categorias);

create table Modulos(
id_modulo int primary key identity,
titulo varchar(255) not null,
curso_id_curso int foreign key references Cursos
);

create table Aulas(
id_aula int primary key identity,
titulo varchar(255) not null,
conteudo varchar(max) not null,
modulo_id_modulo int foreign key references Modulos);

select Cursos.nome_curso, Cursos.criador from Cursos join Categorias on Cursos.categoria_id_categoria = Categorias.id_categoria where Categorias.nome_categoria = 'Frontend';
select Cursos.nome_curso, Cursos.criador from Cursos where Cursos.criador = 'guilhermesousa'



