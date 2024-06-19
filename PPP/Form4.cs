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
    public partial class Form4 : Form
    {
        private int n = 0;
        public Form4()
        {
            InitializeComponent();
        }


        private void tBL_ConsultasBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();


        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'bD_ConsultasDataSet.TBL_Consultas' Puede moverla o quitarla según sea necesario.
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            int n = dgtvConsultas.Rows.Add();

            //Colocamos la informacion
            dgtvConsultas.Rows[n].Cells[0].Value = txtNombre.Text;
            dgtvConsultas.Rows[n].Cells[1].Value = txtApellidos.Text;
            dgtvConsultas.Rows[n].Cells[2].Value = txtEdad.Text;
            dgtvConsultas.Rows[n].Cells[3].Value = txtTelefono.Text;
            dgtvConsultas.Rows[n].Cells[4].Value = txtCorreoelectronico.Text;

            //lipaimos los txt
            txtNombre.Text = "";
            txtApellidos.Text = "";
            txtEdad.Text = "";
            txtTelefono.Text = "";
            txtCorreoelectronico.Text = "";
        }

        private void dgtvConsultas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            n = e.RowIndex;

            if (n != -1)
            {
                lblInformacion.Text = (string)dgtvConsultas.Rows[n].Cells[1].Value;
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (n != -1)
            {
                dgtvConsultas.Rows.RemoveAt(n);
            }
        }

        private void btnGenerarConsulta_Click(object sender, EventArgs e)
        {

            MessageBox.Show("La consulta se ha generado exitosamente");
            if (dgtvConsultas.Rows.Count == 0)
            {
             
            }

            /*else
            {
                clsConsulta.CreaTicket2 Ticket1 = new clsConsulta.CreaTicket2();

                Ticket1.TextoCentro("FARMACIA SNAKE ");
                Ticket1.TextoCentro("************");

                Ticket1.TextoIzquierda("");
                Ticket1.TextoCentro("Ticket de Venta");
                Ticket1.TextoIzquierda("No ticket:");
                Ticket1.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());
                Ticket1.TextoIzquierda("Doctor: NESTOR SANDOVAL");
                Ticket1.TextoIzquierda("");
                clsConsulta.CreaTicket2.LineasGuion();

                clsConsulta.CreaTicket2.EncabezadoVenta();
                clsConsulta.CreaTicket2.LineasGuion();
                foreach (DataGridViewRow r in dgtvConsultas.Rows)
                {

                Ticket1.AgregaArticulo(r.Cells[0].Value.ToString(), double.Parse(r.Cells[1].Value.ToString()), int.Parse(r.Cells[2].Value.ToString()), double.Parse(r.Cells[3].Value.ToString())); //imprime una linea de descripcion
                }

                clsConsulta.CreaTicket2.LineasGuion();
                Ticket1.TextoIzquierda(" ");
                Ticket1.TextoCentro("************");
                Ticket1.TextoCentro("*     Gracias por preferirnos    *");

                Ticket1.TextoCentro("************");
                Ticket1.TextoIzquierda(" ");
                string impresora = "Microsoft XPS Document Writer";
                Ticket1.ImprimirTicket(impresora);

                MessageBox.Show("Gracias por preferirnos");
            } */
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }


        private void txtNombre_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            /*if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar >= 255))
            {
                MessageBox.Show("Solo letras", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }*/
        }

        private void txtApellidos_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            /*if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar >= 255))
            {
                MessageBox.Show("Solo letras", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }*/
        }

        private void txtEdad_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtTelefono_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}


