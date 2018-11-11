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

namespace PalcoNet.Abm_Rol
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            gb_b_avanzada.Visible = false;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void cb_busquedaAvanzada_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_busquedaAvanzada.Checked)
            {
                gb_b_avanzada.Visible = true;
            }else
            {
                gb_b_avanzada.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            conn.Open();
            string SQL = "SELECT dire_id, dire_calle, dire_numero, dire_piso FROM EL_REJUNTE.Direccion";
            SqlCommand command = new SqlCommand(SQL, conn);

            command.Connection = conn;
            command.CommandType = CommandType.Text;

            SqlDataReader reader = command.ExecuteReader() as SqlDataReader;
            int cont = 0;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[cont].Cells[0].Value = reader["dire_id"].ToString();
                    dataGridView1.Rows[cont].Cells[1].Value = reader["dire_calle"].ToString();
                    dataGridView1.Rows[cont].Cells[2].Value = reader["dire_piso"].ToString();
                    dataGridView1.Rows[cont].Cells[3].Value = reader["dire_numero"].ToString();
                    cont++;
                }
            }

            Connection.close(conn);*/
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
