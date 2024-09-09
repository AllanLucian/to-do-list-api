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

## Observação

Mesmo realizando as configurações do Docker Compose e criando o script do Banco de Dados (Data/create-database.sql), não obtive sucesso ao criar automaticamente a base de dados no momento da subida do Docker (executar script), dessa forma, seria necessário executar o teste local criando um Docker para a base de dados e rodando a aplicação localhost, assim como validei o CRUD.

**Comando a ser Executado para o Teste Local**

```bash
docker run --cap-add SYS_PTRACE -e 'ACCEPT_EULA=1' -e 'MSSQL_SA_PASSWORD=todolist2121' -p 1433:1433 --name todolist-db -d mcr.microsoft.com/azure-sql-edge
```

**Link do Swagger Local**

```bash
http://localhost:5287/swagger/index.html
```

_Perdão por esse ponto. Peço por gentileza que considerem ;)_

## Oportunidade

Muito obrigado pela oportunidade e espero que gostem da API.