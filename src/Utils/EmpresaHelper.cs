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

        public static Boolean altaEmpresa(Empresa empresa) {

            SqlConnection connection = new SqlConnection(Connection.getStringConnection());
            SqlCommand comm = connection.CreateCommand();
            comm.CommandText = "INSERT INTO EL_REJUNTE.Empresa (empre_razon_social, empre_cuit, empre_fecha_creacion, empre_mail, empre_direccion_id , empre_telefono, empre_usuario_id) " +
                                "VALUES ('" + empresa.razon_social + "', '" + empresa.cuit + "', GETDATE() , '" + empresa.mail + "', (SELECT TOP 1 dire_id FROM EL_REJUNTE.Direccion WHERE dire_calle = '" + empresa.direccion.calle + "' AND dire_numero = '" + empresa.direccion.numero + "' AND dire_piso = '" + empresa.direccion.piso + "' AND dire_depto = '" + empresa.direccion.depto + "' AND dire_localidad = '" + empresa.direccion.localidad + "' AND dire_codigo_postal = '" + empresa.direccion.codigo_postal + "') , '" + empresa.telefono + "', null" +
                                ")";
            comm.Connection = connection;
            comm.Connection.Open();
            int rows = comm.ExecuteNonQuery();
            comm.Connection.Close();
            connection.Close();
            return rows > 0;
        }

        public static Boolean EmpresaDontExistCuit(string cuit) {

            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            conn.Open();
            string SQL = "SELECT 1 " +
                          "FROM EL_REJUNTE.Empresa " +
                          "WHERE empre_cuit = '" + cuit + "'";

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