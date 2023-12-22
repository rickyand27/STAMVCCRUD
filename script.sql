USE [master]
GO
/****** Object:  Database [akademik]    Script Date: 22/12/2023 15:45:57 ******/
CREATE DATABASE [akademik]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MvcDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER01\MSSQL\DATA\MvcDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MvcDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER01\MSSQL\DATA\MvcDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [akademik] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [akademik].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [akademik] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [akademik] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [akademik] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [akademik] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [akademik] SET ARITHABORT OFF 
GO
ALTER DATABASE [akademik] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [akademik] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [akademik] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [akademik] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [akademik] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [akademik] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [akademik] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [akademik] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [akademik] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [akademik] SET  ENABLE_BROKER 
GO
ALTER DATABASE [akademik] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [akademik] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [akademik] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [akademik] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [akademik] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [akademik] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [akademik] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [akademik] SET RECOVERY FULL 
GO
ALTER DATABASE [akademik] SET  MULTI_USER 
GO
ALTER DATABASE [akademik] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [akademik] SET DB_CHAINING OFF 
GO
ALTER DATABASE [akademik] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [akademik] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [akademik] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [akademik] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'akademik', N'ON'
GO
ALTER DATABASE [akademik] SET QUERY_STORE = ON
GO
ALTER DATABASE [akademik] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [akademik]
GO
USE [akademik]
GO
/****** Object:  Sequence [dbo].[Seq_NIM]    Script Date: 22/12/2023 15:45:58 ******/
CREATE SEQUENCE [dbo].[Seq_NIM] 
 AS [bigint]
 START WITH 1
 INCREMENT BY 1
 MINVALUE -9223372036854775808
 MAXVALUE 9223372036854775807
 CACHE 
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 22/12/2023 15:45:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dosen]    Script Date: 22/12/2023 15:45:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dosen](
	[Nip] [bigint] IDENTITY(202312210001,1) NOT NULL,
	[Nama_Dosen] [varchar](25) NOT NULL,
 CONSTRAINT [PK_Dosen] PRIMARY KEY CLUSTERED 
(
	[Nip] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mahasiswa]    Script Date: 22/12/2023 15:45:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mahasiswa](
	[Nim] [int] IDENTITY(202300001,1) NOT NULL,
	[Nama_Mhs] [varchar](25) NOT NULL,
	[Tgl_Lahir] [datetime2](7) NOT NULL,
	[Alamat] [varchar](50) NOT NULL,
	[Jenis_Kelamin] [int] NOT NULL,
 CONSTRAINT [PK_Mahasiswa] PRIMARY KEY CLUSTERED 
(
	[Nim] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Matakuliah]    Script Date: 22/12/2023 15:45:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Matakuliah](
	[Kode_MK] [varchar](6) NOT NULL,
	[Nama_MK] [varchar](50) NOT NULL,
	[Sks] [int] NOT NULL,
 CONSTRAINT [PK_matakuliah] PRIMARY KEY CLUSTERED 
(
	[Kode_MK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Perkuliahan]    Script Date: 22/12/2023 15:45:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Perkuliahan](
	[IdPerkuliahan] [int] IDENTITY(1,1) NOT NULL,
	[Nim] [int] NOT NULL,
	[Kode_MK] [varchar](6) NOT NULL,
	[Nip] [bigint] NOT NULL,
	[Nilai] [char](1) NOT NULL,
 CONSTRAINT [PK__Perkulia__BA10A247A95FF124] PRIMARY KEY CLUSTERED 
(
	[IdPerkuliahan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Perkuliahan]  WITH CHECK ADD  CONSTRAINT [FK__Perkuliah__Kode___7F2BE32F] FOREIGN KEY([Kode_MK])
REFERENCES [dbo].[Matakuliah] ([Kode_MK])
GO
ALTER TABLE [dbo].[Perkuliahan] CHECK CONSTRAINT [FK__Perkuliah__Kode___7F2BE32F]
GO
ALTER TABLE [dbo].[Perkuliahan]  WITH CHECK ADD  CONSTRAINT [FK__Perkuliahan__Nim__7E37BEF6] FOREIGN KEY([Nim])
REFERENCES [dbo].[Mahasiswa] ([Nim])
GO
ALTER TABLE [dbo].[Perkuliahan] CHECK CONSTRAINT [FK__Perkuliahan__Nim__7E37BEF6]
GO
ALTER TABLE [dbo].[Perkuliahan]  WITH CHECK ADD  CONSTRAINT [FK__Perkuliahan__Nip__00200768] FOREIGN KEY([Nip])
REFERENCES [dbo].[Dosen] ([Nip])
GO
ALTER TABLE [dbo].[Perkuliahan] CHECK CONSTRAINT [FK__Perkuliahan__Nip__00200768]
GO
USE [master]
GO
ALTER DATABASE [akademik] SET  READ_WRITE 
GO
