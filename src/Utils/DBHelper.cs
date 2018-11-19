using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System;
using PalcoNet.Objetos;
namespace PalcoNet.Utils {

    public class DBHelper {

        public static List<Funcionalidad> getFuncionalidades() {
            List<Funcionalidad> func = new List<Funcionalidad>();

            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            conn.Open();
            string SQL = "SELECT f.func_id, f.func_descripcion " +
                          "FROM EL_REJUNTE.Funcionalidad f ";
            SqlCommand command = new SqlCommand(SQL, conn);
            command.Connection = conn;
            command.CommandType = CommandType.Text;

            SqlDataReader reader = command.ExecuteReader() as SqlDataReader;

            if (reader.HasRows) {
                while (reader.Read()) {

                    Funcionalidad funcionalidad = new Funcionalidad();
                    funcionalidad.id = Int32.Parse(reader["func_id"].ToString());
                    funcionalidad.descripcion = reader["func_descripcion"].ToString();
                    func.Add(funcionalidad);
                }
            }

            conn.Close();
            return func;
        }

        public static List<Funcionalidad> getFuncionalidadesPorRol(string rol) {
            List<Funcionalidad> func = new List<Funcionalidad>();

            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            conn.Open();
            string SQL = "SELECT f.func_id, f.func_descripcion " +
                          "FROM EL_REJUNTE.Funcionalidad f, EL_REJUNTE.Rol r, EL_REJUNTE.Func_Rol fr " + 
                          "WHERE r.rol_nombre = '" + rol + "' AND "+
                          "fr.func_id = f.func_id AND " + 
                          "fr.rol_id = r.rol_id";
            SqlCommand command = new SqlCommand(SQL, conn);
            command.Connection = conn;
            command.CommandType = CommandType.Text;

            SqlDataReader reader = command.ExecuteReader() as SqlDataReader;

            if (reader.HasRows) {
                while (reader.Read()) {

                    Funcionalidad funcionalidad = new Funcionalidad();
                    funcionalidad.id = Int32.Parse(reader["func_id"].ToString());
                    funcionalidad.descripcion = reader["func_descripcion"].ToString();
                    func.Add(funcionalidad);
                }
            }

            conn.Close();
            return func;
        }

        public static Boolean rolExistHabilitado(string rol) {

            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            conn.Open();
            string SQL = "SELECT r.rol_id " +
                          "FROM EL_REJUNTE.Rol r " +
                          "WHERE r.rol_nombre = '" + rol + "' AND " +
                          "r.rol_habilitado = 1";
            SqlCommand command = new SqlCommand(SQL, conn);
            command.Connection = conn;
            command.CommandType = CommandType.Text;

            SqlDataReader reader = command.ExecuteReader() as SqlDataReader;

            if (reader.HasRows) {
                while (reader.Read()) {
                    return reader["rol_id"].ToString() != null;
                }
            }

            conn.Close();
            return false;
        }

        public static Boolean rolDontExist(string rol) {

            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            conn.Open();
            string SQL = "SELECT 1 " +
                          "FROM EL_REJUNTE.Rol r " +
                          "WHERE r.rol_nombre = '" + rol + "'" ;
            SqlCommand command = new SqlCommand(SQL, conn);
            command.Connection = conn;
            command.CommandType = CommandType.Text;

            SqlDataReader reader = command.ExecuteReader() as SqlDataReader;

            if (!reader.HasRows) {
                return true;
            }

            conn.Close();
            return false;
        }

        public static Boolean rolExistDesHabilitado(string rol) {

            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            conn.Open();
            string SQL = "SELECT r.rol_id " +
                          "FROM EL_REJUNTE.Rol r " +
                          "WHERE r.rol_nombre = '" + rol + "' AND " +
                          "r.rol_habilitado = 0";
            SqlCommand command = new SqlCommand(SQL, conn);
            command.Connection = conn;
            command.CommandType = CommandType.Text;

            SqlDataReader reader = command.ExecuteReader() as SqlDataReader;

            if (reader.HasRows) {
                while (reader.Read()) {
                    return reader["rol_id"].ToString() != null;
                }
            }

            conn.Close();
            return false;
        }

        public static Boolean bajaRol(string rol) {

            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            SqlCommand command = conn.CreateCommand();
            command.CommandText = "UPDATE EL_REJUNTE.Rol " +
                                  "SET rol_baja_logica = 1 " +
                                  "WHERE rol_nombre = '" + rol + "'";
            command.Connection = conn;
            command.Connection.Open();
            int rows = command.ExecuteNonQuery();
            command.Connection.Close();
            conn.Close();
            return rows > 0;
        }

        public static Boolean altaRol(string rol, List<string> funcionalidades) {

            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            SqlCommand command = conn.CreateCommand();
            command.CommandText = "INSERT INTO EL_REJUNTE.Rol (rol_nombre, rol_habilitado, rol_baja_logica) " +
                                  "VALUES ('" + rol + "', 1, 0)";
            command.Connection = conn;
            command.Connection.Open();
            int rows = command.ExecuteNonQuery();
            command.Connection.Close();
            conn.Close();
            int rowsFunc = agregarFuncionalidades(rol, funcionalidades);
            return rows > 0 && rowsFunc > 0;
        }

        private static int agregarFuncionalidades(string rol, List<string> funcionalidades) {

            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            SqlCommand command = conn.CreateCommand();
            string SQL = "INSERT INTO EL_REJUNTE.Func_Rol (func_id, rol_id) " +
                                  "SELECT f.func_id, r.rol_id " +
                                  "FROM EL_REJUNTE.Funcionalidad f, EL_REJUNTE.Rol r " +
                                  "WHERE r.rol_nombre = '" + rol + "' AND " +
                                  "(";
            foreach (string item in funcionalidades) {

                SQL += "f.func_descripcion = '" + item + "' OR ";

            }
            SQL = SQL.Substring(0, SQL.Length - 3);
            SQL += ")";
            command.CommandText = SQL;
            command.Connection = conn;
            command.Connection.Open();
            int rows = command.ExecuteNonQuery();
            command.Connection.Close();
            conn.Close();
            return rows;
        }

        public static Boolean bajaFuncionalidades(string rol) {

            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            SqlCommand command = conn.CreateCommand();
            command.CommandText = "DELETE FROM EL_REJUNTE.Func_Rol " +
                                  "WHERE rol_id = (SELECT rol_id FROM EL_REJUNTE.Rol WHERE rol_nombre = '" + rol + "') ";
            command.Connection = conn;
            command.Connection.Open();
            int rows = command.ExecuteNonQuery();
            command.Connection.Close();
            conn.Close();
            return rows > 0;
        }

        public static Boolean altaFuncionalidades(string rol, string funcionalidad) {

            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            SqlCommand command = conn.CreateCommand();
            command.CommandText = "INSERT INTO EL_REJUNTE.Func_Rol (func_id, rol_id) " +
                                  "VALUES ((SELECT func_id FROM EL_REJUNTE.Funcionalidad WHERE func_descripcion = '" + funcionalidad + "'), (SELECT rol_id FROM EL_REJUNTE.Rol WHERE rol_nombre = '" + rol + "') )";
            command.Connection = conn;
            command.Connection.Open();
            int rows = command.ExecuteNonQuery();
            command.Connection.Close();
            conn.Close();
            return rows > 0;
        }

        public static Boolean bajaCliente(string cliente) {

            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            SqlCommand command = conn.CreateCommand();
            command.CommandText = "UPDATE EL_REJUNTE.Cliente " +
                                  "SET clie_habilitado = 0 " +
                                  "WHERE clie_nombre = '" + cliente + "'";
            command.Connection = conn;
            command.Connection.Open();
            int rows = command.ExecuteNonQuery();
            command.Connection.Close();
            conn.Close();
            return rows > 0;
        }

        public static Boolean clienteDontExistDocumento(string tipo, string documento) {

            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            conn.Open();
            string SQL = "SELECT 1 " +
                          "FROM EL_REJUNTE.Cliente c " +
                          "WHERE c.clie_tipo_documento = '" + tipo + "' AND " +
                          "c.clie_documento = '" + documento + "'";

            SqlCommand command = new SqlCommand(SQL, conn);
            command.Connection = conn;
            command.CommandType = CommandType.Text;

            SqlDataReader reader = command.ExecuteReader() as SqlDataReader;

            if (!reader.HasRows) {
                return true;
            }

            conn.Close();
            return false;
        }

        public static Boolean clienteDontExistCuil(string cuil) {

            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            conn.Open();
            string SQL = "SELECT 1 " +
                          "FROM EL_REJUNTE.Cliente c " +
                          "WHERE c.clie_cuil = '" + cuil + "'";

            SqlCommand command = new SqlCommand(SQL, conn);
            command.Connection = conn;
            command.CommandType = CommandType.Text;

            SqlDataReader reader = command.ExecuteReader() as SqlDataReader;

            if (!reader.HasRows) {
                return true;
            }

            conn.Close();
            return false;
        }

        public static Boolean altaDeTarjeta(Tarjeta tarjeta) {
            if (verificarTarjetaDontExist(tarjeta)) {
                SqlConnection conn = new SqlConnection(Connection.getStringConnection());
                SqlCommand command = conn.CreateCommand();
                command.CommandText = "INSERT INTO EL_REJUNTE.Tarjeta (tarj_numero, tarj_titular, tarj_vencimiento, tarj_tipo, tarj_cod_seguridad) " +
                                      "VALUES ('" + tarjeta.numero + "', '" + tarjeta.titular + "', '" + tarjeta.vencimiento + "', '" + tarjeta.tipo + "', '" + tarjeta.cod_seguridad + "')";
                command.Connection = conn;
                command.Connection.Open();
                int rows = command.ExecuteNonQuery();
                command.Connection.Close();
                conn.Close();
                return rows > 0;
            }
            else {
                return true;
            }
        }

        public static Boolean altaDeDireccion(Direccion direccion) {
            if (verificarDireccionDontExist(direccion)) {
                SqlConnection conn = new SqlConnection(Connection.getStringConnection());
                SqlCommand command = conn.CreateCommand();
                command.CommandText = "INSERT INTO EL_REJUNTE.Direccion (dire_calle, dire_numero, dire_piso, dire_depto, dire_localidad, dire_codigo_postal) " +
                                      "VALUES ('" + direccion.calle + "', '" + direccion.numero + "', '" + direccion.piso + "', '" + direccion.depto + "', '" + direccion.localidad + "', '" + direccion.codigo_postal + "')";
                command.Connection = conn;
                command.Connection.Open();
                int rows = command.ExecuteNonQuery();
                command.Connection.Close();
                conn.Close();
                return rows > 0;
            }
            else {
                return true;
            }
        }

        public static Boolean altaCliente(Cliente cliente) {

            SqlConnection connection = new SqlConnection(Connection.getStringConnection());
            SqlCommand comm = connection.CreateCommand();
            comm.CommandText = "INSERT INTO EL_REJUNTE.Cliente (clie_nombre, clie_apellido, clie_tipo_documento, clie_documento, clie_cuil, clie_email, clie_telefono, clie_direccion_id, clie_fecha_nacimiento, clie_fecha_creacion, clie_tarjeta_id, clie_habilitado, clie_usuario_id) " +
                                "VALUES ('" + cliente.nombre + "', '" + cliente.apellido + "', '" + cliente.tipo_documento + "', " + cliente.documento + ", '" + cliente.cuil + "', '" + cliente.mail + "', '" + cliente.telefono + "'," + "(SELECT dire_id FROM EL_REJUNTE.Direccion WHERE dire_calle = '" + cliente.dire.calle + "' AND dire_numero = '" + cliente.dire.numero + "' AND dire_piso = '" + cliente.dire.piso + "' AND dire_depto = '" + cliente.dire.depto + "' AND dire_localidad = '" + cliente.dire.localidad + "' AND dire_codigo_postal = '" + cliente.dire.codigo_postal + "') , " + "GETDATE()" + ", " + "GETDATE()" + "," + "(SELECT tarj_id FROM EL_REJUNTE.Tarjeta WHERE tarj_numero = '" + cliente.tarjeta.numero + "' AND tarj_cod_seguridad = '" + cliente.tarjeta.cod_seguridad + "' AND tarj_vencimiento = '" + cliente.tarjeta.vencimiento + "' AND tarj_titular = '" + cliente.tarjeta.titular + "' AND tarj_tipo = '" + cliente.tarjeta.tipo + "')" + ", 1, null" +
                                ")";
            comm.Connection = connection;
            comm.Connection.Open();
            int rows = comm.ExecuteNonQuery();
            comm.Connection.Close();
            connection.Close();
            return rows > 0;
        }

        public static Boolean verificarDireccionDontExist(Direccion dire) {

            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            conn.Open();
            string SQL = "SELECT 1 " +
                         "FROM EL_REJUNTE.Direccion " + 
                         "WHERE dire_calle = '" + dire.calle + "' AND "+
                         "dire_numero = '" + dire.numero + "' AND " + 
                         "dire_piso = '" + dire.piso + "' AND " + 
                         "dire_depto = '" + dire.depto + "' AND " +
                         "dire_localidad = '" + dire.localidad + "' AND " +
                         "dire_codigo_postal = '" + dire.codigo_postal + "'";

            SqlCommand command = new SqlCommand(SQL, conn);
            command.Connection = conn;
            command.CommandType = CommandType.Text;

            SqlDataReader reader = command.ExecuteReader() as SqlDataReader;

            if (!reader.HasRows) {
                return true;
            }

            conn.Close();
            return false;
        }

        public static Boolean verificarTarjetaDontExist(Tarjeta tarjeta) {

            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            conn.Open();
            string SQL = "SELECT 1 " + 
                         "FROM EL_REJUNTE.Tarjeta " + 
                         "WHERE tarj_numero = '" + tarjeta.numero + "' AND " + 
                         "tarj_cod_seguridad = '" + tarjeta.cod_seguridad + "' AND " + 
                         "tarj_vencimiento = '" + tarjeta.vencimiento + "' AND " + 
                         "tarj_titular = '" + tarjeta.titular + "' AND " + 
                         "tarj_tipo = '" + tarjeta.tipo + "'";

            SqlCommand command = new SqlCommand(SQL, conn);
            command.Connection = conn;
            command.CommandType = CommandType.Text;

            SqlDataReader reader = command.ExecuteReader() as SqlDataReader;

            if (!reader.HasRows) {
                return true;
            }

            conn.Close();
            return false;
        }

    }
}