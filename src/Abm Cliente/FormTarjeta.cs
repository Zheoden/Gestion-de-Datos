using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Abm_Cliente {
    public partial class FormTarjeta : Form {
        public FormTarjeta() {
            InitializeComponent();
            cmbTipos.Items.Add("Visa");
            cmbTipos.Items.Add("MasterCard");
            cmbTipos.Items.Add("AmericanExpress");
        }

        private void btnCerrar_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btnDarAlta_Click(object sender, EventArgs e) {
            long numero = 0;
            int mes;
            int anio;
            if (txtCodSeg.Text != "" && txtNumero.Text != "" && txtTitular.Text != "" && txtVencimiento.Text != "" && cmbTipos.SelectedItem.ToString() != "") {
                if (txtNumero.Text.Length == 16 && long.TryParse(txtNumero.Text, out numero)) {
                    try {
                        string aux = txtVencimiento.Text.Split('/')[0];
                        string aux1 = txtVencimiento.Text.Split('/')[1];
                        mes = Convert.ToInt32(aux);
                        anio = Convert.ToInt32(aux1);

                    }catch(Exception){
                        MessageBox.Show("Formato de fecha incorrecta.");
                        return;
                    }
                    if (txtVencimiento.Text.Length == 5 && mes > 00 && mes < 13 && anio > 19 && anio < 24) {
                        if (txtCodSeg.Text.Length == 3 && long.TryParse(txtCodSeg.Text, out numero)) {
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else {
                            MessageBox.Show("El codigo tiene que tener 3 numeros.");
                        }
                    }
                    else {
                        MessageBox.Show("El fecha de vencimiento invalida.");
                    }
                }
                else {
                    MessageBox.Show("El Numero de tarjeta debe contener unicamente 16 numeros.");
                }
            }
            else {
                MessageBox.Show("Todos los campos son obligatorios, por favor verifique que toda la informacion sea correcta e intente nuevamente");
            }
        }
    }
}
