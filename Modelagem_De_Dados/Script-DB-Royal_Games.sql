CREATE DATABASE Royal_Games;
GO

USE Royal_Games;
GO

-- DDL

CREATE TABLE Usuario (
    UsuarioID INT PRIMARY KEY IDENTITY,
    Nome VARCHAR(50) NOT NULL,
    Email VARCHAR(125) UNIQUE NOT NULL,
    Senha VARBINARY(32) NOT NULL,
    StatusUsuario BIT DEFAULT 1
);
GO

CREATE TABLE ClassIndicativa (
    ClassIndicativaID INT PRIMARY KEY IDENTITY,
    Nome VARCHAR(25) NOT NULL
);
GO

CREATE TABLE Jogo (
    JogoID INT PRIMARY KEY IDENTITY,
    Nome VARCHAR(75) UNIQUE NOT NULL,
    Preco DECIMAL(10,2) NOT NULL,
    Descricao NVARCHAR(2000) NOT NULL,
    Imagem VARBINARY(MAX) NOT NULL,
    StatusJogo BIT DEFAULT 1,
    UsuarioID INT FOREIGN KEY REFERENCES Usuario(UsuarioID),
    Class_IndicativaID INT FOREIGN KEY REFERENCES ClassIndicativa(ClassIndicativaID)
);
GO

CREATE TABLE Genero (
    GeneroID INT PRIMARY KEY IDENTITY,
    Nome NVARCHAR(50) NOT NULL
);
GO

CREATE TABLE Plataforma (
    PlataformaID INT PRIMARY KEY IDENTITY,
    Nome VARCHAR(50) NOT NULL
);
GO

CREATE TABLE Log_AlteracaoJogo (
    Log_AlteracaoJogoID INT PRIMARY KEY IDENTITY,
    DataAlteracao DATETIME2(0) NOT NULL,
    NomeAnterior VARCHAR(75),
    PrecoAnterior DECIMAL(10,2),
    JogoID INT FOREIGN KEY REFERENCES Jogo(JogoID)
);
GO

CREATE TABLE JogoGenero (
    JogoID INT NOT NULL,
    GeneroID INT NOT NULL,

    CONSTRAINT PK_JogoGenero PRIMARY KEY (JogoID, GeneroID),
	CONSTRAINT FK_JogoGenero_Jogo FOREIGN KEY (JogoID) 
		REFERENCES Jogo(JogoID) ON DELETE CASCADE,
	CONSTRAINT FK_JogoGenero_Genero FOREIGN KEY (GeneroID) 
		REFERENCES Genero(GeneroID) ON DELETE CASCADE
);
GO

CREATE TABLE JogoPlataforma (
    JogoID INT NOT NULL,
    PlataformaID INT NOT NULL,

    CONSTRAINT PK_JogoPlataforma PRIMARY KEY (JogoID, PlataformaID),
    CONSTRAINT FK_JogoPlataforma_Jogo FOREIGN KEY (JogoID)
        REFERENCES Jogo(JogoID) ON DELETE CASCADE,
    CONSTRAINT FK_JogoPlataforma_Plataforma FOREIGN KEY (PlataformaID)
        REFERENCES Plataforma(PlataformaID) ON DELETE CASCADE
);
GO

-- TRIGGERS

    -- INATIVA JOGO EM VEZ DE EXCLUIR
    CREATE TRIGGER trg_ExclusaoJogo
	ON Jogo
	INSTEAD OF DELETE
	AS BEGIN
		UPDATE j SET StatusJogo = 0
		FROM Jogo j
		INNER JOIN deleted d
			ON d.JogoID = j.JogoID
	END
	GO

    -- INATIVA USUARIO EM VEZ DE EXCLUIR
    CREATE TRIGGER trg_ExclusaoUsuario
	ON Usuario
	INSTEAD OF DELETE
	AS BEGIN
		UPDATE u SET StatusUsuario = 0
		FROM Usuario u
		INNER JOIN deleted d
			ON d.UsuarioID = u.UsuarioID
	END
	GO

    -- GERA LOGS DE ALTERACAO DE JOGO
	CREATE TRIGGER trg_AlteracaoJogo
	ON Jogo
	AFTER UPDATE
	AS BEGIN
		INSERT INTO Log_AlteracaoJogo(DataAlteracao, JogoID, NomeAnterior, PrecoAnterior)
		SELECT GETDATE(), JogoID, Nome, Preco FROM deleted
	END
	GO