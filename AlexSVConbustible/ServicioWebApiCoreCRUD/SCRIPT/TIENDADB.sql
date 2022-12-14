CREATE DATABASE TIENDABD
GO
USE [TIENDABD]
GO
/****** Object:  Table [dbo].[PERSONA]    Script Date: 17/03/2022 10:36:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PERSONA](
	[intPersonaId] [int] IDENTITY(1,1) NOT NULL,
	[strDni] [varchar](50) NULL,
	[strNombre] [varchar](50) NULL,
	[intEdad] [int] NULL,
	[bitEstado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[intPersonaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PRODUCTO]    Script Date: 17/03/2022 10:36:04 ******/
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
SET IDENTITY_INSERT [dbo].[PERSONA] ON 

INSERT [dbo].[PERSONA] ([intPersonaId], [strDni], [strNombre], [intEdad], [bitEstado]) VALUES (1, N'321654', N'leo', 25, 1)
INSERT [dbo].[PERSONA] ([intPersonaId], [strDni], [strNombre], [intEdad], [bitEstado]) VALUES (2, N'321654', N'alex', 20, 1)
INSERT [dbo].[PERSONA] ([intPersonaId], [strDni], [strNombre], [intEdad], [bitEstado]) VALUES (3, N'321654', N'alex', 20, 1)
INSERT [dbo].[PERSONA] ([intPersonaId], [strDni], [strNombre], [intEdad], [bitEstado]) VALUES (4, N'6513', N'juan', 30, 1)
INSERT [dbo].[PERSONA] ([intPersonaId], [strDni], [strNombre], [intEdad], [bitEstado]) VALUES (6, N'32165', N'pedro', 50, 1)
INSERT [dbo].[PERSONA] ([intPersonaId], [strDni], [strNombre], [intEdad], [bitEstado]) VALUES (7, N'32165', N'pedro', 50, 1)
INSERT [dbo].[PERSONA] ([intPersonaId], [strDni], [strNombre], [intEdad], [bitEstado]) VALUES (8, N'654321', N'asd', 30, 0)
INSERT [dbo].[PERSONA] ([intPersonaId], [strDni], [strNombre], [intEdad], [bitEstado]) VALUES (9, N'654321', N'asd', 30, 1)
INSERT [dbo].[PERSONA] ([intPersonaId], [strDni], [strNombre], [intEdad], [bitEstado]) VALUES (10, N'65432', N'carlos', 30, 1)
INSERT [dbo].[PERSONA] ([intPersonaId], [strDni], [strNombre], [intEdad], [bitEstado]) VALUES (11, N'65432', N'carlos', 30, 1)
SET IDENTITY_INSERT [dbo].[PERSONA] OFF
GO
SET IDENTITY_INSERT [dbo].[PRODUCTO] ON 

INSERT [dbo].[PRODUCTO] ([intProductoId], [strProductoDesc], [intCantidad], [decPrecio], [bitEstado]) VALUES (2, N'camisa', 25, CAST(13.0000 AS Decimal(12, 4)), 1)
INSERT [dbo].[PRODUCTO] ([intProductoId], [strProductoDesc], [intCantidad], [decPrecio], [bitEstado]) VALUES (3, N'CPU', 1560, CAST(20.0000 AS Decimal(12, 4)), 1)
INSERT [dbo].[PRODUCTO] ([intProductoId], [strProductoDesc], [intCantidad], [decPrecio], [bitEstado]) VALUES (5, N'chaqueta', 14, CAST(32.0000 AS Decimal(12, 4)), 1)
INSERT [dbo].[PRODUCTO] ([intProductoId], [strProductoDesc], [intCantidad], [decPrecio], [bitEstado]) VALUES (9, N'celular', 20, CAST(30.0000 AS Decimal(12, 4)), 1)
SET IDENTITY_INSERT [dbo].[PRODUCTO] OFF
GO
ALTER TABLE [dbo].[PERSONA] ADD  CONSTRAINT [DF_PERSONA_bitEstado]  DEFAULT ((1)) FOR [bitEstado]
GO
ALTER TABLE [dbo].[PRODUCTO] ADD  CONSTRAINT [DF_PRODUCTO_estado]  DEFAULT ((1)) FOR [bitEstado]
GO
/****** Object:  StoredProcedure [dbo].[usp_persona_actualizar]    Script Date: 17/03/2022 10:36:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_persona_actualizar]
(
@intPersonaId int,
@strDni varchar(50),
@strNombre varchar(50),
@intEdad int 
)
as
begin
	UPDATE [dbo].[PERSONA]
	SET strDni = @strDni,
		strNombre = @strNombre,
		intEdad = @intEdad
		WHERE intPersonaId = @intPersonaId
end
GO
/****** Object:  StoredProcedure [dbo].[usp_persona_anulacionLogica]    Script Date: 17/03/2022 10:36:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[usp_persona_anulacionLogica]
(
@intPersonaId int 
)
as
begin
	UPDATE [dbo].[PERSONA]
	SET bitEstado = 'false'
	where intPersonaId = @intPersonaId
end
GO
/****** Object:  StoredProcedure [dbo].[usp_persona_eliminar]    Script Date: 17/03/2022 10:36:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[usp_persona_eliminar]
(
@intPersonaId int
)
as
begin
 DELETE FROM [dbo].[PERSONA]
 WHERE intPersonaId = @intPersonaId;
 end
GO
/****** Object:  StoredProcedure [dbo].[usp_persona_insert]    Script Date: 17/03/2022 10:36:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_persona_insert]
(
@strDni varchar(50),
@strNombre varchar(50),
@intEdad int

)
as
begin
	
	insert into [dbo].[PERSONA]
			(
			strDni,
			strNombre,
			intEdad
			
			)
			values
			(
			@strDni,
			@strNombre,
			@intEdad
			
			)
end
GO
/****** Object:  StoredProcedure [dbo].[usp_persona_listar]    Script Date: 17/03/2022 10:36:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_persona_listar]
as
begin
		select [intPersonaId],[strDni],[strNombre],[intEdad],[bitEstado] from [dbo].[PERSONA]
		where bitEstado = 'true'
end
GO
/****** Object:  StoredProcedure [dbo].[usp_persona_ListarById]    Script Date: 17/03/2022 10:36:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create proc [dbo].[usp_persona_ListarById]
(
@intPersonaId int
)
as
begin
		select [intPersonaId],[strDni],[strNombre],[intEdad],[bitEstado] from [dbo].[PERSONA]
		where bitEstado = 'true' and intPersonaId=@intPersonaId
end
GO
/****** Object:  StoredProcedure [dbo].[usp_prod_actualizar]    Script Date: 17/03/2022 10:36:04 ******/
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
/****** Object:  StoredProcedure [dbo].[usp_prod_anulacionLogica]    Script Date: 17/03/2022 10:36:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_prod_anulacionLogica]
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
/****** Object:  StoredProcedure [dbo].[usp_prod_eliminar]    Script Date: 17/03/2022 10:36:04 ******/
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
 DELETE FROM PRODUCTO 
 WHERE intProductoId = @intProductoId;
 end
GO
/****** Object:  StoredProcedure [dbo].[usp_prod_insert]    Script Date: 17/03/2022 10:36:04 ******/
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
/****** Object:  StoredProcedure [dbo].[usp_prod_listar]    Script Date: 17/03/2022 10:36:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_prod_listar]
as
begin
		select intProductoId,strProductoDesc,intCantidad,decPrecio,bitEstado from [dbo].[PRODUCTO]
		where bitEstado = 'true'
end
GO
/****** Object:  StoredProcedure [dbo].[usp_prod_ListarById]    Script Date: 17/03/2022 10:36:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[usp_prod_ListarById]
(
@intProductoId int
)
as
begin
		select intProductoId,strProductoDesc,intCantidad,decPrecio,bitEstado from [dbo].[PRODUCTO]
		where bitEstado='true' and intProductoId=@intProductoId
end
GO
