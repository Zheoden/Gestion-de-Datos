USE GD2C2018;

SELECT TOP 100 * FROM EL_REJUNTE.Usuario

SELECT TOP 100 * FROM EL_REJUNTE.Rol
SELECT TOP 100 * FROM EL_REJUNTE.Cliente


UPDATE clie_documento  FROM EL_REJUNTE.Cliente
INSERT INTO EL_REJUNTE.Usuario (usuario_username, usuario_password, usuario_habilitado, usuario_bloqueado, usuario_cant_logeo_error, usuario_tipo) " +
                                "VALUES ('" + usuario.username + "', '" + usuario.password + "', TRUE , FALSE , 0 , '" + usuario.roles[0].nombre + "')";
