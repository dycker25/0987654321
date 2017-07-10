using almacen_telar.controller;
using almacen_telar.Ob;
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
    public partial class bodegaView : Form
    {
        loginView ligi = new loginView();
        public bodegaView()
        {
            InitializeComponent();
            CargarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string message =
            "Desea Agregar a bodega ?";
            const string caption = "Form Closing";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Exclamation);

            // If the no button was pressed ...
            if (result == DialogResult.Yes)
            {
                if (0 == 0)
                {
                    BodegaCon con = new BodegaCon();
                    short idBodega, IdTerminado, IdUsuario;
                    idBodega = (short)cbbBodega.SelectedValue;
                    IdTerminado = (short)cbbPrendas.SelectedValue;
                    IdUsuario = ligi.User().Id;
                    if (con.AgregarRecibidos(IdTerminado, idBodega, IdUsuario))
                    {
                        AgregarPrenda(IdTerminado, idBodega);
                        MessageBox.Show(" se agrego Correctamente");
                        List<string> lista = new List<string>();
                        cbbPrendas.DataSource = lista;
                        CargarDatos();

                    }
                    else
                    {
                        MessageBox.Show(" NO agrego Correctamente");
                    }
                }
                else
                {
                    //EspesificarCantidades
                }
            }

        }

        private void CargarDatos()
        {
            CargarDatosPrendas();


        CargarDatosTerminados();


         CargarDatosResividas();


        CargarDatosModegas();
        }

        private void CargarDatosPrendas()
        {
            BodegaCon con = new BodegaCon();

            dgvPrendas.DataSource = con.ListaResivido();
            dgvPrendas.Columns[0].Visible = false;
        }
        private void CargarDatosTerminados()
        {
            BodegaCon con = new BodegaCon();
            cbbPrendas.DataSource = con.ListaProcesoTerminado();
            cbbPrendas.DisplayMember = "Descripcion";
            cbbPrendas.ValueMember = "Id";
        }
        private void CargarDatosResividas()
        {
            BodegaCon con = new BodegaCon();
            dgvResivos.DataSource = con.ListaDeprendas();
        }
        private void CargarDatosModegas()
        {
            BodegaCon con = new BodegaCon();

            cbbBodega.DataSource = con.ListaBodegasActivas();
            cbbBodega.DisplayMember = "Descripcion";
            cbbBodega.ValueMember = "Id";
        }

        public void AgregarPrenda(short IdTerminado, short IdBodega)
        {
            try
            {
                BodegaCon con = new BodegaCon();
                List<TerminadoDTO> terminado = con.DetallesDeTerminado(IdTerminado);
               
                foreach (TerminadoDTO item in terminado)
                {
                    short IdPantalon = con.BuscarPrendaExistente(item, IdBodega);
                    if (IdPantalon == 0)
                    {
                        con.AgregarPantalon(item, IdBodega);
                        CargarDatosTerminados();
                    }
                    else
                    {
                        con.ActualizarPantalon(item, IdBodega, IdPantalon);
                        CargarDatosTerminados();
                    }

                }


                            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ExpesificarPrendas()
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           ventaView vent = new ventaView();
           vent.Show();
           Close();
        }

        private void Bodega_Load(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        



    }
}
