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
    public partial class lavanderiaView : Form
    {


        private loginView logi= new loginView();
        private LavanderiaDTO newLavanderia;
        controller.LavanderiaCon lav = new controller.LavanderiaCon();
        


        public lavanderiaView()
        {
            InitializeComponent();
            cargarDadots();


        }

        private void txtidlavanderia_TextChanged(object sender, EventArgs e)
        {

        }


        private void limpiar()
        {

            txtidlavanderia.Text = "";
            cbbMaquila.Text = "";
            cbbProcesos.Text = "";

        }

        private void cargarDadots()
        {
            
                cbbProcesos.DataSource = lav.ListaProcesos();
            cbbProcesos.DisplayMember = "IdLavanderia";
            cbbProcesos.ValueMember = "Id";

            cbbMaquila.DataSource = lav.ListaProcesosMaquilaSinTerminar();
            cbbMaquila.DisplayMember = "IdLavanderia";
            cbbMaquila.ValueMember = "Id";

            dgvLavanderia.DataSource = lav.ListaPorcesoLavanderiaSinTerminar();
            dgvLavanderia.Columns[0].Visible = false;

            NumeroLavanderia();
             btns();
        }

        private void NumeroLavanderia()
        {
            LavanderiaCon con = new LavanderiaCon();
            txtidlavanderia.Text = "Lavanderia" + (1 + con.NumeroLavanderia());
        }






        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            if (txtidlavanderia.Text != "" )
            {
                try
                {
                    if (newLavanderia == null)
                    {
                        newLavanderia = new LavanderiaDTO();
                    }

                    if (newLavanderia.Id == 0)
                    {
                        newLavanderia.IdLavanderia = txtidlavanderia.Text;
                        if (lav.ObtenerLavanderiaID(txtidlavanderia.Text))
                        {
                            newLavanderia.FechaRecepcion = DateTime.Now;
                            newLavanderia.NumeroPiezas = 0;
                            newLavanderia.IdUsuario = logi.User().Id;
                         
                            newLavanderia.IdProceso = Convert.ToInt16(cbbProcesos.SelectedValue);
                            MaquilaCon maq = new MaquilaCon(); 
                            newLavanderia.IdMaquila = maq.ObtenerMaquilaProceso( Convert.ToInt16(cbbMaquila.SelectedValue)).IdPrenda;
                            newLavanderia.Estado = false;

                            if (lav.AgregarLavanteria(newLavanderia))
                            {
                                MessageBox.Show("El proceso lavanderia se agrego correctamente");
                                limpiar();
                                cargarDadots();

                            }
                        }
                        else
                        {
                            MessageBox.Show("EL Id ya existe");
                        }
                    }
                    else
                    {
                        newLavanderia.IdLavanderia = txtidlavanderia.Text;
                        newLavanderia.FechaRecepcion = DateTime.Now;
                        newLavanderia.NumeroPiezas = 0;
                        newLavanderia.IdUsuario = logi.User().Id;
                        newLavanderia.IdProceso = Convert.ToInt16(cbbProcesos.SelectedValue);
                        newLavanderia.IdMaquila = Convert.ToInt16(cbbMaquila.SelectedValue);
                        newLavanderia.Estado = false;

                        if (lav.ActualizarLavanteria(newLavanderia))
                        {
                            MessageBox.Show("El proceso se actualizo correctamente");
                            limpiar();
                            cargarDadots();
                            newLavanderia = null;
                        }
                    }
                }
                catch (Exception ex)
                {

                    throw;
                }

            }
        }

        private void btneliminar_Click_1(object sender, EventArgs e)
        {
            
            string message =
         "Desea eliminar el bordado " + newLavanderia.IdLavanderia + "?";
            const string caption = "Form Closing";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Exclamation);

            // If the no button was pressed ...
            if (result == DialogResult.Yes)
            {
                controller.BordadoCon cor = new controller.BordadoCon();
                if (lav.EliminarLavanteria(newLavanderia.Id))
                {
                    MessageBox.Show("Se elimino correctamente");
                    limpiar();
                    btneliminar.Visible = false;
                    cargarDadots();
                    btnTerminado.Visible = false;
                    newLavanderia = null;
                }


            }

        }

        private void btnmodificar_Click_1(object sender, EventArgs e)
        {
            try
            {
                MaquilaCon maq = new MaquilaCon();
                int PiezasMaquila= maq.ObtenerCantidadPiezasMaquila(newLavanderia.IdPrenda);
                int x;
                cantidadView c = new cantidadView();
                c.LoadOrders("Cantidad", PiezasMaquila);
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
                        int id = dgvLavanderia.CurrentRow.Index;


                        newLavanderia = new LavanderiaDTO();
                        newLavanderia.Id = Convert.ToInt16(dgvLavanderia[0, id].Value);


                        newLavanderia.FechaEntrega = DateTime.Now;

                        newLavanderia.NumeroPiezas = x;
                        newLavanderia.IdUsuario = logi.User().Id;
                        newLavanderia.Estado = true;

                        if (lav.ProcesoTerminadoLavandria(newLavanderia))
                        {

                            MessageBox.Show("A finalizado el proceso de lavanderia");
                            limpiar();
                            cargarDadots();
                            btneliminar.Visible = false;
                            btnTerminado.Visible = false;
                            newLavanderia = null;

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

        private void dgvLavanderia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           

            if (logi.User().Permiso.Lavanderia)
            {
                try
                {

                    int id = dgvLavanderia.CurrentRow.Index;

                    short idCorte = Convert.ToInt16(dgvLavanderia[0, id].Value);
                    
                    newLavanderia = lav.ObtenerLavanderia(idCorte);
                    txtidlavanderia.Text = newLavanderia.IdLavanderia;
                    cbbMaquila.SelectedItem = newLavanderia.IdMaquila;
                    cbbProcesos.SelectedItem = newLavanderia.IdProceso;
                    btneliminar.Visible = true;
                    btnTerminado.Visible = true;

                }
                catch (Exception ex)
                {

                    throw;
                }
            }
        }

        private void pbIrMaquila_Click(object sender, EventArgs e)
        {
                    terminadoView maq = new terminadoView();
                maq.Show();
                Close();
            
        }

        private void btns()
        {
            if (logi.User().Permiso.Terminado)
            {
                imagenIR.Visible = true;
            }
        
        }
        }
    }

