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
using PalcoNet.Objetos;
using System.Globalization;

namespace PalcoNet.Comprar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cargarCategorias();
        }

        public void cargarCategorias()
        {
            try
            {
                SqlConnection conn = new SqlConnection(Connection.getStringConnection());
                conn.Open();
                string SQL = "SELECT r.rubro_id, r.rubro_descripcion " +
                             "FROM EL_REJUNTE.Rubro r";
                SqlCommand command = new SqlCommand(SQL, conn);

                command.Connection = conn;
                command.CommandType = CommandType.Text;

                //SqlDataReader reader = command.ExecuteReader() as SqlDataReader;
                //while (reader.Read())
                //{
                //    cboCategoria.Items.Add(reader[1].ToString());
                //}
                //conn.Close();
                //cboCategoria.Items.Insert(0, "Seleccione una categoria");
                //cboCategoria.SelectedIndex = 0;

                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conn.Close();
                cboCategoria.ValueMember = "rubro_id";
                cboCategoria.DisplayMember = "rubro_descripcion";

                DataRow fila = dt.NewRow();
                fila["rubro_id"] = -1;
                fila["rubro_descripcion"] = "Seleccione una categoria";
                dt.Rows.InsertAt(fila, 0);

                cboCategoria.DataSource = dt;

            }
            catch (Exception ex)
            {
                var algo = 3;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //dgvEspectaculos.Rows.Clear();
            //dgvEspectaculos.Refresh();

            //SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            //conn.Open();
            //string SQL = "SELECT c.clie_id, c.clie_nombre, c.clie_apellido, c.clie_tipo_documento, c.clie_documento, c.clie_cuil, c.clie_email, c.clie_telefono, c.clie_fecha_nacimiento, c.clie_fecha_creacion, c.clie_habilitado, d.dire_calle, d.dire_numero " +
            //             "FROM EL_REJUNTE.Cliente c, EL_REJUNTE.Direccion d " +
            //             "WHERE c.clie_direccion_id = d.dire_id ";

            //if (txtNombre.Text != "") {
            //    SQL += " AND c.clie_nombre LIKE " + "'%" + txtNombre.Text.ToString() + "%'";
            //}
            //if (txtApellido.Text != "") {
            //    SQL += " AND c.clie_apellido LIKE " + "'%" + txtApellido.Text.ToString() + "%'";
            //}

            //if (cb_busquedaAvanzada.Checked) {
            //    foreach (string item in lstFiltro.Items) {
            //        string[] items = item.Split(':'); // la tercera posicion no me importa
            //        string tipo = items[0];
            //        string dato = items[1].Split('.')[0].Substring(1);
            //        string campo = mapeoDeCampos(items[2].Substring(1));
            //        string sufijo = obtenerSufijo(campo);

            //        MessageBox.Show("Tipo: " + tipo + ". Datos: " + dato + ". Campo: " + campo);

            //        if (tipo == "Texto Libre") {
            //            SQL += " AND " + sufijo + "." + campo + " LIKE '%" + dato + "%'";
            //        }

            //        if (tipo == "Texto Exacto") {
            //            SQL += " AND " + sufijo + "." + campo + " = '" + dato + "'"; ;
            //        }
            //    }
            //}



            //SqlCommand command = new SqlCommand(SQL, conn);

            //command.Connection = conn;
            //command.CommandType = CommandType.Text;

            //SqlDataReader reader = command.ExecuteReader() as SqlDataReader;
            //int cont = 0;
            //if (reader.HasRows) {
            //    while (reader.Read()) {
            //        dgvEspectaculos.Rows.Add();
            //        dgvEspectaculos.Rows[cont].Cells[0].Value = reader["clie_id"].ToString();
            //        dgvEspectaculos.Rows[cont].Cells[1].Value = reader["clie_nombre"].ToString();
            //        dgvEspectaculos.Rows[cont].Cells[2].Value = reader["clie_apellido"].ToString();
            //        dgvEspectaculos.Rows[cont].Cells[3].Value = reader["clie_tipo_documento"].ToString();
            //        dgvEspectaculos.Rows[cont].Cells[4].Value = reader["clie_documento"].ToString();
            //        dgvEspectaculos.Rows[cont].Cells[5].Value = reader["clie_cuil"].ToString();
            //        dgvEspectaculos.Rows[cont].Cells[6].Value = reader["clie_email"].ToString();
            //        dgvEspectaculos.Rows[cont].Cells[7].Value = reader["clie_telefono"].ToString();
            //        dgvEspectaculos.Rows[cont].Cells[8].Value = Convert.ToDateTime(reader["clie_fecha_nacimiento"]);
            //        dgvEspectaculos.Rows[cont].Cells[9].Value = Convert.ToDateTime(reader["clie_fecha_creacion"]);
            //        dgvEspectaculos.Rows[cont].Cells[10].Value = Convert.ToBoolean(reader["clie_habilitado"]);
            //        dgvEspectaculos.Rows[cont].Cells[11].Value = reader["dire_calle"].ToString();
            //        dgvEspectaculos.Rows[cont].Cells[12].Value = reader["dire_numero"].ToString();
            //        cont++;
            //    }
            //}
            //else {
            //    MessageBox.Show("No se encontraron resultados para estos parametros, modifique alguno e intente nuevamente!");
            //}

            //Connection.close(conn);
        }


        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            lstFiltro.Items.Clear();
        }

        private void btnDarAlta_Click(object sender, EventArgs e)
        {
            /* FormAlta testDialog = new FormAlta();
             testDialog.ShowDialog(this);*/
        }



        private void Form1_Load(object sender, EventArgs e)
        {

            foreach (Funcionalidad func in VariablesGlobales.usuario.funcionalidades)
            {
                ToolStripMenuItem item = new ToolStripMenuItem(func.descripcion);
                item.Tag = func.descripcion.ToString();

                menuToolStripMenuItem.DropDownItems.Add(item);

                item.Click += new EventHandler(eventClick);
            }
        }

        public void eventClick(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;

            string opcion = item.Tag.ToString();

            Menus menuSeleccionado = MenuHelper.getOpciones(opcion);

            this.Close();
            Form nextForm = (Form)Activator.CreateInstance(null, "PalcoNet" + "." + menuSeleccionado.carpeta + "." + menuSeleccionado.form).Unwrap();
            nextForm.Show();
        }


        private void btnFiltro_Click_1(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboCategoria.SelectedValue) != -1)
            {

                var rpueba = Convert.ToInt32(cboCategoria.SelectedValue);
                lstFiltro.Items.Add(cboCategoria.SelectedItem);
                lstFiltro.ValueMember = "rubro_id";
                lstFiltro.DisplayMember = "rubro_descripcion";
            }
            else
            {
                MessageBox.Show("Seleccione un filtro para poder agregar.");
            }
            cboCategoria.SelectedIndex = 0;

        }

        private void btnEliminarFiltro_Click_1(object sender, EventArgs e)
        {
            if (lstFiltro.SelectedIndex != -1)
            {
                var algo = lstFiltro.SelectedItem;
                lstFiltro.Items.Remove(lstFiltro.SelectedItem);
                lstFiltro.Refresh();
            }
            else
            {
                MessageBox.Show("Seleccione un filtro para poder eliminarlo.");
            }
            cboCategoria.SelectedIndex = 0;
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            var sql = "Select * ";
            sql += "from EL_REJUNTE.Publicacion ";
            sql += "where 1=1 ";

            if (lstFiltro.Items.Count > 0) 
            {
                foreach (DataRowView drv in lstFiltro.Items)
                {
                    int id = int.Parse(drv.Row[lstFiltro.ValueMember].ToString());

                    sql += " AND publi_rubro_id = " + id;

                }
            }
            
            var descripcion = txtDescripcion.Text;
            if (descripcion != "") 
            {
                sql += " AND publi_descripcion LIKE  '%" + descripcion + "%' ";
            }


            var desde = dtpDesde.Value.Date.ToString("yyyy-MM-dd");
            var hasta = dtpHasta.Value.Date.ToString("yyyy-MM-dd");




            sql += " AND publi_fecha_evento >  " + "'" + desde + "'";

            sql += " AND publi_fecha_evento < " + "'" + hasta + "'";


            sql += " order by publi_grado_id ";

            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            conn.Open();

            SqlCommand command = new SqlCommand(sql, conn);

            command.Connection = conn;
            command.CommandType = CommandType.Text;

            SqlDataReader reader = command.ExecuteReader() as SqlDataReader;
            dgvEspectaculos.Rows.Clear();
            dgvEspectaculos.Refresh(); 
            int cont = 0;
            if (reader.HasRows) {
                while (reader.Read()) {
                    dgvEspectaculos.Rows.Add();
                    dgvEspectaculos.Rows[cont].Cells[0].Value = reader["publi_id"].ToString();
                    dgvEspectaculos.Rows[cont].Cells[1].Value = reader["publi_descripcion"].ToString();
                    dgvEspectaculos.Rows[cont].Cells[2].Value = reader["publi_grado_id"].ToString();
                    cont++;
                }
            }
            else
            {
                MessageBox.Show("No se encontraron resultados para estos parametros, modifique alguno e intente nuevamente!");
            }

            Connection.close(conn);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
