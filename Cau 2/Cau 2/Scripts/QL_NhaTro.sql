-- Tạo CSDL QL_NhaTro nếu chưa tồn tại
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'QL_NhaTro')
BEGIN
    CREATE DATABASE QL_NhaTro;
END
GO

USE QL_NhaTro;
GO

-- Xóa bảng nếu đã tồn tại để tạo lại bảng sạch (chú ý thứ tự do có khóa ngoại)
IF OBJECT_ID(N'dbo.KhachThue', N'U') IS NOT NULL
BEGIN
    DROP TABLE dbo.KhachThue;
END
GO

IF OBJECT_ID(N'dbo.PhongTro', N'U') IS NOT NULL
BEGIN
    DROP TABLE dbo.PhongTro;
END
GO

-- 1. Bảng PhongTro
CREATE TABLE dbo.PhongTro (
    MaPhong INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    TenPhong NVARCHAR(20) NOT NULL,
    GiaThue DECIMAL(18,0) NOT NULL,
    TinhTrang NVARCHAR(20) NOT NULL -- 'Trống' / 'Đang thuê'
);
GO

-- 2. Bảng KhachThue
CREATE TABLE dbo.KhachThue (
    MaKhach INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    GioiTinh NVARCHAR(5) NOT NULL, -- 'Nam' / 'Nữ'
    NgaySinh DATE NOT NULL,
    SoDienThoai VARCHAR(15) NOT NULL,
    MaTinh INT NOT NULL,
    TenTinh NVARCHAR(100) NOT NULL,
    MaPhuongXa INT NOT NULL,
    TenPhuongXa NVARCHAR(100) NOT NULL,
    DaDangKyTamTru BIT NOT NULL DEFAULT 0,
    MaPhong INT NOT NULL,
    CONSTRAINT FK_KhachThue_PhongTro FOREIGN KEY (MaPhong) REFERENCES dbo.PhongTro(MaPhong) ON DELETE CASCADE
);
GO

-- Nhập sẵn 6 phòng trọ
INSERT INTO dbo.PhongTro (TenPhong, GiaThue, TinhTrang)
VALUES
    (N'Phòng 101', 2500000, N'Đang thuê'),
    (N'Phòng 102', 2500000, N'Trống'),
    (N'Phòng 201', 3000000, N'Đang thuê'),
    (N'Phòng 202', 3000000, N'Trống'),
    (N'Phòng 301', 3500000, N'Đang thuê'),
    (N'Phòng 302', 3500000, N'Trống');
GO

-- Nhập sẵn vài khách thuê
INSERT INTO dbo.KhachThue (HoTen, GioiTinh, NgaySinh, SoDienThoai, MaTinh, TenTinh, MaPhuongXa, TenPhuongXa, DaDangKyTamTru, MaPhong)
VALUES
    (N'Nguyễn Văn An', N'Nam', '2001-05-15', '0912345678', 1, N'Thành phố Hà Nội', 613, N'Phường Tây Tựu', 1, 1),
    (N'Trần Thị Mai', N'Nữ', '2002-09-20', '0987654321', 1, N'Thành phố Hà Nội', 619, N'Phường Phú Diễn', 1, 1),
    (N'Lê Hoàng Long', N'Nam', '1999-11-10', '0905112233', 48, N'Thành phố Đà Nẵng', 20206, N'Phường Hải Châu I', 0, 3),
    (N'Phạm Thu Hà', N'Nữ', '2003-03-25', '0934556677', 79, N'Thành phố Hồ Chí Minh', 26740, N'Phường Bến Nghé', 1, 5);
GO

SELECT COUNT(*) AS TongSoPhong FROM dbo.PhongTro;
SELECT COUNT(*) AS TongSoKhach FROM dbo.KhachThue;
GO
