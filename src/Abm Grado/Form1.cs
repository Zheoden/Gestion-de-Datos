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
using PalcoNet.Objetos;

namespace PalcoNet.Abm_Grado {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            gb_b_avanzada.Visible = false;
        }

        private void cb_busquedaAvanzada_CheckedChanged(object sender, EventArgs e) {
            if (cb_busquedaAvanzada.Checked) {
                gb_b_avanzada.Visible = true;

            }
            else {
                gb_b_avanzada.Visible = false;
            }
        }

        private void btnFiltro_Click(object sender, EventArgs e) {
            string texto_libre = "";
            string texto_exacto = txtComision.Text;

            if (texto_libre == "" && texto_exacto == "") {
                MessageBox.Show("Escriba al menos un filtro.");
            }
            else {
                if (texto_libre != "") {
                    lstFiltro.Items.Add("Texto Libre: " + texto_libre + ". Para el Campo: Porcentaje");
                }
                if (texto_exacto != "") {
                    lstFiltro.Items.Add("Texto Exacto: " + texto_exacto + ". Para el Campo: Comision");
                }

                lstFiltro.SelectedIndexChanged += ListBoxapp_SelectedIndexChanged;

            }

            txtComision.Text = "";
        }

        private void btnEliminarFiltro_Click(object sender, EventArgs e) {
            if (lstFiltro.SelectedIndex != -1) {
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

        private void btnBuscar_Click(object sender, EventArgs e) {
            dgvGrados.Rows.Clear();
            dgvGrados.Refresh();

            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            conn.Open();
            string SQL = "SELECT g.grado_id, g.grado_prioridad, g.grado_comision, g.grado_habilitado " +
                         "FROM EL_REJUNTE.Grado g " +
                         "WHERE g.grado_id = g.grado_id ";

            if (txtPrioridad.Text != "") {
                SQL += " AND g.grado_prioridad LIKE " + "'%" + txtPrioridad.Text.ToString() + "%'";
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
                        SQL += " AND " + sufijo + "." + campo + " = '" + dato + "'";
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
                    dgvGrados.Rows.Add();
                    dgvGrados.Rows[cont].Cells[0].Value = reader["grado_id"].ToString();
                    dgvGrados.Rows[cont].Cells[1].Value = reader["grado_prioridad"].ToString();
                    dgvGrados.Rows[cont].Cells[2].Value = reader["grado_comision"].ToString();
                    dgvGrados.Rows[cont].Cells[3].Value = Convert.ToBoolean(reader["grado_habilitado"].ToString());
                    cont++;
                }
            }
            else {
                MessageBox.Show("No se encontraron resultados para estos parametros, modifique alguno e intente nuevamente!");
            }

            Connection.close(conn);
        }

        private string mapeoDeCampos(string campo) {
            switch (campo) {
                case "Id de Grado":
                    return "grado_id";
                case "Prioridad":
                    return "grado_prioridad";
                case "Comision":
                    return "grado_comision";
                case "Habilitado":
                    return "grado_habilitado";
                default:
                    return "";
            }
        }

        private string obtenerSufijo(string campo) {
            return campo.Substring(0, 1);
        }

        private void btnDarAlta_Click(object sender, EventArgs e) {
            FormAlta testDialog = new FormAlta();
            testDialog.ShowDialog(this);
        }

        private void btnEliminar_Click(object sender, EventArgs e) {
            if (dgvGrados.SelectedCells.Count > 0) {
                int selectedrowindex = dgvGrados.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvGrados.Rows[selectedrowindex];
                int gradoSeleccionado = Int32.Parse(selectedRow.Cells["grado_id"].Value.ToString());
                if (gradoSeleccionado.ToString() != "") {
                    string respuesta = Microsoft.VisualBasic.Interaction.InputBox("Se va a proceder a borrar el grado " + gradoSeleccionado.ToString().ToUpper() + ", esta seguro que desea eliminarlo?\n\nEscriba " + gradoSeleccionado.ToString().ToUpper() + " para confirmar la operacion.", "Confirmacion");
                    if (respuesta.ToUpper() == gradoSeleccionado.ToString().ToUpper()) {
                        if (DBHelper.bajaGrado(gradoSeleccionado)) {
                            MessageBox.Show("El grado fue eliminado correctamente.");
                        }
                    }
                }
                else {
                    MessageBox.Show("Seleccionó una celda invalida, por favor seleccione otra.");
                }
            }
            else {
                MessageBox.Show("Buscar los grados aplicando los filtros deseados y luego seleccionar algun rol dentro de la lista para modificar.");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e) {
            if (dgvGrados.SelectedCells.Count > 0) {
                int selectedrowindex = dgvGrados.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvGrados.Rows[selectedrowindex];
                string gradoSeleccionado = Convert.ToString(selectedRow.Cells["grado_id"].Value);
                if (gradoSeleccionado != "") {

                    FormModificacion testDialog = new FormModificacion();
                    testDialog.txtID.Text = gradoSeleccionado;
                    testDialog.ShowDialog(this);

                }
                else {
                    MessageBox.Show("Seleccionó una celda invalida, por favor seleccione otra.");
                }
            }
            else {
                MessageBox.Show("Buscar los grados aplicando los filtros deseados y luego seleccionar algun rol dentro de la lista para modificar.");
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e) {
            dgvGrados.Rows.Clear();
            dgvGrados.Refresh();
            txtPrioridad.Text = "";
            txtComision.Text = "";
            lstFiltro.Items.Clear();
        }

        private void Form1_Load(object sender, EventArgs e) {

            foreach (Funcionalidad func in VariablesGlobales.usuario.funcionalidades) {
                ToolStripMenuItem item = new ToolStripMenuItem(func.descripcion);
                item.Tag = func.descripcion.ToString();

                menuToolStripMenuItem.DropDownItems.Add(item);

                item.Click += new EventHandler(eventClick);
            }
        }

        public void eventClick(object sender, EventArgs e) {
            ToolStripMenuItem item = sender as ToolStripMenuItem;

            string opcion = item.Tag.ToString();

            Menus menuSeleccionado = MenuHelper.getOpciones(opcion);

            this.Close();
            Form nextForm = (Form)Activator.CreateInstance(null, "PalcoNet" + "." + menuSeleccionado.carpeta + "." + menuSeleccionado.form).Unwrap();
            nextForm.Show();
        }

        private void cerrarAplicacionToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }
    }
}
