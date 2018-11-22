using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PalcoNet.Objetos;

namespace PalcoNet.Utils {

    public partial class DBHelper {

        public static List<Estado> getEstados() {

            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            conn.Open();
            string SQL = "SELECT e.estado_id, e.estado_descripcion, e.estado_habilitado " +
                          "FROM EL_REJUNTE.Estado e ";

            SqlCommand command = new SqlCommand(SQL, conn);
            command.Connection = conn;
            command.CommandType = CommandType.Text;

            SqlDataReader reader = command.ExecuteReader() as SqlDataReader;
            List<Estado> estados = new List<Estado>();
            if (reader.HasRows) {
                while (reader.Read()) {
                    Estado estado = new Estado();
                    estado.id = Int32.Parse(reader["estado_id"].ToString());
                    estado.descripcion = reader["estado_descripcion"].ToString();
                    estado.habilitado = Convert.ToBoolean(reader["estado_habilitado"].ToString());
                    estados.Add(estado);
                }
            }

            conn.Close();
            return estados;
        }

        public static Estado getEstado(string descripcion) {

            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            conn.Open();
            string SQL = "SELECT e.estado_id, e.estado_descripcion, e.estado_habilitado " +
                          "FROM EL_REJUNTE.Estado e " +
                          "WHERE e.estado_descripcion = " + descripcion;

            SqlCommand command = new SqlCommand(SQL, conn);
            command.Connection = conn;
            command.CommandType = CommandType.Text;

            SqlDataReader reader = command.ExecuteReader() as SqlDataReader;
            Estado estado = new Estado();
            if (reader.HasRows) {
                while (reader.Read()) {
                    estado.id = Int32.Parse(reader["estado_id"].ToString());
                    estado.descripcion = reader["estado_descripcion"].ToString();
                    estado.habilitado = Convert.ToBoolean(reader["estado_habilitado"].ToString());
                }
            }

            conn.Close();
            return estado;
        }

    }
}