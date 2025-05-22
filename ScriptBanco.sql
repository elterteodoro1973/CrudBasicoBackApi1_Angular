USE [Master]
GO
Create database Corporacao;
GO
USE [Corporacao]
GO
/****** Object:  Table [dbo].[Funcionarios]    Script Date: 22/05/2025 16:10:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Funcionarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](50) NULL,
	[Endereco] [varchar](150) NULL,
	[DataNascimento] [datetime] NULL,
	[Ativo] [bit] NULL,
 CONSTRAINT [PK_Funcionarios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Funcionarios] ON 
GO
INSERT [dbo].[Funcionarios] ([Id], [Nome], [Endereco], [DataNascimento], [Ativo]) VALUES (2, N'Ana Paula Ambrosio', N'Rua Petropolis,1640 Centro', CAST(N'2001-03-11T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[Funcionarios] ([Id], [Nome], [Endereco], [DataNascimento], [Ativo]) VALUES (3, N'Flavia Tatsue Takeda Sawamura', N'Avendia Sol da manha,583 Paraiso', CAST(N'1985-05-09T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[Funcionarios] ([Id], [Nome], [Endereco], [DataNascimento], [Ativo]) VALUES (4, N'Giselle AKemi Gami Yamagami', N'Praça da Bandeira,11 Mangabeiras', CAST(N'1988-06-11T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[Funcionarios] ([Id], [Nome], [Endereco], [DataNascimento], [Ativo]) VALUES (5, N'SILVANA RIBEIRO DOS SANTOS', N'Avenida Caivera,228, Jardim Pinheiro machai', CAST(N'2025-05-06T04:49:43.740' AS DateTime), 1)
GO
INSERT [dbo].[Funcionarios] ([Id], [Nome], [Endereco], [DataNascimento], [Ativo]) VALUES (6, N'Luiz Antônio Romualdo Pereira', N'Rua das acacias, 256 Sion', CAST(N'1986-04-12T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[Funcionarios] ([Id], [Nome], [Endereco], [DataNascimento], [Ativo]) VALUES (7, N'Sergio Yuri Petronio Mazembe', N'Rua outono, 456 Santa Efigênia', CAST(N'2003-04-20T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[Funcionarios] ([Id], [Nome], [Endereco], [DataNascimento], [Ativo]) VALUES (8, N'Zelia da SILVIa', N'RUA Nova ERA, 489 Boa Vista ', CAST(N'1981-06-20T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[Funcionarios] ([Id], [Nome], [Endereco], [DataNascimento], [Ativo]) VALUES (9, N'Mauricio Alves Santos', N'Rua Padre Leopoldo Mertens,1651,  Bairro: São Francisco Belo Horizonte-MG', CAST(N'1999-06-20T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[Funcionarios] ([Id], [Nome], [Endereco], [DataNascimento], [Ativo]) VALUES (11, N'Frederico Mendez Alves', N'Rua itamogi ,56 Santa Cruz', CAST(N'1977-09-10T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[Funcionarios] ([Id], [Nome], [Endereco], [DataNascimento], [Ativo]) VALUES (14, N'Túlio Garcia', N'Rua Boa Esperança,160  Sion', CAST(N'1997-05-14T00:00:00.000' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[Funcionarios] OFF
GO
