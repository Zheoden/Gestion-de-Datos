using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PalcoNet.Objetos;
using PalcoNet.Utils;

namespace PalcoNet.Generar_Publicacion {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            cargarDatos();
        }

        private void btnAlta_Click(object sender, EventArgs e) {

        }

        private void btnAgregarDire_Click(object sender, EventArgs e) {
            if (cmbDireccion.Items.Count == 0) {
                FormDireccion testDialog = new FormDireccion();
                if (testDialog.ShowDialog(this) == DialogResult.OK) {
                    cmbDireccion.Items.Add("Datos de la direccion(Calle;Numero;Piso;Departamento;Localidad;Codigo Postal): " + testDialog.txtCalle.Text + "#" + testDialog.txtNumero.Text + "#" + testDialog.txtPiso.Text + "#" + testDialog.txtDepartamento.Text + "#" + testDialog.txtLocalidad.Text + "#" + testDialog.txtCodigoPostal.Text);
                    cmbDireccion.SelectedItem = "Datos de la direccion(Calle;Numero;Piso;Departamento;Localidad;Codigo Postal): " + testDialog.txtCalle.Text + "#" + testDialog.txtNumero.Text + "#" + testDialog.txtPiso.Text + "#" + testDialog.txtDepartamento.Text + "#" + testDialog.txtLocalidad.Text + "#" + testDialog.txtCodigoPostal.Text;
                }
            }
            else {
                MessageBox.Show("Solo se puede ingregar una direccion");
            }
        }

        private void btnEliminarDire_Click(object sender, EventArgs e) {
            cmbDireccion.Items.Remove(cmbDireccion.SelectedItem);
        }

        private void cargarDatos() {
            txtUsuarioResponsable.Text = VariablesGlobales.usuario.username;

            List<Grado> grados = DBHelper.getGrados();
            foreach (Grado grado in grados) {
                cmbGrado.Items.Add("Prioridad:"+grado.prioridad+"; Comision:" + grado.comision+"; Porcentaje:" + grado.porcentaje);
            }

            List<Estado> estados = DBHelper.getEstados();
            foreach (Estado estado in estados) {
                cmbEstado.Items.Add(estado.descripcion);
            }
        }

        private Boolean validarDatos() {
            int numero;
            if (txtDescripcion.Text != "" && txtStock.Text != "" && txtPrecio.Text != "" && txtRubro.Text != "" && txtUsuarioResponsable.Text != "" && dtpEspectaculo.Text != "" &&  cmbDireccion.Items.Count > 0 && cmbEstado.SelectedItem != "" && cmbGrado.SelectedItem != "") {
                if (Int32.TryParse(txtStock.Text, out numero) && Int32.TryParse(txtPrecio.Text, out numero)) {
                    if (cmbFechaEspectaculo.Items.Count > 0) {
                            return true;
                        }
                        else {
                            MessageBox.Show("Ingrese al menos una fecha para el espectaculo.");
                        }
                    }
                    else {
                        MessageBox.Show("El stock y el precio deben ser numeros.");
                    }
            }
            else {
                MessageBox.Show("Todos los campos son obligatorios.");
            }
            return false;
        }

        private void btnAgregarFecha_Click(object sender, EventArgs e) {
            if (cmbFechaEspectaculo.Items.Count > 0) {
                if (cmbFechaEspectaculo.Items.Contains(dtpEspectaculo.Value)) {
                    MessageBox.Show("Este horario ya existe");
                }
                else {
                    cmbFechaEspectaculo.SelectedIndex = cmbFechaEspectaculo.Items.Count -1 ;
                    if (Convert.ToDateTime(cmbFechaEspectaculo.SelectedItem.ToString()) > dtpEspectaculo.Value) {
                        MessageBox.Show("Solo se pueden agregar eventos posteriores a los ya ingresados.");
                    }
                    else {
                        cmbFechaEspectaculo.Items.Add(dtpEspectaculo.Value);
                        cmbFechaEspectaculo.SelectedItem = dtpEspectaculo.Value;
                    }
                }
            }
            else {
                cmbFechaEspectaculo.Items.Add(dtpEspectaculo.Value);
                cmbFechaEspectaculo.SelectedItem = dtpEspectaculo.Value;
            }
        }

        private void btnSacarFecha_Click(object sender, EventArgs e) {
            cmbFechaEspectaculo.Items.Remove(cmbFechaEspectaculo.SelectedItem);
        }

    }
}
