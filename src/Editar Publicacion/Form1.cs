using PalcoNet.Objetos;
using PalcoNet.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Editar_Publicacion {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {

            List<Rubro> rubros = DBHelper.getRubros();
            foreach (Rubro rubro in rubros) {
                cmbRubro.Items.Add(rubro.descripcion);
            }

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

        private void btnBuscar_Click(object sender, EventArgs e) {


            dgvPublicaciones.Rows.Clear();
            dgvPublicaciones.Refresh();

            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            conn.Open();
            string SQL = "SELECT DISTINCT p.publi_id, p.publi_descripcion, e.estado_descripcion, p.publi_fecha_evento, p.publi_codigo, r.rubro_descripcion, g.grado_prioridad, p.publi_stock " +
                         "FROM EL_REJUNTE.Publicacion p, EL_REJUNTE.Estado e, EL_REJUNTE.Rubro r, EL_REJUNTE.Grado g, EL_REJUNTE.Usuario u " +
                         "WHERE p.publi_estado_id = e.estado_id AND " +
                               "e.estado_id = 1 AND " +
                               "p.publi_rubro_id = r.rubro_id AND " +
                               "p.publi_grado_id = g.grado_id AND " +
                               "p.publi_usuario_id = " + VariablesGlobales.usuario.id;

            if (txtDesc.Text != "") {
                SQL += " AND p.publi_descripcion LIKE " + "'%" + txtDesc.Text.ToString() + "%'";
            }
            if (cmbRubro.Text != "") {
                SQL += " AND p.publi_rubro_id = " + DBHelper.getRubro(cmbRubro.Text.ToString()).id;
            }

            SqlCommand command = new SqlCommand(SQL, conn);

            command.Connection = conn;
            command.CommandType = CommandType.Text;

            SqlDataReader reader = command.ExecuteReader() as SqlDataReader;
            int cont = 0;
            if (reader.HasRows) {
                while (reader.Read()) {
                    dgvPublicaciones.Rows.Add();
                    dgvPublicaciones.Rows[cont].Cells[0].Value = reader["publi_id"].ToString();
                    dgvPublicaciones.Rows[cont].Cells[1].Value = reader["publi_descripcion"].ToString();
                    dgvPublicaciones.Rows[cont].Cells[2].Value = reader["estado_descripcion"].ToString();
                    dgvPublicaciones.Rows[cont].Cells[3].Value = reader["publi_fecha_evento"].ToString();
                    dgvPublicaciones.Rows[cont].Cells[4].Value = reader["publi_codigo"].ToString();
                    dgvPublicaciones.Rows[cont].Cells[5].Value = reader["rubro_descripcion"].ToString();
                    dgvPublicaciones.Rows[cont].Cells[6].Value = reader["grado_prioridad"].ToString();
                    dgvPublicaciones.Rows[cont].Cells[7].Value = reader["publi_stock"].ToString();
                    cont++;
                }
            }
            else if (txtDesc.Text == "" && cmbRubro.Text == "") {
                MessageBox.Show("No tiene publicaciones que pueda editar, primero cree publicaciones para poder editarlas.");
            }
            else {
                MessageBox.Show("No se encontraron resultados para estos parametros, modifique alguno e intente nuevamente!");
            }

            Connection.close(conn);
        }

        private string mapeoDeCampos(string campo) {
            switch (campo) {
                case "Id de Publicacion":
                    return "publi_id";
                case "Nombre":
                    return "clie_nombre";
                case "Descripcion":
                    return "publi_descripcion";
                case "Fecha de Evento":
                    return "publi_fecha_evento";
                case "Codigo":
                    return "publi_codigo";
                default:
                    return "";
            }
        }

        private string obtenerSufijo(string campo) {
            return campo.Substring(0, 1);
        }

        private void btnModificar_Click(object sender, EventArgs e) {
            if (dgvPublicaciones.SelectedCells.Count > 0) {
                int selectedrowindex = dgvPublicaciones.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvPublicaciones.Rows[selectedrowindex];
                string publicacion = Convert.ToString(selectedRow.Cells["publi_id"].Value);
                if (publicacion != "") {
                    FormModificacion testDialog = new FormModificacion();
                    testDialog.txtID.Text = publicacion;
                    testDialog.ShowDialog(this);
                    btnBuscar_Click(sender, e);
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
