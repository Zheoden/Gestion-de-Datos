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

namespace PalcoNet.Editar_Publicacion {
    public partial class FormModificacion : Form {
        public FormModificacion() {
            InitializeComponent();
            cargarDatos();
        }

        private void btnAgregarFecha_Click(object sender, EventArgs e) {
            if (cmbFechaEspectaculo.Items.Count > 0) {
                if (cmbFechaEspectaculo.Items.Count == 1) {
                    MessageBox.Show("Solamente puede haber un horario porque se esta editando una publicacion.");
                }
            }
            else {
                if (dtpEspectaculo.Value > DateTime.Today) {
                    cmbFechaEspectaculo.Items.Add(dtpEspectaculo.Value);
                    cmbFechaEspectaculo.SelectedItem = dtpEspectaculo.Value;
                }
                else {
                    MessageBox.Show("La fecha seleccionada ya paso! Seleccione una fecha futura.");
                }
            }
        }

        private void btnSacarFecha_Click(object sender, EventArgs e) {
            cmbFechaEspectaculo.Items.Remove(cmbFechaEspectaculo.SelectedItem);
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

        private void button1_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void FormModificacion_Load(object sender, EventArgs e) {
            Publicacion publi = DBHelper.publicacionGetData(Int32.Parse(txtID.Text));
            txtDescripcion.Text = publi.descripcion;
            txtStock.Text = publi.stock.ToString();
            txtUsuarioResponsable.Text = VariablesGlobales.usuario.username;
            cmbDireccion.Items.Add("Datos de la direccion(Calle;Numero;Piso;Departamento;Localidad;Codigo Postal): " + publi.espectaculo.direccion.calle + "#" + publi.espectaculo.direccion.numero + "#" + publi.espectaculo.direccion.piso + "#" + publi.espectaculo.direccion.depto + "#" + publi.espectaculo.direccion.localidad + "#" + publi.espectaculo.direccion.codigo_postal);
            cmbDireccion.SelectedItem = "Datos de la direccion(Calle;Numero;Piso;Departamento;Localidad;Codigo Postal): " + publi.espectaculo.direccion.calle + "#" + publi.espectaculo.direccion.numero + "#" + publi.espectaculo.direccion.piso + "#" + publi.espectaculo.direccion.depto + "#" + publi.espectaculo.direccion.localidad + "#" + publi.espectaculo.direccion.codigo_postal;
            cmbFechaEspectaculo.Items.Add(publi.fecha_evento);
            cmbFechaEspectaculo.SelectedItem = publi.fecha_evento;
            cmbRubro.SelectedItem = publi.rubro.descripcion;
            cmbEstado.SelectedItem = "Borrador";
            cmbGrado.SelectedItem = "Prioridad:" + publi.grado.prioridad + "; Comision:" + publi.grado.comision + "; Habilitado:" + publi.grado.habilitado;
        }

        private void cargarDatos() {
            txtUsuarioResponsable.Text = VariablesGlobales.usuario.username;

            List<Grado> grados = DBHelper.getGrados();
            foreach (Grado grado in grados) {
                cmbGrado.Items.Add("Prioridad:" + grado.prioridad + "; Comision:" + grado.comision + "; Habilitado:" + grado.habilitado);
            }

            List<Estado> estados = DBHelper.getEstados();
            foreach (Estado estado in estados) {
                cmbEstado.Items.Add(estado.descripcion);
            }

            List<Rubro> rubros = DBHelper.getRubros();
            foreach (Rubro rubro in rubros) {
                cmbRubro.Items.Add(rubro.descripcion);
            }
        }

    }
}
