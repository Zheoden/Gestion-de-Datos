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

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            conn.Open();
            string SQL = "SELECT dire_id FROM EL_REJUNTE.Direccion WHERE dire_id=1";
            SqlCommand command = new SqlCommand(SQL, conn);
            command.Connection = conn;
            command.CommandType = CommandType.Text;

            SqlDataReader reader = command.ExecuteReader() as SqlDataReader;

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    MessageBox.Show(reader["dire_id"].ToString());
                }
            }

            Connection.close(conn);
        }
    }
}
