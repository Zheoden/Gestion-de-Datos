USE GD2C2018;


IF NOT EXISTS (select * from sys.schemas where name = 'EL_REJUNTE')
BEGIN
EXEC('create schema EL_REJUNTE')
END;
GO

IF NOT EXISTS (select * from sysobjects where name='Cliente' and xtype='U')
CREATE TABLE EL_REJUNTE.Cliente(
	clie_id INT NOT NULL IDENTITY(1,1),
	clie_nombre nvarchar(50) NOT NULL,
	clie_apellido nvarchar(50) NOT NULL,
	clie_tipo_documento nvarchar(255) NOT NULL,
	clie_documento INT NOT NULL,
	clie_cuil nvarchar(11) NULL,
	clie_email nvarchar(50) NOT NULL,
	clie_telefono nvarchar(10) NOT NULL,
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
	dire_calle nvarchar(50) NOT NULL,
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
	espec_estado nvarchar(255) NULL,
 CONSTRAINT PK_Espectaculo PRIMARY KEY CLUSTERED(
	espec_id ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)ON [PRIMARY]
GO

IF NOT EXISTS (select * from sysobjects where name='Estado' and xtype='U')
CREATE TABLE EL_REJUNTE.Estado(
	estado_id INT NOT NULL IDENTITY(1,1),
	estado_descripcion nvarchar(50) NOT NULL,
	estado_inicial BIT NULL,
	estado_final BIT NULL,
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
	funci_id INT NOT NULL,
	rol_id INT NOT NULL,
 CONSTRAINT PK_Func_Rol PRIMARY KEY CLUSTERED (
	funci_id ASC,
	rol_id ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)ON [PRIMARY]
GO

IF NOT EXISTS (select * from sysobjects where name='Funcionalidad' and xtype='U')
CREATE TABLE EL_REJUNTE.Funcionalidad(
	funci_id INT NOT NULL,
	func_descripcion nvarchar(10) NOT NULL,
 CONSTRAINT PK_Funcionalidad PRIMARY KEY CLUSTERED(
	funci_id ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)ON [PRIMARY]
GO

IF NOT EXISTS (select * from sysobjects where name='Grado' and xtype='U')
CREATE TABLE EL_REJUNTE.Grado(
	grado_id INT NOT NULL IDENTITY(1,1),
	grado_descripcion nvarchar(50) NOT NULL,
	grado_comision numeric(18, 0) NOT NULL,
	grado_porcentaje numeric(18, 0) NOT NULL,
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
	item_descripcion nvarchar(60) NOT NULL,
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
	publi_descripcion nvarchar(50) NOT NULL,
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
	punt_cantidad nvarchar(10) NOT NULL,
	punt_vencimiento datetime NOT NULL,
 CONSTRAINT PK_Puntaje PRIMARY KEY CLUSTERED(
	punt_id ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)ON [PRIMARY]
GO

IF NOT EXISTS (select * from sysobjects where name='Rol' and xtype='U')
CREATE TABLE EL_REJUNTE.Rol(
	rol_id INT NOT NULL IDENTITY(1,1),
	rol_nombre nvarchar(60) NOT NULL,
	rol_habilitado BIT NOT NULL,
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
	rubro_codigo nvarchar(10) NOT NULL,
	rubro_descripcion nvarchar(255) NOT NULL,
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
	tarj_vencimiento BIT NULL,
	tarj_titular INT NOT NULL,
	tarj_tipo INT NOT NULL,
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
	ubica_facturada BIT NOT NULL,
 CONSTRAINT PK_Ubicacion PRIMARY KEY CLUSTERED(
	ubica_id ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

IF NOT EXISTS (select * from sysobjects where name='Ubicacion_Compra' and xtype='U')
CREATE TABLE EL_REJUNTE.Ubicacion_Compra(
	ubica_id INT NOT NULL,
	compra_id INT NOT NULL,
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
CONSTRAINT PK_Ubicacion_Publicacion PRIMARY KEY CLUSTERED(
	ubica_id ASC,
	publi_id ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

IF NOT EXISTS (select * from sysobjects where name='Usuario' and xtype='U')
CREATE TABLE EL_REJUNTE.Usuario(
	usuario_id INT NOT NULL IDENTITY(1,1),
	usuario_username nvarchar(20) NOT NULL,
	usuario_password nvarchar(50) NOT NULL,
	usuario_habilitado BIT NOT NULL,
	usuario_cant_logeo_error INT NULL,
	usuario_tipo nvarchar(55) NOT NULL,
 CONSTRAINT PK_Usuario PRIMARY KEY CLUSTERED(
	usuario_id ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)ON [PRIMARY]
GO


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
ALTER TABLE EL_REJUNTE.Func_Rol WITH CHECK ADD CONSTRAINT FK_Func_Rol_Funcionalidad FOREIGN KEY(funci_id)
REFERENCES EL_REJUNTE.Funcionalidad (funci_id)
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
USE [master]
GO
ALTER DATABASE [GD2C2018] SET READ_WRITE 
GO