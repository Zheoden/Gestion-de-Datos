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

        private void btnAlta_Click(object sender, EventArgs e) {
            Publicacion publi = new Publicacion();
            Espectaculo espec = new Espectaculo();
//            Rubro rubro = new Rubro();
            Direccion direccion = new Direccion();
            Grado grado = new Grado();

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
                //precio
                //rubro
                grado.prioridad = cmbGrado.SelectedItem.ToString().Split(';')[0].Split(':')[1];
                grado.comision = Int32.Parse(cmbGrado.SelectedItem.ToString().Split(';')[1].Split(':')[1]);
                grado.porcentaje = Int32.Parse(cmbGrado.SelectedItem.ToString().Split(';')[2].Split(':')[1]);
                grado = DBHelper.getGrado(grado.prioridad, grado.comision, grado.porcentaje);
                Estado estado = DBHelper.getEstado(cmbEstado.SelectedItem.ToString());

                publi.descripcion = txtDescripcion.Text;
                publi.stock = Int32.Parse(txtStock.Text);
                publi.user = VariablesGlobales.usuario;
                publi.estado = estado;
                publi.grado = grado;

                espec.codigo = publi.codigo;
                espec.descripcion = publi.descripcion;
                espec.direccion = direccion;
                espec.estado = estado;

                publi.espectaculo = espec;

                foreach (DateTime item in cmbFechaEspectaculo.Items) {
                    publi.codigo = DBHelper.publicacionGetNextCod();
                    publi.fecha_evento = item;
                    espec.fecha_venc = item;
                    if (DBHelper.altaEspectaculo(espec)) {
                        if (DBHelper.altaPublicacion(publi)) {
                            MessageBox.Show("Se creo la publicacion correctamente.");
                        }
                        else {
                            MessageBox.Show("Se produjo un error insertando la Publicacion.");
                        }
                    }
                    else {
                        MessageBox.Show("Se produjo un error insertando el espectaculo.");
                    }

                }

                /* Creo el Cliente */
               /* if (!DBHelper.altaCliente(cliente)) {
                    MessageBox.Show("Se produjo un error al intentar dar de alta el Cliente");
                }
                else {
                    MessageBox.Show("El cliente se creo correctamente.");
                    this.Close();
                }*/
            }
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
            if (txtDescripcion.Text != "" && txtStock.Text != "" && txtPrecio.Text != "" && txtRubro.Text != "" && txtUsuarioResponsable.Text != "" && dtpEspectaculo.Text != "" && cmbDireccion.Items.Count > 0 && cmbEstado.Text != "" && cmbGrado.Text != "") {
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

        private void salirToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

    }
}
