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

        public static List<Compra> publicacionesHabilitadas(DateTime desde, DateTime hasta) {

            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            conn.Open();
            string SQL = "SELECT p.publi_fecha_inicio, p.publi_fecha_evento, p.publi_stock, r.rubro_descripcion, p.publi_descripcion, u.ubica_precio " +
                         "FROM EL_REJUNTE.Publicacion p, EL_REJUNTE.Rubro r, EL_REJUNTE.Grado g, EL_REJUNTE.Ubicacion u, EL_REJUNTE.Ubicacion_Publicacion up " +
                         "WHERE p.publi_rubro_id = r.rubro_id AND " +
                               "p.publi_grado_id = g.grado_id AND " +
                               "p.publi_estado_id = 2 AND " +
                               "p.publi_stock > 0 AND " +
                               "u.ubica_id = up.ubica_id AND " +
                               "up.publi_id = p.publi_id AND " +
                               "p.publi_fecha_evento BETWEEN '" + desde.ToString("yyyy-MM-dd HH:mm:ss") + "' AND '" + hasta.ToString("yyyy-MM-dd HH:mm:ss") + "' " +
                         "ORDER BY p.publi_grado_id, p.publi_fecha_evento, p.publi_stock";

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
                    compra.precio = Int32.Parse(reader["ubica_precio"].ToString());
                    compras.Add(compra);
                }
            }

            conn.Close();
            return compras;

        }

        public static List<Compra> publicacionesHabilitadas(string rubro, string descripcion, DateTime desde, DateTime hasta) {

            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            conn.Open();
            string SQL = "SELECT p.publi_fecha_inicio, p.publi_fecha_evento, p.publi_stock, r.rubro_descripcion, p.publi_descripcion, u.ubica_precio " +
                         "FROM EL_REJUNTE.Publicacion p, EL_REJUNTE.Rubro r, EL_REJUNTE.Grado g, EL_REJUNTE.Ubicacion u, EL_REJUNTE.Ubicacion_Publicacion up " +
                         "WHERE p.publi_rubro_id = r.rubro_id AND " +
                               "p.publi_grado_id = g.grado_id AND " +
                               "p.publi_estado_id = 2 AND " +
                               "p.publi_stock > 0 AND " +
                               "u.ubica_id = up.ubica_id AND " +
                               "up.publi_id = p.publi_id AND " +
                               "p.publi_fecha_evento BETWEEN '" + desde.ToString("yyyy-MM-dd HH:mm:ss") + "' AND '" + hasta.ToString("yyyy-MM-dd HH:mm:ss") + "' AND " +
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
                    compra.precio = Int32.Parse(reader["ubica_precio"].ToString());
                    compras.Add(compra);
                }
            }

            conn.Close();
            return compras;

        }

        public static List<Compra> publicacionesHabilitadasRubro(string rubro, DateTime desde, DateTime hasta) {

            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            conn.Open();
            string SQL = "SELECT p.publi_fecha_inicio, p.publi_fecha_evento, p.publi_stock, r.rubro_descripcion, p.publi_descripcion, u.ubica_precio " +
                         "FROM EL_REJUNTE.Publicacion p, EL_REJUNTE.Rubro r, EL_REJUNTE.Grado g, EL_REJUNTE.Ubicacion u, EL_REJUNTE.Ubicacion_Publicacion up " +
                         "WHERE p.publi_rubro_id = r.rubro_id AND " +
                               "p.publi_grado_id = g.grado_id AND " +
                               "p.publi_estado_id = 2 AND " +
                               "p.publi_stock > 0 AND " +
                               "u.ubica_id = up.ubica_id AND " +
                               "up.publi_id = p.publi_id AND " +
                               "p.publi_fecha_evento BETWEEN '" + desde.ToString("yyyy-MM-dd HH:mm:ss") + "' AND '" + hasta.ToString("yyyy-MM-dd HH:mm:ss") + "' AND " +
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
                    compra.precio = Int32.Parse(reader["ubica_precio"].ToString());
                    compras.Add(compra);
                }
            }

            conn.Close();
            return compras;

        }

        public static List<Compra> publicacionesHabilitadasDesc(string descripcion, DateTime desde, DateTime hasta) {

            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            conn.Open();
            string SQL = "SELECT p.publi_fecha_inicio, p.publi_fecha_evento, p.publi_stock, r.rubro_descripcion, p.publi_descripcion, u.ubica_precio " +
                         "FROM EL_REJUNTE.Publicacion p, EL_REJUNTE.Rubro r, EL_REJUNTE.Grado g, EL_REJUNTE.Ubicacion u, EL_REJUNTE.Ubicacion_Publicacion up " +
                         "WHERE p.publi_rubro_id = r.rubro_id AND " +
                               "p.publi_grado_id = g.grado_id AND " +
                               "p.publi_estado_id = 2 AND " +
                               "p.publi_stock > 0 AND " +
                               "u.ubica_id = up.ubica_id AND " +
                               "up.publi_id = p.publi_id AND " +
                               "p.publi_fecha_evento BETWEEN '" + desde.ToString("yyyy-MM-dd HH:mm:ss") + "' AND '" + hasta.ToString("yyyy-MM-dd HH:mm:ss") + "' AND " +
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
                    compra.precio = Int32.Parse(reader["ubica_precio"].ToString());
                    compras.Add(compra);
                }
            }

            conn.Close();
            return compras;

        }

        public static int comprar() {
            SqlConnection connection = new SqlConnection(Connection.getStringConnection());
            SqlCommand comm = connection.CreateCommand();
            comm.CommandText = "INSERT INTO EL_REJUNTE.Compra (compra_fecha, compra_cantidad, compra_cliente_id, compra_facturada) " +
                                "VALUES ( GETDATE(), 1 , " + DBHelper.clienteGetId(VariablesGlobales.usuario.id) + ", 0 ); SELECT SCOPE_IDENTITY()";
            comm.Connection = connection;
            comm.Connection.Open();
            int rows = Convert.ToInt32(comm.ExecuteScalar());
            comm.Connection.Close();
            connection.Close();
            return rows;
        }

        public static Boolean altaUbicacion_Compra(int id_publi, int id_compra) {
            SqlConnection connection = new SqlConnection(Connection.getStringConnection());
            SqlCommand comm = connection.CreateCommand();
            comm.CommandText = "INSERT INTO EL_REJUNTE.Ubicacion_Compra (ubica_id, compra_id) " +
                                "VALUES ( (SELECT TOP 1 u.ubica_id FROM EL_REJUNTE.Ubicacion u, EL_REJUNTE.Ubicacion_Publicacion up, EL_REJUNTE.Publicacion p WHERE u.ubica_id = up.ubica_id AND up.publi_id = " + id_publi + "), " + id_compra + ")";
            comm.Connection = connection;
            comm.Connection.Open();
            int rows = comm.ExecuteNonQuery();
            comm.Connection.Close();
            connection.Close();
            return rows > 0;
        }

        public static List<CompraNoFacturada> comprasNoFacturadas() {

            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            conn.Open();
            string SQL = "SELECT CONCAT(cl.clie_nombre, ' ', cl.clie_apellido) AS FullName, cl.clie_documento, c.compra_fecha, c.compra_cantidad, u.ubica_tipo_descripcion, u.ubica_precio " +
                         "FROM EL_REJUNTE.Compra c, EL_REJUNTE.Ubicacion u, EL_REJUNTE.Ubicacion_Compra uc, EL_REJUNTE.Cliente cl " +
                         "WHERE c.compra_cliente_id = cl.clie_id AND " +
                               "uc.compra_id = c.compra_id AND " +
	                           "uc.ubica_id = u.ubica_id AND " +
	                           "c.compra_facturada = 0";
            SqlCommand command = new SqlCommand(SQL, conn);
            command.Connection = conn;
            command.CommandType = CommandType.Text;

            SqlDataReader reader = command.ExecuteReader() as SqlDataReader;
            List<CompraNoFacturada> compras_no_facturadas = new List<CompraNoFacturada>();

            if (reader.HasRows) {
                while (reader.Read()) {
                    CompraNoFacturada comprs_no_facturada = new CompraNoFacturada();
                    comprs_no_facturada.fullName = reader["FullName"].ToString();
                    comprs_no_facturada.documento = reader["clie_documento"].ToString();
                    comprs_no_facturada.fecha = Convert.ToDateTime(reader["compra_fecha"]);
                    comprs_no_facturada.cantidad = Int32.Parse(reader["compra_cantidad"].ToString());
                    comprs_no_facturada.descripcion = reader["ubica_tipo_descripcion"].ToString();
                    comprs_no_facturada.precio = Int32.Parse(reader["ubica_precio"].ToString());
                    compras_no_facturadas.Add(comprs_no_facturada);
                }
            }

            conn.Close();
            return compras_no_facturadas;



        }
    }
}