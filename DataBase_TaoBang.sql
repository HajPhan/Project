CREATE DATABASE BanHangDienThoai
GO

USE BanHangDienThoai
GO


-- |================================================> Tao Bang <======================================================|

-- Tao bang NHANVIEN
CREATE TABLE NHANVIEN
(
	MANV INT PRIMARY KEY IDENTITY(15150001,1),
	HOTEN NVARCHAR(250),
	NGAYSINH DATE,
	GT NCHAR(5),
	SDT NCHAR(50),
	MAIL NCHAR(250),
	DIACHI NVARCHAR(250),
	NGAYLAM DATETIME,
	IMAGES NVARCHAR(250),
	TRANGTHAI BIT DEFAULT 0
)
GO

-- Tao bang KHACHHANG
CREATE TABLE KHACHHANG
(
	MAKH INT PRIMARY KEY IDENTITY(12120001,1),
	TENKH NVARCHAR(50),
	NGAYSINH DATE,
	GT NCHAR(5),
	SDT INT,
	MAIL NCHAR(50),
	DIACHI NVARCHAR(100),
	NGAYDK DATETIME,
	TRANGTHAI BIT DEFAULT 0
)
GO

-- Tao bang NHACC
CREATE TABLE NHACC
(
	MACC INT PRIMARY KEY IDENTITY(13130001,1),
	TENCC NVARCHAR(100),
	DIACHI NVARCHAR(100),
	SDT INT,
	TRANGTHAI BIT DEFAULT 0
)
GO

-- Tao bang NHASX 
CREATE TABLE NHASX
(
	MASX INT PRIMARY KEY IDENTITY(14140001,1),
	TENSX NVARCHAR(50),
	QUOCGIA NVARCHAR(50),
	LOGO NVARCHAR(250),
	TRANGTHAI BIT DEFAULT 0
)
GO

-- Tao bang LOAISP 
CREATE TABLE LOAISP
(
	MALOAI INT PRIMARY KEY IDENTITY(10110001,1),
	TENLOAI NVARCHAR(50),
	DVT NCHAR(10),
	TRANGTHAI BIT DEFAULT 0
)
GO

-- Tao bang SANPHAM
CREATE TABLE SANPHAM
(
	MASP INT PRIMARY KEY IDENTITY(16160001,1),
	TENSP NVARCHAR(100),
	MASX INT,
	MALOAI INT,
	GIATHANH MONEY DEFAULT 0,
	IMAGES NVARCHAR(250),
	TRANGTHAI BIT DEFAULT 0
)
GO

-- Tao bang CTSP
CREATE TABLE CTSP
(
	MASP INT,
	DoPhanGiaiManHinh NVARCHAR(250),
	CameraTruoc NVARCHAR(250),
	CameraSau NVARCHAR(250),
	TocDoCpu NVARCHAR(250),
	SoNhan NVARCHAR(250),
	Chipset NVARCHAR(250),
	Ram NVARCHAR(250),
	Gpu NVARCHAR(250),
	Rom NVARCHAR(250),
	KichThuoc NVARCHAR(250),
	CongNgheManHinh NVARCHAR(250),
	MauManHinh NVARCHAR(250),
	ChuanManHinh NVARCHAR(250),
	CongNgheCamUng NVARCHAR(250),
	MatKinhManHinh NVARCHAR(250),
	VideoCall NVARCHAR(250),
	DoPhanGiaiTruoc NVARCHAR(250),
	ThongTinKhac NVARCHAR(250),
	DoPhanGiaiSau NVARCHAR(250),
	QuayPhim NVARCHAR(250),
	DenFlash NVARCHAR(250),
	ChupAnhNangCao NVARCHAR(250),
	DanhBaLuTru NVARCHAR(250),
	TheNhoNgoai NVARCHAR(250),
	HoTroTheNhoToiDa NVARCHAR(250),
	KieuDang NVARCHAR(250),
	ChatLieu NVARCHAR(250),
	Trongluong NVARCHAR(250),
	KhaNangChongNuoc NVARCHAR(250),
	LoaiPin NVARCHAR(250),
	DungLuongPin NVARCHAR(250),
	PinCoTheThaoRoi NVARCHAR(250),
	ThoGianCho NVARCHAR(250),
	ThoiGianDamThoai NVARCHAR(250),
	CheDoSac NVARCHAR(250),
	MangInternet NVARCHAR(250),
	Wifi NVARCHAR(250),
	HoTroSim NVARCHAR(250),
	KheCamSim NVARCHAR(250),
	CPS NVARCHAR(250),
	Bluetooth NVARCHAR(250),
	NFC NVARCHAR(250),
	KetNoiUsb NVARCHAR(250),
	CongKetNoiKhac NVARCHAR(250),
	CongSac NVARCHAR(250),
	JackTaiKhe NVARCHAR(250),
	XemPhim NVARCHAR(250),
	NgheNhac NVARCHAR(250),
	GhiAm NVARCHAR(250),
	FMRadio NVARCHAR(250),
	DenPin NVARCHAR(250),
	UngDungKhac NVARCHAR(250)
)
GO

-- Tao bang DONDH 
CREATE TABLE DONDH
(
	MADH INT PRIMARY KEY IDENTITY(17170001,1),
	MANV INT,
	MAKH INT,
	NGDH DATE
)
GO

-- Tao bang CTDH 
CREATE TABLE CTDH
(
	MADH INT PRIMARY KEY,
	MASP INT,
	SLDH INT DEFAULT 0
)
GO

-- Tao bang PHIEUNHAP 
CREATE TABLE PHIEUNHAP 
(
	MAPN INT PRIMARY KEY IDENTITY(18180001,1),
	MANV INT,
	NGAYNHAP DATE,
	MACC INT
)
GO

-- Tao bang CTPN 
CREATE TABLE CTPN
(
	MAPN INT PRIMARY KEY,
	MASP INT,
	SLN INT DEFAULT 0,
	DONGIA MONEY
)
GO

-- Tao bang PHIEUXUAT
CREATE TABLE PHIEUXUAT
(
	MAPX INT PRIMARY KEY IDENTITY(19190001,1),
	MANV INT,
	MAKH INT,
	MADH INT,
	NGAYXUAT DATE
)
GO

-- Tao bang CTPX 
CREATE TABLE CTPX
(
	MAPX INT PRIMARY KEY,
	MASP INT,
	SLX INT DEFAULT 0,
	PHANTRAM REAL DEFAULT 0,
	THANHTIEN MONEY DEFAULT 0
)
GO

-- Tao bang TONKHO
CREATE TABLE TONKHO
(
	MONTH_YEAR DATE,
	MASP INT,
	TONGSLD INT DEFAULT 0,
	TONGSLN INT DEFAULT 0,
	TONGSLX INT DEFAULT 0,
	TONGSLT AS TONGSLD+TONGSLN-TONGSLX,
	PRIMARY KEY(MONTH_YEAR,MASP)
)
GO


-- ===================================================================================================================
-- Tao bang TAIKHOAN
CREATE TABLE Account
(
	UserId INT PRIMARY KEY,
	USERNAME NVARCHAR(250),
	PASSWORDS NVARCHAR(250) DEFAULT '123456',
	ISADMIN BIT DEFAULT 0,
	ALLOWED BIT DEFAULT 0
)
GO

-- Tao cac bang PHANQUYEN

CREATE TABLE Business
(
	BusinessId NVARCHAR(350) PRIMARY KEY,
	BusinessName NVARCHAR(350),
	Descriptions NVARCHAR(350)
)
GO

CREATE TABLE Permission
(
	PermissionId INT PRIMARY KEY IDENTITY(1,1),
	PermissionName NVARCHAR(250),
	Descriptions NVARCHAR(250),
	BusinessId NVARCHAR(350)
)
GO

CREATE TABLE GrantPermission
(
	UserId INT,
	PermissionId INT
	PRIMARY KEY (UserId,PermissionId)
)
GO

CREATE TABLE PermissionAction
(
	PermissionId INT PRIMARY KEY,
	PermissionName NVARCHAR(250),
	Descriptions NVARCHAR(250),
	isGrant BIT DEFAULT 0
)
GO


CREATE TABLE ROLES
(
	ID NVARCHAR(250) PRIMARY KEY,
	NameId NVARCHAR(250),
	DISCRIPTION NVARCHAR(250)
)
GO
