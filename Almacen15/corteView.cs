using almacen_telar.controller;
using almacen_telar.Ob;
using Project.BL;
using Project.BL.Catalogos;
using Project.BL.DetallesProcesos;
using Project.BL.Procesos;
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
    public partial class corteView : Form
    {
        private Corte _corte;
        private List<Detalle> _detallesPrenda;
        private Prenda _prenda;
        public DateTime fechahoy;
        loginView logi = new loginView();

        public corteView()
        {
            InitializeComponent();
            CargarDatosCorte();

        }


        private void CargarDatosCorte()
        {


            corteBL bl = new corteBL();
            dgvCorte.DataSource = bl.ListaCortesEnproceso();
            dgvCorte.Columns[0].Visible = false;

            for (int i = 8; i < dgvCorte.ColumnCount; i++)
            {
                dgvCorte.Columns[i].Visible = false;
            }



            DiseñoBL bld = new DiseñoBL();
           
            cbxDiseño.DisplayMember = "Corte";
            cbxDiseño.ValueMember = "id";
            cbxDiseño.DataSource = bld.ListaDiseñosActivos();

            TallaBL blt = new TallaBL();
            gtvTallas.DataSource = blt.ListaTallasActivas();
            gtvTallas.Columns[0].Visible = false;
            gtvTallas.Columns[2].Visible = false;

        }




        private void btneliminar_Click(object sender, EventArgs e)
        {

            string message =
         "Desea eliminar al usuario " + _corte.IdCorte + "?";
            const string caption = "Form Closing";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Exclamation);

            // If the no button was pressed ...
            if (result == DialogResult.Yes)
            {
                corteBL bl = new corteBL();
                if (bl.EliminarCorte(_corte.Id))
                {
                    MessageBox.Show("Se elimino correctamente");
                    limpiar();

                    CargarDatosCorte();
                    btnTerminado.Visible = false;
                    btnTerminado.Visible = false;
                    _corte = null;
                }
            }


        }


        private void limpiar()
        {
            txtNumeroCorte.Text = "";
            txtCantidad.Text = "";
            pbxImagen.Image = null;
        }



        private void txtpiezas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }



        private void btnTerminado_Click(object sender, EventArgs e)
        {
            controller.CorteCon con = new controller.CorteCon();
            try
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




                    _corte.Estado = true;
                    corteBL bl = new corteBL();
                    if (bl.AgregarActualizarCorte(_corte))
                    {

                        MessageBox.Show("Laoperacion fue exitosa");
                        limpiar();
                        CargarDatosCorte();
                        btnTerminado.Visible = false;
                        btneliminar.Visible = false;
                        
                        _corte = null;
                    }
                }



            }
            catch (Exception)
            {

                throw;
            }

        }



        private void dgvCorte_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {


            if (logi.User().Permiso.Corte)
            {
                try
                {

                    int id = dgvCorte.CurrentRow.Index;

                    _corte.Id = Convert.ToInt16(dgvCorte[0, id].Value);
                    corteBL bl = new corteBL();
                    _corte = bl.ObtenerCorte(_corte.Id);

                    txtNumeroCorte.Text = _corte.IdCorte;
                    cbxDiseño.SelectedValue = _corte.Prenda.IdDiseño;

                    btneliminar.Visible = true;
                    btnTerminado.Visible = true;

                }
                catch (Exception ex)
                {

                    throw;
                }
            }
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            if (txtCantidad.Text != "" && txtNumeroCorte.Text != "")
            {

                if (_corte == null)
                {
                    _corte = new Corte();
                }


                _corte.IdCorte = txtNumeroCorte.Text;
                List<Talla> listaTallasSelect = new List<Talla>();
               _detallesPrenda = new List<Detalle>();
                
                //Me obtiene las tallas seleccionadas
                Int32 selectedCellCount = gtvTallas.GetCellCount(DataGridViewElementStates.Selected);
                for (int i = 0; i < selectedCellCount; i++)
                {
                    int x = gtvTallas.SelectedCells[i].RowIndex;
                    listaTallasSelect.Add(new Talla()
                    {
                        Id = Convert.ToInt16(gtvTallas[0, x].Value),
                        Talla1 = Convert.ToInt16(gtvTallas[1, x].Value)
                    });

                }


                //paso los valores al corte
                _corte.Piezas = Convert.ToInt32(txtCantidad.Text);
                _corte.IdPrenda = (short)cbxDiseño.SelectedValue;
                _corte.FechaEntrada = dtpFechaEntrada.Value.Date;
                _corte.FechaEntrada = dtpFechaEntrada.Value.Date;
                _corte.IdUsuario = logi.User().Id;
                _corte.Estado = false;

                //pido la cantidad de cada talla seleccionada al usuario
                for (int z = 0; z < listaTallasSelect.Count(); z++)
                {

                    cantidadView can = new cantidadView();
                    string cadena = "Cantidad de talla " + listaTallasSelect[z].Talla1.ToString();
                    can.LoadOrders(cadena, 0);
                    can.ShowDialog();

                    _detallesPrenda.Add(new Detalle()
                    {
                        Cantidad = int.Parse(can.cant().ToString()),
                        IdTalla = listaTallasSelect[z].Id
                    });

                }


                _prenda = new Prenda();
                _prenda.IdDiseño = short.Parse( cbxDiseño.SelectedValue.ToString()); 

                if (AgregarCorteCompleto( _prenda))
                {
                    MessageBox.Show("El corte se agrego correctamente");
                    limpiar();
                    CargarDatosCorte();

                }

            }
        }

        private bool AgregarCorteCompleto( Prenda prenda)
        {
            bool resul = false;
            try
            {

                string message =
             "Desea agregar el corte?";
                const string caption = "Form Closing";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Exclamation);

                // If the no button was pressed ...
                if (result == DialogResult.Yes)
                {

                    int total = 0;
                    foreach (Detalle item in _detallesPrenda)
                    {
                        total += item.Cantidad;
                    }
                    //agregar prenda
                    
                    PrendaBL blp = new PrendaBL();
                    
                   short IdPrenda= blp.AgregarActualizarPreda(prenda);

                    for (int i = 0; i < _detallesPrenda.Count; i++)
                    {
                        _detallesPrenda[i].IdPrenda = IdPrenda;

                        detallesPrendaBL bld = new detallesPrendaBL();
                        if (bld.AgregarActualizarDetallePrenda(_detallesPrenda[i]))
                        {


                        }
                    }

                    corteBL blc = new corteBL();
                    _corte.IdPrenda = IdPrenda;
                    return blc.AgregarActualizarCorte(_corte);
                }
                else
                {
                    _corte = null;
                    _detallesPrenda = null;
                    _prenda = null;
                    return false;
                }
            }
            catch (Exception ex)
            {
                resul = false;

            }

            return resul;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            bordadoView bor = new bordadoView();
            bor.Show();
            Close();

        }

        private void txtNumeroCorte_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbxDiseño_SelectedIndexChanged(object sender, EventArgs e)
        {
            DiseñoBL bl = new DiseñoBL();
            Diseño dis = new Diseño();
            dis = bl.ObtenerDiseño(short.Parse( cbxDiseño.SelectedValue.ToString()));
            pbxImagen.Image = null;
            if(dis.Imagen.Count() > 0 )
            {
                BynaryToImagen(dis.Imagen);
            }
        }

        public void BynaryToImagen(byte[] imagen)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream(imagen);
            pbxImagen.Image = System.Drawing.Bitmap.FromStream(ms);
        }
    }
}
