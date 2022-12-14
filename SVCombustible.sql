USE [master]
GO
/****** Object:  Database [SVCombustible]    Script Date: 23/08/2022 16:07:02 ******/
CREATE DATABASE [SVCombustible]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SVCombustible', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\SVCombustible.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SVCombustible_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\SVCombustible_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [SVCombustible] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SVCombustible].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SVCombustible] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SVCombustible] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SVCombustible] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SVCombustible] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SVCombustible] SET ARITHABORT OFF 
GO
ALTER DATABASE [SVCombustible] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SVCombustible] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SVCombustible] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SVCombustible] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SVCombustible] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SVCombustible] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SVCombustible] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SVCombustible] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SVCombustible] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SVCombustible] SET  ENABLE_BROKER 
GO
ALTER DATABASE [SVCombustible] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SVCombustible] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SVCombustible] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SVCombustible] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SVCombustible] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SVCombustible] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SVCombustible] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SVCombustible] SET RECOVERY FULL 
GO
ALTER DATABASE [SVCombustible] SET  MULTI_USER 
GO
ALTER DATABASE [SVCombustible] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SVCombustible] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SVCombustible] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SVCombustible] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SVCombustible] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SVCombustible] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'SVCombustible', N'ON'
GO
ALTER DATABASE [SVCombustible] SET QUERY_STORE = OFF
GO
USE [SVCombustible]
GO
/****** Object:  Table [dbo].[PRODUCTO]    Script Date: 23/08/2022 16:07:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PRODUCTO](
	[intProductoId] [int] IDENTITY(1,1) NOT NULL,
	[strProductoDesc] [varchar](50) NULL,
	[intCantidad] [int] NULL,
	[decPrecio] [decimal](12, 4) NULL,
	[bitEstado] [bit] NULL,
 CONSTRAINT [PK__PRODUCTO__3213E83FBAE4C4EA] PRIMARY KEY CLUSTERED 
(
	[intProductoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[PRODUCTO] ON 

INSERT [dbo].[PRODUCTO] ([intProductoId], [strProductoDesc], [intCantidad], [decPrecio], [bitEstado]) VALUES (1, N'gasol', 15, CAST(30.0000 AS Decimal(12, 4)), 1)
INSERT [dbo].[PRODUCTO] ([intProductoId], [strProductoDesc], [intCantidad], [decPrecio], [bitEstado]) VALUES (2, N'hola', 2, CAST(15.0000 AS Decimal(12, 4)), 0)
INSERT [dbo].[PRODUCTO] ([intProductoId], [strProductoDesc], [intCantidad], [decPrecio], [bitEstado]) VALUES (3, N'dasd', 15, CAST(50.0000 AS Decimal(12, 4)), 1)
INSERT [dbo].[PRODUCTO] ([intProductoId], [strProductoDesc], [intCantidad], [decPrecio], [bitEstado]) VALUES (4, N'sasa', 12, CAST(323.0000 AS Decimal(12, 4)), 1)
INSERT [dbo].[PRODUCTO] ([intProductoId], [strProductoDesc], [intCantidad], [decPrecio], [bitEstado]) VALUES (5, N'sasa', 12, CAST(323.0000 AS Decimal(12, 4)), 1)
INSERT [dbo].[PRODUCTO] ([intProductoId], [strProductoDesc], [intCantidad], [decPrecio], [bitEstado]) VALUES (6, N'dos', 12, CAST(323.0000 AS Decimal(12, 4)), 1)
INSERT [dbo].[PRODUCTO] ([intProductoId], [strProductoDesc], [intCantidad], [decPrecio], [bitEstado]) VALUES (7, N'dos', 12, CAST(323.0000 AS Decimal(12, 4)), 1)
INSERT [dbo].[PRODUCTO] ([intProductoId], [strProductoDesc], [intCantidad], [decPrecio], [bitEstado]) VALUES (8, N'tres', 3, CAST(3.0000 AS Decimal(12, 4)), 1)
INSERT [dbo].[PRODUCTO] ([intProductoId], [strProductoDesc], [intCantidad], [decPrecio], [bitEstado]) VALUES (9, N'rwer', 32, CAST(12.0000 AS Decimal(12, 4)), 1)
INSERT [dbo].[PRODUCTO] ([intProductoId], [strProductoDesc], [intCantidad], [decPrecio], [bitEstado]) VALUES (10, N'ttt', 3323, CAST(232.0000 AS Decimal(12, 4)), 1)
INSERT [dbo].[PRODUCTO] ([intProductoId], [strProductoDesc], [intCantidad], [decPrecio], [bitEstado]) VALUES (11, N'fff', 3414, CAST(323.0000 AS Decimal(12, 4)), 1)
SET IDENTITY_INSERT [dbo].[PRODUCTO] OFF
GO
ALTER TABLE [dbo].[PRODUCTO] ADD  CONSTRAINT [DF_PRODUCTO_estado]  DEFAULT ((1)) FOR [bitEstado]
GO
/****** Object:  StoredProcedure [dbo].[usp_prod_actualizar]    Script Date: 23/08/2022 16:07:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_prod_actualizar]
(
@intProductoId int,
@strProductoDesc varchar(50),
@intCantidad int ,
@decPrecio decimal(12,4)
)
as
begin
	UPDATE [dbo].[PRODUCTO]
	SET strProductoDesc = @strProductoDesc,
		intCantidad = @intCantidad,
		decPrecio = @decPrecio
		WHERE intProductoId = @intProductoId
end
GO
/****** Object:  StoredProcedure [dbo].[usp_prod_eliminar]    Script Date: 23/08/2022 16:07:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	create proc [dbo].[usp_prod_eliminar]
	(
	@intProductoId int 
	)
	as
	begin
		UPDATE [dbo].[PRODUCTO]
		SET bitEstado = 'false'
		where intProductoId = @intProductoId
	end
GO
/****** Object:  StoredProcedure [dbo].[usp_prod_insert]    Script Date: 23/08/2022 16:07:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_prod_insert]
(
@strProductoDesc varchar(50),
@intCantidad int,
@decPrecio decimal(12,4)
)
as
begin
	
	insert into [dbo].[PRODUCTO]
			(
			strProductoDesc,
			intCantidad,
			decPrecio
			
			)
			values
			(
			@strProductoDesc,
			@intCantidad,
			@decPrecio
			
			)
end
GO
/****** Object:  StoredProcedure [dbo].[usp_prod_listar]    Script Date: 23/08/2022 16:07:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_prod_listar]
as
begin
		select intProductoId,strProductoDesc,intCantidad,decPrecio,bitEstado from [dbo].[PRODUCTO]
		where bitEstado = 'true'
end
GO
USE [master]
GO
ALTER DATABASE [SVCombustible] SET  READ_WRITE 
GO
