USE [master]
GO
/****** Object:  Database [GD2C2018]    Script Date: 05/10/2018 03:33:57 p. m. ******/
CREATE DATABASE [GD2C2018]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GD2C2018', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLSERVER2012\MSSQL\DATA\GD2C2018.mdf' , SIZE = 279552KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'GD2C2018_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLSERVER2012\MSSQL\DATA\GD2C2018_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [GD2C2018] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GD2C2018].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GD2C2018] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GD2C2018] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GD2C2018] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GD2C2018] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GD2C2018] SET ARITHABORT OFF 
GO
ALTER DATABASE [GD2C2018] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [GD2C2018] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [GD2C2018] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GD2C2018] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GD2C2018] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GD2C2018] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GD2C2018] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GD2C2018] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GD2C2018] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GD2C2018] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GD2C2018] SET DISABLE_BROKER 
GO
ALTER DATABASE [GD2C2018] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GD2C2018] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GD2C2018] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GD2C2018] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GD2C2018] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GD2C2018] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [GD2C2018] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GD2C2018] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [GD2C2018] SET MULTI_USER 
GO
ALTER DATABASE [GD2C2018] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GD2C2018] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GD2C2018] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GD2C2018] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [GD2C2018]
GO
/****** Object:  User [gdEspectaculos2018]    Script Date: 05/10/2018 03:33:57 p. m. ******/
CREATE USER [gdEspectaculos2018] FOR LOGIN [gdEspectaculos2018] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Schema [gd_esquema]    Script Date: 05/10/2018 03:33:58 p. m. ******/
CREATE SCHEMA [gd_esquema]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 05/10/2018 03:33:58 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [IF NOT EXISTS] [dbo].[Cliente](
	[clie_id] INT NOT NULL AUTO_INCREMENT,
	[clie_nombre] [nvarchar](50) NOT NULL,
	[clie_apellido] [nvarchar](50) NOT NULL,
	[clie_tipo_documento] [nvarchar](255) NOT NULL,
	[clie_documento] INT NOT NULL,
	[clie_CUIL] [nchar](11) NOT NULL,
	[clie_email] [nvarchar](50) NOT NULL,
	[clie_telefono] [nchar](10) NOT NULL,
	[clie_direccion_id] INT NOT NULL,
	[clie_fecha_nacimiento] [date] NOT NULL,
	[clie_fecha_creacion] [date] NOT NULL,
	[clie_tarjeta_id] INT NOT NULL,
	[clie_habilitado] BOOLEAN NOT NULL,
	[clie_usuario_id] INT,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[clie_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Compra]    Script Date: 05/10/2018 03:33:58 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [IF NOT EXISTS] [dbo].[Compra](
	[compra_id] INT NOT NULL AUTO_INCREMENT,
	[compra_fecha] [datetime] NOT NULL,
	[compra_cantidad] [numeric](18, 0) NOT NULL,
	[compra_cliente_id] INT NOT NULL,
 CONSTRAINT [PK_Compra] PRIMARY KEY CLUSTERED 
(
	[compra_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Direccion]    Script Date: 05/10/2018 03:33:58 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [IF NOT EXISTS] [dbo].[Direccion](
	[dire_id] INT NOT NULL AUTO_INCREMENT,
	[dire_calle] [nchar](10) NULL,
	[dire_numero] [nchar](10) NULL,
	[dire_piso] [nchar](10) NULL,
	[dire_depto] [nchar](10) NULL,
	[dire_localidad] [nchar](10) NULL,
	[dire_codigo_postal] [nchar](10) NULL,
 CONSTRAINT [PK_Direccion] PRIMARY KEY CLUSTERED 
(
	[dire_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Empresa]    Script Date: 05/10/2018 03:33:58 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [IF NOT EXISTS] [dbo].[Empresa](
	[empre_id] INT NOT NULL AUTO_INCREMENT,
	[empre_razon_social] [nvarchar](255) NULL,
	[empre_cuit] [nvarchar](255) NULL,
	[empre_fecha_creacion] [datetime] NULL,
	[empre_mail] [nvarchar](50) NULL,
	[empre_direccion_id] INT NULL,
	[empre_telefono] [nvarchar](50) NULL,
	[empre_usuario_id] INT NULL,
 CONSTRAINT [PK_Empresa] PRIMARY KEY CLUSTERED 
(
	[empre_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Espectaculo]    Script Date: 05/10/2018 03:33:58 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [IF NOT EXISTS] [dbo].[Espectaculo](
	[espec_id] INT NOT NULL AUTO_INCREMENT,
	[espec_codigo] [numeric](18, 0) NULL,
	[espec_descripcion] [nvarchar](255) NULL,
	[espec_fecha] [datetime] NULL,
	[espec_fecha_venc] [datetime] NULL,
	[espec_rubro_id] INT NULL,
	[espec_estado] [nvarchar](255) NULL,
 CONSTRAINT [PK_Espectaculo] PRIMARY KEY CLUSTERED 
(
	[espec_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Estado]    Script Date: 05/10/2018 03:33:58 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [IF NOT EXISTS] [dbo].[Estado](
	[estado_id] INT NOT NULL AUTO_INCREMENT,
	[estado_descripcion] [nvarchar](50) NULL,
	[estado_inicial] BOOLEAN NULL,
	[estado_final] BOOLEAN NULL,
 CONSTRAINT [PK_Estado] PRIMARY KEY CLUSTERED 
(
	[estado_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Factura]    Script Date: 05/10/2018 03:33:58 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [IF NOT EXISTS] [dbo].[Factura](
	[fact_id] INT NOT NULL AUTO_INCREMENT,
	[fact_nro] [numeric](18, 0) NULL,
	[fact_fecha] [datetime] NULL,
	[fact_total] [numeric](18, 2) NULL,
	[fact_pago_desc] [nvarchar](255) NULL,
	[fact_cliente_id] INT NULL,
	[fact_empresa_id] INT NULL,
 CONSTRAINT [PK_Factura] PRIMARY KEY CLUSTERED 
(
	[fact_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Func_Rol]    Script Date: 05/10/2018 03:33:58 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [IF NOT EXISTS] [dbo].[Func_Rol](
	[funci_id] INT NOT NULL,
	[rol_id] INT NOT NULL,
 CONSTRAINT [PK_Func_Rol] PRIMARY KEY CLUSTERED 
(
	[funci_id] ASC,
	[rol_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Funcionalidad]    Script Date: 05/10/2018 03:33:58 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [IF NOT EXISTS] [dbo].[Funcionalidad](
	[funci_id] INT NOT NULL,
	[func_descripcion] [nchar](10) NULL,
 CONSTRAINT [PK_Funcionalidad] PRIMARY KEY CLUSTERED 
(
	[funci_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Grado]    Script Date: 05/10/2018 03:33:58 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [IF NOT EXISTS] [dbo].[Grado](
	[grado_id] INT NOT NULL AUTO_INCREMENT,
	[grado_descripcion] [nvarchar](50) NULL,
	[grado_comision] [numeric](18, 0) NULL,
	[grado_porcentaje] [numeric](18, 0) NULL,
 CONSTRAINT [PK_Grado] PRIMARY KEY CLUSTERED 
(
	[grado_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Item_Factura]    Script Date: 05/10/2018 03:33:58 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [IF NOT EXISTS] [dbo].[Item_Factura](
	[item_id] INT NOT NULL AUTO_INCREMENT,
	[item_monto] [numeric](18, 2) NULL,
	[item_cantidad] [numeric](18, 0) NULL,
	[item_descripcion] [nvarchar](60) NULL,
	[item_factura_id] INT NULL,
	[item_ubicacion_id] INT NULL,
 CONSTRAINT [PK_Item_Factura] PRIMARY KEY CLUSTERED 
(
	[item_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Publicacion]    Script Date: 05/10/2018 03:33:58 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [IF NOT EXISTS] [dbo].[Publicacion](
	[publi_id] INT NOT NULL AUTO_INCREMENT,
	[publi_descripcion] [nvarchar](50) NULL,
	[publi_estado_id] INT NULL,
	[publi_fecha_inicio] [datetime] NULL,
	[publi_fecha_evento] [datetime] NULL,
	[publi_codigo] [numeric](18, 0) NULL,
	[publi_rubro_id] INT NULL,
	[publi_usuario_id] INT NULL,
	[publi_espectaculo_id] INT NULL,
	[publi_grado_id] INT NULL,
	[publi_stock] INT NULL,	
 CONSTRAINT [PK_Publicacion] PRIMARY KEY CLUSTERED 
(
	[publi_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Rol]    Script Date: 05/10/2018 03:33:58 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [IF NOT EXISTS] [dbo].[Rol](
	[rol_id] INT NOT NULL AUTO_INCREMENT,
	[rol_nombre] [nchar](60) NOT NULL,
	[rol_habilitado] BOOLEAN NOT NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[rol_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Rol_Usuario]    Script Date: 05/10/2018 03:33:58 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [IF NOT EXISTS] [dbo].[Rol_Usuario](
	[rol_id] INT NOT NULL,
	[usuario_id] INT NOT NULL,
 CONSTRAINT [PK_Rol_Usuario] PRIMARY KEY CLUSTERED 
(
	[rol_id] ASC,
	[usuario_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Rubro]    Script Date: 05/10/2018 03:33:58 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [IF NOT EXISTS] [dbo].[Rubro](
	[rubro_id] INT NOT NULL,
	[rubro_codigo] [nchar](10) NULL,
	[rubro_descripcion] [nvarchar](255) NULL,
 CONSTRAINT [PK_Rubro] PRIMARY KEY CLUSTERED 
(
	[rubro_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Ubicacion]    Script Date: 05/10/2018 03:33:58 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [IF NOT EXISTS] [dbo].[Ubicacion](
	[ubica_id] INT NOT NULL,
	[ubica_fila] [varbinary](3) NULL,
	[ubica_asiento] [numeric](18, 0) NULL,
	[ubica_sin_numerar] BOOLEAN NULL,
	[ubica_precio] [numeric](18, 0) NULL,
	[ubica_tipo_codigo] [numeric](18, 0) NULL,
	[ubica_tipo_descripcion] [nvarchar](255) NULL,
	[ubica_facturada] BOOLEAN NULL,
 CONSTRAINT [PK_Ubicacion] PRIMARY KEY CLUSTERED 
(
	[ubica_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ubicacion_Compra]    Script Date: 05/10/2018 03:33:58 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [IF NOT EXISTS] [dbo].[Ubicacion_Compra](
	[ubica_id] INT NULL,
	[compra_id] INT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ubicacion_Publicacion]    Script Date: 05/10/2018 03:33:58 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [IF NOT EXISTS] [dbo].[Ubicacion_Publicacion](
	[ubica_id] INT NULL,
	[publi_id] INT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 05/10/2018 03:33:58 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [IF NOT EXISTS] [dbo].[Usuario](
	[usuario_id] INT NOT NULL,
	[usuario_username] [nchar](10) NULL,
	[usuario_password] [nchar](10) NULL,
	[usuario_habilitado] BOOLEAN NULL,
	[usuario_cant_logeo_error] [int] NULL,
	[usuario_tipo] [nvarchar](55) NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[usuario_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Tarjeta]    Script Date: 05/10/2018 03:33:58 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [IF NOT EXISTS] [dbo].[Tarjeta](
	[tarj_id] INT NOT NULL,
	[tarj_numero] [nchar](10) NULL,
	[tarj_cod_seguridad] [nchar](10) NULL,
	[tarj_vencimiento] BOOLEAN NULL,
	[tarj_titular] [int] NULL,
	[tarj_tipo] INT NULL,
 CONSTRAINT [PK_Tarjeta] PRIMARY KEY CLUSTERED 
(
	[tarj_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Puntaje]    Script Date: 05/10/2018 03:33:58 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [IF NOT EXISTS] [dbo].[Puntaje](
	[punt_id] INT NOT NULL,
	[punt_id_cliente] [nchar](10) NULL,
	[punt_cantidad] [nchar](10) NULL,
	[punt_vencimiento] BOOLEAN NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[usuario_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [gd_esquema].[Maestra]    Script Date: 05/10/2018 03:33:58 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Direccion] FOREIGN KEY([clie_direccion_id])
REFERENCES [dbo].[Direccion] ([dire_id])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_Cliente_Direccion]
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Documento] FOREIGN KEY([clie_documento])
REFERENCES [dbo].[Documento] ([doc_id])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_Cliente_Documento]
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Usuario] FOREIGN KEY([clie_usuario_id])
REFERENCES [dbo].[Usuario] ([usuario_id])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_Cliente_Usuario]
GO
ALTER TABLE [dbo].[Compra]  WITH CHECK ADD  CONSTRAINT [FK_Compra_Cliente] FOREIGN KEY([compra_cliente_id])
REFERENCES [dbo].[Cliente] ([clie_id])
GO
ALTER TABLE [dbo].[Compra] CHECK CONSTRAINT [FK_Compra_Cliente]
GO
ALTER TABLE [dbo].[Documento]  WITH CHECK ADD  CONSTRAINT [FK_Documento_Tipo_Documento] FOREIGN KEY([doc_tipo_id])
REFERENCES [dbo].[Tipo_Documento] ([tipo_doc_id])
GO
ALTER TABLE [dbo].[Documento] CHECK CONSTRAINT [FK_Documento_Tipo_Documento]
GO
ALTER TABLE [dbo].[Empresa]  WITH CHECK ADD  CONSTRAINT [FK_Empresa_Direccion] FOREIGN KEY([empre_direccion_id])
REFERENCES [dbo].[Direccion] ([dire_id])
GO
ALTER TABLE [dbo].[Empresa] CHECK CONSTRAINT [FK_Empresa_Direccion]
GO
ALTER TABLE [dbo].[Empresa]  WITH CHECK ADD  CONSTRAINT [FK_Empresa_Usuario] FOREIGN KEY([empre_usuario_id])
REFERENCES [dbo].[Usuario] ([usuario_id])
GO
ALTER TABLE [dbo].[Empresa] CHECK CONSTRAINT [FK_Empresa_Usuario]
GO
ALTER TABLE [dbo].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_Factura_Cliente] FOREIGN KEY([fact_cliente_id])
REFERENCES [dbo].[Cliente] ([clie_id])
GO
ALTER TABLE [dbo].[Factura] CHECK CONSTRAINT [FK_Factura_Cliente]
GO
ALTER TABLE [dbo].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_Factura_Empresa] FOREIGN KEY([fact_Empresa_id])
REFERENCES [dbo].[Empresa] ([empre_id])
GO
ALTER TABLE [dbo].[Factura] CHECK CONSTRAINT [FK_Factura_Empresa]
GO
ALTER TABLE [dbo].[Func_Rol]  WITH CHECK ADD  CONSTRAINT [FK_Func_Rol_Funcionalidad] FOREIGN KEY([funci_id])
REFERENCES [dbo].[Funcionalidad] ([funci_id])
GO
ALTER TABLE [dbo].[Func_Rol] CHECK CONSTRAINT [FK_Func_Rol_Funcionalidad]
GO
ALTER TABLE [dbo].[Func_Rol]  WITH CHECK ADD  CONSTRAINT [FK_Func_Rol_Rol] FOREIGN KEY([rol_id])
REFERENCES [dbo].[Rol] ([rol_id])
GO
ALTER TABLE [dbo].[Func_Rol] CHECK CONSTRAINT [FK_Func_Rol_Rol]
GO
ALTER TABLE [dbo].[Item_Factura]  WITH CHECK ADD  CONSTRAINT [FK_Item_Factura_Factura] FOREIGN KEY([item_factura_id])
REFERENCES [dbo].[Factura] ([fact_id])
GO
ALTER TABLE [dbo].[Item_Factura] CHECK CONSTRAINT [FK_Item_Factura_Factura]
GO
ALTER TABLE [dbo].[Item_Factura]  WITH CHECK ADD  CONSTRAINT [FK_Item_Factura_Factura1] FOREIGN KEY([item_factura_id])
REFERENCES [dbo].[Factura] ([fact_id])
GO
ALTER TABLE [dbo].[Item_Factura] CHECK CONSTRAINT [FK_Item_Factura_Factura1]
GO
ALTER TABLE [dbo].[Item_Factura]  WITH CHECK ADD  CONSTRAINT [FK_Item_Factura_Ubicacion] FOREIGN KEY([item_ubicacion_id])
REFERENCES [dbo].[Ubicacion] ([ubica_id])
GO
ALTER TABLE [dbo].[Item_Factura] CHECK CONSTRAINT [FK_Item_Factura_Ubicacion]
GO
ALTER TABLE [dbo].[Publicacion]  WITH CHECK ADD  CONSTRAINT [FK_Publicacion_Espectaculo] FOREIGN KEY([publi_espectaculo_id])
REFERENCES [dbo].[Espectaculo] ([espec_id])
GO
ALTER TABLE [dbo].[Publicacion] CHECK CONSTRAINT [FK_Publicacion_Espectaculo]
GO
ALTER TABLE [dbo].[Publicacion]  WITH CHECK ADD  CONSTRAINT [FK_Publicacion_Estado] FOREIGN KEY([publi_estado_id])
REFERENCES [dbo].[Estado] ([estado_id])
GO
ALTER TABLE [dbo].[Publicacion] CHECK CONSTRAINT [FK_Publicacion_Estado]
GO
ALTER TABLE [dbo].[Publicacion]  WITH CHECK ADD  CONSTRAINT [FK_Publicacion_Grado] FOREIGN KEY([publi_grado_id])
REFERENCES [dbo].[Grado] ([grado_id])
GO
ALTER TABLE [dbo].[Publicacion] CHECK CONSTRAINT [FK_Publicacion_Grado]
GO
ALTER TABLE [dbo].[Publicacion]  WITH CHECK ADD  CONSTRAINT [FK_Publicacion_Rubro] FOREIGN KEY([publi_rubro_id])
REFERENCES [dbo].[Rubro] ([rubro_id])
GO
ALTER TABLE [dbo].[Publicacion] CHECK CONSTRAINT [FK_Publicacion_Rubro]
GO
ALTER TABLE [dbo].[Rol_Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Rol_Usuario_Rol] FOREIGN KEY([rol_id])
REFERENCES [dbo].[Rol] ([rol_id])
GO
ALTER TABLE [dbo].[Rol_Usuario] CHECK CONSTRAINT [FK_Rol_Usuario_Rol]
GO
ALTER TABLE [dbo].[Rol_Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Rol_Usuario_Usuario] FOREIGN KEY([usuario_id])
REFERENCES [dbo].[Usuario] ([usuario_id])
GO
ALTER TABLE [dbo].[Rol_Usuario] CHECK CONSTRAINT [FK_Rol_Usuario_Usuario]
GO
ALTER TABLE [dbo].[Ubicacion_Compra]  WITH CHECK ADD  CONSTRAINT [FK_Ubicacion_Compra_Compra] FOREIGN KEY([compra_id])
REFERENCES [dbo].[Compra] ([compra_id])
GO
ALTER TABLE [dbo].[Ubicacion_Compra] CHECK CONSTRAINT [FK_Ubicacion_Compra_Compra]
GO
ALTER TABLE [dbo].[Ubicacion_Compra]  WITH CHECK ADD  CONSTRAINT [FK_Ubicacion_Compra_Ubicacion] FOREIGN KEY([ubica_id])
REFERENCES [dbo].[Ubicacion] ([ubica_id])
GO
ALTER TABLE [dbo].[Ubicacion_Compra] CHECK CONSTRAINT [FK_Ubicacion_Compra_Ubicacion]
GO
ALTER TABLE [dbo].[Ubicacion_Publicacion]  WITH CHECK ADD  CONSTRAINT [FK_Ubicacion_Publicacion_Publicacion] FOREIGN KEY([publi_id])
REFERENCES [dbo].[Publicacion] ([publi_id])
GO
ALTER TABLE [dbo].[Ubicacion_Publicacion] CHECK CONSTRAINT [FK_Ubicacion_Publicacion_Publicacion]
GO
ALTER TABLE [dbo].[Ubicacion_Publicacion]  WITH CHECK ADD  CONSTRAINT [FK_Ubicacion_Publicacion_Ubicacion] FOREIGN KEY([ubica_id])
REFERENCES [dbo].[Ubicacion] ([ubica_id])
GO
ALTER TABLE [dbo].[Ubicacion_Publicacion] CHECK CONSTRAINT [FK_Ubicacion_Publicacion_Ubicacion]
GO
USE [master]
GO
ALTER DATABASE [GD2C2018] SET  READ_WRITE 
GO