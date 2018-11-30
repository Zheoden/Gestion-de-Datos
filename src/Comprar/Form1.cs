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
using System.Threading;

namespace PalcoNet.Comprar {
    public partial class Form1 : Form {
        /*private static int totalRecords = DBHelper.publicacionesHabilitadas().Count;
        private const int pageSize = 100;*/

        public Form1() {
            InitializeComponent();
            cargarCategorias();
            /*
                        bindingNavigator1.BindingSource = bindingSource1;
                        bindingSource1.CurrentChanged += new System.EventHandler(bindingSource1_CurrentChanged);
                        bindingSource1.DataSource = new PageOffsetList();*/

        }

        /*  private void bindingSource1_CurrentChanged(object sender, EventArgs e) {
              // The desired page has changed, so fetch the page of records using the "Current" offset 
              int offset = (int)bindingSource1.Current;
              var records = new List<Compra>();
              for (int i = offset; i < offset + pageSize && i < totalRecords; i++) {
                  Compra test = new Compra();
                  records.Add(DBHelper.publicacionesHabilitadas()[i]);
              }
              dgvEspectaculos.DataSource = records;
          }

          class PageOffsetList : System.ComponentModel.IListSource {
              public bool ContainsListCollection { get; protected set; }

              public System.Collections.IList GetList() {
                  // Return a list of page offsets based on "totalRecords" and "pageSize"
                  var pageOffsets = new List<int>();
                  for (int offset = 0; offset < totalRecords; offset += pageSize)
                      pageOffsets.Add(offset);
                  return pageOffsets;
              }
          }*/


        public void cargarCategorias() {
            cboCategoria.ValueMember = "id";
            cboCategoria.DisplayMember = "descripcion";
            List<Rubro> rubros = DBHelper.getRubros();
            foreach (Rubro rubro in rubros) {
                cboCategoria.Items.Add(rubro);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e) {
            txtDescripcion.Text = "";
            dgvEspectaculos.Rows.Clear();
            dgvEspectaculos.Refresh();
        }

        private void Form1_Load(object sender, EventArgs e) {

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

        private void btnContinuar_Click(object sender, EventArgs e) {
            if (dgvEspectaculos.SelectedCells.Count > 0) {
                int selectedrowindex = dgvEspectaculos.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvEspectaculos.Rows[selectedrowindex];
                string espectaculo = Convert.ToString(selectedRow.Cells["publi_descripcion"].Value);
                if (espectaculo != "") {
                    string respuesta = Microsoft.VisualBasic.Interaction.InputBox("Se va a proceder a realizar la compra del espectaculo: " + espectaculo.ToUpper() + ", esta seguro que desea comprarlo? Se le van a realizar cargos a su tarjeta asociada.\nEscriba SI para confirmar la operacion.", "Confirmacion");
                    if (respuesta.ToUpper() == "SI") {
                        if (!DBHelper.clienteTieneTarjeta(DBHelper.clienteGetId(VariablesGlobales.usuario.id))) {
                            if (VariablesGlobales.usuario.id != 1) {
                                MessageBox.Show("UPS, lamentamos el inconveniente pero se detecto que no tiene una tarjeta asociada, para continuar porfavor ingrese su tarjeta. ");
                                Forms_Comunes.FormTarjeta testDialog = new Forms_Comunes.FormTarjeta();
                                if (testDialog.ShowDialog(this) == DialogResult.OK) {
                                    Tarjeta tarjeta = new Tarjeta();
                                    tarjeta.numero = testDialog.txtNumero.Text;
                                    tarjeta.titular = testDialog.txtTitular.Text;
                                    tarjeta.vencimiento = testDialog.txtVencimiento.Text;
                                    tarjeta.tipo = testDialog.cmbTipos.Text;
                                    tarjeta.cod_seguridad = testDialog.txtCodSeg.Text;
                                    if (DBHelper.altaDeTarjeta(tarjeta) && DBHelper.asociarTarjeta(tarjeta)) {
                                        MessageBox.Show("Gracias por asociar una tarjeta, vuelva a seleccionar el espectaculo para poder comprarlo.");
                                    }
                                    else {
                                        MessageBox.Show("Se produjo un error intenta dar de alta la tarjeta.");
                                    }
                                }
                                else {
                                    MessageBox.Show("Se cancelo la operacion actual.");
                                }
                            }
                            else {
                                MessageBox.Show("Se detecto que se está operando con el usuario \"admin\", este usuario no puede realizar compras, por favor entre con un usuario Cliente.");
                            }
                        }
                        else {
                            /* Aca se acepta esta todo valido y se procede al pago de las entradas. */
                            Publicacion publi = new Publicacion();
                            publi.rubro = new Rubro();

                            publi.descripcion = Convert.ToString(selectedRow.Cells["publi_descripcion"].Value);
                            publi.fecha_inicio = Convert.ToDateTime(selectedRow.Cells["publi_fecha_inicio"].Value);
                            publi.fecha_evento = Convert.ToDateTime(selectedRow.Cells["publi_fecha_evento"].Value);
                            publi.stock = Convert.ToInt32(selectedRow.Cells["publi_stock"].Value);
                            publi.rubro.descripcion = Convert.ToString(selectedRow.Cells["rubro_descripcion"].Value);
                            int id_publicacion = DBHelper.publicacionGetID(publi);

                            DBHelper.publicacionModificarStock(id_publicacion, publi.stock - 1);
                            int id_compra = DBHelper.comprar();
                            DBHelper.altaUbicacion_Compra(id_publicacion, id_compra);
                            DBHelper.clienteAcreditarPuntos(DBHelper.clienteGetId(VariablesGlobales.usuario.id), Convert.ToInt32(selectedRow.Cells["ubica_precio"].Value));


                            using (Forms_Comunes.FormEspera frm = new Forms_Comunes.FormEspera(saveData)) {
                                frm.ShowDialog(this);
                            }
                            MessageBox.Show("Operacion realizada con exito!");
                            dgvEspectaculos.Rows.Clear();
                            dgvEspectaculos.Refresh();
                        }
                    }
                    else {
                        MessageBox.Show("Se cancelo la operacion actual.");
                    }
                }
                else {
                    MessageBox.Show("Seleccionó una celda invalida, por favor seleccione otra.");
                }
            }
            else {
                MessageBox.Show("Utilice el buscador para encontrar los espectaculos que mas le gusten!!!");
            }
        }

        private void saveData() {

            for (int i = 0; i <= 500; i++) {
                Thread.Sleep(10);
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e) {
            if (dtpDesde.Value > DateTime.Today) {
                dgvEspectaculos.Rows.Clear();
                dgvEspectaculos.Refresh();
                List<Compra> compras = new List<Compra>();
                if (cboCategoria.Text != "" && txtDescripcion.Text != "") {
                    compras = DBHelper.publicacionesHabilitadas(cboCategoria.Text, txtDescripcion.Text, dtpDesde.Value, dtpHasta.Value);
                }
                else if (cboCategoria.Text != "") {
                    compras = DBHelper.publicacionesHabilitadasRubro(cboCategoria.Text, dtpDesde.Value, dtpHasta.Value);
                }
                else if (txtDescripcion.Text != "") {
                    compras = DBHelper.publicacionesHabilitadasDesc(txtDescripcion.Text, dtpDesde.Value, dtpHasta.Value);
                }
                else {
                    compras = DBHelper.publicacionesHabilitadas(dtpDesde.Value, dtpHasta.Value);
                }
                int cont = 0;
                foreach (Compra compra in compras) {
                    dgvEspectaculos.Rows.Add();
                    dgvEspectaculos.Rows[cont].Cells[0].Value = compra.descripcion;
                    dgvEspectaculos.Rows[cont].Cells[1].Value = compra.fecha_publicacion;
                    dgvEspectaculos.Rows[cont].Cells[2].Value = compra.fecha_evento;
                    dgvEspectaculos.Rows[cont].Cells[3].Value = compra.stock;
                    dgvEspectaculos.Rows[cont].Cells[4].Value = compra.rubro;
                    dgvEspectaculos.Rows[cont].Cells[5].Value = compra.precio;
                    cont++;
                }
                if (dgvEspectaculos.Rows.Count < 1) {
                    MessageBox.Show("No se encontraron resultados.");
                }
            }
            else {
                MessageBox.Show("Desde: " + dtpDesde.Value.ToString("yyyy-MM-dd HH:mm:ss") + ", Hasta: " + dtpHasta.Value.ToString("yyyy-MM-dd HH:mm:ss") + ", Hoy: " + DateTime.Today.ToString("yyyy-MM-dd HH:mm:ss"));
                MessageBox.Show("No se pueden buscar eventos pasados, por favor modifique la fecha de inicio.");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {

        }

        private void cerrarAplicacionToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

    }
}
