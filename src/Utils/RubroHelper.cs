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

        public static List<Rubro> getRubros() {

            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            conn.Open();
            string SQL = "SELECT r.rubro_id, r.rubro_descripcion, r.rubro_habilitado " +
                          "FROM EL_REJUNTE.Rubro r ";

            SqlCommand command = new SqlCommand(SQL, conn);
            command.Connection = conn;
            command.CommandType = CommandType.Text;

            SqlDataReader reader = command.ExecuteReader() as SqlDataReader;
            List<Rubro> rubros = new List<Rubro>();
            if (reader.HasRows) {
                while (reader.Read()) {
                    Rubro rubro = new Rubro();
                    rubro.id = Int32.Parse(reader["rubro_id"].ToString());
                    rubro.descripcion = reader["rubro_descripcion"].ToString();
                    rubro.habilitado = Convert.ToBoolean(reader["rubro_habilitado"].ToString());
                    rubros.Add(rubro);
                }
            }

            conn.Close();
            return rubros;
        }

        public static Rubro getRubro(string descripcion) {

            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            conn.Open();
            string SQL = "SELECT r.rubro_id, r.rubro_descripcion, r.rubro_habilitado " +
                          "FROM EL_REJUNTE.Rubro r " +
                          "WHERE r.rubro_descripcion = '" + descripcion + "'";

            SqlCommand command = new SqlCommand(SQL, conn);
            command.Connection = conn;
            command.CommandType = CommandType.Text;

            SqlDataReader reader = command.ExecuteReader() as SqlDataReader;
            Rubro rubro = new Rubro();
            if (reader.HasRows) {
                while (reader.Read()) {
                    rubro.id = Int32.Parse(reader["rubro_id"].ToString());
                    rubro.descripcion = reader["rubro_descripcion"].ToString();
                    rubro.habilitado = Convert.ToBoolean(reader["rubro_habilitado"].ToString());
                }
            }

            conn.Close();
            return rubro;
        }

    }
}