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
    JogoGeneroID INT PRIMARY KEY IDENTITY,
    JogoID INT FOREIGN KEY REFERENCES Jogo(JogoID),
    GeneroID INT FOREIGN KEY REFERENCES Genero(GeneroID)
);
GO

CREATE TABLE JogoPlataforma (
    JogoPlataformaID INT PRIMARY KEY IDENTITY,
    JogoID INT FOREIGN KEY REFERENCES Jogo(JogoID),
    PlataformaID INT FOREIGN KEY REFERENCES Plataforma(PlataformaID)
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

    -- TODA ALTERAÇÃO DA TABELA Jogo CRIA UM REGISTRO NA TABELA Log_AlteracaoJogo
	CREATE TRIGGER trg_AlteracaoJogo
	ON Jogo
	AFTER UPDATE
	AS BEGIN
		INSERT INTO Log_AlteracaoJogo(DataAlteracao, JogoID, NomeAnterior, PrecoAnterior)
		SELECT GETDATE(), JogoID, Nome, Preco FROM deleted
	END
	GO

    -- DML

    INSERT INTO Usuario (Nome, Email, Senha, StatusUsuario) VALUES
('Administrador', 'admin@royalgames.com', CONVERT(VARBINARY(32), 'senha'), 1),
('Carlos Silva', 'carlos@email.com', CONVERT(VARBINARY(32), 'senha'), 1),
('Marina Souza', 'marina@email.com', CONVERT(VARBINARY(32), 'senha'), 1),
('Lucas Pereira', 'lucas@email.com', CONVERT(VARBINARY(32), 'senha'), 1),
('Ana Costa', 'ana@email.com', CONVERT(VARBINARY(32), 'senha'), 1);
GO

INSERT INTO ClassIndicativa (Nome) VALUES
('Livre'),
('12+'),
('14+'),
('16+'),
('18+');
GO

INSERT INTO Genero (Nome) VALUES
('Ação'),
('Aventura'),
('RPG'),
('Estratégia'),
('Terror');
GO

INSERT INTO Plataforma (Nome) VALUES
('PlayStation 5'),
('Xbox Series X'),
('PC'),
('Nintendo Switch'),
('Mobile');
GO

INSERT INTO Jogo 
(Nome, Preco, Descricao, Imagem, StatusJogo, UsuarioID, Class_IndicativaID)
VALUES
('FIFA 24', 299.90, 'Simulador de futebol.', 0x0, 1, 1, 3),
('Resident Evil 4 Remake', 249.90, 'Terror e sobrevivência.', 0x0, 1, 2, 5),
('The Witcher 3', 199.90, 'RPG de mundo aberto.', 0x0, 1, 3, 4),
('God of War Ragnarok', 349.90, 'Aventura mitológica.', 0x0, 1, 4, 4),
('Mario Kart 8', 279.90, 'Corrida divertida.', 0x0, 1, 5, 2);
GO

INSERT INTO JogoGenero (JogoID, GeneroID) VALUES
(1, 4),
(2, 5),
(3, 3),
(4, 2),
(5, 4);
GO

INSERT INTO JogoPlataforma (JogoID, PlataformaID) VALUES
(1, 1),
(2, 1),
(3, 3),
(4, 1),
(5, 4);
GO