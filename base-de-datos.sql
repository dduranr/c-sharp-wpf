﻿USE [master]
GO
/****** Object:  Database [MVVMLoginDb]    Script Date: 30/06/2024 07:03:52 p. m. ******/
CREATE DATABASE [MVVMLoginDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MVVMLoginDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\MVVMLoginDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MVVMLoginDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\MVVMLoginDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [MVVMLoginDb] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MVVMLoginDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MVVMLoginDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MVVMLoginDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MVVMLoginDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MVVMLoginDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MVVMLoginDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [MVVMLoginDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MVVMLoginDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MVVMLoginDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MVVMLoginDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MVVMLoginDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MVVMLoginDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MVVMLoginDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MVVMLoginDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MVVMLoginDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MVVMLoginDb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [MVVMLoginDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MVVMLoginDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MVVMLoginDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MVVMLoginDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MVVMLoginDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MVVMLoginDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MVVMLoginDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MVVMLoginDb] SET RECOVERY FULL 
GO
ALTER DATABASE [MVVMLoginDb] SET  MULTI_USER 
GO
ALTER DATABASE [MVVMLoginDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MVVMLoginDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MVVMLoginDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MVVMLoginDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MVVMLoginDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MVVMLoginDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'MVVMLoginDb', N'ON'
GO
ALTER DATABASE [MVVMLoginDb] SET QUERY_STORE = ON
GO
ALTER DATABASE [MVVMLoginDb] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [MVVMLoginDb]
GO
/****** Object:  Table [dbo].[User]    Script Date: 30/06/2024 07:03:53 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [uniqueidentifier] NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[User] ([Id], [Username], [Password], [Name], [LastName], [Email]) VALUES (N'97b648b7-9b80-441f-a64a-3df1dc6128ea', N'jazz', N'querty', N'Jazzlyn Yarely', N'Sebhant', N'jazz.m@gmail.com')
INSERT [dbo].[User] ([Id], [Username], [Password], [Name], [LastName], [Email]) VALUES (N'28c4b3cb-c66a-4cb4-845f-4df473a49fa3', N'admin', N'admin', N'David', N'Durán', N'rjcode@gmail.com')
INSERT [dbo].[User] ([Id], [Username], [Password], [Name], [LastName], [Email]) VALUES (N'202ee724-14ed-40d8-8f59-b430c1cf4898', N'keni', N'asdfg', N'Kenisha Aira', N'Montero', N'keni.m@gmail.com')
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__User__536C85E46BB269F0]    Script Date: 30/06/2024 07:03:53 p. m. ******/
ALTER TABLE [dbo].[User] ADD UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__User__A9D105342D396990]    Script Date: 30/06/2024 07:03:53 p. m. ******/
ALTER TABLE [dbo].[User] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT (newid()) FOR [Id]
GO
USE [master]
GO
ALTER DATABASE [MVVMLoginDb] SET  READ_WRITE 
GO
