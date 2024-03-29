USE [master]
GO

/****** Object:  Database [excisemis]    Script Date: 06-Sep-19 11:55:44 PM ******/
CREATE DATABASE [excisemis]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'excisemis', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\excisemis.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'excisemis_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\excisemis_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO

ALTER DATABASE [excisemis] SET COMPATIBILITY_LEVEL = 130
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [excisemis].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [excisemis] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [excisemis] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [excisemis] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [excisemis] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [excisemis] SET ARITHABORT OFF 
GO

ALTER DATABASE [excisemis] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [excisemis] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [excisemis] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [excisemis] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [excisemis] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [excisemis] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [excisemis] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [excisemis] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [excisemis] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [excisemis] SET  DISABLE_BROKER 
GO

ALTER DATABASE [excisemis] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [excisemis] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [excisemis] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [excisemis] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [excisemis] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [excisemis] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [excisemis] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [excisemis] SET RECOVERY FULL 
GO

ALTER DATABASE [excisemis] SET  MULTI_USER 
GO

ALTER DATABASE [excisemis] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [excisemis] SET DB_CHAINING OFF 
GO

ALTER DATABASE [excisemis] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [excisemis] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [excisemis] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [excisemis] SET QUERY_STORE = OFF
GO

USE [excisemis]
GO

ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO

ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO

ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO

ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO

ALTER DATABASE [excisemis] SET  READ_WRITE 
GO

