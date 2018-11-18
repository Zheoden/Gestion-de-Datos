using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using PalcoNet.Utils;
using Microsoft.VisualBasic;

namespace PalcoNet.Abm_Rol {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            gb_b_avanzada.Visible = false;
            cargarComboBoxCampos();
        }

        private void cb_busquedaAvanzada_CheckedChanged(object sender, EventArgs e) {
            if (cb_busquedaAvanzada.Checked) {
                gb_b_avanzada.Visible = true;

            }
            else {
                gb_b_avanzada.Visible = false;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e) {

            dgvRoles.Rows.Clear();
            dgvRoles.Refresh();

            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            conn.Open();
            string SQL = "SELECT r.rol_id, r.rol_nombre, f.func_descripcion, r.rol_habilitado " +
                         "FROM EL_REJUNTE.Rol r, EL_REJUNTE.Func_Rol fr, EL_REJUNTE.Funcionalidad f " +
                         "WHERE r.rol_id = fr.rol_id AND " +
                               "fr.func_id = f.func_id AND " + 
                               "r.rol_baja_logica = 0";

            if (txtNombreRol.Text != "") {
                SQL += " AND r.rol_nombre = " + "'" + txtNombreRol.Text.ToString() + "'";
            }

            if (cb_busquedaAvanzada.Checked) {
                foreach (string item in lstFiltro.Items) {
                    string[] items = item.Split(':'); // la tercera posicion no me importa
                    string tipo = items[0];
                    string dato = items[1].Split('.')[0].Substring(1);
                    string campo = mapeoDeCampos(items[2].Substring(1));
                    string sufijo = obtenerSufijo(campo);

                    MessageBox.Show("Tipo: " + tipo + ". Datos: " + dato + ". Campo: " + campo);

                    if (tipo == "Texto Libre") {
                        SQL += " AND " + sufijo + "." + campo + " LIKE '%" + dato + "%'";
                    }

                    if (tipo == "Texto Exacto") {
                        SQL += " AND " + sufijo + "." + campo + " = " + dato;
                    }

                    if (tipo == "Seleccion Acotada") {
                        SQL += " AND " + sufijo + "." + campo + " LIKE '%" + dato + "%'";
                    }
                }
            }



            SqlCommand command = new SqlCommand(SQL, conn);

            command.Connection = conn;
            command.CommandType = CommandType.Text;

            SqlDataReader reader = command.ExecuteReader() as SqlDataReader;
            int cont = 0;
            if (reader.HasRows) {
                while (reader.Read()) {
                    dgvRoles.Rows.Add();
                    dgvRoles.Rows[cont].Cells[0].Value = reader["rol_id"].ToString();
                    dgvRoles.Rows[cont].Cells[1].Value = reader["rol_nombre"].ToString();
                    dgvRoles.Rows[cont].Cells[2].Value = Convert.ToBoolean(reader["rol_habilitado"]);
                    dgvRoles.Rows[cont].Cells[3].Value = reader["func_descripcion"].ToString();
                    cont++;
                }
            }
            else {
                MessageBox.Show("No se encontraron resultados para estos parametros, modifique alguno e intente nuevamente!");
            }

            Connection.close(conn);
        }

        private void btnFiltro_Click(object sender, EventArgs e) {
            string campo = cmbCampo.Text;
            string texto_libre = txtTextoLibre.Text;
            string seleccion_acotada = txtSeleccionAcotada.Text;
            string texto_exacto = txtTextoExacto.Text;

            if (campo != "") {
                if (texto_libre == "" && texto_exacto == "" && seleccion_acotada == "") {
                    MessageBox.Show("Escriba al menos un filtro.");
                }
                else {
                    if (texto_libre != "") {
                        lstFiltro.Items.Add("Texto Libre: " + texto_libre + ". Para el Campo: " + campo);
                    }
                    if (texto_exacto != "") {
                        lstFiltro.Items.Add("Texto Exacto: " + texto_exacto + ". Para el Campo: " + campo);
                    }
                    if (seleccion_acotada != "") {
                        lstFiltro.Items.Add("Seleccion Acotada: " + seleccion_acotada + ". Para el Campo: " + campo);
                    }

                    lstFiltro.SelectedIndexChanged += ListBoxapp_SelectedIndexChanged;

                }
            }
            else {
                MessageBox.Show("Seleccione el campo por el cual se desea filtrar.");
            }
        }

        private void cargarComboBoxCampos() {
            cmbCampo.Items.Add("Id de Rol");
            cmbCampo.Items.Add("Nombre del Rol");
            cmbCampo.Items.Add("Funcionalidad");
        }

        private string obtenerSufijo(string campo) {
            return campo.Substring(0, 1);
        }

        private string mapeoDeCampos(string campo) {
            switch (campo) {
                case "Id de Rol":
                    return "rol_id";
                case "Nombre del Rol":
                    return "rol_nombre";
                case "Funcionalidad":
                    return "func_descripcion";
                default:
                    return "";
            } 
        }

        private void btnEliminarFiltro_Click(object sender, EventArgs e) {
            if (lstFiltro.SelectedIndex != -1 ) {
                lstFiltro.Items.Remove(lstFiltro.SelectedItem.ToString());
            }
            else {
                MessageBox.Show("Seleccione un filtro para poder eliminarlo.");
            }
        }

        private void ListBoxapp_SelectedIndexChanged(object sender, EventArgs e) {
            ListBox lBox = sender as ListBox;
            int index = lBox.SelectedIndex;
        }

        private void btnDarAlta_Click(object sender, EventArgs e) {
            FormAlta testDialog = new FormAlta();
            testDialog.ShowDialog(this);
        }

        private void btnModificar_Click(object sender, EventArgs e) {

            if (dgvRoles.SelectedCells.Count > 0) {
                int selectedrowindex = dgvRoles.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvRoles.Rows[selectedrowindex];
                string rolSeleccionado = Convert.ToString(selectedRow.Cells["rol_nombre"].Value);
                if (rolSeleccionado != "") {

                    FormModificacion testDialog = new FormModificacion();
                    testDialog.txtNombre.Text = rolSeleccionado;
                    testDialog.ShowDialog(this);

                }
                else {
                    MessageBox.Show("Seleccionó una celda invalida, por favor seleccione otra.");
                }
            }
            else {
                MessageBox.Show("Buscar los roles aplicando los filtros deseados y luego seleccionar algun rol dentro de la lista para modificar.");
            }
        }

        private void dgvRoles_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
            // Update the balance column whenever the value of any cell changes.
        }

        private void btnLimpiar_Click(object sender, EventArgs e) {
            dgvRoles.Rows.Clear();
            dgvRoles.Refresh();
            txtNombreRol.Text = "";
            txtSeleccionAcotada.Text = "";
            txtTextoExacto.Text = "";
            txtTextoLibre.Text = "";
            lstFiltro.Items.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e) {

            if (dgvRoles.SelectedCells.Count > 0) {
                int selectedrowindex = dgvRoles.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvRoles.Rows[selectedrowindex];
                string rolSeleccionado = Convert.ToString(selectedRow.Cells["rol_nombre"].Value);
                if (rolSeleccionado != "") {
                   string respuesta = Microsoft.VisualBasic.Interaction.InputBox("Se va a proceder a borrar el rol " + rolSeleccionado.ToUpper() + ", esta seguro que desea eliminarlo?\n\nEscriba "+ rolSeleccionado.ToUpper() + " para confirmar la operacion.", "Confirmacion");
                   if (respuesta.ToUpper() == rolSeleccionado.ToUpper()) {
                       if (DBHelper.bajaRol(rolSeleccionado)) {
                           MessageBox.Show("El rol fue eliminado correctamente.");
                       }
                   }
                }
                else {
                    MessageBox.Show("Seleccionó una celda invalida, por favor seleccione otra.");
                }
            }
            else {
                MessageBox.Show("Buscar los roles aplicando los filtros deseados y luego seleccionar algun rol dentro de la lista para modificar.");
            }

        }
    }
}
