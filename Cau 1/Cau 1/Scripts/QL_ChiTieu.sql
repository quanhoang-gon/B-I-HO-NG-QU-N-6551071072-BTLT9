-- Tạo CSDL QL_ChiTieu nếu chưa tồn tại
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'QL_ChiTieu')
BEGIN
    CREATE DATABASE QL_ChiTieu;
END
GO

USE QL_ChiTieu;
GO

-- Xóa bảng ChiTieu nếu đã tồn tại để tạo lại bảng sạch
IF OBJECT_ID(N'dbo.ChiTieu', N'U') IS NOT NULL
BEGIN
    DROP TABLE dbo.ChiTieu;
END
GO

-- Tạo bảng ChiTieu
CREATE TABLE dbo.ChiTieu (
    MaCT INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    NgayChi DATE NOT NULL,
    NoiDung NVARCHAR(100) NOT NULL,
    LoaiChi NVARCHAR(30) NOT NULL,
    SoTien DECIMAL(18,0) NOT NULL,
    GhiChu NVARCHAR(200) NULL
);
GO

-- Chèn dữ liệu mẫu (ít nhất 10 dòng đa dạng các loại chi)
INSERT INTO dbo.ChiTieu (NgayChi, NoiDung, LoaiChi, SoTien, GhiChu)
VALUES 
    (CAST(GETDATE() - 9 AS DATE), N'Ăn sáng phở bò Hà Nội', N'Ăn uống', 40000, N'Ăn quán gần nhà'),
    (CAST(GETDATE() - 9 AS DATE), N'Đổ xăng xe máy Wave Alpha', N'Đi lại', 70000, N'Đầy bình xăng'),
    (CAST(GETDATE() - 8 AS DATE), N'Mua sách Lập trình C# nâng cao', N'Học tập', 120000, N'Mua tại nhà sách Fahasa'),
    (CAST(GETDATE() - 7 AS DATE), N'Xem phim rạp CGV cuối tuần', N'Giải trí', 110000, N'Đi xem cùng bạn bè'),
    (CAST(GETDATE() - 6 AS DATE), N'Cà phê Highlands gặp bạn bè', N'Ăn uống', 45000, N'Freeze trà xanh size M'),
    (CAST(GETDATE() - 5 AS DATE), N'Mua vở ghi chép và bút viết', N'Học tập', 35000, N'Vở Campus và bút bi'),
    (CAST(GETDATE() - 4 AS DATE), N'Nạp thẻ xe buýt tháng 10', N'Đi lại', 100000, N'Vé liên tuyến sinh viên'),
    (CAST(GETDATE() - 3 AS DATE), N'Mua sạc điện thoại dự phòng', N'Khác', 250000, N'Bảo hành 12 tháng'),
    (CAST(GETDATE() - 2 AS DATE), N'Ăn trưa cơm tấm sườn trứng', N'Ăn uống', 35000, N'Quán quen gần trường'),
    (CAST(GETDATE() - 1 AS DATE), N'Cắt tóc gội đầu nam', N'Khác', 60000, N'Cắt tóc đầu tháng'),
    (CAST(GETDATE() AS DATE), N'Trà sữa Phúc Long', N'Giải trí', 55000, N'Trà đào cam sả'),
    (CAST(GETDATE() AS DATE), N'Bánh mì xíu mại chiều', N'Ăn uống', 20000, N'Ăn lót dạ buổi chiều');
GO

SELECT COUNT(*) AS TongSoDong FROM dbo.ChiTieu;
GO
