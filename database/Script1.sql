CREATE DATABASE CafePOSDB

USE CafePOSDB

CREATE TABLE BanAn
(
    MaBan INT IDENTITY(1,1) PRIMARY KEY,
    TenBan NVARCHAR(50) NOT NULL,
    TrangThai NVARCHAR(20) DEFAULT N'Trống'
)

CREATE TABLE DanhMuc
(
    MaDanhMuc INT IDENTITY(1,1) PRIMARY KEY,
    TenDanhMuc NVARCHAR(100) NOT NULL
)

CREATE TABLE MonAn
(
    MaMon INT IDENTITY(1,1) PRIMARY KEY,
    TenMon NVARCHAR(100) NOT NULL,
    MaDanhMuc INT,
    DonGia DECIMAL(18,2),

    CONSTRAINT FK_MonAn_DanhMuc
    FOREIGN KEY(MaDanhMuc)
    REFERENCES DanhMuc(MaDanhMuc)
)

CREATE TABLE HoaDon
(
    MaHoaDon INT IDENTITY(1,1) PRIMARY KEY,
    MaBan INT,

    GioVao DATETIME DEFAULT GETDATE(),
    GioRa DATETIME NULL,

    TongTien DECIMAL(18,2) DEFAULT 0,

    TrangThai BIT DEFAULT 0,

    CONSTRAINT FK_HoaDon_BanAn
    FOREIGN KEY(MaBan)
    REFERENCES BanAn(MaBan)
)

CREATE TABLE ChiTietHoaDon
(
    MaHoaDon INT,
    MaMon INT,
    SoLuong INT,
    DonGia DECIMAL(18,2),

    PRIMARY KEY(MaHoaDon, MaMon),

    FOREIGN KEY(MaHoaDon)
    REFERENCES HoaDon(MaHoaDon),

    FOREIGN KEY(MaMon)
    REFERENCES MonAn(MaMon)
)

INSERT INTO BanAn(TenBan)
VALUES
(N'Bàn 01'),
(N'Bàn 02'),
(N'Bàn 03'),
(N'Bàn 04'),
(N'Bàn 05')

INSERT INTO DanhMuc(TenDanhMuc)
VALUES
(N'Cà phê'),
(N'Trà sữa'),
(N'Đồ ăn nhẹ')

INSERT INTO MonAn(TenMon,MaDanhMuc,DonGia)
VALUES
(N'Cà phê đen',1,25000),
(N'Cà phê sữa',1,30000),
(N'Trà đào',2,35000),
(N'Trà sữa Matcha',2,45000),
(N'Bánh ngọt',3,20000)

SELECT * FROM DanhMuc

SELECT * FROM MonAn
WHERE MaDanhMuc=@madm

SELECT
m.TenMon,
ct.SoLuong,
ct.DonGia,
ct.SoLuong * ct.DonGia ThanhTien
FROM ChiTietHoaDon ct
INNER JOIN MonAn m
ON m.MaMon=ct.MaMon
WHERE ct.MaHoaDon=@MaHD

SELECT TOP 1 *
FROM HoaDon
WHERE MaBan=@MaBan
AND TrangThai=0

SELECT SCOPE_IDENTITY()

INSERT INTO ChiTietHoaDon
(
    MaHoaDon,
    MaMon,
    SoLuong,
    DonGia
)
VALUES
(
    @MaHD,
    @MaMon,
    @SoLuong,
    @DonGia
)

UPDATE BanAn
SET TrangThai=N'Có khách'
WHERE MaBan=@MaBan

UPDATE HoaDon
SET MaBan=@BanMoi
WHERE MaHoaDon=@MaHD

UPDATE BanAn
SET TrangThai=N'Trống'
WHERE MaBan=@BanCu

UPDATE BanAn
SET TrangThai=N'Có khách'
WHERE MaBan=@BanMoi

SELECT
SUM(SoLuong * DonGia)
FROM ChiTietHoaDon
WHERE MaHoaDon=@MaHD