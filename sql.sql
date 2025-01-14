USE [master]
GO
/****** Object:  Database [prj2_2210900044_nhm]    Script Date: 11/10/2024 8:16:28 PM ******/
CREATE DATABASE [prj2_2210900044_nhm]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'prj2_2210900044_nhm', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\prj2_2210900044_nhm.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'prj2_2210900044_nhm_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\prj2_2210900044_nhm_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [prj2_2210900044_nhm] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [prj2_2210900044_nhm].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [prj2_2210900044_nhm] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [prj2_2210900044_nhm] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [prj2_2210900044_nhm] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [prj2_2210900044_nhm] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [prj2_2210900044_nhm] SET ARITHABORT OFF 
GO
ALTER DATABASE [prj2_2210900044_nhm] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [prj2_2210900044_nhm] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [prj2_2210900044_nhm] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [prj2_2210900044_nhm] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [prj2_2210900044_nhm] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [prj2_2210900044_nhm] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [prj2_2210900044_nhm] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [prj2_2210900044_nhm] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [prj2_2210900044_nhm] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [prj2_2210900044_nhm] SET  ENABLE_BROKER 
GO
ALTER DATABASE [prj2_2210900044_nhm] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [prj2_2210900044_nhm] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [prj2_2210900044_nhm] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [prj2_2210900044_nhm] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [prj2_2210900044_nhm] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [prj2_2210900044_nhm] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [prj2_2210900044_nhm] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [prj2_2210900044_nhm] SET RECOVERY FULL 
GO
ALTER DATABASE [prj2_2210900044_nhm] SET  MULTI_USER 
GO
ALTER DATABASE [prj2_2210900044_nhm] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [prj2_2210900044_nhm] SET DB_CHAINING OFF 
GO
ALTER DATABASE [prj2_2210900044_nhm] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [prj2_2210900044_nhm] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [prj2_2210900044_nhm] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [prj2_2210900044_nhm] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'prj2_2210900044_nhm', N'ON'
GO
ALTER DATABASE [prj2_2210900044_nhm] SET QUERY_STORE = ON
GO
ALTER DATABASE [prj2_2210900044_nhm] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [prj2_2210900044_nhm]
GO
/****** Object:  Table [dbo].[chi_tiet_don_hang]    Script Date: 11/10/2024 8:16:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[chi_tiet_don_hang](
	[chi_tiet_don_hang_id] [int] IDENTITY(1,1) NOT NULL,
	[don_hang_id] [int] NULL,
	[so_luong] [int] NOT NULL,
	[gia] [decimal](18, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[chi_tiet_don_hang_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[danh_muc_san_pham]    Script Date: 11/10/2024 8:16:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[danh_muc_san_pham](
	[danh_muc_id] [int] IDENTITY(1,1) NOT NULL,
	[ten_danh_muc] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[danh_muc_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[don_hang]    Script Date: 11/10/2024 8:16:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[don_hang](
	[don_hang_id] [int] IDENTITY(1,1) NOT NULL,
	[nguoi_dung_id] [int] NULL,
	[ngay_dat] [datetime] NULL,
	[tong_tien] [decimal](18, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[don_hang_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[nguoi_dung]    Script Date: 11/10/2024 8:16:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[nguoi_dung](
	[nguoi_dung_id] [int] IDENTITY(1,1) NOT NULL,
	[ten_dang_nhap] [nvarchar](50) NOT NULL,
	[mat_khau] [nvarchar](255) NOT NULL,
	[email] [nvarchar](100) NOT NULL,
	[ho_ten] [nvarchar](100) NULL,
	[dia_chi] [nvarchar](255) NULL,
	[so_dien_thoai] [nvarchar](15) NULL,
	[ngay_dang_ky] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[nguoi_dung_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[ten_dang_nhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[san_pham]    Script Date: 11/10/2024 8:16:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[san_pham](
	[san_pham_id] [int] IDENTITY(1,1) NOT NULL,
	[ten_san_pham] [nvarchar](100) NOT NULL,
	[gia] [decimal](18, 2) NOT NULL,
	[mo_ta] [nvarchar](255) NULL,
	[danh_muc_id] [int] NULL,
	[anh_san_pham] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[san_pham_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[thanh_toan]    Script Date: 11/10/2024 8:16:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[thanh_toan](
	[thanh_toan_id] [int] IDENTITY(1,1) NOT NULL,
	[don_hang_id] [int] NULL,
	[phuong_thuc] [nvarchar](50) NULL,
	[trang_thai] [nvarchar](50) NULL,
	[so_tien] [decimal](18, 2) NULL,
	[ngay_thanh_toan] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[thanh_toan_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[don_hang] ADD  DEFAULT (getdate()) FOR [ngay_dat]
GO
ALTER TABLE [dbo].[nguoi_dung] ADD  DEFAULT (getdate()) FOR [ngay_dang_ky]
GO
ALTER TABLE [dbo].[thanh_toan] ADD  DEFAULT ('Chưa thanh toán') FOR [trang_thai]
GO
ALTER TABLE [dbo].[thanh_toan] ADD  DEFAULT (getdate()) FOR [ngay_thanh_toan]
GO
ALTER TABLE [dbo].[chi_tiet_don_hang]  WITH CHECK ADD FOREIGN KEY([don_hang_id])
REFERENCES [dbo].[don_hang] ([don_hang_id])
GO
ALTER TABLE [dbo].[don_hang]  WITH CHECK ADD FOREIGN KEY([nguoi_dung_id])
REFERENCES [dbo].[nguoi_dung] ([nguoi_dung_id])
GO
ALTER TABLE [dbo].[san_pham]  WITH CHECK ADD FOREIGN KEY([danh_muc_id])
REFERENCES [dbo].[danh_muc_san_pham] ([danh_muc_id])
GO
ALTER TABLE [dbo].[thanh_toan]  WITH CHECK ADD FOREIGN KEY([don_hang_id])
REFERENCES [dbo].[don_hang] ([don_hang_id])
GO
USE [master]
GO
ALTER DATABASE [prj2_2210900044_nhm] SET  READ_WRITE 
GO
select*from SAN_PHAM
select*from thanh_toan
SELECT dh.don_hang_id, tt.thanh_toan_id, tt.phuong_thuc, tt.trang_thai
FROM dbo.don_hang dh
LEFT JOIN dbo.thanh_toan tt ON dh.don_hang_id = tt.don_hang_id