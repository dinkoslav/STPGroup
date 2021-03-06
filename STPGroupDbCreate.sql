USE [STPGroup]
GO
/****** Object:  Table [dbo].[Companies]    Script Date: 10/31/2018 5:58:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Companies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[SalaryMin] [decimal](18, 0) NOT NULL,
	[SalaryMax] [decimal](18, 0) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_Companies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Employees]    Script Date: 10/31/2018 5:58:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[ExperienceLevelId] [int] NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[StartingDate] [datetime] NOT NULL,
	[Salary] [decimal](18, 0) NOT NULL,
	[VacationDays] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ExperienceLevels]    Script Date: 10/31/2018 5:58:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExperienceLevels](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Text] [nvarchar](5) NOT NULL,
 CONSTRAINT [PK_ExperienceLevels] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Companies] ON 

INSERT [dbo].[Companies] ([Id], [Name], [Address], [SalaryMin], [SalaryMax], [CreatedOn], [ModifiedOn]) VALUES (1, N'Dinko OOD1', N'Pleven, Drujba 331', CAST(100 AS Decimal(18, 0)), CAST(10000 AS Decimal(18, 0)), CAST(N'1996-07-04 00:00:00.000' AS DateTime), CAST(N'2018-10-30 21:34:22.710' AS DateTime))
INSERT [dbo].[Companies] ([Id], [Name], [Address], [SalaryMin], [SalaryMax], [CreatedOn], [ModifiedOn]) VALUES (2, N'Test EooD', N'Nqma', CAST(10 AS Decimal(18, 0)), CAST(20 AS Decimal(18, 0)), CAST(N'2018-10-30 18:16:25.000' AS DateTime), CAST(N'2018-10-31 17:37:09.990' AS DateTime))
SET IDENTITY_INSERT [dbo].[Companies] OFF
SET IDENTITY_INSERT [dbo].[Employees] ON 

INSERT [dbo].[Employees] ([Id], [CompanyId], [ExperienceLevelId], [FirstName], [LastName], [StartingDate], [Salary], [VacationDays], [CreatedOn], [ModifiedOn]) VALUES (1, 1, 1, N'Dinko', N'Todorov', CAST(N'2018-10-30 00:00:00.000' AS DateTime), CAST(200 AS Decimal(18, 0)), 12, CAST(N'1996-07-04 00:00:00.000' AS DateTime), CAST(N'2018-10-30 22:53:30.803' AS DateTime))
INSERT [dbo].[Employees] ([Id], [CompanyId], [ExperienceLevelId], [FirstName], [LastName], [StartingDate], [Salary], [VacationDays], [CreatedOn], [ModifiedOn]) VALUES (2, 1, 1, N'Dinko1', N'Todorov2', CAST(N'2018-10-30 00:00:00.000' AS DateTime), CAST(2000 AS Decimal(18, 0)), 15, CAST(N'2018-10-28 19:58:03.347' AS DateTime), CAST(N'2018-10-28 19:58:03.347' AS DateTime))
INSERT [dbo].[Employees] ([Id], [CompanyId], [ExperienceLevelId], [FirstName], [LastName], [StartingDate], [Salary], [VacationDays], [CreatedOn], [ModifiedOn]) VALUES (6, 2, 2, N'a12', N'a21', CAST(N'2018-10-31 17:37:51.000' AS DateTime), CAST(11 AS Decimal(18, 0)), 2, CAST(N'2018-10-31 17:38:05.170' AS DateTime), CAST(N'2018-10-31 17:38:05.170' AS DateTime))
SET IDENTITY_INSERT [dbo].[Employees] OFF
SET IDENTITY_INSERT [dbo].[ExperienceLevels] ON 

INSERT [dbo].[ExperienceLevels] ([Id], [Text]) VALUES (1, N'A')
INSERT [dbo].[ExperienceLevels] ([Id], [Text]) VALUES (2, N'B')
INSERT [dbo].[ExperienceLevels] ([Id], [Text]) VALUES (3, N'C')
INSERT [dbo].[ExperienceLevels] ([Id], [Text]) VALUES (4, N'D')
SET IDENTITY_INSERT [dbo].[ExperienceLevels] OFF
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Companies] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Companies] ([Id])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Companies]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_ExperienceLevels] FOREIGN KEY([ExperienceLevelId])
REFERENCES [dbo].[ExperienceLevels] ([Id])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_ExperienceLevels]
GO
