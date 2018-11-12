using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace PalcoNet.Utils
{
    public class UsuarioDatosHelper
    {
        public static Usuario getUserData(string username)
        {

            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            conn.Open();
            string SQL = "SELECT u.usuario_id, u.usuario_username, u.usuario_password, u.usuario_habilitado, u.usuario_cant_logeo_error, u.usuario_tipo_id, r.rol_nombre, r.rol_habilitado, f.func_descripcion " +
                          "FROM EL_REJUNTE.Usuario u, EL_REJUNTE.Rol_Usuario ru, EL_REJUNTE.Rol r, EL_REJUNTE.Func_Rol fr, EL_REJUNTE.Funcionalidad f "+
                          "WHERE ru.usuario_id = u.usuario_id AND " +
                                "ru.rol_id = r.rol_id AND " +
                                "fr.rol_id = r.rol_id AND " +
                                "fr.funci_id = f.funci_id AND "+
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
