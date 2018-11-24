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
using System.Globalization;

namespace PalcoNet.Comprar
{
    public partial class FormComprar : Form
    {
        public FormComprar()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblPubli_Id_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        public void cargarTipo(int Publi_id)
        {
            try
            {
                cboTipo.ValueMember = "tipo_codigo";
                cboTipo.DisplayMember = "tipo_descripcion";
                List<Ubicacion> ubicacionTipos = DBHelper.tiposPorEspectaculo(Publi_id);
                foreach (var ubicacionTipo in ubicacionTipos)
                {
                    cboTipo.Items.Add(ubicacionTipo);
                }

            }
            catch (Exception ex) {
            
            }
        }

    }
}
