USE baitap51;
GO

-- Tạo bảng lưu tài khoản đăng nhập (Cho Bài 4.1)
CREATE TABLE TaiKhoan (
    TenDangNhap NVARCHAR(50) PRIMARY KEY,
    MatKhau NVARCHAR(100) NOT NULL
);
GO

-- Thêm sẵn 1 tài khoản mẫu để test
INSERT INTO TaiKhoan (TenDangNhap, MatKhau) VALUES ('admin', '123456');
GO

-- Tạo bảng lưu thông tin đăng ký khóa học (Cho Bài 4.2)
CREATE TABLE DangKyKhoaHoc (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    HoTen NVARCHAR(100),
    SoDienThoai VARCHAR(20),
    NgaySinh DATE,
    KhoaHoc NVARCHAR(100)
);
GO