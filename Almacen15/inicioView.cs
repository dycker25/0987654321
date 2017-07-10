using Project.BL;
using Project.DTO;
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
    public partial class inicioView : Form
    {
        loginView logi = new loginView();
        
        public inicioView()
        {
          
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void inicio_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Abre la ventana de corte
        /// </summary>
   
        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            
            if (logi.User().Permiso.Admin)
            {
                administradorView adm = new administradorView();
                adm.ShowDialog();
            }
            
        }

        private void toolStripTextBox2_Click(object sender, EventArgs e)
        {
            if (logi.User().Permiso.Corte)
            {
                corteView c = new corteView();
                c.ShowDialog();
            }
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
            if (logi.User().Permiso.Bordado)
            {
                bordadoView bord = new bordadoView();
                bord.Show();
            }
        }

        private void toolStripTextBox3_Click(object sender, EventArgs e)
        {
            
            if (logi.User().Permiso.Maquila)
            {
                maquilaView m = new maquilaView();
                m.Show();
            }
        }

        private void toolStripComboBox2_Click(object sender, EventArgs e)
        {
            if (logi.User().Permiso.Lavanderia)
            {
                lavanderiaView l = new lavanderiaView();
                l.Show();
            }
        }

        private void toolStripTextBox4_Click(object sender, EventArgs e)
        {
            if (logi.User().Permiso.Terminado)
            {
                terminadoView t = new terminadoView();
                t.Show();
            }
        }

        private void toolStripTextBox5_Click(object sender, EventArgs e)
        {
            if (logi.User().Permiso.Almacen)
            {
                bodegaView boga = new bodegaView();
                boga.Show();
            }
        }

        private void toolStripTextBox6_Click(object sender, EventArgs e)
        {
            if (logi.User().Permiso.Venta)
            {
                ventaView v = new ventaView();
                v.Show();
            }
        }

        private void inicio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F1)
            {
                if (logi.User().Permiso.Corte)
                {
                    corteView at = new corteView();
                    at.Show();
                }
            }
            if (e.KeyData == Keys.F2)
            {
                if (logi.User().Permiso.Bordado)
                {
                    bordadoView at = new bordadoView();
                    at.Show();
                }

            }
            if (e.KeyData == Keys.F3)
            {
                if (logi.User().Permiso.Maquila)
                {
                    maquilaView maq = new maquilaView();
                    maq.Show();
                }

            }
            if (e.KeyData == Keys.F4)
            {
               
            }
            if (e.KeyData == Keys.F5)
            {
               

            }
            if (e.KeyData == Keys.F6)
            {
               
            }
            if (e.KeyData == Keys.F7)
            {
              
            }
            if (e.KeyData == Keys.F8)
            {
               

            }
            if (e.KeyData == Keys.F9)
            {
              

            }
            if (e.KeyData == Keys.F12)
            {
              

                if (logi.User().Permiso.Admin)
                {
                    administradorView admin = new administradorView();
                    admin.ShowDialog();
                }

            }
        }

        private void toolStripTextBox8_Click(object sender, EventArgs e)
        {
           if (logi.User().Permiso.Venta)
           {
              pantalonView pan = new pantalonView();
              pan.Show();
           }

        }
    }
}
