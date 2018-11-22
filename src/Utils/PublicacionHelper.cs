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

        public static Boolean altaPublicacion(Publicacion publicacion) {
            SqlConnection connection = new SqlConnection(Connection.getStringConnection());
            SqlCommand comm = connection.CreateCommand();
            comm.CommandText = "INSERT INTO EL_REJUNTE.Publicacion (publi_descripcion , publi_estado_id, publi_fecha_inicio, publi_fecha_evento, publi_codigo, publi_rubro_id, publi_usuario_id, publi_espectaculo_id, publi_grado_id, publi_stock) " +
                                "VALUES ( '" + publicacion.descripcion + "', " + publicacion.estado.id + ", GETDATE(), '" + publicacion.fecha_evento.ToString("yyyy-MM-dd HH:mm:ss") + "', " +
                                publicacion.codigo + ", null, " + publicacion.user.id + ", (SELECT espec_id FROM EL_REJUNTE.Espectaculo WHERE espec_descripcion = '" + publicacion.espectaculo.descripcion + "' AND espec_fecha_venc = '" + publicacion.espectaculo.fecha_venc.ToString("yyyy-MM-dd HH:mm:ss") + "'), " + publicacion.grado.id + ", " + publicacion.stock + ")";
            comm.Connection = connection;
            comm.Connection.Open();
            int rows = comm.ExecuteNonQuery();
            comm.Connection.Close();
            connection.Close();
            return rows > 0;
        }

    }
}