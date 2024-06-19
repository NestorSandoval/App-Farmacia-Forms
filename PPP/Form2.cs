using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPP
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            txtNombre.Text = Session.nombre;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
          
        }

        private void cerrarform(object sender , EventArgs e)
        {
            Form1 frmprincipal = new Form1();
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            form3 f = new form3();
            f.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4();
            f.Show();
            this.Close();
        }

        private void salir_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void lblUsernme_Click(object sender, EventArgs e)
        {

        }
    }
}
