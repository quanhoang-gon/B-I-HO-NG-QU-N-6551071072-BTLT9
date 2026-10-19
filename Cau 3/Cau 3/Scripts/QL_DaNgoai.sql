-- Tạo CSDL QL_DaNgoai nếu chưa tồn tại
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'QL_DaNgoai')
BEGIN
    CREATE DATABASE QL_DaNgoai;
END
GO

USE QL_DaNgoai;
GO

-- Xóa bảng ChuyenDi nếu đã tồn tại
IF OBJECT_ID(N'dbo.ChuyenDi', N'U') IS NOT NULL
BEGIN
    DROP TABLE dbo.ChuyenDi;
END
GO

-- Tạo bảng ChuyenDi
CREATE TABLE dbo.ChuyenDi (
    MaChuyen INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    TenChuyen NVARCHAR(100) NOT NULL,
    DiaDiem NVARCHAR(100) NOT NULL,
    NgayDi DATE NOT NULL,
    SoNguoi INT NOT NULL DEFAULT 1,
    NganSach DECIMAL(18,0) NOT NULL DEFAULT 0,
    PhuongTien NVARCHAR(30) NOT NULL,
    DaHoanThanh BIT NOT NULL DEFAULT 0,
    GhiChu NVARCHAR(200) NULL
);
GO

-- Nhập sẵn 8 chuyến đi mẫu với ngày đi trải từ vài ngày đến vài tuần tới
INSERT INTO dbo.ChuyenDi (TenChuyen, DiaDiem, NgayDi, SoNguoi, NganSach, PhuongTien, DaHoanThanh, GhiChu)
VALUES
    (N'Khám phá xứ ngàn hoa Đà Lạt', N'Đà Lạt', CAST(DATEADD(day, 2, GETDATE()) AS DATE), 4, 6000000, N'Xe khách', 0, N'Check-in hồ Tuyền Lâm và đồi chè Cầu Đất'),
    (N'Tắm biển cuối tuần Vũng Tàu', N'Vũng Tàu', CAST(DATEADD(day, 1, GETDATE()) AS DATE), 5, 3500000, N'Ô tô', 0, N'Nghỉ dưỡng Bãi Sau, ăn hải sản'),
    (N'Săn mây Fansipan Sa Pa', N'Sa Pa', CAST(DATEADD(day, 5, GETDATE()) AS DATE), 2, 4500000, N'Tàu hỏa', 0, N'Chinh phục đỉnh Fansipan, thăm bản Cát Cát'),
    (N'Thăm phố cổ Hội An về đêm', N'Hội An', CAST(DATEADD(day, 6, GETDATE()) AS DATE), 3, 7000000, N'Xe khách', 0, N'Thả đèn hoa đăng sông Hoài'),
    (N'Nghỉ dưỡng biển ngọc Phú Quốc', N'Phú Quốc', CAST(DATEADD(day, 10, GETDATE()) AS DATE), 2, 12000000, N'Ô tô', 0, N'Lặn ngắm san hô Hòn Thơm'),
    (N'Khám phá danh thắng Tràng An', N'Ninh Bình', CAST(DATEADD(day, 8, GETDATE()) AS DATE), 6, 5000000, N'Xe khách', 0, N'Đi thuyền Tràng An và thăm chùa Bái Đính'),
    (N'Lặn biển ngắm san hô Nha Trang', N'Nha Trang', CAST(DATEADD(day, 14, GETDATE()) AS DATE), 4, 8500000, N'Tàu hỏa', 0, N'Thăm đảo Hòn Mun và Vinpearl'),
    (N'Mùa hoa cải trắng Mộc Châu', N'Mộc Châu', CAST(DATEADD(day, 25, GETDATE()) AS DATE), 4, 3000000, N'Xe máy', 0, N'Đi phượt đèo Thung Khe (ngày đi quá 16 ngày)');
GO

SELECT COUNT(*) AS TongSoChuyenDi FROM dbo.ChuyenDi;
GO
