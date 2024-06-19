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
    public partial class form3 : Form
    {
        public form3()
        {
            InitializeComponent();
        }

        private void regresar_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int cod;
            string nom;
            float precio;

            cod = comboBox1.SelectedIndex;
            nom = comboBox1.SelectedItem.ToString();
            precio = comboBox1.SelectedIndex;

            switch (cod)
            {
                case 0: lblCodigo.Text = "01"; break;
                case 1: lblCodigo.Text = "02"; break;
                case 2: lblCodigo.Text = "03"; break;
                case 3: lblCodigo.Text = "04"; break;
                default: lblCodigo.Text = "04";break;

            }
            switch (nom)
            {
                case "Inyeccion": lblNombre.Text = "Inyeccion"; break;
                case "Paraetamol": lblNombre.Text = "Paracetamol"; break;
                case "Pastilla dia sig": lblNombre.Text = "Pastilla dia sig"; break;
                case "Lodatirina": lblNombre.Text = "Lodatirina"; break;
                default: lblNombre.Text = "Ibuprofeno";break;
            }

            switch (precio)
            {
                case 0: lblPrecio.Text = "50"; break;
                case 1: lblPrecio.Text = "45"; break;
                case 2: lblPrecio.Text = "55"; break;
                case 3: lblPrecio.Text = "20"; break;
                default: lblPrecio.Text = "70"; break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtCantidad.Text.Equals(""))
            {
                MessageBox.Show("Ingrese la cantidad por favor", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(txtCantidad.Text, "[1-20]"))
            {
                MessageBox.Show("La cantidad tiene que ser entre 1 y 20", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
            DataGridViewRow file = new DataGridViewRow();
            file.CreateCells(dgvLista);

            file.Cells[0].Value = lblCodigo.Text;
            file.Cells[1].Value = lblNombre.Text;
            file.Cells[2].Value = lblPrecio.Text;
            file.Cells[3].Value = txtCantidad.Text;
            file.Cells[4].Value = (float.Parse(lblPrecio.Text) * float.Parse(txtCantidad.Text)).ToString();

            dgvLista.Rows.Add(file);

            lblCodigo.Text = lblNombre.Text = lblPrecio.Text = txtCantidad.Text = "";

            obtenerTotal();

            }
        }

        public void obtenerTotal()
        {
            float costot = 0;
            int contador = 0;

            contador = dgvLista.RowCount;
            
            for (int i = 0; i < contador; i++)
            {
                costot += float.Parse(dgvLista.Rows[i].Cells[4].Value.ToString());
            }

            lblTotalPagar.Text = costot.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult rppta = MessageBox.Show("¿Desea eliminar producto?",
                    "Eliminacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (rppta == DialogResult.Yes)
                {
                    dgvLista.Rows.Remove(dgvLista.CurrentRow);
                }
            }
            catch { }
            obtenerTotal();
        }

        private void txtEfectivo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lblDevolucion.Text = (float.Parse(txtEfectivo.Text) - float.Parse(lblTotalPagar.Text)).ToString();
            }
            catch
            {

            }
            if (txtEfectivo.Text == "")
            {
                lblDevolucion.Text = "";
            }
        }
        int Numtickt = 0;
        private void btnVender_Click(object sender, EventArgs e)
        {
            if (txtEfectivo.Text.Equals(""))
            {
                MessageBox.Show("Ingrese la cantidad con la que pagara, por favor", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

            else
            {
                clsFactura.CreaTicket Ticket1 = new clsFactura.CreaTicket();

                Ticket1.TextoCentro("FARMACIA SNAKE ");
                Ticket1.TextoCentro("************");

                Ticket1.TextoIzquierda("");
                Ticket1.TextoCentro("Ticket de Venta");
                Ticket1.TextoIzquierda("No ticket: " + Numtickt);
                Ticket1.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());
                Ticket1.TextoIzquierda("Sucursal SanPedro");
                Ticket1.TextoIzquierda("");
                clsFactura.CreaTicket.LineasGuion();

                clsFactura.CreaTicket.EncabezadoVenta();
                clsFactura.CreaTicket.LineasGuion();
                foreach (DataGridViewRow r in dgvLista.Rows)
                {

                    Ticket1.AgregaArticulo(r.Cells[1].Value.ToString(), double.Parse(r.Cells[2].Value.ToString()), int.Parse(r.Cells[3].Value.ToString()), double.Parse(r.Cells[4].Value.ToString())); //imprime una linea de descripcion
                }


                clsFactura.CreaTicket.LineasGuion();
                Ticket1.TextoIzquierda(" ");
                Ticket1.AgregaTotales("Total", double.Parse(lblTotalPagar.Text)); // imprime linea con total
                Ticket1.TextoIzquierda(" ");
                Ticket1.AgregaTotales("Efectivo Entregado:", double.Parse(txtEfectivo.Text));
                Ticket1.AgregaTotales("Efectivo Devuelto:", double.Parse(lblDevolucion.Text));




                Ticket1.TextoIzquierda(" ");
                Ticket1.TextoCentro("************");
                Ticket1.TextoCentro("*     Gracias por preferirnos    *");

                Ticket1.TextoCentro("************");
                Ticket1.TextoIzquierda(" ");
                string impresora = "Microsoft XPS Document Writer";
                Ticket1.ImprimirTicket(impresora);

                MessageBox.Show("Gracias por preferirnos");
                txtCantidad.Clear();
                txtEfectivo.Clear();
                dgvLista.Rows.Clear();
                lblTotalPagar.Text = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form5 f = new Form5();
            f.Show();
            this.Close();
        }

        private void dgvLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblCodigo_Click(object sender, EventArgs e)
        {

        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {

        }
    }
}



