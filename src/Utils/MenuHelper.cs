using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System;
using PalcoNet.Objetos;
namespace PalcoNet.Utils {

    public class MenuHelper {

        public static SortedList<int, Funcionalidad> getOptionMenu(int idRol) {
            SortedList<int, Funcionalidad> menuOptions = new SortedList<int, Funcionalidad>();

            SqlConnection conn = Connection.getConnection();

            string storedProcedureName = "LA_MAYORIA.sp_menu_list_functionality_by_user";
            SqlCommand command = new SqlCommand(storedProcedureName);
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@p_id_rol", idRol);

            SqlDataReader reader = command.ExecuteReader() as SqlDataReader;

            int position = 0;
            if (reader.HasRows) {
                while (reader.Read()) {
                    Funcionalidad menuOption = new Funcionalidad();
                    menuOption.descripcion = reader["Descripcion"].ToString();
                    menuOption.id = Convert.ToInt32(reader["Id_Funcionalidad"]);
                    menuOptions.Add(position, menuOption);
                    position++;
                }
            }

            Connection.close(conn);

            return menuOptions;
        }

        public static Menus getOpciones(string id) {
            Menus menu = new Menus();

            switch (id) {
                case "Abm Rol":
                    menu.carpeta = "Abm_Rol";
                    menu.form = "Form1";
                    break;
                case "Abm Cliente":
                    menu.carpeta = "Abm_Cliente";
                    menu.form = "Form1";
                    break;
                case "Abm Empresa Espectaculo":
                    menu.carpeta = "Abm_Empresa_Espectaculo";
                    menu.form = "Form1";
                    break;
                case "Abm Rubro":
                    menu.carpeta = "Abm_Rubro";
                    menu.form = "Form1";
                    break;
                case "Abm Grado":
                    menu.carpeta = "ABM_de_Cliente";
                    menu.form = "Form1";
                    break;
                case "Generar Publicacion":
                    menu.carpeta = "Generar_Publicacion";
                    menu.form = "Form1";
                    break;
                case "Editar Publicacion":
                    menu.carpeta = "Editar_Publicacion";
                    menu.form = "Form1";
                    break;
                case "Compra":
                    menu.carpeta = "Compra";
                    menu.form = "Form1";
                    break;
                case "Historial del Cliente":
                    menu.carpeta = "Historial_Cliente";
                    menu.form = "Form1";
                    break;
                case "Canjear Puntos":
                    menu.carpeta = "Canje_Puntos";
                    menu.form = "Form1";
                    break;
                case "Generar Pago de Comisiones":
                    menu.carpeta = "Generar_Rendicion_Comisiones";
                    menu.form = "Form1";
                    break;
                case "Listado Estadistico":
                    menu.carpeta = "Listado_Estadistico";
                    menu.form = "Form1";
                    break;
            }
            return menu;
        }
    }
}