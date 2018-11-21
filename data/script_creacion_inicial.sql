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
	clie_documento nvarchar(8) NOT NULL,
	clie_cuil nvarchar(11) NULL,
	clie_email nvarchar(50) NOT NULL,
	clie_telefono nvarchar(50) NOT NULL,
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
	espec_estado nvarchar(255) NULL,
 CONSTRAINT PK_Espectaculo PRIMARY KEY CLUSTERED(
	espec_id ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)ON [PRIMARY]
GO

IF NOT EXISTS (select * from sysobjects where name='Estado' and xtype='U')
CREATE TABLE EL_REJUNTE.Estado(
	estado_id INT NOT NULL IDENTITY(1,1),
	estado_descripcion nvarchar(255) NOT NULL,
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
USE [master]
GO
ALTER DATABASE [GD2C2018] SET READ_WRITE 
GO

USE GD2C2018;
GO

INSERT INTO EL_REJUNTE.Usuario (usuario_username, usuario_password, usuario_habilitado, usuario_bloqueado, usuario_cant_logeo_error, usuario_tipo)
VALUES('admin','E6B87050BFCB8143FCB8DB0170A4DC9ED00D904DDD3E2A4AD1B1E8DC0FDC9BE7', 1, 0, 0, 'Administrador')
GO
/* Roles */
INSERT INTO EL_REJUNTE.Rol (rol_nombre ,rol_habilitado, rol_baja_logica)
VALUES ('Administrativo' , 1, 0)
GO
INSERT INTO EL_REJUNTE.Rol (rol_nombre ,rol_habilitado, rol_baja_logica)
VALUES ('Empresa' , 1, 0)
GO
INSERT INTO EL_REJUNTE.Rol (rol_nombre ,rol_habilitado, rol_baja_logica)
VALUES ('Cliente' , 1, 0)
GO
/* Funcionalidades */
INSERT INTO EL_REJUNTE.Funcionalidad (func_descripcion)
VALUES ('Abm Rol')
GO
INSERT INTO EL_REJUNTE.Funcionalidad (func_descripcion)
VALUES ('Abm Cliente')
GO
INSERT INTO EL_REJUNTE.Funcionalidad (func_descripcion)
VALUES ('Abm Empresa Espectaculo')
GO
INSERT INTO EL_REJUNTE.Funcionalidad (func_descripcion)
VALUES ('Abm Rubro')
GO
INSERT INTO EL_REJUNTE.Funcionalidad (func_descripcion)
VALUES ('Abm Grado')
GO
INSERT INTO EL_REJUNTE.Funcionalidad (func_descripcion)
VALUES ('Generar Publicacion')
GO
INSERT INTO EL_REJUNTE.Funcionalidad (func_descripcion)
VALUES ('Editar Publicacion')
GO
INSERT INTO EL_REJUNTE.Funcionalidad (func_descripcion)
VALUES ('Comprar')
GO
INSERT INTO EL_REJUNTE.Funcionalidad (func_descripcion)
VALUES ('Historial del Cliente')
GO
INSERT INTO EL_REJUNTE.Funcionalidad (func_descripcion)
VALUES ('Canjar Puntos')
GO
INSERT INTO EL_REJUNTE.Funcionalidad (func_descripcion)
VALUES ('Generar Pago de Comisiones')
GO
INSERT INTO EL_REJUNTE.Funcionalidad (func_descripcion)
VALUES ('Listado Estadistico')
GO
/* Rol Administrador */
INSERT INTO EL_REJUNTE.Rol_Usuario (rol_id ,usuario_id)
VALUES (1 ,1 )
GO
/* Rol Administrador */
INSERT INTO EL_REJUNTE.Func_Rol (func_id , rol_id)
VALUES (1 ,1 )
GO
INSERT INTO EL_REJUNTE.Func_Rol (func_id , rol_id)
VALUES (2 ,1 )
GO
INSERT INTO EL_REJUNTE.Func_Rol (func_id , rol_id)
VALUES (3 ,1 )
GO
INSERT INTO EL_REJUNTE.Func_Rol (func_id , rol_id)
VALUES (4 ,1 )
GO
INSERT INTO EL_REJUNTE.Func_Rol (func_id , rol_id)
VALUES (5 ,1 )
GO
INSERT INTO EL_REJUNTE.Func_Rol (func_id , rol_id)
VALUES (6 ,1 )
GO
INSERT INTO EL_REJUNTE.Func_Rol (func_id , rol_id)
VALUES (7 ,1 )
GO
INSERT INTO EL_REJUNTE.Func_Rol (func_id , rol_id)
VALUES (8 ,1 )
GO
INSERT INTO EL_REJUNTE.Func_Rol (func_id , rol_id)
VALUES (9 ,1 )
GO
INSERT INTO EL_REJUNTE.Func_Rol (func_id , rol_id)
VALUES (10 ,1 )
GO
INSERT INTO EL_REJUNTE.Func_Rol (func_id , rol_id)
VALUES (11 ,1 )
GO
INSERT INTO EL_REJUNTE.Func_Rol (func_id , rol_id)
VALUES (12 ,1 )
GO
/* Rol Empresa */
INSERT INTO EL_REJUNTE.Func_Rol (func_id , rol_id)
VALUES (3 ,2 )
GO
INSERT INTO EL_REJUNTE.Func_Rol (func_id , rol_id)
VALUES (5 ,2 )
GO
/* Rol Cliente */
INSERT INTO EL_REJUNTE.Func_Rol (func_id , rol_id)
VALUES (1 ,3 )
GO
INSERT INTO EL_REJUNTE.Func_Rol (func_id , rol_id)
VALUES (4 ,3 )
GO


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

CREATE PROCEDURE EL_REJUNTE.Migracion
AS
BEGIN
	/* Limpio las tablas para no tener errores despues */
	DELETE FROM [EL_REJUNTE].[Ubicacion_Compra]
	DELETE FROM [EL_REJUNTE].[Item_Factura]
	DELETE FROM [EL_REJUNTE].[Compra]
	DELETE FROM [EL_REJUNTE].[Ubicacion]
	DELETE FROM [EL_REJUNTE].[Factura]
	DELETE FROM [EL_REJUNTE].[Cliente]
	DELETE FROM [EL_REJUNTE].[Empresa]
	DELETE FROM [EL_REJUNTE].[Espectaculo]
	DELETE FROM [EL_REJUNTE].[Direccion]

	/* Variables para las Empresas */
	DECLARE @Espec_Empresa_Razon_Social nvarchar(255)
	DECLARE @Espec_Empresa_Cuit nvarchar(255)
	DECLARE @Espec_Empresa_Fecha_Creacion datetime
	DECLARE @Espec_Empresa_Mail nvarchar(50)
	/* Variables para las Direcciones de las Empresas */
	DECLARE @Espec_Empresa_Dom_Calle nvarchar(255)
	DECLARE @Espec_Empresa_Nro_Calle numeric(18,0)
	DECLARE @Espec_Empresa_Piso numeric(18,0)
	DECLARE @Espec_Empresa_Depto nvarchar(255)
	DECLARE @Espec_Empresa_Cod_Postal nvarchar(255)
	/* Variables para los Espectaculos */
	DECLARE @Espectaculo_Cod numeric(18,0)
	DECLARE @Espectaculo_Descripcion nvarchar(255)
	DECLARE @Espectaculo_Fecha datetime
	DECLARE @Espectaculo_Fecha_Venc datetime
	DECLARE @Espectaculo_Rubro_Descripcion nvarchar(255)
	DECLARE @Espectaculo_Estado nvarchar(255)
	/* Variables para las Ubicaciones */
	DECLARE @Ubicacion_Fila varchar(3)
	DECLARE @Ubicacion_Asiento numeric(18,0)
	DECLARE @Ubicacion_Sin_numerar bit
	DECLARE @Ubicacion_Precio numeric(18,0)
	DECLARE @Ubicacion_Tipo_Codigo numeric(18,0)
	DECLARE @Ubicacion_Tipo_Descripcion nvarchar(255)
	/* Variables para los Clientes */
	DECLARE @Cli_Dni numeric(18,0)
	DECLARE @Cli_Apellido nvarchar(255)
	DECLARE @Cli_Nombre nvarchar(255)
	DECLARE @Cli_Fecha_Nac datetime
	DECLARE @Cli_Mail nvarchar(255)
	/* Variables para las Direcciones de los Clientes */
	DECLARE @Cli_Dom_Calle nvarchar(255)
	DECLARE @Cli_Nro_Calle numeric(18,0)
	DECLARE @Cli_Piso numeric(18,0)
	DECLARE @Cli_Depto nvarchar(255)
	DECLARE @Cli_Cod_Postal nvarchar(255)
	/* Variables para las Compras */
	DECLARE @Compra_Fecha datetime
	DECLARE @Compra_Cantidad numeric(18,0)
	/* Variables para los Items */
	DECLARE @Item_Factura_Monto numeric(18,0)
	DECLARE @Item_Factura_Cantidad numeric(18,0)
	DECLARE @Item_Factura_Descripcion nvarchar(60)
	/* Variables para las Facturas */
	DECLARE @Factura_Nro numeric(18,0)
	DECLARE @Factura_Fecha datetime
	DECLARE @Factura_Total numeric(18,2)
	DECLARE @Forma_Pago_Desc nvarchar(255)
	/* Otras Variables */
	DECLARE @ID_Direccion INT
	DECLARE @ID_Cliente INT
	DECLARE @ID_Empresa INT
	DECLARE @ID_Rubro INT
	DECLARE @ID_Espectaculo INT
	DECLARE @ID_Ubicacion INT
	DECLARE @ID_Compra INT
	DECLARE @ID_Item INT
	DECLARE @ID_Factura INT
	
	DECLARE c_maestro CURSOR FOR
		SELECT gd.Espec_Empresa_Razon_Social, gd.Espec_Empresa_Cuit, gd.Espec_Empresa_Fecha_Creacion, gd.Espec_Empresa_Mail, gd.Espec_Empresa_Dom_Calle, gd.Espec_Empresa_Nro_Calle, gd.Espec_Empresa_Piso, gd.Espec_Empresa_Depto, gd.Espec_Empresa_Cod_Postal, gd.Espectaculo_Cod, gd.Espectaculo_Descripcion, gd.Espectaculo_Fecha, gd.Espectaculo_Fecha_Venc, gd.Espectaculo_Rubro_Descripcion, gd.Espectaculo_Estado, gd.Ubicacion_Fila, gd.Ubicacion_Asiento, gd.Ubicacion_Sin_numerar, gd.Ubicacion_Precio, gd.Ubicacion_Tipo_Codigo, gd.Ubicacion_Tipo_Descripcion, gd.Cli_Dni, gd.Cli_Apeliido, gd.Cli_Nombre, gd.Cli_Fecha_Nac, gd.Cli_Mail, gd.Cli_Dom_Calle, gd.Cli_Nro_Calle, gd.Cli_Piso, gd.Cli_Depto, gd.Cli_Cod_Postal, gd.Compra_Fecha, gd.Compra_Cantidad, gd.Item_Factura_Monto, gd.Item_Factura_Cantidad, gd.Item_Factura_Descripcion, gd.Factura_Nro, gd.Factura_Fecha, gd.Factura_Total, gd.Forma_Pago_Desc
		FROM gd_esquema.Maestra gd
			
	OPEN c_maestro
	FETCH NEXT FROM c_maestro INTO @Espec_Empresa_Razon_Social, @Espec_Empresa_Cuit, @Espec_Empresa_Fecha_Creacion, @Espec_Empresa_Mail, @Espec_Empresa_Dom_Calle, @Espec_Empresa_Nro_Calle, @Espec_Empresa_Piso, @Espec_Empresa_Depto, @Espec_Empresa_Cod_Postal, @Espectaculo_Cod, @Espectaculo_Descripcion, @Espectaculo_Fecha, @Espectaculo_Fecha_Venc, @Espectaculo_Rubro_Descripcion, @Espectaculo_Estado, @Ubicacion_Fila ,@Ubicacion_Asiento ,@Ubicacion_Sin_numerar ,@Ubicacion_Precio ,@Ubicacion_Tipo_Codigo ,@Ubicacion_Tipo_Descripcion, @Cli_Dni, @Cli_Apellido, @Cli_Nombre, @Cli_Fecha_Nac, @Cli_Mail, @Cli_Dom_Calle, @Cli_Nro_Calle,@Cli_Piso, @Cli_Depto, @Cli_Cod_Postal, @Compra_Fecha, @Compra_Cantidad, @Item_Factura_Monto, @Item_Factura_Cantidad, @Item_Factura_Descripcion, @Factura_Nro, @Factura_Fecha, @Factura_Total, @Forma_Pago_Desc

	WHILE(@@FETCH_STATUS=0)
	BEGIN
	/* Empieza el clasificado */
		/* Valido los datos de Direccion de Usuario que voy a insertar */
		IF(@Cli_Dom_Calle IS NOT NULL AND @Cli_Nro_Calle IS NOT NULL AND @Cli_Piso IS NOT NULL AND @Cli_Depto IS NOT NULL AND @Cli_Cod_Postal IS NOT NULL )
		BEGIN
			/* Verifico si ya existe dentro de la tabla este registro, asi evito datos duplicados */
			SELECT @ID_Direccion = dire_id 
			FROM Direccion 
			WHERE @Cli_Dom_Calle = dire_calle AND 
				  @Cli_Nro_Calle = dire_numero AND 
				  @Cli_Piso = dire_piso AND 
				  @Cli_Depto = dire_depto AND 
				  @Cli_Cod_Postal = dire_codigo_postal
					  
			IF(@ID_Direccion IS NULL)
			BEGIN
				/* Si no existe el registro, lo inserto */
				INSERT INTO EL_REJUNTE.Direccion (dire_calle, dire_numero, dire_piso, dire_depto, dire_codigo_postal)
				VALUES (@Cli_Dom_Calle, @Cli_Nro_Calle, @Cli_Piso, @Cli_Depto, @Cli_Cod_Postal)
			END
		
			/* Termina el clasificado de Direcciones */
			/* Ya que los valores son unicos, voy a traerme el ID del campo, en esta instancia tiene que existir si o si */			  
				
			/*Verifico si el Cliente ya existe o si es Cliente Nuevo*/
			SELECT @ID_Cliente = clie_id
			FROM Cliente
			WHERE clie_nombre = @Cli_Nombre AND
				  clie_apellido = @Cli_Apellido AND
				  clie_documento = @Cli_Dni AND
				  clie_email = @Cli_Mail AND
				  clie_direccion_id = @ID_Direccion AND
				  clie_fecha_nacimiento = @Cli_Fecha_Nac
			IF(@ID_Cliente IS NULL)
			BEGIN
				SELECT @ID_Direccion = dire_id 
				FROM Direccion 
				WHERE @Cli_Dom_Calle = dire_calle AND 
					  @Cli_Nro_Calle = dire_numero AND 
					  @Cli_Piso = dire_piso AND 
					  @Cli_Depto = dire_depto AND 
					  @Cli_Cod_Postal = dire_codigo_postal
				/* Hago el Insert de los Clientes, con sus respectivas Direcciones */
				INSERT INTO EL_REJUNTE.Cliente (clie_nombre, clie_apellido, clie_tipo_documento, clie_documento, clie_cuil, clie_email, clie_telefono, clie_direccion_id, clie_fecha_nacimiento,clie_fecha_creacion, clie_tarjeta_id, clie_habilitado, clie_usuario_id)
				VALUES (@Cli_Nombre, @Cli_Apellido, 'DNI', @Cli_Dni, '123' , @Cli_Mail, 123, @ID_Direccion, @Cli_Fecha_Nac, GETDATE(), null, 1, null)
			END
		END
		/* Reinicio el ID_Direccion para que si no existe el campo, no me tome el valor del insert anterior */
		SET @ID_Direccion = NULL
	/* Termina el clasificado de Clientes */
	
		/* Valido los datos de Direccion de la Empresa que voy a insertar */
		IF(@Espec_Empresa_Dom_Calle IS NOT NULL AND @Espec_Empresa_Nro_Calle IS NOT NULL AND @Espec_Empresa_Piso IS NOT NULL AND @Espec_Empresa_Depto IS NOT NULL AND @Espec_Empresa_Cod_Postal IS NOT NULL )
		BEGIN
			/* Verifico si ya existe dentro de la tabla este registro, asi evito datos duplicados */
			SELECT @ID_Direccion = dire_id 
			FROM Direccion 
			WHERE @Espec_Empresa_Dom_Calle = dire_calle AND 
				  @Espec_Empresa_Nro_Calle = dire_numero AND 
				  @Espec_Empresa_Piso = dire_piso AND 
				  @Espec_Empresa_Depto = dire_depto AND 
				  @Espec_Empresa_Cod_Postal = dire_codigo_postal
					  
			IF(@ID_Direccion IS NULL)
			BEGIN
				/* Si no existe el registro, lo inserto */
				INSERT INTO EL_REJUNTE.Direccion (dire_calle, dire_numero, dire_piso, dire_depto, dire_codigo_postal)
				VALUES (@Espec_Empresa_Dom_Calle, @Espec_Empresa_Nro_Calle, @Espec_Empresa_Piso, @Espec_Empresa_Depto, @Espec_Empresa_Cod_Postal)
			END
		

			/*Verifico si la Empresa ya existe o si es Empresa Nueva*/
			SELECT @ID_Empresa = empre_id
			FROM Empresa
			WHERE empre_razon_social = @Espec_Empresa_Razon_Social AND
				  empre_cuit = @Espec_Empresa_Cuit AND
				  empre_fecha_creacion = @Espec_Empresa_Fecha_Creacion AND
				  empre_mail = @Espec_Empresa_Mail AND
				  empre_direccion_id = @ID_Direccion
			IF(@ID_Empresa IS NULL)
			BEGIN
				SELECT @ID_Direccion = dire_id 
				FROM Direccion 
				WHERE @Espec_Empresa_Dom_Calle = dire_calle AND 
					  @Espec_Empresa_Nro_Calle = dire_numero AND 
					  @Espec_Empresa_Piso = dire_piso AND 
					  @Espec_Empresa_Depto = dire_depto AND 
					  @Espec_Empresa_Cod_Postal = dire_codigo_postal
				/* Hago el Insert de las Empresas, con sus respectivas Direcciones */
				INSERT INTO EL_REJUNTE.Empresa (empre_razon_social, empre_cuit, empre_fecha_creacion, empre_mail, empre_direccion_id, empre_telefono, empre_usuario_id, empre_baja_logica)
				VALUES (@Espec_Empresa_Razon_Social, @Espec_Empresa_Cuit, @Espec_Empresa_Fecha_Creacion, @Espec_Empresa_Mail, @ID_Direccion, null, null, 0)
			END
		END
		/* Reinicio el ID_Direccion para que si no existe el campo, no me tome el valor del insert anterior */
		SET @ID_Direccion = NULL
	/* Termina el clasificado de Empresas */
	
		IF(@Espectaculo_Cod IS NOT NULL AND @Espectaculo_Descripcion IS NOT NULL AND @Espectaculo_Fecha IS NOT NULL AND @Espectaculo_Fecha_Venc IS NOT NULL AND @Espectaculo_Estado IS NOT NULL)
		BEGIN
		/*Verifico si el Espectaculo ya existe o si es Especulo Nuevo*/
			SELECT @ID_Espectaculo = espec_id
			FROM Espectaculo
			WHERE espec_codigo = @Espectaculo_Cod AND
				  espec_descripcion = @Espectaculo_Descripcion AND
				  espec_fecha = @Espectaculo_Fecha AND
				  espec_fecha_venc = @Espectaculo_Fecha_Venc AND
				  espec_estado = @Espectaculo_Estado
			IF(@ID_Espectaculo IS NULL)
			BEGIN
				INSERT INTO EL_REJUNTE.Espectaculo (espec_codigo , espec_descripcion, espec_fecha, espec_fecha_venc, espec_rubro_id, espec_estado)
				VALUES (@Espectaculo_Cod, @Espectaculo_Descripcion, @Espectaculo_Fecha, @Espectaculo_Fecha_Venc, null, @Espectaculo_Estado)
			END
		END
		/* Termina el clasificado de Espectaculos */
		IF(@Ubicacion_Fila IS NOT NULL AND @Ubicacion_Asiento IS NOT NULL AND @Ubicacion_Sin_numerar IS NOT NULL AND @Ubicacion_Precio IS NOT NULL AND @Ubicacion_Tipo_Codigo IS NOT NULL AND @Ubicacion_Tipo_Descripcion IS NOT NULL)
		BEGIN
			/*Verifico si la Ubicacion ya existe o si es Ubicacion Nueva*/
			SELECT @ID_Ubicacion = ubica_id
			FROM Ubicacion
			WHERE ubica_fila = @Ubicacion_Fila AND
				  ubica_asiento = @Ubicacion_Asiento AND
				  ubica_sin_numerar = @Ubicacion_Sin_numerar AND
				  ubica_precio = @Ubicacion_Precio AND
				  ubica_tipo_codigo = @Ubicacion_Tipo_Codigo AND 
				  ubica_tipo_descripcion = @Ubicacion_Tipo_Descripcion
			IF(@ID_Espectaculo IS NULL)
			BEGIN
				INSERT INTO EL_REJUNTE.Ubicacion (ubica_fila , ubica_asiento, ubica_sin_numerar, ubica_precio, ubica_tipo_codigo, ubica_tipo_descripcion,ubica_facturada)
				VALUES (@Ubicacion_Fila, @Ubicacion_Asiento, @Ubicacion_Sin_numerar, @Ubicacion_Precio, @Ubicacion_Tipo_Codigo, @Ubicacion_Tipo_Descripcion, 0)
			END
		END
		/*Verifico si la Compra ya existe o si es Compra Nueva*/
		IF(@Compra_Fecha IS NOT NULL AND @Compra_Cantidad IS NOT NULL)
		BEGIN
			SELECT @ID_Compra = compra_id
			FROM Compra
			WHERE compra_fecha = @Compra_Fecha AND
				  compra_cantidad = @Compra_Cantidad AND
				  compra_cliente_id = @ID_Cliente
				  
			IF(@ID_Compra IS NULL)
			BEGIN				

				SELECT @ID_Cliente = clie_id
				FROM Cliente
				WHERE clie_nombre = @Cli_Nombre AND
					clie_apellido = @Cli_Apellido AND
					clie_documento = @Cli_Dni AND
					clie_email = @Cli_Mail AND
					clie_direccion_id = @ID_Direccion AND
					clie_fecha_nacimiento = @Cli_Fecha_Nac
				  
				SELECT @ID_Ubicacion = ubica_id
				FROM Ubicacion
				WHERE ubica_fila = @Ubicacion_Fila AND
				  ubica_asiento = @Ubicacion_Asiento AND
				  ubica_sin_numerar = @Ubicacion_Sin_numerar AND
				  ubica_precio = @Ubicacion_Precio AND
				  ubica_tipo_codigo = @Ubicacion_Tipo_Codigo AND 
				  ubica_tipo_descripcion = @Ubicacion_Tipo_Descripcion
				  
				IF(@ID_Cliente IS NOT NULL AND @ID_Ubicacion IS NOT NULL)
				BEGIN
					INSERT INTO EL_REJUNTE.Compra (compra_fecha , compra_cantidad, compra_cliente_id)
					VALUES (@Compra_Fecha, @Compra_Cantidad, @ID_Cliente)
					/* Agrego el campo de la tabla intermedia */
		
					SELECT @ID_Compra = compra_id
					FROM Compra
					WHERE compra_fecha = @Compra_Fecha AND
						compra_cantidad = @Compra_Cantidad AND
						compra_cliente_id = @ID_Cliente
			
					INSERT INTO EL_REJUNTE.Ubicacion_Compra(ubica_id, compra_id)
					VALUES(@ID_Ubicacion, @ID_Compra)
				END
			END
		END
	
	/* Termina el clasificado de Ubicaciones */
		IF(@Factura_Nro IS NOT NULL AND @Factura_Fecha IS NOT NULL AND @Factura_Total IS NOT NULL AND @Forma_Pago_Desc IS NOT NULL)
		BEGIN
			SELECT @ID_Factura = fact_id
			FROM Factura
			WHERE fact_nro = @Factura_Nro AND
				  fact_fecha = @Factura_Fecha AND
				  fact_total = @Factura_Total AND
				  fact_pago_desc = @Forma_Pago_Desc
				  
			IF(@ID_Factura IS NULL )
			BEGIN
				SELECT @ID_Cliente = clie_id
				FROM Cliente
				WHERE clie_nombre = @Cli_Nombre AND
					clie_apellido = @Cli_Apellido AND
					clie_documento = @Cli_Dni AND
					clie_email = @Cli_Mail AND
					clie_direccion_id = @ID_Direccion AND
					clie_fecha_nacimiento = @Cli_Fecha_Nac
					
				SELECT @ID_Empresa = empre_id
				FROM Empresa
				WHERE empre_razon_social = @Espec_Empresa_Razon_Social AND
					empre_cuit = @Espec_Empresa_Cuit AND
					empre_fecha_creacion = @Espec_Empresa_Fecha_Creacion AND
					empre_mail = @Espec_Empresa_Mail AND
					empre_direccion_id = @ID_Direccion
					
				IF(@ID_Cliente IS NOT NULL AND @ID_Empresa IS NOT NULL AND @Factura_Nro IS NOT NULL)
				BEGIN
					INSERT INTO EL_REJUNTE.Factura (fact_nro , fact_fecha, fact_total, fact_pago_desc, fact_cliente_id, fact_empresa_id)
					VALUES (@Factura_Nro, @Factura_Fecha, @Factura_Total, @Forma_Pago_Desc, @ID_Cliente, @ID_Empresa)
				END
			END
		END
	
	/* Termina el clasificado de Facturacion */
		IF(@Item_Factura_Monto IS NOT NULL AND @Item_Factura_Cantidad IS NOT NULL AND @Item_Factura_Descripcion IS NOT NULL)
		BEGIN
			SELECT @ID_Item = item_id
			FROM Item_Factura
			WHERE item_monto = @Item_Factura_Monto AND
				  item_cantidad = @Item_Factura_Cantidad AND
				  item_descripcion = @Item_Factura_Descripcion	
		
			IF(@ID_Item IS NULL )
			BEGIN
				SELECT @ID_Factura = fact_id
				FROM Factura
				WHERE fact_nro = @Factura_Nro AND
					fact_fecha = @Factura_Fecha AND
					fact_total = @Factura_Total AND
					fact_pago_desc = @Forma_Pago_Desc
					
				SELECT @ID_Ubicacion = ubica_id
				FROM Ubicacion
				WHERE ubica_fila = @Ubicacion_Fila AND
				  ubica_asiento = @Ubicacion_Asiento AND
				  ubica_sin_numerar = @Ubicacion_Sin_numerar AND
				  ubica_precio = @Ubicacion_Precio AND
				  ubica_tipo_codigo = @Ubicacion_Tipo_Codigo AND 
				  ubica_tipo_descripcion = @Ubicacion_Tipo_Descripcion
					
				IF(@ID_Factura IS NOT NULL AND @ID_Ubicacion IS NOT NULL)
				BEGIN
					INSERT INTO EL_REJUNTE.Item_Factura (item_monto , item_cantidad, item_descripcion, item_factura_id, item_ubicacion_id)
					VALUES (@Item_Factura_Monto, @Item_Factura_Cantidad, @Item_Factura_Descripcion, @ID_Factura, @ID_Ubicacion)
				END
			END
		END
	
	/* Reinicio las variables Unicas */
		SET @ID_Direccion = NULL
		SET @ID_Direccion = NULL
		SET @ID_Cliente = NULL
		SET @ID_Empresa = NULL
		SET @ID_Rubro = NULL
		SET @ID_Espectaculo = NULL
		SET @ID_Ubicacion = NULL
		SET @ID_Compra = NULL
		SET @ID_Item = NULL
		SET @ID_Factura = NULL
		
	/* Tomo la siguiente Linea */
		FETCH NEXT FROM c_maestro INTO @Espec_Empresa_Razon_Social, @Espec_Empresa_Cuit, @Espec_Empresa_Fecha_Creacion, @Espec_Empresa_Mail, @Espec_Empresa_Dom_Calle, @Espec_Empresa_Nro_Calle, @Espec_Empresa_Piso, @Espec_Empresa_Depto, @Espec_Empresa_Cod_Postal, @Espectaculo_Cod, @Espectaculo_Descripcion, @Espectaculo_Fecha, @Espectaculo_Fecha_Venc, @Espectaculo_Rubro_Descripcion, @Espectaculo_Estado, @Ubicacion_Fila ,@Ubicacion_Asiento ,@Ubicacion_Sin_numerar ,@Ubicacion_Precio ,@Ubicacion_Tipo_Codigo ,@Ubicacion_Tipo_Descripcion, @Cli_Dni, @Cli_Apellido, @Cli_Nombre, @Cli_Fecha_Nac, @Cli_Mail, @Cli_Dom_Calle, @Cli_Nro_Calle,@Cli_Piso, @Cli_Depto, @Cli_Cod_Postal, @Compra_Fecha, @Compra_Cantidad, @Item_Factura_Monto, @Item_Factura_Cantidad, @Item_Factura_Descripcion, @Factura_Nro, @Factura_Fecha, @Factura_Total, @Forma_Pago_Desc
	END
	/* Termino de recorrer el Cursor, lo cierro y libero la memoria */
	CLOSE c_maestro
	DEALLOCATE c_maestro
END
GO

EXEC EL_REJUNTE.Migracion
GO