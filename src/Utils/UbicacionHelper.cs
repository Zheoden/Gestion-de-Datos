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

        public static Boolean ubicacionAlta(Ubicacion ubica) {
            SqlConnection connection = new SqlConnection(Connection.getStringConnection());
            SqlCommand comm = connection.CreateCommand();
            comm.CommandText = "INSERT INTO EL_REJUNTE.Ubicacion (ubica_fila , ubica_asiento, ubica_sin_numerar, ubica_precio, ubica_tipo_codigo, ubica_tipo_descripcion) " +
                                "VALUES ( '" + ubica.fila + "', " + ubica.asiento + ", " + Convert.ToInt32(ubica.sin_numerar) + " , " + ubica.precio + ", " + ubica.tipo_codigo + ", '" + ubica.tipo_descripcion + "' ); SELECT SCOPE_IDENTITY()";

            comm.Connection = connection;
            comm.Connection.Open();
            int rows = Convert.ToInt32(comm.ExecuteScalar());
            comm.Connection.Close();
            connection.Close();
            return rows > 0;
        }

        public static int ubicacionAltaRetornaID(Ubicacion ubica) {
            SqlConnection connection = new SqlConnection(Connection.getStringConnection());
            SqlCommand comm = connection.CreateCommand();
            comm.CommandText = "INSERT INTO EL_REJUNTE.Ubicacion (ubica_fila , ubica_asiento, ubica_sin_numerar, ubica_precio, ubica_tipo_codigo, ubica_tipo_descripcion) " +
                                "VALUES ( '" + ubica.fila + "', " + ubica.asiento + ", " + Convert.ToInt32(ubica.sin_numerar) + " , " + ubica.precio + ", " + ubica.tipo_codigo + ", '" + ubica.tipo_descripcion + "' ); SELECT SCOPE_IDENTITY()";

            comm.Connection = connection;
            comm.Connection.Open();
            int rows = Convert.ToInt32(comm.ExecuteScalar());
            comm.Connection.Close();
            connection.Close();
            return rows;
        }

        public static Boolean ubicacionModificar(Ubicacion ubica) {
            SqlConnection connection = new SqlConnection(Connection.getStringConnection());
            SqlCommand comm = connection.CreateCommand();
            comm.CommandText = "UPDATE EL_REJUNTE.Ubicacion " +
                               "SET ubica_precio = " + ubica.precio + " " +
                               "WHERE ubica_tipo_codigo = " + ubica.tipo_codigo;
            comm.Connection = connection;
            comm.Connection.Open();
            int rows = comm.ExecuteNonQuery();
            comm.Connection.Close();
            connection.Close();
            return rows > 0;
        }

        public static List<Ubicacion> tiposPorEspectaculo(int id) {
            var rv = new List<Ubicacion>();

            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            conn.Open();
            string SQL = " select ubica_tipo_descripcion, ubica_tipo_codigo " +
                         " from EL_REJUNTE.Ubicacion u " +
                         " join EL_REJUNTE.Ubicacion_Publicacion up on u.ubica_id = up.ubica_id " +
                         " where up.publi_id = " + id +
                         " group by u.ubica_tipo_descripcion, ubica_tipo_codigo ";

            SqlCommand command = new SqlCommand(SQL, conn);
            command.Connection = conn;
            command.CommandType = CommandType.Text;

            SqlDataReader reader = command.ExecuteReader() as SqlDataReader;

            if (reader.HasRows) {
                while (reader.Read()) {
                    var ubicacion = new Ubicacion();
                    ubicacion.tipo_descripcion = reader["ubica_tipo_descripcion"].ToString();
                    ubicacion.tipo_codigo = Int32.Parse(reader["ubica_tipo_codigo"].ToString());
                    rv.Add(ubicacion);
                }
            }

            conn.Close();

            return rv;
        }

    }
}