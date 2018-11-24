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

        public static Boolean altaPublicacion(Ubicacion_Publicacion publicacion) {
            SqlConnection connection = new SqlConnection(Connection.getStringConnection());
            SqlCommand comm = connection.CreateCommand();
            comm.CommandText = "INSERT INTO EL_REJUNTE.Publicacion (publi_descripcion , publi_estado_id, publi_fecha_inicio, publi_fecha_evento, publi_codigo, publi_rubro_id, publi_usuario_id, publi_espectaculo_id, publi_grado_id, publi_stock) " +
                                "VALUES ( '" + publicacion.publicacion.descripcion + "', " + publicacion.publicacion.estado.id + ", GETDATE(), '" + publicacion.publicacion.fecha_evento.ToString("yyyy-MM-dd HH:mm:ss") + "', " +
                                publicacion.publicacion.codigo + ", " + publicacion.publicacion.rubro.id + ", " + publicacion.publicacion.user.id + ", (SELECT espec_id FROM EL_REJUNTE.Espectaculo WHERE espec_descripcion = '" + publicacion.publicacion.espectaculo.descripcion + "' AND espec_fecha_venc = '" + publicacion.publicacion.espectaculo.fecha_venc.ToString("yyyy-MM-dd HH:mm:ss") + "'), " + publicacion.publicacion.grado.id + ", " + publicacion.publicacion.stock + ")";
            comm.Connection = connection;
            comm.Connection.Open();
            int rows = comm.ExecuteNonQuery();
            comm.Connection.Close();
            connection.Close();
            return rows > 0 && DBHelper.ubicacionAlta(publicacion.ubicacion) ;//&& DBHelper.altaUbicacion_Publicacion(publicacion);
        }

        public static Publicacion publicacionGetData(int id) {

            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            conn.Open();
            string SQL = "SELECT DISTINCT p.publi_descripcion, p.publi_stock, p.publi_fecha_evento, r.rubro_descripcion, d.dire_id, d.dire_calle, d.dire_numero, d.dire_piso, d.dire_depto, d.dire_localidad, d.dire_codigo_postal , g.grado_comision, g.grado_prioridad, g.grado_habilitado " +
                         "FROM EL_REJUNTE.Publicacion p, EL_REJUNTE.Estado e, EL_REJUNTE.Rubro r, EL_REJUNTE.Grado g, EL_REJUNTE.Espectaculo es, EL_REJUNTE.Direccion d " +
                         "WHERE p.publi_id = " + id + " AND " +
                         "p.publi_estado_id = e.estado_id AND " +
                         "e.estado_id = 1 AND " +
                         "p.publi_rubro_id = r.rubro_id AND " +
                         "p.publi_grado_id = g.grado_id AND " +
                         "p.publi_espectaculo_id = es.espec_id AND " + 
                         "es.espec_direccion_id = d.dire_id";

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

        public static Boolean publicacionModificar(Cliente cliente) {

            SqlConnection connection = new SqlConnection(Connection.getStringConnection());
            SqlCommand comm = connection.CreateCommand();
            comm.CommandText = "UPDATE EL_REJUNTE.Cliente " +
                               "SET clie_nombre = '" + cliente.nombre + "', clie_apellido = '" + cliente.apellido + "', clie_tipo_documento= '" + cliente.tipo_documento + "', clie_documento= '" + cliente.documento + "', clie_cuil= '" + cliente.cuil + "', clie_email= '" + cliente.mail + "', clie_telefono= '" + cliente.telefono + "', clie_direccion_id = (SELECT TOP 1 dire_id FROM EL_REJUNTE.Direccion WHERE dire_calle = '" + cliente.dire.calle + "' AND dire_numero = '" + cliente.dire.numero + "' AND dire_piso = '" + cliente.dire.piso + "' AND dire_depto = '" + cliente.dire.depto + "' AND dire_localidad = '" + cliente.dire.localidad + "' AND dire_codigo_postal = '" + cliente.dire.codigo_postal + "') , clie_tarjeta_id = (SELECT TOP 1 tarj_id FROM EL_REJUNTE.Tarjeta WHERE tarj_numero = '" + cliente.tarjeta.numero + "' AND tarj_cod_seguridad = '" + cliente.tarjeta.cod_seguridad + "' AND tarj_vencimiento = '" + cliente.tarjeta.vencimiento + "' AND tarj_titular = '" + cliente.tarjeta.titular + "' AND tarj_tipo = '" + cliente.tarjeta.tipo + "') , clie_habilitado = " + Convert.ToInt32(cliente.habilitado) + " " +
                               "WHERE clie_id = " + cliente.id;
            comm.Connection = connection;
            comm.Connection.Open();
            int rows = comm.ExecuteNonQuery();
            comm.Connection.Close();
            connection.Close();
            return rows > 0;
        }

        public static Boolean altaUbicacion_Publicacion(Ubicacion_Publicacion publicacion) {
            SqlConnection connection = new SqlConnection(Connection.getStringConnection());
            SqlCommand comm = connection.CreateCommand();
            comm.CommandText = "INSERT INTO EL_REJUNTE.Publicacion (publi_descripcion , publi_estado_id, publi_fecha_inicio, publi_fecha_evento, publi_codigo, publi_rubro_id, publi_usuario_id, publi_espectaculo_id, publi_grado_id, publi_stock) " +
                                "VALUES ( '" + publicacion.publicacion.descripcion + "', " + publicacion.publicacion.estado.id + ", GETDATE(), '" + publicacion.publicacion.fecha_evento.ToString("yyyy-MM-dd HH:mm:ss") + "', " +
                                publicacion.publicacion.codigo + ", " + publicacion.publicacion.rubro.id + ", " + publicacion.publicacion.user.id + ", (SELECT espec_id FROM EL_REJUNTE.Espectaculo WHERE espec_descripcion = '" + publicacion.publicacion.espectaculo.descripcion + "' AND espec_fecha_venc = '" + publicacion.publicacion.espectaculo.fecha_venc.ToString("yyyy-MM-dd HH:mm:ss") + "'), " + publicacion.publicacion.grado.id + ", " + publicacion.publicacion.stock + ")";
            comm.Connection = connection;
            comm.Connection.Open();
            int rows = comm.ExecuteNonQuery();
            comm.Connection.Close();
            connection.Close();
            return rows > 0;
        }


    }
}