using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form nextForm = (Form)Activator.CreateInstance(null, "PalcoNet" + "." + "Abm_Rol" + "." + "Form1").Unwrap();
            nextForm.Show();
        }
    }
}
