CREATE PROCEDURE EL_REJUNTE.Migracion
AS
BEGIN
	DECLARE @Cli_Dni numeric(18,0)
	DECLARE @Cli_Apellido nvarchar(255)
	DECLARE @Cli_Nombre nvarchar(255)
	DECLARE @Cli_Fecha_Nac datetime
	DECLARE @Cli_Mail nvarchar(255)
	DECLARE @Cli_Dom_Calle nvarchar(255)
	DECLARE @Cli_Nro_Calle numeric(18,0)
	DECLARE @Cli_Piso numeric(18,0)
	DECLARE @Cli_Depto nvarchar(255)
	DECLARE @Cli_Cod_Postal nvarchar(255)
	DECLARE @ID_row INT

	DECLARE c_maestro CURSOR FOR
			SELECT TOP 100 gd.Cli_Dni, gd.Cli_Apeliido, gd.Cli_Nombre, gd.Cli_Fecha_Nac, gd.Cli_Mail, gd.Cli_Dom_Calle, gd.Cli_Nro_Calle, gd.Cli_Piso, gd.Cli_Depto, gd.Cli_Cod_Postal
			FROM gd_esquema.Maestra gd
			WHERE  gd.Cli_Nombre IS NOT NULL AND
				gd.Cli_Apeliido IS NOT NULL AND
				gd.Cli_Dni IS NOT NULL AND
				gd.Cli_Mail IS NOT NULL
			
	OPEN c_maestro
	FETCH NEXT FROM c_maestro INTO @Cli_Dni, @Cli_Apellido, @Cli_Nombre, @Cli_Fecha_Nac, @Cli_Mail, @Cli_Dom_Calle, @Cli_Nro_Calle, @Cli_Piso, @Cli_Depto, @Cli_Cod_Postal

	WHILE(@@FETCH_STATUS=0)
	BEGIN
		IF(@Cli_Dom_Calle IS NOT NULL AND @Cli_Nro_Calle IS NOT NULL AND @Cli_Piso IS NOT NULL AND @Cli_Depto IS NOT NULL @Cli_Cod_Postal IS NOT NULL )
		BEGIN
		
				SELECT @ID_row = dire_id 
				FROM Direccion 
				WHERE @Cli_Dom_Calle = dire_calle AND 
					  @Cli_Nro_Calle = dire_numero AND 
					  @Cli_Piso = dire_piso AND 
					  @Cli_Depto = dire_depto AND 
					  @Cli_Cod_Postal = dire_codigo_postal
					  
			IF(@ID_row IS NULL)
			BEGIN
				INSERT INTO EL_REJUNTE.Direccion (dire_calle, dire_numero, dire_piso, dire_depto, dire_codigo_postal)
				VALUES (@Cli_Dom_Calle, @Cli_Nro_Calle, @Cli_Piso, @Cli_Depto, @Cli_Cod_Postal)
			END
		END
		
		SELECT @ID_row = dire_id 
		FROM Direccion 
		WHERE @Cli_Dom_Calle = dire_calle AND 
			  @Cli_Nro_Calle = dire_numero AND 
			  @Cli_Piso = dire_piso AND 
			  @Cli_Depto = dire_depto AND 
			  @Cli_Cod_Postal = dire_codigo_postal
		
		INSERT INTO EL_REJUNTE.Cliente (clie_nombre, clie_apellido, clie_tipo_documento, clie_documento, clie_cuil, clie_email, clie_telefono, clie_direccion_id, clie_fecha_nacimiento,clie_fecha_creacion, clie_tarjeta_id, clie_habilitado, clie_usuario_id)
		VALUES (@Cli_Nombre, @Cli_Apellido, 'DNI', @Cli_Dni, '123' , @Cli_Mail, 123, @ID_row, @Cli_Fecha_Nac, GETDATE(), null, 1, null)
		
		SET @ID_row = NULL
	
		FETCH NEXT FROM c_maestro INTO @Cli_Dni, @Cli_Apellido, @Cli_Nombre, @Cli_Fecha_Nac, @Cli_Mail, @Cli_Dom_Calle, @Cli_Nro_Calle, @Cli_Piso, @Cli_Depto, @Cli_Cod_Postal
	END

	CLOSE c_maestro
	DEALLOCATE c_maestro
END
GO