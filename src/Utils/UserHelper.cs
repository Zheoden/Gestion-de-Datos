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

        public static Boolean bloquear(string username) {
            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            SqlCommand command = conn.CreateCommand();
            command.CommandText = "UPDATE EL_REJUNTE.Usuario " +
                         "SET usuario_bloqueado = 0 " +
                         "WHERE usuario_id = (SELECT u.usuario_id FROM EL_REJUNTE.Usuario u WHERE UPPER(u.usuario_username) = UPPER('" + username + "'))";
            command.Connection = conn;
            command.Connection.Open();
            int rows = command.ExecuteNonQuery();
            command.Connection.Close();
            conn.Close();

            return rows > 0;
        }

        public static Boolean addFailLogin(string username) {
            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            SqlCommand command = conn.CreateCommand();
            command.CommandText = "UPDATE EL_REJUNTE.Usuario " +
                         "SET usuario_cant_logeo_error = (SELECT u.usuario_cant_logeo_error + 1 FROM EL_REJUNTE.Usuario u WHERE UPPER(u.usuario_username) = UPPER('" + username + "'))" +
                         "WHERE usuario_id = (SELECT u.usuario_id FROM EL_REJUNTE.Usuario u WHERE UPPER(u.usuario_username) = UPPER('" + username + "'))";
            command.Connection = conn;
            command.Connection.Open();
            int rows = command.ExecuteNonQuery();
            command.Connection.Close();
            conn.Close();
            return rows > 0;
        }

        public static Boolean cleanFailLogin(string username) {
            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            SqlCommand command = conn.CreateCommand();
            command.CommandText = "UPDATE EL_REJUNTE.Usuario " +
                         "SET usuario_cant_logeo_error = 0" +
                         "WHERE usuario_id = (SELECT u.usuario_id FROM EL_REJUNTE.Usuario u WHERE UPPER(u.usuario_username) = UPPER('" + username + "'))";
            command.Connection = conn;
            command.Connection.Open();
            int rows = command.ExecuteNonQuery();
            command.Connection.Close();
            conn.Close();
            return rows > 0;
        }

        public static Boolean existUser(string username) {
            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            conn.Open();
            string SQL = "SELECT u.usuario_id " +
                          "FROM EL_REJUNTE.Usuario u " +
                          "WHERE UPPER(u.usuario_username) = UPPER('" + username + "')";
            SqlCommand command = new SqlCommand(SQL, conn);
            command.Connection = conn;
            command.CommandType = CommandType.Text;

            SqlDataReader reader = command.ExecuteReader() as SqlDataReader;

            if (reader.HasRows) {
                while (reader.Read()) {
                    return reader["usuario_id"].ToString() != null;
                }
            }

            conn.Close();
            return false;
        }

        public static Boolean usuarioBloqueado(string username) {
            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            conn.Open();
            string SQL = "SELECT u.usuario_id " +
                          "FROM EL_REJUNTE.Usuario u " +
                          "WHERE UPPER(u.usuario_username) = UPPER('" + username + "') AND " +
                                "u.usuario_bloqueado = 1";
            SqlCommand command = new SqlCommand(SQL, conn);
            command.Connection = conn;
            command.CommandType = CommandType.Text;

            SqlDataReader reader = command.ExecuteReader() as SqlDataReader;

            if (reader.HasRows) {
                while (reader.Read()) {
                    return reader["usuario_id"].ToString() != null;
                }
            }

            conn.Close();
            return false;
        }

        public static Boolean validLogin(string username, string password) {
            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            conn.Open();
            string SQL = "SELECT u.usuario_id " +
                          "FROM EL_REJUNTE.Usuario u " +
                          "WHERE UPPER(u.usuario_username) = UPPER('" + username + "') AND " +
                                "UPPER(u.usuario_password) = UPPER('" + Encrypt.Sha256(password) + "')";
            SqlCommand command = new SqlCommand(SQL, conn);
            command.Connection = conn;
            command.CommandType = CommandType.Text;

            SqlDataReader reader = command.ExecuteReader() as SqlDataReader;

            if (reader.HasRows) {
                while (reader.Read()) {
                    return reader["usuario_id"].ToString() != null;
                }
            }

            conn.Close();
            return false;
        }

        public static Usuario getUserData(string username) {
            if (existUser(username)) {
                SqlConnection conn = new SqlConnection(Connection.getStringConnection());
                conn.Open();
                string SQL = "SELECT u.usuario_id, u.usuario_username, u.usuario_password, u.usuario_habilitado, u.usuario_bloqueado, u.usuario_cant_logeo_error, u.usuario_tipo, r.rol_id, r.rol_nombre, r.rol_habilitado " +
                              "FROM EL_REJUNTE.Usuario u, EL_REJUNTE.Rol_Usuario ru, EL_REJUNTE.Rol r " +
                              "WHERE ru.usuario_id = u.usuario_id AND " +
                                    "ru.rol_id = r.rol_id AND " +
                                    "r.rol_habilitado = 1 AND " +
                                    "UPPER(u.usuario_username) = UPPER('" + username + "')";
                SqlCommand command = new SqlCommand(SQL, conn);
                command.Connection = conn;
                command.CommandType = CommandType.Text;

                SqlDataReader reader = command.ExecuteReader() as SqlDataReader;
                Usuario user = new Usuario();
                user.funcionalidades = new List<Funcionalidad>();
                user.roles = new List<Rol>();

                if (reader.HasRows) {
                    while (reader.Read()) {
                        user.id = Int32.Parse(reader["usuario_id"].ToString());
                        user.username = reader["usuario_username"].ToString();
                        user.password = reader["usuario_password"].ToString();
                        user.habilitado = Convert.ToBoolean(reader["usuario_habilitado"].ToString());
                        user.bloqueado = Convert.ToBoolean(reader["usuario_bloqueado"].ToString());
                        user.cant_logeo_error = Int32.Parse(reader["usuario_cant_logeo_error"].ToString());
                        user.tipo = reader["usuario_tipo"].ToString();

                        Rol rol = new Rol();

                        rol.id = Int32.Parse(reader["rol_id"].ToString());
                        rol.nombre = reader["rol_nombre"].ToString();
                        rol.habilitado = Convert.ToBoolean(reader["rol_habilitado"].ToString());

                        if (user.roles.All(element => element.id != rol.id)) {
                            user.roles.Add(rol);
                        }
                    }
                }

                conn.Close();
                return user;
            }
            else {
                return null;
            }
        }

        public static Boolean altaUsuario(Usuario usuario)
        {
            SqlConnection connection = new SqlConnection(Connection.getStringConnection());
            SqlCommand comm = connection.CreateCommand();
            comm.CommandText = "INSERT INTO EL_REJUNTE.Usuario (usuario_username, usuario_password, usuario_habilitado, usuario_bloqueado, usuario_cant_logeo_error, usuario_tipo) " +
                                "VALUES ('" + usuario.username + "', '" + usuario.password + "', TRUE , FALSE , 0 , '" + usuario.roles[0].nombre + "')";
            comm.Connection = connection;
            comm.Connection.Open();
            int rows = comm.ExecuteNonQuery();
            comm.Connection.Close();
            connection.Close();
            return rows > 0;
        }

        public static Usuario getUserFuncionalidades(Usuario user, string rol) {

            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            conn.Open();
            string SQL = "SELECT f.func_id, f.func_descripcion " +
                          "FROM EL_REJUNTE.Usuario u, EL_REJUNTE.Rol_Usuario ru, EL_REJUNTE.Rol r, EL_REJUNTE.Func_Rol fr, EL_REJUNTE.Funcionalidad f " +
                          "WHERE ru.usuario_id = " + user.id + " AND " +
                                "ru.rol_id = r.rol_id AND " +
                                "r.rol_nombre = '" + rol + "' AND " +
                                "r.rol_habilitado = 1 AND " +
                                "fr.rol_id = r.rol_id AND " +
                                "fr.func_id = f.func_id";
            SqlCommand command = new SqlCommand(SQL, conn);
            command.Connection = conn;
            command.CommandType = CommandType.Text;

            SqlDataReader reader = command.ExecuteReader() as SqlDataReader;
            user.funcionalidades = new List<Funcionalidad>();

            if (reader.HasRows) {
                while (reader.Read()) {

                    Funcionalidad funcionalidad = new Funcionalidad();

                    funcionalidad.id = Int32.Parse(reader["func_id"].ToString());
                    funcionalidad.descripcion = reader["func_descripcion"].ToString();

                    if (user.funcionalidades.All(element => element.id != funcionalidad.id)) {
                        user.funcionalidades.Add(funcionalidad);
                    }
                }
            }

            conn.Close();
            return user;
        }

    }
}