USE [master]
GO
/****** Object:  Database [MerCado]    Script Date: 2019-01-16 14:04:42 ******/
CREATE DATABASE [MerCado]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MerCado', FILENAME = N'C:\Users\Administrator\MerCado.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MerCado_log', FILENAME = N'C:\Users\Administrator\MerCado_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [MerCado] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MerCado].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MerCado] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MerCado] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MerCado] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MerCado] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MerCado] SET ARITHABORT OFF 
GO
ALTER DATABASE [MerCado] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [MerCado] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MerCado] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MerCado] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MerCado] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MerCado] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MerCado] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MerCado] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MerCado] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MerCado] SET  ENABLE_BROKER 
GO
ALTER DATABASE [MerCado] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MerCado] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MerCado] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MerCado] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MerCado] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MerCado] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MerCado] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MerCado] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MerCado] SET  MULTI_USER 
GO
ALTER DATABASE [MerCado] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MerCado] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MerCado] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MerCado] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MerCado] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MerCado] SET QUERY_STORE = OFF
GO
USE [MerCado]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [MerCado]
GO
/****** Object:  Table [dbo].[ANSWER]    Script Date: 2019-01-16 14:04:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ANSWER](
	[QuestionID] [int] NOT NULL,
	[PersonID] [int] NOT NULL,
	[Answer] [int] NULL,
 CONSTRAINT [PK_ANSWER] PRIMARY KEY CLUSTERED 
(
	[QuestionID] ASC,
	[PersonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[COMPANY]    Script Date: 2019-01-16 14:04:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[COMPANY](
	[CompanyID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_COMPANY] PRIMARY KEY CLUSTERED 
(
	[CompanyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MARKETRESEARCH]    Script Date: 2019-01-16 14:04:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MARKETRESEARCH](
	[ResearchID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyID] [int] NOT NULL,
 CONSTRAINT [PK_MARKETRESEARCH] PRIMARY KEY CLUSTERED 
(
	[ResearchID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PERSON]    Script Date: 2019-01-16 14:04:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PERSON](
	[PersonID] [int] IDENTITY(1,1) NOT NULL,
	[Age] [int] NOT NULL,
	[Gender] [nvarchar](50) NOT NULL,
	[Location] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_PERSON] PRIMARY KEY CLUSTERED 
(
	[PersonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PERSONMR]    Script Date: 2019-01-16 14:04:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PERSONMR](
	[ResearchID] [int] NOT NULL,
	[PersonID] [int] NOT NULL,
 CONSTRAINT [PK_PERSONMR] PRIMARY KEY CLUSTERED 
(
	[ResearchID] ASC,
	[PersonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QUESTION]    Script Date: 2019-01-16 14:04:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QUESTION](
	[QuestionID] [int] IDENTITY(1,1) NOT NULL,
	[Question] [nvarchar](50) NOT NULL,
	[QuestionTypeID] [int] NULL,
	[GenericQuestion] [bit] NOT NULL,
	[AnswerID] [int] NULL,
 CONSTRAINT [PK_QUESTION] PRIMARY KEY CLUSTERED 
(
	[QuestionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QUESTIONS]    Script Date: 2019-01-16 14:04:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QUESTIONS](
	[ResearchID] [int] NOT NULL,
	[QuestionID] [int] NOT NULL,
 CONSTRAINT [PK_QUESTIONS] PRIMARY KEY CLUSTERED 
(
	[ResearchID] ASC,
	[QuestionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QUESTIONTYPE]    Script Date: 2019-01-16 14:04:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QUESTIONTYPE](
	[QuestionTypeID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_QUESTIONTYPE] PRIMARY KEY CLUSTERED 
(
	[QuestionTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[COMPANY] ON 

INSERT [dbo].[COMPANY] ([CompanyID], [Name]) VALUES (1, N'CocaCola')
INSERT [dbo].[COMPANY] ([CompanyID], [Name]) VALUES (2, N'Estrella')
INSERT [dbo].[COMPANY] ([CompanyID], [Name]) VALUES (4, N'Kaffekoppen')
INSERT [dbo].[COMPANY] ([CompanyID], [Name]) VALUES (5, N'tekoppen')
INSERT [dbo].[COMPANY] ([CompanyID], [Name]) VALUES (7, N'Göteborgsposten')
INSERT [dbo].[COMPANY] ([CompanyID], [Name]) VALUES (8, N'Visual Studios')
INSERT [dbo].[COMPANY] ([CompanyID], [Name]) VALUES (9, N'Scandic Hotels')
INSERT [dbo].[COMPANY] ([CompanyID], [Name]) VALUES (10, N'hejsan')
INSERT [dbo].[COMPANY] ([CompanyID], [Name]) VALUES (11, N'tekoppen')
INSERT [dbo].[COMPANY] ([CompanyID], [Name]) VALUES (12, N'Loreal')
INSERT [dbo].[COMPANY] ([CompanyID], [Name]) VALUES (13, N'Kaffekoppen')
INSERT [dbo].[COMPANY] ([CompanyID], [Name]) VALUES (14, N'Lindex')
INSERT [dbo].[COMPANY] ([CompanyID], [Name]) VALUES (15, N'H&M')
INSERT [dbo].[COMPANY] ([CompanyID], [Name]) VALUES (16, N'Academic Work')
INSERT [dbo].[COMPANY] ([CompanyID], [Name]) VALUES (17, N'Academy')
INSERT [dbo].[COMPANY] ([CompanyID], [Name]) VALUES (18, N'Åhlens')
INSERT [dbo].[COMPANY] ([CompanyID], [Name]) VALUES (19, N'Subway')
INSERT [dbo].[COMPANY] ([CompanyID], [Name]) VALUES (20, N'Datanördarna')
INSERT [dbo].[COMPANY] ([CompanyID], [Name]) VALUES (23, N'Olofs partybutik')
INSERT [dbo].[COMPANY] ([CompanyID], [Name]) VALUES (24, N'GöteborgsOperan')
INSERT [dbo].[COMPANY] ([CompanyID], [Name]) VALUES (25, N'Georgs partybutik')
INSERT [dbo].[COMPANY] ([CompanyID], [Name]) VALUES (26, N'Heidis partybutik')
SET IDENTITY_INSERT [dbo].[COMPANY] OFF
SET IDENTITY_INSERT [dbo].[MARKETRESEARCH] ON 

INSERT [dbo].[MARKETRESEARCH] ([ResearchID], [CompanyID]) VALUES (1, 2)
INSERT [dbo].[MARKETRESEARCH] ([ResearchID], [CompanyID]) VALUES (2, 4)
INSERT [dbo].[MARKETRESEARCH] ([ResearchID], [CompanyID]) VALUES (3, 4)
INSERT [dbo].[MARKETRESEARCH] ([ResearchID], [CompanyID]) VALUES (4, 1)
INSERT [dbo].[MARKETRESEARCH] ([ResearchID], [CompanyID]) VALUES (5, 2)
INSERT [dbo].[MARKETRESEARCH] ([ResearchID], [CompanyID]) VALUES (7, 1)
INSERT [dbo].[MARKETRESEARCH] ([ResearchID], [CompanyID]) VALUES (8, 2)
INSERT [dbo].[MARKETRESEARCH] ([ResearchID], [CompanyID]) VALUES (9, 2)
INSERT [dbo].[MARKETRESEARCH] ([ResearchID], [CompanyID]) VALUES (10, 10)
INSERT [dbo].[MARKETRESEARCH] ([ResearchID], [CompanyID]) VALUES (11, 1)
INSERT [dbo].[MARKETRESEARCH] ([ResearchID], [CompanyID]) VALUES (12, 1)
INSERT [dbo].[MARKETRESEARCH] ([ResearchID], [CompanyID]) VALUES (13, 2)
SET IDENTITY_INSERT [dbo].[MARKETRESEARCH] OFF
SET IDENTITY_INSERT [dbo].[PERSON] ON 

INSERT [dbo].[PERSON] ([PersonID], [Age], [Gender], [Location], [Email]) VALUES (1, 22, N'Male', N'Göteborg', N'georg@falemark.se')
INSERT [dbo].[PERSON] ([PersonID], [Age], [Gender], [Location], [Email]) VALUES (2, 35, N'male', N'Stockholm', N'klappahänderna@hotmail.com')
INSERT [dbo].[PERSON] ([PersonID], [Age], [Gender], [Location], [Email]) VALUES (3, 27, N'Female', N'Göteborg', N'heidivonjahf@hotmail.com')
INSERT [dbo].[PERSON] ([PersonID], [Age], [Gender], [Location], [Email]) VALUES (4, 30, N'female', N'Falkenberg', N'dksjfk@hotmail.com')
INSERT [dbo].[PERSON] ([PersonID], [Age], [Gender], [Location], [Email]) VALUES (5, 22, N'Male', N'Stockholm', N'fritiof.eriksson96@gmail.com')
INSERT [dbo].[PERSON] ([PersonID], [Age], [Gender], [Location], [Email]) VALUES (6, 54, N'Male', N'Göteborg', N'johan@falemark.se')
INSERT [dbo].[PERSON] ([PersonID], [Age], [Gender], [Location], [Email]) VALUES (7, 53, N'Female', N'Göteborg', N'helena@falemark.se')
INSERT [dbo].[PERSON] ([PersonID], [Age], [Gender], [Location], [Email]) VALUES (8, 23, N'Other', N'Jönköping', N'other@hotmail.com')
INSERT [dbo].[PERSON] ([PersonID], [Age], [Gender], [Location], [Email]) VALUES (9, 32, N'Female', N'Skövde', N'jagboriskovde@hotmail.com')
INSERT [dbo].[PERSON] ([PersonID], [Age], [Gender], [Location], [Email]) VALUES (10, 68, N'Female', N'Göteborg', N'gretahej@hotmail.com')
INSERT [dbo].[PERSON] ([PersonID], [Age], [Gender], [Location], [Email]) VALUES (11, 80, N'Female', N'Göteborg', N'bsavesoderbergh@gmail.com')
INSERT [dbo].[PERSON] ([PersonID], [Age], [Gender], [Location], [Email]) VALUES (12, 12, N'Female', N'Göteborg', N'heidivonjahf@hotmail.com')
INSERT [dbo].[PERSON] ([PersonID], [Age], [Gender], [Location], [Email]) VALUES (13, 555, N'Female', N'hgg', N'hghgjh')
INSERT [dbo].[PERSON] ([PersonID], [Age], [Gender], [Location], [Email]) VALUES (14, 55, N'female', N'Göteborg', N'asad@gmali.se')
INSERT [dbo].[PERSON] ([PersonID], [Age], [Gender], [Location], [Email]) VALUES (15, 30, N'male', N'Göteborg', N'jasfkjs')
INSERT [dbo].[PERSON] ([PersonID], [Age], [Gender], [Location], [Email]) VALUES (16, 55, N'female', N'Stockholm', N'hjdsf@hotmail.com')
INSERT [dbo].[PERSON] ([PersonID], [Age], [Gender], [Location], [Email]) VALUES (17, 25, N'female', N'Göteborg', N'johan@hotmail.com')
INSERT [dbo].[PERSON] ([PersonID], [Age], [Gender], [Location], [Email]) VALUES (21, 22, N'female', N'Götelabor', N'dfsdfsdf2@fddf')
SET IDENTITY_INSERT [dbo].[PERSON] OFF
SET IDENTITY_INSERT [dbo].[QUESTION] ON 

INSERT [dbo].[QUESTION] ([QuestionID], [Question], [QuestionTypeID], [GenericQuestion], [AnswerID]) VALUES (1, N'Vilka chips är godast?', NULL, 1, NULL)
INSERT [dbo].[QUESTION] ([QuestionID], [Question], [QuestionTypeID], [GenericQuestion], [AnswerID]) VALUES (2, N'vad är godast?', NULL, 1, NULL)
INSERT [dbo].[QUESTION] ([QuestionID], [Question], [QuestionTypeID], [GenericQuestion], [AnswerID]) VALUES (3, N'Hur ofta äter du chips?', NULL, 1, NULL)
SET IDENTITY_INSERT [dbo].[QUESTION] OFF
INSERT [dbo].[QUESTIONS] ([ResearchID], [QuestionID]) VALUES (9, 1)
INSERT [dbo].[QUESTIONS] ([ResearchID], [QuestionID]) VALUES (10, 2)
INSERT [dbo].[QUESTIONS] ([ResearchID], [QuestionID]) VALUES (13, 3)
SET IDENTITY_INSERT [dbo].[QUESTIONTYPE] ON 

INSERT [dbo].[QUESTIONTYPE] ([QuestionTypeID], [Description]) VALUES (1, N'1 to 10')
INSERT [dbo].[QUESTIONTYPE] ([QuestionTypeID], [Description]) VALUES (2, N'1 to 5')
INSERT [dbo].[QUESTIONTYPE] ([QuestionTypeID], [Description]) VALUES (3, N'Yes or No')
SET IDENTITY_INSERT [dbo].[QUESTIONTYPE] OFF
ALTER TABLE [dbo].[ANSWER]  WITH CHECK ADD  CONSTRAINT [FK_ANSWER_PERSON] FOREIGN KEY([PersonID])
REFERENCES [dbo].[PERSON] ([PersonID])
GO
ALTER TABLE [dbo].[ANSWER] CHECK CONSTRAINT [FK_ANSWER_PERSON]
GO
ALTER TABLE [dbo].[ANSWER]  WITH CHECK ADD  CONSTRAINT [FK_ANSWER_QUESTION] FOREIGN KEY([QuestionID])
REFERENCES [dbo].[QUESTION] ([QuestionID])
GO
ALTER TABLE [dbo].[ANSWER] CHECK CONSTRAINT [FK_ANSWER_QUESTION]
GO
ALTER TABLE [dbo].[MARKETRESEARCH]  WITH CHECK ADD  CONSTRAINT [FK_MARKETRESEARCH_COMPANY] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[COMPANY] ([CompanyID])
GO
ALTER TABLE [dbo].[MARKETRESEARCH] CHECK CONSTRAINT [FK_MARKETRESEARCH_COMPANY]
GO
ALTER TABLE [dbo].[PERSONMR]  WITH CHECK ADD  CONSTRAINT [FK_PERSONMR_MARKETRESEARCH] FOREIGN KEY([ResearchID])
REFERENCES [dbo].[MARKETRESEARCH] ([ResearchID])
GO
ALTER TABLE [dbo].[PERSONMR] CHECK CONSTRAINT [FK_PERSONMR_MARKETRESEARCH]
GO
ALTER TABLE [dbo].[PERSONMR]  WITH CHECK ADD  CONSTRAINT [FK_PERSONMR_PERSON] FOREIGN KEY([PersonID])
REFERENCES [dbo].[PERSON] ([PersonID])
GO
ALTER TABLE [dbo].[PERSONMR] CHECK CONSTRAINT [FK_PERSONMR_PERSON]
GO
ALTER TABLE [dbo].[QUESTION]  WITH CHECK ADD  CONSTRAINT [FK_QUESTION_QUESTIONTYPE] FOREIGN KEY([QuestionTypeID])
REFERENCES [dbo].[QUESTIONTYPE] ([QuestionTypeID])
GO
ALTER TABLE [dbo].[QUESTION] CHECK CONSTRAINT [FK_QUESTION_QUESTIONTYPE]
GO
ALTER TABLE [dbo].[QUESTIONS]  WITH CHECK ADD  CONSTRAINT [FK_QUESTIONS_MARKETRESEARCH] FOREIGN KEY([ResearchID])
REFERENCES [dbo].[MARKETRESEARCH] ([ResearchID])
GO
ALTER TABLE [dbo].[QUESTIONS] CHECK CONSTRAINT [FK_QUESTIONS_MARKETRESEARCH]
GO
ALTER TABLE [dbo].[QUESTIONS]  WITH CHECK ADD  CONSTRAINT [FK_QUESTIONS_QUESTION] FOREIGN KEY([QuestionID])
REFERENCES [dbo].[QUESTION] ([QuestionID])
GO
ALTER TABLE [dbo].[QUESTIONS] CHECK CONSTRAINT [FK_QUESTIONS_QUESTION]
GO
USE [master]
GO
ALTER DATABASE [MerCado] SET  READ_WRITE 
GO
