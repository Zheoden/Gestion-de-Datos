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
            comm.CommandText = "INSERT INTO EL_REJUNTE.Grado (grado_prioridad, grado_comision, grado_habilitado) " +
                                "VALUES ('" + grado.prioridad + "', " + grado.comision + ", 1 )";
            comm.Connection = connection;
            comm.Connection.Open();
            int rows = comm.ExecuteNonQuery();
            comm.Connection.Close();
            connection.Close();
            return rows > 0;
        }

        public static Boolean gradoDontExist(string prioridad, int comision) {

            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            conn.Open();
            string SQL = "SELECT 1 " +
                          "FROM EL_REJUNTE.Grado g " +
                          "WHERE g.grado_prioridad = '" + prioridad + "' AND g.grado_comision = " + comision;

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
            string SQL = "SELECT g.grado_id, g.grado_prioridad, g.grado_comision, g.grado_habilitado " +
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
                    grado.habilitado = Convert.ToBoolean(reader["grado_habilitado"].ToString());
                }
            }

            conn.Close();
            return grado;
        }

        public static Grado getGrado(string prioridad, int comision) {

            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            conn.Open();
            string SQL = "SELECT g.grado_id, g.grado_prioridad, g.grado_comision, g.grado_habilitado " +
                          "FROM EL_REJUNTE.Grado g " +
                          "WHERE g.grado_prioridad = '" + prioridad + "' AND g.grado_comision = " + comision;

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
                    grado.habilitado = Convert.ToBoolean(reader["grado_habilitado"].ToString());
                }
            }

            conn.Close();
            return grado;
        }

        public static Boolean modificarGrado(Grado grado) {

            SqlConnection connection = new SqlConnection(Connection.getStringConnection());
            SqlCommand comm = connection.CreateCommand();
            comm.CommandText = "UPDATE EL_REJUNTE.Grado " +
                               "SET grado_prioridad = '" + grado.prioridad + "', grado_comision = " + grado.comision + ", grado_habilitado = " + Convert.ToInt32(grado.habilitado) + " " +
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
            comm.CommandText = "UPDATE EL_REJUNTE.Grado " +
                               "SET grado_habilitado = 0 " +
                               "WHERE grado_id = " + id;

            comm.Connection = connection;
            comm.Connection.Open();
            int rows = comm.ExecuteNonQuery();
            comm.Connection.Close();
            connection.Close();
            return rows > 0;
        }

        public static List<Grado> getGrados() {

            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            conn.Open();
            string SQL = "SELECT g.grado_id, g.grado_prioridad, g.grado_comision, g.grado_habilitado " +
                          "FROM EL_REJUNTE.Grado g ";

            SqlCommand command = new SqlCommand(SQL, conn);
            command.Connection = conn;
            command.CommandType = CommandType.Text;

            SqlDataReader reader = command.ExecuteReader() as SqlDataReader;
            List<Grado> grados = new List<Grado>();
            if (reader.HasRows) {
                while (reader.Read()) {
                    Grado grado = new Grado();
                    grado.id = Int32.Parse(reader["grado_id"].ToString());
                    grado.prioridad = reader["grado_prioridad"].ToString();
                    grado.comision = Int32.Parse(reader["grado_comision"].ToString());
                    grado.habilitado = Convert.ToBoolean(reader["grado_habilitado"].ToString());
                    grados.Add(grado);
                }
            }

            conn.Close();
            return grados;
        }

    }
}