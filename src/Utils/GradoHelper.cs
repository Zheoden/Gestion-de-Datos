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

        public static Boolean altaGrado(Grado grado) {

            SqlConnection connection = new SqlConnection(Connection.getStringConnection());
            SqlCommand comm = connection.CreateCommand();
            comm.CommandText = "INSERT INTO EL_REJUNTE.Grado (grado_prioridad, grado_comision, grado_porcentaje) " +
                                "VALUES ('" + grado.prioridad + "', " + grado.comision + ", " + grado.porcentaje + ")";
            comm.Connection = connection;
            comm.Connection.Open();
            int rows = comm.ExecuteNonQuery();
            comm.Connection.Close();
            connection.Close();
            return rows > 0;
        }

        public static Boolean gradoDontExist(string prioridad, int comision, int porcentaje) {

            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            conn.Open();
            string SQL = "SELECT 1 " +
                          "FROM EL_REJUNTE.Grado g " +
                          "WHERE g.grado_prioridad = '" + prioridad + "' AND g.grado_comision = " + comision + " AND g.grado_porcentaje = " + porcentaje;

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

        public static Grado getGrado(int id) {

            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            conn.Open();
            string SQL = "SELECT g.grado_id, g.grado_prioridad, g.grado_comision, g.grado_porcentaje " +
                          "FROM EL_REJUNTE.Grado g " +
                          "WHERE g.grado_id = " + id;

            SqlCommand command = new SqlCommand(SQL, conn);
            command.Connection = conn;
            command.CommandType = CommandType.Text;

            SqlDataReader reader = command.ExecuteReader() as SqlDataReader;
            Grado grado = new Grado();
            if (reader.HasRows) {
                while (reader.Read()) {
                    grado.id = Int32.Parse(reader["grado_id"].ToString());
                    grado.prioridad = reader["grado_prioridad"].ToString();
                    grado.comision = Int32.Parse(reader["grado_comision"].ToString());
                    grado.porcentaje = Int32.Parse(reader["grado_porcentaje"].ToString());
                }
            }

            conn.Close();
            return grado;
        }

        public static Boolean modificarGrado(Grado grado) {

            SqlConnection connection = new SqlConnection(Connection.getStringConnection());
            SqlCommand comm = connection.CreateCommand();
            comm.CommandText = "UPDATE EL_REJUNTE.Grado " +
                               "SET grado_prioridad = '" + grado.prioridad + "', grado_comision = " + grado.comision + ", grado_porcentaje = " + grado.porcentaje + " " +
                               "WHERE grado_id = " + grado.id;
            comm.Connection = connection;
            comm.Connection.Open();
            int rows = comm.ExecuteNonQuery();
            comm.Connection.Close();
            connection.Close();
            return rows > 0;
        }

        public static Boolean bajaGrado(int id) {

            SqlConnection connection = new SqlConnection(Connection.getStringConnection());
            SqlCommand comm = connection.CreateCommand();
            comm.CommandText = "DELETE FROM EL_REJUNTE.Grado " +
                               "WHERE grado_id = " + id;
            comm.Connection = connection;
            comm.Connection.Open();
            int rows = comm.ExecuteNonQuery();
            comm.Connection.Close();
            connection.Close();
            return rows > 0;
        }

    }
}