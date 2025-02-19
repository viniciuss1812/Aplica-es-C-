USE [dblogin]
GO
/****** Object:  Table [dbo].[StatusTarefa]    Script Date: 09/10/2024 16:39:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StatusTarefa](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [nchar](100) NOT NULL,
 CONSTRAINT [PK_StatusTarefa] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tarefas]    Script Date: 09/10/2024 16:39:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tarefas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [nchar](1000) NOT NULL,
	[Data] [datetime] NOT NULL,
	[Id_usuario] [int] NOT NULL,
	[Id_estadotarefa] [int] NOT NULL,
 CONSTRAINT [PK_Tarefas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 09/10/2024 16:39:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Senha] [nchar](100) NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Tarefas]  WITH CHECK ADD  CONSTRAINT [FK_Tarefas_StatusTarefa] FOREIGN KEY([Id_estadotarefa])
REFERENCES [dbo].[StatusTarefa] ([Id])
GO
ALTER TABLE [dbo].[Tarefas] CHECK CONSTRAINT [FK_Tarefas_StatusTarefa]
GO
ALTER TABLE [dbo].[Tarefas]  WITH CHECK ADD  CONSTRAINT [FK_Tarefas_Usuario] FOREIGN KEY([Id_usuario])
REFERENCES [dbo].[Usuario] ([id])
GO
ALTER TABLE [dbo].[Tarefas] CHECK CONSTRAINT [FK_Tarefas_Usuario]
GO
