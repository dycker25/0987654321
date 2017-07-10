using almacen_telar.controller;
using almacen_telar.Ob;
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

namespace almacen_telar.Resources
{
    public partial class Config : Form
    {
        public Config()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioBL bl = new UsuarioBL();

                Permiso _Permisos = new Permiso()
                {
                    Admin = true,
                    Corte = true,
                    Bordado = true,
                    Maquila = true,
                    Lavanderia = true,
                    Terminado = true,
                    Almacen = true,
                    Venta = true,

                };
                PermisosBL blp = new PermisosBL();

                _Permisos.Id = blp.AgregarActualizarPermisos(_Permisos);
                if (_Permisos.Id > 0)
                {
                    Usuario _Usuario = new Usuario()
                   {
                    Nombre = txtNombre.Text,
                    Usuario1 = txtUsuario.Text,
                    contrasena = txtContraseña.Text,
                    IdPermisos = _Permisos.Id,
                    Activo = true
                    };
                    if (bl.AgregarActualizarUsuario(_Usuario))
                    {
                        Close();
                    }
                }



                
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
