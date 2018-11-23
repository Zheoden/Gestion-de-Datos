USE GD2C2018;

/* Creacion del schema */
IF NOT EXISTS (select * from sys.schemas where name = 'EL_REJUNTE')
BEGIN
EXEC('create schema EL_REJUNTE')
END;
GO

/* Creacion de las tablas */
IF NOT EXISTS (select * from sysobjects where name='Cliente' and xtype='U')
CREATE TABLE EL_REJUNTE.Cliente(
	clie_id INT NOT NULL IDENTITY(1,1),
	clie_nombre nvarchar(50) NOT NULL,
	clie_apellido nvarchar(50) NOT NULL,
	clie_tipo_documento nvarchar(255) NOT NULL,
	clie_documento nvarchar(8) NOT NULL,
	clie_cuil nvarchar(11) NULL,
	clie_email nvarchar(50) NOT NULL,
	clie_telefono nvarchar(50) NULL,
	clie_direccion_id INT NULL,
	clie_fecha_nacimiento date NOT NULL,
	clie_fecha_creacion date NOT NULL,
	clie_tarjeta_id INT NULL,
	clie_habilitado bit NOT NULL,
	clie_usuario_id INT,
 CONSTRAINT PK_Cliente PRIMARY KEY CLUSTERED(
	clie_id ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)ON [PRIMARY]
GO

IF NOT EXISTS (select * from sysobjects where name='Compra' and xtype='U')
CREATE TABLE EL_REJUNTE.Compra(
	compra_id INT NOT NULL IDENTITY(1,1),
	compra_fecha datetime NOT NULL,
	compra_cantidad numeric(18, 0) NOT NULL,
	compra_cliente_id INT NOT NULL,
 CONSTRAINT PK_Compra PRIMARY KEY CLUSTERED(
	compra_id ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)ON [PRIMARY]
GO

IF NOT EXISTS (select * from sysobjects where name='Direccion' and xtype='U')
CREATE TABLE EL_REJUNTE.Direccion(
	dire_id INT NOT NULL IDENTITY(1,1),
	dire_calle nvarchar(255) NOT NULL,
	dire_numero nvarchar(50) NOT NULL,
	dire_piso nvarchar(50) NULL,
	dire_depto nvarchar(50) NULL,
	dire_localidad nvarchar(50) NULL,
	dire_codigo_postal nvarchar(50) NOT NULL,
 CONSTRAINT PK_Direccion PRIMARY KEY CLUSTERED(
	dire_id ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)ON [PRIMARY]
GO

IF NOT EXISTS (select * from sysobjects where name='Empresa' and xtype='U')
CREATE TABLE EL_REJUNTE.Empresa(
	empre_id INT NOT NULL IDENTITY(1,1),
	empre_razon_social nvarchar(255) NOT NULL,
	empre_cuit nvarchar(255) NOT NULL,
	empre_fecha_creacion datetime NOT NULL,
	empre_mail nvarchar(50) NULL,
	empre_direccion_id INT NULL,
	empre_telefono nvarchar(50) NULL,
	empre_usuario_id INT NULL,
	empre_baja_logica BIT NOT NULL,
 CONSTRAINT PK_Empresa PRIMARY KEY CLUSTERED(
	empre_id ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)ON [PRIMARY]
GO

IF NOT EXISTS (select * from sysobjects where name='Espectaculo' and xtype='U')
CREATE TABLE EL_REJUNTE.Espectaculo(
	espec_id INT NOT NULL IDENTITY(1,1),
	espec_codigo numeric(18, 0) NULL,
	espec_descripcion nvarchar(255) NOT NULL,
	espec_fecha datetime NULL,
	espec_fecha_venc datetime NULL,
	espec_rubro_id INT NULL,
	espec_estado_id INT NOT NULL,
	espec_direccion_id INT NULL,
 CONSTRAINT PK_Espectaculo PRIMARY KEY CLUSTERED(
	espec_id ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)ON [PRIMARY]
GO

IF NOT EXISTS (select * from sysobjects where name='Estado' and xtype='U')
CREATE TABLE EL_REJUNTE.Estado(
	estado_id INT NOT NULL IDENTITY(1,1),
	estado_descripcion nvarchar(255) NOT NULL,
	estado_habilitado BIT NULL,
 CONSTRAINT PK_Estado PRIMARY KEY CLUSTERED(
	estado_id ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)ON [PRIMARY]
GO

IF NOT EXISTS (select * from sysobjects where name='Factura' and xtype='U')
CREATE TABLE EL_REJUNTE.Factura(
	fact_id INT NOT NULL IDENTITY(1,1),
	fact_nro numeric(18, 0) NOT NULL,
	fact_fecha datetime NOT NULL,
	fact_total numeric(18, 2) NOT NULL,
	fact_pago_desc nvarchar(255) NULL,
	fact_cliente_id INT NULL,
	fact_empresa_id INT NULL,
 CONSTRAINT PK_Factura PRIMARY KEY CLUSTERED(
	fact_id ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)ON [PRIMARY]
GO

IF NOT EXISTS (select * from sysobjects where name='Func_Rol' and xtype='U')
CREATE TABLE EL_REJUNTE.Func_Rol(
	func_id INT NOT NULL,
	rol_id INT NOT NULL,
 CONSTRAINT PK_Func_Rol PRIMARY KEY CLUSTERED (
	func_id ASC,
	rol_id ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)ON [PRIMARY]
GO

IF NOT EXISTS (select * from sysobjects where name='Funcionalidad' and xtype='U')
CREATE TABLE EL_REJUNTE.Funcionalidad(
	func_id INT NOT NULL IDENTITY(1,1),
	func_descripcion nvarchar(255) NOT NULL,
 CONSTRAINT PK_Funcionalidad PRIMARY KEY CLUSTERED(
	func_id ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)ON [PRIMARY]
GO

IF NOT EXISTS (select * from sysobjects where name='Grado' and xtype='U')
CREATE TABLE EL_REJUNTE.Grado(
	grado_id INT NOT NULL IDENTITY(1,1),
	grado_prioridad nvarchar(255) NOT NULL,
	grado_comision numeric(18, 0) NOT NULL,
	grado_habilitado BIT NOT NULL,
 CONSTRAINT PK_Grado PRIMARY KEY CLUSTERED(
	grado_id ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)ON [PRIMARY]
GO

IF NOT EXISTS (select * from sysobjects where name='Item_Factura' and xtype='U')
CREATE TABLE EL_REJUNTE.Item_Factura(
	item_id INT NOT NULL IDENTITY(1,1),
	item_monto numeric(18, 2) NOT NULL,
	item_cantidad numeric(18, 0) NOT NULL,
	item_descripcion nvarchar(255) NOT NULL,
	item_factura_id INT NULL,
	item_ubicacion_id INT NULL,
 CONSTRAINT PK_Item_Factura PRIMARY KEY CLUSTERED(
	item_id ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)ON [PRIMARY]
GO

IF NOT EXISTS (select * from sysobjects where name='Publicacion' and xtype='U')
CREATE TABLE EL_REJUNTE.Publicacion(
	publi_id INT NOT NULL IDENTITY(1,1),
	publi_descripcion nvarchar(255) NOT NULL,
	publi_estado_id INT NULL,
	publi_fecha_inicio datetime NOT NULL,
	publi_fecha_evento datetime NOT NULL,
	publi_codigo numeric(18, 0) NOT NULL,
	publi_rubro_id INT NULL,
	publi_usuario_id INT NULL,
	publi_espectaculo_id INT NULL,
	publi_grado_id INT NULL,
	publi_stock INT NULL,	
 CONSTRAINT PK_Publicacion PRIMARY KEY CLUSTERED(
	publi_id ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)ON [PRIMARY]
GO

IF NOT EXISTS (select * from sysobjects where name='Puntaje' and xtype='U')
CREATE TABLE EL_REJUNTE.Puntaje(
	punt_id INT NOT NULL IDENTITY(1,1),
	punt_cliente_id INT NOT NULL,
	punt_cantidad INT NOT NULL,
	punt_vencimiento datetime NOT NULL,
 CONSTRAINT PK_Puntaje PRIMARY KEY CLUSTERED(
	punt_id ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)ON [PRIMARY]
GO

IF NOT EXISTS (select * from sysobjects where name='Rol' and xtype='U')
CREATE TABLE EL_REJUNTE.Rol(
	rol_id INT NOT NULL IDENTITY(1,1),
	rol_nombre nvarchar(255) NOT NULL,
	rol_habilitado BIT NOT NULL,
	rol_baja_logica BIT NOT NULL,
 CONSTRAINT PK_Rol PRIMARY KEY CLUSTERED(
	rol_id ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)ON [PRIMARY]
GO

IF NOT EXISTS (select * from sysobjects where name='Rol_Usuario' and xtype='U')
CREATE TABLE EL_REJUNTE.Rol_Usuario(
	rol_id INT NOT NULL,
	usuario_id INT NOT NULL,
 CONSTRAINT PK_Rol_Usuario PRIMARY KEY CLUSTERED(
	rol_id ASC,
	usuario_id ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

IF NOT EXISTS (select * from sysobjects where name='Rubro' and xtype='U')
CREATE TABLE EL_REJUNTE.Rubro(
	rubro_id INT NOT NULL IDENTITY(1,1),
	rubro_descripcion nvarchar(255) NOT NULL,
	rubro_habilitado BIT NOT NULL,
 CONSTRAINT PK_Rubro PRIMARY KEY CLUSTERED(
	rubro_id ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

IF NOT EXISTS (select * from sysobjects where name='Tarjeta' and xtype='U')
CREATE TABLE EL_REJUNTE.Tarjeta(
	tarj_id INT NOT NULL IDENTITY(1,1),
	tarj_numero nvarchar(16) NOT NULL,
	tarj_cod_seguridad nvarchar(3) NOT NULL,
	tarj_vencimiento nvarchar(5)NOT NULL,
	tarj_titular nvarchar(50) NOT NULL,
	tarj_tipo nvarchar(50) NOT NULL,
 CONSTRAINT PK_Tarjeta PRIMARY KEY CLUSTERED(
	tarj_id ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)ON [PRIMARY]
GO

IF NOT EXISTS (select * from sysobjects where name='Ubicacion' and xtype='U')
CREATE TABLE EL_REJUNTE.Ubicacion(
	ubica_id INT NOT NULL IDENTITY(1,1),
	ubica_fila varchar(3) NOT NULL,
	ubica_asiento numeric(18, 0) NOT NULL,
	ubica_sin_numerar BIT NULL,
	ubica_precio numeric(18, 0) NOT NULL,
	ubica_tipo_codigo numeric(18, 0) NULL,
	ubica_tipo_descripcion nvarchar(255) NOT NULL,
 CONSTRAINT PK_Ubicacion PRIMARY KEY CLUSTERED(
	ubica_id ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

IF NOT EXISTS (select * from sysobjects where name='Ubicacion_Compra' and xtype='U')
CREATE TABLE EL_REJUNTE.Ubicacion_Compra(
	ubica_id INT NOT NULL,
	compra_id INT NOT NULL,
	ubica_facturada BIT NOT NULL,
CONSTRAINT PK_Ubicacion_Compra PRIMARY KEY CLUSTERED(
	ubica_id ASC,
	compra_id ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

IF NOT EXISTS (select * from sysobjects where name='Ubicacion_Publicacion' and xtype='U')
CREATE TABLE EL_REJUNTE.Ubicacion_Publicacion(
	ubica_id INT NOT NULL,
	publi_id INT NOT NULL,
	ubica_disponible BIT NOT NULL,
CONSTRAINT PK_Ubicacion_Publicacion PRIMARY KEY CLUSTERED(
	ubica_id ASC,
	publi_id ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

IF NOT EXISTS (select * from sysobjects where name='Usuario' and xtype='U')
CREATE TABLE EL_REJUNTE.Usuario(
	usuario_id INT NOT NULL IDENTITY(1,1),
	usuario_username nvarchar(50) NOT NULL,
	usuario_password nvarchar(255) NOT NULL,
	usuario_habilitado BIT NOT NULL,
	usuario_bloqueado BIT NOT NULL,
	usuario_cant_logeo_error INT NULL,
	usuario_tipo nvarchar(55) NULL,
 CONSTRAINT PK_Usuario PRIMARY KEY CLUSTERED(
	usuario_id ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)ON [PRIMARY]
GO

/* Tabla para datos erroneos */

CREATE TABLE EL_REJUNTE.DatosInvalidos(
	[Espec_Empresa_Razon_Social] [nvarchar](255) NULL,
	[Espec_Empresa_Cuit] [nvarchar](255) NULL,
	[Espec_Empresa_Fecha_Creacion] [datetime] NULL,
	[Espec_Empresa_Mail] [nvarchar](50) NULL,
	[Espec_Empresa_Dom_Calle] [nvarchar](50) NULL,
	[Espec_Empresa_Nro_Calle] [numeric](18, 0) NULL,
	[Espec_Empresa_Piso] [numeric](18, 0) NULL,
	[Espec_Empresa_Depto] [nvarchar](50) NULL,
	[Espec_Empresa_Cod_Postal] [nvarchar](50) NULL,
	[Espectaculo_Cod] [numeric](18, 0) NULL,
	[Espectaculo_Descripcion] [nvarchar](255) NULL,
	[Espectaculo_Fecha] [datetime] NULL,
	[Espectaculo_Fecha_Venc] [datetime] NULL,
	[Espectaculo_Rubro_Descripcion] [nvarchar](255) NULL,
	[Espectaculo_Estado] [nvarchar](255) NULL,
	[Ubicacion_Fila] [varchar](3) NULL,
	[Ubicacion_Asiento] [numeric](18, 0) NULL,
	[Ubicacion_Sin_numerar] [bit] NULL,
	[Ubicacion_Precio] [numeric](18, 0) NULL,
	[Ubicacion_Tipo_Codigo] [numeric](18, 0) NULL,
	[Ubicacion_Tipo_Descripcion] [nvarchar](255) NULL,
	[Cli_Dni] [numeric](18, 0) NULL,
	[Cli_Apeliido] [nvarchar](255) NULL,
	[Cli_Nombre] [nvarchar](255) NULL,
	[Cli_Fecha_Nac] [datetime] NULL,
	[Cli_Mail] [nvarchar](255) NULL,
	[Cli_Dom_Calle] [nvarchar](255) NULL,
	[Cli_Nro_Calle] [numeric](18, 0) NULL,
	[Cli_Piso] [numeric](18, 0) NULL,
	[Cli_Depto] [nvarchar](255) NULL,
	[Cli_Cod_Postal] [nvarchar](255) NULL,
	[Compra_Fecha] [datetime] NULL,
	[Compra_Cantidad] [numeric](18, 0) NULL,
	[Item_Factura_Monto] [numeric](18, 2) NULL,
	[Item_Factura_Cantidad] [numeric](18, 0) NULL,
	[Item_Factura_Descripcion] [nvarchar](60) NULL,
	[Factura_Nro] [numeric](18, 0) NULL,
	[Factura_Fecha] [datetime] NULL,
	[Factura_Total] [numeric](18, 2) NULL,
	[Forma_Pago_Desc] [nvarchar](255) NULL
) ON [PRIMARY]

/* Creacion de claves foraneas */
ALTER TABLE EL_REJUNTE.Cliente WITH CHECK ADD CONSTRAINT FK_Cliente_Direccion FOREIGN KEY(clie_direccion_id)
REFERENCES EL_REJUNTE.Direccion (dire_id)
GO
ALTER TABLE EL_REJUNTE.Cliente CHECK CONSTRAINT FK_Cliente_Direccion
GO
ALTER TABLE EL_REJUNTE.Cliente WITH CHECK ADD CONSTRAINT FK_Cliente_Tarjeta FOREIGN KEY(clie_tarjeta_id)
REFERENCES EL_REJUNTE.Tarjeta (tarj_id)
GO
ALTER TABLE EL_REJUNTE.Cliente CHECK CONSTRAINT FK_Cliente_Tarjeta
GO
ALTER TABLE EL_REJUNTE.Cliente WITH CHECK ADD CONSTRAINT FK_Cliente_Usuario FOREIGN KEY(clie_usuario_id)
REFERENCES EL_REJUNTE.Usuario (usuario_id)
GO
ALTER TABLE EL_REJUNTE.Cliente CHECK CONSTRAINT FK_Cliente_Usuario
GO
ALTER TABLE EL_REJUNTE.Compra WITH CHECK ADD CONSTRAINT FK_Compra_Cliente FOREIGN KEY(compra_cliente_id)
REFERENCES EL_REJUNTE.Cliente (clie_id)
GO
ALTER TABLE EL_REJUNTE.Compra CHECK CONSTRAINT FK_Compra_Cliente
GO
ALTER TABLE EL_REJUNTE.Empresa WITH CHECK ADD CONSTRAINT FK_Empresa_Direccion FOREIGN KEY(empre_direccion_id)
REFERENCES EL_REJUNTE.Direccion (dire_id)
GO
ALTER TABLE EL_REJUNTE.Empresa CHECK CONSTRAINT FK_Empresa_Direccion
GO
ALTER TABLE EL_REJUNTE.Empresa WITH CHECK ADD CONSTRAINT FK_Empresa_Usuario FOREIGN KEY(empre_usuario_id)
REFERENCES EL_REJUNTE.Usuario (usuario_id)
GO
ALTER TABLE EL_REJUNTE.Empresa CHECK CONSTRAINT FK_Empresa_Usuario
GO
ALTER TABLE EL_REJUNTE.Factura WITH CHECK ADD CONSTRAINT FK_Factura_Cliente FOREIGN KEY(fact_cliente_id)
REFERENCES EL_REJUNTE.Cliente (clie_id)
GO
ALTER TABLE EL_REJUNTE.Factura CHECK CONSTRAINT FK_Factura_Cliente
GO
ALTER TABLE EL_REJUNTE.Factura WITH CHECK ADD CONSTRAINT FK_Factura_Empresa FOREIGN KEY(fact_Empresa_id)
REFERENCES EL_REJUNTE.Empresa (empre_id)
GO
ALTER TABLE EL_REJUNTE.Factura CHECK CONSTRAINT FK_Factura_Empresa
GO
ALTER TABLE EL_REJUNTE.Func_Rol WITH CHECK ADD CONSTRAINT FK_Func_Rol_Funcionalidad FOREIGN KEY(func_id)
REFERENCES EL_REJUNTE.Funcionalidad (func_id)
GO
ALTER TABLE EL_REJUNTE.Func_Rol CHECK CONSTRAINT FK_Func_Rol_Funcionalidad
GO
ALTER TABLE EL_REJUNTE.Func_Rol WITH CHECK ADD CONSTRAINT FK_Func_Rol_Rol FOREIGN KEY(rol_id)
REFERENCES EL_REJUNTE.Rol (rol_id)
GO
ALTER TABLE EL_REJUNTE.Func_Rol CHECK CONSTRAINT FK_Func_Rol_Rol
GO
ALTER TABLE EL_REJUNTE.Item_Factura WITH CHECK ADD CONSTRAINT FK_Item_Factura_Factura FOREIGN KEY(item_factura_id)
REFERENCES EL_REJUNTE.Factura (fact_id)
GO
ALTER TABLE EL_REJUNTE.Item_Factura CHECK CONSTRAINT FK_Item_Factura_Factura
GO
ALTER TABLE EL_REJUNTE.Item_Factura WITH CHECK ADD CONSTRAINT FK_Item_Factura_Ubicacion FOREIGN KEY(item_ubicacion_id)
REFERENCES EL_REJUNTE.Ubicacion (ubica_id)
GO
ALTER TABLE EL_REJUNTE.Item_Factura CHECK CONSTRAINT FK_Item_Factura_Ubicacion
GO
ALTER TABLE EL_REJUNTE.Publicacion WITH CHECK ADD CONSTRAINT FK_Publicacion_Espectaculo FOREIGN KEY(publi_espectaculo_id)
REFERENCES EL_REJUNTE.Espectaculo (espec_id)
GO
ALTER TABLE EL_REJUNTE.Publicacion CHECK CONSTRAINT FK_Publicacion_Espectaculo
GO
ALTER TABLE EL_REJUNTE.Publicacion WITH CHECK ADD CONSTRAINT FK_Publicacion_Estado FOREIGN KEY(publi_estado_id)
REFERENCES EL_REJUNTE.Estado (estado_id)
GO
ALTER TABLE EL_REJUNTE.Publicacion CHECK CONSTRAINT FK_Publicacion_Estado
GO
ALTER TABLE EL_REJUNTE.Publicacion WITH CHECK ADD CONSTRAINT FK_Publicacion_Grado FOREIGN KEY(publi_grado_id)
REFERENCES EL_REJUNTE.Grado (grado_id)
GO
ALTER TABLE EL_REJUNTE.Publicacion CHECK CONSTRAINT FK_Publicacion_Grado
GO
ALTER TABLE EL_REJUNTE.Publicacion WITH CHECK ADD CONSTRAINT FK_Publicacion_Rubro FOREIGN KEY(publi_rubro_id)
REFERENCES EL_REJUNTE.Rubro (rubro_id)
GO
ALTER TABLE EL_REJUNTE.Publicacion CHECK CONSTRAINT FK_Publicacion_Rubro
GO
ALTER TABLE EL_REJUNTE.Publicacion WITH CHECK ADD CONSTRAINT FK_Publicacion_Usuario FOREIGN KEY(publi_usuario_id)
REFERENCES EL_REJUNTE.Usuario (usuario_id)
GO
ALTER TABLE EL_REJUNTE.Publicacion CHECK CONSTRAINT FK_Publicacion_Usuario
GO
ALTER TABLE EL_REJUNTE.Espectaculo WITH CHECK ADD CONSTRAINT FK_Espectaculo_Rubro FOREIGN KEY(espec_rubro_id)
REFERENCES EL_REJUNTE.Rubro (rubro_id)
GO
ALTER TABLE EL_REJUNTE.Espectaculo CHECK CONSTRAINT FK_Espectaculo_Rubro
GO
ALTER TABLE EL_REJUNTE.Rol_Usuario WITH CHECK ADD CONSTRAINT FK_Rol_Usuario_Rol FOREIGN KEY(rol_id)
REFERENCES EL_REJUNTE.Rol (rol_id)
GO
ALTER TABLE EL_REJUNTE.Rol_Usuario CHECK CONSTRAINT FK_Rol_Usuario_Rol
GO
ALTER TABLE EL_REJUNTE.Rol_Usuario WITH CHECK ADD CONSTRAINT FK_Rol_Usuario_Usuario FOREIGN KEY(usuario_id)
REFERENCES EL_REJUNTE.Usuario (usuario_id)
GO
ALTER TABLE EL_REJUNTE.Rol_Usuario CHECK CONSTRAINT FK_Rol_Usuario_Usuario
GO
ALTER TABLE EL_REJUNTE.Ubicacion_Compra WITH CHECK ADD CONSTRAINT FK_Ubicacion_Compra_Compra FOREIGN KEY(compra_id)
REFERENCES EL_REJUNTE.Compra (compra_id)
GO
ALTER TABLE EL_REJUNTE.Ubicacion_Compra CHECK CONSTRAINT FK_Ubicacion_Compra_Compra
GO
ALTER TABLE EL_REJUNTE.Ubicacion_Compra WITH CHECK ADD CONSTRAINT FK_Ubicacion_Compra_Ubicacion FOREIGN KEY(ubica_id)
REFERENCES EL_REJUNTE.Ubicacion (ubica_id)
GO
ALTER TABLE EL_REJUNTE.Ubicacion_Compra CHECK CONSTRAINT FK_Ubicacion_Compra_Ubicacion
GO
ALTER TABLE EL_REJUNTE.Ubicacion_Publicacion WITH CHECK ADD CONSTRAINT FK_Ubicacion_Publicacion_Publicacion FOREIGN KEY(publi_id)
REFERENCES EL_REJUNTE.Publicacion (publi_id)
GO
ALTER TABLE EL_REJUNTE.Ubicacion_Publicacion CHECK CONSTRAINT FK_Ubicacion_Publicacion_Publicacion
GO
ALTER TABLE EL_REJUNTE.Ubicacion_Publicacion WITH CHECK ADD CONSTRAINT FK_Ubicacion_Publicacion_Ubicacion FOREIGN KEY(ubica_id)
REFERENCES EL_REJUNTE.Ubicacion (ubica_id)
GO
ALTER TABLE EL_REJUNTE.Ubicacion_Publicacion CHECK CONSTRAINT FK_Ubicacion_Publicacion_Ubicacion
GO
ALTER TABLE EL_REJUNTE.Puntaje WITH CHECK ADD CONSTRAINT FK_Puntaje_Cliente FOREIGN KEY(punt_cliente_id)
REFERENCES EL_REJUNTE.Cliente (clie_id)
GO
ALTER TABLE EL_REJUNTE.Puntaje CHECK CONSTRAINT FK_Puntaje_Cliente
GO
ALTER TABLE EL_REJUNTE.Espectaculo WITH CHECK ADD CONSTRAINT FK_Espectaculo_Estado FOREIGN KEY(espec_estado_id)
REFERENCES EL_REJUNTE.Estado (estado_id)
GO
ALTER TABLE EL_REJUNTE.Espectaculo CHECK CONSTRAINT FK_Espectaculo_Estado
GO
ALTER TABLE EL_REJUNTE.Espectaculo WITH CHECK ADD CONSTRAINT FK_Espectaculo_Direccion FOREIGN KEY(espec_direccion_id)
REFERENCES EL_REJUNTE.Direccion (dire_id)
GO
ALTER TABLE EL_REJUNTE.Espectaculo CHECK CONSTRAINT FK_Espectaculo_Direccion
GO
USE [master]
GO
ALTER DATABASE [GD2C2018] SET READ_WRITE 
GO
USE GD2C2018;
GO
/*Limpio las tablas antes de insertar */
DELETE FROM [EL_REJUNTE].[Func_Rol]
DELETE FROM [EL_REJUNTE].[Rol_Usuario]
DELETE FROM [EL_REJUNTE].[Funcionalidad]
DELETE FROM [EL_REJUNTE].[Rol]
DELETE FROM [EL_REJUNTE].[Publicacion]
DELETE FROM [EL_REJUNTE].[Espectaculo]
DELETE FROM [EL_REJUNTE].[Estado]
DELETE FROM [EL_REJUNTE].[Ubicacion_Compra]
DELETE FROM [EL_REJUNTE].[Item_Factura]
DELETE FROM [EL_REJUNTE].[Compra]
DELETE FROM [EL_REJUNTE].[Ubicacion]
DELETE FROM [EL_REJUNTE].[Factura]
DELETE FROM [EL_REJUNTE].[Cliente]
DELETE FROM [EL_REJUNTE].[Empresa]
DELETE FROM [EL_REJUNTE].[Direccion]
DELETE FROM [EL_REJUNTE].[DatosInvalidos]
DELETE FROM [EL_REJUNTE].[Usuario]

/* Creo los estados */
INSERT INTO EL_REJUNTE.Estado (estado_descripcion ,estado_habilitado) VALUES ('Borrador' , 1)
INSERT INTO EL_REJUNTE.Estado (estado_descripcion ,estado_habilitado) VALUES ('Publicada' , 1)
INSERT INTO EL_REJUNTE.Estado (estado_descripcion ,estado_habilitado) VALUES ('Finalizada' , 1)
INSERT INTO EL_REJUNTE.Estado (estado_descripcion ,estado_habilitado) VALUES ('Pausada' , 1)

/* Creo los Rubros */
INSERT INTO EL_REJUNTE.Rubro (rubro_descripcion, rubro_habilitado) VALUES ('Otro', 1)
INSERT INTO EL_REJUNTE.Rubro (rubro_descripcion, rubro_habilitado) VALUES ('Musical', 1)
INSERT INTO EL_REJUNTE.Rubro (rubro_descripcion, rubro_habilitado) VALUES ('Obra Teatral', 1)
INSERT INTO EL_REJUNTE.Rubro (rubro_descripcion, rubro_habilitado) VALUES ('Humoristico', 1)
INSERT INTO EL_REJUNTE.Rubro (rubro_descripcion, rubro_habilitado) VALUES ('Audio Visual', 1)

/* Creo los Grados de Publicacion */
INSERT INTO EL_REJUNTE.Grado (grado_prioridad, grado_comision, grado_habilitado) VALUES ('Alta',30, 1);
INSERT INTO EL_REJUNTE.Grado (grado_prioridad, grado_comision, grado_habilitado) VALUES ('Media',25, 1);
INSERT INTO EL_REJUNTE.Grado (grado_prioridad, grado_comision, grado_habilitado) VALUES ('Baja',10, 1);
INSERT INTO EL_REJUNTE.Grado (grado_prioridad, grado_comision, grado_habilitado) VALUES ('Otro',0, 1);

/* Creo el usuario administrador */
INSERT INTO EL_REJUNTE.Usuario (usuario_username, usuario_password, usuario_habilitado, usuario_bloqueado, usuario_cant_logeo_error, usuario_tipo)
VALUES('admin','e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7', 1, 0, 0, 'Administrativo')

/* Roles */
INSERT INTO EL_REJUNTE.Rol (rol_nombre ,rol_habilitado, rol_baja_logica) VALUES ('Administrativo' , 1, 0)
INSERT INTO EL_REJUNTE.Rol (rol_nombre ,rol_habilitado, rol_baja_logica) VALUES ('Empresa' , 1, 0)
INSERT INTO EL_REJUNTE.Rol (rol_nombre ,rol_habilitado, rol_baja_logica) VALUES ('Cliente' , 1, 0)

/* Funcionalidades */
INSERT INTO EL_REJUNTE.Funcionalidad (func_descripcion) VALUES ('Abm Rol')
INSERT INTO EL_REJUNTE.Funcionalidad (func_descripcion) VALUES ('Abm Cliente')
INSERT INTO EL_REJUNTE.Funcionalidad (func_descripcion) VALUES ('Abm Empresa Espectaculo')
INSERT INTO EL_REJUNTE.Funcionalidad (func_descripcion) VALUES ('Abm Rubro')                                 
INSERT INTO EL_REJUNTE.Funcionalidad (func_descripcion) VALUES ('Abm Grado')
INSERT INTO EL_REJUNTE.Funcionalidad (func_descripcion) VALUES ('Generar Publicacion')
INSERT INTO EL_REJUNTE.Funcionalidad (func_descripcion) VALUES ('Editar Publicacion')
INSERT INTO EL_REJUNTE.Funcionalidad (func_descripcion) VALUES ('Comprar')
INSERT INTO EL_REJUNTE.Funcionalidad (func_descripcion) VALUES ('Historial del Cliente')
INSERT INTO EL_REJUNTE.Funcionalidad (func_descripcion) VALUES ('Canjear Puntos')
INSERT INTO EL_REJUNTE.Funcionalidad (func_descripcion) VALUES ('Generar Pa de Comisiones')
INSERT INTO EL_REJUNTE.Funcionalidad (func_descripcion) VALUES ('Listado Estadistico')

/* Asigno el Rol Administrador al admin */
INSERT INTO EL_REJUNTE.Rol_Usuario (rol_id ,usuario_id) VALUES (1 ,1 )

/* Rol Administrador */
INSERT INTO EL_REJUNTE.Func_Rol (func_id , rol_id) VALUES (1 ,1 )
INSERT INTO EL_REJUNTE.Func_Rol (func_id , rol_id) VALUES (2 ,1 )
INSERT INTO EL_REJUNTE.Func_Rol (func_id , rol_id) VALUES (3 ,1 )
INSERT INTO EL_REJUNTE.Func_Rol (func_id , rol_id) VALUES (4 ,1 )
INSERT INTO EL_REJUNTE.Func_Rol (func_id , rol_id) VALUES (5 ,1 )
INSERT INTO EL_REJUNTE.Func_Rol (func_id , rol_id) VALUES (6 ,1 )
INSERT INTO EL_REJUNTE.Func_Rol (func_id , rol_id) VALUES (7 ,1 )
INSERT INTO EL_REJUNTE.Func_Rol (func_id , rol_id) VALUES (8 ,1 )
INSERT INTO EL_REJUNTE.Func_Rol (func_id , rol_id) VALUES (9 ,1 )
INSERT INTO EL_REJUNTE.Func_Rol (func_id , rol_id) VALUES (10 ,1 )
INSERT INTO EL_REJUNTE.Func_Rol (func_id , rol_id) VALUES (11 ,1 )
INSERT INTO EL_REJUNTE.Func_Rol (func_id , rol_id) VALUES (12 ,1 )

/* Rol Empresa */
INSERT INTO EL_REJUNTE.Func_Rol (func_id , rol_id) VALUES (6 ,2 )
INSERT INTO EL_REJUNTE.Func_Rol (func_id , rol_id) VALUES (7 ,2 )

/* Rol Cliente */
INSERT INTO EL_REJUNTE.Func_Rol (func_id , rol_id) VALUES (8 ,3 )
INSERT INTO EL_REJUNTE.Func_Rol (func_id , rol_id) VALUES (9 ,3 )
INSERT INTO EL_REJUNTE.Func_Rol (func_id , rol_id) VALUES (10 ,3 )
GO
/* Trigger para desasignar roles cuando se inhabilitan o se dan de baja */
CREATE TRIGGER EL_REJUNTE.tg_inhabilitar_rol
ON EL_REJUNTE.Rol
AFTER UPDATE AS
BEGIN
	IF EXISTS(SELECT 1 FROM inserted i WHERE i.rol_baja_logica = 1 OR i.rol_habilitado = 0)
	BEGIN
		DELETE FROM EL_REJUNTE.Rol_Usuario
		WHERE rol_id = (SELECT i.rol_id FROM inserted i)
	END
END
GO

/* Creo una tabla temporal para tener todas las direccion sin validar */
CREATE TABLE EL_REJUNTE.#Direcciones (	
    dire_id INT NOT NULL IDENTITY(1,1),
	dire_calle nvarchar(255) NOT NULL,
	dire_numero nvarchar(50) NOT NULL,
	dire_piso nvarchar(50) NULL,
	dire_depto nvarchar(50) NULL,
	dire_localidad nvarchar(50) NULL,
	dire_codigo_postal nvarchar(50) NOT NULL
	)
	
/* DIRECCIONES */	
	/* Migro las direcciones de los clientes */
	INSERT INTO EL_REJUNTE.#Direcciones (dire_calle, dire_numero, dire_piso, dire_depto, dire_codigo_postal)
	(SELECT gd.Cli_Dom_Calle, gd.Cli_Nro_Calle, gd.Cli_Piso, gd.Cli_Depto, gd.Cli_Cod_Postal
	FROM gd_esquema.Maestra gd
	WHERE gd.Cli_Dom_Calle IS NOT NULL AND gd.Cli_Nro_Calle IS NOT NULL AND gd.Cli_Piso IS NOT NULL AND gd.Cli_Depto IS NOT NULL AND gd.Cli_Cod_Postal IS NOT NULL)
	GO
	/* Migro las direcciones de las empresas */
	INSERT INTO EL_REJUNTE.#Direcciones (dire_calle, dire_numero, dire_piso, dire_depto, dire_codigo_postal)
	(SELECT gd.Espec_Empresa_Dom_Calle, gd.Espec_Empresa_Nro_Calle, gd.Espec_Empresa_Piso, gd.Espec_Empresa_Depto, gd.Espec_Empresa_Cod_Postal 
	FROM gd_esquema.Maestra gd
	WHERE gd.Espec_Empresa_Dom_Calle IS NOT NULL AND gd.Espec_Empresa_Nro_Calle IS NOT NULL AND gd.Espec_Empresa_Piso IS NOT NULL AND gd.Espec_Empresa_Depto IS NOT NULL AND gd.Espec_Empresa_Cod_Postal IS NOT NULL)
	GO
	/* Me quedo con las direcciones sin repetir */
	INSERT INTO EL_REJUNTE.Direccion(dire_calle, dire_numero, dire_piso, dire_depto, dire_codigo_postal)
	(SELECT DISTINCT dire_calle, dire_numero, dire_piso, dire_depto, dire_codigo_postal
	FROM EL_REJUNTE.#Direcciones)
	GO
	/* No sirve mas */
	DROP TABLE EL_REJUNTE.#Direcciones
	
/* CLIENTES */
	/* Me traigo todos los clientes que sean distintos */

	/*Se agrupa clientes de la tabla Maestra y se inserta en una tabla Temporal*/
	SELECT Cli_Nombre AS Nombre,Cli_Apeliido AS Apellido,Cli_Dni AS Dni ,Cli_Fecha_Nac,Cli_Mail as Email,Cli_Dom_Calle,Cli_Nro_Calle,Cli_Piso,Cli_Depto,Cli_Cod_Postal
	INTO #Temp_Clientes
	FROM GD2C2018.gd_esquema.Maestra
	WHERE Cli_Dni IS NOT NULL
	GROUP BY Cli_Nombre,Cli_Apeliido,Cli_Dni,Cli_Fecha_Nac,Cli_Mail,Cli_Dom_Calle,Cli_Nro_Calle,Cli_Piso,Cli_Depto,Cli_Cod_Postal;
	
	/*Se busca si existe incosistencia en los datos mediante otra tabla Temporal*/
	SELECT  Nombre,Apellido,Dni,Cli_Fecha_Nac,Email,Cli_Dom_Calle,Cli_Nro_Calle,Cli_Piso,Cli_Depto,Cli_Cod_Postal,row_number() OVER(PARTITION BY Dni ORDER BY Email) AS cantDni,row_number() OVER(PARTITION BY Email ORDER BY Email) AS cantEmail
	INTO #Temp_Cli_Incons
	FROM #Temp_Clientes
	GROUP BY Nombre,Apellido,Dni,Cli_Fecha_Nac,Email,Cli_Dom_Calle,Cli_Nro_Calle,Cli_Piso,Cli_Depto,Cli_Cod_Postal;
	
	/* Borro la primer tabla temporal, ya que no sirve mas */
	DROP TABLE #Temp_Clientes;
	
	/* Se cren los usuarios de los Clientes */
	INSERT INTO EL_REJUNTE.Usuario (usuario_username, usuario_password, usuario_habilitado, usuario_bloqueado, usuario_cant_logeo_error, usuario_tipo)
	SELECT left(Email,charindex('@',Email,1)-1) AS username ,'e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7', 1, 0, 0, 'Cliente'
	FROM #Temp_Cli_Incons
	WHERE cantDni = 1 AND cantEmail = 1
	
	/* Se les asigna el Rol de Cliente */
	INSERT INTO EL_REJUNTE.Rol_Usuario (rol_id ,usuario_id)
	SELECT 3, usuario_id
	FROM EL_REJUNTE.Usuario
	WHERE usuario_id NOT IN (SELECT usuario_id FROM EL_REJUNTE.Rol_Usuario)
	
	/* Ahora si se insertan los Clientes */
	INSERT INTO EL_REJUNTE.Cliente (clie_nombre, clie_apellido, clie_tipo_documento, clie_documento, clie_cuil, clie_email, clie_telefono, clie_direccion_id, clie_fecha_nacimiento,clie_fecha_creacion, clie_tarjeta_id, clie_habilitado, clie_usuario_id)
	SELECT Nombre, Apellido, 'DNI', Dni, null, Email, null, (SELECT dire_id FROM EL_REJUNTE.Direccion WHERE tmp.Cli_Dom_Calle = dire_calle AND tmp.Cli_Nro_Calle = dire_numero AND tmp.Cli_Piso = dire_piso AND tmp.Cli_Depto = dire_depto AND tmp.Cli_Cod_Postal = dire_codigo_postal ),tmp.Cli_Fecha_Nac, GETDATE(), null, 1,usu.usuario_id
	FROM #Temp_Cli_Incons tmp
	INNER JOIN EL_REJUNTE.Usuario usu
	ON left(email,charindex('@',email,1)-1) = usu.usuario_username
	WHERE cantDni = 1 and cantEmail = 1
	ORDER BY dni
	
	/* No sirve mas */
	DROP TABLE #Temp_Cli_Incons;
	
/* EMPRESAS */
	/* Se cren los usuarios de las Empresas */
	INSERT INTO EL_REJUNTE.Usuario (usuario_username, usuario_password, usuario_habilitado, usuario_bloqueado, usuario_cant_logeo_error, usuario_tipo)
	SELECT DISTINCT left(Espec_Empresa_Mail,charindex('@',Espec_Empresa_Mail,1)-1) AS username ,'e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7', 1, 0, 0, 'Empresa'
	FROM gd_esquema.Maestra
	WHERE Espec_Empresa_Cuit IS NOT NULL

	/* Se les asigna el Rol de Empresa */
	INSERT INTO EL_REJUNTE.Rol_Usuario (rol_id ,usuario_id)
	SELECT 2, usuario_id
	FROM EL_REJUNTE.Usuario
	WHERE usuario_id NOT IN (SELECT usuario_id FROM EL_REJUNTE.Rol_Usuario)

	INSERT INTO EL_REJUNTE.Empresa (empre_razon_social, empre_cuit, empre_fecha_creacion, empre_mail, empre_direccion_id, empre_telefono, empre_usuario_id, empre_baja_logica)
	SELECT DISTINCT gd.Espec_Empresa_Razon_Social, gd.Espec_Empresa_Cuit, gd.Espec_Empresa_Fecha_Creacion, gd.Espec_Empresa_Mail, (SELECT dire_id FROM EL_REJUNTE.Direccion WHERE gd.Espec_Empresa_Dom_Calle = dire_calle AND gd.Espec_Empresa_Nro_Calle = dire_numero AND gd.Espec_Empresa_Piso = dire_piso AND gd.Espec_Empresa_Depto = dire_depto AND gd.Espec_Empresa_Cod_Postal = dire_codigo_postal), null, usu.usuario_id, 0
	FROM gd_esquema.Maestra gd
	INNER JOIN EL_REJUNTE.Usuario usu
	ON left(gd.Espec_Empresa_Mail,charindex('@',gd.Espec_Empresa_Mail,1)-1)=usu.usuario_username
	ORDER BY Espec_Empresa_Cuit
	
/* ESPECTACULOS */
	INSERT INTO EL_REJUNTE.Espectaculo (espec_codigo , espec_descripcion, espec_fecha, espec_fecha_venc, espec_rubro_id, espec_estado_id, espec_direccion_id)
	SELECT DISTINCT gd.Espectaculo_Cod, gd.Espectaculo_Descripcion, gd.Espectaculo_Fecha, gd.Espectaculo_Fecha_Venc, 1, (SELECT estado_id FROM EL_REJUNTE.Estado WHERE estado_descripcion = gd.Espectaculo_Estado), null
	FROM gd_esquema.Maestra gd
	WHERE gd.Espectaculo_Cod IS NOT NULL
	GO

/* PUBLICACIONES */
	INSERT INTO EL_REJUNTE.Publicacion (publi_descripcion , publi_estado_id, publi_fecha_inicio, publi_fecha_evento, publi_codigo, publi_rubro_id, publi_usuario_id,publi_espectaculo_id, publi_grado_id)
	SELECT DISTINCT gd.Espectaculo_Descripcion, (SELECT estado_id FROM EL_REJUNTE.Estado WHERE estado_descripcion = gd.Espectaculo_Estado), gd.Espectaculo_Fecha, gd.Espectaculo_Fecha_Venc, gd.Espectaculo_Cod, 1, usu.usuario_id,(SELECT espec_id FROM EL_REJUNTE.Espectaculo WHERE espec_descripcion = gd.Espectaculo_Descripcion), 4
	FROM gd_esquema.Maestra gd, EL_REJUNTE.Usuario usu
	WHERE left(gd.Espec_Empresa_Mail,charindex('@',gd.Espec_Empresa_Mail,1)-1)=usu.usuario_username
	ORDER BY gd.Espectaculo_Cod
	GO
	
/* UBICACION */
	INSERT INTO EL_REJUNTE.Ubicacion (ubica_fila , ubica_asiento, ubica_sin_numerar, ubica_precio, ubica_tipo_codigo, ubica_tipo_descripcion)
	SELECT DISTINCT gd.Ubicacion_Fila, gd.Ubicacion_Asiento, gd.Ubicacion_Sin_numerar, gd.Ubicacion_Precio, gd.Ubicacion_Tipo_Codigo, gd.Ubicacion_Tipo_Descripcion
	FROM gd_esquema.Maestra gd
	WHERE gd.Ubicacion_Fila IS NOT NULL
	GO
	
/* UBICACION_PUBLICACION */
	INSERT INTO EL_REJUNTE.Ubicacion_Publicacion (ubica_id, publi_id, ubica_disponible)
	SELECT DISTINCT ubica_id, publi_id, 0
	FROM EL_REJUNTE.Ubicacion u, EL_REJUNTE.Publicacion p, gd_esquema.Maestra gd
	WHERE u.ubica_fila = gd.Ubicacion_Fila AND u.ubica_asiento = gd.Ubicacion_Asiento AND u.ubica_sin_numerar = gd.Ubicacion_Sin_numerar AND u.ubica_precio = gd.Ubicacion_Precio AND u.ubica_tipo_codigo = gd.Ubicacion_Tipo_Codigo AND u.ubica_tipo_descripcion = gd.Ubicacion_Tipo_Descripcion AND p.publi_descripcion = gd.Espectaculo_Descripcion AND p.publi_fecha_inicio = gd.Espectaculo_Fecha AND p.publi_fecha_evento = gd.Espectaculo_Fecha_Venc AND p.publi_codigo = gd.Espectaculo_Cod AND gd.Factura_Nro IS NULL AND gd.Compra_Fecha IS NULL
	ORDER BY ubica_id
	
/* COMPRA */
	INSERT INTO EL_REJUNTE.Compra (compra_fecha , compra_cantidad, compra_cliente_id)
	SELECT DISTINCT gd.Compra_Fecha, gd.Compra_Cantidad, c.clie_id
	FROM gd_esquema.Maestra gd, EL_REJUNTE.Cliente c
	WHERE gd.Compra_Fecha IS NOT NULL AND gd.Compra_Cantidad IS NOT NULL AND c.clie_apellido = gd.Cli_Apeliido AND c.clie_nombre = gd.Cli_Nombre AND c.clie_documento = gd.Cli_Dni
	GO

/* UBICACION_COMPRA */
	INSERT INTO EL_REJUNTE.Ubicacion_Compra(ubica_id, compra_id, ubica_facturada)	
	SELECT DISTINCT u.ubica_id, c.compra_id, 0
	FROM gd_esquema.Maestra gd, EL_REJUNTE.Ubicacion u, EL_REJUNTE.Compra c, EL_REJUNTE.Cliente cl
	WHERE u.ubica_fila = gd.Ubicacion_Fila AND u.ubica_asiento = gd.Ubicacion_Asiento AND u.ubica_sin_numerar = gd.Ubicacion_Sin_numerar AND u.ubica_precio = gd.Ubicacion_Precio AND u.ubica_tipo_codigo = gd.Ubicacion_Tipo_Codigo AND u.ubica_tipo_descripcion = gd.Ubicacion_Tipo_Descripcion AND c.compra_cliente_id = cl.clie_id AND cl.clie_email = Cli_Mail AND c.compra_fecha = gd.Compra_Fecha AND c.compra_cantidad = gd.Compra_Cantidad AND gd.Factura_Nro IS NOT NULL AND gd.Compra_Cantidad IS NOT NULL
	

/* FACTURA */
	INSERT INTO EL_REJUNTE.Factura (fact_nro , fact_fecha, fact_total, fact_pago_desc, fact_cliente_id, fact_empresa_id)
	SELECT DISTINCT Factura_Nro,Factura_Fecha,Factura_Total, Forma_Pago_Desc, clie_id, empre_id
	FROM gd_esquema.Maestra, EL_REJUNTE.Cliente, EL_REJUNTE.Empresa
	WHERE Factura_Nro IS NOT NULL AND clie_email = Cli_Mail AND empre_cuit = Espec_Empresa_Cuit
	GO

/* ITEM_FACTURA*/
	SELECT DISTINCT gd.Item_Factura_Monto, gd.Item_Factura_Cantidad, gd.Item_Factura_Descripcion, f.fact_id , u.ubica_id 
	INTO #Item_Factura_Aux
	FROM gd_esquema.Maestra gd, EL_REJUNTE.Factura f, EL_REJUNTE.Ubicacion u,EL_REJUNTE.Cliente c, EL_REJUNTE.Empresa e 
	WHERE gd.Factura_Nro IS NOT NULL AND f.fact_nro = gd.Factura_Nro AND f.fact_cliente_id = c.clie_id AND c.clie_email = gd.Cli_Mail AND f.fact_empresa_id = e.empre_id AND e.empre_cuit = gd.Espec_Empresa_Cuit AND u.ubica_fila = gd.Ubicacion_Fila AND u.ubica_asiento = gd.Ubicacion_Asiento AND u.ubica_sin_numerar = gd.Ubicacion_Sin_numerar AND u.ubica_precio = gd.Ubicacion_Precio AND u.ubica_tipo_codigo = gd.Ubicacion_Tipo_Codigo AND u.ubica_tipo_descripcion = gd.Ubicacion_Tipo_Descripcion

	INSERT INTO EL_REJUNTE.Item_Factura (item_monto , item_cantidad, item_descripcion, item_factura_id, item_ubicacion_id)
	SELECT Item_Factura_Monto, Item_Factura_Cantidad, Item_Factura_Descripcion, fact_id, ubica_id FROM #Item_Factura_Aux

	DROP TABLE #Item_Factura_Aux

/* TODOS LOS DATOS
INSERT INTO EL_REJUNTE.DatosInvalidos(Espec_Empresa_Razon_Social,Espec_Empresa_Cuit,Espec_Empresa_Fecha_Creacion,Espec_Empresa_Mail,Espec_Empresa_Dom_Calle,Espec_Empresa_Nro_Calle,Espec_Empresa_Piso,Espec_Empresa_Depto,Espec_Empresa_Cod_Postal,Espectaculo_Cod,Espectaculo_Descripcion,Espectaculo_Fecha,Espectaculo_Fecha_Venc,Espectaculo_Rubro_Descripcion,Espectaculo_Estado,Ubicacion_Fila,Ubicacion_Asiento,Ubicacion_Sin_numerar,Ubicacion_Precio,Ubicacion_Tipo_Codigo,Ubicacion_Tipo_Descripcion,Cli_Dni,Cli_Apeliido,Cli_Nombre,Cli_Fecha_Nac,Cli_Mail,Cli_Dom_Calle,Cli_Nro_Calle,Cli_Piso,Cli_Depto,Cli_Cod_Postal,Compra_Fecha,Compra_Cantidad,Item_Factura_Monto,Item_Factura_Cantidad,Item_Factura_Descripcion,Factura_Nro,Factura_Fecha,Factura_Total,Forma_Pago_Desc)
(SELECT Espec_Empresa_Razon_Social,Espec_Empresa_Cuit,Espec_Empresa_Fecha_Creacion,Espec_Empresa_Mail,Espec_Empresa_Dom_Calle,Espec_Empresa_Nro_Calle,Espec_Empresa_Piso,Espec_Empresa_Depto,Espec_Empresa_Cod_Postal,Espectaculo_Cod,Espectaculo_Descripcion,Espectaculo_Fecha,Espectaculo_Fecha_Venc,Espectaculo_Rubro_Descripcion,Espectaculo_Estado,Ubicacion_Fila,Ubicacion_Asiento,Ubicacion_Sin_numerar,Ubicacion_Precio,Ubicacion_Tipo_Codigo,Ubicacion_Tipo_Descripcion,Cli_Dni,Cli_Apeliido,Cli_Nombre,Cli_Fecha_Nac,Cli_Mail,Cli_Dom_Calle,Cli_Nro_Calle,Cli_Piso,Cli_Depto,Cli_Cod_Postal,Compra_Fecha,Compra_Cantidad,Item_Factura_Monto,Item_Factura_Cantidad,Item_Factura_Descripcion,Factura_Nro,Factura_Fecha,Factura_Total,Forma_Pago_Desc  
FROM gd_esquema.Maestra)
GO*/

