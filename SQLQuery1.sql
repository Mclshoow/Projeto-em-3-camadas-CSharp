USE Aluno

-- Script para criar a tabela Aluno
CREATE TABLE Aluno (
    Matricula INT IDENTITY(1,1) PRIMARY KEY,
    Nome NVARCHAR(100) NOT NULL,
    Data_Nascimento DATE NOT NULL,
    Serie NVARCHAR(50) NOT NULL,
    Segmento NVARCHAR(50) NOT NULL,
    Nome_Pai NVARCHAR(100) NOT NULL,
    Nome_Mae NVARCHAR(100) NOT NULL
);

-- Script para criar a tabela Endereco
CREATE TABLE Endereco (
    EnderecoId INT IDENTITY(1,1) PRIMARY KEY,
    Tipo NVARCHAR(50) NOT NULL,
    Rua NVARCHAR(100) NOT NULL,
    Numero INT NOT NULL,
    CEP NVARCHAR(20) NOT NULL,
    Complemento NVARCHAR(100) NOT NULL,
    AlunoMatricula INT NOT NULL,
    FOREIGN KEY (AlunoMatricula) REFERENCES Aluno(Matricula) ON DELETE CASCADE
);