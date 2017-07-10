using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace almacen_telar
{
    public partial class cantidadView : Form
    {
        public int CantidadACt = 0;
        private string text = "";
              public cantidadView()
        {
            InitializeComponent();
            label1.Text = text;
        }

        internal void LoadOrders(String CustomerID,int NoPiezas)
        {
            label1.Text = CustomerID;
            txtCantidad.Text=   NoPiezas.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtCantidad.Text != "")
            {
                CantidadACt = int.Parse(txtCantidad.Text);
                Visible = false;
            }
            else {
                CantidadACt = 0;
                Visible = false;
            }
        }

        public int cant()
        {
            return CantidadACt;
        }

        private void txtCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (txtCantidad.Text != "")
                {
                    CantidadACt = int.Parse(txtCantidad.Text);
                    Visible = false;
                }
                else
                {
                    CantidadACt = 0;
                    Visible = false;
                }

            }
        }
    }
}
