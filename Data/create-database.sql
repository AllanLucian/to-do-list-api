CREATE DATABASE [TODOITEMS]
GO

USE [TODOITEMS];
GO

CREATE TABLE TodoItem ( 
    Id UNIQUEIDENTIFIER  CONSTRAINT DF_Id DEFAULT newsequentialid(),
    Name VARCHAR(200) NOT NULL,
    IsComplete bit NOT NULL,
 PRIMARY KEY (Id)
);
GO

INSERT INTO [TodoItem] (Name, IsComplete)
VALUES 
('Criar API Rest com uma Lista de Tarefas', 1),
('Testar aplicação de realizar o Deploy', 1); 
GO