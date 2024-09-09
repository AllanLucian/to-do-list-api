# Lista de Tarefas

CRUD de Lista de tarefas em API REST + SQL SERVER + DOCKER COMPOSE + SWAGGER

## Tecnologias e Padrões Utilizados

- C# .Net
- API REST + Swagger
- SQL Server
- Injeção de Dependência
- Async/Await
- Arquitetura em N Camadas (separando responsabilidades)
- Aplicação em Docker Compose

## Passo a Passo para Teste da API

1. Executar o comando abaixo para levantar automaticamente o Docker Compose com API e SQL SERVER:

```bash
docker compose up -d	
```

2. Acessar endpoints da API através do Swagger:

```bash
http://localhost:1433/swagger/index.html
```

## Script do Banco de Dados

```python
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
```

## Oportunidade

Muito obrigado pela oportunidade e espero que gostem da API.