USE [master]
GO
/****** Object:  Database [AmicaRentDB]    Script Date: 4.01.2021 01:32:17 ******/
CREATE DATABASE [AmicaRentDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AmicaRentDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\AmicaRentDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AmicaRentDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\AmicaRentDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [AmicaRentDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AmicaRentDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AmicaRentDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AmicaRentDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AmicaRentDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AmicaRentDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AmicaRentDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [AmicaRentDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AmicaRentDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AmicaRentDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AmicaRentDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AmicaRentDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AmicaRentDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AmicaRentDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AmicaRentDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AmicaRentDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AmicaRentDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AmicaRentDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AmicaRentDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AmicaRentDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AmicaRentDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AmicaRentDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AmicaRentDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AmicaRentDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AmicaRentDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [AmicaRentDB] SET  MULTI_USER 
GO
ALTER DATABASE [AmicaRentDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AmicaRentDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AmicaRentDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AmicaRentDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AmicaRentDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [AmicaRentDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'AmicaRentDB', N'ON'
GO
ALTER DATABASE [AmicaRentDB] SET QUERY_STORE = OFF
GO
USE [AmicaRentDB]
GO
/****** Object:  Table [dbo].[Arac]    Script Date: 4.01.2021 01:32:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Arac](
	[Arac_ID] [int] IDENTITY(1,1) NOT NULL,
	[AracGrup_ID] [int] NOT NULL,
	[AracMarka_ID] [int] NOT NULL,
	[AracModel_ID] [int] NOT NULL,
	[Arac_Yil] [char](4) NOT NULL,
	[AracYakitTuru_ID] [int] NOT NULL,
	[Arac_VitesTipi] [char](10) NOT NULL,
	[AracKasaTipi_ID] [int] NOT NULL,
	[AracKlimaDurumu] [int] NOT NULL,
	[AracPlakaNo] [nvarchar](50) NOT NULL,
	[AracGuncelKM] [float] NOT NULL,
	[AracMotorNo] [nvarchar](50) NOT NULL,
	[AracSaseNo] [nvarchar](50) NOT NULL,
	[AracRuhsatSeriNo] [nvarchar](50) NOT NULL,
	[Arac_Status] [int] NOT NULL,
	[AracRenk_ID] [int] NOT NULL,
	[AracKiralamaDurumu] [int] NULL,
	[Arac_TrafikSigortasiBitisTarihi] [date] NULL,
	[Arac_KaskoBitisTarihi] [date] NULL,
	[Arac_KoltukSigortasiBitisTarihi] [date] NULL,
	[Arac_FenniMuayeneGecerlilikTarihi] [date] NULL,
 CONSTRAINT [PK_Arac] PRIMARY KEY CLUSTERED 
(
	[Arac_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AracGrup]    Script Date: 4.01.2021 01:32:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AracGrup](
	[AracGrup_ID] [int] IDENTITY(1,1) NOT NULL,
	[AracGrup_Adi] [nvarchar](50) NOT NULL,
	[AracGrup_Status] [int] NOT NULL,
	[AracGrup_CreateDate] [datetime] NULL,
 CONSTRAINT [PK_AracGrup] PRIMARY KEY CLUSTERED 
(
	[AracGrup_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AracRenk]    Script Date: 4.01.2021 01:32:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AracRenk](
	[AracRenk_ID] [int] IDENTITY(1,1) NOT NULL,
	[AracRenk_Adi] [nvarchar](50) NOT NULL,
	[AracRenk_Status] [int] NOT NULL,
	[AracRenk_CreateDate] [datetime] NULL,
 CONSTRAINT [PK_AracRenk] PRIMARY KEY CLUSTERED 
(
	[AracRenk_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AracKasaTipi]    Script Date: 4.01.2021 01:32:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AracKasaTipi](
	[AracKasaTipi_ID] [int] IDENTITY(1,1) NOT NULL,
	[AracKasaTipi_Adi] [nvarchar](50) NULL,
	[AracKasaTipi_Status] [int] NOT NULL,
	[AracKasaTipi_CreateDate] [datetime] NULL,
 CONSTRAINT [PK_AracKasaTipi] PRIMARY KEY CLUSTERED 
(
	[AracKasaTipi_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AracYakitTuru]    Script Date: 4.01.2021 01:32:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AracYakitTuru](
	[AracYakitTuru_ID] [int] IDENTITY(1,1) NOT NULL,
	[AracYakitTuru_Adi] [nvarchar](50) NOT NULL,
	[AracYakitTuru_Status] [int] NOT NULL,
	[AracYakitTuru_CreateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_AracYakitTuru] PRIMARY KEY CLUSTERED 
(
	[AracYakitTuru_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AracMarka]    Script Date: 4.01.2021 01:32:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AracMarka](
	[AracMarka_ID] [int] IDENTITY(1,1) NOT NULL,
	[AracMarka_Adi] [nvarchar](50) NULL,
	[AracMarka_Status] [int] NOT NULL,
	[AracMarka_CreateDate] [datetime] NULL,
 CONSTRAINT [PK_AracMarka] PRIMARY KEY CLUSTERED 
(
	[AracMarka_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AracModel]    Script Date: 4.01.2021 01:32:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AracModel](
	[AracModel_ID] [int] IDENTITY(1,1) NOT NULL,
	[AracMarka_ID] [int] NOT NULL,
	[AracModel_Adi] [nvarchar](50) NOT NULL,
	[AracModel_Status] [int] NOT NULL,
	[AracModel_CreateDate] [datetime] NULL,
 CONSTRAINT [PK_AracModel] PRIMARY KEY CLUSTERED 
(
	[AracModel_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[viewAracList]    Script Date: 4.01.2021 01:32:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[viewAracList]
AS
SELECT        dbo.Arac.Arac_ID,dbo.Arac.Arac_Status, dbo.AracGrup.AracGrup_Adi, dbo.AracMarka.AracMarka_Adi, dbo.AracModel.AracModel_Adi, dbo.Arac.Arac_Yil, dbo.AracYakitTuru.AracYakitTuru_Adi, dbo.Arac.Arac_VitesTipi, 
                         dbo.AracKasaTipi.AracKasaTipi_Adi, CASE WHEN dbo.Arac.AracKlimaDurumu = 1 THEN 'Klimalı' ELSE 'Klimasız' END AS KlimaDurumu, dbo.Arac.AracPlakaNo, dbo.Arac.AracGuncelKM, dbo.Arac.AracMotorNo, 
                         dbo.Arac.AracSaseNo, dbo.Arac.AracRuhsatSeriNo, dbo.AracRenk.AracRenk_Adi, 
                         CASE WHEN dbo.Arac.AracKiralamaDurumu = 0 THEN 'Boşta' WHEN dbo.Arac.AracKiralamaDurumu = 1 THEN 'Müşteride' WHEN dbo.Arac.AracKiralamaDurumu = 2 THEN 'Pasif Araç' WHEN dbo.Arac.AracKiralamaDurumu = 3 THEN
                          'Arızalı/Serviste' END AS KiralamaDurumu, dbo.Arac.Arac_TrafikSigortasiBitisTarihi, dbo.Arac.Arac_KaskoBitisTarihi, dbo.Arac.Arac_KoltukSigortasiBitisTarihi, dbo.Arac.Arac_FenniMuayeneGecerlilikTarihi
FROM            dbo.Arac INNER JOIN
                         dbo.AracGrup ON dbo.Arac.AracGrup_ID = dbo.AracGrup.AracGrup_ID INNER JOIN
                         dbo.AracKasaTipi ON dbo.Arac.AracKasaTipi_ID = dbo.AracKasaTipi.AracKasaTipi_ID INNER JOIN
                         dbo.AracMarka ON dbo.Arac.AracMarka_ID = dbo.AracMarka.AracMarka_ID INNER JOIN
                         dbo.AracModel ON dbo.Arac.AracModel_ID = dbo.AracModel.AracModel_ID INNER JOIN
                         dbo.AracRenk ON dbo.Arac.AracRenk_ID = dbo.AracRenk.AracRenk_ID INNER JOIN
                         dbo.AracYakitTuru ON dbo.Arac.AracYakitTuru_ID = dbo.AracYakitTuru.AracYakitTuru_ID
GO
/****** Object:  Table [dbo].[Cari]    Script Date: 4.01.2021 01:32:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cari](
	[Cari_ID] [int] IDENTITY(1,1) NOT NULL,
	[Cari_AdSoyad] [nvarchar](50) NULL,
	[Cari_UyrukID] [int] NULL,
	[Cari_IDNumber] [nvarchar](11) NULL,
	[Cari_Cinsiyet] [int] NULL,
	[Cari_DogumTarihi] [date] NULL,
	[Cari_EpostaAdresi] [nvarchar](100) NULL,
	[Cari_Adres1] [nvarchar](500) NULL,
	[Cari_Adres2] [nvarchar](500) NULL,
	[CariSehir_ID] [int] NULL,
	[Cari_MobilTelefon] [nvarchar](50) NULL,
	[Cari_LokalTelefon] [nvarchar](50) NULL,
	[Cari_CreateDate] [datetime] NULL,
	[Cari_Status] [int] NOT NULL,
 CONSTRAINT [PK_Cari] PRIMARY KEY CLUSTERED 
(
	[Cari_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Islem]    Script Date: 4.01.2021 01:32:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Islem](
	[Islem_ID] [int] IDENTITY(1,1) NOT NULL,
	[Islem_Tipi] [int] NULL,
	[Cari_ID] [int] NULL,
	[Arac_ID] [int] NULL,
	[Islem_BaslangicTarihi] [datetime] NULL,
	[Islem_BitisTarihi] [datetime] NULL,
	[Islem_IlkKM] [int] NULL,
	[Islem_SonKM] [int] NULL,
	[Islem_YakitDurumu] [int] NULL,
	[Islem_TeslimatLokasyonID] [int] NULL,
	[Islem_IadeLokasyonID] [int] NULL,
	[Islem_GunlukUcret] [float] NULL,
	[Islem_GunlukKMSiniri] [float] NULL,
	[Islem_ToplamKiralamaUcreti] [float] NULL,
	[Islem_ToplamKMAsimUcreti] [float] NULL,
	[Islem_ToplamEkstraHizmetler] [float] NULL,
	[Islem_ToplamValeHizmetleri] [float] NULL,
	[Islem_ToplamDigerUcretler] [float] NULL,
	[Islem_IskontoOrani] [int] NULL,
	[Islem_TahsilEdilen] [float] NULL,
	[Islem_KalanBorc] [float] NULL,
	[Islem_Status] [int] NOT NULL,
	[Islem_CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Islem] PRIMARY KEY CLUSTERED 
(
	[Islem_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[viewIslem]    Script Date: 4.01.2021 01:32:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[viewIslem]
AS
SELECT        dbo.Islem.Islem_ID, CASE WHEN dbo.Islem.Islem_Tipi = 1 THEN 'Rezervasyon' ELSE 'Kiralama' END AS IslemTipim, dbo.Cari.Cari_AdSoyad, dbo.viewAracList.AracGrup_Adi, dbo.viewAracList.AracMarka_Adi, 
                         dbo.viewAracList.AracModel_Adi, dbo.viewAracList.Arac_Yil, dbo.Islem.Islem_BaslangicTarihi, dbo.Islem.Islem_BitisTarihi, dbo.Islem.Islem_IlkKM, dbo.Islem.Islem_SonKM, dbo.Islem.Islem_YakitDurumu, 
                         dbo.Islem.Islem_TeslimatLokasyonID, dbo.Islem.Islem_IadeLokasyonID, dbo.Islem.Islem_GunlukUcret, dbo.Islem.Islem_GunlukKMSiniri, dbo.Islem.Islem_ToplamKiralamaUcreti, dbo.Islem.Islem_ToplamKMAsimUcreti, 
                         dbo.Islem.Islem_ToplamEkstraHizmetler, dbo.Islem.Islem_ToplamValeHizmetleri, dbo.Islem.Islem_ToplamDigerUcretler, dbo.Islem.Islem_IskontoOrani, dbo.Islem.Islem_TahsilEdilen, dbo.Islem.Islem_KalanBorc, 
                         dbo.Islem.Islem_Status, dbo.Islem.Islem_CreateDate
FROM            dbo.Islem INNER JOIN
                         dbo.Cari ON dbo.Islem.Cari_ID = dbo.Cari.Cari_ID INNER JOIN
                         dbo.viewAracList ON dbo.Islem.Arac_ID = dbo.viewAracList.Arac_ID
GO
/****** Object:  Table [dbo].[Servis]    Script Date: 4.01.2021 01:32:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Servis](
	[Servis_ID] [int] IDENTITY(1,1) NOT NULL,
	[Arac_ID] [int] NULL,
	[Servis_ServisZamani] [date] NULL,
	[ServisFirma_ID] [int] NULL,
	[Servis_Notlar] [nvarchar](500) NULL,
	[Servis_Ucreti] [float] NULL,
	[Servis_CreateDate] [datetime] NULL,
	[Servis_Status] [int] NOT NULL,
 CONSTRAINT [PK_Servis] PRIMARY KEY CLUSTERED 
(
	[Servis_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServisFirma]    Script Date: 4.01.2021 01:32:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServisFirma](
	[ServisFirma_ID] [int] IDENTITY(1,1) NOT NULL,
	[ServisFirma_Adi] [nvarchar](50) NULL,
	[ServisFirma_Adres1] [nvarchar](150) NULL,
	[ServisFirma_Adres2] [nvarchar](150) NULL,
	[ServisFirma_Tel1] [nvarchar](50) NULL,
	[ServisFirma_Tel2] [nvarchar](50) NULL,
	[ServisFirma_Email] [nvarchar](100) NULL,
	[ServisFirma_Yetkili] [nvarchar](50) NULL,
	[ServisFirma_CreateDate] [datetime] NULL,
	[ServisFirma_Status] [int] NOT NULL,
 CONSTRAINT [PK_ServisFirma] PRIMARY KEY CLUSTERED 
(
	[ServisFirma_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[viewServis]    Script Date: 4.01.2021 01:32:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[viewServis]
AS
SELECT        dbo.Servis.Servis_ID, dbo.viewAracList.AracGrup_Adi, dbo.viewAracList.AracMarka_Adi, dbo.viewAracList.AracModel_Adi, dbo.viewAracList.Arac_Yil, dbo.viewAracList.AracPlakaNo, dbo.Servis.Servis_ServisZamani, 
                         dbo.ServisFirma.ServisFirma_Adi, dbo.Servis.Servis_Notlar, dbo.Servis.Servis_Ucreti, dbo.Servis.Servis_Status
FROM            dbo.Servis INNER JOIN
                         dbo.ServisFirma ON dbo.Servis.ServisFirma_ID = dbo.ServisFirma.ServisFirma_ID INNER JOIN
                         dbo.viewAracList ON dbo.Servis.Arac_ID = dbo.viewAracList.Arac_ID
GO
/****** Object:  View [dbo].[viewAracModel]    Script Date: 4.01.2021 01:32:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[viewAracModel]
AS
SELECT        dbo.AracModel.AracModel_ID, dbo.AracModel.AracMarka_ID, dbo.AracMarka.AracMarka_Adi, dbo.AracModel.AracModel_Adi, dbo.AracModel.AracModel_Status, dbo.AracModel.AracModel_CreateDate
FROM            dbo.AracModel INNER JOIN
                         dbo.AracMarka ON dbo.AracModel.AracMarka_ID = dbo.AracMarka.AracMarka_ID
GO
/****** Object:  Table [dbo].[CariEhliyet]    Script Date: 4.01.2021 01:32:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CariEhliyet](
	[CariEhliyet_ID] [int] IDENTITY(1,1) NOT NULL,
	[Cari_ID] [int] NULL,
	[CariEhliyet_VerilisTarihi] [date] NULL,
	[CariEhliyet_GecerlilikTarihi] [date] NULL,
	[CariEhliyet_VerildigiYer] [nvarchar](50) NULL,
	[CariEhliyet_DogumYeri] [nvarchar](50) NULL,
	[CariEhliyet_EhliyetNumarasi] [nvarchar](50) NULL,
	[EhliyetSinif_ID] [int] NULL,
	[KanGrubu_ID] [int] NULL,
	[CariEhliyet_Status] [int] NOT NULL,
 CONSTRAINT [PK_CariEhliyet] PRIMARY KEY CLUSTERED 
(
	[CariEhliyet_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EhliyetSinif]    Script Date: 4.01.2021 01:32:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EhliyetSinif](
	[EhliyetSinif_ID] [int] IDENTITY(1,1) NOT NULL,
	[EhliyetSinif_Adi] [nvarchar](50) NULL,
	[EhliyetSinif_Status] [int] NOT NULL,
	[EhliyetSinif_CreateDate] [datetime] NULL,
 CONSTRAINT [PK_EhliyetSinif] PRIMARY KEY CLUSTERED 
(
	[EhliyetSinif_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KanGrubu]    Script Date: 4.01.2021 01:32:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KanGrubu](
	[KanGrubu_ID] [int] IDENTITY(1,1) NOT NULL,
	[KanGrubu_Adi] [nvarchar](50) NULL,
	[KanGrubu_Status] [int] NOT NULL,
	[KanGrubu_CreateDate] [datetime] NULL,
 CONSTRAINT [PK_KanGrubu] PRIMARY KEY CLUSTERED 
(
	[KanGrubu_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[viewCariEhliyet]    Script Date: 4.01.2021 01:32:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[viewCariEhliyet]
AS
SELECT dbo.CariEhliyet.CariEhliyet_ID, dbo.CariEhliyet.Cari_ID, dbo.Cari.Cari_AdSoyad, CONVERT(varchar, dbo.CariEhliyet.CariEhliyet_VerilisTarihi, 104) AS VerilisTarihi, CONVERT(varchar, dbo.CariEhliyet.CariEhliyet_GecerlilikTarihi, 104) AS GecerlilikTarihi, 
             dbo.CariEhliyet.CariEhliyet_DogumYeri, dbo.CariEhliyet.CariEhliyet_EhliyetNumarasi, dbo.EhliyetSinif.EhliyetSinif_Adi, dbo.KanGrubu.KanGrubu_Adi, dbo.CariEhliyet.CariEhliyet_Status
FROM   dbo.CariEhliyet INNER JOIN
             dbo.Cari ON dbo.CariEhliyet.Cari_ID = dbo.Cari.Cari_ID INNER JOIN
             dbo.EhliyetSinif ON dbo.CariEhliyet.EhliyetSinif_ID = dbo.EhliyetSinif.EhliyetSinif_ID INNER JOIN
             dbo.KanGrubu ON dbo.CariEhliyet.KanGrubu_ID = dbo.KanGrubu.KanGrubu_ID
GO
/****** Object:  Table [dbo].[CariSehir]    Script Date: 4.01.2021 01:32:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CariSehir](
	[CariSehir_ID] [int] IDENTITY(1,1) NOT NULL,
	[CariSehir_Adi] [nvarchar](50) NULL,
	[CariSehir_Status] [int] NOT NULL,
	[CariSehir_CreateDate] [datetime] NULL,
 CONSTRAINT [PK_CariSehir] PRIMARY KEY CLUSTERED 
(
	[CariSehir_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CariUyruk]    Script Date: 4.01.2021 01:32:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CariUyruk](
	[CariUyruk_ID] [int] IDENTITY(1,1) NOT NULL,
	[CariUyruk_Adi] [nvarchar](50) NULL,
	[CariUyruk_Status] [int] NOT NULL,
	[CariUyruk_CreateDate] [datetime] NULL,
 CONSTRAINT [PK_CariUyruk] PRIMARY KEY CLUSTERED 
(
	[CariUyruk_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[viewCari]    Script Date: 4.01.2021 01:32:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[viewCari]
AS
SELECT dbo.Cari.Cari_ID, dbo.Cari.Cari_Status, dbo.Cari.Cari_AdSoyad, dbo.CariUyruk.CariUyruk_Adi, dbo.Cari.Cari_IDNumber, CASE WHEN dbo.Cari.Cari_Cinsiyet = 1 THEN 'Erkek' ELSE 'Kadın' END AS Cinsiyet, dbo.Cari.Cari_DogumTarihi, dbo.Cari.Cari_EpostaAdresi, 
             dbo.Cari.Cari_Adres1, dbo.Cari.Cari_Adres2, dbo.CariSehir.CariSehir_Adi, dbo.Cari.Cari_MobilTelefon, dbo.Cari.Cari_LokalTelefon, dbo.Cari.Cari_CreateDate, dbo.CariEhliyet.CariEhliyet_ID
FROM   dbo.Cari INNER JOIN
             dbo.CariSehir ON dbo.Cari.CariSehir_ID = dbo.CariSehir.CariSehir_ID INNER JOIN
             dbo.CariUyruk ON dbo.Cari.Cari_UyrukID = dbo.CariUyruk.CariUyruk_ID LEFT OUTER JOIN
             dbo.CariEhliyet ON dbo.Cari.Cari_ID = dbo.CariEhliyet.Cari_ID
GO
/****** Object:  Table [dbo].[EkstraHizmetler]    Script Date: 4.01.2021 01:32:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EkstraHizmetler](
	[EkstraHizmetler_ID] [int] IDENTITY(1,1) NOT NULL,
	[EkstraHizmetler_Adi] [nvarchar](50) NULL,
	[EkstraHizmetler_Ucreti] [float] NULL,
	[EkstraHizmetler_Status] [int] NOT NULL,
	[EkstraHizmetler_CreateDate] [datetime] NULL,
 CONSTRAINT [PK_EkstraHizmetler] PRIMARY KEY CLUSTERED 
(
	[EkstraHizmetler_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EkSurucu]    Script Date: 4.01.2021 01:32:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EkSurucu](
	[EkSurucu_ID] [int] IDENTITY(1,1) NOT NULL,
	[Cari_ID] [int] NULL,
	[EkSurucu_CreateDate] [datetime] NULL,
	[EkSurucu_Status] [int] NOT NULL,
 CONSTRAINT [PK_EkSurucu] PRIMARY KEY CLUSTERED 
(
	[EkSurucu_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IslemEkstraHizmetler]    Script Date: 4.01.2021 01:32:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IslemEkstraHizmetler](
	[IslemEkstraHizmetler_ID] [int] IDENTITY(1,1) NOT NULL,
	[Islem_ID] [int] NULL,
	[EkstraHizmetler_ID] [int] NULL,
	[IslemEkstraHizmetler_CreateDate] [datetime] NULL,
	[IslemEkstraHizmetler_Status] [int] NOT NULL,
 CONSTRAINT [PK_IslemEkstraHizmetler] PRIMARY KEY CLUSTERED 
(
	[IslemEkstraHizmetler_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IslemTahsilat]    Script Date: 4.01.2021 01:32:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IslemTahsilat](
	[IslemTahsilat_ID] [int] IDENTITY(1,1) NOT NULL,
	[Islem_ID] [int] NULL,
	[IslemTahsilat_Tarih] [date] NULL,
	[IslemTahsilat_Aciklama] [nvarchar](150) NULL,
	[OdemeTipi_ID] [int] NULL,
	[IslemTahsilat_Tutar] [float] NULL,
	[IslemTahsilat_CreateDate] [datetime] NULL,
	[IslemTahsilat_Status] [int] NOT NULL,
 CONSTRAINT [PK_IslemTahsilat] PRIMARY KEY CLUSTERED 
(
	[IslemTahsilat_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kullanici]    Script Date: 4.01.2021 01:32:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kullanici](
	[Kullanici_ID] [int] IDENTITY(1,1) NOT NULL,
	[Kullanici_TamAdi] [nvarchar](50) NULL,
	[Kullanici_Adi] [nvarchar](50) NULL,
	[Kullanici_Sifre] [nvarchar](50) NULL,
	[Kullanici_SonGirisZamani] [datetime] NULL,
	[Kullanici_Status] [int] NOT NULL,
	[Kullanici_CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Kullanici] PRIMARY KEY CLUSTERED 
(
	[Kullanici_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KullaniciRolIliskileri]    Script Date: 4.01.2021 01:32:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KullaniciRolIliskileri](
	[RolIliski_ID] [int] IDENTITY(1,1) NOT NULL,
	[Rol_ID] [int] NOT NULL,
	[Kullanici_ID] [int] NOT NULL,
 CONSTRAINT [PK_KullaniciRolIliskileri] PRIMARY KEY CLUSTERED 
(
	[RolIliski_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KullaniciRolTanimlari]    Script Date: 4.01.2021 01:32:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KullaniciRolTanimlari](
	[Rol_ID] [int] IDENTITY(1,1) NOT NULL,
	[Rol_Adi] [nvarchar](50) NOT NULL,
	[Rol_Aciklama] [nvarchar](50) NOT NULL,
	[Rol_Kategori] [int] NOT NULL,
 CONSTRAINT [PK_KullaniciRolTanimlari] PRIMARY KEY CLUSTERED 
(
	[Rol_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lokasyon]    Script Date: 4.01.2021 01:32:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lokasyon](
	[Lokasyon_ID] [int] IDENTITY(1,1) NOT NULL,
	[Lokasyon_Adi] [nvarchar](50) NULL,
	[Lokasyon_Tipi] [int] NULL,
	[Lokasyon_Status] [int] NOT NULL,
	[Lokasyon_CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Table_2] PRIMARY KEY CLUSTERED 
(
	[Lokasyon_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OdemeTipi]    Script Date: 4.01.2021 01:32:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OdemeTipi](
	[OdemeTipi_ID] [int] IDENTITY(1,1) NOT NULL,
	[OdemeTipi_Adi] [nvarchar](50) NULL,
	[OdemeTipi_Status] [int] NOT NULL,
	[OdemeTipi_CreateDate] [datetime] NULL,
 CONSTRAINT [PK_OdemeTipi] PRIMARY KEY CLUSTERED 
(
	[OdemeTipi_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Arac] ON 
GO
INSERT [dbo].[Arac] ([Arac_ID], [AracGrup_ID], [AracMarka_ID], [AracModel_ID], [Arac_Yil], [AracYakitTuru_ID], [Arac_VitesTipi], [AracKasaTipi_ID], [AracKlimaDurumu], [AracPlakaNo], [AracGuncelKM], [AracMotorNo], [AracSaseNo], [AracRuhsatSeriNo], [Arac_Status], [AracRenk_ID], [AracKiralamaDurumu], [Arac_TrafikSigortasiBitisTarihi], [Arac_KaskoBitisTarihi], [Arac_KoltukSigortasiBitisTarihi], [Arac_FenniMuayeneGecerlilikTarihi]) VALUES (1, 1, 1, 1, N'2010', 1, N'OTOMATİK  ', 3, 1, N'34 MGM 34', 23000, N'AS7488377 NM 123 000000 761772-A', N'212198237948374', N'A-343412', 1, 1, 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-01-01' AS Date), CAST(N'2021-01-01' AS Date), CAST(N'2020-01-01' AS Date))
GO
INSERT [dbo].[Arac] ([Arac_ID], [AracGrup_ID], [AracMarka_ID], [AracModel_ID], [Arac_Yil], [AracYakitTuru_ID], [Arac_VitesTipi], [AracKasaTipi_ID], [AracKlimaDurumu], [AracPlakaNo], [AracGuncelKM], [AracMotorNo], [AracSaseNo], [AracRuhsatSeriNo], [Arac_Status], [AracRenk_ID], [AracKiralamaDurumu], [Arac_TrafikSigortasiBitisTarihi], [Arac_KaskoBitisTarihi], [Arac_KoltukSigortasiBitisTarihi], [Arac_FenniMuayeneGecerlilikTarihi]) VALUES (2, 2, 1, 12, N'2012', 1, N'MANUEL    ', 5, 1, N'34 ABC 11', 110909, N'AS7488377 NM 123 000000 761772-A', N'212198237948374', N'A-343412', 1, 2, 0, CAST(N'2021-01-01' AS Date), CAST(N'2021-01-01' AS Date), CAST(N'2021-01-01' AS Date), CAST(N'2020-01-01' AS Date))
GO
INSERT [dbo].[Arac] ([Arac_ID], [AracGrup_ID], [AracMarka_ID], [AracModel_ID], [Arac_Yil], [AracYakitTuru_ID], [Arac_VitesTipi], [AracKasaTipi_ID], [AracKlimaDurumu], [AracPlakaNo], [AracGuncelKM], [AracMotorNo], [AracSaseNo], [AracRuhsatSeriNo], [Arac_Status], [AracRenk_ID], [AracKiralamaDurumu], [Arac_TrafikSigortasiBitisTarihi], [Arac_KaskoBitisTarihi], [Arac_KoltukSigortasiBitisTarihi], [Arac_FenniMuayeneGecerlilikTarihi]) VALUES (3, 1, 2, 5, N'2019', 1, N'OTOMATİK  ', 3, 1, N'34 ZSM 99', 10000, N'AS7488377 NM 123 000000 761772-A', N'212198237948374', N'A-343412', 1, 2, 0, CAST(N'2021-01-01' AS Date), CAST(N'2021-01-01' AS Date), CAST(N'2021-01-01' AS Date), CAST(N'2020-01-01' AS Date))
GO
INSERT [dbo].[Arac] ([Arac_ID], [AracGrup_ID], [AracMarka_ID], [AracModel_ID], [Arac_Yil], [AracYakitTuru_ID], [Arac_VitesTipi], [AracKasaTipi_ID], [AracKlimaDurumu], [AracPlakaNo], [AracGuncelKM], [AracMotorNo], [AracSaseNo], [AracRuhsatSeriNo], [Arac_Status], [AracRenk_ID], [AracKiralamaDurumu], [Arac_TrafikSigortasiBitisTarihi], [Arac_KaskoBitisTarihi], [Arac_KoltukSigortasiBitisTarihi], [Arac_FenniMuayeneGecerlilikTarihi]) VALUES (4, 1, 1, 1, N'2010', 1, N'OTOMATİK  ', 3, 1, N'34 mgm 34', 23000, N'AS7488377 ', N'212198237948374', N'A-343412	', 1, 1, 0, CAST(N'2021-01-01' AS Date), CAST(N'2021-01-01' AS Date), CAST(N'2021-02-02' AS Date), CAST(N'2021-01-01' AS Date))
GO
SET IDENTITY_INSERT [dbo].[Arac] OFF
GO
SET IDENTITY_INSERT [dbo].[AracGrup] ON 
GO
INSERT [dbo].[AracGrup] ([AracGrup_ID], [AracGrup_Adi], [AracGrup_Status], [AracGrup_CreateDate]) VALUES (1, N'Lux Araç', 1, CAST(N'2020-11-24T13:12:01.307' AS DateTime))
GO
INSERT [dbo].[AracGrup] ([AracGrup_ID], [AracGrup_Adi], [AracGrup_Status], [AracGrup_CreateDate]) VALUES (2, N'Ticari Araç', 1, CAST(N'2020-11-24T13:12:06.293' AS DateTime))
GO
INSERT [dbo].[AracGrup] ([AracGrup_ID], [AracGrup_Adi], [AracGrup_Status], [AracGrup_CreateDate]) VALUES (3, N'Binek Araç', 1, CAST(N'2020-11-24T13:12:11.000' AS DateTime))
GO
INSERT [dbo].[AracGrup] ([AracGrup_ID], [AracGrup_Adi], [AracGrup_Status], [AracGrup_CreateDate]) VALUES (4, N'StationWagon Araç', 1, CAST(N'2020-11-24T13:12:18.293' AS DateTime))
GO
INSERT [dbo].[AracGrup] ([AracGrup_ID], [AracGrup_Adi], [AracGrup_Status], [AracGrup_CreateDate]) VALUES (5, N'Cabrio Araç', 1, CAST(N'2020-11-24T13:12:25.043' AS DateTime))
GO
INSERT [dbo].[AracGrup] ([AracGrup_ID], [AracGrup_Adi], [AracGrup_Status], [AracGrup_CreateDate]) VALUES (6, N'Özel Şöförlü Araç', 1, CAST(N'2020-11-24T13:12:31.693' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[AracGrup] OFF
GO
SET IDENTITY_INSERT [dbo].[AracKasaTipi] ON 
GO
INSERT [dbo].[AracKasaTipi] ([AracKasaTipi_ID], [AracKasaTipi_Adi], [AracKasaTipi_Status], [AracKasaTipi_CreateDate]) VALUES (1, N'Sedan', 1, CAST(N'2020-11-24T13:20:56.853' AS DateTime))
GO
INSERT [dbo].[AracKasaTipi] ([AracKasaTipi_ID], [AracKasaTipi_Adi], [AracKasaTipi_Status], [AracKasaTipi_CreateDate]) VALUES (2, N'Station Wagon', 1, CAST(N'2020-11-24T13:21:04.340' AS DateTime))
GO
INSERT [dbo].[AracKasaTipi] ([AracKasaTipi_ID], [AracKasaTipi_Adi], [AracKasaTipi_Status], [AracKasaTipi_CreateDate]) VALUES (3, N'Hatchback', 1, CAST(N'2020-11-24T13:21:08.917' AS DateTime))
GO
INSERT [dbo].[AracKasaTipi] ([AracKasaTipi_ID], [AracKasaTipi_Adi], [AracKasaTipi_Status], [AracKasaTipi_CreateDate]) VALUES (4, N'SUV', 1, CAST(N'2020-11-24T13:21:11.760' AS DateTime))
GO
INSERT [dbo].[AracKasaTipi] ([AracKasaTipi_ID], [AracKasaTipi_Adi], [AracKasaTipi_Status], [AracKasaTipi_CreateDate]) VALUES (5, N'Minibüs', 1, CAST(N'2020-11-24T13:25:55.040' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[AracKasaTipi] OFF
GO
SET IDENTITY_INSERT [dbo].[AracMarka] ON 
GO
INSERT [dbo].[AracMarka] ([AracMarka_ID], [AracMarka_Adi], [AracMarka_Status], [AracMarka_CreateDate]) VALUES (1, N'Mercedes', 1, CAST(N'2020-11-24T13:12:57.213' AS DateTime))
GO
INSERT [dbo].[AracMarka] ([AracMarka_ID], [AracMarka_Adi], [AracMarka_Status], [AracMarka_CreateDate]) VALUES (2, N'BMW', 1, CAST(N'2020-11-24T13:12:59.937' AS DateTime))
GO
INSERT [dbo].[AracMarka] ([AracMarka_ID], [AracMarka_Adi], [AracMarka_Status], [AracMarka_CreateDate]) VALUES (3, N'Range Rover', 1, CAST(N'2020-11-24T13:13:05.447' AS DateTime))
GO
INSERT [dbo].[AracMarka] ([AracMarka_ID], [AracMarka_Adi], [AracMarka_Status], [AracMarka_CreateDate]) VALUES (4, N'Mini', 1, CAST(N'2020-11-24T13:13:08.080' AS DateTime))
GO
INSERT [dbo].[AracMarka] ([AracMarka_ID], [AracMarka_Adi], [AracMarka_Status], [AracMarka_CreateDate]) VALUES (5, N'Renault', 1, CAST(N'2020-11-24T13:13:11.973' AS DateTime))
GO
INSERT [dbo].[AracMarka] ([AracMarka_ID], [AracMarka_Adi], [AracMarka_Status], [AracMarka_CreateDate]) VALUES (6, N'Masserati', 1, CAST(N'2020-11-24T13:13:18.123' AS DateTime))
GO
INSERT [dbo].[AracMarka] ([AracMarka_ID], [AracMarka_Adi], [AracMarka_Status], [AracMarka_CreateDate]) VALUES (7, N'Ford', 1, CAST(N'2020-11-24T13:13:20.927' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[AracMarka] OFF
GO
SET IDENTITY_INSERT [dbo].[AracModel] ON 
GO
INSERT [dbo].[AracModel] ([AracModel_ID], [AracMarka_ID], [AracModel_Adi], [AracModel_Status], [AracModel_CreateDate]) VALUES (1, 1, N'SLK 200', 1, NULL)
GO
INSERT [dbo].[AracModel] ([AracModel_ID], [AracMarka_ID], [AracModel_Adi], [AracModel_Status], [AracModel_CreateDate]) VALUES (2, 1, N'CLK 180', 1, NULL)
GO
INSERT [dbo].[AracModel] ([AracModel_ID], [AracMarka_ID], [AracModel_Adi], [AracModel_Status], [AracModel_CreateDate]) VALUES (3, 1, N'SLS 500', 1, NULL)
GO
INSERT [dbo].[AracModel] ([AracModel_ID], [AracMarka_ID], [AracModel_Adi], [AracModel_Status], [AracModel_CreateDate]) VALUES (4, 1, N'A 500', 1, NULL)
GO
INSERT [dbo].[AracModel] ([AracModel_ID], [AracMarka_ID], [AracModel_Adi], [AracModel_Status], [AracModel_CreateDate]) VALUES (5, 2, N'318 CI', 1, NULL)
GO
INSERT [dbo].[AracModel] ([AracModel_ID], [AracMarka_ID], [AracModel_Adi], [AracModel_Status], [AracModel_CreateDate]) VALUES (6, 2, N'316 D', 1, NULL)
GO
INSERT [dbo].[AracModel] ([AracModel_ID], [AracMarka_ID], [AracModel_Adi], [AracModel_Status], [AracModel_CreateDate]) VALUES (7, 2, N'520 D', 1, NULL)
GO
INSERT [dbo].[AracModel] ([AracModel_ID], [AracMarka_ID], [AracModel_Adi], [AracModel_Status], [AracModel_CreateDate]) VALUES (8, 4, N'Cooper S', 1, NULL)
GO
INSERT [dbo].[AracModel] ([AracModel_ID], [AracMarka_ID], [AracModel_Adi], [AracModel_Status], [AracModel_CreateDate]) VALUES (9, 5, N'Egea 180', 1, NULL)
GO
INSERT [dbo].[AracModel] ([AracModel_ID], [AracMarka_ID], [AracModel_Adi], [AracModel_Status], [AracModel_CreateDate]) VALUES (10, 6, N'XBox TDI', 1, NULL)
GO
INSERT [dbo].[AracModel] ([AracModel_ID], [AracMarka_ID], [AracModel_Adi], [AracModel_Status], [AracModel_CreateDate]) VALUES (11, 7, N'Fiesta 1.2', 1, NULL)
GO
INSERT [dbo].[AracModel] ([AracModel_ID], [AracMarka_ID], [AracModel_Adi], [AracModel_Status], [AracModel_CreateDate]) VALUES (12, 1, N'VİTO M', 1, NULL)
GO
SET IDENTITY_INSERT [dbo].[AracModel] OFF
GO
SET IDENTITY_INSERT [dbo].[AracRenk] ON 
GO
INSERT [dbo].[AracRenk] ([AracRenk_ID], [AracRenk_Adi], [AracRenk_Status], [AracRenk_CreateDate]) VALUES (1, N'BEYAZ', 1, NULL)
GO
INSERT [dbo].[AracRenk] ([AracRenk_ID], [AracRenk_Adi], [AracRenk_Status], [AracRenk_CreateDate]) VALUES (2, N'SIYAH', 1, NULL)
GO
INSERT [dbo].[AracRenk] ([AracRenk_ID], [AracRenk_Adi], [AracRenk_Status], [AracRenk_CreateDate]) VALUES (3, N'KIRMIZI', 1, NULL)
GO
INSERT [dbo].[AracRenk] ([AracRenk_ID], [AracRenk_Adi], [AracRenk_Status], [AracRenk_CreateDate]) VALUES (4, N'MAVİ', 1, NULL)
GO
INSERT [dbo].[AracRenk] ([AracRenk_ID], [AracRenk_Adi], [AracRenk_Status], [AracRenk_CreateDate]) VALUES (5, N'LACİVERT', 1, NULL)
GO
INSERT [dbo].[AracRenk] ([AracRenk_ID], [AracRenk_Adi], [AracRenk_Status], [AracRenk_CreateDate]) VALUES (6, N'SARI', 1, NULL)
GO
INSERT [dbo].[AracRenk] ([AracRenk_ID], [AracRenk_Adi], [AracRenk_Status], [AracRenk_CreateDate]) VALUES (7, N'FÜME', 1, NULL)
GO
SET IDENTITY_INSERT [dbo].[AracRenk] OFF
GO
SET IDENTITY_INSERT [dbo].[AracYakitTuru] ON 
GO
INSERT [dbo].[AracYakitTuru] ([AracYakitTuru_ID], [AracYakitTuru_Adi], [AracYakitTuru_Status], [AracYakitTuru_CreateDate]) VALUES (1, N'Benzin', 1, CAST(N'2020-11-24T13:18:58.613' AS DateTime))
GO
INSERT [dbo].[AracYakitTuru] ([AracYakitTuru_ID], [AracYakitTuru_Adi], [AracYakitTuru_Status], [AracYakitTuru_CreateDate]) VALUES (2, N'Diesel', 1, CAST(N'2020-11-24T13:19:01.383' AS DateTime))
GO
INSERT [dbo].[AracYakitTuru] ([AracYakitTuru_ID], [AracYakitTuru_Adi], [AracYakitTuru_Status], [AracYakitTuru_CreateDate]) VALUES (3, N'Elektrik', 1, CAST(N'2020-11-24T13:19:05.033' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[AracYakitTuru] OFF
GO
SET IDENTITY_INSERT [dbo].[Cari] ON 
GO
INSERT [dbo].[Cari] ([Cari_ID], [Cari_AdSoyad], [Cari_UyrukID], [Cari_IDNumber], [Cari_Cinsiyet], [Cari_DogumTarihi], [Cari_EpostaAdresi], [Cari_Adres1], [Cari_Adres2], [CariSehir_ID], [Cari_MobilTelefon], [Cari_LokalTelefon], [Cari_CreateDate], [Cari_Status]) VALUES (1, N'TOLGA ALTAY', 1, N'22342160594', 1, CAST(N'1976-10-28' AS Date), N'tolga.altay@gmail.com', N'Istanbul', N'Istanbul', 41, N'905301175594', N'902122300909', CAST(N'2020-11-24T13:31:00.143' AS DateTime), 1)
GO
INSERT [dbo].[Cari] ([Cari_ID], [Cari_AdSoyad], [Cari_UyrukID], [Cari_IDNumber], [Cari_Cinsiyet], [Cari_DogumTarihi], [Cari_EpostaAdresi], [Cari_Adres1], [Cari_Adres2], [CariSehir_ID], [Cari_MobilTelefon], [Cari_LokalTelefon], [Cari_CreateDate], [Cari_Status]) VALUES (2, N'FIRAT ACIOĞLU', 1, N'50328787123', 1, CAST(N'1980-02-15' AS Date), N'firatacioglu@hotmail.com', N'Istanbul', N'Istanbul', 41, N'905393340909', N'903129008191', CAST(N'2020-11-24T13:31:47.773' AS DateTime), 1)
GO
INSERT [dbo].[Cari] ([Cari_ID], [Cari_AdSoyad], [Cari_UyrukID], [Cari_IDNumber], [Cari_Cinsiyet], [Cari_DogumTarihi], [Cari_EpostaAdresi], [Cari_Adres1], [Cari_Adres2], [CariSehir_ID], [Cari_MobilTelefon], [Cari_LokalTelefon], [Cari_CreateDate], [Cari_Status]) VALUES (3, N'MURAT YAPICI', 1, N'50328787123', 1, CAST(N'1980-02-15' AS Date), N'firatacioglu@hotmail.com', N'Istanbul', N'Istanbul', 41, N'905393340909', N'903129008191', CAST(N'2020-11-24T13:31:47.773' AS DateTime), 1)
GO
INSERT [dbo].[Cari] ([Cari_ID], [Cari_AdSoyad], [Cari_UyrukID], [Cari_IDNumber], [Cari_Cinsiyet], [Cari_DogumTarihi], [Cari_EpostaAdresi], [Cari_Adres1], [Cari_Adres2], [CariSehir_ID], [Cari_MobilTelefon], [Cari_LokalTelefon], [Cari_CreateDate], [Cari_Status]) VALUES (4, N'ŞEBNEM YARGILI', 1, N'92819920019', 2, CAST(N'1984-09-09' AS Date), N'sebnem@yargili.com', N'Istanbul', N'Istanbul', 13, N'905334009090', N'902165609911', CAST(N'2020-11-24T13:33:33.393' AS DateTime), 1)
GO
INSERT [dbo].[Cari] ([Cari_ID], [Cari_AdSoyad], [Cari_UyrukID], [Cari_IDNumber], [Cari_Cinsiyet], [Cari_DogumTarihi], [Cari_EpostaAdresi], [Cari_Adres1], [Cari_Adres2], [CariSehir_ID], [Cari_MobilTelefon], [Cari_LokalTelefon], [Cari_CreateDate], [Cari_Status]) VALUES (5, N'müşteri 1', 1, N'1234567897', 1, CAST(N'1990-10-28' AS Date), N'musteri@test.com', N'adresi 1', N'adres 2', 13, N'5468666622', NULL, CAST(N'2020-11-29T16:42:21.187' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[Cari] OFF
GO
SET IDENTITY_INSERT [dbo].[CariEhliyet] ON 
GO
INSERT [dbo].[CariEhliyet] ([CariEhliyet_ID], [Cari_ID], [CariEhliyet_VerilisTarihi], [CariEhliyet_GecerlilikTarihi], [CariEhliyet_VerildigiYer], [CariEhliyet_DogumYeri], [CariEhliyet_EhliyetNumarasi], [EhliyetSinif_ID], [KanGrubu_ID], [CariEhliyet_Status]) VALUES (1, 1, CAST(N'2020-11-12' AS Date), CAST(N'2020-11-19' AS Date), N'Bakırköy', N'Malatya', N'ABC 123456', 2, 1, 1)
GO
INSERT [dbo].[CariEhliyet] ([CariEhliyet_ID], [Cari_ID], [CariEhliyet_VerilisTarihi], [CariEhliyet_GecerlilikTarihi], [CariEhliyet_VerildigiYer], [CariEhliyet_DogumYeri], [CariEhliyet_EhliyetNumarasi], [EhliyetSinif_ID], [KanGrubu_ID], [CariEhliyet_Status]) VALUES (2, 4, CAST(N'2021-01-01' AS Date), CAST(N'2020-12-31' AS Date), N'Maslak', N'Edremit', N'QAZ 7896635423', 6, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[CariEhliyet] OFF
GO
SET IDENTITY_INSERT [dbo].[CariSehir] ON 
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (8, N'Adana', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (9, N'Adıyaman', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (10, N'Afyon', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (11, N'Ağrı', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (12, N'Amasya', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (13, N'Ankara', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (14, N'Antalya', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (15, N'Artvin', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (16, N'Aydın', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (17, N'Balıkesir', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (18, N'Bilecik', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (19, N'Bingöl', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (20, N'Bitlis', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (21, N'Bolu', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (22, N'Burdur', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (23, N'Bursa', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (24, N'Çanakkale', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (25, N'Çankırı', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (26, N'Çorum', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (27, N'Denizli', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (28, N'Diyarbakır', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (29, N'Edirne', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (30, N'Elazığ', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (31, N'Erzincan', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (32, N'Erzurum', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (33, N'Eskişehir', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (34, N'Gaziantep', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (35, N'Giresun', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (36, N'Gümüşhane', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (37, N'Hakkari', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (38, N'Hatay', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (39, N'Isparta', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (40, N'Mersin', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (41, N'İstanbul', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (42, N'İzmir', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (43, N'Kars', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (44, N'Kastamonu', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (45, N'Kayseri', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (46, N'Kırklareli', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (47, N'Kırşehir', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (48, N'Kocaeli', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (49, N'Konya', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (50, N'Kütahya', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (51, N'Malatya', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (52, N'Manisa', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (53, N'K.Maraş', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (54, N'Mardin', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (55, N'Muğla', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (56, N'Muş', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (57, N'Nevşehir', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (58, N'Niğde', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (59, N'Ordu', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (60, N'Rize', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (61, N'Sakarya', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (62, N'Samsun', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (63, N'Siirt', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (64, N'Sinop', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (65, N'Sivas', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (66, N'Tekirdağ', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (67, N'Tokat', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (68, N'Trabzon', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (69, N'Tunceli', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (70, N'Şanlıurfa', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (71, N'Uşak', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (72, N'Van', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (73, N'Yozgat', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (74, N'Zonguldak', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (75, N'Aksaray', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (76, N'Bayburt', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (77, N'Karaman', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (78, N'Kırıkkale', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (79, N'Batman', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (80, N'Şırnak', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (81, N'Bartın', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (82, N'Ardahan', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (83, N'Iğdır', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (84, N'Yalova', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (85, N'Karabük', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (86, N'Kilis', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (87, N'Osmaniye', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (88, N'Düzce', 1, CAST(N'2021-01-03T19:35:04.703' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[CariSehir] OFF
GO
SET IDENTITY_INSERT [dbo].[CariUyruk] ON 
GO
INSERT [dbo].[CariUyruk] ([CariUyruk_ID], [CariUyruk_Adi], [CariUyruk_Status], [CariUyruk_CreateDate]) VALUES (1, N'TÜRKİYE CUMHURİYETİ', 1, NULL)
GO
INSERT [dbo].[CariUyruk] ([CariUyruk_ID], [CariUyruk_Adi], [CariUyruk_Status], [CariUyruk_CreateDate]) VALUES (2, N'AMERİKA BİRLEŞİK DEVLETLERİ', 1, NULL)
GO
INSERT [dbo].[CariUyruk] ([CariUyruk_ID], [CariUyruk_Adi], [CariUyruk_Status], [CariUyruk_CreateDate]) VALUES (3, N'ALMANYA', 1, NULL)
GO
INSERT [dbo].[CariUyruk] ([CariUyruk_ID], [CariUyruk_Adi], [CariUyruk_Status], [CariUyruk_CreateDate]) VALUES (4, N'FRANSA', 1, NULL)
GO
INSERT [dbo].[CariUyruk] ([CariUyruk_ID], [CariUyruk_Adi], [CariUyruk_Status], [CariUyruk_CreateDate]) VALUES (5, N'ÜRDÜN', 1, NULL)
GO
INSERT [dbo].[CariUyruk] ([CariUyruk_ID], [CariUyruk_Adi], [CariUyruk_Status], [CariUyruk_CreateDate]) VALUES (6, N'BİRLEŞİK KRALLIK', 1, NULL)
GO
INSERT [dbo].[CariUyruk] ([CariUyruk_ID], [CariUyruk_Adi], [CariUyruk_Status], [CariUyruk_CreateDate]) VALUES (7, N'URUGUAY', 1, NULL)
GO
INSERT [dbo].[CariUyruk] ([CariUyruk_ID], [CariUyruk_Adi], [CariUyruk_Status], [CariUyruk_CreateDate]) VALUES (8, N'UKRAYNA', 1, NULL)
GO
INSERT [dbo].[CariUyruk] ([CariUyruk_ID], [CariUyruk_Adi], [CariUyruk_Status], [CariUyruk_CreateDate]) VALUES (9, N'MONTENEGRO', 1, NULL)
GO
SET IDENTITY_INSERT [dbo].[CariUyruk] OFF
GO
SET IDENTITY_INSERT [dbo].[EhliyetSinif] ON 
GO
INSERT [dbo].[EhliyetSinif] ([EhliyetSinif_ID], [EhliyetSinif_Adi], [EhliyetSinif_Status], [EhliyetSinif_CreateDate]) VALUES (1, N'A', 1, CAST(N'2020-11-24T13:34:52.030' AS DateTime))
GO
INSERT [dbo].[EhliyetSinif] ([EhliyetSinif_ID], [EhliyetSinif_Adi], [EhliyetSinif_Status], [EhliyetSinif_CreateDate]) VALUES (2, N'C1', 1, CAST(N'2020-11-24T13:35:02.217' AS DateTime))
GO
INSERT [dbo].[EhliyetSinif] ([EhliyetSinif_ID], [EhliyetSinif_Adi], [EhliyetSinif_Status], [EhliyetSinif_CreateDate]) VALUES (3, N'C', 1, CAST(N'2020-11-24T13:35:04.133' AS DateTime))
GO
INSERT [dbo].[EhliyetSinif] ([EhliyetSinif_ID], [EhliyetSinif_Adi], [EhliyetSinif_Status], [EhliyetSinif_CreateDate]) VALUES (4, N'D1', 1, CAST(N'2020-11-24T13:35:09.950' AS DateTime))
GO
INSERT [dbo].[EhliyetSinif] ([EhliyetSinif_ID], [EhliyetSinif_Adi], [EhliyetSinif_Status], [EhliyetSinif_CreateDate]) VALUES (5, N'D', 1, CAST(N'2020-11-24T13:35:11.560' AS DateTime))
GO
INSERT [dbo].[EhliyetSinif] ([EhliyetSinif_ID], [EhliyetSinif_Adi], [EhliyetSinif_Status], [EhliyetSinif_CreateDate]) VALUES (6, N'BE', 1, CAST(N'2020-11-24T13:35:15.903' AS DateTime))
GO
INSERT [dbo].[EhliyetSinif] ([EhliyetSinif_ID], [EhliyetSinif_Adi], [EhliyetSinif_Status], [EhliyetSinif_CreateDate]) VALUES (7, N'CE', 1, CAST(N'2020-11-24T13:35:17.653' AS DateTime))
GO
INSERT [dbo].[EhliyetSinif] ([EhliyetSinif_ID], [EhliyetSinif_Adi], [EhliyetSinif_Status], [EhliyetSinif_CreateDate]) VALUES (8, N'C1E', 1, CAST(N'2020-11-24T13:35:23.747' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[EhliyetSinif] OFF
GO
SET IDENTITY_INSERT [dbo].[EkstraHizmetler] ON 
GO
INSERT [dbo].[EkstraHizmetler] ([EkstraHizmetler_ID], [EkstraHizmetler_Adi], [EkstraHizmetler_Ucreti], [EkstraHizmetler_Status], [EkstraHizmetler_CreateDate]) VALUES (1, N'BEBEK KOLTUĞU', 45, 1, NULL)
GO
INSERT [dbo].[EkstraHizmetler] ([EkstraHizmetler_ID], [EkstraHizmetler_Adi], [EkstraHizmetler_Ucreti], [EkstraHizmetler_Status], [EkstraHizmetler_CreateDate]) VALUES (2, N'CD ÇALAR', 19, 1, NULL)
GO
INSERT [dbo].[EkstraHizmetler] ([EkstraHizmetler_ID], [EkstraHizmetler_Adi], [EkstraHizmetler_Ucreti], [EkstraHizmetler_Status], [EkstraHizmetler_CreateDate]) VALUES (3, N'İLAVE SOFOR', 145, 1, NULL)
GO
INSERT [dbo].[EkstraHizmetler] ([EkstraHizmetler_ID], [EkstraHizmetler_Adi], [EkstraHizmetler_Ucreti], [EkstraHizmetler_Status], [EkstraHizmetler_CreateDate]) VALUES (4, N'VALE HİZMETLERİ', 100, 1, NULL)
GO
INSERT [dbo].[EkstraHizmetler] ([EkstraHizmetler_ID], [EkstraHizmetler_Adi], [EkstraHizmetler_Ucreti], [EkstraHizmetler_Status], [EkstraHizmetler_CreateDate]) VALUES (5, N'DİGER HİZMETLER', 60, 1, NULL)
GO
INSERT [dbo].[EkstraHizmetler] ([EkstraHizmetler_ID], [EkstraHizmetler_Adi], [EkstraHizmetler_Ucreti], [EkstraHizmetler_Status], [EkstraHizmetler_CreateDate]) VALUES (6, N'BEDELSİZ', 0, 1, NULL)
GO
SET IDENTITY_INSERT [dbo].[EkstraHizmetler] OFF
GO
SET IDENTITY_INSERT [dbo].[EkSurucu] ON 
GO
INSERT [dbo].[EkSurucu] ([EkSurucu_ID], [Cari_ID], [EkSurucu_CreateDate], [EkSurucu_Status]) VALUES (1, 1, NULL, 1)
GO
INSERT [dbo].[EkSurucu] ([EkSurucu_ID], [Cari_ID], [EkSurucu_CreateDate], [EkSurucu_Status]) VALUES (2, 2, NULL, 1)
GO
INSERT [dbo].[EkSurucu] ([EkSurucu_ID], [Cari_ID], [EkSurucu_CreateDate], [EkSurucu_Status]) VALUES (3, 3, NULL, 1)
GO
INSERT [dbo].[EkSurucu] ([EkSurucu_ID], [Cari_ID], [EkSurucu_CreateDate], [EkSurucu_Status]) VALUES (4, 4, NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[EkSurucu] OFF
GO
SET IDENTITY_INSERT [dbo].[Islem] ON 
GO
INSERT [dbo].[Islem] ([Islem_ID], [Islem_Tipi], [Cari_ID], [Arac_ID], [Islem_BaslangicTarihi], [Islem_BitisTarihi], [Islem_IlkKM], [Islem_SonKM], [Islem_YakitDurumu], [Islem_TeslimatLokasyonID], [Islem_IadeLokasyonID], [Islem_GunlukUcret], [Islem_GunlukKMSiniri], [Islem_ToplamKiralamaUcreti], [Islem_ToplamKMAsimUcreti], [Islem_ToplamEkstraHizmetler], [Islem_ToplamValeHizmetleri], [Islem_ToplamDigerUcretler], [Islem_IskontoOrani], [Islem_TahsilEdilen], [Islem_KalanBorc], [Islem_Status], [Islem_CreateDate]) VALUES (1, 1, 1, 1, CAST(N'2020-11-24T00:00:00.000' AS DateTime), CAST(N'2020-11-26T00:00:00.000' AS DateTime), 29000, 29700, 50, 1, 1, 1000, 100, 2000, 0, 0, 0, 0, 0, 0, 2000, 1, NULL)
GO
INSERT [dbo].[Islem] ([Islem_ID], [Islem_Tipi], [Cari_ID], [Arac_ID], [Islem_BaslangicTarihi], [Islem_BitisTarihi], [Islem_IlkKM], [Islem_SonKM], [Islem_YakitDurumu], [Islem_TeslimatLokasyonID], [Islem_IadeLokasyonID], [Islem_GunlukUcret], [Islem_GunlukKMSiniri], [Islem_ToplamKiralamaUcreti], [Islem_ToplamKMAsimUcreti], [Islem_ToplamEkstraHizmetler], [Islem_ToplamValeHizmetleri], [Islem_ToplamDigerUcretler], [Islem_IskontoOrani], [Islem_TahsilEdilen], [Islem_KalanBorc], [Islem_Status], [Islem_CreateDate]) VALUES (2, 1, 2, 2, CAST(N'2020-11-24T00:00:00.000' AS DateTime), CAST(N'2020-11-26T00:00:00.000' AS DateTime), 29000, 29700, 50, 1, 1, 1000, 100, 2000, 0, 0, 0, 0, 0, 0, 2000, 1, NULL)
GO
INSERT [dbo].[Islem] ([Islem_ID], [Islem_Tipi], [Cari_ID], [Arac_ID], [Islem_BaslangicTarihi], [Islem_BitisTarihi], [Islem_IlkKM], [Islem_SonKM], [Islem_YakitDurumu], [Islem_TeslimatLokasyonID], [Islem_IadeLokasyonID], [Islem_GunlukUcret], [Islem_GunlukKMSiniri], [Islem_ToplamKiralamaUcreti], [Islem_ToplamKMAsimUcreti], [Islem_ToplamEkstraHizmetler], [Islem_ToplamValeHizmetleri], [Islem_ToplamDigerUcretler], [Islem_IskontoOrani], [Islem_TahsilEdilen], [Islem_KalanBorc], [Islem_Status], [Islem_CreateDate]) VALUES (3, 1, 3, 3, CAST(N'2020-11-24T00:00:00.000' AS DateTime), CAST(N'2020-11-26T00:00:00.000' AS DateTime), 29000, 29700, 50, 1, 1, 1000, 100, 2000, 0, 0, 0, 0, 0, 0, 2000, 1, NULL)
GO
INSERT [dbo].[Islem] ([Islem_ID], [Islem_Tipi], [Cari_ID], [Arac_ID], [Islem_BaslangicTarihi], [Islem_BitisTarihi], [Islem_IlkKM], [Islem_SonKM], [Islem_YakitDurumu], [Islem_TeslimatLokasyonID], [Islem_IadeLokasyonID], [Islem_GunlukUcret], [Islem_GunlukKMSiniri], [Islem_ToplamKiralamaUcreti], [Islem_ToplamKMAsimUcreti], [Islem_ToplamEkstraHizmetler], [Islem_ToplamValeHizmetleri], [Islem_ToplamDigerUcretler], [Islem_IskontoOrani], [Islem_TahsilEdilen], [Islem_KalanBorc], [Islem_Status], [Islem_CreateDate]) VALUES (4, 1, 4, 4, CAST(N'2020-11-24T00:00:00.000' AS DateTime), CAST(N'2020-11-26T00:00:00.000' AS DateTime), 29000, 29700, 50, 1, 1, 1000, 100, 2000, 0, 0, 0, 0, 0, 0, 2000, 1, NULL)
GO
SET IDENTITY_INSERT [dbo].[Islem] OFF
GO
SET IDENTITY_INSERT [dbo].[KanGrubu] ON 
GO
INSERT [dbo].[KanGrubu] ([KanGrubu_ID], [KanGrubu_Adi], [KanGrubu_Status], [KanGrubu_CreateDate]) VALUES (1, N'A Rh -', 1, CAST(N'2021-01-01T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[KanGrubu] ([KanGrubu_ID], [KanGrubu_Adi], [KanGrubu_Status], [KanGrubu_CreateDate]) VALUES (2, N'A Rh +', 1, CAST(N'2021-01-04T01:30:46.207' AS DateTime))
GO
INSERT [dbo].[KanGrubu] ([KanGrubu_ID], [KanGrubu_Adi], [KanGrubu_Status], [KanGrubu_CreateDate]) VALUES (3, N'B Rh -', 1, CAST(N'2021-01-04T01:31:03.630' AS DateTime))
GO
INSERT [dbo].[KanGrubu] ([KanGrubu_ID], [KanGrubu_Adi], [KanGrubu_Status], [KanGrubu_CreateDate]) VALUES (4, N'B Rh +', 1, CAST(N'2021-01-04T01:31:08.313' AS DateTime))
GO
INSERT [dbo].[KanGrubu] ([KanGrubu_ID], [KanGrubu_Adi], [KanGrubu_Status], [KanGrubu_CreateDate]) VALUES (5, N'AB Rh -', 1, CAST(N'2021-01-04T01:31:26.577' AS DateTime))
GO
INSERT [dbo].[KanGrubu] ([KanGrubu_ID], [KanGrubu_Adi], [KanGrubu_Status], [KanGrubu_CreateDate]) VALUES (6, N'AB Rh +', 1, CAST(N'2021-01-04T01:31:28.870' AS DateTime))
GO
INSERT [dbo].[KanGrubu] ([KanGrubu_ID], [KanGrubu_Adi], [KanGrubu_Status], [KanGrubu_CreateDate]) VALUES (7, N'0 Rh -', 1, CAST(N'2021-01-04T01:31:35.670' AS DateTime))
GO
INSERT [dbo].[KanGrubu] ([KanGrubu_ID], [KanGrubu_Adi], [KanGrubu_Status], [KanGrubu_CreateDate]) VALUES (8, N'0 Rh +', 1, CAST(N'2021-01-04T01:31:37.583' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[KanGrubu] OFF
GO
SET IDENTITY_INSERT [dbo].[Kullanici] ON 
GO
INSERT [dbo].[Kullanici] ([Kullanici_ID], [Kullanici_TamAdi], [Kullanici_Adi], [Kullanici_Sifre], [Kullanici_SonGirisZamani], [Kullanici_Status], [Kullanici_CreateDate]) VALUES (1, N'Said Yeter', N'saidyeter', N'123456', CAST(N'2021-01-04T00:09:44.990' AS DateTime), 1, CAST(N'2020-11-28T16:29:04.990' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Kullanici] OFF
GO
SET IDENTITY_INSERT [dbo].[KullaniciRolIliskileri] ON 
GO
INSERT [dbo].[KullaniciRolIliskileri] ([RolIliski_ID], [Rol_ID], [Kullanici_ID]) VALUES (1, 1, 1)
GO
INSERT [dbo].[KullaniciRolIliskileri] ([RolIliski_ID], [Rol_ID], [Kullanici_ID]) VALUES (2, 2, 1)
GO
INSERT [dbo].[KullaniciRolIliskileri] ([RolIliski_ID], [Rol_ID], [Kullanici_ID]) VALUES (3, 3, 1)
GO
INSERT [dbo].[KullaniciRolIliskileri] ([RolIliski_ID], [Rol_ID], [Kullanici_ID]) VALUES (4, 4, 1)
GO
INSERT [dbo].[KullaniciRolIliskileri] ([RolIliski_ID], [Rol_ID], [Kullanici_ID]) VALUES (6, 5, 1)
GO
INSERT [dbo].[KullaniciRolIliskileri] ([RolIliski_ID], [Rol_ID], [Kullanici_ID]) VALUES (7, 6, 1)
GO
INSERT [dbo].[KullaniciRolIliskileri] ([RolIliski_ID], [Rol_ID], [Kullanici_ID]) VALUES (8, 7, 1)
GO
INSERT [dbo].[KullaniciRolIliskileri] ([RolIliski_ID], [Rol_ID], [Kullanici_ID]) VALUES (9, 8, 1)
GO
INSERT [dbo].[KullaniciRolIliskileri] ([RolIliski_ID], [Rol_ID], [Kullanici_ID]) VALUES (10, 9, 1)
GO
INSERT [dbo].[KullaniciRolIliskileri] ([RolIliski_ID], [Rol_ID], [Kullanici_ID]) VALUES (11, 10, 1)
GO
INSERT [dbo].[KullaniciRolIliskileri] ([RolIliski_ID], [Rol_ID], [Kullanici_ID]) VALUES (12, 11, 1)
GO
INSERT [dbo].[KullaniciRolIliskileri] ([RolIliski_ID], [Rol_ID], [Kullanici_ID]) VALUES (13, 12, 1)
GO
INSERT [dbo].[KullaniciRolIliskileri] ([RolIliski_ID], [Rol_ID], [Kullanici_ID]) VALUES (14, 13, 1)
GO
INSERT [dbo].[KullaniciRolIliskileri] ([RolIliski_ID], [Rol_ID], [Kullanici_ID]) VALUES (15, 14, 1)
GO
INSERT [dbo].[KullaniciRolIliskileri] ([RolIliski_ID], [Rol_ID], [Kullanici_ID]) VALUES (16, 15, 1)
GO
INSERT [dbo].[KullaniciRolIliskileri] ([RolIliski_ID], [Rol_ID], [Kullanici_ID]) VALUES (17, 16, 1)
GO
INSERT [dbo].[KullaniciRolIliskileri] ([RolIliski_ID], [Rol_ID], [Kullanici_ID]) VALUES (18, 17, 1)
GO
INSERT [dbo].[KullaniciRolIliskileri] ([RolIliski_ID], [Rol_ID], [Kullanici_ID]) VALUES (19, 18, 1)
GO
INSERT [dbo].[KullaniciRolIliskileri] ([RolIliski_ID], [Rol_ID], [Kullanici_ID]) VALUES (20, 19, 1)
GO
INSERT [dbo].[KullaniciRolIliskileri] ([RolIliski_ID], [Rol_ID], [Kullanici_ID]) VALUES (22, 20, 1)
GO
INSERT [dbo].[KullaniciRolIliskileri] ([RolIliski_ID], [Rol_ID], [Kullanici_ID]) VALUES (23, 21, 1)
GO
INSERT [dbo].[KullaniciRolIliskileri] ([RolIliski_ID], [Rol_ID], [Kullanici_ID]) VALUES (24, 22, 1)
GO
INSERT [dbo].[KullaniciRolIliskileri] ([RolIliski_ID], [Rol_ID], [Kullanici_ID]) VALUES (25, 23, 1)
GO
INSERT [dbo].[KullaniciRolIliskileri] ([RolIliski_ID], [Rol_ID], [Kullanici_ID]) VALUES (26, 24, 1)
GO
INSERT [dbo].[KullaniciRolIliskileri] ([RolIliski_ID], [Rol_ID], [Kullanici_ID]) VALUES (27, 25, 1)
GO
SET IDENTITY_INSERT [dbo].[KullaniciRolIliskileri] OFF
GO
SET IDENTITY_INSERT [dbo].[KullaniciRolTanimlari] ON 
GO
INSERT [dbo].[KullaniciRolTanimlari] ([Rol_ID], [Rol_Adi], [Rol_Aciklama], [Rol_Kategori]) VALUES (1, N'Arac', N'Arac Okuma Yazma', 1)
GO
INSERT [dbo].[KullaniciRolTanimlari] ([Rol_ID], [Rol_Adi], [Rol_Aciklama], [Rol_Kategori]) VALUES (2, N'AracGrup', N'AracGrup Okuma Yazma', 1)
GO
INSERT [dbo].[KullaniciRolTanimlari] ([Rol_ID], [Rol_Adi], [Rol_Aciklama], [Rol_Kategori]) VALUES (3, N'AracKasaTipi', N'AracKasaTipi RW', 1)
GO
INSERT [dbo].[KullaniciRolTanimlari] ([Rol_ID], [Rol_Adi], [Rol_Aciklama], [Rol_Kategori]) VALUES (4, N'AracMarka', N'AracMarka RW', 1)
GO
INSERT [dbo].[KullaniciRolTanimlari] ([Rol_ID], [Rol_Adi], [Rol_Aciklama], [Rol_Kategori]) VALUES (5, N'AracModel', N'AracModel RW', 1)
GO
INSERT [dbo].[KullaniciRolTanimlari] ([Rol_ID], [Rol_Adi], [Rol_Aciklama], [Rol_Kategori]) VALUES (6, N'AracRenk', N'AracRenk RW', 1)
GO
INSERT [dbo].[KullaniciRolTanimlari] ([Rol_ID], [Rol_Adi], [Rol_Aciklama], [Rol_Kategori]) VALUES (7, N'AracYakitTuru', N'AracYakitTuru RW', 1)
GO
INSERT [dbo].[KullaniciRolTanimlari] ([Rol_ID], [Rol_Adi], [Rol_Aciklama], [Rol_Kategori]) VALUES (8, N'Cari', N'Cari RW', 2)
GO
INSERT [dbo].[KullaniciRolTanimlari] ([Rol_ID], [Rol_Adi], [Rol_Aciklama], [Rol_Kategori]) VALUES (9, N'CariEhliyet', N'CariEhliyet RW', 2)
GO
INSERT [dbo].[KullaniciRolTanimlari] ([Rol_ID], [Rol_Adi], [Rol_Aciklama], [Rol_Kategori]) VALUES (10, N'CariSehir', N'CariSehir RW', 2)
GO
INSERT [dbo].[KullaniciRolTanimlari] ([Rol_ID], [Rol_Adi], [Rol_Aciklama], [Rol_Kategori]) VALUES (11, N'CariUyruk', N'CariUyruk RW', 2)
GO
INSERT [dbo].[KullaniciRolTanimlari] ([Rol_ID], [Rol_Adi], [Rol_Aciklama], [Rol_Kategori]) VALUES (12, N'EhliyetSinif', N'EhliyetSinif RW', 2)
GO
INSERT [dbo].[KullaniciRolTanimlari] ([Rol_ID], [Rol_Adi], [Rol_Aciklama], [Rol_Kategori]) VALUES (13, N'EkstraHizmetler', N'EkstraHizmetler RW', 3)
GO
INSERT [dbo].[KullaniciRolTanimlari] ([Rol_ID], [Rol_Adi], [Rol_Aciklama], [Rol_Kategori]) VALUES (14, N'EkSurucu', N'EkSurucu RW', 3)
GO
INSERT [dbo].[KullaniciRolTanimlari] ([Rol_ID], [Rol_Adi], [Rol_Aciklama], [Rol_Kategori]) VALUES (15, N'Islem', N'Islem RW', 3)
GO
INSERT [dbo].[KullaniciRolTanimlari] ([Rol_ID], [Rol_Adi], [Rol_Aciklama], [Rol_Kategori]) VALUES (16, N'IslemEkstraHizmetler', N'IslemEkstraHizmetler RW', 3)
GO
INSERT [dbo].[KullaniciRolTanimlari] ([Rol_ID], [Rol_Adi], [Rol_Aciklama], [Rol_Kategori]) VALUES (17, N'IslemTahsilat', N'IslemTahsilat RW', 3)
GO
INSERT [dbo].[KullaniciRolTanimlari] ([Rol_ID], [Rol_Adi], [Rol_Aciklama], [Rol_Kategori]) VALUES (18, N'KanGrubu', N'KanGrubu RW', 4)
GO
INSERT [dbo].[KullaniciRolTanimlari] ([Rol_ID], [Rol_Adi], [Rol_Aciklama], [Rol_Kategori]) VALUES (19, N'Kullanici', N'Kullanici RW', 9)
GO
INSERT [dbo].[KullaniciRolTanimlari] ([Rol_ID], [Rol_Adi], [Rol_Aciklama], [Rol_Kategori]) VALUES (20, N'KullaniciRolIliskileri', N'KullaniciRolIliskileri RW', 9)
GO
INSERT [dbo].[KullaniciRolTanimlari] ([Rol_ID], [Rol_Adi], [Rol_Aciklama], [Rol_Kategori]) VALUES (21, N'KullaniciRolTanimlari', N'KullaniciRolTanimlari RW', 9)
GO
INSERT [dbo].[KullaniciRolTanimlari] ([Rol_ID], [Rol_Adi], [Rol_Aciklama], [Rol_Kategori]) VALUES (22, N'Lokasyon', N'Lokasyon RW', 4)
GO
INSERT [dbo].[KullaniciRolTanimlari] ([Rol_ID], [Rol_Adi], [Rol_Aciklama], [Rol_Kategori]) VALUES (23, N'OdemeTipi', N'OdemeTipi RW', 4)
GO
INSERT [dbo].[KullaniciRolTanimlari] ([Rol_ID], [Rol_Adi], [Rol_Aciklama], [Rol_Kategori]) VALUES (24, N'Servis', N'Servis RW', 4)
GO
INSERT [dbo].[KullaniciRolTanimlari] ([Rol_ID], [Rol_Adi], [Rol_Aciklama], [Rol_Kategori]) VALUES (25, N'ServisFirma', N'ServisFirma RW', 4)
GO
SET IDENTITY_INSERT [dbo].[KullaniciRolTanimlari] OFF
GO
SET IDENTITY_INSERT [dbo].[Lokasyon] ON 
GO
INSERT [dbo].[Lokasyon] ([Lokasyon_ID], [Lokasyon_Adi], [Lokasyon_Tipi], [Lokasyon_Status], [Lokasyon_CreateDate]) VALUES (1, N'AVRUPA YAKASI TESLİMAT MERKEZİ', 0, 1, CAST(N'2020-11-24T14:05:19.860' AS DateTime))
GO
INSERT [dbo].[Lokasyon] ([Lokasyon_ID], [Lokasyon_Adi], [Lokasyon_Tipi], [Lokasyon_Status], [Lokasyon_CreateDate]) VALUES (2, N'ANADOLU YAKASI TESLİMAT MERKEZİ', 0, 1, CAST(N'2020-11-24T14:05:26.793' AS DateTime))
GO
INSERT [dbo].[Lokasyon] ([Lokasyon_ID], [Lokasyon_Adi], [Lokasyon_Tipi], [Lokasyon_Status], [Lokasyon_CreateDate]) VALUES (3, N'SABİHA GÖKÇEN HAVALİMANI TESLİMAT BÖLGESİ', 0, 1, CAST(N'2020-11-24T14:05:38.900' AS DateTime))
GO
INSERT [dbo].[Lokasyon] ([Lokasyon_ID], [Lokasyon_Adi], [Lokasyon_Tipi], [Lokasyon_Status], [Lokasyon_CreateDate]) VALUES (4, N'İSTANBUL HAVALİMANI TESLİMAT BÖLGESİ', 0, 1, CAST(N'2020-11-24T14:05:50.630' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Lokasyon] OFF
GO
SET IDENTITY_INSERT [dbo].[OdemeTipi] ON 
GO
INSERT [dbo].[OdemeTipi] ([OdemeTipi_ID], [OdemeTipi_Adi], [OdemeTipi_Status], [OdemeTipi_CreateDate]) VALUES (1, N'NAKİT', 1, NULL)
GO
INSERT [dbo].[OdemeTipi] ([OdemeTipi_ID], [OdemeTipi_Adi], [OdemeTipi_Status], [OdemeTipi_CreateDate]) VALUES (2, N'BANKA HAVALE', 1, NULL)
GO
INSERT [dbo].[OdemeTipi] ([OdemeTipi_ID], [OdemeTipi_Adi], [OdemeTipi_Status], [OdemeTipi_CreateDate]) VALUES (3, N'KREDİ KARTI', 1, NULL)
GO
SET IDENTITY_INSERT [dbo].[OdemeTipi] OFF
GO
SET IDENTITY_INSERT [dbo].[Servis] ON 
GO
INSERT [dbo].[Servis] ([Servis_ID], [Arac_ID], [Servis_ServisZamani], [ServisFirma_ID], [Servis_Notlar], [Servis_Ucreti], [Servis_CreateDate], [Servis_Status]) VALUES (1, 1, CAST(N'2020-01-01' AS Date), 1, N'DİKKAT ETSİNLER', 10000, NULL, 1)
GO
INSERT [dbo].[Servis] ([Servis_ID], [Arac_ID], [Servis_ServisZamani], [ServisFirma_ID], [Servis_Notlar], [Servis_Ucreti], [Servis_CreateDate], [Servis_Status]) VALUES (2, 2, CAST(N'2020-01-01' AS Date), 2, N'BUNA DA DİKKAT ETSİNLER', 1000, NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[Servis] OFF
GO
SET IDENTITY_INSERT [dbo].[ServisFirma] ON 
GO
INSERT [dbo].[ServisFirma] ([ServisFirma_ID], [ServisFirma_Adi], [ServisFirma_Adres1], [ServisFirma_Adres2], [ServisFirma_Tel1], [ServisFirma_Tel2], [ServisFirma_Email], [ServisFirma_Yetkili], [ServisFirma_CreateDate], [ServisFirma_Status]) VALUES (1, N'MERCEDES USTASI ', N'ISTANBUL', N'ISTANBUL', N'02123220099', N'02129990022', N'FİRMA@FİRMA.COM', N'TOLGA MERCEDESCİ', CAST(N'2020-11-24T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[ServisFirma] ([ServisFirma_ID], [ServisFirma_Adi], [ServisFirma_Adres1], [ServisFirma_Adres2], [ServisFirma_Tel1], [ServisFirma_Tel2], [ServisFirma_Email], [ServisFirma_Yetkili], [ServisFirma_CreateDate], [ServisFirma_Status]) VALUES (2, N'BMW USTASI', N'ISTANBUL', N'ISTANBIL', N'02123332211', N'02129932223', N'FİRMA@MİRMA.COM', N'FİRAT ALMAN EKOLÜ', CAST(N'2020-11-24T00:00:00.000' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[ServisFirma] OFF
GO
ALTER TABLE [dbo].[Arac] ADD  CONSTRAINT [DF_Arac_AracKlimaDurumu]  DEFAULT ((1)) FOR [AracKlimaDurumu]
GO
ALTER TABLE [dbo].[Arac] ADD  CONSTRAINT [DF_Arac_Arac_Status]  DEFAULT ((1)) FOR [Arac_Status]
GO
ALTER TABLE [dbo].[Arac] ADD  CONSTRAINT [DF_Arac_AracKiralamaDurumu]  DEFAULT ((0)) FOR [AracKiralamaDurumu]
GO
ALTER TABLE [dbo].[AracGrup] ADD  CONSTRAINT [DF_AracGrup_AracGrup_Status]  DEFAULT ((1)) FOR [AracGrup_Status]
GO
ALTER TABLE [dbo].[AracGrup] ADD  CONSTRAINT [DF_AracGrup_AracGrup_CreateDate]  DEFAULT (getdate()) FOR [AracGrup_CreateDate]
GO
ALTER TABLE [dbo].[AracKasaTipi] ADD  CONSTRAINT [DF_AracKasaTipi_AracKasaTipi_Status]  DEFAULT ((1)) FOR [AracKasaTipi_Status]
GO
ALTER TABLE [dbo].[AracKasaTipi] ADD  CONSTRAINT [DF_AracKasaTipi_AracKasaTipi_CreateDate]  DEFAULT (getdate()) FOR [AracKasaTipi_CreateDate]
GO
ALTER TABLE [dbo].[AracMarka] ADD  CONSTRAINT [DF_AracMarka_AracMarka_Status]  DEFAULT ((1)) FOR [AracMarka_Status]
GO
ALTER TABLE [dbo].[AracMarka] ADD  CONSTRAINT [DF_AracMarka_AracMarka_CreateDate]  DEFAULT (getdate()) FOR [AracMarka_CreateDate]
GO
ALTER TABLE [dbo].[AracModel] ADD  CONSTRAINT [DF_AracModel_AracModel_Status]  DEFAULT ((1)) FOR [AracModel_Status]
GO
ALTER TABLE [dbo].[AracRenk] ADD  CONSTRAINT [DF_AracRenk_AracRenk_Status]  DEFAULT ((1)) FOR [AracRenk_Status]
GO
ALTER TABLE [dbo].[AracYakitTuru] ADD  CONSTRAINT [DF_AracYakitTuru_AracYakitTuru_Status]  DEFAULT ((1)) FOR [AracYakitTuru_Status]
GO
ALTER TABLE [dbo].[AracYakitTuru] ADD  CONSTRAINT [DF_AracYakitTuru_AracYakitTuru_CreateDate]  DEFAULT (getdate()) FOR [AracYakitTuru_CreateDate]
GO
ALTER TABLE [dbo].[Cari] ADD  CONSTRAINT [DF_Cari_Cari_Cinsiyet]  DEFAULT ((1)) FOR [Cari_Cinsiyet]
GO
ALTER TABLE [dbo].[Cari] ADD  CONSTRAINT [DF_Cari_Cari_CreateDate]  DEFAULT (getdate()) FOR [Cari_CreateDate]
GO
ALTER TABLE [dbo].[CariSehir] ADD  CONSTRAINT [DF_CariSehir_CariSehir_Status]  DEFAULT ((1)) FOR [CariSehir_Status]
GO
ALTER TABLE [dbo].[CariSehir] ADD  CONSTRAINT [DF_CariSehir_CariSehir_CreateDate]  DEFAULT (getdate()) FOR [CariSehir_CreateDate]
GO
ALTER TABLE [dbo].[CariUyruk] ADD  CONSTRAINT [DF_CariUyruk_CariUyruk_Status]  DEFAULT ((1)) FOR [CariUyruk_Status]
GO
ALTER TABLE [dbo].[EhliyetSinif] ADD  CONSTRAINT [DF_EhliyetSinif_EhliyetSinif_Status]  DEFAULT ((1)) FOR [EhliyetSinif_Status]
GO
ALTER TABLE [dbo].[EhliyetSinif] ADD  CONSTRAINT [DF_EhliyetSinif_EhliyetSinif_CreateDate]  DEFAULT (getdate()) FOR [EhliyetSinif_CreateDate]
GO
ALTER TABLE [dbo].[EkstraHizmetler] ADD  CONSTRAINT [DF_EkstraHizmetler_EkstraHizmetler_Status]  DEFAULT ((1)) FOR [EkstraHizmetler_Status]
GO
ALTER TABLE [dbo].[Islem] ADD  CONSTRAINT [DF_Islem_Islem_Tipi]  DEFAULT ((1)) FOR [Islem_Tipi]
GO
ALTER TABLE [dbo].[Islem] ADD  CONSTRAINT [DF_Islem_Islem_IskontoOrani]  DEFAULT ((0)) FOR [Islem_IskontoOrani]
GO
ALTER TABLE [dbo].[Islem] ADD  CONSTRAINT [DF_Islem_Islem_Status]  DEFAULT ((1)) FOR [Islem_Status]
GO
ALTER TABLE [dbo].[KanGrubu] ADD  CONSTRAINT [DF_KanGrubu_KanGrubu_Status]  DEFAULT ((1)) FOR [KanGrubu_Status]
GO
ALTER TABLE [dbo].[KanGrubu] ADD  CONSTRAINT [DF_KanGrubu_KanGrubu_CreateDate]  DEFAULT (getdate()) FOR [KanGrubu_CreateDate]
GO
ALTER TABLE [dbo].[Kullanici] ADD  CONSTRAINT [DF_Kullanici_Kullanici_Status]  DEFAULT ((1)) FOR [Kullanici_Status]
GO
ALTER TABLE [dbo].[Kullanici] ADD  CONSTRAINT [DF_Kullanici_Kullanici_CreateDate]  DEFAULT (getdate()) FOR [Kullanici_CreateDate]
GO
ALTER TABLE [dbo].[Lokasyon] ADD  CONSTRAINT [DF_Table_2_Lokasyon_Tipi]  DEFAULT ((0)) FOR [Lokasyon_Tipi]
GO
ALTER TABLE [dbo].[Lokasyon] ADD  CONSTRAINT [DF_Table_2_Lokasyon_Status]  DEFAULT ((1)) FOR [Lokasyon_Status]
GO
ALTER TABLE [dbo].[Lokasyon] ADD  CONSTRAINT [DF_Table_2_Lokasyon_CreateDate]  DEFAULT (getdate()) FOR [Lokasyon_CreateDate]
GO
ALTER TABLE [dbo].[OdemeTipi] ADD  CONSTRAINT [DF_OdemeTipi_OdemeTipi_Status]  DEFAULT ((1)) FOR [OdemeTipi_Status]
GO
ALTER TABLE [dbo].[Servis] ADD  CONSTRAINT [DF_Servis_Servis_CreateDate]  DEFAULT (getdate()) FOR [Servis_CreateDate]
GO
ALTER TABLE [dbo].[ServisFirma] ADD  CONSTRAINT [DF_ServisFirma_ServisFirma_CreateDate]  DEFAULT (getdate()) FOR [ServisFirma_CreateDate]
GO
ALTER TABLE [dbo].[ServisFirma] ADD  CONSTRAINT [DF_ServisFirma_ServisFirma_Status]  DEFAULT ((1)) FOR [ServisFirma_Status]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1: Klimalı 0: Klimasız' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Arac', @level2type=N'COLUMN',@level2name=N'AracKlimaDurumu'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1: Aktif 0: Pasif' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Arac', @level2type=N'COLUMN',@level2name=N'Arac_Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0 :Boş 1: Müşteride 2: Pasif Araç 3: Arızalı/Serviste ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Arac', @level2type=N'COLUMN',@level2name=N'AracKiralamaDurumu'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1: Aktif 0: Pasif' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AracGrup', @level2type=N'COLUMN',@level2name=N'AracGrup_Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1: Aktif 0: Pasif' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AracKasaTipi', @level2type=N'COLUMN',@level2name=N'AracKasaTipi_Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1: Aktif 0 : Pasif' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AracMarka', @level2type=N'COLUMN',@level2name=N'AracMarka_Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1: Aktif 0: Pasif' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AracModel', @level2type=N'COLUMN',@level2name=N'AracModel_Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1: Aktif 0: Pasif' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AracRenk', @level2type=N'COLUMN',@level2name=N'AracRenk_Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1: Aktif 0 : Pasif' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AracYakitTuru', @level2type=N'COLUMN',@level2name=N'AracYakitTuru_Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'TC Kimlik ve Pasaport Numarası Girilebilir. Uyruk TC ise numara TC Kimlik numarasıdır.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Cari', @level2type=N'COLUMN',@level2name=N'Cari_IDNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1: Erkek 0: Kadın' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Cari', @level2type=N'COLUMN',@level2name=N'Cari_Cinsiyet'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1: Aktif 0: Pasif' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CariSehir', @level2type=N'COLUMN',@level2name=N'CariSehir_Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1: Aktif 0: Pasif' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CariUyruk', @level2type=N'COLUMN',@level2name=N'CariUyruk_Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1: Aktif 0: Pasif' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EhliyetSinif', @level2type=N'COLUMN',@level2name=N'EhliyetSinif_Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1: Aktif 0: Pasif' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EkstraHizmetler', @level2type=N'COLUMN',@level2name=N'EkstraHizmetler_Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1 : Rezervasyon 2: Kiralama ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Islem', @level2type=N'COLUMN',@level2name=N'Islem_Tipi'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1: Aktif 0: Pasif' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Islem', @level2type=N'COLUMN',@level2name=N'Islem_Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1: Aktif 0: Pasif' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KanGrubu', @level2type=N'COLUMN',@level2name=N'KanGrubu_Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1: Aktif 0: Pasif' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Kullanici', @level2type=N'COLUMN',@level2name=N'Kullanici_Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0 : Teslimat Lokasyonu 1: İade Lokasyonu 2: Her ikiside' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Lokasyon', @level2type=N'COLUMN',@level2name=N'Lokasyon_Tipi'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1: Aktif 0: Pasif' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Lokasyon', @level2type=N'COLUMN',@level2name=N'Lokasyon_Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1: Aktif 0: Pasif' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OdemeTipi', @level2type=N'COLUMN',@level2name=N'OdemeTipi_Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1: Aktif 0: Pasif' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ServisFirma', @level2type=N'COLUMN',@level2name=N'ServisFirma_Status'
GO
USE [master]
GO
ALTER DATABASE [AmicaRentDB] SET  READ_WRITE 
GO
