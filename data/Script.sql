USE GD2C2018;


IF NOT EXISTS (select * from sys.schemas where name = 'EL_REJUNTE')
BEGIN
EXEC('create schema EL_REJUNTE')
END;
GO

IF NOT EXISTS (select * from sysobjects where name='Cliente' and xtype='U')
CREATE TABLE  EL_REJUNTE.Cliente(
	clie_id INT NOT NULL ,
	clie_nombre nvarchar(50) NOT NULL,
	clie_apellido nvarchar(50) NOT NULL,
	clie_tipo_documento nvarchar(255) NOT NULL,
	clie_documento INT NOT NULL,
	clie_CUIL nvarchar(11) NOT NULL,
	clie_email nvarchar(50) NOT NULL,
	clie_telefono nvarchar(10) NOT NULL,
	clie_direccion_id INT NOT NULL,
	clie_fecha_nacimiento date NOT NULL,
	clie_fecha_creacion date NOT NULL,
	clie_tarjeta_id INT NOT NULL,
	clie_habilitado bit NOT NULL,
	clie_usuario_id INT,
 CONSTRAINT PK_Cliente PRIMARY KEY (clie_id))
GO

IF NOT EXISTS (select * from sysobjects where name='Compra' and xtype='U')
CREATE TABLE EL_REJUNTE.Compra(
	compra_id INT NOT NULL,
	compra_fecha datetime NOT NULL,
	compra_cantidad numeric(18, 0) NOT NULL,
	compra_cliente_id INT NOT NULL,
  CONSTRAINT PK_Compra PRIMARY KEY (compra_id))
GO

IF NOT EXISTS (select * from sysobjects where name='Direccion' and xtype='U')
CREATE TABLE  [EL_REJUNTE].[Direccion](
	[dire_id] INT NOT NULL,
	[dire_calle] nvarchar(10) NULL,
	[dire_numero] nvarchar(10) NULL,
	[dire_piso] nvarchar(10) NULL,
	[dire_depto] nvarchar(10) NULL,
	[dire_localidad] nvarchar(10) NULL,
	[dire_codigo_postal] nvarchar(10) NULL,
  CONSTRAINT PK_Direccion PRIMARY KEY (dire_id))
GO

IF NOT EXISTS (select * from sysobjects where name='Empresa' and xtype='U')
CREATE TABLE  [EL_REJUNTE].[Empresa](
	[empre_id] INT NOT NULL ,
	[empre_razon_social] nvarchar(255) NULL,
	[empre_cuit] nvarchar(255) NULL,
	[empre_fecha_creacion] datetime NULL,
	[empre_mail] nvarchar(50) NULL,
	[empre_direccion_id] INT NULL,
	[empre_telefono] nvarchar(50) NULL,
	[empre_usuario_id] INT NULL,
   CONSTRAINT PK_Empresa PRIMARY KEY (empre_id))
GO

IF NOT EXISTS (select * from sysobjects where name='Espectaculo' and xtype='U')
CREATE TABLE  [EL_REJUNTE].[Espectaculo](
	[espec_id] INT NOT NULL ,
	[espec_codigo] numeric(18, 0) NULL,
	[espec_descripcion] nvarchar(255) NULL,
	[espec_fecha] datetime NULL,
	[espec_fecha_venc] datetime NULL,
	[espec_rubro_id] INT NULL,
	[espec_estado] nvarchar(255) NULL,
   CONSTRAINT PK_Espectaculo PRIMARY KEY (espec_id))
GO

IF NOT EXISTS (select * from sysobjects where name='Estado' and xtype='U')
CREATE TABLE  [EL_REJUNTE].[Estado](
	[estado_id] INT NOT NULL ,
	[estado_descripcion] nvarchar(50) NULL,
	[estado_inicial] BIT NULL,
	[estado_final] BIT NULL,
 CONSTRAINT PK_Estado PRIMARY KEY (estado_id))
GO

CREATE TABLE  [EL_REJUNTE].[Factura](
	[fact_id] INT NOT NULL ,
	[fact_nro] numeric(18, 0) NULL,
	[fact_fecha] datetime NULL,
	[fact_total] numeric(18, 2) NULL,
	[fact_pago_desc] nvarchar(255) NULL,
	[fact_cliente_id] INT NULL,
	[fact_empresa_id] INT NULL,
 CONSTRAINT [PK_Factura] PRIMARY KEY CLUSTERED 
(
	[fact_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


CREATE TABLE  [EL_REJUNTE].[Func_Rol](
	[funci_id] INT NOT NULL,
	[rol_id] INT NOT NULL,
 CONSTRAINT [PK_Func_Rol] PRIMARY KEY CLUSTERED 
(
	[funci_id] ASC,
	[rol_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


CREATE TABLE  [EL_REJUNTE].[Funcionalidad](
	[funci_id] INT NOT NULL,
	[func_descripcion] nvarchar(10) NULL,
 CONSTRAINT [PK_Funcionalidad] PRIMARY KEY CLUSTERED 
(
	[funci_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


CREATE TABLE  [EL_REJUNTE].[Grado](
	[grado_id] INT NOT NULL ,
	[grado_descripcion] nvarchar(50) NULL,
	[grado_comision] numeric(18, 0) NULL,
	[grado_porcentaje] numeric(18, 0) NULL,
 CONSTRAINT [PK_Grado] PRIMARY KEY CLUSTERED 
(
	[grado_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


CREATE TABLE  [EL_REJUNTE].[Item_Factura](
	[item_id] INT NOT NULL ,
	[item_monto] numeric(18, 2) NULL,
	[item_cantidad] numeric(18, 0) NULL,
	[item_descripcion] nvarchar(60) NULL,
	[item_factura_id] INT NULL,
	[item_ubicacion_id] INT NULL,
 CONSTRAINT [PK_Item_Factura] PRIMARY KEY CLUSTERED 
(
	[item_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


CREATE TABLE  [EL_REJUNTE].[Publicacion](
	[publi_id] INT NOT NULL ,
	[publi_descripcion] nvarchar(50) NULL,
	[publi_estado_id] INT NULL,
	[publi_fecha_inicio] datetime NULL,
	[publi_fecha_evento] datetime NULL,
	[publi_codigo] numeric(18, 0) NULL,
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


CREATE TABLE  [EL_REJUNTE].[Rol](
	[rol_id] INT NOT NULL ,
	[rol_nombre] nvarchar(60) NOT NULL,
	[rol_habilitado] BIT NOT NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[rol_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE  [EL_REJUNTE].[Rol_Usuario](
	[rol_id] INT NOT NULL,
	[usuario_id] INT NOT NULL,
 CONSTRAINT [PK_Rol_Usuario] PRIMARY KEY CLUSTERED 
(
	[rol_id] ASC,
	[usuario_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


CREATE TABLE  [EL_REJUNTE].[Rubro](
	[rubro_id] INT NOT NULL,
	[rubro_codigo] nvarchar(10) NULL,
	[rubro_descripcion] nvarchar(255) NULL,
 CONSTRAINT [PK_Rubro] PRIMARY KEY CLUSTERED 
(
	[rubro_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE  [EL_REJUNTE].[Ubicacion](
	[ubica_id] INT NOT NULL,
	[ubica_fila] [varbinary](3) NULL,
	[ubica_asiento] numeric(18, 0) NULL,
	[ubica_sin_numerar] BIT NULL,
	[ubica_precio] numeric(18, 0) NULL,
	[ubica_tipo_codigo] numeric(18, 0) NULL,
	[ubica_tipo_descripcion] nvarchar(255) NULL,
	[ubica_facturada] BIT NULL,
 CONSTRAINT [PK_Ubicacion] PRIMARY KEY CLUSTERED 
(
	[ubica_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE  [EL_REJUNTE].[Ubicacion_Compra](
	[ubica_id] INT NULL,
	[compra_id] INT NULL
) ON [PRIMARY]

GO

CREATE TABLE  [EL_REJUNTE].[Ubicacion_Publicacion](
	[ubica_id] INT NULL,
	[publi_id] INT NULL
) ON [PRIMARY]

CREATE TABLE  [EL_REJUNTE].[Usuario](
	[usuario_id] INT NOT NULL,
	[usuario_username] nvarchar(10) NULL,
	[usuario_password] nvarchar(10) NULL,
	[usuario_habilitado] BIT NULL,
	[usuario_cant_logeo_error] [int] NULL,
	[usuario_tipo] nvarchar(55) NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[usuario_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE  [EL_REJUNTE].[Tarjeta](
	[tarj_id] INT NOT NULL,
	[tarj_numero] nvarchar(10) NULL,
	[tarj_cod_seguridad] nvarchar(10) NULL,
	[tarj_vencimiento] BIT NULL,
	[tarj_titular] [int] NULL,
	[tarj_tipo] INT NULL,
 CONSTRAINT [PK_Tarjeta] PRIMARY KEY CLUSTERED 
(
	[tarj_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE  [EL_REJUNTE].[Puntaje](
	[punt_id] INT NOT NULL,
	[punt_id_cliente] nvarchar(10) NULL,
	[punt_cantidad] nvarchar(10) NULL,
	[punt_vencimiento] BIT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[usuario_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [EL_REJUNTE].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Direccion] FOREIGN KEY([clie_direccion_id])
REFERENCES [EL_REJUNTE].[Direccion] ([dire_id])
GO
ALTER TABLE [EL_REJUNTE].[Cliente] CHECK CONSTRAINT [FK_Cliente_Direccion]
GO
ALTER TABLE [EL_REJUNTE].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Documento] FOREIGN KEY([clie_documento])
REFERENCES [EL_REJUNTE].[Documento] ([doc_id])
GO
ALTER TABLE [EL_REJUNTE].[Cliente] CHECK CONSTRAINT [FK_Cliente_Documento]
GO
ALTER TABLE [EL_REJUNTE].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Usuario] FOREIGN KEY([clie_usuario_id])
REFERENCES [EL_REJUNTE].[Usuario] ([usuario_id])
GO
ALTER TABLE [EL_REJUNTE].[Cliente] CHECK CONSTRAINT [FK_Cliente_Usuario]
GO
ALTER TABLE [EL_REJUNTE].[Compra]  WITH CHECK ADD  CONSTRAINT [FK_Compra_Cliente] FOREIGN KEY([compra_cliente_id])
REFERENCES [EL_REJUNTE].[Cliente] ([clie_id])
GO
ALTER TABLE [EL_REJUNTE].[Compra] CHECK CONSTRAINT [FK_Compra_Cliente]
GO
ALTER TABLE [EL_REJUNTE].[Documento]  WITH CHECK ADD  CONSTRAINT [FK_Documento_Tipo_Documento] FOREIGN KEY([doc_tipo_id])
REFERENCES [EL_REJUNTE].[Tipo_Documento] ([tipo_doc_id])
GO
ALTER TABLE [EL_REJUNTE].[Documento] CHECK CONSTRAINT [FK_Documento_Tipo_Documento]
GO
ALTER TABLE [EL_REJUNTE].[Empresa]  WITH CHECK ADD  CONSTRAINT [FK_Empresa_Direccion] FOREIGN KEY([empre_direccion_id])
REFERENCES [EL_REJUNTE].[Direccion] ([dire_id])
GO
ALTER TABLE [EL_REJUNTE].[Empresa] CHECK CONSTRAINT [FK_Empresa_Direccion]
GO
ALTER TABLE [EL_REJUNTE].[Empresa]  WITH CHECK ADD  CONSTRAINT [FK_Empresa_Usuario] FOREIGN KEY([empre_usuario_id])
REFERENCES [EL_REJUNTE].[Usuario] ([usuario_id])
GO
ALTER TABLE [EL_REJUNTE].[Empresa] CHECK CONSTRAINT [FK_Empresa_Usuario]
GO
ALTER TABLE [EL_REJUNTE].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_Factura_Cliente] FOREIGN KEY([fact_cliente_id])
REFERENCES [EL_REJUNTE].[Cliente] ([clie_id])
GO
ALTER TABLE [EL_REJUNTE].[Factura] CHECK CONSTRAINT [FK_Factura_Cliente]
GO
ALTER TABLE [EL_REJUNTE].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_Factura_Empresa] FOREIGN KEY([fact_Empresa_id])
REFERENCES [EL_REJUNTE].[Empresa] ([empre_id])
GO
ALTER TABLE [EL_REJUNTE].[Factura] CHECK CONSTRAINT [FK_Factura_Empresa]
GO
ALTER TABLE [EL_REJUNTE].[Func_Rol]  WITH CHECK ADD  CONSTRAINT [FK_Func_Rol_Funcionalidad] FOREIGN KEY([funci_id])
REFERENCES [EL_REJUNTE].[Funcionalidad] ([funci_id])
GO
ALTER TABLE [EL_REJUNTE].[Func_Rol] CHECK CONSTRAINT [FK_Func_Rol_Funcionalidad]
GO
ALTER TABLE [EL_REJUNTE].[Func_Rol]  WITH CHECK ADD  CONSTRAINT [FK_Func_Rol_Rol] FOREIGN KEY([rol_id])
REFERENCES [EL_REJUNTE].[Rol] ([rol_id])
GO
ALTER TABLE [EL_REJUNTE].[Func_Rol] CHECK CONSTRAINT [FK_Func_Rol_Rol]
GO
ALTER TABLE [EL_REJUNTE].[Item_Factura]  WITH CHECK ADD  CONSTRAINT [FK_Item_Factura_Factura] FOREIGN KEY([item_factura_id])
REFERENCES [EL_REJUNTE].[Factura] ([fact_id])
GO
ALTER TABLE [EL_REJUNTE].[Item_Factura] CHECK CONSTRAINT [FK_Item_Factura_Factura]
GO
ALTER TABLE [EL_REJUNTE].[Item_Factura]  WITH CHECK ADD  CONSTRAINT [FK_Item_Factura_Factura1] FOREIGN KEY([item_factura_id])
REFERENCES [EL_REJUNTE].[Factura] ([fact_id])
GO
ALTER TABLE [EL_REJUNTE].[Item_Factura] CHECK CONSTRAINT [FK_Item_Factura_Factura1]
GO
ALTER TABLE [EL_REJUNTE].[Item_Factura]  WITH CHECK ADD  CONSTRAINT [FK_Item_Factura_Ubicacion] FOREIGN KEY([item_ubicacion_id])
REFERENCES [EL_REJUNTE].[Ubicacion] ([ubica_id])
GO
ALTER TABLE [EL_REJUNTE].[Item_Factura] CHECK CONSTRAINT [FK_Item_Factura_Ubicacion]
GO
ALTER TABLE [EL_REJUNTE].[Publicacion]  WITH CHECK ADD  CONSTRAINT [FK_Publicacion_Espectaculo] FOREIGN KEY([publi_espectaculo_id])
REFERENCES [EL_REJUNTE].[Espectaculo] ([espec_id])
GO
ALTER TABLE [EL_REJUNTE].[Publicacion] CHECK CONSTRAINT [FK_Publicacion_Espectaculo]
GO
ALTER TABLE [EL_REJUNTE].[Publicacion]  WITH CHECK ADD  CONSTRAINT [FK_Publicacion_Estado] FOREIGN KEY([publi_estado_id])
REFERENCES [EL_REJUNTE].[Estado] ([estado_id])
GO
ALTER TABLE [EL_REJUNTE].[Publicacion] CHECK CONSTRAINT [FK_Publicacion_Estado]
GO
ALTER TABLE [EL_REJUNTE].[Publicacion]  WITH CHECK ADD  CONSTRAINT [FK_Publicacion_Grado] FOREIGN KEY([publi_grado_id])
REFERENCES [EL_REJUNTE].[Grado] ([grado_id])
GO
ALTER TABLE [EL_REJUNTE].[Publicacion] CHECK CONSTRAINT [FK_Publicacion_Grado]
GO
ALTER TABLE [EL_REJUNTE].[Publicacion]  WITH CHECK ADD  CONSTRAINT [FK_Publicacion_Rubro] FOREIGN KEY([publi_rubro_id])
REFERENCES [EL_REJUNTE].[Rubro] ([rubro_id])
GO
ALTER TABLE [EL_REJUNTE].[Publicacion] CHECK CONSTRAINT [FK_Publicacion_Rubro]
GO
ALTER TABLE [EL_REJUNTE].[Rol_Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Rol_Usuario_Rol] FOREIGN KEY([rol_id])
REFERENCES [EL_REJUNTE].[Rol] ([rol_id])
GO
ALTER TABLE [EL_REJUNTE].[Rol_Usuario] CHECK CONSTRAINT [FK_Rol_Usuario_Rol]
GO
ALTER TABLE [EL_REJUNTE].[Rol_Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Rol_Usuario_Usuario] FOREIGN KEY([usuario_id])
REFERENCES [EL_REJUNTE].[Usuario] ([usuario_id])
GO
ALTER TABLE [EL_REJUNTE].[Rol_Usuario] CHECK CONSTRAINT [FK_Rol_Usuario_Usuario]
GO
ALTER TABLE [EL_REJUNTE].[Ubicacion_Compra]  WITH CHECK ADD  CONSTRAINT [FK_Ubicacion_Compra_Compra] FOREIGN KEY([compra_id])
REFERENCES [EL_REJUNTE].[Compra] ([compra_id])
GO
ALTER TABLE [EL_REJUNTE].[Ubicacion_Compra] CHECK CONSTRAINT [FK_Ubicacion_Compra_Compra]
GO
ALTER TABLE [EL_REJUNTE].[Ubicacion_Compra]  WITH CHECK ADD  CONSTRAINT [FK_Ubicacion_Compra_Ubicacion] FOREIGN KEY([ubica_id])
REFERENCES [EL_REJUNTE].[Ubicacion] ([ubica_id])
GO
ALTER TABLE [EL_REJUNTE].[Ubicacion_Compra] CHECK CONSTRAINT [FK_Ubicacion_Compra_Ubicacion]
GO
ALTER TABLE [EL_REJUNTE].[Ubicacion_Publicacion]  WITH CHECK ADD  CONSTRAINT [FK_Ubicacion_Publicacion_Publicacion] FOREIGN KEY([publi_id])
REFERENCES [EL_REJUNTE].[Publicacion] ([publi_id])
GO
ALTER TABLE [EL_REJUNTE].[Ubicacion_Publicacion] CHECK CONSTRAINT [FK_Ubicacion_Publicacion_Publicacion]
GO
ALTER TABLE [EL_REJUNTE].[Ubicacion_Publicacion]  WITH CHECK ADD  CONSTRAINT [FK_Ubicacion_Publicacion_Ubicacion] FOREIGN KEY([ubica_id])
REFERENCES [EL_REJUNTE].[Ubicacion] ([ubica_id])
GO
ALTER TABLE [EL_REJUNTE].[Ubicacion_Publicacion] CHECK CONSTRAINT [FK_Ubicacion_Publicacion_Ubicacion]
GO
USE [master]
GO
ALTER DATABASE [GD2C2018] SET  READ_WRITE 
GO