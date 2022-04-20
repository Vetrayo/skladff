CREATE DATABASE [DB]

USE [DB]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 20.04.2022 17:03:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[IdProduct] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[IdProduct] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 20.04.2022 17:03:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[IdRole] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[IdRole] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 20.04.2022 17:03:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[IdStatus] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[IdStatus] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 20.04.2022 17:03:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[IdUser] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[IdRole] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[IdUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Work]    Script Date: 20.04.2022 17:03:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Work](
	[IdWork] [int] IDENTITY(1,1) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Patronymic] [nvarchar](50) NULL,
 CONSTRAINT [PK_Work] PRIMARY KEY CLUSTERED 
(
	[IdWork] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Zakaz]    Script Date: 20.04.2022 17:03:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Zakaz](
	[IdZakaz] [int] IDENTITY(1,1) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Patronymic] [nvarchar](50) NULL,
	[Amount] [int] NOT NULL,
	[IdProduct] [int] NOT NULL,
	[IdStatus] [int] NOT NULL,
 CONSTRAINT [PK_Zakaz] PRIMARY KEY CLUSTERED 
(
	[IdZakaz] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Product] ON 
GO
INSERT [dbo].[Product] ([IdProduct], [Name]) VALUES (1, N'Кола')
GO
INSERT [dbo].[Product] ([IdProduct], [Name]) VALUES (2, N'Чизбургер')
GO
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 
GO
INSERT [dbo].[Role] ([IdRole], [Name]) VALUES (1, N'Администратор')
GO
INSERT [dbo].[Role] ([IdRole], [Name]) VALUES (2, N'Работник')
GO
INSERT [dbo].[Role] ([IdRole], [Name]) VALUES (3, N'Пользователь')
GO
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
INSERT [dbo].[Status] ([IdStatus], [Name]) VALUES (1, N'В ожидании')
GO
INSERT [dbo].[Status] ([IdStatus], [Name]) VALUES (2, N'Выполнен')
GO
INSERT [dbo].[Status] ([IdStatus], [Name]) VALUES (3, N'Не выполнен')
GO
INSERT [dbo].[Status] ([IdStatus], [Name]) VALUES (4, N'Отказано')
GO
SET IDENTITY_INSERT [dbo].[User] ON 
GO
INSERT [dbo].[User] ([IdUser], [Login], [Password], [IdRole]) VALUES (1, N'admin', N'admin', 1)
GO
INSERT [dbo].[User] ([IdUser], [Login], [Password], [IdRole]) VALUES (2, N'work', N'work', 2)
GO
INSERT [dbo].[User] ([IdUser], [Login], [Password], [IdRole]) VALUES (3, N'user', N'user', 3)
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[Work] ON 
GO
INSERT [dbo].[Work] ([IdWork], [Surname], [Name], [Patronymic]) VALUES (1, N'Червинский', N'Леонид', N'Витальевич')
GO
SET IDENTITY_INSERT [dbo].[Work] OFF
GO
SET IDENTITY_INSERT [dbo].[Zakaz] ON 
GO
INSERT [dbo].[Zakaz] ([IdZakaz], [Surname], [Name], [Patronymic], [Amount], [IdProduct], [IdStatus]) VALUES (1, N'Чукин', N'Вячеслав', N'Павлович', 3, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[Zakaz] OFF
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([IdRole])
REFERENCES [dbo].[Role] ([IdRole])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
ALTER TABLE [dbo].[Zakaz]  WITH CHECK ADD  CONSTRAINT [FK_Zakaz_Product] FOREIGN KEY([IdProduct])
REFERENCES [dbo].[Product] ([IdProduct])
GO
ALTER TABLE [dbo].[Zakaz] CHECK CONSTRAINT [FK_Zakaz_Product]
GO
ALTER TABLE [dbo].[Zakaz]  WITH CHECK ADD  CONSTRAINT [FK_Zakaz_Status] FOREIGN KEY([IdStatus])
REFERENCES [dbo].[Status] ([IdStatus])
GO
ALTER TABLE [dbo].[Zakaz] CHECK CONSTRAINT [FK_Zakaz_Status]
GO
USE [master]
GO
ALTER DATABASE [DB] SET  READ_WRITE 
GO
