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

        public static Boolean altaDeTarjeta(Tarjeta tarjeta) {
            if (verificarTarjetaDontExist(tarjeta)) {
                SqlConnection conn = new SqlConnection(Connection.getStringConnection());
                SqlCommand command = conn.CreateCommand();
                command.CommandText = "INSERT INTO EL_REJUNTE.Tarjeta (tarj_numero, tarj_titular, tarj_vencimiento, tarj_tipo, tarj_cod_seguridad) " +
                                      "VALUES ('" + tarjeta.numero + "', '" + tarjeta.titular + "', '" + tarjeta.vencimiento + "', '" + tarjeta.tipo + "', '" + tarjeta.cod_seguridad + "')";
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

        public static Boolean asociarTarjeta(Tarjeta tarjeta) {
            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            SqlCommand command = conn.CreateCommand();
            command.CommandText = "UPDATE EL_REJUNTE.Cliente " +
                                  "SET clie_tarjeta_id = " + DBHelper.tarjetaGetID(tarjeta) + " " +
                                  "WHERE clie_id = " + DBHelper.clienteGetId(VariablesGlobales.usuario.id);
            command.Connection = conn;
            command.Connection.Open();
            int rows = command.ExecuteNonQuery();
            command.Connection.Close();
            conn.Close();
            return rows > 0;
        }

        public static Boolean verificarTarjetaDontExist(Tarjeta tarjeta) {

            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            conn.Open();
            string SQL = "SELECT 1 " +
                         "FROM EL_REJUNTE.Tarjeta " +
                         "WHERE tarj_numero = '" + tarjeta.numero + "' AND " +
                         "tarj_cod_seguridad = '" + tarjeta.cod_seguridad + "' AND " +
                         "tarj_vencimiento = '" + tarjeta.vencimiento + "' AND " +
                         "tarj_titular = '" + tarjeta.titular + "' AND " +
                         "tarj_tipo = '" + tarjeta.tipo + "'";

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

        public static int tarjetaGetID(Tarjeta tarjeta) {

            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            conn.Open();
            string SQL = "SELECT tarj_id " +
                         "FROM EL_REJUNTE.Tarjeta " +
                         "WHERE tarj_numero = '" + tarjeta.numero + "' AND " +
                         "tarj_cod_seguridad = '" + tarjeta.cod_seguridad + "' AND " +
                         "tarj_vencimiento = '" + tarjeta.vencimiento + "' AND " +
                         "tarj_titular = '" + tarjeta.titular + "' AND " +
                         "tarj_tipo = '" + tarjeta.tipo + "'";

            SqlCommand command = new SqlCommand(SQL, conn);
            command.Connection = conn;
            command.CommandType = CommandType.Text;

            SqlDataReader reader = command.ExecuteReader() as SqlDataReader;

            if (reader.HasRows) {
                reader.Read();
                return Convert.ToInt32(reader["tarj_id"]);
            }

            conn.Close();
            return 0;
        }

    }
}