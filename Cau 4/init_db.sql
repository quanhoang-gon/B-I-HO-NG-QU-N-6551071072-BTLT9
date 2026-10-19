USE master;
GO

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'QL_TraSua')
BEGIN
    CREATE DATABASE QL_TraSua;
END
GO

USE QL_TraSua;
GO

IF OBJECT_ID('dbo.ChiTietHoaDon', 'U') IS NOT NULL DROP TABLE dbo.ChiTietHoaDon;
IF OBJECT_ID('dbo.HoaDon', 'U') IS NOT NULL DROP TABLE dbo.HoaDon;
IF OBJECT_ID('dbo.Mon', 'U') IS NOT NULL DROP TABLE dbo.Mon;
IF OBJECT_ID('dbo.DanhMucMon', 'U') IS NOT NULL DROP TABLE dbo.DanhMucMon;
GO

CREATE TABLE dbo.DanhMucMon (
    MaDM INT IDENTITY(1,1) PRIMARY KEY,
    TenDM NVARCHAR(50) NOT NULL
);
GO

CREATE TABLE dbo.Mon (
    MaMon INT IDENTITY(1,1) PRIMARY KEY,
    TenMon NVARCHAR(100) NOT NULL,
    MaDM INT NOT NULL FOREIGN KEY REFERENCES dbo.DanhMucMon(MaDM),
    GiaBan DECIMAL(18,0) NOT NULL,
    DangBan BIT NOT NULL DEFAULT 1
);
GO

CREATE TABLE dbo.HoaDon (
    MaHD INT IDENTITY(1,1) PRIMARY KEY,
    GioLap DATETIME NOT NULL DEFAULT GETDATE(),
    HinhThuc NVARCHAR(20) NOT NULL, -- 'Tiền mặt' / 'Chuyển khoản'
    TongTien DECIMAL(18,0) NOT NULL,
    DaThanhToan BIT NOT NULL DEFAULT 1
);
GO

CREATE TABLE dbo.ChiTietHoaDon (
    MaHD INT NOT NULL FOREIGN KEY REFERENCES dbo.HoaDon(MaHD),
    MaMon INT NOT NULL FOREIGN KEY REFERENCES dbo.Mon(MaMon),
    SoLy INT NOT NULL,
    DonGia DECIMAL(18,0) NOT NULL,
    PRIMARY KEY (MaHD, MaMon)
);
GO

-- Chèn 4 danh mục
INSERT INTO dbo.DanhMucMon (TenDM) VALUES
(N'Trà sữa truyền thống'),
(N'Trà trái cây'),
(N'Đá xay & Sinh tố'),
(N'Topping thêm');
GO

-- Chèn 12 món
INSERT INTO dbo.Mon (TenMon, MaDM, GiaBan, DangBan) VALUES
(N'Trà sữa Trân châu đường đen', 1, 35000, 1),
(N'Trà sữa Oolong nướng', 1, 38000, 1),
(N'Trà sữa Khoai môn', 1, 35000, 1),
(N'Trà đào cam sả', 2, 40000, 1),
(N'Trà vải hoa hồng', 2, 42000, 1),
(N'Trà dâu tằm tuyết nhĩ', 2, 45000, 1),
(N'Matcha đá xay kem cheese', 3, 48000, 1),
(N'Chocolate đá xay hạnh nhân', 3, 50000, 1),
(N'Sinh tố bơ sầu riêng', 3, 55000, 1),
(N'Trân châu hoàng kim', 4, 8000, 1),
(N'Thạch củ năng', 4, 10000, 1),
(N'Pudding trứng', 4, 10000, 1);
GO

-- Chèn sẵn vài hóa đơn mẫu
INSERT INTO dbo.HoaDon (GioLap, HinhThuc, TongTien, DaThanhToan) VALUES
(DATEADD(hour, -2, GETDATE()), N'Tiền mặt', 73000, 1),
(DATEADD(hour, -1, GETDATE()), N'Chuyển khoản', 88000, 1);
GO

INSERT INTO dbo.ChiTietHoaDon (MaHD, MaMon, SoLy, DonGia) VALUES
(1, 1, 1, 35000),
(1, 2, 1, 38000),
(2, 4, 1, 40000),
(2, 7, 1, 48000);
GO
