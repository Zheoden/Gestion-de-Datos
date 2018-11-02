INSERT INTO EL_REJUNTE.Cliente (clie_nombre, clie_apellido, clie_tipo_documento, clie_documento, clie_cuil, clie_email, clie_telefono, clie_direccion_id, clie_fecha_nacimiento,
								clie_fecha_creacion, clie_tarjeta_id, clie_habilitado, clie_usuario_id)
SELECT gd.Cli_Nombre, gd.Cli_Apellido, 'DNI', gd.Cli_Dni, '123' , gd.Cli_Mail, 123, null, gd.Cli_Fecha_Nac, GETDATE(), null, 1, null
FROM gd_esquema.Maestra gd
WHERE  gd.Cli_Nombre IS NOT NULL AND
		gd.Cli_Apellido IS NOT NULL AND
		gd.Cli_Dni IS NOT NULL AND
		gd.Cli_Mail IS NOT NULL