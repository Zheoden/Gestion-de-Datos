using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PalcoNet.Objetos;

namespace PalcoNet.Utils {

    public partial class ClienteHelper {

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
                          "WHERE r.rol_nombre = '" + rol + "'";
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

        public static Boolean habilitarRol(string rol) {

            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            SqlCommand command = conn.CreateCommand();
            command.CommandText = "UPDATE EL_REJUNTE.Rol " +
                                  "SET rol_habilitado = 1 " +
                                  "WHERE rol_nombre = '" + rol + "'";
            command.Connection = conn;
            command.Connection.Open();
            int rows = command.ExecuteNonQuery();
            command.Connection.Close();
            conn.Close();
            return rows > 0;

        }

        public static Boolean deshabilitarRol(string rol) {

            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            SqlCommand command = conn.CreateCommand();
            command.CommandText = "UPDATE EL_REJUNTE.Rol " +
                                  "SET rol_habilitado = 0 " +
                                  "WHERE rol_nombre = '" + rol + "'";
            command.Connection = conn;
            command.Connection.Open();
            int rows = command.ExecuteNonQuery();
            command.Connection.Close();
            conn.Close();
            return rows > 0;

        }

        public static Boolean rolStatusHabilitado(string rol) {

            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            conn.Open();
            string SQL = "SELECT rol_habilitado " +
                         "FROM EL_REJUNTE.Rol " +
                         "WHERE rol_nombre = '" + rol + "'";

            SqlCommand command = new SqlCommand(SQL, conn);
            command.Connection = conn;
            command.CommandType = CommandType.Text;

            SqlDataReader reader = command.ExecuteReader() as SqlDataReader;

            if (reader.HasRows) {
                while (reader.Read()) {
                    return Convert.ToBoolean(reader["rol_habilitado"].ToString());
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

    }
}