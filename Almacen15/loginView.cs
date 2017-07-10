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
       
    public partial class loginView : Form
    {

        public static Usuario _Usuario;    
        
        public loginView()
        {
            InitializeComponent();
           
        }
    
        private void pbxinicio_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text != "" && txtPassword.Text != "")
            {
                UsuarioBL bl = new UsuarioBL();
               _Usuario =  bl.Login(txtUsuario.Text, txtPassword.Text);
                if (_Usuario != null)
                {
                    inicioView Inicio = new inicioView();
                    Visible = false;
                    if (Inicio.ShowDialog() != null)
                    {
                        Visible = true;
                        limpiar();

                    }

                }
                else
                {
                    MessageBox.Show("El usuario o contraseña es incorrecto");
                    limpiar();
                }
 
            }
            
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (txtUsuario.Text != "" && txtPassword.Text != "")
                {
                    UsuarioBL bl = new UsuarioBL();
                    _Usuario = bl.Login(txtUsuario.Text, txtPassword.Text);
                    if (_Usuario != null)
                    {
                        inicioView Inicio = new inicioView();
                        Visible = false;
                        if (Inicio.ShowDialog() != null)
                        {
                            Visible = true;
                            limpiar();
                        }

                    }
                    else
                    {
                        MessageBox.Show("El usuario o contraseña es incorrecto");
                        limpiar();
                    }

                }
            }
        }

        //login
       
        private void limpiar()
        {
            txtPassword.Text = "";
            txtUsuario.Text = "";
        }

        public Usuario User()
        {
            return _Usuario;
            
        }

       
        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData == Keys.F3)
            {
                UsuarioBL bl = new UsuarioBL();

                if (bl.ListaUsuarios().Count == 0)
                {
                    Resources.Config maq = new Resources.Config();
                    maq.ShowDialog();
                }
            }
        }
    }
}
