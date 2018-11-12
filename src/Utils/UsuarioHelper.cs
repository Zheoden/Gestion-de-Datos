using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using PalcoNet;

namespace PalcoNet.Utils
{
    public class UsuarioHelper
    {
        public static void search(string name, string rol, string hotel, DataGridView dgvUser)
        {
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

        public static void enable(string username, Int32 idHotel, Boolean enable)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "LA_MAYORIA.sp_user_enable_disable";

            command.Parameters.Add(new SqlParameter("@p_user_name", SqlDbType.VarChar, 255));
            command.Parameters["@p_user_name"].Value = username;

            command.Parameters.Add(new SqlParameter("@p_id_hotel", SqlDbType.Int));
            command.Parameters["@p_id_hotel"].Value = idHotel;

            command.Parameters.Add(new SqlParameter("@p_enable_disable", SqlDbType.Int));
            if (enable)
            {
                command.Parameters["@p_enable_disable"].Value = 1;
            }
            else
            {
                command.Parameters["@p_enable_disable"].Value = 0;
            }

            ProcedureHelper.execute(command, "Habilitar o deshabilitar usuario", false);
        }

        public static void cleanLogin(string username)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "LA_MAYORIA.sp_user_clean_login";

            command.Parameters.Add(new SqlParameter("@p_user_name", SqlDbType.VarChar, 255));
            command.Parameters["@p_user_name"].Value = username;

            ProcedureHelper.execute(command, "Limpiar intentos de login", false);
        }

        public static Boolean existUser(string user)
        {
            SqlCommand sp_check_user = new SqlCommand();
            sp_check_user.CommandText = "LA_MAYORIA.sp_login_check_valid_user";
            sp_check_user.Parameters.Add(new SqlParameter("@p_id", SqlDbType.VarChar));
            sp_check_user.Parameters["@p_id"].Value = user;

            var returnParameterIsValid = sp_check_user.Parameters.Add(new SqlParameter("@p_is_valid", SqlDbType.Bit));
            returnParameterIsValid.Direction = ParameterDirection.InputOutput;

            ProcedureHelper.execute(sp_check_user, "chequear usuario valido", false);

            int isValid = Convert.ToInt16(returnParameterIsValid.Value);

            if (isValid == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }













        public static Usuario getUserData(string username)
        {

            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            conn.Open();
            string SQL = "SELECT u.usuario_id, u.usuario_username, u.usuario_password, u.usuario_habilitado, u.usuario_cant_logeo_error, u.usuario_tipo_id, r.rol_nombre, r.rol_habilitado, f.func_descripcion " +
                          "FROM EL_REJUNTE.Usuario u, EL_REJUNTE.Rol_Usuario ru, EL_REJUNTE.Rol r, EL_REJUNTE.Func_Rol fr, EL_REJUNTE.Funcionalidad f " +
                          "WHERE ru.usuario_id = u.usuario_id AND " +
                                "ru.rol_id = r.rol_id AND " +
                                "fr.rol_id = r.rol_id AND " +
                                "fr.funci_id = f.funci_id AND " +
                                "u.usuario_username = " + username;
            SqlCommand command = new SqlCommand(SQL, conn);
            command.Connection = conn;
            command.CommandType = CommandType.Text;

            SqlDataReader reader = command.ExecuteReader() as SqlDataReader;
            Usuario user = new Usuario();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    MessageBox.Show(reader["usuario_id"].ToString());
                    MessageBox.Show(reader["usuario_username"].ToString());
                    MessageBox.Show(reader["usuario_password"].ToString());
                    MessageBox.Show(reader["usuario_habilitado"].ToString());
                    MessageBox.Show(reader["usuario_cant_logeo_error"].ToString());
                    MessageBox.Show(reader["usuario_tipo_id"].ToString());
                    MessageBox.Show(reader["rol_nombre"].ToString());
                    MessageBox.Show(reader["rol_habilitado"].ToString());
                    MessageBox.Show(reader["func_descripcion"].ToString());
                }
            }

            Connection.close(conn);

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
               }
         */
    }
}
