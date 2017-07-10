using almacen_telar.controller;
using almacen_telar.Ob;
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
    public partial class bordadoView : Form
    {
        private loginView logi = new loginView();
        private Bordado _bordado;
        

        public bordadoView()
        {
            InitializeComponent();
            
        }

    //    private void btnAgregar_Click(object sender, EventArgs e)
    //    {
    //        if (txtIdbordado.Text != "" && txtNumeroPuntadas.Text != "")
    //        {
    //            if (_bordado == null)
    //            {
    //                _bordado = new Bordado();
    //            }

                
    //                _bordado.IdBordado = txtIdbordado.Text;
    //            _bordado.NumeroPuntadas = int.Parse( txtNumeroPuntadas.Text);
                
    //            _bordado.FechaInicio = fechaEntrada.Value.Date;
    //            _bordado.FechaTerminado = fechaSalida.Value.Date;
    //            _bordado.ParteBordada = txtParteBordad.Text;
    //            _bordado.IdUsuario = logi.User().Id;
    //            _bordado.Estado = false;
                

    //                    if (con.AgregarBordado(_bordado))
    //                    {
    //                        MessageBox.Show("El bordado se agrego correctamente");
    //                        limpiar();
    //                        CargarDAtosBordados();

    //                    }
                    
                   
    //        }
    //        else
    //            MessageBox.Show("Faltan campos por escribir");
    //    }




    //    private void limpiar()
    //    {
    //      txtIdbordado.Text="";
    //      txtNumeroPuntadas.ResetText();

    //      txtParteBordad.Text="";
    //      cbbCortes.Text = "";
    //      //cbbCortes.SelectedText = "";
           
    //    }

    //    public void CargarDAtosBordados()
    //    {
    //        controller.BordadoCon bor = new controller.BordadoCon();
    //        dgvBordado.DataSource = bor.ObtenerListaBordadosInactivos();
    //        dgvBordado.Columns[0].Visible = false;

    //        cbbCortes.DataSource = bor.ObtenerListaCortesParaBordados();
    //        cbbCortes.DisplayMember = "idCorte";
    //        cbbCortes.ValueMember = "id";

    //        NumeroVordado();

    //        btns();
    //    }

    //    private void NumeroVordado()
    //        {

    //            txtIdbordado.Text = "Bordado" + (1 + con.NumeroBordado());

    //}

      
    //    private void btnEliminar_Click(object sender, EventArgs e)
    //    {

    //        string message =
    //     "Desea eliminar el bordado " + _bordado.IdBordado + "?";
    //        const string caption = "Form Closing";
    //        var result = MessageBox.Show(message, caption,
    //                                     MessageBoxButtons.YesNo,
    //                                     MessageBoxIcon.Exclamation);

    //        // If the no button was pressed ...
    //        if (result == DialogResult.Yes)
    //        {
    //            controller.BordadoCon cor = new controller.BordadoCon();
    //            if (cor.EliminarBordado(_bordado.Id))
    //            {
    //                MessageBox.Show("Se elimino correctamente");
    //                limpiar();
    //                btnEliminar.Visible = false;
    //                CargarDAtosBordados();
    //                btnTerminado.Visible = false;
    //                _bordado = null;
    //            }
                

    //        }
               
    //    }

    //    private void btnTerminado_Click(object sender, EventArgs e)
    //    {
    //        CorteCon ter = new CorteCon();
    //        int PiezasCorte = ter.ObtenerCantidadPiezasCorte(_bordado.IdPrenda);
    //        int x = 0;
    //         controller.CorteCon con = new controller.CorteCon();
    //        try
    //        {
    //            cantidadView c = new cantidadView();
    //            c.LoadOrders("Cantidad", PiezasCorte);
    //            c.ShowDialog();
    //            x = c.CantidadACt;
    //            c.Close();
    //            string message =
    //  "Desea marcar el proceso como terminado?";
    //            const string caption = "Form Closing";
    //            var result = MessageBox.Show(message, caption,
    //                                         MessageBoxButtons.YesNo,
    //                                         MessageBoxIcon.Exclamation);

    //            // If the no button was pressed ...
    //            if (result == DialogResult.Yes)
    //            {
    //                controller.BordadoCon cor = new controller.BordadoCon();

    //                _bordado.FechaTerminado = DateTime.Now;
    //                _bordado.NumeroPiezas = x;
    //                _bordado.Estado = true;

    //                if (cor.ActualizarBordadoTerminado(_bordado))
    //                {

    //                    MessageBox.Show("A finalizado el proceso bordado");
    //                    btnTerminado.Visible=false;
    //                btnEliminar.Visible=false;
    //                    limpiar();
    //                    CargarDAtosBordados();

    //                }
                   
                    
    //            }


    //        }
    //        catch (Exception)
    //        {

    //            throw;
    //        }

        
    //    }

      

    //    private void label4_Click(object sender, EventArgs e)
    //    {
    //        CorteCon cor = new CorteCon();
    //        Ob.CorteDTO cort = cor.ObtenerCorteProceso(Convert.ToInt16(cbbCortes.SelectedValue));

    //        MessageBox.Show("IDCorte:" + cort.IdCorte +"\n Cantidad:"+cort.Piezas  );
    //    }

    //    private void dgvBordado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    //    {
           

    //        if (logi.User().Permiso.Bordado)
    //        {
    //            try
    //            {

    //                int id = dgvBordado.CurrentRow.Index;

    //                short idCorte = Convert.ToInt16(dgvBordado[0, id].Value);
    //                controller.BordadoCon cor = new controller.BordadoCon();
    //                _bordado = cor.ObtenerBordado(idCorte);
    //                txtParteBordad.Text = _bordado.ParteBordada;
    //                txtIdbordado.Text = _bordado.IdBordado;
    //                cbbCortes.SelectedItem = _bordado.IdCorte;
    //                txtNumeroPuntadas.Text =  _bordado.NumeroPuntadas.ToString();
    //                btnEliminar.Visible = true;
    //                btnTerminado.Visible = true;

    //            }
    //            catch (Exception ex)
    //            {

    //                throw;
    //            }
    //        }
    //    }

    //    public void refrescarBordado()
    //    {
    //        CargarDAtosBordados();
           
    //    }

    //    private void timer1_Tick(object sender, EventArgs e)
    //    {
    //        CargarDAtosBordados();
    //    }

    //    private void pictureBox2_Click(object sender, EventArgs e)
    //    {
           
    //            maquilaView maq = new maquilaView();
    //            maq.Show();
    //            Close();
            
    //    }

    //    private void btns()
    //    {
    //        if (logi.User().Permiso.Maquila)
    //        {
    //            pbIrMaquila.Visible = true;
    //        }
    //    }

    //    private void Bordado_Load(object sender, EventArgs e)
    //    {

    //    }

    }
}
