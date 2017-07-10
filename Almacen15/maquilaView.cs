using almacen_telar.controller;
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
    
    public partial class maquilaView : Form
    {
        private Ob.MaquilaDTO newMaquila;
        private loginView logi = new loginView();
        public maquilaView()
        {
            InitializeComponent();
            cargarDadots();
           
        }
        private void NumeroMAquila()
        {
            MaquilaCon con = new MaquilaCon();
            txtIdmaquila.Text="Maquila"+(1 + con.NumeroMaquila());
        }
        private void btnagregar_Click(object sender, EventArgs e)
        {
            try
            {
                controller.MaquilaCon con = new controller.MaquilaCon();
                if (newMaquila == null)
                {
                    newMaquila = new Ob.MaquilaDTO();
                }

                if (newMaquila.Id == 0)
                {
                    if (con.ObtenerMaquilaID(txtIdmaquila.Text))
                    {
                        newMaquila.IdMaquila = txtIdmaquila.Text;
                        newMaquila.FechaEntrada = DateTime.Now;
                        newMaquila.Cantidad = 0;

                         newMaquila.IdLugarEntrega = Convert.ToInt16(cbbLugarEntrega.SelectedValue);
                  
                        newMaquila.IdUsuario = logi.User().Id;
                        BordadoCon boco = new BordadoCon();
                        newMaquila.IdBordado =boco.ObtenerBordado(  Convert.ToInt16(cbbCorte.SelectedValue)).IdPrenda;
                        newMaquila.Estado = false;

                        if (con.AgregarMaquila(newMaquila))
                        {
                            MessageBox.Show("Agregado correctamente");
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
                    newMaquila.IdMaquila = txtIdmaquila.Text;
                    newMaquila.FechaEntrada = DateTime.Now;
                    newMaquila.Cantidad = 0;

                    newMaquila.IdLugarEntrega = Convert.ToInt16(cbbLugarEntrega.SelectedValue);
                    newMaquila.IdUsuario = logi.User().Id;
                    BordadoCon boco = new BordadoCon();
                    newMaquila.IdBordado = boco.ObtenerBordado(Convert.ToInt16(cbbCorte.SelectedValue)).IdPrenda;
                    newMaquila.Estado = false;

                    if (con.ActualizarMaquila(newMaquila))
                    {
                        MessageBox.Show("Actualizado correcamente");
                        limpiar();
                        cargarDadots();
                        newMaquila = null;
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        private void limpiar()
        {
           
            txtIdmaquila.Text = "";
            cbbLugarEntrega.Text = "";
            cbbCorte.Text = "";
        
        }

        private void cargarDadots()
        {
            controller.MaquilaCon maq = new controller.MaquilaCon();


            cbbCorte.DataSource = maq.ListaBordadesAMaquila();
            cbbCorte.DisplayMember = "IdBordado";
            cbbCorte.ValueMember = "Id";

            cbbLugarEntrega.DataSource = maq.ListaLugaresEntrega();
            cbbLugarEntrega.DisplayMember = "IdBordado";
            cbbLugarEntrega.ValueMember = "Id";

            dgvMaquila.DataSource = maq.ListaPorcesoMaquilaSinTerminar();
            dgvMaquila.Columns[0].Visible = false;

            NumeroMAquila();
         btns();
        }

       


        private void btnTerminado_Click(object sender, EventArgs e)
        {
            BordadoCon bor = new BordadoCon();
            int PiezasBordado = bor.ObtenerCantidadPiezasBordado(newMaquila.IdPrenda);
            int x;
            cantidadView c = new cantidadView();
            c.LoadOrders("Cantidad", PiezasBordado);
            c.ShowDialog();
            x = c.CantidadACt;
            c.Close();
            string message =
  "Desea marcar el proceso como terminado?";
            const string caption = "Form Closing";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Exclamation);


            // If the no button was pressed ...
            if (result == DialogResult.Yes)
            {
                int id = dgvMaquila.CurrentRow.Index;


                newMaquila = new Ob.MaquilaDTO();
                newMaquila.Id = Convert.ToInt16(dgvMaquila[0, id].Value);
                controller.MaquilaCon cor = new controller.MaquilaCon();

                newMaquila.FechaEntrega = DateTime.Now;

                newMaquila.Cantidad = x;
                newMaquila.IdUsuario = logi.User().Id;
                newMaquila.Estado = true;

                if (cor.ActualizarMaquilaProcesoTerminado(newMaquila))
                {

                    MessageBox.Show("A finalizado el proceso bordado");
                    limpiar();
                    cargarDadots();
                    btneliminar.Visible = false;
                    btnTerminado.Visible = false;
                }
            }
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            string message =
         "Desea eliminar EL proceso maquila  " + newMaquila.IdMaquila + "?";
            const string caption = "Form Closing";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Exclamation);

            // If the no button was pressed ...
            if (result == DialogResult.Yes)
            {
                controller.MaquilaCon cor = new controller.MaquilaCon();
                if (cor.EliminaeMaquilaProceso(newMaquila.Id))
                {
                    MessageBox.Show("Se elimino correctamente");
                    limpiar();
                    btneliminar.Visible = false;
                    cargarDadots();
                    btneliminar.Visible = false;
                    newMaquila = null;
                }
            }
               
        }

        private void dgvMaquila_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           

            if (logi.User().Permiso.Maquila)
            {
                try
                {

                    int id = dgvMaquila.CurrentRow.Index;

                    short idMaquila = Convert.ToInt16(dgvMaquila[0, id].Value);
                    controller.MaquilaCon cor = new controller.MaquilaCon();
                    newMaquila = cor.ObtenerMaquilaProceso(idMaquila);
                    txtIdmaquila.Text = newMaquila.IdMaquila;
                    cbbCorte.SelectedValue = newMaquila.IdBordado;
                    cbbLugarEntrega.SelectedValue = newMaquila.IdLugarEntrega;
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
      
                lavanderiaView maq = new lavanderiaView();
                maq.Show();
                Close();
            
        }

        private void btns()
        {
            if (logi.User().Permiso.Bordado)
            {
                imagenIR.Visible = true;
            }
        }
        
    }


}

        