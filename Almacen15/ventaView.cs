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
    public partial class ventaView : Form
    {
        private int IDColumna;
        private VentaDTO newVenta;
        private List<DetalleVentaDTO> ListaDet;
        public static short IdBodega = 1;
        public ventaView()
        {
            InitializeComponent();
            CargarDatos();


        }



        // boton agregar 






        private void button1_Click(object sender, EventArgs e)
        {

        }



        private void AgregarAList(short Id, string codigo, double IdTalla, int cantidad)
        {
            //pebdiente
            DetalleVentaDTO dto= new DetalleVentaDTO();
            dto.Id = Id;
            dto.Codigo=codigo;
            dto.Talla = IdTalla;
            dto.Cantidad = cantidad;
            if (ListaDet == null)
            {
                ListaDet = new List<DetalleVentaDTO>();
            }
            ListaDet.Add(dto);
            listVentas.DataSource = "";
            listVentas.DataSource = ListaDet;
            listVentas.Columns[0].Visible = false;
            listVentas.Columns[3].Visible = false;
            listVentas.Columns[5].Visible = false;
         
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
          
                VentaCon con = new VentaCon();

                int cantidad = con.CantiadDePRenda(IdBodega, txtCodigo.Text, int.Parse(cbbIdTalla.SelectedValue.ToString()));
                if (cantidad == 0)
                {
                    MessageBox.Show("Ya no cuenta con pantalones ");

                }
                else if (cantidad < int.Parse(txtCantidad.Text))
                {
                    MessageBox.Show("Solo cuenta con " + cantidad + " pantalones ");
                }
                else
                {
                    AgregarAList(0, txtCodigo.Text, double.Parse(cbbIdTalla.Text), int.Parse(txtCantidad.Text));
                    txtCantidad.Text = "";
                }
            

          
        }

        private void cargarTallas(string idDiseño)
        {
            VentaCon con = new VentaCon();
            cbbIdTalla.DataSource = con.ObtenerListaDeTallasPorId(idDiseño, IdBodega);
            cbbIdTalla.DisplayMember = "Talla";
            cbbIdTalla.ValueMember = "Id";
        }



        private void CargarDatos()
        {
            VentaCon con = new VentaCon();
            dataGridView1.DataSource = con.ListaPantalones(IdBodega);
            dataGridView1.Columns[0].Visible = false;


            dgvVentasRealizadas.DataSource = con.ObtenerListaVentas();
            dgvVentasRealizadas.Columns[0].Visible = false;


        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData == Keys.Tab)
            {



                VentaCon con = new VentaCon();
                if (con.ConsultaSiExiste(txtCodigo.Text, IdBodega))
                    cargarTallas(txtCodigo.Text);
                else
                    MessageBox.Show("El pantalon con el codigo " + txtCodigo.Text + " no exite");
            }

            if (e.KeyData == Keys.Enter)
            {



                VentaCon con = new VentaCon();
                if (con.ConsultaSiExiste(txtCodigo.Text, IdBodega))
                    cargarTallas(txtCodigo.Text);
                else
                    MessageBox.Show("El pantalon con el codigo " + txtCodigo.Text + " no exite");
            }
        }

        private void btnTerminarVenta_Click(object sender, EventArgs e)
        {
            if (newVenta != null)
            {
                VentaCon con = new VentaCon();
                newVenta.PiezasVendidas = TotalDePantalonesEntegrados();
                newVenta.PiezasDevueltas = newVenta.PienzasEntregadas - newVenta.PiezasVendidas;
                con.ActualizarVenta(newVenta);
                foreach (DetalleVentaDTO item in ListaDet)
                {
                    con.ActualizarCantidadesDevueltas(item, IdBodega);
                }
                ListaDet = null;
                newVenta = null;
                MessageBox.Show("Se actualizo correctamente");
                CargarDatos();

            }
            else
            {
                VentaCon con = new VentaCon();
                VentaDTO dto = new VentaDTO();
                dto.PienzasEntregadas = TotalDePantalonesEntegrados();
                dto.PiezasVendidas = TotalDePantalonesEntegrados();
                dto.PiezasDevueltas = 0;
                short idVenta = con.AgregarVenta(dto);
                if (idVenta > 0)
                {
                    List<DetalleVentaDTO> lista = new List<DetalleVentaDTO>();
                    for (int i = 0; i < listVentas.RowCount; i++)
                    {


                        lista.Add(new DetalleVentaDTO()
                        {
                            Codigo = listVentas[1, i].Value.ToString(),
                            //Codigo = listVentas.Columns[0].,
                            IdVenta = idVenta,
                            Talla = double.Parse(listVentas[2, i].Value.ToString()),
                            Cantidad = int.Parse(listVentas[4, i].Value.ToString())
                        });

                    }

                    foreach (DetalleVentaDTO item in lista)
                    {
                        if (con.AgregarDetallesVenta(item))
                        {
                            con.ActualizarCantidades(item, IdBodega);
                        }
                    }
                    MessageBox.Show("La venta fue exitosa");
                    limpiar();
                    CargarDatos();

                }
            }
        }

        private int TotalDePantalonesEntegrados()
        {
            int Cantidad = 0;

            for (int i = 0; i < listVentas.RowCount; i++)
            {


                Cantidad += int.Parse(listVentas[4, i].Value.ToString());

            }
            return Cantidad;
        }

        private void limpiar()
        {
            txtCodigo.Text = "";
            txtCantidad.Text = "";
            listVentas.DataSource ="";

            cbbIdTalla.SelectedText = "";
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiar();
            newVenta = null;
            ListaDet = null;
        }

        private void txtCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            VentaCon con = new VentaCon();
            if (e.KeyData == Keys.Enter)
            {

                int cantidad = con.CantiadDePRenda(IdBodega, txtCodigo.Text, int.Parse(cbbIdTalla.SelectedValue.ToString()));
                if (cantidad == 0)
                {
                    MessageBox.Show("Ya no cuenta con pantalones ");

                }
                else if (cantidad < int.Parse(txtCantidad.Text))
                {
                    MessageBox.Show("Solo cuenta con " + cantidad + " pantalones ");
                }
                else
                {
                    AgregarAList(0, txtCodigo.Text, double.Parse(cbbIdTalla.Text), int.Parse(txtCantidad.Text));
                    txtCantidad.Text = "";
                }
            }

        }

        private void dgvVentasRealizadas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            limpiar();
            VentaCon con = new VentaCon();
            int id = dgvVentasRealizadas.CurrentRow.Index;
            newVenta = new VentaDTO();
            newVenta.Id = Convert.ToInt16(dgvVentasRealizadas[0, id].Value);

            newVenta = con.ObtenerVenta(newVenta.Id);
            ListaDet = new List<DetalleVentaDTO>();
            ListaDet = con.ObtenerVentaDetalles(newVenta.Id);

            listVentas.DataSource = ListaDet;
            listVentas.Columns[0].Visible = false;
            listVentas.Columns[3].Visible = false;
            listVentas.Columns[5].Visible = false;

        }

        private void listVentas_VirtualItemsSelectionRangeChanged(object sender, ListViewVirtualItemsSelectionRangeChangedEventArgs e)
        {

        }

        private void listVentas_ItemActivate(object sender, EventArgs e)
        {

        }

        private void listVentas_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void listVentas_Click(object sender, EventArgs e)
        {

        }

        private void listVentas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listVentas_ColumnClick(object sender, ColumnClickEventArgs e)
        {

        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            Int32 selectedCellCount = listVentas.GetCellCount(DataGridViewElementStates.Selected);
            int x = 0;
            for (int i = 0; i < selectedCellCount; i++)
            {
                 x= listVentas.SelectedCells[i].RowIndex;

                 ListaDet.Remove(ListaDet[x]);
            }


           
        }

        private void listVentas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            IDColumna= listVentas.CurrentRow.Index;


            txtCantidad.Text = ListaDet[IDColumna].Cantidad.ToString();
            btnModificar.Visible = true;
            btnAceptar.Visible = false;
            btnQuitar.Visible = false;
            txtCodigo.Visible = false;
            cbbIdTalla.Visible = false;
            listVentas.Columns[0].Visible = false;
            listVentas.Columns[3].Visible = false;
            listVentas.Columns[5].Visible = false;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ListaDet[IDColumna].Cantidad = Convert.ToInt32(txtCantidad.Text);
            listVentas.DataSource = "";
            listVentas.DataSource = ListaDet;
            txtCantidad.Text = "";
            btnModificar.Visible = false;
            btnAceptar.Visible = true;
            btnQuitar.Visible = true;
            txtCodigo.Visible = true;
            cbbIdTalla.Visible = true;
            listVentas.Columns[0].Visible = false;
            listVentas.Columns[3].Visible = false;
            listVentas.Columns[5].Visible = false;
        }

        private void ventas_Load(object sender, EventArgs e)
        {

        }

    }
}
