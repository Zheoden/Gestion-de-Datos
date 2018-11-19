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
using PalcoNet.Utils;
using PalcoNet.Objetos;

namespace PalcoNet.Abm_Cliente {
    public partial class FormAlta : Form {
        public FormAlta() {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btnAgregarTarj_Click(object sender, EventArgs e) {
            if (cmbTarjeta.Items.Count == 0) {
                FormTarjeta testDialog = new FormTarjeta();
                if (testDialog.ShowDialog(this) == DialogResult.OK) {
                    cmbTarjeta.Items.Add("Datos de la Tarjeta(Numero;Titular;Vencimiento;Tipo;Codigo de Seguidad): " + testDialog.txtNumero.Text + "#" + testDialog.txtTitular.Text + "#" + testDialog.txtVencimiento.Text + "#" + testDialog.cmbTipos.Text + "#" + testDialog.txtCodSeg.Text);
                }
            }
            else {
                MessageBox.Show("Solo se puede ingregar una tarjeta");
            }
        }

        private void btnEliminarTarj_Click(object sender, EventArgs e) {
            cmbTarjeta.Items.Remove(cmbTarjeta.SelectedItem);
        }

        private void btnAgregarDire_Click(object sender, EventArgs e) {
            if (cmbDireccion.Items.Count == 0) {
                FormDireccion testDialog = new FormDireccion();
                if (testDialog.ShowDialog(this) == DialogResult.OK) {
                    cmbDireccion.Items.Add("Datos de la direccion(Calle;Numero;Piso;Departamento;Localidad;Codigo Postal): " + testDialog.txtCalle.Text + "#" + testDialog.txtNumero.Text + "#" + testDialog.txtPiso.Text + "#" + testDialog.txtDepartamento.Text + "#" + testDialog.txtLocalidad.Text + "#" + testDialog.txtCodigoPostal.Text);
                }
            }
            else {
                MessageBox.Show("Solo se puede ingregar una direccion");
            }
        }

        private void btnEliminarDire_Click(object sender, EventArgs e) {
            cmbDireccion.Items.Remove(cmbDireccion.SelectedItem);
        }

        private void btnAlta_Click(object sender, EventArgs e) {
            Tarjeta tarjeta = new Tarjeta();
            Direccion direccion = new Direccion();
            Cliente cliente = new Cliente();

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

                /* Agrego todas las tarjetas */
                foreach (string item in cmbTarjeta.Items) {
                    string[] items = item.Split('#');
                    tarjeta.numero = items[0].Split(':')[1].Substring(1);
                    tarjeta.titular = items[1].ToString();
                    tarjeta.vencimiento = items[2].ToString();
                    tarjeta.tipo = items[3].ToString();
                    tarjeta.cod_seguridad = items[4].ToString();

                    if (!DBHelper.altaDeTarjeta(tarjeta)) {
                        MessageBox.Show("Se produjo un error intenta dar de alta la tarjeta.");
                    }
                }
                cliente.nombre = txtNombre.Text;
                cliente.apellido = txtApellido.Text;
                cliente.tipo_documento = txtTipoDoc.Text;
                cliente.documento = txtDocumento.Text;
                cliente.cuil = txtCuil.Text;
                cliente.mail = txtMail.Text;
                cliente.telefono = txtTelefono.Text;
                cliente.dire = direccion;
                cliente.tarjeta = tarjeta;

                /* Creo el Cliente */
                if (!DBHelper.altaCliente(cliente)) {
                    MessageBox.Show("Se produjo un error al intentar dar de alta el Cliente");
                }
                else {
                    MessageBox.Show("El cliente se creo correctamente.");
                    this.Close();
                }
            }
        }

        private Boolean validarDatos(){

            if (txtNombre.Text != "" && txtApellido.Text != "" && txtDocumento.Text != "" && txtCuil.Text != "" && txtMail.Text != "" && txtTelefono.Text != "" && dtpFechaNac.Text != "" && cmbDireccion.Items.Count > 0 && cmbTarjeta.Items.Count > 0) {
                if (txtCuil.Text.Length == 11 && (txtCuil.Text.Substring(0,2) == "20" || txtCuil.Text.Substring(0,2) == "23" || txtCuil.Text.Substring(0,2) == "24" || txtCuil.Text.Substring(0,2) == "27" || txtCuil.Text.Substring(0,2) == "30" || txtCuil.Text.Substring(0,2) == "33") ) {
                    if (DBHelper.clienteDontExistDocumento(txtTipoDoc.Text, txtDocumento.Text)) {
                        if (DBHelper.clienteDontExistCuil(txtCuil.Text)) {
                            return true;
                        }
                        else {
                            MessageBox.Show("Ya exite un cliente con ese CUIL.");
                        }
                    }
                    else {
                        MessageBox.Show("Ya exite un cliente con ese tipo y numero de documento.");
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

    }
}
