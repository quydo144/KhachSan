USE [master]
GO
/****** Object:  Database [KhachSan]    Script Date: 07/12/2019 10:32:41 ******/
CREATE DATABASE [KhachSan]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'KhachSan', FILENAME = N'E:\Data\KhachSan.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'KhachSan_log', FILENAME = N'E:\Data\KhachSan_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [KhachSan] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [KhachSan].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [KhachSan] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [KhachSan] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [KhachSan] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [KhachSan] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [KhachSan] SET ARITHABORT OFF 
GO
ALTER DATABASE [KhachSan] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [KhachSan] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [KhachSan] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [KhachSan] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [KhachSan] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [KhachSan] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [KhachSan] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [KhachSan] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [KhachSan] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [KhachSan] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [KhachSan] SET  DISABLE_BROKER 
GO
ALTER DATABASE [KhachSan] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [KhachSan] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [KhachSan] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [KhachSan] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [KhachSan] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [KhachSan] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [KhachSan] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [KhachSan] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [KhachSan] SET  MULTI_USER 
GO
ALTER DATABASE [KhachSan] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [KhachSan] SET DB_CHAINING OFF 
GO
ALTER DATABASE [KhachSan] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [KhachSan] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [KhachSan]
GO
/****** Object:  UserDefinedFunction [dbo].[AUTO_IDDoan]    Script Date: 07/12/2019 10:32:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[AUTO_IDDoan]()
RETURNS NVARCHAR(20)
AS
BEGIN
	DECLARE @ID NVARCHAR(20)
	DECLARE @length int
	IF (SELECT COUNT(maDoan) FROM Doan) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = convert(int,MAX(right(maDoan,6))) FROM Doan
		set @length=len(@ID)
		 select @ID= case
				when @length=1 and @ID<9 then 'D00000' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				when @ID=9 then 'D0000' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				when (@ID>9 and @length=2) and (@length=2 and @ID<99) then 'D0000' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				when @ID=99 then 'D000' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				when (@ID>99 and @length=3) and (@length=3 and @ID<999) then 'D000' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				when @ID=999 then 'D00' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				when (@ID>999 and @length=4) and(@length=4 and @ID<9999) then 'D00' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				when @ID=9999 then 'D0' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				when (@ID>9999 and @length=5) and (@length=5 and @ID<99999) then 'D0' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				when (@ID>99999 and @length=6) and (@length=6 and @ID<999999) then 'D' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)

			end
	RETURN @ID
END

GO
/****** Object:  UserDefinedFunction [dbo].[AUTO_IDDV]    Script Date: 07/12/2019 10:32:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[AUTO_IDDV]()
RETURNS NVARCHAR(8)
AS
BEGIN
	DECLARE @ID NVARCHAR(8)
	DECLARE @length int
	IF (SELECT COUNT(maDV) FROM DichVu) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = convert(int,MAX(right(maDV,6))) FROM DichVu
		set @length=len(@ID)
		 select @ID= case
				when @length=1 and @ID<9 then 'DV00000' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				when @ID=9 then 'DV0000' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				when (@ID>9 and @length=2) and (@length=2 and @ID<99) then 'DV0000' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				when @ID=99 then 'DV000' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				when (@ID>99 and @length=3) and (@length=3 and @ID<999) then 'KH000' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				when @ID=999 then 'DV00' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				when (@ID>999 and @length=4) and(@length=4 and @ID<9999) then 'DV00' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				when @ID=9999 then 'DV0' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				when (@ID>9999 and @length=5) and (@length=5 and @ID<99999) then 'DV0' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				when (@ID>99999 and @length=6) and (@length=6 and @ID<999999) then 'DV' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)

			end
	RETURN @ID
END
GO
/****** Object:  UserDefinedFunction [dbo].[AUTO_IDHDDV]    Script Date: 07/12/2019 10:32:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[AUTO_IDHDDV]()
RETURNS nvarchar(10)
AS
BEGIN
	DECLARE @ID nvarchar(10)
	DECLARE @length int
	IF (SELECT COUNT(maHDDV) FROM HoaDonDichVu) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = convert(int,MAX(right(maHDDV,6))) FROM HoaDonDichVu
		set @length=len(@ID)
		 select @ID= case
				when @length=1 and @ID<9 then 'HDTP00000' +CONVERT(nvarchar(10), CONVERT(INT, @ID) + 1)
				when @ID=9 then 'HDTP0000' +CONVERT(nvarchar(10), CONVERT(INT, @ID) + 1)
				when (@ID>9 and @length=2) and (@length=2 and @ID<99) then 'HDTP0000' +CONVERT(nvarchar(10), CONVERT(INT, @ID) + 1)
				when @ID=99 then 'HDTP000' +CONVERT(nvarchar(10), CONVERT(INT, @ID) + 1)
				when (@ID>99 and @length=3) and (@length=3 and @ID<999) then 'HDTP000' +CONVERT(nvarchar(10), CONVERT(INT, @ID) + 1)
				when @ID=999 then 'HDTP00' +CONVERT(nvarchar(10), CONVERT(INT, @ID) + 1)
				when (@ID>999 and @length=4) and(@length=4 and @ID<9999) then 'HDTP00' +CONVERT(nvarchar(10), CONVERT(INT, @ID) + 1)
				when @ID=9999 then 'HDTP0' +CONVERT(nvarchar(10), CONVERT(INT, @ID) + 1)
				when (@ID>9999 and @length=5) and (@length=5 and @ID<99999) then 'HDTP0' +CONVERT(nvarchar(10), CONVERT(INT, @ID) + 1)
				when (@ID>99999 and @length=6) and (@length=6 and @ID<999999) then 'HDTP' +CONVERT(nvarchar(10), CONVERT(INT, @ID) + 1)

			end
	RETURN @ID
END

GO
/****** Object:  UserDefinedFunction [dbo].[AUTO_IDHDTP]    Script Date: 07/12/2019 10:32:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[AUTO_IDHDTP]()
RETURNS nvarchar(10)
AS
BEGIN
	DECLARE @ID nvarchar(10)
	DECLARE @length int
	IF (SELECT COUNT(maHDPhong) FROM HoaDonTienPhong) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = convert(int,MAX(right(maHDPhong,6))) FROM HoaDonTienPhong
		set @length=len(@ID)
		 select @ID= case
				when @length=1 and @ID<9 then 'HDTP00000' +CONVERT(nvarchar(10), CONVERT(INT, @ID) + 1)
				when @ID=9 then 'HDTP0000' +CONVERT(nvarchar(10), CONVERT(INT, @ID) + 1)
				when (@ID>9 and @length=2) and (@length=2 and @ID<99) then 'HDTP0000' +CONVERT(nvarchar(10), CONVERT(INT, @ID) + 1)
				when @ID=99 then 'HDTP000' +CONVERT(nvarchar(10), CONVERT(INT, @ID) + 1)
				when (@ID>99 and @length=3) and (@length=3 and @ID<999) then 'HDTP000' +CONVERT(nvarchar(10), CONVERT(INT, @ID) + 1)
				when @ID=999 then 'HDTP00' +CONVERT(nvarchar(10), CONVERT(INT, @ID) + 1)
				when (@ID>999 and @length=4) and(@length=4 and @ID<9999) then 'HDTP00' +CONVERT(nvarchar(10), CONVERT(INT, @ID) + 1)
				when @ID=9999 then 'HDTP0' +CONVERT(nvarchar(10), CONVERT(INT, @ID) + 1)
				when (@ID>9999 and @length=5) and (@length=5 and @ID<99999) then 'HDTP0' +CONVERT(nvarchar(10), CONVERT(INT, @ID) + 1)
				when (@ID>99999 and @length=6) and (@length=6 and @ID<999999) then 'HDTP' +CONVERT(nvarchar(10), CONVERT(INT, @ID) + 1)

			end
	RETURN @ID
END

GO
/****** Object:  UserDefinedFunction [dbo].[AUTO_IDKH]    Script Date: 07/12/2019 10:32:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[AUTO_IDKH]()
RETURNS NVARCHAR(20)
AS
BEGIN
	DECLARE @ID NVARCHAR(20)
	DECLARE @length int
	IF (SELECT COUNT(MAKH) FROM KHACHHANG) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = convert(int,MAX(right(MaKH,6))) FROM KHACHHANG
		set @length=len(@ID)
		 select @ID= case
				when @length=1 and @ID<9 then 'KH00000' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				when @ID=9 then 'KH0000' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				when (@ID>9 and @length=2) and (@length=2 and @ID<99) then 'KH0000' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				when @ID=99 then 'KH000' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				when (@ID>99 and @length=3) and (@length=3 and @ID<999) then 'KH000' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				when @ID=999 then 'KH00' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				when (@ID>999 and @length=4) and(@length=4 and @ID<9999) then 'KH00' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				when @ID=9999 then 'KH0' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				when (@ID>9999 and @length=5) and (@length=5 and @ID<99999) then 'KH0' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				when (@ID>99999 and @length=6) and (@length=6 and @ID<999999) then 'KH' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)

			end
	RETURN @ID
END

GO
/****** Object:  UserDefinedFunction [dbo].[AUTO_IDLP]    Script Date: 07/12/2019 10:32:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[AUTO_IDLP]()
RETURNS NVARCHAR(8)
AS
BEGIN
	DECLARE @ID NVARCHAR(8)
	DECLARE @length int
	IF (SELECT COUNT(maLoaiPhong) FROM LoaiPhong) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = convert(int,MAX(right(maLoaiPhong,6))) FROM LoaiPhong
		set @length=len(@ID)
		 select @ID= case
				when @length=1 and @ID<9 then 'LP00000' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				when @ID=9 then 'LP0000' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				when (@ID>9 and @length=2) and (@length=2 and @ID<99) then 'LP0000' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				when @ID=99 then 'LP000' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				when (@ID>99 and @length=3) and (@length=3 and @ID<999) then 'LP000' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				when @ID=999 then 'LP00' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				when (@ID>999 and @length=4) and(@length=4 and @ID<9999) then 'LP00' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				when @ID=9999 then 'LP0' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				when (@ID>9999 and @length=5) and (@length=5 and @ID<99999) then 'LP0' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				when (@ID>99999 and @length=6) and (@length=6 and @ID<999999) then 'LP' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)

			end
	RETURN @ID
END
GO
/****** Object:  UserDefinedFunction [dbo].[AUTO_IDNV]    Script Date: 07/12/2019 10:32:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[AUTO_IDNV]()
RETURNS NVARCHAR(8)
AS
BEGIN
	DECLARE @ID NVARCHAR(8)
	DECLARE @length int
	IF (SELECT COUNT(maNV) FROM NhanVien) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = convert(int,MAX(right(maNV,6))) FROM NhanVien
		set @length=len(@ID)
		 select @ID= case
				when @length=1 and @ID<9 then 'NV00000' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				when @ID=9 then 'NV0000' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				when (@ID>9 and @length=2) and (@length=2 and @ID<99) then 'KH0000' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				when @ID=99 then 'NV000' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				when (@ID>99 and @length=3) and (@length=3 and @ID<999) then 'KH000' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				when @ID=999 then 'NV00' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				when (@ID>999 and @length=4) and(@length=4 and @ID<9999) then 'NV00' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				when @ID=9999 then 'NV0' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				when (@ID>9999 and @length=5) and (@length=5 and @ID<99999) then 'NV0' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				when (@ID>99999 and @length=6) and (@length=6 and @ID<999999) then 'NV' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)

			end
	RETURN @ID
END

GO
/****** Object:  UserDefinedFunction [dbo].[AUTO_IDPH]    Script Date: 07/12/2019 10:32:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[AUTO_IDPH]()
RETURNS NVARCHAR(8)
AS
BEGIN
	DECLARE @ID NVARCHAR(8)
	DECLARE @length int
	IF (SELECT COUNT(maPhong) FROM Phong) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = convert(int,MAX(right(maPhong,6))) FROM Phong
		set @length=len(@ID)
		 select @ID= case
				when @length=1 and @ID<9 then 'PH00000' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				when @ID=9 then 'PH0000' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				when (@ID>9 and @length=2) and (@length=2 and @ID<99) then 'PH0000' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				when @ID=99 then 'PH000' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				when (@ID>99 and @length=3) and (@length=3 and @ID<999) then 'PH000' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				when @ID=999 then 'PH00' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				when (@ID>999 and @length=4) and(@length=4 and @ID<9999) then 'PH00' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				when @ID=9999 then 'PH0' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				when (@ID>9999 and @length=5) and (@length=5 and @ID<99999) then 'PH0' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				when (@ID>99999 and @length=6) and (@length=6 and @ID<999999) then 'PH' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)

			end
	RETURN @ID
END
GO
/****** Object:  UserDefinedFunction [dbo].[AUTO_IDTP]    Script Date: 07/12/2019 10:32:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[AUTO_IDTP]()
RETURNS NVARCHAR(8)
AS
BEGIN
	DECLARE @ID NVARCHAR(8)
	DECLARE @length int
	IF (SELECT COUNT(maThue) FROM ThuePhong) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = convert(int,MAX(right(maThue,6))) FROM ThuePhong
		set @length=len(@ID)
		 select @ID= case
				when @length=1 and @ID<9 then 'TP00000' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				when @ID=9 then 'TP0000' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				when (@ID>9 and @length=2) and (@length=2 and @ID<99) then 'TP0000' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				when @ID=99 then 'TP000' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				when (@ID>99 and @length=3) and (@length=3 and @ID<999) then 'TP000' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				when @ID=999 then 'TP00' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				when (@ID>999 and @length=4) and(@length=4 and @ID<9999) then 'TP00' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				when @ID=9999 then 'TP0' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				when (@ID>9999 and @length=5) and (@length=5 and @ID<99999) then 'TP0' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				when (@ID>99999 and @length=6) and (@length=6 and @ID<999999) then 'TP' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)

			end
	RETURN @ID
END
GO
/****** Object:  UserDefinedFunction [dbo].[AUTO_TenPhong]    Script Date: 07/12/2019 10:32:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[AUTO_TenPhong]()
RETURNS NVARCHAR(50)
AS
BEGIN
	DECLARE @ID NVARCHAR(8)
	DECLARE @length int
	IF (SELECT COUNT(maPhong) FROM Phong) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = convert(int,MAX(right(maPhong,6))) FROM Phong
		set @length=len(@ID)
		 select @ID= case
				when @length=1 and @ID<9 then 'Phòng ' +CONVERT(NVARCHAR(50), CONVERT(INT, @ID) + 1)
				when @ID=9 then 'Phòng ' +CONVERT(NVARCHAR(50), CONVERT(INT, @ID) + 1)
				when (@ID>9 and @length=2) and (@length=2 and @ID<99) then 'Phòng ' +CONVERT(NVARCHAR(50), CONVERT(INT, @ID) + 1)
				when @ID=99 then 'Phòng ' +CONVERT(NVARCHAR(50), CONVERT(INT, @ID) + 1)
				when (@ID>99 and @length=3) and (@length=3 and @ID<999) then 'Phòng ' +CONVERT(NVARCHAR(50), CONVERT(INT, @ID) + 1)
				when @ID=999 then 'Phòng ' +CONVERT(NVARCHAR(50), CONVERT(INT, @ID) + 1)
				when (@ID>999 and @length=4) and(@length=4 and @ID<9999) then 'Phòng ' +CONVERT(NVARCHAR(50), CONVERT(INT, @ID) + 1)
				when @ID=9999 then 'Phòng ' +CONVERT(NVARCHAR(50), CONVERT(INT, @ID) + 1)
				when (@ID>9999 and @length=5) and (@length=5 and @ID<99999) then 'Phòng ' +CONVERT(NVARCHAR(50), CONVERT(INT, @ID) + 1)
				when (@ID>99999 and @length=6) and (@length=6 and @ID<999999) then 'Phòng ' +CONVERT(NVARCHAR(50), CONVERT(INT, @ID) + 1)

			end
	RETURN @ID
END
GO
/****** Object:  Table [dbo].[ChiTietDichVu]    Script Date: 07/12/2019 10:32:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietDichVu](
	[maThue] [nvarchar](8) NOT NULL,
	[maKhach] [nvarchar](8) NOT NULL,
	[maPhong] [nvarchar](8) NOT NULL,
	[maDV] [nvarchar](8) NOT NULL,
	[soLuong] [int] NOT NULL,
 CONSTRAINT [PK_ChiTietDichVu] PRIMARY KEY CLUSTERED 
(
	[maThue] ASC,
	[maKhach] ASC,
	[maPhong] ASC,
	[maDV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChiTietThuePhong]    Script Date: 07/12/2019 10:32:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietThuePhong](
	[maThue] [nvarchar](8) NOT NULL,
	[maKhach] [nvarchar](8) NOT NULL,
	[maPhong] [nvarchar](8) NOT NULL,
	[ngayVao] [datetime] NOT NULL,
	[ngayRa] [datetime] NOT NULL,
	[gioVao] [time](7) NOT NULL,
	[gioRa] [time](7) NOT NULL,
	[trangThai] [tinyint] NOT NULL,
	[tienKhac] [money] NULL,
	[ghiChu] [nvarchar](max) NULL,
 CONSTRAINT [PK_ChiTietThuePhong] PRIMARY KEY CLUSTERED 
(
	[maThue] ASC,
	[maKhach] ASC,
	[maPhong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DichVu]    Script Date: 07/12/2019 10:32:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DichVu](
	[maDV] [nvarchar](8) NOT NULL CONSTRAINT [DF_DV]  DEFAULT ([dbo].[AUTO_IDDV]()),
	[tenDichVu] [nvarchar](50) NULL,
	[donGia] [money] NULL,
	[soLuongDV] [int] NULL,
 CONSTRAINT [PK_DichVu] PRIMARY KEY CLUSTERED 
(
	[maDV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Doan]    Script Date: 07/12/2019 10:32:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doan](
	[maDoan] [nvarchar](7) NOT NULL CONSTRAINT [DF_Doan]  DEFAULT ([dbo].[AUTO_IDDoan]()),
	[tenDoan] [nvarchar](50) NOT NULL,
	[soDienThoai] [nvarchar](11) NULL,
	[diaChi] [nvarchar](50) NOT NULL,
	[maTruongDoan] [nvarchar](8) NOT NULL,
 CONSTRAINT [PK_KhachDoan] PRIMARY KEY CLUSTERED 
(
	[maDoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HoaDonDichVu]    Script Date: 07/12/2019 10:32:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDonDichVu](
	[maHDDV] [nvarchar](100) NOT NULL,
	[maThue] [nvarchar](8) NOT NULL,
	[maPhong] [nvarchar](8) NOT NULL,
	[maKhach] [nvarchar](8) NOT NULL,
	[ngayLap] [datetime] NOT NULL,
	[gioLap] [time](7) NOT NULL,
 CONSTRAINT [PK_HoaDonDichVu] PRIMARY KEY CLUSTERED 
(
	[maHDDV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HoaDonTienPhong]    Script Date: 07/12/2019 10:32:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDonTienPhong](
	[maHDPhong] [nvarchar](10) NOT NULL CONSTRAINT [DF_HDTP]  DEFAULT ([dbo].[AUTO_IDHDTP]()),
	[maThue] [nvarchar](8) NOT NULL,
	[ngayLap] [datetime] NOT NULL,
	[gioLap] [time](7) NOT NULL,
	[thueVAT] [float] NOT NULL,
	[khuyenMai] [float] NULL,
	[ghiChu] [nvarchar](100) NULL,
 CONSTRAINT [PK_HoaDon] PRIMARY KEY CLUSTERED 
(
	[maHDPhong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 07/12/2019 10:32:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[maKH] [nvarchar](8) NOT NULL CONSTRAINT [DF_KH]  DEFAULT ([dbo].[AUTO_IDKH]()),
	[tenKh] [nvarchar](50) NOT NULL,
	[soCMND] [nchar](20) NOT NULL,
	[gioiTinh] [tinyint] NOT NULL,
	[soDT] [nchar](11) NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[maKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LoaiPhong]    Script Date: 07/12/2019 10:32:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiPhong](
	[maLoaiPhong] [nvarchar](8) NOT NULL CONSTRAINT [DF_LP]  DEFAULT ([dbo].[AUTO_IDLP]()),
	[tenLoaiPhong] [nvarchar](50) NULL,
	[donGia] [money] NULL,
	[soNguoiToiDa] [int] NULL,
 CONSTRAINT [PK_LoaiPhong] PRIMARY KEY CLUSTERED 
(
	[maLoaiPhong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 07/12/2019 10:32:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NhanVien](
	[maNV] [nvarchar](8) NOT NULL CONSTRAINT [DF_NV]  DEFAULT ([dbo].[AUTO_IDNV]()),
	[tenNV] [nvarchar](50) NOT NULL,
	[soCMND] [nchar](20) NOT NULL,
	[gioiTinh] [tinyint] NOT NULL,
	[ngaySinh] [datetime] NOT NULL,
	[soDT] [nchar](11) NOT NULL,
	[chucVu] [tinyint] NOT NULL,
	[passWord] [varchar](50) NOT NULL,
	[email] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[maNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Phong]    Script Date: 07/12/2019 10:32:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Phong](
	[maPhong] [nvarchar](8) NOT NULL CONSTRAINT [DF_PH]  DEFAULT ([dbo].[AUTO_IDPH]()),
	[maLoaiPhong] [nvarchar](8) NOT NULL,
	[tenPhong] [nvarchar](50) NOT NULL CONSTRAINT [DF_TienPhong]  DEFAULT ([dbo].[AUTO_TenPhong]()),
	[tang] [int] NOT NULL,
	[tinhTrang] [bit] NOT NULL,
	[ghiChu] [nvarchar](50) NULL,
	[soNguoiHienTai] [int] NULL,
 CONSTRAINT [PK_Phong] PRIMARY KEY CLUSTERED 
(
	[maPhong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ThuePhong]    Script Date: 07/12/2019 10:32:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThuePhong](
	[maThue] [nvarchar](8) NOT NULL CONSTRAINT [DF_TP]  DEFAULT ([dbo].[AUTO_IDTP]()),
	[maNV] [nvarchar](8) NOT NULL,
	[soLuongPhong] [int] NOT NULL,
	[maDoan] [nvarchar](7) NULL,
	[trangThai] [tinyint] NOT NULL,
 CONSTRAINT [PK_ThuePhong] PRIMARY KEY CLUSTERED 
(
	[maThue] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000001', N'KH000003', N'PH000029', N'DV000001', 3)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000001', N'KH000003', N'PH000029', N'DV000002', 3)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000004', N'KH000010', N'PH000017', N'DV000001', 2)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000005', N'KH000003', N'PH000018', N'DV000001', 3)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000005', N'KH000003', N'PH000018', N'DV000003', 6)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000005', N'KH000003', N'PH000018', N'DV000006', 6)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000005', N'KH000003', N'PH000018', N'DV000008', 7)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000010', N'KH000015', N'PH000021', N'DV000001', 6)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000010', N'KH000015', N'PH000021', N'DV000003', 7)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000011', N'KH000015', N'PH000002', N'DV000001', 5)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000011', N'KH000015', N'PH000002', N'DV000002', 6)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000011', N'KH000015', N'PH000002', N'DV000003', 6)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000014', N'KH000015', N'PH000004', N'DV000001', 6)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000014', N'KH000015', N'PH000004', N'DV000003', 7)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000015', N'KH000015', N'PH000003', N'DV000001', 6)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000015', N'KH000015', N'PH000003', N'DV000003', 7)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000016', N'KH000015', N'PH000004', N'DV000001', 5)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000016', N'KH000015', N'PH000004', N'DV000002', 6)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000016', N'KH000015', N'PH000004', N'DV000003', 6)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000023', N'KH000007', N'PH000002', N'DV000001', 5)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000023', N'KH000007', N'PH000002', N'DV000003', 5)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000023', N'KH000010', N'PH000001', N'DV000005', 4)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000025', N'KH000001', N'PH000008', N'DV000001', 6)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000025', N'KH000001', N'PH000008', N'DV000002', 1)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000025', N'KH000001', N'PH000008', N'DV000003', 1)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000025', N'KH000008', N'PH000012', N'DV000005', 6)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000031', N'KH000002', N'PH000027', N'DV000001', 1)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000031', N'KH000002', N'PH000027', N'DV000003', 1)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000031', N'KH000002', N'PH000027', N'DV000005', 1)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000035', N'KH000008', N'PH000003', N'DV000005', 1)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000035', N'KH000008', N'PH000003', N'DV000008', 1)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000035', N'KH000012', N'PH000007', N'DV000002', 1)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000035', N'KH000012', N'PH000007', N'DV000004', 1)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000035', N'KH000012', N'PH000007', N'DV000006', 1)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000035', N'KH000013', N'PH000002', N'DV000009', 1)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000036', N'KH000008', N'PH000003', N'DV000001', 1)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000036', N'KH000008', N'PH000003', N'DV000003', 1)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000036', N'KH000012', N'PH000007', N'DV000005', 1)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000036', N'KH000012', N'PH000007', N'DV000008', 1)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000037', N'KH000005', N'PH000002', N'DV000012', 1)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000037', N'KH000005', N'PH000002', N'DV000015', 1)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000037', N'KH000012', N'PH000003', N'DV000001', 1)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000037', N'KH000012', N'PH000003', N'DV000003', 1)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000037', N'KH000012', N'PH000003', N'DV000005', 1)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000037', N'KH000015', N'PH000001', N'DV000008', 5)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000037', N'KH000015', N'PH000001', N'DV000010', 20)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000038', N'KH000011', N'PH000001', N'DV000013', 1)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000038', N'KH000011', N'PH000001', N'DV000015', 1)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000038', N'KH000012', N'PH000003', N'DV000001', 1)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000038', N'KH000012', N'PH000003', N'DV000004', 1)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000038', N'KH000012', N'PH000003', N'DV000006', 1)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000039', N'KH000001', N'PH000002', N'DV000002', 1)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000039', N'KH000001', N'PH000002', N'DV000004', 1)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000039', N'KH000010', N'PH000001', N'DV000003', 1)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000039', N'KH000010', N'PH000001', N'DV000005', 1)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000040', N'KH000008', N'PH000002', N'DV000001', 1)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000040', N'KH000008', N'PH000002', N'DV000003', 1)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000040', N'KH000008', N'PH000002', N'DV000006', 1)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000040', N'KH000013', N'PH000001', N'DV000009', 1)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000040', N'KH000013', N'PH000001', N'DV000010', 1)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000041', N'KH000001', N'PH000002', N'DV000002', 1)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000041', N'KH000001', N'PH000002', N'DV000005', 1)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000041', N'KH000001', N'PH000002', N'DV000007', 1)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000042', N'KH000011', N'PH000024', N'DV000002', 1)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000042', N'KH000011', N'PH000024', N'DV000005', 1)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000042', N'KH000011', N'PH000024', N'DV000009', 1)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000043', N'KH000013', N'PH000002', N'DV000002', 1)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000043', N'KH000013', N'PH000002', N'DV000005', 1)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000043', N'KH000013', N'PH000002', N'DV000007', 1)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000043', N'KH000014', N'PH000001', N'DV000008', 1)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000044', N'KH000014', N'PH000002', N'DV000001', 1)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000044', N'KH000014', N'PH000002', N'DV000007', 1)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000044', N'KH000014', N'PH000002', N'DV000009', 1)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000044', N'KH000014', N'PH000002', N'DV000011', 1)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000045', N'KH000013', N'PH000013', N'DV000002', 1)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000045', N'KH000013', N'PH000013', N'DV000005', 1)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000045', N'KH000013', N'PH000013', N'DV000008', 1)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000046', N'KH000002', N'PH000002', N'DV000001', 1)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000046', N'KH000002', N'PH000002', N'DV000005', 1)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000046', N'KH000006', N'PH000001', N'DV000003', 1)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000046', N'KH000006', N'PH000001', N'DV000007', 1)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000046', N'KH000006', N'PH000001', N'DV000010', 1)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000048', N'KH000005', N'PH000015', N'DV000002', 4)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000048', N'KH000005', N'PH000015', N'DV000003', 4)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000049', N'KH000001', N'PH000015', N'DV000001', 1)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000049', N'KH000001', N'PH000015', N'DV000003', 1)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000050', N'KH000014', N'PH000025', N'DV000001', 5)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000050', N'KH000014', N'PH000025', N'DV000003', 1)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000051', N'KH000009', N'PH000001', N'DV000001', 1)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000051', N'KH000009', N'PH000001', N'DV000003', 1)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000051', N'KH000009', N'PH000001', N'DV000006', 1)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000077', N'KH000004', N'PH000001', N'DV000001', 1)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000077', N'KH000004', N'PH000001', N'DV000003', 1)
INSERT [dbo].[ChiTietDichVu] ([maThue], [maKhach], [maPhong], [maDV], [soLuong]) VALUES (N'TP000077', N'KH000004', N'PH000001', N'DV000005', 1)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000001', N'KH000003', N'PH000029', CAST(N'2019-11-10 00:00:00.000' AS DateTime), CAST(N'2019-11-23 00:00:00.000' AS DateTime), CAST(N'08:22:05' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000002', N'KH000015', N'PH000028', CAST(N'2019-11-10 00:00:00.000' AS DateTime), CAST(N'2019-11-23 00:00:00.000' AS DateTime), CAST(N'18:30:41' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000003', N'KH000012', N'PH000027', CAST(N'2019-11-10 00:00:00.000' AS DateTime), CAST(N'2019-11-22 00:00:00.000' AS DateTime), CAST(N'19:21:46' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000004', N'KH000010', N'PH000017', CAST(N'2019-11-10 00:00:00.000' AS DateTime), CAST(N'2019-11-16 00:00:00.000' AS DateTime), CAST(N'21:27:22' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000005', N'KH000003', N'PH000018', CAST(N'2019-11-10 00:00:00.000' AS DateTime), CAST(N'2019-11-23 00:00:00.000' AS DateTime), CAST(N'21:29:01' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000007', N'KH000015', N'PH000020', CAST(N'2019-11-10 00:00:00.000' AS DateTime), CAST(N'2019-11-21 00:00:00.000' AS DateTime), CAST(N'22:00:27' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000008', N'KH000014', N'PH000015', CAST(N'2019-11-10 00:00:00.000' AS DateTime), CAST(N'2019-11-12 00:00:00.000' AS DateTime), CAST(N'22:05:53' AS Time), CAST(N'00:16:16' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000009', N'KH000010', N'PH000014', CAST(N'2019-11-10 00:00:00.000' AS DateTime), CAST(N'2019-11-12 00:00:00.000' AS DateTime), CAST(N'22:06:58' AS Time), CAST(N'00:13:32' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000010', N'KH000015', N'PH000021', CAST(N'2019-11-11 00:00:00.000' AS DateTime), CAST(N'2019-11-11 00:00:00.000' AS DateTime), CAST(N'00:55:40' AS Time), CAST(N'21:23:19' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000011', N'KH000003', N'PH000001', CAST(N'2019-11-14 00:00:00.000' AS DateTime), CAST(N'2019-11-14 00:00:00.000' AS DateTime), CAST(N'23:59:14' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000011', N'KH000015', N'PH000002', CAST(N'2019-11-14 00:00:00.000' AS DateTime), CAST(N'2019-11-14 00:00:00.000' AS DateTime), CAST(N'23:59:14' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, N'Đổi phòng')
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000012', N'KH000010', N'PH000003', CAST(N'2019-11-10 00:00:00.000' AS DateTime), CAST(N'2019-11-16 00:00:00.000' AS DateTime), CAST(N'21:27:22' AS Time), CAST(N'14:00:00' AS Time), 1, 8050000.0000, N'Phòng 17 (21:27:22 10/11/2019)đến Phòng 3 (16:13:14 17/11/2019)')
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000013', N'KH000010', N'PH000017', CAST(N'2019-11-10 00:00:00.000' AS DateTime), CAST(N'2019-11-19 00:00:00.000' AS DateTime), CAST(N'21:27:22' AS Time), CAST(N'09:19:51' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000014', N'KH000015', N'PH000004', CAST(N'2019-11-11 00:00:00.000' AS DateTime), CAST(N'2019-11-11 00:00:00.000' AS DateTime), CAST(N'00:55:40' AS Time), CAST(N'21:23:19' AS Time), 1, 5950000.0000, N'Đổi phòng')
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000015', N'KH000015', N'PH000003', CAST(N'2019-11-11 00:00:00.000' AS DateTime), CAST(N'2019-11-11 00:00:00.000' AS DateTime), CAST(N'00:55:40' AS Time), CAST(N'21:23:19' AS Time), 1, 3500000.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000016', N'KH000003', N'PH000001', CAST(N'2019-11-14 00:00:00.000' AS DateTime), CAST(N'2019-11-14 00:00:00.000' AS DateTime), CAST(N'23:59:14' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000016', N'KH000015', N'PH000004', CAST(N'2019-11-14 00:00:00.000' AS DateTime), CAST(N'2019-11-14 00:00:00.000' AS DateTime), CAST(N'23:59:14' AS Time), CAST(N'14:00:00' AS Time), 1, 2000000.0000, N'Đổi phòng')
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000018', N'KH000002', N'PH000009', CAST(N'2019-11-19 00:00:00.000' AS DateTime), CAST(N'2019-11-19 00:00:00.000' AS DateTime), CAST(N'08:39:42' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000018', N'KH000006', N'PH000009', CAST(N'2019-11-19 00:00:00.000' AS DateTime), CAST(N'2019-11-19 00:00:00.000' AS DateTime), CAST(N'08:39:42' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000018', N'KH000015', N'PH000009', CAST(N'2019-11-19 00:00:00.000' AS DateTime), CAST(N'2019-11-19 00:00:00.000' AS DateTime), CAST(N'08:39:42' AS Time), CAST(N'09:20:46' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000019', N'KH000005', N'PH000001', CAST(N'2019-11-19 00:00:00.000' AS DateTime), CAST(N'2019-11-19 00:00:00.000' AS DateTime), CAST(N'08:58:37' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000019', N'KH000011', N'PH000002', CAST(N'2019-11-19 00:00:00.000' AS DateTime), CAST(N'2019-11-19 00:00:00.000' AS DateTime), CAST(N'08:58:37' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000020', N'KH000002', N'PH000012', CAST(N'2019-11-19 00:00:00.000' AS DateTime), CAST(N'2019-11-19 00:00:00.000' AS DateTime), CAST(N'09:21:40' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000020', N'KH000004', N'PH000001', CAST(N'2019-11-19 00:00:00.000' AS DateTime), CAST(N'2019-11-19 00:00:00.000' AS DateTime), CAST(N'09:21:40' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000020', N'KH000006', N'PH000007', CAST(N'2019-11-19 00:00:00.000' AS DateTime), CAST(N'2019-11-19 00:00:00.000' AS DateTime), CAST(N'09:21:40' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000020', N'KH000008', N'PH000008', CAST(N'2019-11-19 00:00:00.000' AS DateTime), CAST(N'2019-11-19 00:00:00.000' AS DateTime), CAST(N'09:21:40' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000020', N'KH000011', N'PH000002', CAST(N'2019-11-19 00:00:00.000' AS DateTime), CAST(N'2019-11-19 00:00:00.000' AS DateTime), CAST(N'09:21:40' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000021', N'KH000006', N'PH000007', CAST(N'2019-11-19 00:00:00.000' AS DateTime), CAST(N'2019-11-19 00:00:00.000' AS DateTime), CAST(N'09:27:05' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000021', N'KH000010', N'PH000001', CAST(N'2019-11-19 00:00:00.000' AS DateTime), CAST(N'2019-11-19 00:00:00.000' AS DateTime), CAST(N'09:27:05' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000021', N'KH000011', N'PH000002', CAST(N'2019-11-19 00:00:00.000' AS DateTime), CAST(N'2019-11-19 00:00:00.000' AS DateTime), CAST(N'09:27:05' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000021', N'KH000012', N'PH000008', CAST(N'2019-11-19 00:00:00.000' AS DateTime), CAST(N'2019-11-19 00:00:00.000' AS DateTime), CAST(N'09:27:05' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000021', N'KH000013', N'PH000012', CAST(N'2019-11-19 00:00:00.000' AS DateTime), CAST(N'2019-11-19 00:00:00.000' AS DateTime), CAST(N'09:27:05' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000022', N'KH000004', N'PH000001', CAST(N'2019-11-19 00:00:00.000' AS DateTime), CAST(N'2019-11-19 00:00:00.000' AS DateTime), CAST(N'09:29:01' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000022', N'KH000005', N'PH000002', CAST(N'2019-11-19 00:00:00.000' AS DateTime), CAST(N'2019-11-19 00:00:00.000' AS DateTime), CAST(N'09:29:01' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000023', N'KH000006', N'PH000009', CAST(N'2019-11-19 00:00:00.000' AS DateTime), CAST(N'2019-11-19 00:00:00.000' AS DateTime), CAST(N'11:02:25' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000023', N'KH000007', N'PH000002', CAST(N'2019-11-19 00:00:00.000' AS DateTime), CAST(N'2019-11-19 00:00:00.000' AS DateTime), CAST(N'11:02:25' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000023', N'KH000009', N'PH000009', CAST(N'2019-11-19 00:00:00.000' AS DateTime), CAST(N'2019-11-19 00:00:00.000' AS DateTime), CAST(N'11:02:25' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000023', N'KH000010', N'PH000001', CAST(N'2019-11-19 00:00:00.000' AS DateTime), CAST(N'2019-11-19 00:00:00.000' AS DateTime), CAST(N'11:02:25' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000023', N'KH000013', N'PH000009', CAST(N'2019-11-19 00:00:00.000' AS DateTime), CAST(N'2019-11-19 00:00:00.000' AS DateTime), CAST(N'11:02:25' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000025', N'KH000001', N'PH000008', CAST(N'2019-11-19 00:00:00.000' AS DateTime), CAST(N'2019-11-19 00:00:00.000' AS DateTime), CAST(N'18:15:15' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000025', N'KH000008', N'PH000012', CAST(N'2019-11-19 00:00:00.000' AS DateTime), CAST(N'2019-11-19 00:00:00.000' AS DateTime), CAST(N'18:15:15' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000025', N'KH000011', N'PH000007', CAST(N'2019-11-19 00:00:00.000' AS DateTime), CAST(N'2019-11-19 00:00:00.000' AS DateTime), CAST(N'18:15:15' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000025', N'KH000015', N'PH000003', CAST(N'2019-11-19 00:00:00.000' AS DateTime), CAST(N'2019-11-19 00:00:00.000' AS DateTime), CAST(N'18:15:15' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000026', N'KH000011', N'PH000025', CAST(N'2019-11-19 00:00:00.000' AS DateTime), CAST(N'2019-11-22 00:00:00.000' AS DateTime), CAST(N'18:17:16' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000031', N'KH000002', N'PH000027', CAST(N'2019-11-19 00:00:00.000' AS DateTime), CAST(N'2019-11-30 00:00:00.000' AS DateTime), CAST(N'19:16:44' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000035', N'KH000008', N'PH000003', CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'09:45:21' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000035', N'KH000012', N'PH000007', CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'09:45:21' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000035', N'KH000013', N'PH000002', CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'09:45:21' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000035', N'KH000014', N'PH000001', CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'09:45:21' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000036', N'KH000007', N'PH000002', CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'10:03:00' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000036', N'KH000008', N'PH000003', CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'10:03:00' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000036', N'KH000009', N'PH000001', CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'10:03:00' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000036', N'KH000012', N'PH000007', CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'10:03:00' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000037', N'KH000005', N'PH000002', CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'10:10:23' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000037', N'KH000012', N'PH000003', CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'10:10:23' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000037', N'KH000015', N'PH000001', CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'10:10:23' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000038', N'KH000006', N'PH000007', CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'10:25:54' AS Time), CAST(N'10:26:23' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000038', N'KH000007', N'PH000002', CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'10:25:54' AS Time), CAST(N'10:26:23' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000038', N'KH000011', N'PH000001', CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'10:25:54' AS Time), CAST(N'10:26:23' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000038', N'KH000012', N'PH000003', CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'10:25:54' AS Time), CAST(N'10:26:23' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000039', N'KH000001', N'PH000002', CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'10:27:35' AS Time), CAST(N'10:27:55' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000039', N'KH000010', N'PH000001', CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'10:27:35' AS Time), CAST(N'10:27:55' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000040', N'KH000008', N'PH000002', CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'10:34:40' AS Time), CAST(N'10:35:04' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000040', N'KH000013', N'PH000001', CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'10:34:40' AS Time), CAST(N'10:35:04' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000041', N'KH000001', N'PH000002', CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'10:39:30' AS Time), CAST(N'10:39:49' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000041', N'KH000010', N'PH000001', CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'10:39:30' AS Time), CAST(N'10:39:49' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000042', N'KH000011', N'PH000024', CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'2019-11-30 00:00:00.000' AS DateTime), CAST(N'10:47:50' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000043', N'KH000013', N'PH000002', CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'10:48:24' AS Time), CAST(N'10:48:43' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000043', N'KH000014', N'PH000001', CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'10:48:24' AS Time), CAST(N'10:48:43' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000044', N'KH000014', N'PH000002', CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'11:04:34' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000045', N'KH000013', N'PH000013', CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'11:05:56' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000046', N'KH000002', N'PH000002', CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'11:06:34' AS Time), CAST(N'11:06:59' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000046', N'KH000006', N'PH000001', CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'11:06:34' AS Time), CAST(N'11:06:59' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000047', N'KH000001', N'PH000010', CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'11:19:50' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000047', N'KH000004', N'PH000009', CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'11:19:50' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000047', N'KH000006', N'PH000010', CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'11:19:50' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000047', N'KH000009', N'PH000001', CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'11:19:50' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000047', N'KH000010', N'PH000009', CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'11:19:50' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000047', N'KH000012', N'PH000009', CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'11:19:50' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000047', N'KH000014', N'PH000002', CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'11:19:50' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, N'Đổi phòng')
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000048', N'KH000005', N'PH000015', CAST(N'2019-11-26 00:00:00.000' AS DateTime), CAST(N'2019-11-30 00:00:00.000' AS DateTime), CAST(N'21:51:45' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000049', N'KH000001', N'PH000015', CAST(N'2019-11-27 00:00:00.000' AS DateTime), CAST(N'2019-11-30 00:00:00.000' AS DateTime), CAST(N'09:30:39' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000050', N'KH000014', N'PH000025', CAST(N'2019-11-27 00:00:00.000' AS DateTime), CAST(N'2019-11-30 00:00:00.000' AS DateTime), CAST(N'09:32:21' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000051', N'KH000001', N'PH000010', CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'2019-12-06 00:00:00.000' AS DateTime), CAST(N'11:19:50' AS Time), CAST(N'09:47:24' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000051', N'KH000004', N'PH000009', CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'2019-12-06 00:00:00.000' AS DateTime), CAST(N'11:19:50' AS Time), CAST(N'09:47:24' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000051', N'KH000006', N'PH000010', CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'2019-12-06 00:00:00.000' AS DateTime), CAST(N'11:19:50' AS Time), CAST(N'09:47:24' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000051', N'KH000009', N'PH000001', CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'2019-12-06 00:00:00.000' AS DateTime), CAST(N'11:19:50' AS Time), CAST(N'09:47:24' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000051', N'KH000010', N'PH000009', CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'2019-12-06 00:00:00.000' AS DateTime), CAST(N'11:19:50' AS Time), CAST(N'09:47:24' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000051', N'KH000012', N'PH000009', CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'2019-12-06 00:00:00.000' AS DateTime), CAST(N'11:19:50' AS Time), CAST(N'09:47:24' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000051', N'KH000014', N'PH000003', CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'2019-12-06 00:00:00.000' AS DateTime), CAST(N'11:19:50' AS Time), CAST(N'09:47:24' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000052', N'KH000010', N'PH000015', CAST(N'2019-11-27 00:00:00.000' AS DateTime), CAST(N'2019-11-27 00:00:00.000' AS DateTime), CAST(N'10:12:56' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, N'Đổi phòng')
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000053', N'KH000009', N'PH000016', CAST(N'2019-11-27 00:00:00.000' AS DateTime), CAST(N'2019-11-27 00:00:00.000' AS DateTime), CAST(N'10:12:56' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, N'Đổi phòng')
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000054', N'KH000010', N'PH000017', CAST(N'2019-11-27 00:00:00.000' AS DateTime), CAST(N'2019-11-27 00:00:00.000' AS DateTime), CAST(N'10:12:56' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, N'Đổi phòng')
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000060', N'KH000010', N'PH000002', CAST(N'2019-11-27 00:00:00.000' AS DateTime), CAST(N'2019-11-27 00:00:00.000' AS DateTime), CAST(N'10:12:56' AS Time), CAST(N'14:00:00' AS Time), 1, -345000.0000, N'Đổi phòng')
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000061', N'KH000009', N'PH000004', CAST(N'2019-11-27 00:00:00.000' AS DateTime), CAST(N'2019-11-27 00:00:00.000' AS DateTime), CAST(N'10:12:56' AS Time), CAST(N'14:00:00' AS Time), 1, -45000.0000, N'Đổi phòng')
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000062', N'KH000009', N'PH000011', CAST(N'2019-11-27 00:00:00.000' AS DateTime), CAST(N'2019-11-27 00:00:00.000' AS DateTime), CAST(N'10:12:56' AS Time), CAST(N'14:00:00' AS Time), 1, -45000.0000, N'Đổi phòng')
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000063', N'KH000009', N'PH000004', CAST(N'2019-11-27 00:00:00.000' AS DateTime), CAST(N'2019-11-27 00:00:00.000' AS DateTime), CAST(N'10:12:56' AS Time), CAST(N'14:00:00' AS Time), 1, -45000.0000, N'Đổi phòng')
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000064', N'KH000010', N'PH000005', CAST(N'2019-11-27 00:00:00.000' AS DateTime), CAST(N'2019-11-27 00:00:00.000' AS DateTime), CAST(N'10:12:56' AS Time), CAST(N'14:00:00' AS Time), 1, -150000.0000, N'Đổi phòng')
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000065', N'KH000010', N'PH000002', CAST(N'2019-11-27 00:00:00.000' AS DateTime), CAST(N'2019-11-27 00:00:00.000' AS DateTime), CAST(N'10:12:56' AS Time), CAST(N'14:00:00' AS Time), 1, -150000.0000, N'Đổi phòng')
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000066', N'KH000009', N'PH000005', CAST(N'2019-11-27 00:00:00.000' AS DateTime), CAST(N'2019-11-27 00:00:00.000' AS DateTime), CAST(N'10:12:56' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, NULL)
GO
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000067', N'KH000010', N'PH000004', CAST(N'2019-11-27 00:00:00.000' AS DateTime), CAST(N'2019-11-27 00:00:00.000' AS DateTime), CAST(N'10:12:56' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, N'Đổi phòng')
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000068', N'KH000010', N'PH000015', CAST(N'2019-11-27 00:00:00.000' AS DateTime), CAST(N'2019-11-30 00:00:00.000' AS DateTime), CAST(N'12:08:53' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, N'Đổi phòng')
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000069', N'KH000010', N'PH000002', CAST(N'2019-11-27 00:00:00.000' AS DateTime), CAST(N'2019-11-30 00:00:00.000' AS DateTime), CAST(N'12:08:53' AS Time), CAST(N'14:00:00' AS Time), 1, 50000.0000, N'Đổi phòng')
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000070', N'KH000010', N'PH000015', CAST(N'2019-11-27 00:00:00.000' AS DateTime), CAST(N'2019-11-30 00:00:00.000' AS DateTime), CAST(N'12:08:53' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, N'Đổi phòng')
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000071', N'KH000010', N'PH000002', CAST(N'2019-11-27 00:00:00.000' AS DateTime), CAST(N'2019-11-30 00:00:00.000' AS DateTime), CAST(N'12:08:53' AS Time), CAST(N'14:00:00' AS Time), 1, -50000.0000, N'Đổi phòng')
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000072', N'KH000010', N'PH000025', CAST(N'2019-11-27 00:00:00.000' AS DateTime), CAST(N'2019-11-30 00:00:00.000' AS DateTime), CAST(N'12:08:53' AS Time), CAST(N'14:00:00' AS Time), 1, 20000.0000, N'Đổi phòng')
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000073', N'KH000010', N'PH000021', CAST(N'2019-11-27 00:00:00.000' AS DateTime), CAST(N'2019-11-30 00:00:00.000' AS DateTime), CAST(N'12:08:53' AS Time), CAST(N'14:00:00' AS Time), 0, 220000.0000, N'Phòng 15 (12:08:53 27/11/2019)đến Phòng 2 (12:14:09 27/11/2019)Phòng 2 (12:08:53 27/11/2019)đến Phòng 15 (12:14:36 27/11/2019)Phòng 15 (12:08:53 27/11/2019)đến Phòng 2 (12:15:41 27/11/2019)Phòng 2 (12:08:53 27/11/2019)đến Phòng 25 (12:15:57 27/11/2019)Phòng 25 (12:08:53 27/11/2019)đến Phòng 21 (12:16:25 27/11/2019)')
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000074', N'KH000003', N'PH000001', CAST(N'2019-12-06 00:00:00.000' AS DateTime), CAST(N'2019-12-06 00:00:00.000' AS DateTime), CAST(N'09:51:33' AS Time), CAST(N'09:52:01' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000074', N'KH000005', N'PH000002', CAST(N'2019-12-06 00:00:00.000' AS DateTime), CAST(N'2019-12-06 00:00:00.000' AS DateTime), CAST(N'09:51:33' AS Time), CAST(N'09:52:01' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000074', N'KH000006', N'PH000009', CAST(N'2019-12-06 00:00:00.000' AS DateTime), CAST(N'2019-12-06 00:00:00.000' AS DateTime), CAST(N'09:51:33' AS Time), CAST(N'09:52:01' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000074', N'KH000008', N'PH000009', CAST(N'2019-12-06 00:00:00.000' AS DateTime), CAST(N'2019-12-06 00:00:00.000' AS DateTime), CAST(N'09:51:33' AS Time), CAST(N'09:52:01' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000074', N'KH000012', N'PH000009', CAST(N'2019-12-06 00:00:00.000' AS DateTime), CAST(N'2019-12-06 00:00:00.000' AS DateTime), CAST(N'09:51:33' AS Time), CAST(N'09:52:01' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000075', N'KH000004', N'PH000009', CAST(N'2019-12-06 00:00:00.000' AS DateTime), CAST(N'2019-12-06 00:00:00.000' AS DateTime), CAST(N'09:53:34' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000075', N'KH000009', N'PH000009', CAST(N'2019-12-06 00:00:00.000' AS DateTime), CAST(N'2019-12-06 00:00:00.000' AS DateTime), CAST(N'09:53:34' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000075', N'KH000014', N'PH000009', CAST(N'2019-12-06 00:00:00.000' AS DateTime), CAST(N'2019-12-06 00:00:00.000' AS DateTime), CAST(N'09:53:34' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000076', N'KH000004', N'PH000009', CAST(N'2019-12-06 00:00:00.000' AS DateTime), CAST(N'2019-12-06 00:00:00.000' AS DateTime), CAST(N'10:00:40' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, N'Đổi phòng')
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000076', N'KH000010', N'PH000009', CAST(N'2019-12-06 00:00:00.000' AS DateTime), CAST(N'2019-12-06 00:00:00.000' AS DateTime), CAST(N'10:00:40' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, N'Đổi phòng')
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000076', N'KH000013', N'PH000009', CAST(N'2019-12-06 00:00:00.000' AS DateTime), CAST(N'2019-12-06 00:00:00.000' AS DateTime), CAST(N'10:00:40' AS Time), CAST(N'14:00:00' AS Time), 1, 0.0000, N'Đổi phòng')
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000077', N'KH000004', N'PH000001', CAST(N'2019-12-06 00:00:00.000' AS DateTime), CAST(N'2019-12-06 00:00:00.000' AS DateTime), CAST(N'10:00:40' AS Time), CAST(N'14:00:00' AS Time), 0, -50000.0000, N'Phòng 9 (10:00:40 06/12/2019)đến Phòng 1 (10:01:00 06/12/2019)')
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000077', N'KH000010', N'PH000001', CAST(N'2019-12-06 00:00:00.000' AS DateTime), CAST(N'2019-12-06 00:00:00.000' AS DateTime), CAST(N'10:00:40' AS Time), CAST(N'14:00:00' AS Time), 0, -50000.0000, N'Phòng 9 (10:00:40 06/12/2019)đến Phòng 1 (10:01:00 06/12/2019)')
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000077', N'KH000013', N'PH000001', CAST(N'2019-12-06 00:00:00.000' AS DateTime), CAST(N'2019-12-06 00:00:00.000' AS DateTime), CAST(N'10:00:40' AS Time), CAST(N'14:00:00' AS Time), 0, -50000.0000, N'Phòng 9 (10:00:40 06/12/2019)đến Phòng 1 (10:01:00 06/12/2019)')
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000078', N'KH000010', N'PH000002', CAST(N'2019-11-27 00:00:00.000' AS DateTime), CAST(N'2019-11-27 00:00:00.000' AS DateTime), CAST(N'10:12:56' AS Time), CAST(N'14:00:00' AS Time), 1, 4500000.0000, N'Đổi phòng')
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000079', N'KH000010', N'PH000010', CAST(N'2019-11-27 00:00:00.000' AS DateTime), CAST(N'2019-11-27 00:00:00.000' AS DateTime), CAST(N'10:12:56' AS Time), CAST(N'14:00:00' AS Time), 1, 2250000.0000, N'Đổi phòng')
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000080', N'KH000010', N'PH000030', CAST(N'2019-11-27 00:00:00.000' AS DateTime), CAST(N'2019-11-27 00:00:00.000' AS DateTime), CAST(N'10:12:56' AS Time), CAST(N'14:00:00' AS Time), 0, 2250000.0000, N'Phòng 4 (10:12:56 27/11/2019)đến Phòng 2 (10:40:49 06/12/2019)Phòng 2 (10:12:56 27/11/2019)đến Phòng 10 (10:42:14 06/12/2019)Phòng 10 (10:12:56 27/11/2019)đến Phòng 30 (11:51:42 08/12/2019)')
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000081', N'KH000006', N'PH000025', CAST(N'2019-12-08 00:00:00.000' AS DateTime), CAST(N'2019-12-08 00:00:00.000' AS DateTime), CAST(N'20:47:47' AS Time), CAST(N'14:00:00' AS Time), 0, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000082', N'KH000002', N'PH000009', CAST(N'2019-12-08 00:00:00.000' AS DateTime), CAST(N'2019-12-08 00:00:00.000' AS DateTime), CAST(N'21:07:15' AS Time), CAST(N'14:00:00' AS Time), 0, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000082', N'KH000007', N'PH000009', CAST(N'2019-12-08 00:00:00.000' AS DateTime), CAST(N'2019-12-08 00:00:00.000' AS DateTime), CAST(N'21:07:15' AS Time), CAST(N'14:00:00' AS Time), 0, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000082', N'KH000009', N'PH000002', CAST(N'2019-12-08 00:00:00.000' AS DateTime), CAST(N'2019-12-08 00:00:00.000' AS DateTime), CAST(N'21:07:15' AS Time), CAST(N'14:00:00' AS Time), 0, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000082', N'KH000011', N'PH000009', CAST(N'2019-12-08 00:00:00.000' AS DateTime), CAST(N'2019-12-08 00:00:00.000' AS DateTime), CAST(N'21:07:15' AS Time), CAST(N'14:00:00' AS Time), 0, 0.0000, NULL)
INSERT [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong], [ngayVao], [ngayRa], [gioVao], [gioRa], [trangThai], [tienKhac], [ghiChu]) VALUES (N'TP000083', N'KH000009', N'PH000024', CAST(N'2019-12-08 00:00:00.000' AS DateTime), CAST(N'2019-12-13 00:00:00.000' AS DateTime), CAST(N'21:14:03' AS Time), CAST(N'14:00:00' AS Time), 0, 0.0000, NULL)
INSERT [dbo].[DichVu] ([maDV], [tenDichVu], [donGia], [soLuongDV]) VALUES (N'DV000001', N' Nước lọc', 10000.0000, 1743)
INSERT [dbo].[DichVu] ([maDV], [tenDichVu], [donGia], [soLuongDV]) VALUES (N'DV000002', N'Nước ngọt Minrinda', 15000.0000, 1312)
INSERT [dbo].[DichVu] ([maDV], [tenDichVu], [donGia], [soLuongDV]) VALUES (N'DV000003', N'Nước trái cây', 20000.0000, 185)
INSERT [dbo].[DichVu] ([maDV], [tenDichVu], [donGia], [soLuongDV]) VALUES (N'DV000004', N'Sữa chua', 10000.0000, 391)
INSERT [dbo].[DichVu] ([maDV], [tenDichVu], [donGia], [soLuongDV]) VALUES (N'DV000005', N'Bánh Chocopie', 5000.0000, 1522)
INSERT [dbo].[DichVu] ([maDV], [tenDichVu], [donGia], [soLuongDV]) VALUES (N'DV000006', N'Bánh quy', 35000.0000, 1940)
INSERT [dbo].[DichVu] ([maDV], [tenDichVu], [donGia], [soLuongDV]) VALUES (N'DV000007', N'Ăn trưa', 150000.0000, 282)
INSERT [dbo].[DichVu] ([maDV], [tenDichVu], [donGia], [soLuongDV]) VALUES (N'DV000008', N'Giặt ủi', 50000.0000, 1455)
INSERT [dbo].[DichVu] ([maDV], [tenDichVu], [donGia], [soLuongDV]) VALUES (N'DV000009', N'Thuê xe hơi', 1500000.0000, 67)
INSERT [dbo].[DichVu] ([maDV], [tenDichVu], [donGia], [soLuongDV]) VALUES (N'DV000010', N'Thuê xe máy', 200000.0000, 58)
INSERT [dbo].[DichVu] ([maDV], [tenDichVu], [donGia], [soLuongDV]) VALUES (N'DV000011', N'Chuyển hàng', 50000.0000, 70)
INSERT [dbo].[DichVu] ([maDV], [tenDichVu], [donGia], [soLuongDV]) VALUES (N'DV000012', N'Spa', 200000.0000, 97)
INSERT [dbo].[DichVu] ([maDV], [tenDichVu], [donGia], [soLuongDV]) VALUES (N'DV000013', N'Thuê đồ tắm hồ bơi', 120000.0000, 90)
INSERT [dbo].[DichVu] ([maDV], [tenDichVu], [donGia], [soLuongDV]) VALUES (N'DV000014', N'Trông trẻ', 250000.0000, 20)
INSERT [dbo].[DichVu] ([maDV], [tenDichVu], [donGia], [soLuongDV]) VALUES (N'DV000015', N'Sân Golf', 750000.0000, 48)
INSERT [dbo].[DichVu] ([maDV], [tenDichVu], [donGia], [soLuongDV]) VALUES (N'DV000016', N'Fitnes center', 300000.0000, 100)
INSERT [dbo].[DichVu] ([maDV], [tenDichVu], [donGia], [soLuongDV]) VALUES (N'DV000017', N'Bia Huda', 23000.0000, 200)
INSERT [dbo].[DichVu] ([maDV], [tenDichVu], [donGia], [soLuongDV]) VALUES (N'DV000018', N'Bánh mì tươi', 7000.0000, 500)
INSERT [dbo].[Doan] ([maDoan], [tenDoan], [soDienThoai], [diaChi], [maTruongDoan]) VALUES (N'D000001', N'Trường Tiểu Học', N'123456789', N'asd', N'asddsaas')
INSERT [dbo].[Doan] ([maDoan], [tenDoan], [soDienThoai], [diaChi], [maTruongDoan]) VALUES (N'D000002', N'Nguyễn Viết xuất', N'12545325', N'q', N'12345678')
INSERT [dbo].[Doan] ([maDoan], [tenDoan], [soDienThoai], [diaChi], [maTruongDoan]) VALUES (N'D000003', N'Nguyễn Huệ', N'3453245', N'a', N'a')
INSERT [dbo].[Doan] ([maDoan], [tenDoan], [soDienThoai], [diaChi], [maTruongDoan]) VALUES (N'D000004', N'Nguyễn Du', N'6456', N'a', N'a')
INSERT [dbo].[Doan] ([maDoan], [tenDoan], [soDienThoai], [diaChi], [maTruongDoan]) VALUES (N'D000005', N'Vinh Lộc', N'2345', N'a', N'a')
INSERT [dbo].[Doan] ([maDoan], [tenDoan], [soDienThoai], [diaChi], [maTruongDoan]) VALUES (N'D000006', N'Công Nghiệp', N'62345', N'a', N'aaaaaa')
INSERT [dbo].[Doan] ([maDoan], [tenDoan], [soDienThoai], [diaChi], [maTruongDoan]) VALUES (N'D000007', N'Kinh Tế', N'645645', N'a', N'a')
INSERT [dbo].[Doan] ([maDoan], [tenDoan], [soDienThoai], [diaChi], [maTruongDoan]) VALUES (N'D000008', N'Bách Khoa', N'2345', N'a', N'a')
INSERT [dbo].[HoaDonDichVu] ([maHDDV], [maThue], [maPhong], [maKhach], [ngayLap], [gioLap]) VALUES (N'20112019TP000045KH000013PH000013', N'TP000045', N'PH000013', N'KH000013', CAST(N'2019-11-23 00:00:00.000' AS DateTime), CAST(N'21:23:19' AS Time))
INSERT [dbo].[HoaDonDichVu] ([maHDDV], [maThue], [maPhong], [maKhach], [ngayLap], [gioLap]) VALUES (N'20112019TP000046KH000002PH000002', N'TP000046', N'PH000002', N'KH000002', CAST(N'2019-11-23 00:00:00.000' AS DateTime), CAST(N'21:23:19' AS Time))
INSERT [dbo].[HoaDonDichVu] ([maHDDV], [maThue], [maPhong], [maKhach], [ngayLap], [gioLap]) VALUES (N'20112019TP000046KH000006PH000001', N'TP000046', N'PH000001', N'KH000006', CAST(N'2019-11-23 00:00:00.000' AS DateTime), CAST(N'21:23:19' AS Time))
INSERT [dbo].[HoaDonDichVu] ([maHDDV], [maThue], [maPhong], [maKhach], [ngayLap], [gioLap]) VALUES (N'27112019TP000049KH000001PH000015', N'TP000049', N'PH000015', N'KH000001', CAST(N'2019-11-27 00:00:00.000' AS DateTime), CAST(N'09:30:47' AS Time))
INSERT [dbo].[HoaDonDichVu] ([maHDDV], [maThue], [maPhong], [maKhach], [ngayLap], [gioLap]) VALUES (N'27112019TP000050KH000014PH000025', N'TP000050', N'PH000025', N'KH000014', CAST(N'2019-11-27 00:00:00.000' AS DateTime), CAST(N'09:35:12' AS Time))
INSERT [dbo].[HoaDonDichVu] ([maHDDV], [maThue], [maPhong], [maKhach], [ngayLap], [gioLap]) VALUES (N'6122019TP000051KH000009PH000001', N'TP000051', N'PH000001', N'KH000009', CAST(N'2019-12-06 00:00:00.000' AS DateTime), CAST(N'09:47:24' AS Time))
INSERT [dbo].[HoaDonDichVu] ([maHDDV], [maThue], [maPhong], [maKhach], [ngayLap], [gioLap]) VALUES (N'HDTP000001', N'TP000042', N'PH000024', N'KH000011', CAST(N'2019-11-23 00:00:00.000' AS DateTime), CAST(N'21:23:19' AS Time))
INSERT [dbo].[HoaDonDichVu] ([maHDDV], [maThue], [maPhong], [maKhach], [ngayLap], [gioLap]) VALUES (N'HDTP000002', N'TP000043', N'PH000002', N'KH000013', CAST(N'2019-11-23 00:00:00.000' AS DateTime), CAST(N'21:23:19' AS Time))
INSERT [dbo].[HoaDonTienPhong] ([maHDPhong], [maThue], [ngayLap], [gioLap], [thueVAT], [khuyenMai], [ghiChu]) VALUES (N'HDTP000001', N'TP000010', CAST(N'2019-11-23 00:00:00.000' AS DateTime), CAST(N'21:23:19' AS Time), 0, 0, NULL)
INSERT [dbo].[HoaDonTienPhong] ([maHDPhong], [maThue], [ngayLap], [gioLap], [thueVAT], [khuyenMai], [ghiChu]) VALUES (N'HDTP000002', N'TP000009', CAST(N'2019-11-23 00:00:00.000' AS DateTime), CAST(N'00:13:32' AS Time), 0, 0, NULL)
INSERT [dbo].[HoaDonTienPhong] ([maHDPhong], [maThue], [ngayLap], [gioLap], [thueVAT], [khuyenMai], [ghiChu]) VALUES (N'HDTP000003', N'TP000008', CAST(N'2019-11-12 00:00:00.000' AS DateTime), CAST(N'00:16:16' AS Time), 0, 0, NULL)
INSERT [dbo].[HoaDonTienPhong] ([maHDPhong], [maThue], [ngayLap], [gioLap], [thueVAT], [khuyenMai], [ghiChu]) VALUES (N'HDTP000005', N'TP000019', CAST(N'2019-11-06 00:00:00.000' AS DateTime), CAST(N'09:09:02' AS Time), 49000, 98000, NULL)
INSERT [dbo].[HoaDonTienPhong] ([maHDPhong], [maThue], [ngayLap], [gioLap], [thueVAT], [khuyenMai], [ghiChu]) VALUES (N'HDTP000006', N'TP000008', CAST(N'2019-11-19 00:00:00.000' AS DateTime), CAST(N'09:10:25' AS Time), 0, 0, NULL)
INSERT [dbo].[HoaDonTienPhong] ([maHDPhong], [maThue], [ngayLap], [gioLap], [thueVAT], [khuyenMai], [ghiChu]) VALUES (N'HDTP000007', N'TP000009', CAST(N'2019-11-19 00:00:00.000' AS DateTime), CAST(N'09:11:12' AS Time), 0, 0, NULL)
INSERT [dbo].[HoaDonTienPhong] ([maHDPhong], [maThue], [ngayLap], [gioLap], [thueVAT], [khuyenMai], [ghiChu]) VALUES (N'HDTP000008', N'TP000003', CAST(N'2019-11-19 00:00:00.000' AS DateTime), CAST(N'09:14:13' AS Time), 0, 0, NULL)
INSERT [dbo].[HoaDonTienPhong] ([maHDPhong], [maThue], [ngayLap], [gioLap], [thueVAT], [khuyenMai], [ghiChu]) VALUES (N'HDTP000009', N'TP000002', CAST(N'2019-11-19 00:00:00.000' AS DateTime), CAST(N'09:17:11' AS Time), 0, 0, NULL)
INSERT [dbo].[HoaDonTienPhong] ([maHDPhong], [maThue], [ngayLap], [gioLap], [thueVAT], [khuyenMai], [ghiChu]) VALUES (N'HDTP000010', N'TP000001', CAST(N'2019-11-19 00:00:00.000' AS DateTime), CAST(N'09:18:51' AS Time), 0, 0, NULL)
INSERT [dbo].[HoaDonTienPhong] ([maHDPhong], [maThue], [ngayLap], [gioLap], [thueVAT], [khuyenMai], [ghiChu]) VALUES (N'HDTP000011', N'TP000013', CAST(N'2019-11-19 00:00:00.000' AS DateTime), CAST(N'09:19:51' AS Time), 0, 0, NULL)
INSERT [dbo].[HoaDonTienPhong] ([maHDPhong], [maThue], [ngayLap], [gioLap], [thueVAT], [khuyenMai], [ghiChu]) VALUES (N'HDTP000012', N'TP000018', CAST(N'2019-11-19 00:00:00.000' AS DateTime), CAST(N'09:20:46' AS Time), 0, 0, NULL)
INSERT [dbo].[HoaDonTienPhong] ([maHDPhong], [maThue], [ngayLap], [gioLap], [thueVAT], [khuyenMai], [ghiChu]) VALUES (N'HDTP000013', N'TP000020', CAST(N'2019-11-19 00:00:00.000' AS DateTime), CAST(N'09:24:29' AS Time), 122500, 245000, NULL)
INSERT [dbo].[HoaDonTienPhong] ([maHDPhong], [maThue], [ngayLap], [gioLap], [thueVAT], [khuyenMai], [ghiChu]) VALUES (N'HDTP000014', N'TP000021', CAST(N'2019-11-19 00:00:00.000' AS DateTime), CAST(N'09:27:13' AS Time), 122500, 245000, NULL)
INSERT [dbo].[HoaDonTienPhong] ([maHDPhong], [maThue], [ngayLap], [gioLap], [thueVAT], [khuyenMai], [ghiChu]) VALUES (N'HDTP000015', N'TP000022', CAST(N'2019-11-19 00:00:00.000' AS DateTime), CAST(N'09:29:48' AS Time), 49000, 98000, NULL)
INSERT [dbo].[HoaDonTienPhong] ([maHDPhong], [maThue], [ngayLap], [gioLap], [thueVAT], [khuyenMai], [ghiChu]) VALUES (N'HDTP000016', N'TP000023', CAST(N'2019-11-19 00:00:00.000' AS DateTime), CAST(N'11:21:25' AS Time), 0, 0, NULL)
INSERT [dbo].[HoaDonTienPhong] ([maHDPhong], [maThue], [ngayLap], [gioLap], [thueVAT], [khuyenMai], [ghiChu]) VALUES (N'HDTP000018', N'TP000005', CAST(N'2019-11-19 00:00:00.000' AS DateTime), CAST(N'14:10:26' AS Time), 0, 0, NULL)
INSERT [dbo].[HoaDonTienPhong] ([maHDPhong], [maThue], [ngayLap], [gioLap], [thueVAT], [khuyenMai], [ghiChu]) VALUES (N'HDTP000024', N'TP000007', CAST(N'2019-11-19 00:00:00.000' AS DateTime), CAST(N'18:15:48' AS Time), 0, 0, NULL)
INSERT [dbo].[HoaDonTienPhong] ([maHDPhong], [maThue], [ngayLap], [gioLap], [thueVAT], [khuyenMai], [ghiChu]) VALUES (N'HDTP000025', N'TP000026', CAST(N'2019-11-19 00:00:00.000' AS DateTime), CAST(N'18:17:28' AS Time), 0, 0, NULL)
INSERT [dbo].[HoaDonTienPhong] ([maHDPhong], [maThue], [ngayLap], [gioLap], [thueVAT], [khuyenMai], [ghiChu]) VALUES (N'HDTP000030', N'TP000031', CAST(N'2019-11-19 00:00:00.000' AS DateTime), CAST(N'19:18:21' AS Time), 0, 0, NULL)
INSERT [dbo].[HoaDonTienPhong] ([maHDPhong], [maThue], [ngayLap], [gioLap], [thueVAT], [khuyenMai], [ghiChu]) VALUES (N'HDTP000034', N'TP000035', CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'09:48:24' AS Time), 98000, 196000, NULL)
INSERT [dbo].[HoaDonTienPhong] ([maHDPhong], [maThue], [ngayLap], [gioLap], [thueVAT], [khuyenMai], [ghiChu]) VALUES (N'HDTP000035', N'TP000036', CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'10:03:33' AS Time), 98000, 196000, NULL)
INSERT [dbo].[HoaDonTienPhong] ([maHDPhong], [maThue], [ngayLap], [gioLap], [thueVAT], [khuyenMai], [ghiChu]) VALUES (N'HDTP000036', N'TP000037', CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'10:11:14' AS Time), 73500, 147000, NULL)
INSERT [dbo].[HoaDonTienPhong] ([maHDPhong], [maThue], [ngayLap], [gioLap], [thueVAT], [khuyenMai], [ghiChu]) VALUES (N'HDTP000037', N'TP000038', CAST(N'2019-11-23 00:00:00.000' AS DateTime), CAST(N'10:26:23' AS Time), 98000, 196000, NULL)
INSERT [dbo].[HoaDonTienPhong] ([maHDPhong], [maThue], [ngayLap], [gioLap], [thueVAT], [khuyenMai], [ghiChu]) VALUES (N'HDTP000038', N'TP000039', CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'10:27:55' AS Time), 49000, 98000, NULL)
INSERT [dbo].[HoaDonTienPhong] ([maHDPhong], [maThue], [ngayLap], [gioLap], [thueVAT], [khuyenMai], [ghiChu]) VALUES (N'HDTP000039', N'TP000040', CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'10:35:04' AS Time), 49000, 98000, NULL)
INSERT [dbo].[HoaDonTienPhong] ([maHDPhong], [maThue], [ngayLap], [gioLap], [thueVAT], [khuyenMai], [ghiChu]) VALUES (N'HDTP000040', N'TP000041', CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'10:39:49' AS Time), 49000, 98000, NULL)
INSERT [dbo].[HoaDonTienPhong] ([maHDPhong], [maThue], [ngayLap], [gioLap], [thueVAT], [khuyenMai], [ghiChu]) VALUES (N'HDTP000041', N'TP000042', CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'10:47:59' AS Time), 0, 0, NULL)
INSERT [dbo].[HoaDonTienPhong] ([maHDPhong], [maThue], [ngayLap], [gioLap], [thueVAT], [khuyenMai], [ghiChu]) VALUES (N'HDTP000042', N'TP000043', CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'10:48:43' AS Time), 49000, 98000, NULL)
INSERT [dbo].[HoaDonTienPhong] ([maHDPhong], [maThue], [ngayLap], [gioLap], [thueVAT], [khuyenMai], [ghiChu]) VALUES (N'HDTP000043', N'TP000044', CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'11:04:41' AS Time), 0, 0, NULL)
INSERT [dbo].[HoaDonTienPhong] ([maHDPhong], [maThue], [ngayLap], [gioLap], [thueVAT], [khuyenMai], [ghiChu]) VALUES (N'HDTP000044', N'TP000045', CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'11:06:03' AS Time), 0, 0, NULL)
INSERT [dbo].[HoaDonTienPhong] ([maHDPhong], [maThue], [ngayLap], [gioLap], [thueVAT], [khuyenMai], [ghiChu]) VALUES (N'HDTP000045', N'TP000046', CAST(N'2019-11-20 00:00:00.000' AS DateTime), CAST(N'11:06:59' AS Time), 35000, 70000, NULL)
INSERT [dbo].[HoaDonTienPhong] ([maHDPhong], [maThue], [ngayLap], [gioLap], [thueVAT], [khuyenMai], [ghiChu]) VALUES (N'HDTP000046', N'TP000048', CAST(N'2019-11-27 00:00:00.000' AS DateTime), CAST(N'09:30:01' AS Time), 0, 0, NULL)
INSERT [dbo].[HoaDonTienPhong] ([maHDPhong], [maThue], [ngayLap], [gioLap], [thueVAT], [khuyenMai], [ghiChu]) VALUES (N'HDTP000047', N'TP000049', CAST(N'2019-11-27 00:00:00.000' AS DateTime), CAST(N'09:30:47' AS Time), 0, 0, NULL)
INSERT [dbo].[HoaDonTienPhong] ([maHDPhong], [maThue], [ngayLap], [gioLap], [thueVAT], [khuyenMai], [ghiChu]) VALUES (N'HDTP000048', N'TP000050', CAST(N'2019-11-27 00:00:00.000' AS DateTime), CAST(N'09:35:12' AS Time), 0, 0, NULL)
INSERT [dbo].[HoaDonTienPhong] ([maHDPhong], [maThue], [ngayLap], [gioLap], [thueVAT], [khuyenMai], [ghiChu]) VALUES (N'HDTP000049', N'TP000051', CAST(N'2019-12-06 00:00:00.000' AS DateTime), CAST(N'09:47:24' AS Time), 3097000, 6194000, NULL)
INSERT [dbo].[HoaDonTienPhong] ([maHDPhong], [maThue], [ngayLap], [gioLap], [thueVAT], [khuyenMai], [ghiChu]) VALUES (N'HDTP000050', N'TP000074', CAST(N'2019-12-06 00:00:00.000' AS DateTime), CAST(N'09:52:01' AS Time), 91000, 182000, NULL)
INSERT [dbo].[HoaDonTienPhong] ([maHDPhong], [maThue], [ngayLap], [gioLap], [thueVAT], [khuyenMai], [ghiChu]) VALUES (N'HDTP000051', N'TP000066', CAST(N'2019-12-06 00:00:00.000' AS DateTime), CAST(N'10:00:16' AS Time), 1, 0, NULL)
INSERT [dbo].[KhachHang] ([maKH], [tenKh], [soCMND], [gioiTinh], [soDT]) VALUES (N'KH000001', N'Nguyễn Thị Thanh Thảo', N'0272626953          ', 0, N'0379301852 ')
INSERT [dbo].[KhachHang] ([maKH], [tenKh], [soCMND], [gioiTinh], [soDT]) VALUES (N'KH000002', N'Lê Ánh Dương', N'0296314566          ', 0, N'0369885211 ')
INSERT [dbo].[KhachHang] ([maKH], [tenKh], [soCMND], [gioiTinh], [soDT]) VALUES (N'KH000003', N'Trịnh Tú Trung', N'0168523221          ', 1, N'0168523221 ')
INSERT [dbo].[KhachHang] ([maKH], [tenKh], [soCMND], [gioiTinh], [soDT]) VALUES (N'KH000004', N'Nguyễn Minh Phong', N'0175202563          ', 1, N'0963210012 ')
INSERT [dbo].[KhachHang] ([maKH], [tenKh], [soCMND], [gioiTinh], [soDT]) VALUES (N'KH000005', N'Lê Hoài Thương', N'0236022210          ', 0, N'0369555013 ')
INSERT [dbo].[KhachHang] ([maKH], [tenKh], [soCMND], [gioiTinh], [soDT]) VALUES (N'KH000006', N'Trần Ngọc Trâm', N'0269330120          ', 0, N'0909362124 ')
INSERT [dbo].[KhachHang] ([maKH], [tenKh], [soCMND], [gioiTinh], [soDT]) VALUES (N'KH000007', N'Nguyễn Thảo Nguyên', N'0296322012          ', 0, N'0809365221 ')
INSERT [dbo].[KhachHang] ([maKH], [tenKh], [soCMND], [gioiTinh], [soDT]) VALUES (N'KH000008', N'Nguyễn Xuân Đức', N'0296322147          ', 1, N'0963552142 ')
INSERT [dbo].[KhachHang] ([maKH], [tenKh], [soCMND], [gioiTinh], [soDT]) VALUES (N'KH000009', N'Lại Minh Tâm', N'0208554123          ', 1, N'0623520017 ')
INSERT [dbo].[KhachHang] ([maKH], [tenKh], [soCMND], [gioiTinh], [soDT]) VALUES (N'KH000010', N'Phan Gia Thùy Trang', N'0196325212          ', 0, N'0361001450 ')
INSERT [dbo].[KhachHang] ([maKH], [tenKh], [soCMND], [gioiTinh], [soDT]) VALUES (N'KH000011', N'Mộc Nhĩ Đa', N'0201336452          ', 1, N'0916321521 ')
INSERT [dbo].[KhachHang] ([maKH], [tenKh], [soCMND], [gioiTinh], [soDT]) VALUES (N'KH000012', N'Trần Bích Phượng', N'0301255200          ', 0, N'0807562152 ')
INSERT [dbo].[KhachHang] ([maKH], [tenKh], [soCMND], [gioiTinh], [soDT]) VALUES (N'KH000013', N'Nguyễn Trần Minh Anh', N'0240533651          ', 1, N'0856332140 ')
INSERT [dbo].[KhachHang] ([maKH], [tenKh], [soCMND], [gioiTinh], [soDT]) VALUES (N'KH000014', N'Nguyễn Văn Khương', N'0212500145          ', 1, N'0396258828 ')
INSERT [dbo].[KhachHang] ([maKH], [tenKh], [soCMND], [gioiTinh], [soDT]) VALUES (N'KH000015', N'Phan Xuân Bách', N'0190050360          ', 1, N'0896635220 ')
INSERT [dbo].[LoaiPhong] ([maLoaiPhong], [tenLoaiPhong], [donGia], [soNguoiToiDa]) VALUES (N'LP000001', N'Normal', 350000.0000, 1)
INSERT [dbo].[LoaiPhong] ([maLoaiPhong], [tenLoaiPhong], [donGia], [soNguoiToiDa]) VALUES (N'LP000002', N'Double', 600000.0000, 3)
INSERT [dbo].[LoaiPhong] ([maLoaiPhong], [tenLoaiPhong], [donGia], [soNguoiToiDa]) VALUES (N'LP000003', N'Triple', 700000.0000, 4)
INSERT [dbo].[LoaiPhong] ([maLoaiPhong], [tenLoaiPhong], [donGia], [soNguoiToiDa]) VALUES (N'LP000004', N'Family', 850000.0000, 5)
INSERT [dbo].[LoaiPhong] ([maLoaiPhong], [tenLoaiPhong], [donGia], [soNguoiToiDa]) VALUES (N'LP000005', N'Vip', 1500000.0000, 2)
INSERT [dbo].[LoaiPhong] ([maLoaiPhong], [tenLoaiPhong], [donGia], [soNguoiToiDa]) VALUES (N'LP000006', N'Deluxe', 1700000.0000, 2)
INSERT [dbo].[NhanVien] ([maNV], [tenNV], [soCMND], [gioiTinh], [ngaySinh], [soDT], [chucVu], [passWord], [email]) VALUES (N'NV000001', N'Đỗ Thành Thị Qúy Phi', N'272695530           ', 1, CAST(N'1990-08-08 00:00:00.000' AS DateTime), N'0685220001 ', 0, N'123456@             ', N'admin@gmail.com')
INSERT [dbo].[NhanVien] ([maNV], [tenNV], [soCMND], [gioiTinh], [ngaySinh], [soDT], [chucVu], [passWord], [email]) VALUES (N'NV000002', N'Nguyễn Thị Hoa Lan', N'262629637           ', 0, CAST(N'1993-01-12 00:00:00.000' AS DateTime), N'0385523322 ', 0, N'123456', N'admin1@gmail.com')
INSERT [dbo].[NhanVien] ([maNV], [tenNV], [soCMND], [gioiTinh], [ngaySinh], [soDT], [chucVu], [passWord], [email]) VALUES (N'NV000003', N'Trương Đan Phong', N'262712100           ', 1, CAST(N'1998-02-02 00:00:00.000' AS DateTime), N'0386236660 ', 0, N'123456              ', N'admin2@gmail.com')
INSERT [dbo].[NhanVien] ([maNV], [tenNV], [soCMND], [gioiTinh], [ngaySinh], [soDT], [chucVu], [passWord], [email]) VALUES (N'NV000004', N'Lưu Mễ Như A', N'232425512           ', 0, CAST(N'1995-09-08 00:00:00.000' AS DateTime), N'0362563225 ', 0, N'123456              ', N'admin3@gmail.com')
INSERT [dbo].[NhanVien] ([maNV], [tenNV], [soCMND], [gioiTinh], [ngaySinh], [soDT], [chucVu], [passWord], [email]) VALUES (N'NV000005', N'Đỗ Thùy Linh', N'263155212           ', 0, CAST(N'1992-09-03 00:00:00.000' AS DateTime), N'0963001234 ', 0, N'123456              ', N'admin4@gmail.com')
INSERT [dbo].[NhanVien] ([maNV], [tenNV], [soCMND], [gioiTinh], [ngaySinh], [soDT], [chucVu], [passWord], [email]) VALUES (N'NV000006', N'Nguyễn Chí Thông', N'125550369           ', 1, CAST(N'1996-03-21 00:00:00.000' AS DateTime), N'0369522210 ', 0, N'123456              ', N'admin5@gmail.com')
INSERT [dbo].[NhanVien] ([maNV], [tenNV], [soCMND], [gioiTinh], [ngaySinh], [soDT], [chucVu], [passWord], [email]) VALUES (N'NV000007', N'Hứa Phan Quỳnh My', N'272626968           ', 0, CAST(N'1998-01-05 00:00:00.000' AS DateTime), N'0826601253 ', 0, N'123456              ', N'admin6@gmail.com')
INSERT [dbo].[NhanVien] ([maNV], [tenNV], [soCMND], [gioiTinh], [ngaySinh], [soDT], [chucVu], [passWord], [email]) VALUES (N'NV000008', N'Lâm Vỹ Dạ', N'262639965           ', 0, CAST(N'1997-11-03 00:00:00.000' AS DateTime), N'0385022100 ', 0, N'123456              ', N'admin7@gmail.com')
INSERT [dbo].[NhanVien] ([maNV], [tenNV], [soCMND], [gioiTinh], [ngaySinh], [soDT], [chucVu], [passWord], [email]) VALUES (N'NV000009', N'Lâm Canh Tân', N'269965123           ', 1, CAST(N'1996-07-21 00:00:00.000' AS DateTime), N'0345562011 ', 0, N'123456              ', N'admin8@gmail.com')
INSERT [dbo].[NhanVien] ([maNV], [tenNV], [soCMND], [gioiTinh], [ngaySinh], [soDT], [chucVu], [passWord], [email]) VALUES (N'NV000010', N'Nguyễn Thị Hương Ly', N'270052462           ', 0, CAST(N'1997-06-25 00:00:00.000' AS DateTime), N'0396093369 ', 0, N'123456              ', N'admin9@gmail.com')
INSERT [dbo].[NhanVien] ([maNV], [tenNV], [soCMND], [gioiTinh], [ngaySinh], [soDT], [chucVu], [passWord], [email]) VALUES (N'NV000011', N'Lê Viết Huy', N'296544010           ', 1, CAST(N'1996-12-31 00:00:00.000' AS DateTime), N'0262452123 ', 0, N'123456              ', N'admin10@gmail.com')
INSERT [dbo].[NhanVien] ([maNV], [tenNV], [soCMND], [gioiTinh], [ngaySinh], [soDT], [chucVu], [passWord], [email]) VALUES (N'NV000012', N'Mai Thị Thanh Thúy', N'203369966           ', 0, CAST(N'1994-11-03 00:00:00.000' AS DateTime), N'0145021360 ', 0, N'123456', N'admin11@gmail.com')
INSERT [dbo].[NhanVien] ([maNV], [tenNV], [soCMND], [gioiTinh], [ngaySinh], [soDT], [chucVu], [passWord], [email]) VALUES (N'NV000013', N'Nguyễn Trần Trúc Linh', N'262929633           ', 0, CAST(N'1999-04-01 00:00:00.000' AS DateTime), N'0378501101 ', 0, N'123456', N'admin12@gmail.com')
INSERT [dbo].[NhanVien] ([maNV], [tenNV], [soCMND], [gioiTinh], [ngaySinh], [soDT], [chucVu], [passWord], [email]) VALUES (N'NV000014', N'Nguyễn Thị Kim Chi', N'272863500           ', 0, CAST(N'1999-02-03 00:00:00.000' AS DateTime), N'0379301526 ', 0, N'123456', N'admin13@gmail.com')
INSERT [dbo].[NhanVien] ([maNV], [tenNV], [soCMND], [gioiTinh], [ngaySinh], [soDT], [chucVu], [passWord], [email]) VALUES (N'NV000015', N'Nguyễn Thị Hoa Lan Rừng B', N'262629639           ', 0, CAST(N'1993-12-01 00:00:00.000' AS DateTime), N'0385523352 ', 0, N'123456', N'admin14@gmail.com')
INSERT [dbo].[Phong] ([maPhong], [maLoaiPhong], [tenPhong], [tang], [tinhTrang], [ghiChu], [soNguoiHienTai]) VALUES (N'PH000001', N'LP000001', N'Phòng 1', 1, 1, NULL, 0)
INSERT [dbo].[Phong] ([maPhong], [maLoaiPhong], [tenPhong], [tang], [tinhTrang], [ghiChu], [soNguoiHienTai]) VALUES (N'PH000002', N'LP000001', N'Phòng 2', 1, 1, NULL, 1)
INSERT [dbo].[Phong] ([maPhong], [maLoaiPhong], [tenPhong], [tang], [tinhTrang], [ghiChu], [soNguoiHienTai]) VALUES (N'PH000003', N'LP000001', N'Phòng 3', 2, 0, NULL, 0)
INSERT [dbo].[Phong] ([maPhong], [maLoaiPhong], [tenPhong], [tang], [tinhTrang], [ghiChu], [soNguoiHienTai]) VALUES (N'PH000004', N'LP000004', N'Phòng 4', 1, 0, NULL, 0)
INSERT [dbo].[Phong] ([maPhong], [maLoaiPhong], [tenPhong], [tang], [tinhTrang], [ghiChu], [soNguoiHienTai]) VALUES (N'PH000005', N'LP000004', N'Phòng 5', 1, 0, NULL, 0)
INSERT [dbo].[Phong] ([maPhong], [maLoaiPhong], [tenPhong], [tang], [tinhTrang], [ghiChu], [soNguoiHienTai]) VALUES (N'PH000006', N'LP000004', N'Phòng 6', 1, 0, NULL, 0)
INSERT [dbo].[Phong] ([maPhong], [maLoaiPhong], [tenPhong], [tang], [tinhTrang], [ghiChu], [soNguoiHienTai]) VALUES (N'PH000007', N'LP000001', N'Phòng 7', 2, 0, NULL, 0)
INSERT [dbo].[Phong] ([maPhong], [maLoaiPhong], [tenPhong], [tang], [tinhTrang], [ghiChu], [soNguoiHienTai]) VALUES (N'PH000008', N'LP000001', N'Phòng 8', 2, 0, NULL, 0)
INSERT [dbo].[Phong] ([maPhong], [maLoaiPhong], [tenPhong], [tang], [tinhTrang], [ghiChu], [soNguoiHienTai]) VALUES (N'PH000009', N'LP000002', N'Phòng 9', 4, 1, NULL, 3)
INSERT [dbo].[Phong] ([maPhong], [maLoaiPhong], [tenPhong], [tang], [tinhTrang], [ghiChu], [soNguoiHienTai]) VALUES (N'PH000010', N'LP000002', N'Phòng 10', 2, 0, N'Phòng cho gia đình', 0)
INSERT [dbo].[Phong] ([maPhong], [maLoaiPhong], [tenPhong], [tang], [tinhTrang], [ghiChu], [soNguoiHienTai]) VALUES (N'PH000011', N'LP000003', N'Phòng 11', 2, 0, NULL, 0)
INSERT [dbo].[Phong] ([maPhong], [maLoaiPhong], [tenPhong], [tang], [tinhTrang], [ghiChu], [soNguoiHienTai]) VALUES (N'PH000012', N'LP000001', N'Phòng 12', 3, 0, NULL, 0)
INSERT [dbo].[Phong] ([maPhong], [maLoaiPhong], [tenPhong], [tang], [tinhTrang], [ghiChu], [soNguoiHienTai]) VALUES (N'PH000013', N'LP000001', N'Phòng 13', 3, 0, NULL, 0)
INSERT [dbo].[Phong] ([maPhong], [maLoaiPhong], [tenPhong], [tang], [tinhTrang], [ghiChu], [soNguoiHienTai]) VALUES (N'PH000014', N'LP000002', N'Phòng 14', 3, 0, NULL, 0)
INSERT [dbo].[Phong] ([maPhong], [maLoaiPhong], [tenPhong], [tang], [tinhTrang], [ghiChu], [soNguoiHienTai]) VALUES (N'PH000015', N'LP000002', N'Phòng 15', 3, 0, NULL, 0)
INSERT [dbo].[Phong] ([maPhong], [maLoaiPhong], [tenPhong], [tang], [tinhTrang], [ghiChu], [soNguoiHienTai]) VALUES (N'PH000016', N'LP000003', N'Phòng 16', 3, 0, NULL, 0)
INSERT [dbo].[Phong] ([maPhong], [maLoaiPhong], [tenPhong], [tang], [tinhTrang], [ghiChu], [soNguoiHienTai]) VALUES (N'PH000017', N'LP000005', N'Phòng 17', 4, 0, NULL, 0)
INSERT [dbo].[Phong] ([maPhong], [maLoaiPhong], [tenPhong], [tang], [tinhTrang], [ghiChu], [soNguoiHienTai]) VALUES (N'PH000018', N'LP000005', N'Phòng 18', 4, 0, NULL, 0)
INSERT [dbo].[Phong] ([maPhong], [maLoaiPhong], [tenPhong], [tang], [tinhTrang], [ghiChu], [soNguoiHienTai]) VALUES (N'PH000019', N'LP000006', N'Phòng 19', 5, 0, NULL, 0)
INSERT [dbo].[Phong] ([maPhong], [maLoaiPhong], [tenPhong], [tang], [tinhTrang], [ghiChu], [soNguoiHienTai]) VALUES (N'PH000020', N'LP000005', N'Phòng 20', 4, 0, NULL, 0)
INSERT [dbo].[Phong] ([maPhong], [maLoaiPhong], [tenPhong], [tang], [tinhTrang], [ghiChu], [soNguoiHienTai]) VALUES (N'PH000021', N'LP000006', N'Phòng 21', 4, 1, NULL, 0)
INSERT [dbo].[Phong] ([maPhong], [maLoaiPhong], [tenPhong], [tang], [tinhTrang], [ghiChu], [soNguoiHienTai]) VALUES (N'PH000022', N'LP000005', N'Phòng 22', 5, 0, NULL, 0)
INSERT [dbo].[Phong] ([maPhong], [maLoaiPhong], [tenPhong], [tang], [tinhTrang], [ghiChu], [soNguoiHienTai]) VALUES (N'PH000023', N'LP000005', N'Phòng 23', 5, 0, NULL, 0)
INSERT [dbo].[Phong] ([maPhong], [maLoaiPhong], [tenPhong], [tang], [tinhTrang], [ghiChu], [soNguoiHienTai]) VALUES (N'PH000024', N'LP000006', N'Phòng 24', 3, 1, NULL, 0)
INSERT [dbo].[Phong] ([maPhong], [maLoaiPhong], [tenPhong], [tang], [tinhTrang], [ghiChu], [soNguoiHienTai]) VALUES (N'PH000025', N'LP000003', N'Phòng 25', 1, 1, NULL, 0)
INSERT [dbo].[Phong] ([maPhong], [maLoaiPhong], [tenPhong], [tang], [tinhTrang], [ghiChu], [soNguoiHienTai]) VALUES (N'PH000026', N'LP000006', N'Phòng 26', 3, 0, NULL, 0)
INSERT [dbo].[Phong] ([maPhong], [maLoaiPhong], [tenPhong], [tang], [tinhTrang], [ghiChu], [soNguoiHienTai]) VALUES (N'PH000027', N'LP000001', N'Phòng 27', 2, 0, NULL, 0)
INSERT [dbo].[Phong] ([maPhong], [maLoaiPhong], [tenPhong], [tang], [tinhTrang], [ghiChu], [soNguoiHienTai]) VALUES (N'PH000028', N'LP000004', N'Phòng 28', 4, 0, NULL, 0)
INSERT [dbo].[Phong] ([maPhong], [maLoaiPhong], [tenPhong], [tang], [tinhTrang], [ghiChu], [soNguoiHienTai]) VALUES (N'PH000029', N'LP000005', N'Phòng 29', 6, 0, NULL, 0)
INSERT [dbo].[Phong] ([maPhong], [maLoaiPhong], [tenPhong], [tang], [tinhTrang], [ghiChu], [soNguoiHienTai]) VALUES (N'PH000030', N'LP000002', N'Phòng 30', 4, 1, NULL, 0)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000001', N'NV000001', 1, NULL, 0)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000002', N'NV000001', 1, NULL, 0)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000003', N'NV000001', 1, NULL, 0)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000004', N'NV000001', 1, NULL, 1)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000005', N'NV000001', 1, NULL, 1)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000007', N'NV000001', 1, NULL, 1)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000008', N'NV000001', 1, NULL, 0)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000009', N'NV000001', 1, NULL, 0)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000010', N'NV000001', 1, NULL, 1)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000011', N'NV000001', 2, N'D000002', 1)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000012', N'NV000001', 1, NULL, 1)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000013', N'NV000001', 1, NULL, 1)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000014', N'NV000001', 1, NULL, 1)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000015', N'NV000001', 1, NULL, 1)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000016', N'NV000001', 2, N'D000002', 1)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000018', N'NV000001', 1, N'D000003', 1)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000019', N'NV000001', 3, N'D000004', 1)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000020', N'NV000001', 5, N'D000005', 1)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000021', N'NV000001', 5, N'D000006', 1)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000022', N'NV000001', 2, N'D000007', 1)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000023', N'NV000001', 3, N'D000001', 1)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000025', N'NV000001', 4, N'D000003', 1)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000026', N'NV000001', 1, NULL, 1)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000031', N'NV000001', 1, NULL, 1)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000035', N'NV000001', 4, N'D000001', 1)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000036', N'NV000001', 4, N'D000001', 1)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000037', N'NV000001', 3, N'D000001', 1)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000038', N'NV000001', 4, N'D000001', 1)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000039', N'NV000001', 2, N'D000001', 1)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000040', N'NV000001', 2, N'D000001', 1)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000041', N'NV000001', 2, N'D000001', 1)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000042', N'NV000001', 1, NULL, 1)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000043', N'NV000001', 2, N'D000001', 1)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000044', N'NV000001', 1, NULL, 1)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000045', N'NV000001', 1, NULL, 1)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000046', N'NV000001', 2, N'D000001', 1)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000047', N'NV000001', 4, N'D000001', 1)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000048', N'NV000001', 1, NULL, 1)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000049', N'NV000001', 1, NULL, 1)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000050', N'NV000001', 1, NULL, 1)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000051', N'NV000001', 4, N'D000001', 1)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000052', N'NV000001', 1, NULL, 1)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000053', N'NV000001', 1, NULL, 1)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000054', N'NV000001', 1, NULL, 1)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000055', N'NV000001', 1, NULL, 1)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000056', N'NV000001', 1, NULL, 0)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000057', N'NV000001', 1, NULL, 1)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000058', N'NV000001', 1, NULL, 1)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000059', N'NV000001', 1, NULL, 0)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000060', N'NV000001', 1, NULL, 1)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000061', N'NV000001', 1, NULL, 1)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000062', N'NV000001', 1, NULL, 1)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000063', N'NV000001', 1, NULL, 1)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000064', N'NV000001', 1, NULL, 1)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000065', N'NV000001', 1, NULL, 1)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000066', N'NV000001', 1, NULL, 1)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000067', N'NV000001', 1, NULL, 1)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000068', N'NV000001', 1, NULL, 1)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000069', N'NV000001', 1, NULL, 1)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000070', N'NV000001', 1, NULL, 1)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000071', N'NV000001', 1, NULL, 1)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000072', N'NV000001', 1, NULL, 1)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000073', N'NV000001', 1, NULL, 0)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000074', N'NV000001', 3, N'D000001', 1)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000075', N'NV000001', 1, N'D000001', 1)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000076', N'NV000001', 1, N'D000001', 1)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000077', N'NV000001', 1, N'D000001', 0)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000078', N'NV000001', 1, NULL, 1)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000079', N'NV000001', 1, NULL, 1)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000080', N'NV000001', 1, NULL, 0)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000081', N'NV000001', 1, NULL, 0)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000082', N'NV000001', 2, N'D000001', 0)
INSERT [dbo].[ThuePhong] ([maThue], [maNV], [soLuongPhong], [maDoan], [trangThai]) VALUES (N'TP000083', N'NV000001', 1, NULL, 0)
ALTER TABLE [dbo].[ChiTietDichVu]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietDichVu_ChiTietThuePhong] FOREIGN KEY([maThue], [maKhach], [maPhong])
REFERENCES [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong])
GO
ALTER TABLE [dbo].[ChiTietDichVu] CHECK CONSTRAINT [FK_ChiTietDichVu_ChiTietThuePhong]
GO
ALTER TABLE [dbo].[ChiTietDichVu]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietDichVu_DichVu] FOREIGN KEY([maDV])
REFERENCES [dbo].[DichVu] ([maDV])
GO
ALTER TABLE [dbo].[ChiTietDichVu] CHECK CONSTRAINT [FK_ChiTietDichVu_DichVu]
GO
ALTER TABLE [dbo].[ChiTietThuePhong]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietThuePhong_KhachHang] FOREIGN KEY([maKhach])
REFERENCES [dbo].[KhachHang] ([maKH])
GO
ALTER TABLE [dbo].[ChiTietThuePhong] CHECK CONSTRAINT [FK_ChiTietThuePhong_KhachHang]
GO
ALTER TABLE [dbo].[ChiTietThuePhong]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietThuePhong_Phong] FOREIGN KEY([maPhong])
REFERENCES [dbo].[Phong] ([maPhong])
GO
ALTER TABLE [dbo].[ChiTietThuePhong] CHECK CONSTRAINT [FK_ChiTietThuePhong_Phong]
GO
ALTER TABLE [dbo].[ChiTietThuePhong]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietThuePhong_ThuePhong] FOREIGN KEY([maThue])
REFERENCES [dbo].[ThuePhong] ([maThue])
GO
ALTER TABLE [dbo].[ChiTietThuePhong] CHECK CONSTRAINT [FK_ChiTietThuePhong_ThuePhong]
GO
ALTER TABLE [dbo].[HoaDonDichVu]  WITH CHECK ADD  CONSTRAINT [FK_HoaDonDichVu_ChiTietThuePhong1] FOREIGN KEY([maThue], [maKhach], [maPhong])
REFERENCES [dbo].[ChiTietThuePhong] ([maThue], [maKhach], [maPhong])
GO
ALTER TABLE [dbo].[HoaDonDichVu] CHECK CONSTRAINT [FK_HoaDonDichVu_ChiTietThuePhong1]
GO
ALTER TABLE [dbo].[HoaDonTienPhong]  WITH CHECK ADD  CONSTRAINT [FK_HoaDonTienPhong_ThuePhong] FOREIGN KEY([maThue])
REFERENCES [dbo].[ThuePhong] ([maThue])
GO
ALTER TABLE [dbo].[HoaDonTienPhong] CHECK CONSTRAINT [FK_HoaDonTienPhong_ThuePhong]
GO
ALTER TABLE [dbo].[Phong]  WITH CHECK ADD  CONSTRAINT [FK_Phong_LoaiPhong] FOREIGN KEY([maLoaiPhong])
REFERENCES [dbo].[LoaiPhong] ([maLoaiPhong])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Phong] CHECK CONSTRAINT [FK_Phong_LoaiPhong]
GO
ALTER TABLE [dbo].[ThuePhong]  WITH CHECK ADD  CONSTRAINT [FK_ThuePhong_Doan] FOREIGN KEY([maDoan])
REFERENCES [dbo].[Doan] ([maDoan])
GO
ALTER TABLE [dbo].[ThuePhong] CHECK CONSTRAINT [FK_ThuePhong_Doan]
GO
ALTER TABLE [dbo].[ThuePhong]  WITH CHECK ADD  CONSTRAINT [FK_ThuePhong_NhanVien] FOREIGN KEY([maNV])
REFERENCES [dbo].[NhanVien] ([maNV])
GO
ALTER TABLE [dbo].[ThuePhong] CHECK CONSTRAINT [FK_ThuePhong_NhanVien]
GO
USE [master]
GO
ALTER DATABASE [KhachSan] SET  READ_WRITE 
GO
