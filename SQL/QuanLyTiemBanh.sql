CREATE DATABASE BakeryHub
GO
USE BakeryHub
GO


-- =============================================
-- 1. TẠO CẤU TRÚC BẢNG
-- =============================================

-- 1. Bảng Nhân Viên
CREATE TABLE NhanVien(
    MaNhanVien nvarchar(5) primary key,
    MatKhau varchar(50) not null,
    HoTen nvarchar(100) not null,
    Quyen varchar(20) not null CHECK(Quyen IN ('Admin', 'NhanVien'))
)
GO

-- 2. Bảng Danh Mục
CREATE TABLE DanhMuc(
    MaDanhMuc int primary key identity(1,1),
    TenDanhMuc nvarchar(100) not null unique
)
GO

-- 3. Bảng Sản Phẩm (Đã tích hợp GiaNhap và TrangThai)
CREATE TABLE SanPham(
    MaSanPham varchar(20) primary key,
    TenSanPham nvarchar(100) not null,
    DonGia decimal(18,0) not null,
    GiaNhap decimal(18,0) DEFAULT 0,  -- Tích hợp sẵn
    HinhAnh varchar(255),
    SoLuongTon int DEFAULT 0,
    TrangThai bit DEFAULT 1,          -- Tích hợp sẵn (1: Đang bán, 0: Ngừng bán)
    MaDanhMuc int not null,
    foreign key (MaDanhMuc) references DanhMuc(MaDanhMuc)
)
GO

-- 4. Bảng Hóa Đơn
CREATE TABLE HoaDon(
    MaHoaDon int primary key identity(1,1),
    NgayBan datetime default getdate(),
    TongTien decimal(18,0) not null,
    MaNhanVien nvarchar(5) not null,
    foreign key (MaNhanVien) references NhanVien(MaNhanVien)
)
GO

-- 5. Bảng Chi Tiết Hóa Đơn
CREATE TABLE ChiTietHoaDon(
    MaChiTietHoaDon int primary key identity(1,1),
    MaHoaDon int not null,
    MaSanPham varchar(20) not null,
    SoLuong int not null,
    DonGia decimal(18,0) not null,
    foreign key(MaHoaDon) references HoaDon(MaHoaDon),
    foreign key(MaSanPham) references SanPham(MaSanPham)
)
GO

-- 6. Bảng Phiếu Nhập Kho
CREATE TABLE PhieuNhapKho(
    MaPhieuNhapKho int primary key identity(1,1),
    NgayNhap datetime default getdate(),
    NhaCungCap nvarchar(200),
    MaNhanVien nvarchar(5) not null,
    foreign key (MaNhanVien) references NhanVien(MaNhanVien)
)
GO

-- 7. Bảng Chi Tiết Nhập Kho (Đã tích hợp HanSuDung)
CREATE TABLE ChiTietPhieuNhapKho(
    MaChiTietPhieuNhapKho int primary key identity(1,1),
    MaPhieuNhapKho int not null,
    MaSanPham varchar(20) not null,
    SoLuong int not null,
    DonGiaNhap decimal(18,0) not null,
    HanSuDung date,                   -- Tích hợp sẵn
    foreign key (MaPhieuNhapKho) references PhieuNhapKho(MaPhieuNhapKho),
    foreign key (MaSanPham) references SanPham(MaSanPham)
)
GO

-- 8. Bảng Lô Hàng
CREATE TABLE LoHang (
    MaLo INT IDENTITY(1,1) PRIMARY KEY,
    MaSanPham VARCHAR(20) NOT NULL,
    NgayNhap DATE DEFAULT GETDATE(),
    HanSuDung DATE NOT NULL,
    SoLuongNhap INT NOT NULL,
    SoLuongHienTai INT NOT NULL,
    FOREIGN KEY (MaSanPham) REFERENCES SanPham(MaSanPham)
)
GO

alter table LoHang
add MucGiamGia int default 0;

-- 9. Bảng Phiếu Hủy
CREATE TABLE PhieuHuy (
    MaPhieuHuy INT PRIMARY KEY IDENTITY(1,1),
    NgayHuy DATETIME DEFAULT GETDATE(),
    LyDo NVARCHAR(MAX),
    MaNhanVien NVARCHAR(5) NOT NULL,
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien)
)
GO

-- 10. Bảng Chi Tiết Hủy 
CREATE TABLE ChiTietPhieuHuy (
    MaChiTietHuy INT PRIMARY KEY IDENTITY(1,1),
    MaPhieuHuy INT NOT NULL,
    MaSanPham VARCHAR(20) NOT NULL,
    SoLuongHuy INT NOT NULL,
    FOREIGN KEY (MaPhieuHuy) REFERENCES PhieuHuy(MaPhieuHuy),
    FOREIGN KEY (MaSanPham) REFERENCES SanPham(MaSanPham)
)
GO
-- =============================================
-- 2. TẠO TRIGGER TỰ ĐỘNG ĐỒNG BỘ (QUAN TRỌNG)
-- =============================================
CREATE TRIGGER TRG_UpdateTonKhoTong
ON LoHang
AFTER UPDATE, INSERT, DELETE
AS
BEGIN
    UPDATE SanPham
    SET SoLuongTon = (SELECT ISNULL(SUM(SoLuongHienTai), 0) FROM LoHang WHERE LoHang.MaSanPham = SanPham.MaSanPham)
    WHERE MaSanPham IN (SELECT MaSanPham FROM inserted UNION SELECT MaSanPham FROM deleted);
END
GO

-- =============================================
-- 3. NHẬP NHÂN VIÊN & DANH MỤC
-- =============================================
INSERT INTO NhanVien VALUES
('admin', 'admin123', N'Trần Bình Trọng', 'Admin'),
('nv01', '123', N'Tống Thành Vinh', 'NhanVien'),
('nv02', '123', N'Nguyễn Minh Tú', 'NhanVien'),
('nv03', '123', N'Minh Triết', 'NhanVien'),
('nv04', '123', N'Thanh Tiến', 'NhanVien');

INSERT INTO DanhMuc (TenDanhMuc) VALUES (N'BÁNH MÌ – BÁNH NGỌT'),
(N'BÁNH CAKE & DESSERT ĐÓNG GÓI'),
(N'BÁNH QUY – MOCHI – SNACK'),
(N'KẸO – CHOCOLATE'),
(N'ĐỒ UỐNG ĐÓNG CHAI / LON');

-- =============================================
-- 4. NHẬP SẢN PHẨM (Tồn kho khởi tạo = 0)
-- =============================================
INSERT INTO SanPham (MaSanPham, TenSanPham, DonGia, MaDanhMuc, SoLuongTon, TrangThai, HinhAnh) VALUES
('SP001', N'Bánh mì sandwich đóng gói', 18000, 1, 0, 1, ''),
('SP002', N'Bánh croissant làm sẵn', 22000, 1, 0, 1, ''),
('SP003', N'Bánh sừng bò nhân phô mai', 25000, 1, 0, 1, ''),
('SP004', N'Danish trái cây / custard', 28000, 1, 0, 1, ''),
('SP005', N'Bánh bông lan mini', 12000, 1, 0, 1, ''),
('SP006', N'Bông lan cuộn', 35000, 1, 0, 1, ''),
('SP007', N'Bánh su kem đóng hộp', 30000, 1, 0, 1, ''),
('SP008', N'Bánh Choco Pie / Bánh mềm', 45000, 1, 0, 1, ''),
('SP009', N'Tiramisu mini', 40000, 2, 0, 1, ''),
('SP010', N'Bánh Mousse mini', 45000, 2, 0, 1, ''),
('SP011', N'Pudding ly', 25000, 2, 0, 1, ''),
('SP012', N'Rau câu ly', 15000, 2, 0, 1, ''),
('SP013', N'Caramen hộp', 20000, 2, 0, 1, ''),
('SP014', N'Bánh quy bơ', 35000, 3, 0, 1, ''),
('SP015', N'Bánh quy Socola chip', 38000, 3, 0, 1, ''),
('SP016', N'Mochi đóng gói (Nhiều vị)', 55000, 3, 0, 1, ''),
('SP017', N'Snack cao cấp (Thái Lan)', 42000, 3, 0, 1, ''),
('SP018', N'Bánh gạo Hàn Quốc', 30000, 3, 0, 1, ''),
('SP019', N'Hạt rang (Hạnh nhân/Hạt điều)', 65000, 3, 0, 1, ''),
('SP020', N'Kẹo dẻo trái cây', 15000, 4, 0, 1, ''),
('SP021', N'Kẹo cứng bạc hà', 10000, 4, 0, 1, ''),
('SP022', N'Chocolate thanh', 25000, 4, 0, 1, ''), 
('SP023', N'Chocolate hộp nhỏ', 80000, 4, 0, 1, ''),
('SP024', N'Trà sữa đóng chai', 30000, 5, 0, 1, ''),
('SP025', N'Trà trái cây nhiệt đới', 32000, 5, 0, 1, ''),
('SP026', N'Cà phê lon / Cold Brew', 20000, 5, 0, 1, ''),
('SP027', N'Sữa chua uống', 18000, 5, 0, 1, ''),
('SP028', N'Nước trái cây ép', 25000, 5, 0, 1, '');
GO


UPDATE SanPham SET HinhAnh = 'sandwich_dong_goi.jpg' WHERE MaSanPham = 'SP001';
UPDATE SanPham SET HinhAnh = 'croissant_lam_san.jpg' WHERE MaSanPham = 'SP002';
UPDATE SanPham SET HinhAnh = 'croissant_pho_mai.jpg' WHERE MaSanPham = 'SP003';
UPDATE SanPham SET HinhAnh = 'custard.jpg' WHERE MaSanPham = 'SP004';
UPDATE SanPham SET HinhAnh = 'bong_lan_mini.jpg' WHERE MaSanPham = 'SP005';
UPDATE SanPham SET HinhAnh = 'bong_lan_cuon.jpg' WHERE MaSanPham = 'SP006';
UPDATE SanPham SET HinhAnh = 'su_kem_dong_hop.jpg' WHERE MaSanPham = 'SP007';
UPDATE SanPham SET HinhAnh = 'chocopie.jpg' WHERE MaSanPham = 'SP008';
UPDATE SanPham SET HinhAnh = 'tiramisu.jpg' WHERE MaSanPham = 'SP009';
UPDATE SanPham SET HinhAnh = 'mousse_chanh_dayd.jpg' WHERE MaSanPham = 'SP010';
UPDATE SanPham SET HinhAnh = 'pudding.jpg' WHERE MaSanPham = 'SP011';
UPDATE SanPham SET HinhAnh = 'rau_cau.jpg' WHERE MaSanPham = 'SP012';
UPDATE SanPham SET HinhAnh = 'caramen_hop.jpg' WHERE MaSanPham = 'SP013';
UPDATE SanPham SET HinhAnh = 'banh_quy_bo.jpg' WHERE MaSanPham = 'SP014';
UPDATE SanPham SET HinhAnh = 'banh_quy_socola.jpg' WHERE MaSanPham = 'SP015';
UPDATE SanPham SET HinhAnh = 'mochi_dong_goi.jpg' WHERE MaSanPham = 'SP016';
UPDATE SanPham SET HinhAnh = 'snack_thai.jpg' WHERE MaSanPham = 'SP017';
UPDATE SanPham SET HinhAnh = 'banh_gao_han_quoc.jpg' WHERE MaSanPham = 'SP018';
UPDATE SanPham SET HinhAnh = 'hat_rang.jpg' WHERE MaSanPham = 'SP019';
UPDATE SanPham SET HinhAnh = 'keo_deo_trai_cay.jpg' WHERE MaSanPham = 'SP020';
UPDATE SanPham SET HinhAnh = 'keo_cung_bac_ha.jpg' WHERE MaSanPham = 'SP021';
UPDATE SanPham SET HinhAnh = 'keo_socola_thanh.jpg' WHERE MaSanPham = 'SP022';
UPDATE SanPham SET HinhAnh = 'chocolate_hop.jpg' WHERE MaSanPham = 'SP023';
UPDATE SanPham SET HinhAnh = 'tra_sua_dong_chai.jpg' WHERE MaSanPham = 'SP024';
UPDATE SanPham SET HinhAnh = 'tra_trai_cay.jpg' WHERE MaSanPham = 'SP025';
UPDATE SanPham SET HinhAnh = 'coldbrew.jpg' WHERE MaSanPham = 'SP026';
UPDATE SanPham SET HinhAnh = 'sua_chua_uong.jpg' WHERE MaSanPham = 'SP027';
UPDATE SanPham SET HinhAnh = 'nuoc_trai_cay_ep.jpg' WHERE MaSanPham = 'SP028';

-- =============================================
-- 5. NHẬP DỮ LIỆU LÔ HÀNG (Tự động cập nhật tồn kho)
-- =============================================
-- Nhập kho mẫu cho tất cả 28 sản phẩm
INSERT INTO LoHang (MaSanPham, NgayNhap, HanSuDung, SoLuongNhap, SoLuongHienTai) VALUES
('SP001', GETDATE(), '2026-05-01', 50, 50),
('SP002', GETDATE(), '2026-04-20', 30, 30),
('SP003', GETDATE(), '2026-05-10', 25, 25),
('SP004', GETDATE(), '2026-05-10', 20, 20),
('SP005', GETDATE(), '2026-05-05', 60, 60),
('SP006', GETDATE(), '2026-05-05', 40, 40),
('SP007', GETDATE(), '2026-04-25', 35, 35),
('SP008', GETDATE(), '2026-06-15', 50, 50),
('SP009', GETDATE(), '2026-04-18', 15, 15),
('SP010', GETDATE(), '2026-04-18', 15, 15),
('SP011', GETDATE(), '2026-05-20', 30, 30), 
('SP012', GETDATE(), '2026-05-25', 40, 40), 
('SP013', GETDATE(), '2026-05-25', 35, 35),
('SP014', GETDATE(), '2026-07-01', 100, 100),
('SP015', GETDATE(), '2026-07-01', 80, 80),
('SP016', GETDATE(), '2026-08-01', 40, 40), 
('SP017', GETDATE(), '2026-04-18', 60, 60), 
('SP018', GETDATE(), '2026-08-10', 50, 50), 
('SP019', GETDATE(), '2026-09-01', 45, 45),
('SP020', GETDATE(), '2026-12-01', 120, 120), 
('SP021', GETDATE(), '2026-12-31', 150, 150), 
('SP022', GETDATE(), '2026-10-01', 70, 70),
('SP023', GETDATE(), '2026-11-01', 20, 20),
('SP024', GETDATE(), '2026-06-01', 50, 50), 
('SP025', GETDATE(), '2026-06-01', 40, 40), 
('SP026', GETDATE(), '2026-06-10', 60, 60), 
('SP027', GETDATE(), '2026-06-05', 45, 45), 
('SP028', GETDATE(), '2026-06-05', 30, 30);
GO

PRINT N'✅ Đã khởi tạo BakeryHub thành công! Tồn kho đã được đồng bộ tự động từ Lô hàng.';

select * from NhanVien;
select * from DanhMuc;
select * from SanPham;
select * from PhieuNhapKho;
select * from ChiTietPhieuNhapKho;
select * from HoaDon;
select * from ChiTietHoaDon;
select * from LoHang;
select * from PhieuHuy;
select * from ChiTietPhieuHuy;



/*
/* ==================================================
   SCRIPT XÓA TOÀN BỘ DỮ LIỆU & RESET BỘ ĐẾM
   (Dùng khi muốn nhập lại dữ liệu mới từ đầu)
   ================================================== */

-- 1. XÓA BẢNG CHI TIẾT (Bảng con thấp nhất - Xóa trước)
DELETE FROM ChiTietHoaDon;
DELETE FROM ChiTietPhieuNhapKho;

-- 2. XÓA BẢNG GIAO DỊCH (Bảng cha của chi tiết)
DELETE FROM HoaDon;
DELETE FROM PhieuNhapKho;

-- 3. XÓA BẢNG DỮ LIỆU CHÍNH (Hàng hóa, Danh mục - Xóa sau cùng)
-- Lưu ý: Phải xóa SanPham trước DanhMuc
DELETE FROM SanPham;
DELETE FROM DanhMuc;

-- 4. XÓA NHÂN VIÊN (Bảng gốc rễ)
-- Chỉ xóa nếu bạn muốn tạo lại cả Admin. Nếu muốn giữ Admin thì comment dòng này lại.
DELETE FROM NhanVien; 


-- ==================================================
-- 5. RESET BỘ ĐẾM SỐ TỰ ĐỘNG (IDENTITY) VỀ 0
-- (Để lần nhập tiếp theo Mã sẽ bắt đầu lại từ 1)
-- ==================================================

-- Reset Hóa đơn
DBCC CHECKIDENT ('HoaDon', RESEED, 0);
DBCC CHECKIDENT ('ChiTietHoaDon', RESEED, 0);

-- Reset Nhập kho
DBCC CHECKIDENT ('PhieuNhapKho', RESEED, 0);
DBCC CHECKIDENT ('ChiTietPhieuNhapKho', RESEED, 0);

-- Reset Danh mục
DBCC CHECKIDENT ('DanhMuc', RESEED, 0);

-- (NhanVien và SanPham dùng mã chữ tự nhập nên không cần reset)

PRINT N'✅ Đã xóa sạch dữ liệu và reset hệ thống về trạng thái ban đầu!';
GO
*/