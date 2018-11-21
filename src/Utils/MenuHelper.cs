using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System;
using PalcoNet.Objetos;
namespace PalcoNet.Utils {

    public class MenuHelper {

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
                    menu.carpeta = "Abm_Grado";
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