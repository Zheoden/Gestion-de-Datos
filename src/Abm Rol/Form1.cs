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
            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            conn.Open();
            string SQL = "SELECT r.rol_id, r.rol_nombre, f.func_descripcion " +
                         "FROM EL_REJUNTE.Rol r, EL_REJUNTE.Func_Rol fr, EL_REJUNTE.Funcionalidad f " +
                         "WHERE r.rol_id = fr.rol_id AND " +
                               "fr.func_id = f.func_id";

            SqlCommand command = new SqlCommand(SQL, conn);

            command.Connection = conn;
            command.CommandType = CommandType.Text;

            SqlDataReader reader = command.ExecuteReader() as SqlDataReader;
            int cont = 0;
            if (reader.HasRows) {
                while (reader.Read()) {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[cont].Cells[0].Value = reader["rol_id"].ToString();
                    dataGridView1.Rows[cont].Cells[1].Value = reader["rol_nombre"].ToString();
                    dataGridView1.Rows[cont].Cells[2].Value = reader["func_descripcion"].ToString();
                    cont++;
                }
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
    }
}
