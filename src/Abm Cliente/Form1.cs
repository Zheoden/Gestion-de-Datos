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

namespace PalcoNet.Abm_Cliente
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            gb_b_avanzada.Visible = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvClientes.Rows.Clear();
            dgvClientes.Refresh();

            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            conn.Open();
            string SQL = "SELECT c.clie_id, c.clie_nombre, c.clie_apellido, c.clie_tipo_documento, c.clie_documento, c.clie_cuil, c.clie_email, c.clie_telefono, c.clie_fecha_nacimiento, c.clie_fecha_creacion, c.clie_habilitado, d.dire_calle, d.dire_numero " +
                         "FROM EL_REJUNTE.Cliente c, EL_REJUNTE.Direccion d " +
                         "WHERE c.clie_direccion_id = d.dire_id ";

            if (txtNombre.Text != "") {
                SQL += " AND c.clie_nombre LIKE " + "'%" + txtNombre.Text.ToString() + "%'";
            }
            if (txtApellido.Text != "") {
                SQL += " AND c.clie_apellido LIKE " + "'%" + txtApellido.Text.ToString() + "%'";
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
                        SQL += " AND " + sufijo + "." + campo + " = '" + dato + "'"; ;
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
                    dgvClientes.Rows.Add();
                    dgvClientes.Rows[cont].Cells[0].Value = reader["clie_id"].ToString();
                    dgvClientes.Rows[cont].Cells[1].Value = reader["clie_nombre"].ToString();
                    dgvClientes.Rows[cont].Cells[2].Value = reader["clie_apellido"].ToString();
                    dgvClientes.Rows[cont].Cells[3].Value = reader["clie_tipo_documento"].ToString();
                    dgvClientes.Rows[cont].Cells[4].Value = reader["clie_documento"].ToString();
                    dgvClientes.Rows[cont].Cells[5].Value = reader["clie_cuil"].ToString();
                    dgvClientes.Rows[cont].Cells[6].Value = reader["clie_email"].ToString();
                    dgvClientes.Rows[cont].Cells[7].Value = reader["clie_telefono"].ToString();
                    dgvClientes.Rows[cont].Cells[8].Value = Convert.ToDateTime(reader["clie_fecha_nacimiento"]);
                    dgvClientes.Rows[cont].Cells[9].Value = Convert.ToDateTime(reader["clie_fecha_creacion"]);
                    dgvClientes.Rows[cont].Cells[10].Value = Convert.ToBoolean(reader["clie_habilitado"]);
                    dgvClientes.Rows[cont].Cells[11].Value = reader["dire_calle"].ToString();
                    dgvClientes.Rows[cont].Cells[12].Value = reader["dire_numero"].ToString();
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
                case "Id de Cliente":
                    return "clie_id";
                case "Nombre":
                    return "clie_nombre";
                case "Apellido":
                    return "clie_apellido";
                case "Tipo de Documento":
                    return "clie_tipo_documento";
                case "Documento":
                    return "clie_documento";
                case "CUIL":
                    return "clie_cuil";
                case "Email":
                    return "clie_email";
                case "Telefono":
                    return "clie_telefono";
                case "Fecha de Nacimiento":
                    return "clie_fecha_nacimiento";
                case "Fecha de Creacion":
                    return "clie_fecha_creacion";
                case "Habilitado":
                    return "clie_habilitado";
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
            string texto_exacto = txtDNI.Text;

                if (texto_libre == "" && texto_exacto == "") {
                    MessageBox.Show("Escriba al menos un filtro.");
                }
                else {
                    if (texto_libre != "") {
                        lstFiltro.Items.Add("Texto Libre: " + texto_libre + ". Para el Campo: Email");
                    }
                    if (texto_exacto != "") {
                        lstFiltro.Items.Add("Texto Exacto: " + texto_exacto + ". Para el Campo: Documento");
                    }

                    lstFiltro.SelectedIndexChanged += ListBoxapp_SelectedIndexChanged;

                }

                txtEmail.Text = "";
                txtDNI.Text = "";
            }

        private void ListBoxapp_SelectedIndexChanged(object sender, EventArgs e) {
            ListBox lBox = sender as ListBox;
            int index = lBox.SelectedIndex;
        }

        private void btnEliminarFiltro_Click(object sender, EventArgs e) {
            if (lstFiltro.SelectedIndex != -1) {
                lstFiltro.Items.Remove(lstFiltro.SelectedItem.ToString());
            }
            else {
                MessageBox.Show("Seleccione un filtro para poder eliminarlo.");
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

        private void btnLimpiar_Click(object sender, EventArgs e) {
            dgvClientes.Rows.Clear();
            dgvClientes.Refresh();
            txtApellido.Text = "";
            txtNombre.Text = "";
            txtDNI.Text = "";
            txtEmail.Text = "";
            lstFiltro.Items.Clear();
        }

        private void btnDarAlta_Click(object sender, EventArgs e) {
            FormAlta testDialog = new FormAlta();
            testDialog.ShowDialog(this);
        }

        private void btnModificar_Click(object sender, EventArgs e) {

            if (dgvClientes.SelectedCells.Count > 0) {
                int selectedrowindex = dgvClientes.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvClientes.Rows[selectedrowindex];
                string clienteSeleccionado = Convert.ToString(selectedRow.Cells["clie_id"].Value);
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

        private void btnEliminar_Click(object sender, EventArgs e) {

            if (dgvClientes.SelectedCells.Count > 0) {
                int selectedrowindex = dgvClientes.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvClientes.Rows[selectedrowindex];
                string clieSeleccionado = Convert.ToString(selectedRow.Cells["clie_nombre"].Value);
                if (clieSeleccionado != "") {
                    string respuesta = Microsoft.VisualBasic.Interaction.InputBox("Se va a proceder a borrar el rol " + clieSeleccionado.ToUpper() + ", esta seguro que desea eliminarlo?\n\nEscriba " + clieSeleccionado.ToUpper() + " para confirmar la operacion.", "Confirmacion");
                    if (respuesta.ToUpper() == clieSeleccionado.ToUpper()) {
                        if (DBHelper.bajaCliente(clieSeleccionado)) {
                            MessageBox.Show("El Cliente fue eliminado correctamente.");
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
