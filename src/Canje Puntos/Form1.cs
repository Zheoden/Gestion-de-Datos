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

namespace PalcoNet.Canje_Puntos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            cargarPuntos();
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

        private void cargarPuntos() {
            lblPuntos.Text = DBHelper.clienteGetPuntos(DBHelper.clienteGetId(VariablesGlobales.usuario.id)).ToString();
        }

        private void cb10_CheckedChanged(object sender, EventArgs e) {
            int puntos = Int32.Parse(lbl10.Text.Split(' ')[0].ToString());
            if (cb10.Checked) {
                lblCosto.Text = (Int32.Parse(lblCosto.Text) + puntos).ToString();
            }
            else {
                lblCosto.Text = (Int32.Parse(lblCosto.Text) - puntos).ToString();
            }
        }

        private void cb25_CheckedChanged(object sender, EventArgs e) {
            int puntos = Int32.Parse(lbl25.Text.Split(' ')[0].ToString());
            if (cb25.Checked) {
                lblCosto.Text = (Int32.Parse(lblCosto.Text) + puntos).ToString();
            }
            else {
                lblCosto.Text = (Int32.Parse(lblCosto.Text) - puntos).ToString();
            }
        }

        private void cb50_CheckedChanged(object sender, EventArgs e) {
            int puntos = Int32.Parse(lbl50.Text.Split(' ')[0].ToString());
            if (cb50.Checked) {
                lblCosto.Text = (Int32.Parse(lblCosto.Text) + puntos).ToString();
            }
            else {
                lblCosto.Text = (Int32.Parse(lblCosto.Text) - puntos).ToString();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e) {
            if (Int32.Parse(lblCosto.Text) <= Int32.Parse(lblPuntos.Text)) {
                if (Int32.Parse(lblCosto.Text) > 0) {
                    /* Canje de puntos correcto */
                    DBHelper.puntosCanjear(DBHelper.clienteGetId(VariablesGlobales.usuario.id), Int32.Parse(lblCosto.Text));
                    MessageBox.Show("Canje realizado con exito!!!");
                    cargarPuntos();
                    cb10.Checked = false;
                    cb25.Checked = false;
                    cb50.Checked = false;
                }
                else {
                    MessageBox.Show("No hay premio seleccionado. Primero debe seleccionar un premio.");
                }
            }
            else {
                MessageBox.Show("Puntos Insuficientes!! Realice mas compras para obtener mas puntos!!");
            }
        }
    }
}
