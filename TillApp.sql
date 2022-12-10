USE [master]
GO

/****** Object:  Database [TillApp]    Script Date: 12/10/2022 12:11:35 PM ******/
CREATE DATABASE [TillApp]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TillApp', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\TillApp.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TillApp_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\TillApp_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TillApp].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [TillApp] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [TillApp] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [TillApp] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [TillApp] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [TillApp] SET ARITHABORT OFF 
GO

ALTER DATABASE [TillApp] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [TillApp] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [TillApp] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [TillApp] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [TillApp] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [TillApp] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [TillApp] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [TillApp] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [TillApp] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [TillApp] SET  ENABLE_BROKER 
GO

ALTER DATABASE [TillApp] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [TillApp] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [TillApp] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [TillApp] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [TillApp] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [TillApp] SET READ_COMMITTED_SNAPSHOT ON 
GO

ALTER DATABASE [TillApp] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [TillApp] SET RECOVERY FULL 
GO

ALTER DATABASE [TillApp] SET  MULTI_USER 
GO

ALTER DATABASE [TillApp] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [TillApp] SET DB_CHAINING OFF 
GO

ALTER DATABASE [TillApp] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [TillApp] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [TillApp] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [TillApp] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [TillApp] SET QUERY_STORE = OFF
GO

ALTER DATABASE [TillApp] SET  READ_WRITE 
GO

