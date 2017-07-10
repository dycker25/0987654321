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
    public partial class terminadoView : Form
    {
        //de igual manera para poder usar los metodos de la base de datos y controller hay que instanciar
        public TerminadoDTO newTerminado;
        private TerminadoCon con = new TerminadoCon();
        private loginView logi = new loginView();
        private short idTerminado;
        public terminadoView()
        {
            InitializeComponent();
            cargarDatos();
        }

        
      
        private void button1_Click(object sender, EventArgs e)  
        {
            try
            {

                if (newTerminado == null)
                {
                    newTerminado = new TerminadoDTO();
                }

                if (newTerminado.Id == 0)
                {
                    newTerminado.IdTerminado = txtidterminado.Text;
                    if (con.ObtenerTerminadoID(txtidterminado.Text))
                    {
                        newTerminado.FdechaResepcion = DateTime.Now;
                        newTerminado.NumeroPiezas = 0;
                        LavanderiaCon conlav = new LavanderiaCon();
                        newTerminado.IdLavanderia = conlav.ObtenerLavanderia( Convert.ToInt16(cbxLavanderia.SelectedValue)).IdPrenda;
                        newTerminado.IdUsuario = logi.User().Id;
                        newTerminado.Estado = false;
                        
                        if (con.AgregarTerminado(newTerminado))
                        {
                            MessageBox.Show("El proceso terminado se agrego correctamente");
                            limpiar();
                            List<LavanderiaDTO> lava = new List<LavanderiaDTO>();
                            cbxLavanderia.DataSource = lava;
                            cargarDatos();

                        }
                    }
                    else
                    {
                        MessageBox.Show("El Id corte ya existe");
                    }
                }
                else
                {
                    newTerminado.FdechaResepcion = DateTime.Now;
                    newTerminado.NumeroPiezas = 0;
                    if (Convert.ToInt32(cbxLavanderia.SelectedValue) > 0)
                                            newTerminado.IdLavanderia = Convert.ToInt16(cbxLavanderia.SelectedValue);
                         
                    
                    newTerminado.IdUsuario = logi.User().Id;
                    newTerminado.Estado = false;
                    if (con.ActualizarTerminado(newTerminado))
                    {
                        MessageBox.Show("El proceso terminado se actualizo correctamente");
                        limpiar();
                        cargarDatos();
                        newTerminado = null;
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        
        private void button3_Click(object sender, EventArgs e)
        {

            string message =
         "Desea eliminar al proceso terminado " + newTerminado.IdTerminado + "?";
            const string caption = "Form Closing";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Exclamation);

            // If the no button was pressed ...
            if (result == DialogResult.Yes)
            {
               
                if (con.EliminarTerminado(newTerminado.Id))
                {
                    MessageBox.Show("Se elimino correctamente");
                    limpiar();
                    btnEliminar.Visible = false;
                    cargarDatos();
                    btnTermina.Visible = false;
                }
            }
        }
        
          
       
        private void button1_Click_2(object sender, EventArgs e)
        {
             try
             {
                 int x; 
                 LavanderiaCon lav = new LavanderiaCon();
                 int PiezasTerminado = lav.ObtenerCantidadPiezasLavanderia(newTerminado.IdPrenda);
                 cantidadView c = new cantidadView();
                 c.LoadOrders("Cantidad", PiezasTerminado);
                    c.ShowDialog();
                    x = c.CantidadACt;
                    c.Close();
                    if (x > 0)
                    {
                        string message =
              "Desea marcar el proceso como terminado?";
                        const string caption = "Form Closing";
                        var result = MessageBox.Show(message, caption,
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Exclamation);


                        // If the no button was pressed ...
                        if (result == DialogResult.Yes)
                        {
                          


                            newTerminado = new TerminadoDTO();
                            newTerminado.Id =  idTerminado;
                            newTerminado.FechaEntrega = DateTime.Now;

                            newTerminado.NumeroPiezas = x;
                            newTerminado.IdUsuario = logi.User().Id;
                            newTerminado.Estado = true;

                            if (con.ActualizarTerminadoPreceso(newTerminado))
                            {
                                limpiar();
                                cargarDatos();
                                MessageBox.Show("A finalizado el Proceso");
                               

                            }
                        }

                    }
                    else
                        MessageBox.Show("El proceso no puede ser terminado con 0 Prendas terminadas");
                }
                catch (Exception ex)
                {


                }
        }

        private void datGrViTerminado_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (logi.User().Permiso.Terminado)
            {
                try
                {

                    int id = dgvTerminado.CurrentRow.Index;

                     idTerminado = Convert.ToInt16(dgvTerminado[0, id].Value);

                    newTerminado = con.ObtenerTerminado(idTerminado);
                    txtidterminado.Text = newTerminado.IdTerminado;

                    cbxLavanderia.SelectedItem = newTerminado.IdLavanderia;
                    
                    btnEliminar.Visible = true;
                    btnTermina.Visible = true;

                }
                catch (Exception ex)
                {

                    throw;
                }
            }
        }

        private void cargarDatos()
        {
            TerminadoCon con = new TerminadoCon();
            dgvTerminado.DataSource = con.ObtenerListaProcesoTerminado();
            dgvTerminado.Columns[0].Visible = false;

            cbxLavanderia.DataSource = con.ObtenerListaProcesoLavanderiaTerminado();
            cbxLavanderia.DisplayMember = "Descripcion";
            cbxLavanderia.ValueMember = "Id";

            NumeroLavanderia();
            btns();
        }
        private void NumeroLavanderia()
        {
            TerminadoCon con = new TerminadoCon();
            txtidterminado.Text = "Terminado" + (1 + con.NumeroTerminado());
        }
        private void limpiar()
        {
            txtidterminado.Text = ""; 
        }

        private void imagenIR_Click(object sender, EventArgs e)
        {
            bodegaView maq = new bodegaView();
            maq.Show();
            Close();

        }

        private void btns()
        {
            if (logi.User().Permiso.Almacen)
            {
                imagenIR.Visible = true;
            }

        }

        
    }
}
