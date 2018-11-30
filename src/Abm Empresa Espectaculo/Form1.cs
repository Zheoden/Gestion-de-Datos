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
using Microsoft.VisualBasic;

namespace PalcoNet.Abm_Empresa_Espectaculo {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            gb_b_avanzada.Visible = false;
        }

        private void btnDarAlta_Click(object sender, EventArgs e) {
            FormAlta testDialog = new FormAlta();
            testDialog.ShowDialog(this);
        }

        private void btnBuscar_Click(object sender, EventArgs e) {
            dgvEmpresas.Rows.Clear();
            dgvEmpresas.Refresh();

            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            conn.Open();
            string SQL = "SELECT e.empre_id, e.empre_razon_social , e.empre_cuit , e.empre_fecha_creacion, e.empre_mail, e.empre_telefono, e.empre_baja_logica, d.dire_calle, d.dire_numero " +
                         "FROM EL_REJUNTE.Empresa e, EL_REJUNTE.Direccion d " +
                         "WHERE e.empre_direccion_id = d.dire_id ";

            if (txtNombre.Text != "") {
                SQL += " AND e.empre_razon_social LIKE " + "'%" + txtNombre.Text.ToString() + "%'";
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
                    dgvEmpresas.Rows.Add();
                    dgvEmpresas.Rows[cont].Cells[0].Value = reader["empre_id"].ToString();
                    dgvEmpresas.Rows[cont].Cells[1].Value = reader["empre_razon_social"].ToString();
                    dgvEmpresas.Rows[cont].Cells[2].Value = reader["empre_cuit"].ToString();
                    dgvEmpresas.Rows[cont].Cells[3].Value = reader["empre_fecha_creacion"].ToString();
                    dgvEmpresas.Rows[cont].Cells[4].Value = reader["empre_mail"].ToString();
                    dgvEmpresas.Rows[cont].Cells[5].Value = reader["empre_telefono"].ToString();
                    dgvEmpresas.Rows[cont].Cells[6].Value = reader["empre_baja_logica"].ToString();
                    dgvEmpresas.Rows[cont].Cells[7].Value = reader["dire_calle"].ToString();
                    dgvEmpresas.Rows[cont].Cells[8].Value = reader["dire_numero"].ToString();
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
                case "Id de Empresa":
                    return "empre_id";
                case "Razon Social":
                    return "empre_razon_social";
                case "CUIT":
                    return "empre_cuit";
                case "Fecha de Creacion":
                    return "empre_fecha_creacion";
                case "Mail":
                    return "empre_mail";
                case "Telefono":
                    return "empre_telefono";
                case "Calle":
                    return "dire_calle";
                case "Numero de Calle":
                    return "dire_numero";
                default:
                    return "";
            }
        }

        private string obtenerSufijo(string campo) {
            return campo.Substring(0, 1);
        }

        private void btnFiltro_Click(object sender, EventArgs e) {
            string texto_libre = txtEmail.Text;
            string texto_exacto = txtCUIT.Text;

            if (texto_libre == "" && texto_exacto == "") {
                MessageBox.Show("Escriba al menos un filtro.");
            }
            else {
                if (texto_libre != "") {
                    lstFiltro.Items.Add("Texto Libre: " + texto_libre + ". Para el Campo: Email");
                }
                if (texto_exacto != "") {
                    lstFiltro.Items.Add("Texto Exacto: " + texto_exacto + ". Para el Campo: CUIT");
                }

                lstFiltro.SelectedIndexChanged += ListBoxapp_SelectedIndexChanged;

            }

            txtEmail.Text = "";
            txtCUIT.Text = "";
        }

        private void btnEliminarFiltro_Click(object sender, EventArgs e) {
            if (lstFiltro.SelectedIndex != -1) {
                lstFiltro.Items.Remove(lstFiltro.SelectedItem.ToString());
            }
            else {
                MessageBox.Show("Seleccione un filtro para poder eliminarlo.");
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e) {
            dgvEmpresas.Rows.Clear();
            dgvEmpresas.Refresh();
            txtNombre.Text = "";
            txtCUIT.Text = "";
            txtEmail.Text = "";
            lstFiltro.Items.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e) {
            if (dgvEmpresas.SelectedCells.Count > 0) {
                int selectedrowindex = dgvEmpresas.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvEmpresas.Rows[selectedrowindex];
                string EmpreSeleccionado = Convert.ToString(selectedRow.Cells["empre_razon_social"].Value);
                if (EmpreSeleccionado != "") {
                    string respuesta = Microsoft.VisualBasic.Interaction.InputBox("Se va a proceder a borrar el rol " + EmpreSeleccionado.ToUpper() + ", esta seguro que desea eliminarlo?\n\nEscriba " + EmpreSeleccionado.ToUpper() + " para confirmar la operacion.", "Confirmacion");
                    if (respuesta.ToUpper() == EmpreSeleccionado.ToUpper()) {
                        if (DBHelper.bajaEmpresa(EmpreSeleccionado)) {
                            MessageBox.Show("La empresa fue eliminada correctamente.");
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

        private void cb_busquedaAvanzada_CheckedChanged(object sender, EventArgs e) {
            if (cb_busquedaAvanzada.Checked) {
                gb_b_avanzada.Visible = true;

            }
            else {
                gb_b_avanzada.Visible = false;
            }
        }

        private void ListBoxapp_SelectedIndexChanged(object sender, EventArgs e) {
            ListBox lBox = sender as ListBox;
            int index = lBox.SelectedIndex;
        }

        private void btnModificar_Click(object sender, EventArgs e) {
            if (dgvEmpresas.SelectedCells.Count > 0) {
                int selectedrowindex = dgvEmpresas.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvEmpresas.Rows[selectedrowindex];
                string clienteSeleccionado = Convert.ToString(selectedRow.Cells["empre_id"].Value);
                if (clienteSeleccionado != "") {

                    FormModificacion testDialog = new FormModificacion();
                    testDialog.txtID.Text = clienteSeleccionado;
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
