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

        public static int publicacionGetNextCod() {

            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            conn.Open();
            string SQL = "SELECT MAX(publi_codigo) as 'publi_codigo' " +
                          "FROM EL_REJUNTE.Publicacion ";

            SqlCommand command = new SqlCommand(SQL, conn);
            command.Connection = conn;
            command.CommandType = CommandType.Text;

            SqlDataReader reader = command.ExecuteReader() as SqlDataReader;
            int codigo = 1;
            if (reader.HasRows) {
                while (reader.Read()) {
                    codigo += Int32.Parse(reader["publi_codigo"].ToString());
                }
            }

            conn.Close();
            return codigo;
        }

        public static int altaPublicacion(Publicacion publicacion) {
            SqlConnection connection = new SqlConnection(Connection.getStringConnection());
            SqlCommand comm = connection.CreateCommand();
            comm.CommandText = "INSERT INTO EL_REJUNTE.Publicacion (publi_descripcion , publi_estado_id, publi_fecha_inicio, publi_fecha_evento, publi_codigo, publi_rubro_id, publi_usuario_id, publi_espectaculo_id, publi_grado_id, publi_stock) " +
                                "VALUES ( '" + publicacion.descripcion + "', " + publicacion.estado.id + ", '" + VariablesGlobales.FechaHoraSistemaString + "', '" + publicacion.fecha_evento.ToString("yyyy-MM-dd HH:mm:ss") + "', " +
                                publicacion.codigo + ", " + publicacion.rubro.id + ", " + publicacion.user.id + ", (SELECT espec_id FROM EL_REJUNTE.Espectaculo WHERE espec_descripcion = '" + publicacion.espectaculo.descripcion + "' AND espec_fecha_venc = '" + publicacion.espectaculo.fecha_venc.ToString("yyyy-MM-dd HH:mm:ss") + "'), " + publicacion.grado.id + ", " + publicacion.stock + "); SELECT SCOPE_IDENTITY()";
            comm.Connection = connection;
            comm.Connection.Open();
            int rows = Convert.ToInt32(comm.ExecuteScalar());
            comm.Connection.Close();
            connection.Close();
            return rows;
        }

        public static Publicacion publicacionGetData(int id) {

            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            conn.Open();
            string SQL = "SELECT DISTINCT p.publi_descripcion, p.publi_stock, p.publi_fecha_evento, r.rubro_descripcion, d.dire_id, d.dire_calle, d.dire_numero, d.dire_piso, d.dire_depto, d.dire_localidad, d.dire_codigo_postal , g.grado_comision, g.grado_prioridad, g.grado_habilitado, u.ubica_precio " +
                         "FROM EL_REJUNTE.Publicacion p, EL_REJUNTE.Estado e, EL_REJUNTE.Rubro r, EL_REJUNTE.Grado g, EL_REJUNTE.Espectaculo es, EL_REJUNTE.Direccion d, EL_REJUNTE.Ubicacion_Publicacion up, EL_REJUNTE.Ubicacion u " +
                         "WHERE p.publi_id = " + id + " AND " +
                         "p.publi_estado_id = e.estado_id AND " +
                         "e.estado_id = 1 AND " +
                         "p.publi_rubro_id = r.rubro_id AND " +
                         "p.publi_grado_id = g.grado_id AND " +
                         "p.publi_espectaculo_id = es.espec_id AND " +
                         "es.espec_direccion_id = d.dire_id AND " +
                         "up.publi_id = " + id + " AND " +
                         "up.ubica_id = u.ubica_id ";

            SqlCommand command = new SqlCommand(SQL, conn);
            command.Connection = conn;
            command.CommandType = CommandType.Text;

            SqlDataReader reader = command.ExecuteReader() as SqlDataReader;

            Publicacion publi = new Publicacion();

            if (reader.HasRows) {
                while (reader.Read()) {
                    publi.rubro = new Rubro();
                    publi.descripcion = reader["publi_descripcion"].ToString();
                    publi.stock = Int32.Parse(reader["publi_stock"].ToString());
                    publi.fecha_evento = Convert.ToDateTime(reader["publi_fecha_evento"].ToString());
                    publi.rubro.descripcion = reader["rubro_descripcion"].ToString();
                    publi.precio = Int32.Parse(reader["ubica_precio"].ToString());

                    Direccion dire = new Direccion();

                    dire.id = Int32.Parse(reader["dire_id"].ToString());
                    dire.calle = reader["dire_calle"].ToString();
                    dire.numero = reader["dire_numero"].ToString();
                    dire.piso = reader["dire_piso"].ToString();
                    dire.depto = reader["dire_depto"].ToString();
                    dire.localidad = reader["dire_localidad"].ToString();
                    dire.codigo_postal = reader["dire_codigo_postal"].ToString();
                    publi.espectaculo = new Espectaculo();
                    publi.espectaculo.direccion = dire;

                    Grado grado = new Grado();
                    grado.prioridad = reader["grado_prioridad"].ToString();
                    grado.comision = Int32.Parse(reader["grado_comision"].ToString());
                    grado.habilitado = Convert.ToBoolean(reader["grado_habilitado"].ToString());

                    publi.grado = grado;
                }
            }

            conn.Close();
            return publi;
        }

        public static int publicacionCodigo(int id) {

            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            conn.Open();
            string SQL = "SELECT DISTINCT p.publi_codigo " +
                         "FROM EL_REJUNTE.Publicacion p " +
                         "WHERE p.publi_id = " + id;

            SqlCommand command = new SqlCommand(SQL, conn);
            command.Connection = conn;
            command.CommandType = CommandType.Text;

            SqlDataReader reader = command.ExecuteReader() as SqlDataReader;

            Publicacion publi = new Publicacion();

            if (reader.HasRows) {
                while (reader.Read()) {

                    return Int32.Parse(reader["publi_codigo"].ToString());
                }
            }

            conn.Close();
            return 0;
        }

        public static int publicacionGetID(Publicacion publicacion) {

            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            conn.Open();
            string SQL = "SELECT p.publi_id " +
                         "FROM EL_REJUNTE.Publicacion p, EL_REJUNTE.Rubro r " +
                         "WHERE p.publi_descripcion = '" + publicacion.descripcion + "' AND " +
                               "p.publi_fecha_inicio = '" + publicacion.fecha_inicio.ToString("yyyy-MM-dd HH:mm:ss.fff") + "' AND " +
                               "p.publi_fecha_evento =  '" + publicacion.fecha_evento.ToString("yyyy-MM-dd HH:mm:ss.fff") + "' AND " +
                               "p.publi_stock =  " + publicacion.stock + " AND " +
                               "p.publi_rubro_id = r.rubro_id AND " +
                               "r.rubro_descripcion =  '" + publicacion.rubro.descripcion + "'";

            SqlCommand command = new SqlCommand(SQL, conn);
            command.Connection = conn;
            command.CommandType = CommandType.Text;

            SqlDataReader reader = command.ExecuteReader() as SqlDataReader;

            Publicacion publi = new Publicacion();

            if (reader.HasRows) {
                while (reader.Read()) {

                    return Int32.Parse(reader["publi_id"].ToString());
                }
            }

            conn.Close();
            return 0;
        }

        public static Boolean publicacionModificar(Publicacion publi) {

            SqlConnection connection = new SqlConnection(Connection.getStringConnection());
            SqlCommand comm = connection.CreateCommand();
            comm.CommandText = "UPDATE EL_REJUNTE.Publicacion " +
                               "SET publi_descripcion = '" + publi.descripcion + "', publi_estado_id = " + publi.estado.id + ", publi_fecha_evento= '" + publi.fecha_evento.ToString("yyyy-MM-dd HH:mm:ss") +
                               "', publi_rubro_id= " + publi.rubro.id + ", publi_grado_id= " + publi.grado.id + ", publi_stock= " + publi.stock + " " +
                               "WHERE publi_id = " + publi.id;
            comm.Connection = connection;
            comm.Connection.Open();
            int rows = comm.ExecuteNonQuery();
            comm.Connection.Close();
            connection.Close();
            return rows > 0;
        }

        public static Boolean altaUbicacion_Publicacion(Ubicacion_Publicacion publicacion) {
            int id_publicacion = DBHelper.altaPublicacion(publicacion.publicacion);
            int id_ubicacion = DBHelper.ubicacionAltaRetornaID(publicacion.ubicacion);
            SqlConnection connection = new SqlConnection(Connection.getStringConnection());
            SqlCommand comm = connection.CreateCommand();
            comm.CommandText = "INSERT INTO EL_REJUNTE.Ubicacion_Publicacion (ubica_id, publi_id, ubica_disponible) " +
                                "VALUES ( " + id_ubicacion + ", " + id_publicacion + ", " + Convert.ToInt32(publicacion.disponible) + " )";
            comm.Connection = connection;
            comm.Connection.Open();
            int rows = comm.ExecuteNonQuery();
            comm.Connection.Close();
            connection.Close();
            return rows > 0;
        }

        public static Boolean publicacionModificarStock(int publi_id, int publi_stock) {

            SqlConnection connection = new SqlConnection(Connection.getStringConnection());
            SqlCommand comm = connection.CreateCommand();
            comm.CommandText = "UPDATE EL_REJUNTE.Publicacion " +
                               "SET publi_stock= " + publi_stock + " " +
                               "WHERE publi_id = " + publi_id;
            comm.Connection = connection;
            comm.Connection.Open();
            int rows = comm.ExecuteNonQuery();
            comm.Connection.Close();
            connection.Close();
            return rows > 0;
        }

    }
}