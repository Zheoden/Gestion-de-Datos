CREATE PROCEDURE EL_REJUNTE.Migracion
AS
BEGIN
	/* Datos para las Empresas */
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
	/* Otras Variables */
	DECLARE @ID_row INT

	DECLARE c_maestro CURSOR FOR
		SELECT TOP 1000 gd.Espec_Empresa_Razon_Social, gd.Espec_Empresa_Cuit, gd.Espec_Empresa_Fecha_Creacion, gd.Espec_Empresa_Mail, gd.Espec_Empresa_Dom_Calle, gd.Espec_Empresa_Nro_Calle, gd.Espec_Empresa_Piso, gd.Espec_Empresa_Depto, gd.Espec_Empresa_Cod_Postal, gd.Cli_Dni, gd.Cli_Apeliido, gd.Cli_Nombre, gd.Cli_Fecha_Nac, gd.Cli_Mail, gd.Cli_Dom_Calle, gd.Cli_Nro_Calle, gd.Cli_Piso, gd.Cli_Depto, gd.Cli_Cod_Postal
		FROM gd_esquema.Maestra gd
		WHERE   gd.Cli_Nombre IS NOT NULL AND
				gd.Cli_Apeliido IS NOT NULL AND
				gd.Cli_Dni IS NOT NULL AND
				gd.Cli_Mail IS NOT NULL
			
	OPEN c_maestro
	FETCH NEXT FROM c_maestro INTO @Espec_Empresa_Razon_Social, @Espec_Empresa_Cuit, @Espec_Empresa_Fecha_Creacion, @Espec_Empresa_Mail, @Espec_Empresa_Dom_Calle, @Espec_Empresa_Nro_Calle, @Espec_Empresa_Piso, @Espec_Empresa_Depto, @Espec_Empresa_Cod_Postal, @Cli_Dni, @Cli_Apellido, @Cli_Nombre, @Cli_Fecha_Nac, @Cli_Mail, @Cli_Dom_Calle, @Cli_Nro_Calle, @Cli_Piso, @Cli_Depto, @Cli_Cod_Postal

	WHILE(@@FETCH_STATUS=0)
	BEGIN
	/* Empieza el clasificado */
		/* Valido los datos que voy a insertar */
		IF(@Cli_Dom_Calle IS NOT NULL AND @Cli_Nro_Calle IS NOT NULL AND @Cli_Piso IS NOT NULL AND @Cli_Depto IS NOT NULL AND @Cli_Cod_Postal IS NOT NULL )
		BEGIN
			/* Verifico si ya existe dentro de la tabla este registro, asi evito datos duplicados */
			SELECT @ID_row = dire_id 
			FROM Direccion 
			WHERE @Cli_Dom_Calle = dire_calle AND 
				  @Cli_Nro_Calle = dire_numero AND 
				  @Cli_Piso = dire_piso AND 
				  @Cli_Depto = dire_depto AND 
				  @Cli_Cod_Postal = dire_codigo_postal
					  
			IF(@ID_row IS NULL)
			BEGIN
				/* Si no existe el registro, lo inserto */
				INSERT INTO EL_REJUNTE.Direccion (dire_calle, dire_numero, dire_piso, dire_depto, dire_codigo_postal)
				VALUES (@Cli_Dom_Calle, @Cli_Nro_Calle, @Cli_Piso, @Cli_Depto, @Cli_Cod_Postal)
			END
		END
		/* Termina el clasificado de Direcciones */
		/* Ya que los valores son unicos, voy a traerme el ID del campo, en esta instancia tiene que existir si o si */
		SELECT @ID_row = dire_id 
		FROM Direccion 
		WHERE @Cli_Dom_Calle = dire_calle AND 
			  @Cli_Nro_Calle = dire_numero AND 
			  @Cli_Piso = dire_piso AND 
			  @Cli_Depto = dire_depto AND 
			  @Cli_Cod_Postal = dire_codigo_postal
		
		/* Hago el Insert de los Clientes, con sus respectivas Direcciones */
		INSERT INTO EL_REJUNTE.Cliente (clie_nombre, clie_apellido, clie_tipo_documento, clie_documento, clie_cuil, clie_email, clie_telefono, clie_direccion_id, clie_fecha_nacimiento,clie_fecha_creacion, clie_tarjeta_id, clie_habilitado, clie_usuario_id)
		VALUES (@Cli_Nombre, @Cli_Apellido, 'DNI', @Cli_Dni, '123' , @Cli_Mail, 123, @ID_row, @Cli_Fecha_Nac, GETDATE(), null, 1, null)
		
		/* Reinicio el ID_row para que si no existe el campo, no me tome el valor del insert anterior */
		SET @ID_row = NULL
	/* Termina el clasificado de Clientes */
	
	
	
	
	
		IF(@Espec_Empresa_Dom_Calle IS NOT NULL AND @Espec_Empresa_Nro_Calle IS NOT NULL AND @Espec_Empresa_Piso IS NOT NULL AND @Espec_Empresa_Depto IS NOT NULL AND @Espec_Empresa_Cod_Postal IS NOT NULL )
		BEGIN
			/* Verifico si ya existe dentro de la tabla este registro, asi evito datos duplicados */
			SELECT @ID_row = dire_id 
			FROM Direccion 
			WHERE @Espec_Empresa_Dom_Calle = dire_calle AND 
				  @Espec_Empresa_Nro_Calle = dire_numero AND 
				  @Espec_Empresa_Piso = dire_piso AND 
				  @Espec_Empresa_Depto = dire_depto AND 
				  @Espec_Empresa_Cod_Postal = dire_codigo_postal
					  
			IF(@ID_row IS NULL)
			BEGIN
				/* Si no existe el registro, lo inserto */
				INSERT INTO EL_REJUNTE.Direccion (dire_calle, dire_numero, dire_piso, dire_depto, dire_codigo_postal)
				VALUES (@Espec_Empresa_Dom_Calle, @Espec_Empresa_Nro_Calle, @Espec_Empresa_Piso, @Espec_Empresa_Depto, @Espec_Empresa_Cod_Postal)
			END
		END
	
	
		/* Hago el Insert de las Empresas, con sus respectivas Direcciones */
		INSERT INTO EL_REJUNTE.Empresa (empre_razon_social, empre_cuit, empre_fecha_creacion, empre_mail, empre_direccion_id, empre_telefono, empre_usuario_id)
		VALUES (@Espec_Empresa_Razon_Social, @Espec_Empresa_Cuit, @Espec_Empresa_Fecha_Creacion, @Espec_Empresa_Mail, @ID_row, null, null)
		
		/* Reinicio el ID_row para que si no existe el campo, no me tome el valor del insert anterior */
		SET @ID_row = NULL
	/* Termina el clasificado de Empresas */
	
	
	/* Tomo la siguiente Linea */
		FETCH NEXT FROM c_maestro INTO @Espec_Empresa_Razon_Social, @Espec_Empresa_Cuit, @Espec_Empresa_Fecha_Creacion, @Espec_Empresa_Mail, @Espec_Empresa_Dom_Calle, @Espec_Empresa_Nro_Calle, @Espec_Empresa_Piso, @Espec_Empresa_Depto, @Espec_Empresa_Cod_Postal, @Cli_Dni, @Cli_Apellido, @Cli_Nombre, @Cli_Fecha_Nac, @Cli_Mail, @Cli_Dom_Calle, @Cli_Nro_Calle, @Cli_Piso, @Cli_Depto, @Cli_Cod_Postal
	END

	CLOSE c_maestro
	DEALLOCATE c_maestro
END
GO



