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

        public static Boolean altaRol(string rol, List<string> funcionalidades) {

            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            SqlCommand command = conn.CreateCommand();
            command.CommandText = "INSERT INTO EL_REJUNTE.Rol (rol_nombre, rol_habilitado) " +
                                  "VALUES ('" + rol + "', 1)";
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
    }
}