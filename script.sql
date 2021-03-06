USE [master]
GO
/****** Object:  Database [UniversityRating]    Script Date: 6/11/2021 10:12:44 AM ******/
CREATE DATABASE [UniversityRating]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'UniversityRating', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\UniversityRating.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'UniversityRating_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\UniversityRating_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [UniversityRating] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UniversityRating].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UniversityRating] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UniversityRating] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UniversityRating] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UniversityRating] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UniversityRating] SET ARITHABORT OFF 
GO
ALTER DATABASE [UniversityRating] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [UniversityRating] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UniversityRating] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UniversityRating] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UniversityRating] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UniversityRating] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UniversityRating] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UniversityRating] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UniversityRating] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UniversityRating] SET  DISABLE_BROKER 
GO
ALTER DATABASE [UniversityRating] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UniversityRating] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UniversityRating] SET TRUSTWORTHY ON 
GO
ALTER DATABASE [UniversityRating] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UniversityRating] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UniversityRating] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [UniversityRating] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UniversityRating] SET RECOVERY FULL 
GO
ALTER DATABASE [UniversityRating] SET  MULTI_USER 
GO
ALTER DATABASE [UniversityRating] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UniversityRating] SET DB_CHAINING OFF 
GO
ALTER DATABASE [UniversityRating] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [UniversityRating] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [UniversityRating] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [UniversityRating] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'UniversityRating', N'ON'
GO
ALTER DATABASE [UniversityRating] SET QUERY_STORE = OFF
GO
USE [UniversityRating]
GO
/****** Object:  Table [dbo].[CHARTDATA]    Script Date: 6/11/2021 10:12:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHARTDATA](
	[ChartDataId] [int] IDENTITY(1,1) NOT NULL,
	[ChartTimeStamp] [datetime] NOT NULL,
	[ChartValue] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ChartDataId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Indicator]    Script Date: 6/11/2021 10:12:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Indicator](
	[Indicator_Id] [int] IDENTITY(1,1) NOT NULL,
	[IndicatorName] [nvarchar](300) NULL,
 CONSTRAINT [PK_Indicator] PRIMARY KEY CLUSTERED 
(
	[Indicator_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Indicators]    Script Date: 6/11/2021 10:12:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Indicators](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[University_Id] [int] NULL,
	[Value] [int] NULL,
	[UnitOfMeasure] [nvarchar](300) NULL,
	[Year] [int] NULL,
	[Indicator_Id] [int] NULL,
 CONSTRAINT [PK_Indicators] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ratings]    Script Date: 6/11/2021 10:12:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ratings](
	[Rating_Id] [int] IDENTITY(1,1) NOT NULL,
	[University_Id] [int] NULL,
	[RatingValue] [float] NULL,
	[Year] [int] NULL,
 CONSTRAINT [PK_Ratings] PRIMARY KEY CLUSTERED 
(
	[Rating_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Universities]    Script Date: 6/11/2021 10:12:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Universities](
	[University_Id] [int] IDENTITY(1,1) NOT NULL,
	[UniversityName] [nvarchar](300) NULL,
 CONSTRAINT [PK_Universities1] PRIMARY KEY CLUSTERED 
(
	[University_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 6/11/2021 10:12:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](300) NULL,
	[Password] [nvarchar](300) NULL,
	[Role] [nvarchar](50) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CHARTDATA] ADD  DEFAULT (getdate()) FOR [ChartTimeStamp]
GO
ALTER TABLE [dbo].[Indicators]  WITH CHECK ADD  CONSTRAINT [FK_Indicators_Indicator] FOREIGN KEY([Indicator_Id])
REFERENCES [dbo].[Indicator] ([Indicator_Id])
GO
ALTER TABLE [dbo].[Indicators] CHECK CONSTRAINT [FK_Indicators_Indicator]
GO
ALTER TABLE [dbo].[Indicators]  WITH CHECK ADD  CONSTRAINT [FK_Indicators_Universities] FOREIGN KEY([University_Id])
REFERENCES [dbo].[Universities] ([University_Id])
GO
ALTER TABLE [dbo].[Indicators] CHECK CONSTRAINT [FK_Indicators_Universities]
GO
ALTER TABLE [dbo].[Ratings]  WITH CHECK ADD  CONSTRAINT [FK_Ratings_Universities] FOREIGN KEY([University_Id])
REFERENCES [dbo].[Universities] ([University_Id])
GO
ALTER TABLE [dbo].[Ratings] CHECK CONSTRAINT [FK_Ratings_Universities]
GO
/****** Object:  StoredProcedure [dbo].[AddRating]    Script Date: 6/11/2021 10:12:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddRating]
	-- Add the parameters for the stored procedure here
	 @University_Id int,
	 @RatingValue int
AS
BEGIN 
	insert into Ratings( University_Id, RatingValue)
	values (@University_Id, @RatingValue);
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllIndicators]    Script Date: 6/11/2021 10:12:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllIndicators]
	 @UniversityId int
AS
    BEGIN
    select
    Ind.Indicator_Id,
    Ind.University_Id,
    IndR.IndicatorName,
    Ind.[Value],
    Ind.UnitOfMeasure,
    Univ.UniversityName,
    Ind.Year
    from Indicators as Ind
    join Universities as Univ on Ind.University_Id = Univ.University_Id
    join Indicator as IndR on Ind.Indicator_Id = IndR.Indicator_Id
    where Ind.University_Id = @UniversityId
END

GO
/****** Object:  StoredProcedure [dbo].[GetAllIndicatorsByUniversity]    Script Date: 6/11/2021 10:12:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllIndicatorsByUniversity]
    @UniversityId INT
AS
BEGIN
    SET NOCOUNT ON;

 

    SELECT 
    Ind.Indicator_Id,
    Ind.University_Id,
    I.IndicatorName,
    Ind.[Value],
    Ind.UnitOfMeasure,
    Ind.Year
    FROM Indicators AS Ind
    INNER JOIN Indicator as I on I.Indicator_Id = Ind.Indicator_Id
    where Ind.University_Id = @UniversityId
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllIndicatorsByUniversityAndIndicatorId]    Script Date: 6/11/2021 10:12:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllIndicatorsByUniversityAndIndicatorId] 
    @UniversityId INT,
    @IndicatorId INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
    Ind.Indicator_Id,
    Ind.University_Id,
    I.IndicatorName,
    Ind.[Value],
    Ind.UnitOfMeasure,
	U.UniversityName,
    Ind.[Year]
    FROM Indicators AS Ind
    INNER JOIN Indicator as I on I.Indicator_Id = Ind.Indicator_Id
	INNER JOIN Universities as U on U.University_Id = @UniversityId
    where Ind.University_Id = @UniversityId AND Ind.Indicator_Id = @IndicatorId
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllIndicatorsByUniversityAndYear]    Script Date: 6/11/2021 10:12:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllIndicatorsByUniversityAndYear] 
    @UniversityId INT,
    @Year INT
AS
BEGIN
    SET NOCOUNT ON;

 

    SELECT 
    Ind.Indicator_Id,
    Ind.University_Id,
    I.IndicatorName,
    Ind.[Value],
    Ind.UnitOfMeasure,
    Ind.Year
    FROM Indicators AS Ind
    INNER JOIN Indicator as I on I.Indicator_Id = Ind.Indicator_Id
    where Ind.University_Id = @UniversityId AND Ind.Year = @Year
END

GO
/****** Object:  StoredProcedure [dbo].[GetAllUniversities]    Script Date: 6/11/2021 10:12:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllUniversities] 
AS
BEGIN
    SET NOCOUNT ON;
 
    SELECT University_Id, UniversityName
    FROM Universities
END

GO
/****** Object:  StoredProcedure [dbo].[GetAllUsers]    Script Date: 6/11/2021 10:12:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllUsers] AS
SELECT [Login], [Password], [Role]
FROM Users
GO
/****** Object:  StoredProcedure [dbo].[GetAllYearsByUniversityId]    Script Date: 6/11/2021 10:12:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllYearsByUniversityId]
    @UniversityId INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT I.[Year]
    FROM Indicators AS I
    WHERE I.University_Id = @UniversityId
END
GO
/****** Object:  StoredProcedure [dbo].[RegisterUser]    Script Date: 6/11/2021 10:12:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RegisterUser] 
	-- Add the parameters for the stored procedure here
	 @Login nvarchar(300),
	 @Password nvarchar(300),
	 @Role nvarchar(300)
AS
BEGIN 
	insert into Users ([Login],[Password], [Role])
	values (@Login, @Password, @Role);
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateIndicator]    Script Date: 6/11/2021 10:12:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ================================================
-- Template generated from Template Explorer using:

CREATE PROCEDURE [dbo].[UpdateIndicator]
	 @Indicator_Id int,
	 @Value int
AS
BEGIN 
	Update Indicators
	Set [Value] = @Value
	where [Indicator_Id] = @Indicator_Id ;
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateRating]    Script Date: 6/11/2021 10:12:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateRating]
	-- Add the parameters for the stored procedure here
	 @Rating_Id int,
	 @University_Id int,
	 @RatingValue int
AS
BEGIN 
	Update Ratings
	Set [RatingValue] = @RatingValue
	where [Rating_Id] = @Rating_Id and University_Id = @University_Id;
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateRoleUser]    Script Date: 6/11/2021 10:12:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateRoleUser]
	 @Login nvarchar(300),
	 @Role nvarchar(300)
AS
BEGIN
	Update Users
	Set [Role] = @Role
	where [Login] = @Login;
END
GO
USE [master]
GO
ALTER DATABASE [UniversityRating] SET  READ_WRITE 
GO
