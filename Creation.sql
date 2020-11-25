USE [master]
GO
/****** Object:  Database [AmicaRentDB]    Script Date: 23.11.2020 20:40:17 ******/
CREATE DATABASE [AmicaRentDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AmicaRentDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\AmicaRentDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AmicaRentDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\AmicaRentDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
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
ALTER DATABASE [AmicaRentDB] SET QUERY_STORE = OFF
GO

USE [AmicaRentDB]
GO
/****** Object:  Table [dbo].[Arac]    Script Date: 24.11.2020 14:17:58 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AracGrup]    Script Date: 24.11.2020 14:17:58 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AracKasaTipi]    Script Date: 24.11.2020 14:17:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AracKasaTipi](
	[AracKasaTipi_ID] [int] IDENTITY(1,1) NOT NULL,
	[AracKasaTipi_Adi] [nvarchar](50) NULL,
	[AracKasaTipi_Status] [int] NULL,
	[AracKasaTipi_CreateDate] [datetime] NULL,
 CONSTRAINT [PK_AracKasaTipi] PRIMARY KEY CLUSTERED 
(
	[AracKasaTipi_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AracMarka]    Script Date: 24.11.2020 14:17:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AracMarka](
	[AracMarka_ID] [int] IDENTITY(1,1) NOT NULL,
	[AracMarka_Adi] [nvarchar](50) NULL,
	[AracMarka_Status] [int] NULL,
	[AracMarka_CreateDate] [datetime] NULL,
 CONSTRAINT [PK_AracMarka] PRIMARY KEY CLUSTERED 
(
	[AracMarka_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AracModel]    Script Date: 24.11.2020 14:17:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AracModel](
	[AracModel_ID] [int] IDENTITY(1,1) NOT NULL,
	[AracMarka_ID] [int] NOT NULL,
	[AracModel_Adi] [nvarchar](50) NOT NULL,
	[AracModel_Status] [int] NULL,
	[AracModel_CreateDate] [datetime] NULL,
 CONSTRAINT [PK_AracModel] PRIMARY KEY CLUSTERED 
(
	[AracModel_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AracRenk]    Script Date: 24.11.2020 14:17:58 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AracYakitTuru]    Script Date: 24.11.2020 14:17:58 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cari]    Script Date: 24.11.2020 14:17:58 ******/
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
 CONSTRAINT [PK_Cari] PRIMARY KEY CLUSTERED 
(
	[Cari_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CariEhliyet]    Script Date: 24.11.2020 14:17:58 ******/
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
 CONSTRAINT [PK_CariEhliyet] PRIMARY KEY CLUSTERED 
(
	[CariEhliyet_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CariSehir]    Script Date: 24.11.2020 14:17:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CariSehir](
	[CariSehir_ID] [int] IDENTITY(1,1) NOT NULL,
	[CariSehir_Adi] [nvarchar](50) NULL,
	[CariSehir_Status] [int] NULL,
	[CariSehir_CreateDate] [datetime] NULL,
 CONSTRAINT [PK_CariSehir] PRIMARY KEY CLUSTERED 
(
	[CariSehir_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CariUyruk]    Script Date: 24.11.2020 14:17:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CariUyruk](
	[CariUyruk_ID] [int] IDENTITY(1,1) NOT NULL,
	[CariUyruk_Adi] [nvarchar](50) NULL,
	[CariUyruk_Status] [int] NULL,
	[CariUyruk_CreateDate] [datetime] NULL,
 CONSTRAINT [PK_CariUyruk] PRIMARY KEY CLUSTERED 
(
	[CariUyruk_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EhliyetSinif]    Script Date: 24.11.2020 14:17:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EhliyetSinif](
	[EhliyetSinif_ID] [int] IDENTITY(1,1) NOT NULL,
	[EhliyetSinif_Adi] [nvarchar](50) NULL,
	[EhliyetSinif_Status] [int] NULL,
	[EhliyetSinif_CreateDate] [datetime] NULL,
 CONSTRAINT [PK_EhliyetSinif] PRIMARY KEY CLUSTERED 
(
	[EhliyetSinif_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EkstraHizmetler]    Script Date: 24.11.2020 14:17:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EkstraHizmetler](
	[EkstraHizmetler_ID] [int] IDENTITY(1,1) NOT NULL,
	[EkstraHizmetler_Adi] [nvarchar](50) NULL,
	[EkstraHizmetler_Ucreti] [float] NULL,
	[EkstraHizmetler_Status] [int] NULL,
	[EkstraHizmetler_CreateDate] [datetime] NULL,
 CONSTRAINT [PK_EkstraHizmetler] PRIMARY KEY CLUSTERED 
(
	[EkstraHizmetler_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EkSurucu]    Script Date: 24.11.2020 14:17:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EkSurucu](
	[EkSurucu_ID] [int] IDENTITY(1,1) NOT NULL,
	[Cari_ID] [int] NULL,
	[EkSurucu_CreateDate] [datetime] NULL,
 CONSTRAINT [PK_EkSurucu] PRIMARY KEY CLUSTERED 
(
	[EkSurucu_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Islem]    Script Date: 24.11.2020 14:17:58 ******/
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
	[Islem_Status] [int] NULL,
	[Islem_CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Islem] PRIMARY KEY CLUSTERED 
(
	[Islem_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IslemEkstraHizmetler]    Script Date: 24.11.2020 14:17:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IslemEkstraHizmetler](
	[IslemEkstraHizmetler_ID] [int] IDENTITY(1,1) NOT NULL,
	[Islem_ID] [int] NULL,
	[EkstraHizmetler_ID] [int] NULL,
	[IslemEkstraHizmetler_CreateDate] [datetime] NULL,
 CONSTRAINT [PK_IslemEkstraHizmetler] PRIMARY KEY CLUSTERED 
(
	[IslemEkstraHizmetler_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IslemTahsilat]    Script Date: 24.11.2020 14:17:58 ******/
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
 CONSTRAINT [PK_IslemTahsilat] PRIMARY KEY CLUSTERED 
(
	[IslemTahsilat_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KanGrubu]    Script Date: 24.11.2020 14:17:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KanGrubu](
	[KanGrubu_ID] [int] IDENTITY(1,1) NOT NULL,
	[KanGrubu_Adi] [nvarchar](50) NULL,
	[KanGrubu_Status] [int] NULL,
	[KanGrubu_CreateDate] [datetime] NULL,
 CONSTRAINT [PK_KanGrubu] PRIMARY KEY CLUSTERED 
(
	[KanGrubu_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kullanici]    Script Date: 24.11.2020 14:17:58 ******/
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
	[Kullanici_Status] [int] NULL,
	[Kullanici_CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Kullanici] PRIMARY KEY CLUSTERED 
(
	[Kullanici_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lokasyon]    Script Date: 24.11.2020 14:17:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lokasyon](
	[Lokasyon_ID] [int] IDENTITY(1,1) NOT NULL,
	[Lokasyon_Adi] [nvarchar](50) NULL,
	[Lokasyon_Tipi] [int] NULL,
	[Lokasyon_Status] [int] NULL,
	[Lokasyon_CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Table_2] PRIMARY KEY CLUSTERED 
(
	[Lokasyon_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OdemeTipi]    Script Date: 24.11.2020 14:17:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OdemeTipi](
	[OdemeTipi_ID] [int] IDENTITY(1,1) NOT NULL,
	[OdemeTipi_Adi] [nvarchar](50) NULL,
	[OdemeTipi_Status] [int] NULL,
	[OdemeTipi_CreateDate] [datetime] NULL,
 CONSTRAINT [PK_OdemeTipi] PRIMARY KEY CLUSTERED 
(
	[OdemeTipi_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Servis]    Script Date: 24.11.2020 14:17:58 ******/
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
 CONSTRAINT [PK_Servis] PRIMARY KEY CLUSTERED 
(
	[Servis_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServisFirma]    Script Date: 24.11.2020 14:17:58 ******/
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
	[ServisFirma_Status] [int] NULL,
 CONSTRAINT [PK_ServisFirma] PRIMARY KEY CLUSTERED 
(
	[ServisFirma_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Arac] ON 

INSERT [dbo].[Arac] ([Arac_ID], [AracGrup_ID], [AracMarka_ID], [AracModel_ID], [Arac_Yil], [AracYakitTuru_ID], [Arac_VitesTipi], [AracKasaTipi_ID], [AracKlimaDurumu], [AracPlakaNo], [AracGuncelKM], [AracMotorNo], [AracSaseNo], [AracRuhsatSeriNo], [Arac_Status], [AracRenk_ID], [AracKiralamaDurumu], [Arac_TrafikSigortasiBitisTarihi], [Arac_KaskoBitisTarihi], [Arac_KoltukSigortasiBitisTarihi], [Arac_FenniMuayeneGecerlilikTarihi]) VALUES (1, 1, 1, 1, N'2010', 1, N'OTOMATÝK  ', 3, 1, N'34 MGM 34', 23000, N'AS7488377 NM 123 000000 761772-A', N'212198237948374', N'A-343412', 1, 1, 0, CAST(N'2021-01-01' AS Date), CAST(N'2021-01-01' AS Date), CAST(N'2021-01-01' AS Date), CAST(N'2020-01-01' AS Date))
INSERT [dbo].[Arac] ([Arac_ID], [AracGrup_ID], [AracMarka_ID], [AracModel_ID], [Arac_Yil], [AracYakitTuru_ID], [Arac_VitesTipi], [AracKasaTipi_ID], [AracKlimaDurumu], [AracPlakaNo], [AracGuncelKM], [AracMotorNo], [AracSaseNo], [AracRuhsatSeriNo], [Arac_Status], [AracRenk_ID], [AracKiralamaDurumu], [Arac_TrafikSigortasiBitisTarihi], [Arac_KaskoBitisTarihi], [Arac_KoltukSigortasiBitisTarihi], [Arac_FenniMuayeneGecerlilikTarihi]) VALUES (2, 2, 1, 12, N'2012', 1, N'MANUEL    ', 5, 1, N'34 ABC 11', 110909, N'AS7488377 NM 123 000000 761772-A', N'212198237948374', N'A-343412', 1, 2, 0, CAST(N'2021-01-01' AS Date), CAST(N'2021-01-01' AS Date), CAST(N'2021-01-01' AS Date), CAST(N'2020-01-01' AS Date))
INSERT [dbo].[Arac] ([Arac_ID], [AracGrup_ID], [AracMarka_ID], [AracModel_ID], [Arac_Yil], [AracYakitTuru_ID], [Arac_VitesTipi], [AracKasaTipi_ID], [AracKlimaDurumu], [AracPlakaNo], [AracGuncelKM], [AracMotorNo], [AracSaseNo], [AracRuhsatSeriNo], [Arac_Status], [AracRenk_ID], [AracKiralamaDurumu], [Arac_TrafikSigortasiBitisTarihi], [Arac_KaskoBitisTarihi], [Arac_KoltukSigortasiBitisTarihi], [Arac_FenniMuayeneGecerlilikTarihi]) VALUES (3, 1, 2, 5, N'2019', 1, N'OTOMATÝK  ', 3, 1, N'34 ZSM 99', 10000, N'AS7488377 NM 123 000000 761772-A', N'212198237948374', N'A-343412', 1, 2, 0, CAST(N'2021-01-01' AS Date), CAST(N'2021-01-01' AS Date), CAST(N'2021-01-01' AS Date), CAST(N'2020-01-01' AS Date))
SET IDENTITY_INSERT [dbo].[Arac] OFF
GO
SET IDENTITY_INSERT [dbo].[AracGrup] ON 

INSERT [dbo].[AracGrup] ([AracGrup_ID], [AracGrup_Adi], [AracGrup_Status], [AracGrup_CreateDate]) VALUES (1, N'Lux Araç', 1, CAST(N'2020-11-24T13:12:01.307' AS DateTime))
INSERT [dbo].[AracGrup] ([AracGrup_ID], [AracGrup_Adi], [AracGrup_Status], [AracGrup_CreateDate]) VALUES (2, N'Ticari Araç', 1, CAST(N'2020-11-24T13:12:06.293' AS DateTime))
INSERT [dbo].[AracGrup] ([AracGrup_ID], [AracGrup_Adi], [AracGrup_Status], [AracGrup_CreateDate]) VALUES (3, N'Binek Araç', 1, CAST(N'2020-11-24T13:12:11.870' AS DateTime))
INSERT [dbo].[AracGrup] ([AracGrup_ID], [AracGrup_Adi], [AracGrup_Status], [AracGrup_CreateDate]) VALUES (4, N'StationWagon Araç', 1, CAST(N'2020-11-24T13:12:18.293' AS DateTime))
INSERT [dbo].[AracGrup] ([AracGrup_ID], [AracGrup_Adi], [AracGrup_Status], [AracGrup_CreateDate]) VALUES (5, N'Cabrio Araç', 1, CAST(N'2020-11-24T13:12:25.043' AS DateTime))
INSERT [dbo].[AracGrup] ([AracGrup_ID], [AracGrup_Adi], [AracGrup_Status], [AracGrup_CreateDate]) VALUES (6, N'Özel Þöförlü Araç', 1, CAST(N'2020-11-24T13:12:31.693' AS DateTime))
SET IDENTITY_INSERT [dbo].[AracGrup] OFF
GO
SET IDENTITY_INSERT [dbo].[AracKasaTipi] ON 

INSERT [dbo].[AracKasaTipi] ([AracKasaTipi_ID], [AracKasaTipi_Adi], [AracKasaTipi_Status], [AracKasaTipi_CreateDate]) VALUES (1, N'Sedan', 1, CAST(N'2020-11-24T13:20:56.853' AS DateTime))
INSERT [dbo].[AracKasaTipi] ([AracKasaTipi_ID], [AracKasaTipi_Adi], [AracKasaTipi_Status], [AracKasaTipi_CreateDate]) VALUES (2, N'Station Wagon', 1, CAST(N'2020-11-24T13:21:04.340' AS DateTime))
INSERT [dbo].[AracKasaTipi] ([AracKasaTipi_ID], [AracKasaTipi_Adi], [AracKasaTipi_Status], [AracKasaTipi_CreateDate]) VALUES (3, N'Hatchback', 1, CAST(N'2020-11-24T13:21:08.917' AS DateTime))
INSERT [dbo].[AracKasaTipi] ([AracKasaTipi_ID], [AracKasaTipi_Adi], [AracKasaTipi_Status], [AracKasaTipi_CreateDate]) VALUES (4, N'SUV', 1, CAST(N'2020-11-24T13:21:11.760' AS DateTime))
INSERT [dbo].[AracKasaTipi] ([AracKasaTipi_ID], [AracKasaTipi_Adi], [AracKasaTipi_Status], [AracKasaTipi_CreateDate]) VALUES (5, N'Minibüs', 1, CAST(N'2020-11-24T13:25:55.040' AS DateTime))
SET IDENTITY_INSERT [dbo].[AracKasaTipi] OFF
GO
SET IDENTITY_INSERT [dbo].[AracMarka] ON 

INSERT [dbo].[AracMarka] ([AracMarka_ID], [AracMarka_Adi], [AracMarka_Status], [AracMarka_CreateDate]) VALUES (1, N'Mercedes', 1, CAST(N'2020-11-24T13:12:57.213' AS DateTime))
INSERT [dbo].[AracMarka] ([AracMarka_ID], [AracMarka_Adi], [AracMarka_Status], [AracMarka_CreateDate]) VALUES (2, N'BMW', 1, CAST(N'2020-11-24T13:12:59.937' AS DateTime))
INSERT [dbo].[AracMarka] ([AracMarka_ID], [AracMarka_Adi], [AracMarka_Status], [AracMarka_CreateDate]) VALUES (3, N'Range Rover', 1, CAST(N'2020-11-24T13:13:05.447' AS DateTime))
INSERT [dbo].[AracMarka] ([AracMarka_ID], [AracMarka_Adi], [AracMarka_Status], [AracMarka_CreateDate]) VALUES (4, N'Mini', 1, CAST(N'2020-11-24T13:13:08.080' AS DateTime))
INSERT [dbo].[AracMarka] ([AracMarka_ID], [AracMarka_Adi], [AracMarka_Status], [AracMarka_CreateDate]) VALUES (5, N'Renault', 1, CAST(N'2020-11-24T13:13:11.973' AS DateTime))
INSERT [dbo].[AracMarka] ([AracMarka_ID], [AracMarka_Adi], [AracMarka_Status], [AracMarka_CreateDate]) VALUES (6, N'Masserati', 1, CAST(N'2020-11-24T13:13:18.123' AS DateTime))
INSERT [dbo].[AracMarka] ([AracMarka_ID], [AracMarka_Adi], [AracMarka_Status], [AracMarka_CreateDate]) VALUES (7, N'Ford', 1, CAST(N'2020-11-24T13:13:20.927' AS DateTime))
SET IDENTITY_INSERT [dbo].[AracMarka] OFF
GO
SET IDENTITY_INSERT [dbo].[AracModel] ON 

INSERT [dbo].[AracModel] ([AracModel_ID], [AracMarka_ID], [AracModel_Adi], [AracModel_Status], [AracModel_CreateDate]) VALUES (1, 1, N'SLK 200', 1, NULL)
INSERT [dbo].[AracModel] ([AracModel_ID], [AracMarka_ID], [AracModel_Adi], [AracModel_Status], [AracModel_CreateDate]) VALUES (2, 1, N'CLK 180', 1, NULL)
INSERT [dbo].[AracModel] ([AracModel_ID], [AracMarka_ID], [AracModel_Adi], [AracModel_Status], [AracModel_CreateDate]) VALUES (3, 1, N'SLS 500', 1, NULL)
INSERT [dbo].[AracModel] ([AracModel_ID], [AracMarka_ID], [AracModel_Adi], [AracModel_Status], [AracModel_CreateDate]) VALUES (4, 1, N'A 500', 1, NULL)
INSERT [dbo].[AracModel] ([AracModel_ID], [AracMarka_ID], [AracModel_Adi], [AracModel_Status], [AracModel_CreateDate]) VALUES (5, 2, N'318 CI', 1, NULL)
INSERT [dbo].[AracModel] ([AracModel_ID], [AracMarka_ID], [AracModel_Adi], [AracModel_Status], [AracModel_CreateDate]) VALUES (6, 2, N'316 D', 1, NULL)
INSERT [dbo].[AracModel] ([AracModel_ID], [AracMarka_ID], [AracModel_Adi], [AracModel_Status], [AracModel_CreateDate]) VALUES (7, 2, N'520 D', 1, NULL)
INSERT [dbo].[AracModel] ([AracModel_ID], [AracMarka_ID], [AracModel_Adi], [AracModel_Status], [AracModel_CreateDate]) VALUES (8, 4, N'Cooper S', 1, NULL)
INSERT [dbo].[AracModel] ([AracModel_ID], [AracMarka_ID], [AracModel_Adi], [AracModel_Status], [AracModel_CreateDate]) VALUES (9, 5, N'Egea 180', 1, NULL)
INSERT [dbo].[AracModel] ([AracModel_ID], [AracMarka_ID], [AracModel_Adi], [AracModel_Status], [AracModel_CreateDate]) VALUES (10, 6, N'XBox TDI', 1, NULL)
INSERT [dbo].[AracModel] ([AracModel_ID], [AracMarka_ID], [AracModel_Adi], [AracModel_Status], [AracModel_CreateDate]) VALUES (11, 7, N'Fiesta 1.2', 1, NULL)
INSERT [dbo].[AracModel] ([AracModel_ID], [AracMarka_ID], [AracModel_Adi], [AracModel_Status], [AracModel_CreateDate]) VALUES (12, 1, N'VÝTO M', 1, NULL)
SET IDENTITY_INSERT [dbo].[AracModel] OFF
GO
SET IDENTITY_INSERT [dbo].[AracRenk] ON 

INSERT [dbo].[AracRenk] ([AracRenk_ID], [AracRenk_Adi], [AracRenk_Status], [AracRenk_CreateDate]) VALUES (1, N'BEYAZ', 1, NULL)
INSERT [dbo].[AracRenk] ([AracRenk_ID], [AracRenk_Adi], [AracRenk_Status], [AracRenk_CreateDate]) VALUES (2, N'SIYAH', 1, NULL)
INSERT [dbo].[AracRenk] ([AracRenk_ID], [AracRenk_Adi], [AracRenk_Status], [AracRenk_CreateDate]) VALUES (3, N'KIRMIZI', 1, NULL)
INSERT [dbo].[AracRenk] ([AracRenk_ID], [AracRenk_Adi], [AracRenk_Status], [AracRenk_CreateDate]) VALUES (4, N'MAVÝ', 1, NULL)
INSERT [dbo].[AracRenk] ([AracRenk_ID], [AracRenk_Adi], [AracRenk_Status], [AracRenk_CreateDate]) VALUES (5, N'LACÝVERT', 1, NULL)
INSERT [dbo].[AracRenk] ([AracRenk_ID], [AracRenk_Adi], [AracRenk_Status], [AracRenk_CreateDate]) VALUES (6, N'SARI', 1, NULL)
INSERT [dbo].[AracRenk] ([AracRenk_ID], [AracRenk_Adi], [AracRenk_Status], [AracRenk_CreateDate]) VALUES (7, N'FÜME', 1, NULL)
SET IDENTITY_INSERT [dbo].[AracRenk] OFF
GO
SET IDENTITY_INSERT [dbo].[AracYakitTuru] ON 

INSERT [dbo].[AracYakitTuru] ([AracYakitTuru_ID], [AracYakitTuru_Adi], [AracYakitTuru_Status], [AracYakitTuru_CreateDate]) VALUES (1, N'Benzin', 1, CAST(N'2020-11-24T13:18:58.613' AS DateTime))
INSERT [dbo].[AracYakitTuru] ([AracYakitTuru_ID], [AracYakitTuru_Adi], [AracYakitTuru_Status], [AracYakitTuru_CreateDate]) VALUES (2, N'Diesel', 1, CAST(N'2020-11-24T13:19:01.383' AS DateTime))
INSERT [dbo].[AracYakitTuru] ([AracYakitTuru_ID], [AracYakitTuru_Adi], [AracYakitTuru_Status], [AracYakitTuru_CreateDate]) VALUES (3, N'Elektrik', 1, CAST(N'2020-11-24T13:19:05.033' AS DateTime))
SET IDENTITY_INSERT [dbo].[AracYakitTuru] OFF
GO
SET IDENTITY_INSERT [dbo].[Cari] ON 

INSERT [dbo].[Cari] ([Cari_ID], [Cari_AdSoyad], [Cari_UyrukID], [Cari_IDNumber], [Cari_Cinsiyet], [Cari_DogumTarihi], [Cari_EpostaAdresi], [Cari_Adres1], [Cari_Adres2], [CariSehir_ID], [Cari_MobilTelefon], [Cari_LokalTelefon], [Cari_CreateDate]) VALUES (1, N'TOLGA ALTAY', 1, N'22342160594', 1, CAST(N'1976-10-28' AS Date), N'tolga.altay@gmail.com', N'Istanbul', N'Istanbul', 2, N'905301175594', N'902122300909', CAST(N'2020-11-24T13:31:00.143' AS DateTime))
INSERT [dbo].[Cari] ([Cari_ID], [Cari_AdSoyad], [Cari_UyrukID], [Cari_IDNumber], [Cari_Cinsiyet], [Cari_DogumTarihi], [Cari_EpostaAdresi], [Cari_Adres1], [Cari_Adres2], [CariSehir_ID], [Cari_MobilTelefon], [Cari_LokalTelefon], [Cari_CreateDate]) VALUES (2, N'FIRAT ACIOÐLU', 1, N'50328787123', 1, CAST(N'1980-02-15' AS Date), N'firatacioglu@hotmail.com', N'Istanbul', N'Istanbul', 1, N'905393340909', N'903129008191', CAST(N'2020-11-24T13:31:47.773' AS DateTime))
INSERT [dbo].[Cari] ([Cari_ID], [Cari_AdSoyad], [Cari_UyrukID], [Cari_IDNumber], [Cari_Cinsiyet], [Cari_DogumTarihi], [Cari_EpostaAdresi], [Cari_Adres1], [Cari_Adres2], [CariSehir_ID], [Cari_MobilTelefon], [Cari_LokalTelefon], [Cari_CreateDate]) VALUES (3, N'MURAT YAPICI', 1, N'50328787123', 1, CAST(N'1980-02-15' AS Date), N'firatacioglu@hotmail.com', N'Istanbul', N'Istanbul', 1, N'905393340909', N'903129008191', CAST(N'2020-11-24T13:31:47.773' AS DateTime))
INSERT [dbo].[Cari] ([Cari_ID], [Cari_AdSoyad], [Cari_UyrukID], [Cari_IDNumber], [Cari_Cinsiyet], [Cari_DogumTarihi], [Cari_EpostaAdresi], [Cari_Adres1], [Cari_Adres2], [CariSehir_ID], [Cari_MobilTelefon], [Cari_LokalTelefon], [Cari_CreateDate]) VALUES (4, N'ÞEBNEM YARGILI', 1, N'92819920019', 2, CAST(N'1984-09-09' AS Date), N'sebnem@yargili.com', N'Istanbul', N'Istanbul', 1, N'905334009090', N'902165609911', CAST(N'2020-11-24T13:33:33.393' AS DateTime))
SET IDENTITY_INSERT [dbo].[Cari] OFF
GO
SET IDENTITY_INSERT [dbo].[CariSehir] ON 

INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (1, N'ANKARA', 1, CAST(N'2020-11-24T13:30:17.307' AS DateTime))
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (2, N'ISTANBUL', 1, CAST(N'2020-11-24T13:30:19.800' AS DateTime))
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (3, N'ÝZMÝR', 1, CAST(N'2020-11-24T13:30:22.210' AS DateTime))
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (4, N'ADANA', 1, CAST(N'2020-11-24T13:30:24.653' AS DateTime))
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (5, N'MERSÝN', 1, CAST(N'2020-11-24T13:30:27.590' AS DateTime))
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (6, N'BALIKESÝR', 1, CAST(N'2020-11-24T13:30:31.917' AS DateTime))
INSERT [dbo].[CariSehir] ([CariSehir_ID], [CariSehir_Adi], [CariSehir_Status], [CariSehir_CreateDate]) VALUES (7, N'TRABZON', 1, CAST(N'2020-11-24T13:30:35.970' AS DateTime))
SET IDENTITY_INSERT [dbo].[CariSehir] OFF
GO
SET IDENTITY_INSERT [dbo].[CariUyruk] ON 

INSERT [dbo].[CariUyruk] ([CariUyruk_ID], [CariUyruk_Adi], [CariUyruk_Status], [CariUyruk_CreateDate]) VALUES (1, N'TÜRKÝYE CUMHURÝYETÝ', 1, NULL)
INSERT [dbo].[CariUyruk] ([CariUyruk_ID], [CariUyruk_Adi], [CariUyruk_Status], [CariUyruk_CreateDate]) VALUES (2, N'AMERÝKA BÝRLEÞÝK DEVLETLERÝ', 1, NULL)
INSERT [dbo].[CariUyruk] ([CariUyruk_ID], [CariUyruk_Adi], [CariUyruk_Status], [CariUyruk_CreateDate]) VALUES (3, N'ALMANYA', 1, NULL)
INSERT [dbo].[CariUyruk] ([CariUyruk_ID], [CariUyruk_Adi], [CariUyruk_Status], [CariUyruk_CreateDate]) VALUES (4, N'FRANSA', 1, NULL)
INSERT [dbo].[CariUyruk] ([CariUyruk_ID], [CariUyruk_Adi], [CariUyruk_Status], [CariUyruk_CreateDate]) VALUES (5, N'ÜRDÜN', 1, NULL)
INSERT [dbo].[CariUyruk] ([CariUyruk_ID], [CariUyruk_Adi], [CariUyruk_Status], [CariUyruk_CreateDate]) VALUES (6, N'BÝRLEÞÝK KRALLIK', 1, NULL)
INSERT [dbo].[CariUyruk] ([CariUyruk_ID], [CariUyruk_Adi], [CariUyruk_Status], [CariUyruk_CreateDate]) VALUES (7, N'URUGUAY', 1, NULL)
INSERT [dbo].[CariUyruk] ([CariUyruk_ID], [CariUyruk_Adi], [CariUyruk_Status], [CariUyruk_CreateDate]) VALUES (8, N'UKRAYNA', 1, NULL)
INSERT [dbo].[CariUyruk] ([CariUyruk_ID], [CariUyruk_Adi], [CariUyruk_Status], [CariUyruk_CreateDate]) VALUES (9, N'MONTENEGRO', 1, NULL)
SET IDENTITY_INSERT [dbo].[CariUyruk] OFF
GO
SET IDENTITY_INSERT [dbo].[EhliyetSinif] ON 

INSERT [dbo].[EhliyetSinif] ([EhliyetSinif_ID], [EhliyetSinif_Adi], [EhliyetSinif_Status], [EhliyetSinif_CreateDate]) VALUES (1, N'A', 1, CAST(N'2020-11-24T13:34:52.030' AS DateTime))
INSERT [dbo].[EhliyetSinif] ([EhliyetSinif_ID], [EhliyetSinif_Adi], [EhliyetSinif_Status], [EhliyetSinif_CreateDate]) VALUES (2, N'C1', 1, CAST(N'2020-11-24T13:35:02.217' AS DateTime))
INSERT [dbo].[EhliyetSinif] ([EhliyetSinif_ID], [EhliyetSinif_Adi], [EhliyetSinif_Status], [EhliyetSinif_CreateDate]) VALUES (3, N'C', 1, CAST(N'2020-11-24T13:35:04.133' AS DateTime))
INSERT [dbo].[EhliyetSinif] ([EhliyetSinif_ID], [EhliyetSinif_Adi], [EhliyetSinif_Status], [EhliyetSinif_CreateDate]) VALUES (4, N'D1', 1, CAST(N'2020-11-24T13:35:09.950' AS DateTime))
INSERT [dbo].[EhliyetSinif] ([EhliyetSinif_ID], [EhliyetSinif_Adi], [EhliyetSinif_Status], [EhliyetSinif_CreateDate]) VALUES (5, N'D', 1, CAST(N'2020-11-24T13:35:11.560' AS DateTime))
INSERT [dbo].[EhliyetSinif] ([EhliyetSinif_ID], [EhliyetSinif_Adi], [EhliyetSinif_Status], [EhliyetSinif_CreateDate]) VALUES (6, N'BE', 1, CAST(N'2020-11-24T13:35:15.903' AS DateTime))
INSERT [dbo].[EhliyetSinif] ([EhliyetSinif_ID], [EhliyetSinif_Adi], [EhliyetSinif_Status], [EhliyetSinif_CreateDate]) VALUES (7, N'CE', 1, CAST(N'2020-11-24T13:35:17.653' AS DateTime))
INSERT [dbo].[EhliyetSinif] ([EhliyetSinif_ID], [EhliyetSinif_Adi], [EhliyetSinif_Status], [EhliyetSinif_CreateDate]) VALUES (8, N'C1E', 1, CAST(N'2020-11-24T13:35:23.747' AS DateTime))
SET IDENTITY_INSERT [dbo].[EhliyetSinif] OFF
GO
SET IDENTITY_INSERT [dbo].[EkstraHizmetler] ON 

INSERT [dbo].[EkstraHizmetler] ([EkstraHizmetler_ID], [EkstraHizmetler_Adi], [EkstraHizmetler_Ucreti], [EkstraHizmetler_Status], [EkstraHizmetler_CreateDate]) VALUES (1, N'BEBEK KOLTUÐU', 45, 1, NULL)
INSERT [dbo].[EkstraHizmetler] ([EkstraHizmetler_ID], [EkstraHizmetler_Adi], [EkstraHizmetler_Ucreti], [EkstraHizmetler_Status], [EkstraHizmetler_CreateDate]) VALUES (2, N'CD ÇALAR', 19, 1, NULL)
INSERT [dbo].[EkstraHizmetler] ([EkstraHizmetler_ID], [EkstraHizmetler_Adi], [EkstraHizmetler_Ucreti], [EkstraHizmetler_Status], [EkstraHizmetler_CreateDate]) VALUES (3, N'ÝLAVE SOFOR', 145, 1, NULL)
INSERT [dbo].[EkstraHizmetler] ([EkstraHizmetler_ID], [EkstraHizmetler_Adi], [EkstraHizmetler_Ucreti], [EkstraHizmetler_Status], [EkstraHizmetler_CreateDate]) VALUES (4, N'VALE HÝZMETLERÝ', 100, 1, NULL)
INSERT [dbo].[EkstraHizmetler] ([EkstraHizmetler_ID], [EkstraHizmetler_Adi], [EkstraHizmetler_Ucreti], [EkstraHizmetler_Status], [EkstraHizmetler_CreateDate]) VALUES (5, N'DÝGER HÝZMETLER', 60, 1, NULL)
INSERT [dbo].[EkstraHizmetler] ([EkstraHizmetler_ID], [EkstraHizmetler_Adi], [EkstraHizmetler_Ucreti], [EkstraHizmetler_Status], [EkstraHizmetler_CreateDate]) VALUES (6, N'BEDELSÝZ', 0, 1, NULL)
SET IDENTITY_INSERT [dbo].[EkstraHizmetler] OFF
GO
SET IDENTITY_INSERT [dbo].[EkSurucu] ON 

INSERT [dbo].[EkSurucu] ([EkSurucu_ID], [Cari_ID], [EkSurucu_CreateDate]) VALUES (1, 1, NULL)
INSERT [dbo].[EkSurucu] ([EkSurucu_ID], [Cari_ID], [EkSurucu_CreateDate]) VALUES (2, 2, NULL)
INSERT [dbo].[EkSurucu] ([EkSurucu_ID], [Cari_ID], [EkSurucu_CreateDate]) VALUES (3, 3, NULL)
INSERT [dbo].[EkSurucu] ([EkSurucu_ID], [Cari_ID], [EkSurucu_CreateDate]) VALUES (4, 4, NULL)
SET IDENTITY_INSERT [dbo].[EkSurucu] OFF
GO
SET IDENTITY_INSERT [dbo].[Islem] ON 

INSERT [dbo].[Islem] ([Islem_ID], [Islem_Tipi], [Cari_ID], [Arac_ID], [Islem_BaslangicTarihi], [Islem_BitisTarihi], [Islem_IlkKM], [Islem_SonKM], [Islem_YakitDurumu], [Islem_TeslimatLokasyonID], [Islem_IadeLokasyonID], [Islem_GunlukUcret], [Islem_GunlukKMSiniri], [Islem_ToplamKiralamaUcreti], [Islem_ToplamKMAsimUcreti], [Islem_ToplamEkstraHizmetler], [Islem_ToplamValeHizmetleri], [Islem_ToplamDigerUcretler], [Islem_IskontoOrani], [Islem_TahsilEdilen], [Islem_KalanBorc], [Islem_Status], [Islem_CreateDate]) VALUES (1, 1, 1, 1, CAST(N'2020-11-24T00:00:00.000' AS DateTime), CAST(N'2020-11-26T00:00:00.000' AS DateTime), 29000, 29700, 50, 1, 1, 1000, 100, 2000, 0, 0, 0, 0, 0, 0, 2000, 1, NULL)
INSERT [dbo].[Islem] ([Islem_ID], [Islem_Tipi], [Cari_ID], [Arac_ID], [Islem_BaslangicTarihi], [Islem_BitisTarihi], [Islem_IlkKM], [Islem_SonKM], [Islem_YakitDurumu], [Islem_TeslimatLokasyonID], [Islem_IadeLokasyonID], [Islem_GunlukUcret], [Islem_GunlukKMSiniri], [Islem_ToplamKiralamaUcreti], [Islem_ToplamKMAsimUcreti], [Islem_ToplamEkstraHizmetler], [Islem_ToplamValeHizmetleri], [Islem_ToplamDigerUcretler], [Islem_IskontoOrani], [Islem_TahsilEdilen], [Islem_KalanBorc], [Islem_Status], [Islem_CreateDate]) VALUES (2, 1, 2, 2, CAST(N'2020-11-24T00:00:00.000' AS DateTime), CAST(N'2020-11-26T00:00:00.000' AS DateTime), 29000, 29700, 50, 1, 1, 1000, 100, 2000, 0, 0, 0, 0, 0, 0, 2000, 1, NULL)
INSERT [dbo].[Islem] ([Islem_ID], [Islem_Tipi], [Cari_ID], [Arac_ID], [Islem_BaslangicTarihi], [Islem_BitisTarihi], [Islem_IlkKM], [Islem_SonKM], [Islem_YakitDurumu], [Islem_TeslimatLokasyonID], [Islem_IadeLokasyonID], [Islem_GunlukUcret], [Islem_GunlukKMSiniri], [Islem_ToplamKiralamaUcreti], [Islem_ToplamKMAsimUcreti], [Islem_ToplamEkstraHizmetler], [Islem_ToplamValeHizmetleri], [Islem_ToplamDigerUcretler], [Islem_IskontoOrani], [Islem_TahsilEdilen], [Islem_KalanBorc], [Islem_Status], [Islem_CreateDate]) VALUES (3, 1, 3, 3, CAST(N'2020-11-24T00:00:00.000' AS DateTime), CAST(N'2020-11-26T00:00:00.000' AS DateTime), 29000, 29700, 50, 1, 1, 1000, 100, 2000, 0, 0, 0, 0, 0, 0, 2000, 1, NULL)
INSERT [dbo].[Islem] ([Islem_ID], [Islem_Tipi], [Cari_ID], [Arac_ID], [Islem_BaslangicTarihi], [Islem_BitisTarihi], [Islem_IlkKM], [Islem_SonKM], [Islem_YakitDurumu], [Islem_TeslimatLokasyonID], [Islem_IadeLokasyonID], [Islem_GunlukUcret], [Islem_GunlukKMSiniri], [Islem_ToplamKiralamaUcreti], [Islem_ToplamKMAsimUcreti], [Islem_ToplamEkstraHizmetler], [Islem_ToplamValeHizmetleri], [Islem_ToplamDigerUcretler], [Islem_IskontoOrani], [Islem_TahsilEdilen], [Islem_KalanBorc], [Islem_Status], [Islem_CreateDate]) VALUES (4, 1, 4, 4, CAST(N'2020-11-24T00:00:00.000' AS DateTime), CAST(N'2020-11-26T00:00:00.000' AS DateTime), 29000, 29700, 50, 1, 1, 1000, 100, 2000, 0, 0, 0, 0, 0, 0, 2000, 1, NULL)
SET IDENTITY_INSERT [dbo].[Islem] OFF
GO
SET IDENTITY_INSERT [dbo].[Lokasyon] ON 

INSERT [dbo].[Lokasyon] ([Lokasyon_ID], [Lokasyon_Adi], [Lokasyon_Tipi], [Lokasyon_Status], [Lokasyon_CreateDate]) VALUES (1, N'AVRUPA YAKASI TESLÝMAT MERKEZÝ', 0, 1, CAST(N'2020-11-24T14:05:19.860' AS DateTime))
INSERT [dbo].[Lokasyon] ([Lokasyon_ID], [Lokasyon_Adi], [Lokasyon_Tipi], [Lokasyon_Status], [Lokasyon_CreateDate]) VALUES (2, N'ANADOLU YAKASI TESLÝMAT MERKEZÝ', 0, 1, CAST(N'2020-11-24T14:05:26.793' AS DateTime))
INSERT [dbo].[Lokasyon] ([Lokasyon_ID], [Lokasyon_Adi], [Lokasyon_Tipi], [Lokasyon_Status], [Lokasyon_CreateDate]) VALUES (3, N'SABÝHA GÖKÇEN HAVALÝMANI TESLÝMAT BÖLGESÝ', 0, 1, CAST(N'2020-11-24T14:05:38.900' AS DateTime))
INSERT [dbo].[Lokasyon] ([Lokasyon_ID], [Lokasyon_Adi], [Lokasyon_Tipi], [Lokasyon_Status], [Lokasyon_CreateDate]) VALUES (4, N'ÝSTANBUL HAVALÝMANI TESLÝMAT BÖLGESÝ', 0, 1, CAST(N'2020-11-24T14:05:50.630' AS DateTime))
SET IDENTITY_INSERT [dbo].[Lokasyon] OFF
GO
SET IDENTITY_INSERT [dbo].[OdemeTipi] ON 

INSERT [dbo].[OdemeTipi] ([OdemeTipi_ID], [OdemeTipi_Adi], [OdemeTipi_Status], [OdemeTipi_CreateDate]) VALUES (1, N'NAKÝT', 1, NULL)
INSERT [dbo].[OdemeTipi] ([OdemeTipi_ID], [OdemeTipi_Adi], [OdemeTipi_Status], [OdemeTipi_CreateDate]) VALUES (2, N'BANKA HAVALE', 1, NULL)
INSERT [dbo].[OdemeTipi] ([OdemeTipi_ID], [OdemeTipi_Adi], [OdemeTipi_Status], [OdemeTipi_CreateDate]) VALUES (3, N'KREDÝ KARTI', 1, NULL)
SET IDENTITY_INSERT [dbo].[OdemeTipi] OFF
GO
SET IDENTITY_INSERT [dbo].[Servis] ON 

INSERT [dbo].[Servis] ([Servis_ID], [Arac_ID], [Servis_ServisZamani], [ServisFirma_ID], [Servis_Notlar], [Servis_Ucreti], [Servis_CreateDate]) VALUES (1, 1, CAST(N'2020-01-01' AS Date), 1, N'DÝKKAT ETSÝNLER', 10000, NULL)
INSERT [dbo].[Servis] ([Servis_ID], [Arac_ID], [Servis_ServisZamani], [ServisFirma_ID], [Servis_Notlar], [Servis_Ucreti], [Servis_CreateDate]) VALUES (2, 2, CAST(N'2020-01-01' AS Date), 2, N'BUNA DA DÝKKAT ETSÝNLER', 1000, NULL)
SET IDENTITY_INSERT [dbo].[Servis] OFF
GO
SET IDENTITY_INSERT [dbo].[ServisFirma] ON 

INSERT [dbo].[ServisFirma] ([ServisFirma_ID], [ServisFirma_Adi], [ServisFirma_Adres1], [ServisFirma_Adres2], [ServisFirma_Tel1], [ServisFirma_Tel2], [ServisFirma_Email], [ServisFirma_Yetkili], [ServisFirma_CreateDate], [ServisFirma_Status]) VALUES (1, N'MERCEDES USTASI ', N'ISTANBUL', N'ISTANBUL', N'02123220099', N'02129990022', N'FÝRMA@FÝRMA.COM', N'TOLGA MERCEDESCÝ', CAST(N'2020-11-24T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[ServisFirma] ([ServisFirma_ID], [ServisFirma_Adi], [ServisFirma_Adres1], [ServisFirma_Adres2], [ServisFirma_Tel1], [ServisFirma_Tel2], [ServisFirma_Email], [ServisFirma_Yetkili], [ServisFirma_CreateDate], [ServisFirma_Status]) VALUES (2, N'BMW USTASI', N'ISTANBUL', N'ISTANBIL', N'02123332211', N'02129932223', N'FÝRMA@MÝRMA.COM', N'FÝRAT ALMAN EKOLÜ', CAST(N'2020-11-24T00:00:00.000' AS DateTime), 1)
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1: Klimalý 0: Klimasýz' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Arac', @level2type=N'COLUMN',@level2name=N'AracKlimaDurumu'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1: Aktif 0: Pasif' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Arac', @level2type=N'COLUMN',@level2name=N'Arac_Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0 :Boþ 1: Müþteride 2: Pasif Araç 3: Arýzalý/Serviste ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Arac', @level2type=N'COLUMN',@level2name=N'AracKiralamaDurumu'
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'TC Kimlik ve Pasaport Numarasý Girilebilir. Uyruk TC ise numara TC Kimlik numarasýdýr.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Cari', @level2type=N'COLUMN',@level2name=N'Cari_IDNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1: Erkek 0: Kadýn' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Cari', @level2type=N'COLUMN',@level2name=N'Cari_Cinsiyet'
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0 : Teslimat Lokasyonu 1: Ýade Lokasyonu 2: Her ikiside' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Lokasyon', @level2type=N'COLUMN',@level2name=N'Lokasyon_Tipi'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1: Aktif 0: Pasif' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Lokasyon', @level2type=N'COLUMN',@level2name=N'Lokasyon_Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1: Aktif 0: Pasif' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OdemeTipi', @level2type=N'COLUMN',@level2name=N'OdemeTipi_Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1: Aktif 0: Pasif' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ServisFirma', @level2type=N'COLUMN',@level2name=N'ServisFirma_Status'
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[viewAracList]
AS
SELECT        dbo.Arac.Arac_ID, dbo.AracGrup.AracGrup_Adi, dbo.AracMarka.AracMarka_Adi, dbo.AracModel.AracModel_Adi, dbo.Arac.Arac_Yil, dbo.AracYakitTuru.AracYakitTuru_Adi, dbo.Arac.Arac_VitesTipi, 
                         dbo.AracKasaTipi.AracKasaTipi_Adi, CASE WHEN dbo.Arac.AracKlimaDurumu = 1 THEN 'Klimalý' ELSE 'Klimasýz' END AS KlimaDurumu, dbo.Arac.AracPlakaNo, dbo.Arac.AracGuncelKM, dbo.Arac.AracMotorNo, 
                         dbo.Arac.AracSaseNo, dbo.Arac.AracRuhsatSeriNo, dbo.AracRenk.AracRenk_Adi, 
                         CASE WHEN dbo.Arac.AracKiralamaDurumu = 0 THEN 'Boþta' WHEN dbo.Arac.AracKiralamaDurumu = 1 THEN 'Müþteride' WHEN dbo.Arac.AracKiralamaDurumu = 2 THEN 'Pasif Araç' WHEN dbo.Arac.AracKiralamaDurumu = 3 THEN
                          'Arýzalý/Serviste' END AS KiralamaDurumu, dbo.Arac.Arac_TrafikSigortasiBitisTarihi, dbo.Arac.Arac_KaskoBitisTarihi, dbo.Arac.Arac_KoltukSigortasiBitisTarihi, dbo.Arac.Arac_FenniMuayeneGecerlilikTarihi
FROM            dbo.Arac INNER JOIN
                         dbo.AracGrup ON dbo.Arac.AracGrup_ID = dbo.AracGrup.AracGrup_ID INNER JOIN
                         dbo.AracKasaTipi ON dbo.Arac.AracKasaTipi_ID = dbo.AracKasaTipi.AracKasaTipi_ID INNER JOIN
                         dbo.AracMarka ON dbo.Arac.AracMarka_ID = dbo.AracMarka.AracMarka_ID INNER JOIN
                         dbo.AracModel ON dbo.Arac.AracModel_ID = dbo.AracModel.AracModel_ID INNER JOIN
                         dbo.AracRenk ON dbo.Arac.AracRenk_ID = dbo.AracRenk.AracRenk_ID INNER JOIN
                         dbo.AracYakitTuru ON dbo.Arac.AracYakitTuru_ID = dbo.AracYakitTuru.AracYakitTuru_ID
GO
/****** Object:  View [dbo].[viewIslem]    Script Date: 25.11.2020 18:53:07 ******/
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
/****** Object:  View [dbo].[viewServis]    Script Date: 25.11.2020 18:53:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[viewServis]
AS
SELECT        dbo.Servis.Servis_ID, dbo.viewAracList.AracGrup_Adi, dbo.viewAracList.AracMarka_Adi, dbo.viewAracList.AracModel_Adi, dbo.viewAracList.Arac_Yil, dbo.viewAracList.AracPlakaNo, dbo.Servis.Servis_ServisZamani, 
                         dbo.ServisFirma.ServisFirma_Adi, dbo.Servis.Servis_Notlar, dbo.Servis.Servis_Ucreti
FROM            dbo.Servis INNER JOIN
                         dbo.ServisFirma ON dbo.Servis.ServisFirma_ID = dbo.ServisFirma.ServisFirma_ID INNER JOIN
                         dbo.viewAracList ON dbo.Servis.Arac_ID = dbo.viewAracList.Arac_ID
GO
/****** Object:  View [dbo].[viewAracModel]    Script Date: 25.11.2020 18:53:07 ******/
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
/****** Object:  View [dbo].[viewCari]    Script Date: 25.11.2020 18:53:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[viewCari]
AS
SELECT        dbo.Cari.Cari_ID, dbo.Cari.Cari_AdSoyad, dbo.CariUyruk.CariUyruk_Adi, dbo.Cari.Cari_IDNumber, CASE WHEN dbo.Cari.Cari_Cinsiyet = 1 THEN 'Erkek' ELSE 'Kadýn' END AS 'Cinsiyet', dbo.Cari.Cari_DogumTarihi, 
                         dbo.Cari.Cari_EpostaAdresi, dbo.Cari.Cari_Adres1, dbo.Cari.Cari_Adres2, dbo.CariSehir.CariSehir_Adi, dbo.Cari.Cari_MobilTelefon, dbo.Cari.Cari_LokalTelefon, dbo.Cari.Cari_CreateDate
FROM            dbo.Cari INNER JOIN
                         dbo.CariSehir ON dbo.Cari.CariSehir_ID = dbo.CariSehir.CariSehir_ID INNER JOIN
                         dbo.CariUyruk ON dbo.Cari.Cari_UyrukID = dbo.CariUyruk.CariUyruk_ID
GO
/****** Object:  View [dbo].[viewCariEhliyet]    Script Date: 25.11.2020 18:53:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[viewCariEhliyet]
AS
SELECT        dbo.CariEhliyet.CariEhliyet_ID, dbo.CariEhliyet.Cari_ID, dbo.Cari.Cari_AdSoyad, dbo.CariEhliyet.CariEhliyet_VerilisTarihi, dbo.CariEhliyet.CariEhliyet_GecerlilikTarihi, dbo.CariEhliyet.CariEhliyet_DogumYeri, 
                         dbo.CariEhliyet.CariEhliyet_EhliyetNumarasi, dbo.EhliyetSinif.EhliyetSinif_Adi, dbo.KanGrubu.KanGrubu_Adi
FROM            dbo.CariEhliyet INNER JOIN
                         dbo.Cari ON dbo.CariEhliyet.Cari_ID = dbo.Cari.Cari_ID INNER JOIN
                         dbo.EhliyetSinif ON dbo.CariEhliyet.EhliyetSinif_ID = dbo.EhliyetSinif.EhliyetSinif_ID INNER JOIN
                         dbo.KanGrubu ON dbo.CariEhliyet.KanGrubu_ID = dbo.KanGrubu.KanGrubu_ID
GO




USE [master]
GO
ALTER DATABASE [AmicaRentDB] SET  READ_WRITE 
GO
