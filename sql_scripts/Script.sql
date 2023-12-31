USE [LoginRegister]
GO
/****** Object:  Table [dbo].[Preguntas]    Script Date: 27/9/2023 09:58:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Preguntas](
	[idPregunta] [int] IDENTITY(1,1) NOT NULL,
	[Enunciado] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Preguntas] PRIMARY KEY CLUSTERED 
(
	[idPregunta] ASC
)
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 27/9/2023 09:58:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[idUsuario] [int] IDENTITY(1,1) NOT NULL,
	[NombreUsuario] [varchar](max) NOT NULL,
	[Contrasena] [varchar](max) NOT NULL,
	[Nombre] [varchar](max) NOT NULL,
	[Email] [varchar](max) NOT NULL,
	[idPregunta] [int] NOT NULL,
	[RespuestaPregunta] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Preguntas] ON 

INSERT [dbo].[Preguntas] ([idPregunta], [Enunciado]) VALUES (1, N'¿Cual es tu color favorito?')
INSERT [dbo].[Preguntas] ([idPregunta], [Enunciado]) VALUES (2, N'¿Cual fue el nombre de tu primera mascota?')
INSERT [dbo].[Preguntas] ([idPregunta], [Enunciado]) VALUES (3, N'¿Como se llama el colegio donde hiciste el jardin?')
INSERT [dbo].[Preguntas] ([idPregunta], [Enunciado]) VALUES (4, N'¿Cual es tu numero favorito?')
SET IDENTITY_INSERT [dbo].[Preguntas] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([idUsuario], [NombreUsuario], [Contrasena], [Nombre], [Email], [idPregunta], [RespuestaPregunta]) VALUES (1, N'Juan', N'$2a$11$EEvlmlnWnwOMtD5XCe/nHu.6KcrCpG94J2dve35JkE9V5EIl2ewO.', N'Juan', N'Juan@gmail.com', 0, N'Juan')
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
