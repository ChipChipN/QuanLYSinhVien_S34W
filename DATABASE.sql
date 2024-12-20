﻿CREATE DATABASE DOAN
USE DOAN

CREATE TABLE MONHOC
(
	MAMON INT IDENTITY(1,1) CONSTRAINT MONHOC_MAMON_PK PRIMARY KEY,
	TENMONHOC NVARCHAR(200),
)

INSERT INTO MONHOC (TENMONHOC) VALUES 
(N'Toán Học Đại Cương'),
(N'Lý Thuyết Xác Suất'),
(N'Lập Trình Căn Bản'),
(N'Cấu Trúc Dữ Liệu và Giải Thuật'),
(N'Cơ Sở Dữ Liệu'),
(N'Hệ Điều Hành'),
(N'Mạng Máy Tính'),
(N'Tin Học Văn Phòng'),
(N'Kỹ Thuật Phần Mềm'),
(N'Thương Mại Điện Tử');

CREATE TABLE GIAOVIEN( 
	MAGV INT IDENTITY(1,1) CONSTRAINT GIAOVIEN_MaGV_PK PRIMARY KEY,
	HOTEN NVARCHAR(50),
	GIOITINH NVARCHAR(3) CONSTRAINT SVIEN_GIOITINH_CK CHECK (GIOITINH IN ('Nam',N'Nữ')),
	NGAYSINH DATETIME,
	DIACHI NVARCHAR(50),
	SODT CHAR(10),
	EMAIL VARCHAR(50),
);


 INSERT INTO GIAOVIEN( HOTEN, GIOITINH, NGAYSINH, DIACHI, SODT, EMAIL) values (N'Trần Thị Liên',N'Nữ','1998-03-17',N'28 Nguyễn Văn Cừ, Quận 5, TP.HCM', '0935678923','lientran12@gmail.com');
 INSERT INTO GIAOVIEN( HOTEN, GIOITINH, NGAYSINH, DIACHI, SODT, EMAIL) values (N'Trần Thị Trà My',N'Nữ','1996-06-07',N'134 Nguyễn Văn Cừ, Quận 5, TP.HCM', '0956777231','tramydo178@gmail.com');
 INSERT INTO GIAOVIEN( HOTEN, GIOITINH, NGAYSINH, DIACHI, SODT, EMAIL) values (N'Hồ Tấn Phát','Nam','1995-05-27',N'124 Trường Chinh, Quận 12, TP.HCM', '0892236531','phathotk23@gmail.com');
 INSERT INTO GIAOVIEN( HOTEN, GIOITINH, NGAYSINH, DIACHI, SODT, EMAIL) values (N'Hồ Cẩm Vân',N'Nữ','1999-08-30',N'55 Âu Cơ, Quận 10, TP.HCM', '0789523421','vancamaz123@gmail.com');
 INSERT INTO GIAOVIEN( HOTEN, GIOITINH, NGAYSINH, DIACHI, SODT, EMAIL) values (N'Nguyễn Tùng Dương','Nam','1997-12-18',N'135 Cộng Hòa, Quận Tân Bình, TP.HCM', '0936163003','tungduongnab@gmail.com');
 INSERT INTO GIAOVIEN( HOTEN, GIOITINH, NGAYSINH, DIACHI, SODT, EMAIL) values (N'Hứa Văn Thịnh','Nam','1996-04-11',N'128 Trường Chinh, Quận 12, TP.HCM', '0234651231','vanthinhde3@gmail.com');
 INSERT INTO GIAOVIEN( HOTEN, GIOITINH, NGAYSINH, DIACHI, SODT, EMAIL) values (N'Lê Thị Ngọc Linh',N'Nữ','1993-05-27',N'11 Phan Văn Hớn, Quận 12, TP.HCM', '0232236531','linhng25@gmail.com');
 INSERT INTO GIAOVIEN( HOTEN, GIOITINH, NGAYSINH, DIACHI, SODT, EMAIL) values (N'Trần Ngọc Nhi ',N'Nữ','1994-12-27',N'138 Lê Đại Hành, Quận 11, TP.HCM', '0765213461','ngocnhilk25@gmail.com');
 INSERT INTO GIAOVIEN( HOTEN, GIOITINH, NGAYSINH, DIACHI, SODT, EMAIL) values (N'Bùi Anh Ninh','Nam','1994-04-18',N'135A Cộng Hòa, Quận Tân Bình, TP.HCM', '0930033616','aninhntd3@gmail.com');
 INSERT INTO GIAOVIEN( HOTEN, GIOITINH, NGAYSINH, DIACHI, SODT, EMAIL) values (N'Trần Thị Đào Trang',N'Nữ','1995-05-03',N'154 Trường Chinh, Quận 12, TP.HCM', '0234736531','trangdt123@gmail.com');


CREATE TABLE LOPHOC
(
	MALOP INT IDENTITY(1,1) CONSTRAINT LOPHOC_MALOP_PK PRIMARY KEY,
	TENLOP NVARCHAR(50),
	SOLUONG_SV INT,
	MAMON INT,
	MAGV INT,
	CONSTRAINT LOPHOC_MAGV_FK FOREIGN KEY(MAGV) REFERENCES GIAOVIEN(MAGV)
	ON UPDATE CASCADE ON DELETE CASCADE,
	CONSTRAINT LOPHOC_MAMON_FK FOREIGN KEY(MAMON) REFERENCES MONHOC(MAMON)
	ON UPDATE CASCADE ON DELETE CASCADE
)

INSERT INTO LOPHOC
VALUES(N'LOP001', 30, 1, 1)

CREATE TABLE SINHVIEN
(
	MASV INT IDENTITY(1,1) CONSTRAINT SINHVIEN_MASV_PK PRIMARY KEY,
    HO NVARCHAR(50),
    TENDEM NVARCHAR(50),
    TEN NVARCHAR(50),
    NGAYSINH DATETIME,
    GIOITINH NVARCHAR(3),
    QUEQUAN NVARCHAR(50),
    DIACHI NVARCHAR(50),
    DIENTHOAI VARCHAR(10),
    EMAIL VARCHAR(100)
)

INSERT INTO SINHVIEN (HO, TENDEM, TEN, NGAYSINH, GIOITINH, QUEQUAN, DIACHI, DIENTHOAI, EMAIL)
VALUES
(N'Nguyễn', N'Thi', N'Anh', '2000-01-01', N'Nam', N'Hà Nội', N'123 Nguyễn Street', '0912345678', N'nguyen.anh@example.com'),
(N'Trần', N'Thi', N'Bích', '1999-02-02', N'Nam', N'Hồ Chí Minh', N'456 Trần Street', '0912345679', N'tran.bich@example.com'),
(N'Lê', N'Thi', N'Hoa', '1998-03-03', N'Nam', N'Đà Nẵng', N'789 Lê Street', '0912345680', N'le.hoa@example.com'),
(N'Phạm', N'Thi', N'Làn', '1997-04-04', N'Nam', N'Hà Nội', N'101 Phạm Street', '0912345681', N'pham.lan@example.com'),
(N'Nguyễn', N'Thi', N'Mai', '1996-05-05', N'Nam', N'Hồ Chí Minh', N'202 Nguyễn Street', '0912345682', N'nguyen.mai@example.com'),
(N'Lê', N'Thi', N'Hương', '1995-06-06', N'Nữ', N'Đà Nẵng', N'303 Lê Street', '0912345683', N'le.huong@example.com'),
(N'Vũ', N'Thi', N'Lan', '1994-07-07', N'Nữ', N'Quảng Ninh', N'404 Vũ Street', '0912345684', N'vu.lan@example.com'),
(N'Hồ', N'Thi', N'Bích', '1993-08-08', N'Nữ', N'Hà Nội', N'505 Hồ Street', '0912345685', N'ho.bich@example.com');


CREATE TABLE LOPHOC_SINHVIEN
(
    MALOP INT,
    MASV INT,
    CONSTRAINT LH_SV_MALOP_SV_PK PRIMARY KEY(MALOP, MASV),
    CONSTRAINT LH_SV_MALOP_LOP_FK FOREIGN KEY(MALOP) REFERENCES LOPHOC(MALOP)
    ON UPDATE CASCADE ON DELETE CASCADE,
    CONSTRAINT LH_SV_MALOP_SV_FK FOREIGN KEY(MASV) REFERENCES SINHVIEN(MASV)
    ON UPDATE CASCADE ON DELETE CASCADE
)


CREATE TABLE DIEM
(
	MADIEM INT IDENTITY(1,1) CONSTRAINT DIEM_MADIEM_PK PRIMARY KEY,
	MASV INT,
	DIEMSO FLOAT,
	CONSTRAINT SINHVIEN_MASV_FK FOREIGN KEY(MASV) REFERENCES SINHVIEN(MASV)
	ON UPDATE CASCADE ON DELETE CASCADE,
)



CREATE TABLE TAIKHOAN
(
	MATK INT IDENTITY(1,1) CONSTRAINT TAIHKOAN_MATK_PK PRIMARY KEY,
	TENTK nvarchar(100),
	MATKHAU varchar(250),
	ROLE nvarchar(50)
);

INSERT INTO TAIKHOAN (TENTK, MATKHAU, ROLE)
VALUES
(N'admin1', 'password123', N'Quản trị viên'),
(N'admin2', 'password456', N'Quản trị viên'),
(N'teacher1', 'password123', N'Giáo viên'),
(N'teacher2', 'password456', N'Giáo viên'),
(N'student1', 'password123', N'Sinh viên'),
(N'student2', 'password456', N'Sinh viên');
