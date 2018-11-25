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
using System.Text.RegularExpressions;

namespace PalcoNet.Abm_Empresa_Espectaculo {
    public partial class FormAlta : Form {
        public FormAlta() {
            InitializeComponent();
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

        private void btnAlta_Click(object sender, EventArgs e) {
            Direccion direccion = new Direccion();
            Empresa empresa = new Empresa();

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
                empresa.cuit = txtCuil.Text;
                empresa.mail = txtMail.Text;
                empresa.telefono = txtTelefono.Text;
                empresa.direccion = direccion;

                Usuario user = new Usuario();
                user.username = txtCuil.Text;
                user.password = Encrypt.Sha256(Encrypt.RandomString(9));
                Rol rol = new Rol();
                rol.nombre = "Empresa";
                user.roles = new List<Rol>();

                user.roles.Add(rol);
                /* Creo el Cliente */
                if (DBHelper.altaUsuario(user)) {
                    if (DBHelper.altaEmpresa(empresa)) {
                        MessageBox.Show("La Empresa se creo correctamente.");
                        this.Close();
                    }
                    else {
                        MessageBox.Show("Se produjo un error al intentar dar de alta la Empresa");
                    }
                }
            }
        }

        private Boolean validarDatos() {
            if (txtNombre.Text != "" && txtCuil.Text != "" && txtMail.Text != "" && txtTelefono.Text != "" && cmbDireccion.Items.Count > 0) {

                var regex = @"^(30|33|34)[0-9]{8}[0-9]$";
                var match = Regex.Match(txtCuil.Text, regex, RegexOptions.IgnoreCase);

                if (match.Success) {//txtCuil.Text.Length == 11 && (txtCuil.Text.Substring(0, 2) == "30" || txtCuil.Text.Substring(0, 2) == "33")) {
                    if (DBHelper.EmpresaDontExistCuit(txtCuil.Text)) {
                        return true;
                    }
                    else {
                        MessageBox.Show("Ya exite una empresa con ese CUIT.");
                    }
                }
                else {
                    MessageBox.Show("El cuit es invalido, por favor ingreselo nuevamente");
                }
            }
            else {
                MessageBox.Show("Todos los campos son obligatorios.");
            }
            return false;
        }

        private void btnCerrar_Click(object sender, EventArgs e) {
            this.Close();
        }

    }
}
