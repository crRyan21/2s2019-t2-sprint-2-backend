CREATE DATABASE ManualPecas


USE ManualPecas


CREATE TABLE Usuarios
(
	UsuarioId		INT PRIMARY KEY IDENTITY
	, Email			VARCHAR(255) NOT NULL UNIQUE
	, Senha			VARCHAR(255) NOT NULL
);

CREATE TABLE Fornecedores 
(
	FornecedorId	INT PRIMARY KEY IDENTITY
	, CNPJ			CHAR(14)		NOT NULL UNIQUE
	, RazaoSocial	VARCHAR(255)	NOT NULL UNIQUE
	, NomeFantasia	VARCHAR(255)	NOT NULL
	, Endereco		VARCHAR(255)	NOT NULL
	, UsuarioId		INT FOREIGN KEY REFERENCES Usuarios(UsuarioId) NOT NULL UNIQUE
);

CREATE TABLE Pecas (
	PecaId			INT PRIMARY KEY IDENTITY
	, Codigo		VARCHAR(255) NOT NULL UNIQUE
	, Descricao		TEXT
	, Peso			FLOAT(2) NOT NULL
	, PrecoCusto	FLOAT(2) NOT NULL
	, PrecoVenda	FLOAT(2) NOT NULL
	, FornecedorId	INT FOREIGN KEY REFERENCES Fornecedores(FornecedorId) NOT NULL
);



INSERT INTO Usuarios (Email, Senha) VALUES ('ryan@email.com', '123456'), ('pedrinho@email.com', '123456');
SELECT * FROM Usuarios;


