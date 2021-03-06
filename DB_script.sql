USE [master]
GO
/****** Object:  Database [Structure_of_company]    Script Date: 20. 7. 2021 10:04:46 ******/
CREATE DATABASE [Structure_of_company]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Structure_of_company', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Structure_of_company.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Structure_of_company_log', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Structure_of_company.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Structure_of_company] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Structure_of_company].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Structure_of_company] SET ANSI_NULL_DEFAULT ON 
GO
ALTER DATABASE [Structure_of_company] SET ANSI_NULLS ON 
GO
ALTER DATABASE [Structure_of_company] SET ANSI_PADDING ON 
GO
ALTER DATABASE [Structure_of_company] SET ANSI_WARNINGS ON 
GO
ALTER DATABASE [Structure_of_company] SET ARITHABORT ON 
GO
ALTER DATABASE [Structure_of_company] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Structure_of_company] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Structure_of_company] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Structure_of_company] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Structure_of_company] SET CURSOR_DEFAULT  LOCAL 
GO
ALTER DATABASE [Structure_of_company] SET CONCAT_NULL_YIELDS_NULL ON 
GO
ALTER DATABASE [Structure_of_company] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Structure_of_company] SET QUOTED_IDENTIFIER ON 
GO
ALTER DATABASE [Structure_of_company] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Structure_of_company] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Structure_of_company] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Structure_of_company] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Structure_of_company] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Structure_of_company] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Structure_of_company] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Structure_of_company] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Structure_of_company] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Structure_of_company] SET RECOVERY FULL 
GO
ALTER DATABASE [Structure_of_company] SET  MULTI_USER 
GO
ALTER DATABASE [Structure_of_company] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Structure_of_company] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Structure_of_company] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Structure_of_company] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Structure_of_company] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Structure_of_company] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Structure_of_company] SET QUERY_STORE = OFF
GO
USE [Structure_of_company]
GO
/****** Object:  Table [dbo].[BelongsTo]    Script Date: 20. 7. 2021 10:04:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BelongsTo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[employeeID] [int] NOT NULL,
	[structureID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 20. 7. 2021 10:04:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[employeeID] [int] IDENTITY(1,1) NOT NULL,
	[degree] [varchar](10) NULL,
	[name] [varchar](20) NOT NULL,
	[surname] [varchar](20) NOT NULL,
	[cellPhone] [varchar](20) NOT NULL,
	[email] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[employeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Structure]    Script Date: 20. 7. 2021 10:04:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Structure](
	[structureCode] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[type] [int] NOT NULL,
	[bossID] [int] NOT NULL,
	[upperStructureID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[structureCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BelongsTo]  WITH CHECK ADD FOREIGN KEY([employeeID])
REFERENCES [dbo].[Employee] ([employeeID])
GO
ALTER TABLE [dbo].[BelongsTo]  WITH CHECK ADD FOREIGN KEY([structureID])
REFERENCES [dbo].[Structure] ([structureCode])
GO
ALTER TABLE [dbo].[Structure]  WITH CHECK ADD FOREIGN KEY([bossID])
REFERENCES [dbo].[Employee] ([employeeID])
GO
ALTER TABLE [dbo].[Structure]  WITH CHECK ADD FOREIGN KEY([upperStructureID])
REFERENCES [dbo].[Structure] ([structureCode])
GO
USE [master]
GO
ALTER DATABASE [Structure_of_company] SET  READ_WRITE 
GO
