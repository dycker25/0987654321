using almacen_telar.controller;
using almacen_telar.Ob;
using Project.BL;
using Project.BL.Catalogos;
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
    public partial class administradorView : Form
    {
        private Usuario _usuario;
        private Permiso _permisos;
        private Diseño _Diseño;
        private LugarEntrega _lugarentrega;
        private Proceso _procesolavanderia;
        private Bodega _bodega;
        private Talla _talla;
        
        private loginView longin = new loginView();

        private LugarEntregaDTO newLugar;
        public administradorView()
        {
            InitializeComponent();
            Listas();
            
            //CargarDatosDEprocesos();
        }
        /* ---Usuario--- */

        /// <summary>
        /// evento de onclic del botnon(se crea dando doble clic al boton el diseño)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnagregar_Click(object sender, EventArgs e)
        {//verifica qu los campos rincipales no esten vacios y si lo estan no haga nada
            if (txtNombre.Text != "" && txtUsuario.Text != "" && txtcontrasena.Text != "")
            {
                //verifica si el usuario es null si lo es quiere decir que es nuevo y deve instancialo
                //crea el usuario y el permiso al ser nuevos si es actualizacion lo ignora
                if (_usuario == null)
                {
                    _usuario = new Usuario();
                    _permisos = new Permiso();
                }
                //le asigna todos sus valores a permisos
                _permisos.Admin = checkAdmin.Checked;
                _permisos.Corte = checkCorte.Checked;
                _permisos.Bordado = checkBordado.Checked;
                _permisos.Maquila = checkMaquila.Checked;
                _permisos.Lavanderia = checkLavanderia.Checked;
                _permisos.Terminado = checkTerminado.Checked;
                _permisos.Almacen = checkAlmacen.Checked;
                _permisos.Venta = checkVentas.Checked;
                //instancia la clase BL capa de negocio para poder mandar a guardar(tiene mas metodos guardar,eliminar,actualizar)
                PermisosBL blp = new PermisosBL();
                //manda a guardar pero el metodo regresa un short (un sort es casi igual que un int )
                //guardar los permisos y regresa el id
                _usuario.IdPermisos = blp.AgregarActualizarPermisos(_permisos);
                //verifica que el Id devuelto por el metodo anterior sea mayor a 0 si lo es quiere decir que si se guardo correctante y prosigu a lo siguiente
                if (_usuario.IdPermisos > 0)
                {
                    //asina valores
                    _usuario.Nombre = txtNombre.Text;
                    _usuario.Usuario1 = txtUsuario.Text;
                    _usuario.contrasena = txtcontrasena.Text;
                    _usuario.Activo = checkActivoUsuario.Checked;
                    UsuarioBL bl = new UsuarioBL();
                    //manda a guardar y devuelve un bool si se guardo es tru si no se guardo es false
                    if (bl.AgregarActualizarUsuario(_usuario))
                    {
                        Limpiar();
                        CargarDatosUsuario();
                        MessageBox.Show("Se agrego correctamente");
                    }
                    else
                        MessageBox.Show("error al guardar");

                }

            }
            else
            {
                string message =
         "Le faltan campos por llenar";
                const string caption = "Form Closing";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Exclamation);

            }
        }

        private void txtEliminarUsuario_Click(object sender, EventArgs e)
        {

            string message =
         "Desea eliminar al usuario " + _usuario.Nombre + "?";
            const string caption = "Form Closing";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Exclamation);

            // If the no button was pressed ...
            if (result == DialogResult.Yes)
            {
                UsuarioBL bl = new UsuarioBL();
                if (bl.EliminarUsuario(_usuario.Id))
                {
                    MessageBox.Show("Se elimino correctamente");
                    Limpiar();
                    btnEliminarUsuario.Visible = false;
                    CargarDatosUsuario();
                    _usuario = null;
                }
            }

        }
        /// <summary>
        /// Mustra los datos del usuario seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {//identifica que coluna fue seleccionada
            int id = dgvUsuarios.CurrentRow.Index;
            _usuario = new Usuario();
            //obtiene el valor del id de la comuna seleccionada
           _usuario.Id = (Convert.ToInt16(dgvUsuarios[0, id].Value));

            
            UsuarioBL bl = new UsuarioBL();
            //manda llamar al usuario por el id
            _usuario = bl.ObtenerUduario(_usuario.Id);
            //llena campos
            txtNombre.Text = _usuario.Nombre;
            txtUsuario.Text = _usuario.Usuario1;
            txtcontrasena.Text = _usuario.contrasena;
            checkActivoUsuario.Checked = _usuario.Activo;
            btnEliminarUsuario.Visible = true;
            //hace lo mismo pero con permisos
            PermisosBL blp = new PermisosBL();
            _permisos = blp.ObtenerPermiso(_usuario.IdPermisos);
            checkAdmin.Checked = _permisos.Admin;

            checkCorte.Checked = _permisos.Corte;
            checkBordado.Checked = _permisos.Bordado;
            checkMaquila.Checked = _permisos.Maquila;
            checkLavanderia.Checked = _permisos.Lavanderia;
            checkTerminado.Checked = _permisos.Terminado;
            checkAlmacen.Checked = _permisos.Almacen;
            checkVentas.Checked = _permisos.Venta;
        }
        /// <summary>
        /// llena los el datagriew con los datos de los usuarios
        /// </summary>
        private void CargarDatosUsuario()
        {
            //manda a llamar una lista de usuarios
            UsuarioBL bl = new UsuarioBL();
            dgvUsuarios.DataSource = bl.ListaUsuarios();
            //oculta la primera fila que es donde aparece el ID
            dgvUsuarios.Columns[0].Visible = false;
            //oculta los demas valores del objeto
            for (int i = 6; i < dgvUsuarios.ColumnCount; i++)
            {
            dgvUsuarios.Columns[i].Visible = false;    
            }
         


        }

        /*---UsuarioEND---*/
        private void Limpiar()
        {
            //Tallas
            txtTallasNombre.Text = "";
            //Bodeha

            txtNombreBodega.Text = "";

            //Procesolavanderia
            txtPLavanderiaNombre.Text = "";
            txtPLavanderiaDescrip.Text = "";
            //
            txtcontrasena.Text = "";
            txtNombre.Text = "";
            txtUsuario.Text = "";
            txtIdDiseño.Text = "";
            txtNombreLugar.Text = "";
            dtpFechaAprovacionDiseño.Value = DateTime.Now;
            //lugar//
            txtNombre.Text = "";
            txtDireccionLugar.Text = "";
            txtTelefonoLugar.Text = "";

            //

            txtModeloDiseño.Text = "";
            txtIdDiseño.Text = "";
            txtCorteDiseño.Text = "";
            checkActivoDiseño.Checked = false;
            PicBoxImagen.Image =null;
        }



        private void CargarDatosProcesos()
        {
            AdministradorCon admin = new AdministradorCon();


        }
     
      

       /*---Diseños---*/
        private void btnAgregarActualizardiseño_Click(object sender, EventArgs e)
        {
           DiseñoCon dis = new DiseñoCon();

           if (_Diseño == null)
              _Diseño = new Diseño();

           _Diseño.Codigo = txtIdDiseño.Text;
           _Diseño.Corte = txtCorteDiseño.Text;
           _Diseño.Modelo = txtModeloDiseño.Text;
           _Diseño.FechaAprovado = Convert.ToDateTime(dtpFechaAprovacionDiseño.Value.ToShortDateString());
           _Diseño.Activo = checkActivoDiseño.Checked;
           _Diseño.IdUsuario = longin.User().Id;
           if (openFileDialog1.FileName != "")
           {
              _Diseño.Imagen = ImagenTOBynary(PicBoxImagen);
           }
           if(_Diseño.Id==0)
           {
              DiseñoBL bl = new DiseñoBL();
              if(bl.AgregarActualizarDiseño(_Diseño))
              {
                 Limpiar();

                 MessageBox.Show("El diseño se agrego correctamente");
                 CargarDatosDiseño();
                 btnEliminardiseño.Visible = false;
              }
           }
           else
           {
              DiseñoBL bl = new DiseñoBL();
              if(bl.AgregarActualizarDiseño(_Diseño))
              {
                 Limpiar();

                 MessageBox.Show("El diseño se actualizo correctamente");
                 CargarDatosDiseño();
                 _Diseño = null;
              }
           }
             
        }

        /*private DiseñoCon DiseñoCon()
        {
           throw new NotImplementedException();
        }*/

        private void btnEliminardiseño_Click(object sender, EventArgs e)
        {
           string message =
              "Desea eliminar el diseño?" + _Diseño.Codigo +"?";
           const string caption = "Form Closing";
           var result = MessageBox.Show(message, caption,
                                      MessageBoxButtons.YesNo,
                                      MessageBoxIcon.Exclamation);
           //if no button was pressed ...
           if(result==DialogResult.Yes)
           {
              controller.DiseñoCon din = new controller.DiseñoCon();
              if (din.EliminarDiseño(_Diseño.Id))
              {
                 MessageBox.Show("Eliminado correctamente");
                 Limpiar();
                 btnEliminardiseño.Visible = false;
                 CargarDatosDiseño();
                 _Diseño = null;
              }
           }
        }
       

        private void dgvDiseño_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = dgvDiseño.CurrentRow.Index;

            _Diseño = new Diseño();

            _Diseño.Id = (Convert.ToInt16(dgvDiseño[0, id].Value));
            DiseñoBL bl = new DiseñoBL();
            _Diseño = bl.ObtenerDiseño(_Diseño.Id);
            txtIdDiseño.Text = _Diseño.Codigo;
            txtCorteDiseño.Text = _Diseño.Corte;
            txtModeloDiseño.Text = _Diseño.Modelo;
            dtpFechaAprovacionDiseño.Value = _Diseño.FechaAprovado;
            checkActivoDiseño.Checked = _Diseño.Activo;
            if (_Diseño.Imagen.Count() > 0)
                BynaryToImagen(_Diseño.Imagen);
            btnEliminardiseño.Visible = true;

        }

        private void CargarDatosDiseño()
        {

            DiseñoBL bl = new DiseñoBL();
            dgvDiseño.DataSource = bl.ListaDiseños();
            dgvDiseño.Columns[0].Visible = false;

            for (int i = 5; i < dgvDiseño.ColumnCount; i++)
            {
                dgvDiseño.Columns[i].Visible = false;
            }


        }

        public void BynaryToImagen(byte[] imagen)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream(imagen);
            PicBoxImagen.Image = System.Drawing.Bitmap.FromStream(ms);
        }
        public Byte[] ImagenTOBynary(PictureBox imagen)
        {
            System.IO.MemoryStream sm = new System.IO.MemoryStream();
            imagen.Image.Save(sm, System.Drawing.Imaging.ImageFormat.Jpeg);
            return sm.GetBuffer();
        }

        private void btnSubirImagen_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            this.PicBoxImagen.Image = Image.FromFile(this.openFileDialog1.FileName);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           Corte cort = new Corte();
           //cort.Show();
           Close();
           
        }

      /*---DiseñoEnd--*/

     
        /*---Lugares---*/
        private void btnagregarlugar_Click(object sender, EventArgs e)
        {
           LugaresBL bl = new LugaresBL();
           if (_lugarentrega == null)
           {
              _lugarentrega = new LugarEntrega();
           }
              

           _lugarentrega.Nombre = txtNombreLugar.Text;
           _lugarentrega.Direccion = txtDireccionLugar.Text;
           _lugarentrega.Telefono = txtTelefonoLugar.Text;
           _lugarentrega.Activo = rbtnActivoLugar.Checked;

           if(_lugarentrega.Id==0)
           {
              LugaresBL bls = new LugaresBL();
              if(bls.AgregarActualizarLugar(_lugarentrega))
              {
                 Limpiar();

                 MessageBox.Show("La operacion fue exitosa");
                 CargarDatosLugar();
                 btneliminarlugar.Visible = false;
                 _lugarentrega = null;
              }
           }
          
           
           
           
        }

        private void btneliminarlugar_Click(object sender, EventArgs e)
        {
           string message =
              "Desea eliminar el lugar" + _lugarentrega.Nombre + "?";
           const string caption = "Form closing";
           var result = MessageBox.Show(message, caption,
              MessageBoxButtons.YesNo,
              MessageBoxIcon.Exclamation);

           //if the no button was pressed
           if (result == DialogResult.Yes)
           {
              LugaresBL bl = new LugaresBL();
              if (bl.EliminarLugar(_lugarentrega.Id))
              {
                 MessageBox.Show("Eliminado correctamente");
                 Limpiar();
                 btneliminarlugar.Visible = false;
                 CargarDatosLugar();
                 _lugarentrega = null;
              }
           }

        }


        private void dgvLugares_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = dgvLugares.CurrentRow.Index;

            _lugarentrega = new LugarEntrega();

            _lugarentrega.Id = (Convert.ToInt16(dgvLugares[0, id].Value));

            
            LugaresBL bl = new LugaresBL();
            _lugarentrega = bl.ObtenerLugarEntrega(_lugarentrega.Id);
            txtNombreLugar.Text = _lugarentrega.Nombre;
            txtDireccionLugar.Text = _lugarentrega.Direccion;
            txtTelefonoLugar.Text = _lugarentrega.Telefono;
            rbtnActivoLugar.Checked = _lugarentrega.Activo;

            btneliminarlugar.Visible = true;
            
        }

        private void CargarDatosLugar()
        {

            LugaresBL bl = new LugaresBL();
            dgvLugares.DataSource = bl.ListaLugarEntregas();
            dgvLugares.Columns[0].Visible = false;
            dgvLugares.Columns[5].Visible = false;

        }

     /*---LugaresEnd*/


        /*--Procesos de lavanderia---*/
        private void btnAceptarPLavanderia_Click(object sender, EventArgs e)
        {

           
           if (_procesolavanderia==null)
           {
              _procesolavanderia = new Proceso();
              // _procesolavaderia = new Lavanderia();
           }
           _procesolavanderia.Nombre = txtPLavanderiaNombre.Text;
           _procesolavanderia.Descripcion = txtPLavanderiaDescrip.Text;
           _procesolavanderia.Activo = rbtnPLavanderia.Checked;
         
           
              ProcesosLavanderiaBL bl = new ProcesosLavanderiaBL();
              if(bl.AgregarActualizarProceso(_procesolavanderia))
              {
                 Limpiar();

                 MessageBox.Show("La operacion fue exitosa");
                 CargarDatosProcesolavanderia();
                 btnEliminarPLavanderia.Visible = false;
                 _procesolavanderia = null;
              }
           
           
        }

        private void btnEliminarPLavanderia_Click(object sender, EventArgs e)
        {
            string message =
        "Desea eliminar el proceso "+_procesolavanderia.Nombre + "?";
            const string caption = "Form Closing";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Exclamation);

            // If the no button was pressed ...
            if (result == DialogResult.Yes)
            {
               ProcesosLavanderiaBL bl = new ProcesosLavanderiaBL(); 
               //AdministradorCon admin = new AdministradorCon();
               if(bl.EliminarProcesoLavan(_procesolavanderia.Id)) 
               //if (admin.EliminarProcesoDeLavanderia(newLugar.Id))
                {
                    MessageBox.Show("Se elimino correctamente");
                    Limpiar();
                    btnEliminarPLavanderia.Visible = false;
                    CargarDatosProcesolavanderia();
                    _procesolavanderia = null;
                }
            }
        }

        private void dgvProLavaderia_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = dgvProLavaderia.CurrentRow.Index;

            _procesolavanderia = new Proceso();
           // newLugar = new LugarEntregaDTO();

            _procesolavanderia.Id = (Convert.ToInt16(dgvProLavaderia[0, id].Value));

            ProcesosLavanderiaBL bl = new ProcesosLavanderiaBL();
            //AdministradorCon admin = new AdministradorCon();
            _procesolavanderia = bl.ObtenerProceso(_procesolavanderia.Id);
            txtPLavanderiaNombre.Text = _procesolavanderia.Nombre;
            txtPLavanderiaDescrip.Text = _procesolavanderia.Descripcion;
            rbtnPLavanderia.Checked = _procesolavanderia.Activo;

            btnEliminarPLavanderia.Visible = true;
        }

        private void CargarDatosProcesolavanderia()
        {

            ProcesosLavanderiaBL bl = new ProcesosLavanderiaBL();
            dgvProLavaderia.DataSource = bl.ListaProcesos();
            dgvProLavaderia.Columns[0].Visible = false;
            dgvProLavaderia.Columns[4].Visible = false;

        }

        /*---Procesos de lavanderia End*/


        /*--Almacen---*/
        private void btnAceptarBodega_Click(object sender, EventArgs e)
        {
           AlmacenBL bl = new AlmacenBL();
           if (_bodega == null)
           {
              _bodega = new Bodega();

           }
           
              _bodega.Nombre = txtNombreBodega.Text;
              _bodega.IdUsuario = short.Parse(cbbUsuarioBodegaActivas.SelectedValue.ToString());
              _bodega.Estado = rbtnEstadoBodega.Checked;

              
                 AlmacenBL blm = new AlmacenBL();
                 if(blm.AgregarActualizarBodega(_bodega))
               
                 {
                    Limpiar();

                    MessageBox.Show("La bodega se agrego correctamente");
                    CargarDatosBodega();
                    btnEliminarBodega.Visible = false;
                    _bodega = null;
                 }
             
          }


        private void btnEliminarBodega_Click(object sender, EventArgs e)
        {
           string message =
              "Desea eliminar el lugar" + _bodega.Nombre+ "?";
           const string caption = "Form closing";
           var result = MessageBox.Show(message, caption,
              MessageBoxButtons.YesNo,
              MessageBoxIcon.Exclamation);

           //if the no button was pressed
           if (result == DialogResult.Yes)
           {
              AlmacenBL bl = new AlmacenBL();
              if(bl.EliminarBodegas(_bodega.Id))
              {
                 MessageBox.Show("Eliminado correctamente");
                 Limpiar();
                 btnEliminarBodega.Visible = false;
                 CargarDatosBodega();
                 _bodega = null;
              }
           }

        }


        private void dgvBodegas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = dgvBodegas.CurrentRow.Index;

            _bodega = new Bodega();

           _bodega.Id = (Convert.ToInt16(dgvBodegas[0, id].Value));

           AlmacenBL bl = new AlmacenBL();
           _bodega = bl.ObtenerBodega(_bodega.Id);
            txtNombreBodega.Text = _bodega.Nombre;
            cbbUsuarioBodegaActivas.SelectedItem = _bodega.IdUsuario;
            rbtnEstadoBodega.Checked = _bodega.Estado;
            btnEliminarBodega.Visible = true;

        }

        private void CargarDatosBodega()
        {

            AlmacenBL bl = new AlmacenBL();
            dgvBodegas.DataSource = bl.ListaBodegas();
            dgvBodegas.Columns[0].Visible = false;
            dgvBodegas.Columns[4].Visible = false;
            dgvBodegas.Columns[5].Visible = false;
            dgvBodegas.Columns[6].Visible = false;
            UsuarioBL blu = new UsuarioBL();
            cbbUsuarioBodegaActivas.DataSource = blu.ListaUsuarios();
            cbbUsuarioBodegaActivas.DisplayMember = "Nombre";
            cbbUsuarioBodegaActivas.ValueMember = "Id";
        }

        /*---Almacen End*/


        /*---Tallas---*/
        private void btnAceptartallas_Click(object sender, EventArgs e)
        {
           TallaBL bl = new TallaBL();
           if (_talla == null)
           {
              _talla = new Talla();
           }

           _talla.Talla1 = Convert.ToDouble(txtTallasNombre.Text);
           _talla.activo = rbtnTallasActivo.Checked;

          
              TallaBL blt = new TallaBL();
              if(blt.AgregarActualizarTalla(_talla))
              {
                 Limpiar();
                 MessageBox.Show("La operacion fue exitosa");
                 CargarDatosTallas();
                 btnEliminartallas.Visible = false;
                 _talla = null;
              }
          
        }

        private void btnEliminartallas_Click(object sender, EventArgs e)
        {
           string message =
              "Desea eliminar el lugar" + _talla.Talla1 + "?";
           const string caption = "Form closing";
           var result = MessageBox.Show(message, caption,
              MessageBoxButtons.YesNo,
              MessageBoxIcon.Exclamation);
           
           //if the no button was pressed
           if (result == DialogResult.Yes)
           {
              TallaBL bl = new TallaBL();
              if(bl.Eliminartallas((short)_talla.Id))
              {
                 MessageBox.Show("Eliminado correctamente");
                 Limpiar();
                 btnEliminartallas.Visible = false;
                 CargarDatosTallas();
                 _talla = null;
              }
           }
        }




        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = dataGridView1.CurrentRow.Index;

            _talla = new Talla();


            _talla.Id = (Convert.ToInt16(dataGridView1[0, id].Value));

            TallaBL bl = new TallaBL();
            //AdministradorCon admin = new AdministradorCon();
            _talla = bl.ObtenerTalla((short)_talla.Id);

            txtTallasNombre.Text = _talla.Talla1.ToString();

            rbtnTallasActivo.Checked = _talla.activo;

            btnEliminartallas.Visible = true;
        }

        private void CargarDatosTallas()
        {
            TallaBL bl = new TallaBL();
            dataGridView1.DataSource = bl.ListaTallas();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[3].Visible = false;
        }

       /*---Tallas End*/


        /*---Resumen de Procesos--*/
        private void CargarDatosDEprocesos()
        {
            AdministradorCon con = new AdministradorCon();
            List<DetallesDTO> lista = con.ObtenerListaDePrendas();

            foreach (DetallesDTO item in lista)
            {
                CorteDTO corte = con.ProcesoCorte(item.Id);
                if (corte.IdCorte != null)
                {
                    BordadoDTO bordado = con.ProcesoBordado(item.Id);
                    if (bordado.IdBordado != null)
                    {
                        MaquilaDTO maquila = con.ProcesoMaquila(item.Id);
                        if (maquila.IdMaquila != null)
                        {
                            LavanderiaDTO lavanderia = con.ProcesoLavanderia(item.Id);
                            if (lavanderia.IdLavanderia != null)
                            {
                                TerminadoDTO terminado = con.ProcesoTerminado(item.Id);
                                if (terminado.IdTerminado != null)
                                {
                                    AgregarLisviwTerminado(corte, bordado, maquila, lavanderia, terminado);
                                }
                                else
                                {
                                    AgregarLisviwLavanderia(corte, bordado, maquila, lavanderia);
                                }
                            }
                            else
                            {
                                AgregarLisviwMaquila(corte, bordado, maquila);
                            }
                        }
                        else
                        {
                            AgregarLisviwBordado(corte, bordado);
                        }
                    }
                    else
                    {
                        AgregarLisviwCorte(corte);
                    }
                }
                else
                {

                }
            }
        }




        private void AgregarLisviwCorte(CorteDTO corte)
        {
            ListViewItem c = new ListViewItem(corte.IdCorte.ToString());
            if (corte.Estado)
                c.SubItems.Add("En proceso");
            else
                c.SubItems.Add("Finalizado");
            c.SubItems.Add("");
            c.SubItems.Add("");
            c.SubItems.Add("");
            c.SubItems.Add("");
            c.SubItems.Add("");
            c.SubItems.Add("");
            c.SubItems.Add("");
            c.SubItems.Add("");


            listView1.Items.Add(c);

        }
        private void AgregarLisviwBordado(CorteDTO corte, BordadoDTO bordado)
        {
            ListViewItem c = new ListViewItem(corte.IdCorte.ToString());
            c.SubItems.Add("Finalizado");
            c.SubItems.Add(bordado.IdBordado.ToString());
            if (bordado.Estado)
                c.SubItems.Add("En proceso");
            else
                c.SubItems.Add("Finalizado");
            c.SubItems.Add("");
            c.SubItems.Add("");
            c.SubItems.Add("");
            c.SubItems.Add("");
            c.SubItems.Add("");
            c.SubItems.Add("");


            listView1.Items.Add(c);

        }
        private void AgregarLisviwMaquila(CorteDTO corte, BordadoDTO bordado, MaquilaDTO maquila)
        {
            ListViewItem c = new ListViewItem(corte.IdCorte.ToString());
            c.SubItems.Add("Finalizado");
            c.SubItems.Add(bordado.IdBordado.ToString());
            c.SubItems.Add("Finalizado");
            c.SubItems.Add(maquila.IdMaquila.ToString());
            if (maquila.Estado)
                c.SubItems.Add("En proceso");
            else
                c.SubItems.Add("Finalizado");
            c.SubItems.Add("");
            c.SubItems.Add("");
            c.SubItems.Add("");
            c.SubItems.Add("");


            listView1.Items.Add(c);

        }
        private void AgregarLisviwLavanderia(CorteDTO corte, BordadoDTO bordado, MaquilaDTO maquila, LavanderiaDTO lavanderia)
        {
            ListViewItem c = new ListViewItem(corte.IdCorte.ToString());
            c.SubItems.Add("Finalizado");
            c.SubItems.Add(bordado.IdBordado.ToString());
            c.SubItems.Add("Finalizado");
            c.SubItems.Add(maquila.IdMaquila.ToString());
            c.SubItems.Add("Finalizado");
            c.SubItems.Add(lavanderia.IdLavanderia.ToString());
            if (lavanderia.Estado)
                c.SubItems.Add("En proceso");
            else
                c.SubItems.Add("Finalizado");
            c.SubItems.Add("");
            c.SubItems.Add("");


            listView1.Items.Add(c);

        }
        private void AgregarLisviwTerminado(CorteDTO corte, BordadoDTO bordado, MaquilaDTO maquila, LavanderiaDTO lavanderia, TerminadoDTO terminado)
        {
            ListViewItem c = new ListViewItem(corte.IdCorte.ToString());
            c.SubItems.Add("Finalizado");
            c.SubItems.Add(bordado.IdBordado.ToString());
            c.SubItems.Add("Finalizado");
            c.SubItems.Add(maquila.IdMaquila.ToString());
            c.SubItems.Add("Finalizado");
            c.SubItems.Add(lavanderia.IdLavanderia.ToString());
            c.SubItems.Add("Finalizado");
            c.SubItems.Add(terminado.IdTerminado.ToString());
            c.SubItems.Add("Finalizado");


            listView1.Items.Add(c);

        }


        /*---Resumen de procesos End*/
        private void Listas()
        {

            CargarDatosDiseño();
            CargarDatosUsuario();
            CargarDatosLugar();
            //CargarDatosProcesos();
            CargarDatosProcesolavanderia();
            CargarDatosBodega();
            CargarDatosTallas();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Administrador_Load(object sender, EventArgs e)
        {

        }

       

       

       

      

       

        

       
       
    }
}
