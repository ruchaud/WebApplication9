CREATE SCHEMA [opima_1];
GO

USE [opima_1]
GO
/****** Object: Table [dbo].[Estado] Script Date: 13/03/2019 12:49:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Estado] (
    [codigo]    INT           IDENTITY (1, 1) NOT NULL,
    [descricao] VARCHAR (250) NULL
);


USE [opima_1]
GO

/****** Object: Table [dbo].[Cidade] Script Date: 13/03/2019 12:48:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Cidade] (
    [codigo]        INT           IDENTITY (1, 1) NOT NULL,
    [descricao]     VARCHAR (250) NULL,
    [codigo_estado] INT           NULL
);

USE [opima_1]
GO
/****** Object: Table [dbo].[Bairro] Script Date: 13/03/2019 12:48:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Bairro] (
    [codigo]        INT           IDENTITY (1, 1) NOT NULL,
    [descricao]     VARCHAR (250) NULL,
    [codigo_cidade] INT           NULL
);


USE [opima_1]
GO


/****** Object: Table [dbo].[Pessoa] Script Date: 13/03/2019 12:49:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Pessoa] (
    [codigo]               INT           IDENTITY (1, 1) NOT NULL,
    [nome]                 VARCHAR (250) NULL,
    [data_nascimento]      DATETIME      NULL,
    [sexo]                 VARCHAR (50)  NULL,
    [profissao]            VARCHAR (200) NULL,
    [nacionalidade]        VARCHAR (50)  NULL,
    [email]                VARCHAR (150) NULL,
    [pai]                  VARCHAR (200) NULL,
    [mae]                  VARCHAR (200) NULL,
    [data_cadastro]        DATETIME      NULL,
    [tipo_pessoa]          INT           NULL,
    [cpf]                  VARCHAR (100) NULL,
    [cnpj]                 VARCHAR (100) NULL,
    [codigo_tipo_cadastro] INT           NULL,
    [numero_oab]           VARCHAR (50)  NULL,
    [codigo_posicao_parte] INT           NULL
);

USE [opima_1]
GO

/****** Object: Table [dbo].[Endereco] Script Date: 13/03/2019 12:49:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Endereco] (
    [codigo]               INT           IDENTITY (1, 1) NOT NULL,
    [rua]                  VARCHAR (250) NULL,
    [numero]               VARCHAR (50)  NULL,
    [cep]                  VARCHAR (50)  NULL,
    [complemento]          VARCHAR (250) NULL,
    [telefone_residencial] VARCHAR (100) NULL,
    [telefone_celular]     VARCHAR (100) NULL,
    [tipo_endereco]        VARCHAR (50)  NULL,
    [codigo_bairro]        INT           NULL,
    [codigo_pessoa]        INT           NULL,
    [codigo_cidade]        INT           NULL,
    [codigo_estado]        INT           NULL
);


USE [opima_1]
GO

/****** Object: Table [dbo].[Posicao] Script Date: 13/03/2019 12:49:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Posicao] (
    [codigo]    INT           IDENTITY (1, 1) NOT NULL,
    [descricao] VARCHAR (250) NULL
);

USE [opima_1]
GO

/****** Object: Table [dbo].[TipoCadastro] Script Date: 13/03/2019 12:49:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TipoCadastro] (
    [codigo]    INT           IDENTITY (1, 1) NOT NULL,
    [descricao] VARCHAR (200) NULL
);






