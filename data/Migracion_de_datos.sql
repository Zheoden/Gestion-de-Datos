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
				INSERT INTO EL_REJUNTE.Empresa (empre_razon_social, empre_cuit, empre_fecha_creacion, empre_mail, empre_direccion_id, empre_telefono, empre_usuario_id)
				VALUES (@Espec_Empresa_Razon_Social, @Espec_Empresa_Cuit, @Espec_Empresa_Fecha_Creacion, @Espec_Empresa_Mail, @ID_Direccion, null, null)
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