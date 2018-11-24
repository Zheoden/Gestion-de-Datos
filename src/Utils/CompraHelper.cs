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

        public static List<Compra> publicacionesHabilitadas() {

            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            conn.Open();
            string SQL = "SELECT p.publi_fecha_inicio, p.publi_fecha_evento, p.publi_stock, r.rubro_descripcion, p.publi_descripcion " +
                         "FROM EL_REJUNTE.Publicacion p, EL_REJUNTE.Rubro r, EL_REJUNTE.Grado g " +
                         "WHERE p.publi_rubro_id = r.rubro_id AND " +
                               "p.publi_grado_id = g.grado_id AND " +
                               "p.publi_estado_id = 2 "+
                         "ORDER BY p.publi_grado_id";
            SqlCommand command = new SqlCommand(SQL, conn);
            command.Connection = conn;
            command.CommandType = CommandType.Text;

            SqlDataReader reader = command.ExecuteReader() as SqlDataReader;
            List<Compra> compras = new List<Compra>();

            if (reader.HasRows) {
                while (reader.Read()) {
                    Compra compra = new Compra();
                    compra.stock = Int32.Parse(reader["publi_stock"].ToString());
                    compra.rubro = reader["rubro_descripcion"].ToString();
                    compra.fecha_evento = Convert.ToDateTime(reader["publi_fecha_evento"]);
                    compra.fecha_publicacion = Convert.ToDateTime(reader["publi_fecha_inicio"]);
                    compra.descripcion = reader["publi_descripcion"].ToString();
                    compras.Add(compra);
                }
            }

            conn.Close();
            return compras;

        }

        public static List<Compra> publicacionesHabilitadas(string rubro, string descripcion) {

            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            conn.Open();
            string SQL = "SELECT p.publi_fecha_inicio, p.publi_fecha_evento, p.publi_stock, r.rubro_descripcion, p.publi_descripcion " +
                         "FROM EL_REJUNTE.Publicacion p, EL_REJUNTE.Rubro r, EL_REJUNTE.Grado g " +
                         "WHERE p.publi_rubro_id = r.rubro_id AND " +
                               "p.publi_grado_id = g.grado_id AND " +
                               "p.publi_estado_id = 2 AND " +
                               "p.publi_descripcion LIKE '%" + descripcion + "%' AND " +
                               "r.rubro_descripcion = '" + rubro + "' " +
                         "ORDER BY p.publi_grado_id";
            SqlCommand command = new SqlCommand(SQL, conn);
            command.Connection = conn;
            command.CommandType = CommandType.Text;

            SqlDataReader reader = command.ExecuteReader() as SqlDataReader;
            List<Compra> compras = new List<Compra>();

            if (reader.HasRows) {
                while (reader.Read()) {
                    Compra compra = new Compra();
                    compra.stock = Int32.Parse(reader["publi_stock"].ToString());
                    compra.rubro = reader["rubro_descripcion"].ToString();
                    compra.fecha_evento = Convert.ToDateTime(reader["publi_fecha_evento"]);
                    compra.fecha_publicacion = Convert.ToDateTime(reader["publi_fecha_inicio"]);
                    compra.descripcion = reader["publi_descripcion"].ToString();
                    compras.Add(compra);
                }
            }

            conn.Close();
            return compras;

        }

        public static List<Compra> publicacionesHabilitadasRubro(string rubro) {

            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            conn.Open();
            string SQL = "SELECT p.publi_fecha_inicio, p.publi_fecha_evento, p.publi_stock, r.rubro_descripcion, p.publi_descripcion " +
                         "FROM EL_REJUNTE.Publicacion p, EL_REJUNTE.Rubro r, EL_REJUNTE.Grado g " +
                         "WHERE p.publi_rubro_id = r.rubro_id AND " +
                               "p.publi_grado_id = g.grado_id AND " +
                               "p.publi_estado_id = 2 AND " +
                               "r.rubro_descripcion = '" + rubro + "' " +
                         "ORDER BY p.publi_grado_id";
            SqlCommand command = new SqlCommand(SQL, conn);
            command.Connection = conn;
            command.CommandType = CommandType.Text;

            SqlDataReader reader = command.ExecuteReader() as SqlDataReader;
            List<Compra> compras = new List<Compra>();

            if (reader.HasRows) {
                while (reader.Read()) {
                    Compra compra = new Compra();
                    compra.stock = Int32.Parse(reader["publi_stock"].ToString());
                    compra.rubro = reader["rubro_descripcion"].ToString();
                    compra.fecha_evento = Convert.ToDateTime(reader["publi_fecha_evento"]);
                    compra.fecha_publicacion = Convert.ToDateTime(reader["publi_fecha_inicio"]);
                    compra.descripcion = reader["publi_descripcion"].ToString();
                    compras.Add(compra);
                }
            }

            conn.Close();
            return compras;

        }

        public static List<Compra> publicacionesHabilitadasDesc(string descripcion) {

            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            conn.Open();
            string SQL = "SELECT p.publi_fecha_inicio, p.publi_fecha_evento, p.publi_stock, r.rubro_descripcion, p.publi_descripcion " +
                         "FROM EL_REJUNTE.Publicacion p, EL_REJUNTE.Rubro r, EL_REJUNTE.Grado g " +
                         "WHERE p.publi_rubro_id = r.rubro_id AND " +
                               "p.publi_grado_id = g.grado_id AND " +
                               "p.publi_estado_id = 2 AND " +
                               "p.publi_descripcion LIKE '%" + descripcion + "%'" +
                         "ORDER BY p.publi_grado_id";
            SqlCommand command = new SqlCommand(SQL, conn);
            command.Connection = conn;
            command.CommandType = CommandType.Text;

            SqlDataReader reader = command.ExecuteReader() as SqlDataReader;
            List<Compra> compras = new List<Compra>();

            if (reader.HasRows) {
                while (reader.Read()) {
                    Compra compra = new Compra();
                    compra.stock = Int32.Parse(reader["publi_stock"].ToString());
                    compra.rubro = reader["rubro_descripcion"].ToString();
                    compra.fecha_evento = Convert.ToDateTime(reader["publi_fecha_evento"]);
                    compra.fecha_publicacion = Convert.ToDateTime(reader["publi_fecha_inicio"]);
                    compra.descripcion = reader["publi_descripcion"].ToString();
                    compras.Add(compra);
                }
            }

            conn.Close();
            return compras;

        }

    }
}