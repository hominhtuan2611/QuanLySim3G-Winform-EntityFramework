--use master
--GO
--drop database QLCuocDT


use master
create database QLCuocDT
GO
use QLCuocDT
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[CuocGoi](
	[MaCuocGoi] [int] IDENTITY(1,1) NOT NULL,
	[MaSim] [int] NOT NULL,
	[TG_BatDau] [datetime] NOT NULL,
	[TG_KetThuc] [datetime] NOT NULL,
	[SoPhutSD] [int] NOT NULL,
	[trangthai] [bit] NOT NULL,
PRIMARY KEY
(
	[MaCuocGoi] ASC
)
)
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[HoaDonDK](
	[MaHD] [int] IDENTITY(1,1) NOT NULL,
	[MaSim] [int] NOT NULL,
	[NgayDK] [datetime] NOT NULL,
	[ChiPhi] [decimal](18, 0) NOT NULL,
	[MaKH] [int] NOT NULL,
PRIMARY KEY 
(
	[MaHD] ASC
)
) 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[HoaDonThanhToan](
	[MaHD] [int] IDENTITY(1,1) NOT NULL,
	[MaKH] [int] NOT NULL,
	[MaSim] [int] NOT NULL,
	[CuocThueBao] [decimal](18, 0) NOT NULL,
	[NgayHD] [datetime] NOT NULL,
	[ThanhToan] [bit] NOT NULL,
	[ThanhTien] [decimal](18, 0) NOT NULL,
	[Status] [bit] NOT NULL,
PRIMARY KEY 
(
	[MaHD] ASC
)
)
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[KhachHang](
	[MaKH] [int] IDENTITY(1,1) NOT NULL,
	[TenKH] [nvarchar](50) NOT NULL,
	[CMND] [nvarchar](50) NOT NULL,
	[NgheNghiep] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[Status] [bit] NOT NULL,
PRIMARY KEY
(
	[MaKH] ASC
)
)
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[LoaiCuoc](
	[TG_BatDau] [time](7) NOT NULL,
	[TG_KetThuc] [time](7) NOT NULL,
	[GiaCuoc] [decimal](18, 0) NOT NULL,
	[Status] [bit] NOT NULL
) ON [PRIMARY]

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[Sim](
	[MaSim] [int] IDENTITY(1,1) NOT NULL,
	[SoSim] [nvarchar](50) NOT NULL,
	[Status] [bit] NOT NULL,
PRIMARY KEY 
(
	[MaSim] ASC
)
)
ALTER TABLE [dbo].[CuocGoi]  WITH CHECK ADD  CONSTRAINT [FK_CuocGoi_Sim] FOREIGN KEY([MaSim])
REFERENCES [dbo].[Sim] ([MaSim])
GO
ALTER TABLE [dbo].[CuocGoi] CHECK CONSTRAINT [FK_CuocGoi_Sim]
GO
ALTER TABLE [dbo].[HoaDonDK]  WITH CHECK ADD  CONSTRAINT [FK_HoaDonDK_KhachHang] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KhachHang] ([MaKH])
GO
ALTER TABLE [dbo].[HoaDonDK] CHECK CONSTRAINT [FK_HoaDonDK_KhachHang]
GO
ALTER TABLE [dbo].[HoaDonDK]  WITH CHECK ADD  CONSTRAINT [FK_HoaDonDK_Sim] FOREIGN KEY([MaSim])
REFERENCES [dbo].[Sim] ([MaSim])
GO
ALTER TABLE [dbo].[HoaDonDK] CHECK CONSTRAINT [FK_HoaDonDK_Sim]
GO
ALTER TABLE [dbo].[HoaDonThanhToan]  WITH CHECK ADD  CONSTRAINT [FK_HoaDonThanhToan_KhachHang] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KhachHang] ([MaKH])
GO
ALTER TABLE [dbo].[HoaDonThanhToan] CHECK CONSTRAINT [FK_HoaDonThanhToan_KhachHang]
GO
ALTER TABLE [dbo].[HoaDonThanhToan]  WITH CHECK ADD  CONSTRAINT [FK_HoaDonThanhToan_Sim] FOREIGN KEY([MaSim])
REFERENCES [dbo].[Sim] ([MaSim])
GO
ALTER TABLE [dbo].[HoaDonThanhToan] CHECK CONSTRAINT [FK_HoaDonThanhToan_Sim]

/*Sim*/
SET IDENTITY_INSERT Sim ON
INSERT [dbo].[Sim] ([MaSim], [SoSim], [Status]) VALUES (2, N'84913805266', 1)
INSERT [dbo].[Sim] ([MaSim], [SoSim], [Status]) VALUES (3, N'841236969334', 1)
INSERT [dbo].[Sim] ([MaSim], [SoSim], [Status]) VALUES (4, N'84913919143', 1)
INSERT [dbo].[Sim] ([MaSim], [SoSim], [Status]) VALUES (5, N'84918725997', 1)
INSERT [dbo].[Sim] ([MaSim], [SoSim], [Status]) VALUES (6, N'84913905878', 1)
INSERT [dbo].[Sim] ([MaSim], [SoSim], [Status]) VALUES (7, N'84918588499', 1)
INSERT [dbo].[Sim] ([MaSim], [SoSim], [Status]) VALUES (8, N'84948021619', 1)
INSERT [dbo].[Sim] ([MaSim], [SoSim], [Status]) VALUES (9, N'84918015588', 1)
INSERT [dbo].[Sim] ([MaSim], [SoSim], [Status]) VALUES (10, N'84913750047', 1)
INSERT [dbo].[Sim] ([MaSim], [SoSim], [Status]) VALUES (11, N'81115750140', 1)
INSERT [dbo].[Sim] ([MaSim], [SoSim], [Status]) VALUES (12, N'89215660137', 1)

/*LoaiCuoc*/
INSERT [dbo].[LoaiCuoc] ([TG_BatDau], [TG_KetThuc], [GiaCuoc], [Status]) VALUES (CAST(N'07:00:00' AS Time), CAST(N'23:00:00' AS Time), CAST(200 AS Decimal(18, 0)), 1)
INSERT [dbo].[LoaiCuoc] ([TG_BatDau], [TG_KetThuc], [GiaCuoc], [Status]) VALUES (CAST(N'23:00:00' AS Time), CAST(N'07:00:00' AS Time), CAST(150 AS Decimal(18, 0)), 1)

/*KhachHang*/
SET IDENTITY_INSERT SIM OFF
SET IDENTITY_INSERT KhachHang ON
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [CMND], [NgheNghiep], [DiaChi], [Status]) VALUES (0, N'CTY TNHH THƯƠNG MẠI HOA LỢI', N'25400649', N'Kinh Doanh', N'284/6, NGUYỄN TRỌNG TUYỂN, P.10, PHÚ NHUẬN', 1)
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [CMND], [NgheNghiep], [DiaChi], [Status]) VALUES (2, N'NGUYỄN NGỌC HUỲNH NHƯ', N'25454976', N'Bán Hàng', N'30/32 - NGUYỄN BỈNH KHIÊM - P.1 - GÒ VẤP - TP HCM', 1)
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [CMND], [NgheNghiep], [DiaChi], [Status]) VALUES (3, N'ĐÀO VĂN PHÚC', N'25446098', N'Nội Trợ', N'58/647, NGUYỄN OANH, P.17, GÒ VẤP', 1)
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [CMND], [NgheNghiep], [DiaChi], [Status]) VALUES (4, N'CTY TNHH TM DV VẬN TẢI DƯƠNG THÀNH', N'25433339', N'Kinh Doanh', N'46/1, HÙNG VƯƠNG, P.1, Q.10', 1)
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [CMND], [NgheNghiep], [DiaChi], [Status]) VALUES (5, N'PHẠM THỊ VÂN KHÁNH', N'25488912', N'Giảng Viên', N'326, NGUYỄN CHÍ THANH, P.5, Q.10', 1)
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [CMND], [NgheNghiep], [DiaChi], [Status]) VALUES (6, N'TRỊNH THỊ HỒNG', N'25494671', N'Sinh Viên', N'161/3F, HÙNG VƯƠNG, P.6, Q.06', 1)
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [CMND], [NgheNghiep], [DiaChi], [Status]) VALUES (7, N'NGUYỄN THANH THẠCH', N'25450784', N'Văn Phòng', N'20, KHU 1, TÂN SƠN NHÌ, TÂN SƠN NHÌ, TÂN PHÚ', 1)
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [CMND], [NgheNghiep], [DiaChi], [Status]) VALUES (9, N'VÕ THANH BÌNH', N'25458659', N'Bán Hàng', N'232/6, VÕ THỊ SÁU, P.7, Q.03', 1)
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [CMND], [NgheNghiep], [DiaChi], [Status]) VALUES (10, N'LÊ THỊ THU CÚC', N'25423812', N'Sinh Viên', N'338A, NƠ TRANG LONG, P.13, BÌNH THẠNH', 1)
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [CMND], [NgheNghiep], [DiaChi], [Status]) VALUES (11, N'HOÀNG KIM PHỤNG', N'25910211', N'Nhân viên văn phòng', N'610, KINH DƯƠNG VƯƠNG, P.6, BÌNH TÂN', 1)


/*HoaDonThanhToan*/
SET IDENTITY_INSERT KhachHang OFF
SET IDENTITY_INSERT HoaDonThanhToan ON
INSERT [dbo].[HoaDonThanhToan] ([MaHD], [MaKH], [MaSim], [CuocThueBao], [NgayHD], [ThanhToan], [ThanhTien], [Status]) VALUES (229, 0, 2, CAST(50000 AS Decimal(18, 0)), CAST(N'2018-11-14T22:20:35.050' AS DateTime), 0, CAST(275200 AS Decimal(18, 0)), 1)
INSERT [dbo].[HoaDonThanhToan] ([MaHD], [MaKH], [MaSim], [CuocThueBao], [NgayHD], [ThanhToan], [ThanhTien], [Status]) VALUES (230, 2, 4, CAST(50000 AS Decimal(18, 0)), CAST(N'2018-11-14T22:20:35.137' AS DateTime), 0, CAST(258150 AS Decimal(18, 0)), 1)
INSERT [dbo].[HoaDonThanhToan] ([MaHD], [MaKH], [MaSim], [CuocThueBao], [NgayHD], [ThanhToan], [ThanhTien], [Status]) VALUES (231, 3, 5, CAST(50000 AS Decimal(18, 0)), CAST(N'2018-11-14T22:20:35.183' AS DateTime), 0, CAST(94550 AS Decimal(18, 0)), 1)
INSERT [dbo].[HoaDonThanhToan] ([MaHD], [MaKH], [MaSim], [CuocThueBao], [NgayHD], [ThanhToan], [ThanhTien], [Status]) VALUES (232, 9, 12, CAST(50000 AS Decimal(18, 0)), CAST(N'2018-11-14T22:20:35.207' AS DateTime), 0, CAST(60600 AS Decimal(18, 0)), 1)
INSERT [dbo].[HoaDonThanhToan] ([MaHD], [MaKH], [MaSim], [CuocThueBao], [NgayHD], [ThanhToan], [ThanhTien], [Status]) VALUES (233, 4, 6, CAST(50000 AS Decimal(18, 0)), CAST(N'2018-11-14T22:20:35.227' AS DateTime), 0, CAST(81000 AS Decimal(18, 0)), 1)
INSERT [dbo].[HoaDonThanhToan] ([MaHD], [MaKH], [MaSim], [CuocThueBao], [NgayHD], [ThanhToan], [ThanhTien], [Status]) VALUES (234, 5, 7, CAST(50000 AS Decimal(18, 0)), CAST(N'2018-11-14T22:20:35.243' AS DateTime), 0, CAST(62400 AS Decimal(18, 0)), 1)
INSERT [dbo].[HoaDonThanhToan] ([MaHD], [MaKH], [MaSim], [CuocThueBao], [NgayHD], [ThanhToan], [ThanhTien], [Status]) VALUES (235, 6, 8, CAST(50000 AS Decimal(18, 0)), CAST(N'2018-11-14T22:20:35.267' AS DateTime), 0, CAST(124600 AS Decimal(18, 0)), 1)
INSERT [dbo].[HoaDonThanhToan] ([MaHD], [MaKH], [MaSim], [CuocThueBao], [NgayHD], [ThanhToan], [ThanhTien], [Status]) VALUES (236, 7, 9, CAST(50000 AS Decimal(18, 0)), CAST(N'2018-11-14T22:20:35.297' AS DateTime), 0, CAST(129850 AS Decimal(18, 0)), 1)
INSERT [dbo].[HoaDonThanhToan] ([MaHD], [MaKH], [MaSim], [CuocThueBao], [NgayHD], [ThanhToan], [ThanhTien], [Status]) VALUES (237, 10, 10, CAST(50000 AS Decimal(18, 0)), CAST(N'2018-11-14T22:20:35.317' AS DateTime), 0, CAST(62600 AS Decimal(18, 0)), 1)
INSERT [dbo].[HoaDonThanhToan] ([MaHD], [MaKH], [MaSim], [CuocThueBao], [NgayHD], [ThanhToan], [ThanhTien], [Status]) VALUES (238, 11, 3, CAST(50000 AS Decimal(18, 0)), CAST(N'2018-11-14T22:20:35.337' AS DateTime), 0, CAST(93050 AS Decimal(18, 0)), 1)

/*HoaDonDK*/
SET IDENTITY_INSERT HoaDonThanhToan OFF
SET IDENTITY_INSERT HoaDonDK ON
INSERT [dbo].[HoaDonDK] ([MaHD], [MaSim], [NgayDK], [ChiPhi], [MaKH]) VALUES (0, 2, CAST(N'2016-09-29T11:00:00.000' AS DateTime), CAST(50000 AS Decimal(18, 0)), 0)
INSERT [dbo].[HoaDonDK] ([MaHD], [MaSim], [NgayDK], [ChiPhi], [MaKH]) VALUES (2, 4, CAST(N'2016-12-15T13:23:00.000' AS DateTime), CAST(50000 AS Decimal(18, 0)), 2)
INSERT [dbo].[HoaDonDK] ([MaHD], [MaSim], [NgayDK], [ChiPhi], [MaKH]) VALUES (3, 5, CAST(N'2016-12-29T16:30:00.000' AS DateTime), CAST(50000 AS Decimal(18, 0)), 3)
INSERT [dbo].[HoaDonDK] ([MaHD], [MaSim], [NgayDK], [ChiPhi], [MaKH]) VALUES (4, 6, CAST(N'2017-04-28T15:58:00.000' AS DateTime), CAST(50000 AS Decimal(18, 0)), 4)
INSERT [dbo].[HoaDonDK] ([MaHD], [MaSim], [NgayDK], [ChiPhi], [MaKH]) VALUES (5, 7, CAST(N'2018-06-22T00:00:00.000' AS DateTime), CAST(50000 AS Decimal(18, 0)), 5)
INSERT [dbo].[HoaDonDK] ([MaHD], [MaSim], [NgayDK], [ChiPhi], [MaKH]) VALUES (6, 8, CAST(N'2017-09-21T11:25:00.000' AS DateTime), CAST(50000 AS Decimal(18, 0)), 6)
INSERT [dbo].[HoaDonDK] ([MaHD], [MaSim], [NgayDK], [ChiPhi], [MaKH]) VALUES (7, 9, CAST(N'2017-06-26T17:45:00.000' AS DateTime), CAST(50000 AS Decimal(18, 0)), 7)
INSERT [dbo].[HoaDonDK] ([MaHD], [MaSim], [NgayDK], [ChiPhi], [MaKH]) VALUES (8, 10, CAST(N'2016-10-21T18:00:00.000' AS DateTime), CAST(50000 AS Decimal(18, 0)), 7)
INSERT [dbo].[HoaDonDK] ([MaHD], [MaSim], [NgayDK], [ChiPhi], [MaKH]) VALUES (11, 12, CAST(N'2017-03-12T11:11:00.000' AS DateTime), CAST(50000 AS Decimal(18, 0)), 3)
INSERT [dbo].[HoaDonDK] ([MaHD], [MaSim], [NgayDK], [ChiPhi], [MaKH]) VALUES (19, 3, CAST(N'2018-06-12T08:45:20.000' AS DateTime), CAST(50000 AS Decimal(18, 0)), 11)

 /* CuocGoi */
 SET IDENTITY_INSERT HoaDonDK OFF
 SET IDENTITY_INSERT CuocGoi ON
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2809, 3, CAST(N'2018-12-07T11:44:18.000' AS DateTime), CAST(N'2018-12-07T21:47:03.000' AS DateTime), 603, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2810, 6, CAST(N'2018-12-13T09:50:17.000' AS DateTime), CAST(N'2018-12-13T16:41:25.000' AS DateTime), 411, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2811, 7, CAST(N'2018-12-24T06:28:07.000' AS DateTime), CAST(N'2018-12-24T11:46:27.000' AS DateTime), 318, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2812, 7, CAST(N'2018-12-04T10:53:21.000' AS DateTime), CAST(N'2018-12-04T11:56:29.000' AS DateTime), 63, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2813, 10, CAST(N'2018-12-01T17:49:03.000' AS DateTime), CAST(N'2018-12-01T22:57:41.000' AS DateTime), 309, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2814, 5, CAST(N'2018-12-10T02:30:21.000' AS DateTime), CAST(N'2018-12-10T13:50:02.000' AS DateTime), 680, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2815, 5, CAST(N'2018-12-21T07:55:34.000' AS DateTime), CAST(N'2018-12-21T12:00:03.000' AS DateTime), 244, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2816, 7, CAST(N'2018-12-08T07:11:28.000' AS DateTime), CAST(N'2018-12-08T22:41:39.000' AS DateTime), 930, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2817, 4, CAST(N'2018-12-07T02:41:28.000' AS DateTime), CAST(N'2018-12-07T06:53:39.000' AS DateTime), 252, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2818, 3, CAST(N'2018-12-08T03:57:47.000' AS DateTime), CAST(N'2018-12-08T14:03:38.000' AS DateTime), 606, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2819, 2, CAST(N'2018-12-03T15:09:34.000' AS DateTime), CAST(N'2018-12-03T17:47:10.000' AS DateTime), 158, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2820, 2, CAST(N'2018-12-01T17:22:46.000' AS DateTime), CAST(N'2018-12-01T17:47:00.000' AS DateTime), 24, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2821, 4, CAST(N'2018-12-22T00:26:08.000' AS DateTime), CAST(N'2018-12-22T21:45:30.000' AS DateTime), 1279, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2822, 10, CAST(N'2018-12-30T15:36:00.000' AS DateTime), CAST(N'2018-12-30T18:00:46.000' AS DateTime), 145, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2823, 8, CAST(N'2018-12-25T03:48:47.000' AS DateTime), CAST(N'2018-12-25T21:44:18.000' AS DateTime), 1076, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2824, 8, CAST(N'2018-12-06T08:13:00.000' AS DateTime), CAST(N'2018-12-06T20:54:19.000' AS DateTime), 761, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2825, 8, CAST(N'2018-12-17T12:38:13.000' AS DateTime), CAST(N'2018-12-17T20:04:21.000' AS DateTime), 446, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2826, 7, CAST(N'2018-12-12T00:50:00.000' AS DateTime), CAST(N'2018-12-12T22:47:52.000' AS DateTime), 1318, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2827, 6, CAST(N'2018-12-23T04:15:13.000' AS DateTime), CAST(N'2018-12-23T22:57:54.000' AS DateTime), 1123, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2828, 6, CAST(N'2018-12-03T08:40:27.000' AS DateTime), CAST(N'2018-12-03T22:07:56.000' AS DateTime), 807, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2829, 7, CAST(N'2018-12-10T15:10:01.000' AS DateTime), CAST(N'2018-12-10T21:58:25.000' AS DateTime), 408, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2830, 4, CAST(N'2018-12-27T02:40:11.000' AS DateTime), CAST(N'2018-12-27T17:33:07.000' AS DateTime), 893, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2831, 2, CAST(N'2018-12-19T16:39:51.000' AS DateTime), CAST(N'2018-12-19T20:39:14.000' AS DateTime), 239, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2832, 5, CAST(N'2018-12-05T06:51:19.000' AS DateTime), CAST(N'2018-12-05T07:52:47.000' AS DateTime), 61, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2833, 2, CAST(N'2018-12-04T01:21:19.000' AS DateTime), CAST(N'2018-12-04T15:04:46.000' AS DateTime), 823, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2834, 5, CAST(N'2018-12-30T03:04:38.000' AS DateTime), CAST(N'2018-12-30T10:34:08.000' AS DateTime), 450, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2835, 4, CAST(N'2018-12-08T00:36:05.000' AS DateTime), CAST(N'2018-12-08T17:03:24.000' AS DateTime), 987, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2836, 8, CAST(N'2018-12-23T03:10:37.000' AS DateTime), CAST(N'2018-12-23T22:24:28.000' AS DateTime), 1154, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2837, 9, CAST(N'2018-12-07T05:33:39.000' AS DateTime), CAST(N'2018-12-07T06:51:10.000' AS DateTime), 78, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2838, 10, CAST(N'2018-12-26T15:15:28.000' AS DateTime), CAST(N'2018-12-26T19:14:40.000' AS DateTime), 239, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2839, 4, CAST(N'2018-12-05T01:03:28.000' AS DateTime), CAST(N'2018-12-05T12:46:54.000' AS DateTime), 703, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2840, 8, CAST(N'2018-12-24T01:34:52.000' AS DateTime), CAST(N'2018-12-24T08:55:44.000' AS DateTime), 441, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2841, 7, CAST(N'2018-12-05T06:59:06.000' AS DateTime), CAST(N'2018-12-05T07:05:46.000' AS DateTime), 7, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2842, 12, CAST(N'2018-12-14T05:39:34.000' AS DateTime), CAST(N'2018-12-14T11:04:12.000' AS DateTime), 325, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2843, 8, CAST(N'2018-12-13T00:08:34.000' AS DateTime), CAST(N'2018-12-13T19:16:12.000' AS DateTime), 1148, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2844, 6, CAST(N'2018-12-21T02:01:19.000' AS DateTime), CAST(N'2018-12-21T09:08:21.000' AS DateTime), 427, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2845, 8, CAST(N'2018-12-08T20:21:52.000' AS DateTime), CAST(N'2018-12-08T22:58:33.000' AS DateTime), 157, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2846, 2, CAST(N'2018-12-12T00:39:05.000' AS DateTime), CAST(N'2018-12-12T11:22:20.000' AS DateTime), 643, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2847, 2, CAST(N'2018-12-22T06:50:05.000' AS DateTime), CAST(N'2018-12-22T14:45:26.000' AS DateTime), 475, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2848, 2, CAST(N'2018-12-03T10:15:18.000' AS DateTime), CAST(N'2018-12-03T13:55:27.000' AS DateTime), 220, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2849, 3, CAST(N'2018-12-02T06:32:11.000' AS DateTime), CAST(N'2018-12-02T17:04:54.000' AS DateTime), 633, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2850, 12, CAST(N'2018-12-09T02:52:18.000' AS DateTime), CAST(N'2018-12-09T16:48:00.000' AS DateTime), 836, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2851, 10, CAST(N'2018-12-20T07:17:32.000' AS DateTime), CAST(N'2018-12-20T15:59:02.000' AS DateTime), 522, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2852, 10, CAST(N'2018-12-01T11:42:45.000' AS DateTime), CAST(N'2018-12-01T15:09:03.000' AS DateTime), 206, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2853, 4, CAST(N'2018-12-22T22:56:48.000' AS DateTime), CAST(N'2018-12-22T23:28:37.000' AS DateTime), 32, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2854, 9, CAST(N'2018-12-06T03:19:45.000' AS DateTime), CAST(N'2018-12-06T17:02:37.000' AS DateTime), 823, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2855, 7, CAST(N'2018-12-02T15:31:31.000' AS DateTime), CAST(N'2018-12-02T19:45:08.000' AS DateTime), 254, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2856, 5, CAST(N'2018-12-30T06:03:48.000' AS DateTime), CAST(N'2018-12-30T18:44:50.000' AS DateTime), 761, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2857, 7, CAST(N'2018-12-23T00:21:58.000' AS DateTime), CAST(N'2018-12-23T19:06:11.000' AS DateTime), 1124, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2858, 5, CAST(N'2018-12-18T11:33:44.000' AS DateTime), CAST(N'2018-12-18T21:49:43.000' AS DateTime), 616, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2859, 5, CAST(N'2018-12-29T16:58:58.000' AS DateTime), CAST(N'2018-12-29T21:59:45.000' AS DateTime), 301, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2860, 6, CAST(N'2018-12-16T13:32:12.000' AS DateTime), CAST(N'2018-12-16T23:50:14.000' AS DateTime), 618, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2861, 3, CAST(N'2018-12-05T08:35:57.000' AS DateTime), CAST(N'2018-12-05T23:52:18.000' AS DateTime), 916, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2862, 3, CAST(N'2018-12-16T12:00:11.000' AS DateTime), CAST(N'2018-12-16T23:02:19.000' AS DateTime), 662, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2863, 2, CAST(N'2018-12-11T00:12:57.000' AS DateTime), CAST(N'2018-12-11T01:46:51.000' AS DateTime), 94, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2864, 5, CAST(N'2018-12-18T20:57:20.000' AS DateTime), CAST(N'2018-12-18T21:44:34.000' AS DateTime), 47, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2865, 4, CAST(N'2018-12-30T10:42:03.000' AS DateTime), CAST(N'2018-12-30T18:03:02.000' AS DateTime), 441, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2866, 7, CAST(N'2018-12-26T11:25:21.000' AS DateTime), CAST(N'2018-12-26T14:33:24.000' AS DateTime), 188, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2867, 10, CAST(N'2018-12-08T01:39:24.000' AS DateTime), CAST(N'2018-12-08T03:59:27.000' AS DateTime), 140, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2868, 12, CAST(N'2018-12-24T01:24:21.000' AS DateTime), CAST(N'2018-12-24T05:57:23.000' AS DateTime), 273, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2869, 12, CAST(N'2018-12-23T10:36:56.000' AS DateTime), CAST(N'2018-12-23T14:59:54.000' AS DateTime), 263, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2870, 10, CAST(N'2018-12-01T04:51:54.000' AS DateTime), CAST(N'2018-12-01T11:44:20.000' AS DateTime), 412, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2871, 4, CAST(N'2018-12-09T14:29:26.000' AS DateTime), CAST(N'2018-12-09T16:58:17.000' AS DateTime), 149, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2872, 10, CAST(N'2018-12-02T00:51:01.000' AS DateTime), CAST(N'2018-12-02T02:59:10.000' AS DateTime), 128, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2873, 9, CAST(N'2018-12-14T12:18:59.000' AS DateTime), CAST(N'2018-12-14T19:33:06.000' AS DateTime), 434, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2874, 5, CAST(N'2018-12-06T05:55:37.000' AS DateTime), CAST(N'2018-12-06T09:50:08.000' AS DateTime), 235, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2875, 10, CAST(N'2018-12-09T08:30:17.000' AS DateTime), CAST(N'2018-12-09T22:15:27.000' AS DateTime), 825, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2876, 7, CAST(N'2018-12-08T03:59:17.000' AS DateTime), CAST(N'2018-12-08T06:27:27.000' AS DateTime), 148, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2877, 3, CAST(N'2018-12-23T02:57:50.000' AS DateTime), CAST(N'2018-12-23T10:53:43.000' AS DateTime), 476, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2878, 2, CAST(N'2018-12-04T06:22:03.000' AS DateTime), CAST(N'2018-12-04T10:03:45.000' AS DateTime), 222, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2879, 10, CAST(N'2018-12-29T01:54:55.000' AS DateTime), CAST(N'2018-12-29T04:39:11.000' AS DateTime), 164, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2880, 2, CAST(N'2018-12-19T09:15:38.000' AS DateTime), CAST(N'2018-12-19T18:06:50.000' AS DateTime), 531, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2881, 12, CAST(N'2018-12-20T03:23:16.000' AS DateTime), CAST(N'2018-12-20T12:07:19.000' AS DateTime), 524, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2882, 9, CAST(N'2018-12-15T14:36:03.000' AS DateTime), CAST(N'2018-12-15T14:50:51.000' AS DateTime), 15, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2883, 5, CAST(N'2018-12-23T11:05:13.000' AS DateTime), CAST(N'2018-12-23T23:45:31.000' AS DateTime), 760, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2884, 2, CAST(N'2018-12-22T05:35:13.000' AS DateTime), CAST(N'2018-12-22T07:57:31.000' AS DateTime), 142, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2885, 7, CAST(N'2018-12-02T11:37:16.000' AS DateTime), CAST(N'2018-12-02T16:54:26.000' AS DateTime), 317, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2886, 7, CAST(N'2018-12-13T15:02:29.000' AS DateTime), CAST(N'2018-12-13T16:04:27.000' AS DateTime), 62, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2887, 6, CAST(N'2018-12-08T03:14:16.000' AS DateTime), CAST(N'2018-12-08T18:47:59.000' AS DateTime), 934, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2888, 5, CAST(N'2018-12-19T07:39:29.000' AS DateTime), CAST(N'2018-12-19T18:57:00.000' AS DateTime), 678, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2889, 5, CAST(N'2018-12-29T12:04:43.000' AS DateTime), CAST(N'2018-12-29T17:07:02.000' AS DateTime), 302, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2890, 6, CAST(N'2018-12-22T07:36:03.000' AS DateTime), CAST(N'2018-12-22T09:48:31.000' AS DateTime), 132, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2891, 4, CAST(N'2018-12-05T04:41:42.000' AS DateTime), CAST(N'2018-12-05T20:01:35.000' AS DateTime), 920, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2892, 3, CAST(N'2018-12-16T08:06:56.000' AS DateTime), CAST(N'2018-12-16T19:11:37.000' AS DateTime), 665, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2893, 2, CAST(N'2018-12-11T20:18:42.000' AS DateTime), CAST(N'2018-12-11T22:54:08.000' AS DateTime), 155, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2894, 2, CAST(N'2018-12-22T00:43:55.000' AS DateTime), CAST(N'2018-12-22T21:04:10.000' AS DateTime), 1220, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2895, 12, CAST(N'2018-12-27T05:05:46.000' AS DateTime), CAST(N'2018-12-27T06:39:18.000' AS DateTime), 94, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2896, 8, CAST(N'2018-12-26T00:34:46.000' AS DateTime), CAST(N'2018-12-26T14:51:18.000' AS DateTime), 857, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2897, 10, CAST(N'2018-12-09T21:45:09.000' AS DateTime), CAST(N'2018-12-09T23:08:45.000' AS DateTime), 84, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2898, 8, CAST(N'2018-12-22T00:03:58.000' AS DateTime), CAST(N'2018-12-22T16:36:00.000' AS DateTime), 992, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2899, 4, CAST(N'2018-12-14T10:15:06.000' AS DateTime), CAST(N'2018-12-14T15:18:36.000' AS DateTime), 304, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2900, 9, CAST(N'2018-12-08T03:22:50.000' AS DateTime), CAST(N'2018-12-08T15:12:58.000' AS DateTime), 710, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2901, 9, CAST(N'2018-12-25T00:17:06.000' AS DateTime), CAST(N'2018-12-25T08:36:48.000' AS DateTime), 500, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2902, 4, CAST(N'2018-12-15T06:58:24.000' AS DateTime), CAST(N'2018-12-15T11:38:00.000' AS DateTime), 280, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2903, 4, CAST(N'2018-12-16T02:15:20.000' AS DateTime), CAST(N'2018-12-16T20:47:15.000' AS DateTime), 1112, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2904, 5, CAST(N'2018-12-07T01:01:21.000' AS DateTime), CAST(N'2018-12-07T05:58:26.000' AS DateTime), 297, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2905, 12, CAST(N'2018-12-10T21:39:42.000' AS DateTime), CAST(N'2018-12-10T22:32:21.000' AS DateTime), 53, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2906, 8, CAST(N'2018-12-06T06:39:43.000' AS DateTime), CAST(N'2018-12-06T12:58:05.000' AS DateTime), 378, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2907, 6, CAST(N'2018-12-28T12:42:18.000' AS DateTime), CAST(N'2018-12-28T15:17:41.000' AS DateTime), 155, 1)
INSERT [dbo].[CuocGoi] ([MaCuocGoi], [MaSim], [TG_BatDau], [TG_KetThuc], [SoPhutSD], [trangthai]) VALUES (2908, 3, CAST(N'2018-12-04T02:28:48.000' AS DateTime), CAST(N'2018-12-04T07:12:02.000' AS DateTime), 283, 1)
