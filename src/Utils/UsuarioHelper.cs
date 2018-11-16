using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using PalcoNet.Objetos;

namespace PalcoNet.Utils {

    public class UsuarioHelper {

        public static void search(string name, string rol, string hotel, DataGridView dgvUser) {
            SqlCommand command = new SqlCommand();
            command.CommandText = "LA_MAYORIA.sp_user_search";

            command.Parameters.Add(new SqlParameter("@p_user_name", SqlDbType.VarChar, 255));
            if (name == string.Empty)
                command.Parameters["@p_user_name"].Value = null;
            else
                command.Parameters["@p_user_name"].Value = name;

            command.Parameters.Add(new SqlParameter("@p_id_rol", SqlDbType.Int));
            if (rol == string.Empty)
                command.Parameters["@p_id_rol"].Value = null;
            else
                command.Parameters["@p_id_rol"].Value = Convert.ToInt16(rol);

            command.Parameters.Add(new SqlParameter("@p_id_hotel", SqlDbType.Int));
            if (hotel == string.Empty)
                command.Parameters["@p_id_hotel"].Value = null;
            else
                command.Parameters["@p_id_hotel"].Value = Convert.ToInt16(hotel);

            DataGridViewHelper.fill(command, dgvUser);
        }
        /*
                public static Rol getRolByUserHotel(string user, int hotel)
                {
                    Rol rol = new Rol();

                    SqlConnection conn = Connection.getConnection();
                    SqlCommand command = new SqlCommand();
                    command.Connection = conn;
                    command.CommandText = "LA_MAYORIA.sp_user_search_rol_hotel_by_user";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@p_user_name", SqlDbType.VarChar, 255));
                    if (user == string.Empty)
                        command.Parameters["@p_user_name"].Value = null;
                    else
                        command.Parameters["@p_user_name"].Value = user;

                    command.Parameters.Add(new SqlParameter("@p_id_hotel", SqlDbType.Int));
                    command.Parameters["@p_id_hotel"].Value = hotel;

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        rol.id = Convert.ToInt32(reader["IdRol"]);
                        rol.description = Convert.ToString(reader["Descripcion"]);
                    }

                    Connection.close(conn);

                    return rol;
                }*/
        public static void enable(string username, Int32 idHotel, Boolean enable) {
            SqlCommand command = new SqlCommand();
            command.CommandText = "LA_MAYORIA.sp_user_enable_disable";

            command.Parameters.Add(new SqlParameter("@p_user_name", SqlDbType.VarChar, 255));
            command.Parameters["@p_user_name"].Value = username;

            command.Parameters.Add(new SqlParameter("@p_id_hotel", SqlDbType.Int));
            command.Parameters["@p_id_hotel"].Value = idHotel;

            command.Parameters.Add(new SqlParameter("@p_enable_disable", SqlDbType.Int));
            if (enable) {
                command.Parameters["@p_enable_disable"].Value = 1;
            }
            else {
                command.Parameters["@p_enable_disable"].Value = 0;
            }

            ProcedureHelper.execute(command, "Habilitar o deshabilitar usuario", false);
        }

        public static void bloquear(string username) {
            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            SqlCommand command = conn.CreateCommand();
            command.CommandText = "UPDATE EL_REJUNTE.Usuario " +
                         "SET usuario_habilitado = 0 " +
                         "WHERE usuario_id = (SELECT u.usuario_id FROM EL_REJUNTE.Usuario u WHERE UPPER(u.usuario_username) = UPPER('" + username + "'))";
            command.Connection = conn;
            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
            conn.Close();
        }

        public static void addFailLogin(string username) {
            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            SqlCommand command = conn.CreateCommand();
            command.CommandText = "UPDATE EL_REJUNTE.Usuario " +
                         "SET usuario_cant_logeo_error = (SELECT u.usuario_cant_logeo_error + 1 FROM EL_REJUNTE.Usuario u WHERE UPPER(u.usuario_username) = UPPER('" + username + "'))" +
                         "WHERE usuario_id = (SELECT u.usuario_id FROM EL_REJUNTE.Usuario u WHERE UPPER(u.usuario_username) = UPPER('" + username + "'))";
            command.Connection = conn;
            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
            conn.Close();
        }

        public static void cleanFailLogin(string username) {
            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            SqlCommand command = conn.CreateCommand();
            command.CommandText = "UPDATE EL_REJUNTE.Usuario " +
                         "SET usuario_cant_logeo_error = 0" +
                         "WHERE usuario_id = (SELECT u.usuario_id FROM EL_REJUNTE.Usuario u WHERE UPPER(u.usuario_username) = UPPER('" + username + "'))";
            command.Connection = conn;
            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
            conn.Close();
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

        public static Boolean usuarioHabilitado(string username) {
            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            conn.Open();
            string SQL = "SELECT u.usuario_id " +
                          "FROM EL_REJUNTE.Usuario u " +
                          "WHERE UPPER(u.usuario_username) = UPPER('" + username + "') AND " +
                                "u.usuario_habilitado = 1";
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
                string SQL = "SELECT u.usuario_id, u.usuario_username, u.usuario_password, u.usuario_habilitado, u.usuario_cant_logeo_error, u.usuario_tipo, r.rol_id, r.rol_nombre, r.rol_habilitado " +
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
                        user.cant_logeo_error = Int32.Parse(reader["usuario_cant_logeo_error"].ToString());
                        user.tipo = reader["usuario_tipo"].ToString();

                        Rol rol = new Rol();

                        rol.id = Int32.Parse(reader["rol_id"].ToString());
                        rol.nombre = reader["rol_nombre"].ToString();
                        rol.habilitado = Convert.ToBoolean(reader["rol_habilitado"].ToString());

                        if (user.roles.All(element => element.id != rol.id)) {
                            user.roles.Add(rol);
                        }

                        /*
                        Funcionalidad funcionalidad = new Funcionalidad();

                        funcionalidad.id = Int32.Parse(reader["func_id"].ToString());
                        funcionalidad.descripcion = reader["func_descripcion"].ToString();

                        if (user.funcionalidades.All(element => element.id != funcionalidad.id)) {
                            user.funcionalidades.Add(funcionalidad);
                        }*/
                    }
                }

                conn.Close();
                return user;
            }
            else {
                return null;
            }
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

        /*
        public static void save(Usuario userData, Int32 hotel, Int32 rol, String password)
        {
            SqlCommand sp_save_or_update_user = new SqlCommand();
            sp_save_or_update_user.CommandType = CommandType.StoredProcedure;
            sp_save_or_update_user.CommandText = "LA_MAYORIA.sp_user_save_update";

            sp_save_or_update_user.Parameters.AddWithValue("@p_user_name", userData.username);
            sp_save_or_update_user.Parameters.AddWithValue("@p_name_lastName", userData.nameLastname);
            sp_save_or_update_user.Parameters.AddWithValue("@p_id_type_document", userData.typeDocument);
            sp_save_or_update_user.Parameters.AddWithValue("@p_document_number", userData.documentNumber);
            sp_save_or_update_user.Parameters.AddWithValue("@p_mail", userData.mail);
            sp_save_or_update_user.Parameters.AddWithValue("@p_telephone", userData.telephone);
            sp_save_or_update_user.Parameters.AddWithValue("@p_address", userData.address);
            sp_save_or_update_user.Parameters.AddWithValue("@p_birthdate", userData.birthDate);
        
            if (userData.enabled){
                sp_save_or_update_user.Parameters.AddWithValue("@p_enabled", 1);
            }else{
                sp_save_or_update_user.Parameters.AddWithValue("@p_enabled", 0);
            }

            sp_save_or_update_user.Parameters.AddWithValue("@p_id_hotel", hotel);
            sp_save_or_update_user.Parameters.AddWithValue("@p_id_rol", rol);
            if (password != null)
                sp_save_or_update_user.Parameters.AddWithValue("@p_password", Encrypt.Sha256(password));

            ProcedureHelper.execute(sp_save_or_update_user, "save or update user data", false);
        }*/
    }
}
