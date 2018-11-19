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
                          "WHERE r.rol_nombre = '" + rol + "' AND " +
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

    }
}