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

namespace PalcoNet.Abm_Empresa_Espectaculo {
    public partial class FormModificacion : Form {

        Empresa empresa = new Empresa();

        public FormModificacion() {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btnAlta_Click(object sender, EventArgs e) {
            Direccion direccion = new Direccion();

            if (validarDatos()) {
                /* Agrego todas las direcciones */
                foreach (string item in cmbDireccion.Items) {
                    string[] items = item.Split('#');
                    direccion.calle = items[0].Split(':')[1].Substring(1);
                    direccion.numero = items[1].ToString();
                    direccion.piso = items[2].ToString();
                    direccion.depto = items[3].ToString();
                    direccion.localidad = items[4].ToString();
                    direccion.codigo_postal = items[5].ToString();

                    if (!DBHelper.altaDeDireccion(direccion)) {
                        MessageBox.Show("Se produjo un error intenta dar de alta la direccion.");
                    }
                }

                empresa.razon_social = txtNombre.Text;
                empresa.cuit = txtCUIT.Text;
                empresa.mail = txtMail.Text;
                empresa.direccion = direccion;
                empresa.telefono = txtTelefono.Text;
                empresa.baja_logica = cbHabilitado.Checked;

                /* Creo el Cliente */
                if (!DBHelper.modificarEmpresa(empresa)) {
                    MessageBox.Show("Se produjo un error al intentar modificar la empresa");
                }
                else {
                    MessageBox.Show("La empresa se modifico correctamente.");
                    this.Close();
                }
            }
        }

        private void btnAgregarDire_Click(object sender, EventArgs e) {
            if (cmbDireccion.Items.Count == 0) {
                Forms_Comunes.FormDireccion testDialog = new Forms_Comunes.FormDireccion();
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

        private Boolean validarDatos() {
            if (txtNombre.Text == empresa.razon_social && txtCUIT.Text == empresa.cuit && txtMail.Text == empresa.mail && txtTelefono.Text == empresa.telefono && cmbDireccion.Items.Count > 0) {
                return true;
            }
            if (txtNombre.Text != "" && txtCUIT.Text != "" && txtMail.Text != "" && txtTelefono.Text != "" && cmbDireccion.Items.Count > 0) {
                if (txtTelefono.Text.Length == 11 && (txtTelefono.Text.Substring(0, 2) == "20" || txtTelefono.Text.Substring(0, 2) == "23" || txtTelefono.Text.Substring(0, 2) == "24" || txtTelefono.Text.Substring(0, 2) == "27" || txtTelefono.Text.Substring(0, 2) == "30" || txtTelefono.Text.Substring(0, 2) == "33")) {
                    if (DBHelper.EmpresaDontExistCuit(empresa.cuit) || empresa.cuit == txtCUIT.Text) {
                        return true;
                    }
                    else {
                        MessageBox.Show("Ya exite una empresa con ese CUIT.");
                    }
                }
                else {
                    MessageBox.Show("El cuil es invalido, por favor ingreselo nuevamente");
                }
            }
            else {
                MessageBox.Show("Todos los campos son obligatorios.");
            }
            return false;
        }

        private void FormModificacion_Load(object sender, EventArgs e) {
            cargarEmpresa();
        }

        private void cargarEmpresa() {

            empresa = DBHelper.cargarEmpresa(Int32.Parse(txtID.Text));
            txtNombre.Text = empresa.razon_social;
            txtCUIT.Text = empresa.cuit;
            txtMail.Text = empresa.mail;
            txtTelefono.Text = empresa.telefono;
            cbHabilitado.Checked = empresa.baja_logica;
            cmbDireccion.Items.Add("Datos de la direccion(Calle;Numero;Piso;Departamento;Localidad;Codigo Postal): " + empresa.direccion.calle + "#" + empresa.direccion.numero + "#" + empresa.direccion.piso + "#" + empresa.direccion.depto + "#" + empresa.direccion.localidad + "#" + empresa.direccion.codigo_postal);
            cmbDireccion.SelectedItem = "Datos de la direccion(Calle;Numero;Piso;Departamento;Localidad;Codigo Postal): " + empresa.direccion.calle + "#" + empresa.direccion.numero + "#" + empresa.direccion.piso + "#" + empresa.direccion.depto + "#" + empresa.direccion.localidad + "#" + empresa.direccion.codigo_postal;
        }
    }
}
