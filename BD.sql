USE [API]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 14/12/2022 03:44:45 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[id_usuarios] [int] IDENTITY(1,1) NOT NULL,
	[nombre_usuario] [varchar](300) NULL,
	[primer_apellido] [varchar](300) NULL,
	[segundo_apellido] [varchar](300) NULL,
	[sexo] [varchar](20) NULL,
	[activo] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_usuarios] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([id_usuarios], [nombre_usuario], [primer_apellido], [segundo_apellido], [sexo], [activo]) VALUES (14, N'juan carlos', N'ortiz ', N'tiscareño', N'M', 1)
INSERT [dbo].[Usuarios] ([id_usuarios], [nombre_usuario], [primer_apellido], [segundo_apellido], [sexo], [activo]) VALUES (16, N'maria victoria ', N'ortiz ', N'de luna', N'M', 1)
INSERT [dbo].[Usuarios] ([id_usuarios], [nombre_usuario], [primer_apellido], [segundo_apellido], [sexo], [activo]) VALUES (17, N'luis antonio', N'ortiz', N'tiscareño', N'F', 1)
INSERT [dbo].[Usuarios] ([id_usuarios], [nombre_usuario], [primer_apellido], [segundo_apellido], [sexo], [activo]) VALUES (18, N'FUFI', N'ORTIZ', N'TISCAREÑO', N'F', 1)
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
/****** Object:  StoredProcedure [dbo].[sp_consulta_usuarios]    Script Date: 14/12/2022 03:44:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Juan Carlos Ortiz Tiscareño
-- Create date: 14/14/2022
-- Description:	Consulta Usuarios select * from usuarios
-- =============================================
CREATE PROCEDURE [dbo].[sp_consulta_usuarios] 
	@id_usuarios int 
AS
BEGIN
	SET NOCOUNT ON;
	if(@id_usuarios !=0)
	BEGIN
	select * from Usuarios where id_usuarios=@id_usuarios
	END
	ELSE 
	BEGIN
	select * from Usuarios
	END
   
END
GO
/****** Object:  StoredProcedure [dbo].[sp_elimina_usuario]    Script Date: 14/12/2022 03:44:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Juan Carlos Ortiz Tiscareño
-- Create date: 14/14/2022
-- Description:	Elimina Usuarios select * from usuarios
-- =============================================
CREATE PROCEDURE [dbo].[sp_elimina_usuario]
	@id_usuarios int 
AS
BEGIN
	SET NOCOUNT ON;
	delete from Usuarios where id_usuarios=@id_usuarios
   
END
GO
/****** Object:  StoredProcedure [dbo].[sp_insertaActualiza_usuarios]    Script Date: 14/12/2022 03:44:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Juan Carlos Ortiz Tiscareño
-- Create date: 14/14/2022
-- Description:	Inserta  o actualiza Usuarios select * from usuarios
-- =============================================
CREATE PROCEDURE [dbo].[sp_insertaActualiza_usuarios] 
	@id_usuarios int ,
	@nombre_usuario varchar(300),
	@primer_apellido  varchar(300),
	@segundo_apellido  varchar(300),
	@sexo varchar(20),
	@activo bit
AS
BEGIN
	SET NOCOUNT ON;
	if EXISTS (select * from Usuarios where id_usuarios=@id_usuarios)
	BEGIN
	update Usuarios 
	set nombre_usuario=@nombre_usuario,primer_apellido=@primer_apellido,segundo_apellido=@segundo_apellido,sexo=@sexo,activo=@activo where id_usuarios=@id_usuarios
    END
	ELSE 
	BEGIN
	insert into Usuarios(nombre_usuario,primer_apellido,segundo_apellido,sexo,activo)values
	(@nombre_usuario,@primer_apellido,@segundo_apellido,@sexo,@activo)

	END
   
END
GO
