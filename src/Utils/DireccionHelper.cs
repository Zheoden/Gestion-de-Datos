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

        public static Boolean altaDeDireccion(Direccion direccion) {
            if (verificarDireccionDontExist(direccion)) {
                SqlConnection conn = new SqlConnection(Connection.getStringConnection());
                SqlCommand command = conn.CreateCommand();
                command.CommandText = "INSERT INTO EL_REJUNTE.Direccion (dire_calle, dire_numero, dire_piso, dire_depto, dire_localidad, dire_codigo_postal) " +
                                      "VALUES ('" + direccion.calle + "', '" + direccion.numero + "', '" + direccion.piso + "', '" + direccion.depto + "', '" + direccion.localidad + "', '" + direccion.codigo_postal + "')";
                command.Connection = conn;
                command.Connection.Open();
                int rows = command.ExecuteNonQuery();
                command.Connection.Close();
                conn.Close();
                return rows > 0;
            }
            else {
                return true;
            }
        }

        public static Boolean verificarDireccionDontExist(Direccion dire) {

            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            conn.Open();
            string SQL = "SELECT 1 " +
                         "FROM EL_REJUNTE.Direccion " +
                         "WHERE dire_calle = '" + dire.calle + "' AND " +
                         "dire_numero = '" + dire.numero + "' AND " +
                         "dire_piso = '" + dire.piso + "' AND " +
                         "dire_depto = '" + dire.depto + "' AND " +
                         "dire_localidad = '" + dire.localidad + "' AND " +
                         "dire_codigo_postal = '" + dire.codigo_postal + "'";

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

    }
}