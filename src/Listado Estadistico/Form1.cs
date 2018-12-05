using PalcoNet.Objetos;
using PalcoNet.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Listado_Estadistico
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {

            cargarListado();
            cargarAnio();
            cargarTrimestre();
            cargarGrados();
            lblTrimestre.Visible = false;
            lblListado.Visible = false;
            cboTrimestre.Visible = false;
            cboListado .Visible = false;
            lblGrado.Visible = false;
            cboGrado.Visible = false;

            foreach (Funcionalidad func in VariablesGlobales.usuario.funcionalidades) {
                ToolStripMenuItem item = new ToolStripMenuItem(func.descripcion);
                item.Tag = func.descripcion.ToString();

                menuToolStripMenuItem.DropDownItems.Add(item);

                item.Click += new EventHandler(eventClick);
            }
        }

        private void cargarListado() {
            cboListado.Items.Add("Empresas con mayor cantidad de localidades no vendidas");
            cboListado.Items.Add("Clientes con mayores puntos vencidos");
            cboListado.Items.Add("Clientes con mayor cantidad de compras");
        }

        private void cargarGrados() {
            List<Grado> grados = DBHelper.getGrados();
            foreach (Grado grado in grados) {
                cboGrado.Items.Add("Prioridad:" + grado.prioridad + "; Comision:" + grado.comision + "; Habilitado:" + grado.habilitado);
            }
        }

        private void cargarAnio() {
            for (int i = 2000; i < 2025; i++) {
                cboAnio.Items.Add(i.ToString());
            }
        }

        private void cargarTrimestre() {
            cboTrimestre.Items.Add("Enero a Marzo");
            cboTrimestre.Items.Add("Abril a Junio");
            cboTrimestre.Items.Add("Julio a Septiembre");
            cboTrimestre.Items.Add("Octubre a Diciembre");

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

        private void cboAnio_SelectedIndexChanged(object sender, EventArgs e) {
            if (cboAnio.Text != "") {
                lblTrimestre.Visible = true;
                cboTrimestre.Visible = true;
            }
        }

        private void cboTrimestre_SelectedIndexChanged(object sender, EventArgs e) {
            if (cboTrimestre.Text != "") {
                lblListado.Visible = true;
                cboListado.Visible = true;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e) {
            if (validarDatos()) {
                switch (cboListado.Text) {
                    case "Empresas con mayor cantidad de localidades no vendidas":
                        Grado grado = new Grado();
                        grado.prioridad = cboGrado.SelectedItem.ToString().Split(';')[0].Split(':')[1];
                        grado.comision = Int32.Parse(cboGrado.SelectedItem.ToString().Split(';')[1].Split(':')[1]);
                        grado.habilitado = Convert.ToBoolean(cboGrado.SelectedItem.ToString().Split(';')[2].Split(':')[1]);
                        grado = DBHelper.getGrado(grado.prioridad, grado.comision);
                        dgvListado.DataSource = DBHelper.empresasMenosVendidas(armarFechaInicio(), armarFechaFinal(), grado.id);
                        if (dgvListado.RowCount == 0) {
                            MessageBox.Show("No se encontraron Empresas para el trimestre seleccionado.");
                        }
                        break;
                    case "Clientes con mayores puntos vencidos":
                        dgvListado.DataSource = DBHelper.clientesMayoresPuntosVencidos(armarFechaInicio(), armarFechaFinal());
                        if (dgvListado.RowCount == 0) {
                            MessageBox.Show("No se encontraron Clientes para el trimestre seleccionado.");
                        }
                        break;
                    case "Clientes con mayor cantidad de compras":
                        dgvListado.DataSource = DBHelper.clientesMasCompras(armarFechaInicio(), armarFechaFinal());
                        if (dgvListado.RowCount == 0) {
                            MessageBox.Show("No se encontraron Clientes para el trimestre seleccionado.");
                        }
                        break;
                }
            }
            else {
                MessageBox.Show("Complete todos los campos para poder realizar la busqueda.");
            }
            
        }

        private Boolean validarDatos() {
            return (cboTrimestre.Text != "" && cboAnio.Text != "") && ((cboListado.Text == "Empresas con mayor cantidad de localidades no vendidas" && cboGrado.Text != "") || (cboListado.Text != "Empresas con mayor cantidad de localidades no vendidas" && cboListado.Text != ""));
        }

        private DateTime armarFechaInicio() {
            DateTime fecha;
            switch (cboTrimestre.Text) {
                case "Enero a Marzo":
                    fecha = new DateTime(Int32.Parse(cboAnio.Text), 01, 01);
                    break;
                case "Abril a Junio":
                    fecha = new DateTime(Int32.Parse(cboAnio.Text), 4, 01);
                    break;
                case "Julio a Septiembre":
                    fecha = new DateTime(Int32.Parse(cboAnio.Text), 7, 01);
                    break;
                case "Octubre a Diciembre":
                    fecha = new DateTime(Int32.Parse(cboAnio.Text), 10, 01);
                    break;
                default:
                    fecha = new DateTime(Int32.Parse(cboAnio.Text), 01, 01);
                    break;
            }
            return fecha;
        }

        private DateTime armarFechaFinal() {
            DateTime fecha;
            switch (cboTrimestre.Text) {
                case "Enero a Marzo":
                    fecha = new DateTime(Int32.Parse(cboAnio.Text), 03, 31);
                    break;
                case "Abril a Junio":
                    fecha = new DateTime(Int32.Parse(cboAnio.Text), 6, 30);
                    break;
                case "Julio a Septiembre":
                    fecha = new DateTime(Int32.Parse(cboAnio.Text), 9, 30);
                    break;
                case "Octubre a Diciembre":
                    fecha = new DateTime(Int32.Parse(cboAnio.Text), 12, 31);
                    break;
                default:
                    fecha = new DateTime(Int32.Parse(cboAnio.Text), 01, 01);
                    break;
            }
            return fecha;
        }

        private void cboListado_SelectedIndexChanged(object sender, EventArgs e) {
            if (cboListado.Text == "Empresas con mayor cantidad de localidades no vendidas") {
                lblGrado.Visible = true;
                cboGrado.Visible = true;
            }
            else {
                lblGrado.Visible = false;
                cboGrado.Visible = false;
            }
        }
    }
}
