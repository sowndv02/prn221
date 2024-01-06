USE [master]
GO
/****** Object:  Database [PRN211_1]    Script Date: 9/19/2023 4:48:36 PM ******/
CREATE DATABASE [PRN211_1]
GO
ALTER DATABASE [PRN211_1] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PRN211_1].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PRN211_1] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PRN211_1] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PRN211_1] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PRN211_1] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PRN211_1] SET ARITHABORT OFF 
GO
ALTER DATABASE [PRN211_1] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PRN211_1] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PRN211_1] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PRN211_1] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PRN211_1] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PRN211_1] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PRN211_1] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PRN211_1] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PRN211_1] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PRN211_1] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PRN211_1] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PRN211_1] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PRN211_1] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PRN211_1] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PRN211_1] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PRN211_1] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PRN211_1] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PRN211_1] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PRN211_1] SET  MULTI_USER 
GO
ALTER DATABASE [PRN211_1] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PRN211_1] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PRN211_1] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PRN211_1] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PRN211_1] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PRN211_1] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [PRN211_1] SET QUERY_STORE = OFF
GO
USE [PRN211_1]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 9/19/2023 4:48:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[id] [nvarchar](10) NOT NULL,
	[name] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 9/19/2023 4:48:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[id] [int] NOT NULL,
	[name] [nvarchar](30) NOT NULL,
	[gender] [bit] NOT NULL,
	[departId] [nvarchar](10) NOT NULL,
	[dob] [date] NULL,
	[gpa] [float] NOT NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Department] ([id], [name]) VALUES (N'AI', N'Trí tuệ nhân tạo')
INSERT [dbo].[Department] ([id], [name]) VALUES (N'BA', N'Quản trị kinh doanh')
INSERT [dbo].[Department] ([id], [name]) VALUES (N'En', N'Ngôn Ngữ Anh')
INSERT [dbo].[Department] ([id], [name]) VALUES (N'GD', N'Thiết kế đồ họa')
INSERT [dbo].[Department] ([id], [name]) VALUES (N'IA', N'An Toàn thông tin')
INSERT [dbo].[Department] ([id], [name]) VALUES (N'JP', N'Ngôn ngữ Nhật')
INSERT [dbo].[Department] ([id], [name]) VALUES (N'SE', N'Kỹ thuật phầm mềm')
GO
INSERT [dbo].[Student] ([id], [name], [gender], [departId], [dob], [gpa]) VALUES (2, N'Trần B124', 0, N'En', CAST(N'2001-02-16' AS Date), 6.7)
INSERT [dbo].[Student] ([id], [name], [gender], [departId], [dob], [gpa]) VALUES (3, N'Trần C', 1, N'IA', CAST(N'2001-03-28' AS Date), 6)
INSERT [dbo].[Student] ([id], [name], [gender], [departId], [dob], [gpa]) VALUES (4, N'TChu DE123', 1, N'En', CAST(N'2023-06-02' AS Date), 3)
INSERT [dbo].[Student] ([id], [name], [gender], [departId], [dob], [gpa]) VALUES (5, N'ABc123', 0, N'IA', CAST(N'2023-06-02' AS Date), 3)
INSERT [dbo].[Student] ([id], [name], [gender], [departId], [dob], [gpa]) VALUES (6, N'Nóng như lửa', 0, N'SE', CAST(N'2001-02-28' AS Date), 6)
INSERT [dbo].[Student] ([id], [name], [gender], [departId], [dob], [gpa]) VALUES (7, N'Lạnh Như Băng', 1, N'AI', CAST(N'2001-04-25' AS Date), 8)
INSERT [dbo].[Student] ([id], [name], [gender], [departId], [dob], [gpa]) VALUES (8, N'TChu DE', 1, N'AI', CAST(N'2023-06-02' AS Date), 3)
INSERT [dbo].[Student] ([id], [name], [gender], [departId], [dob], [gpa]) VALUES (9, N'TChu DE', 0, N'SE', CAST(N'2000-06-13' AS Date), 3)
INSERT [dbo].[Student] ([id], [name], [gender], [departId], [dob], [gpa]) VALUES (10, N'Nguyen Van ko Co', 1, N'IA', CAST(N'2000-06-30' AS Date), 8)
INSERT [dbo].[Student] ([id], [name], [gender], [departId], [dob], [gpa]) VALUES (11, N'Có không', 0, N'AI', CAST(N'2000-06-11' AS Date), 7)
INSERT [dbo].[Student] ([id], [name], [gender], [departId], [dob], [gpa]) VALUES (12, N'Moi them vao', 1, N'En', CAST(N'2000-06-01' AS Date), 8)
INSERT [dbo].[Student] ([id], [name], [gender], [departId], [dob], [gpa]) VALUES (13, N'Thich Thi Thieu', 1, N'JP', CAST(N'2000-05-31' AS Date), 8.5)
INSERT [dbo].[Student] ([id], [name], [gender], [departId], [dob], [gpa]) VALUES (14, N'Vua A Dinh', 0, N'BA', CAST(N'2000-05-02' AS Date), 7.5)
INSERT [dbo].[Student] ([id], [name], [gender], [departId], [dob], [gpa]) VALUES (15, N'Dinh Vua Vua', 0, N'AI', CAST(N'2000-05-31' AS Date), 9)
INSERT [dbo].[Student] ([id], [name], [gender], [departId], [dob], [gpa]) VALUES (16, N'Nóng Như Lửa', 1, N'GD', CAST(N'2010-02-28' AS Date), 8)
INSERT [dbo].[Student] ([id], [name], [gender], [departId], [dob], [gpa]) VALUES (17, N'Nguyen Van A123', 1, N'En', CAST(N'2022-06-02' AS Date), 8.1)
INSERT [dbo].[Student] ([id], [name], [gender], [departId], [dob], [gpa]) VALUES (18, N'Tạo mới thêm vào', 0, N'BA', CAST(N'2023-06-28' AS Date), 11)
INSERT [dbo].[Student] ([id], [name], [gender], [departId], [dob], [gpa]) VALUES (19, N'Nguyen Van A321', 1, N'BA', CAST(N'2023-05-06' AS Date), 5.5)
INSERT [dbo].[Student] ([id], [name], [gender], [departId], [dob], [gpa]) VALUES (20, N'Nguyễn Văn ABC123', 1, N'JP', CAST(N'2023-06-02' AS Date), 1)
INSERT [dbo].[Student] ([id], [name], [gender], [departId], [dob], [gpa]) VALUES (21, N'Nguyen Van A', 1, N'GD', CAST(N'2023-05-11' AS Date), 8.1)
INSERT [dbo].[Student] ([id], [name], [gender], [departId], [dob], [gpa]) VALUES (22, N'Nguyen Van Thêm Vào', 1, N'En', CAST(N'2023-06-02' AS Date), 1.1)
INSERT [dbo].[Student] ([id], [name], [gender], [departId], [dob], [gpa]) VALUES (23, N'Nguyen Van AChut nữa', 0, N'BA', CAST(N'2023-05-03' AS Date), 1.2)
INSERT [dbo].[Student] ([id], [name], [gender], [departId], [dob], [gpa]) VALUES (24, N'Nguyen Van A11', 0, N'SE', CAST(N'2023-06-02' AS Date), 1.5)
INSERT [dbo].[Student] ([id], [name], [gender], [departId], [dob], [gpa]) VALUES (25, N'Nguyễn Văn ABC123', 0, N'En', CAST(N'2023-02-02' AS Date), 6.5)
INSERT [dbo].[Student] ([id], [name], [gender], [departId], [dob], [gpa]) VALUES (26, N'Nguyen Van A1211', 1, N'SE', CAST(N'2012-10-01' AS Date), 5.3)
INSERT [dbo].[Student] ([id], [name], [gender], [departId], [dob], [gpa]) VALUES (27, N'Nguyen Van ZZ', 1, N'BA', CAST(N'2008-02-15' AS Date), 4)
INSERT [dbo].[Student] ([id], [name], [gender], [departId], [dob], [gpa]) VALUES (28, N'Nguyen Van A321', 1, N'En', CAST(N'2023-06-03' AS Date), 5)
INSERT [dbo].[Student] ([id], [name], [gender], [departId], [dob], [gpa]) VALUES (30, N'Trần Như Nhộng', 0, N'En', CAST(N'2009-01-20' AS Date), 6.5)
INSERT [dbo].[Student] ([id], [name], [gender], [departId], [dob], [gpa]) VALUES (31, N'Vừa A Dính', 0, N'JP', CAST(N'2014-01-02' AS Date), 0)
INSERT [dbo].[Student] ([id], [name], [gender], [departId], [dob], [gpa]) VALUES (32, N'Dinh mot thoi', 0, N'SE', CAST(N'2023-02-07' AS Date), 7)
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Department] FOREIGN KEY([departId])
REFERENCES [dbo].[Department] ([id])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Department]
GO
USE [master]
GO
ALTER DATABASE [PRN211_1] SET  READ_WRITE 
GO