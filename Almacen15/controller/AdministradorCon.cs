using almacen_telar.Ob;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace almacen_telar.controller
{
    class AdministradorCon
    {

        private ConexionBD conexionbd;

        public ConexionBD Conexionbd
        {
            get { return conexionbd; }
            set { conexionbd = value; }
        }

        public AdministradorCon()
        {
            if (Conexionbd == null)
            {
                conexionbd = new ConexionBD();
            }
        }


        public bool AgregarUsuario(Ob.UsuarioDTO user)
        {
            try
            {
                IDataParameter[] parametros = new IDataParameter[4];
                parametros[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                parametros[0].Value = user.Nombre;
                parametros[1] = new SqlParameter("Usuario", SqlDbType.VarChar);
                parametros[1].Value = user.User;
                parametros[2] = new SqlParameter("Password", SqlDbType.VarChar);
                parametros[2].Value = user.Password;
                parametros[3] = new SqlParameter("Tipo", SqlDbType.VarChar);
                parametros[3].Value = user.Tipo;


                return conexionbd.EjecutarSPSinRetorno("proAgregarUsuario", parametros);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Consulte con el administrador" + ex);
                throw;
            }
        }
        public DataTable ListaUsuarios()
        {

            try
            {
                return conexionbd.EjecutarSPResultSet("proListaUsuarios", null);

            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Lugar entregas
        /// </summary>
        /// <returns></returns>
        public DataTable ListaLugarEntregas()
        {

            try
            {
                return conexionbd.EjecutarSPResultSet("proListaLugares", null);

            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable ListaProcesosLavanderias()
        {

            try
            {
                return conexionbd.EjecutarSPResultSet("proListaProcesosLAvanderia", null);

            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable ListaDeProcesos()
        {

            try
            {
                return conexionbd.EjecutarSPResultSet("corteListaCortesEnProceso", null);

            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable ListaLugaresEntrega()
        {

            try
            {
                return conexionbd.EjecutarSPResultSet("", null);

            }
            catch (Exception)
            {

                throw;
            }
        }


        /// <summary>
        /// usuario
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>

        public bool EliminarUsuario(short idUsuario)
        {
            try
            {
                IDataParameter[] parametros = new IDataParameter[1];
                parametros[0] = new SqlParameter("id", SqlDbType.SmallInt);
                parametros[0].Value = idUsuario;

                return conexionbd.EjecutarSPSinRetorno("proEliminarUsuario", parametros);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool ActualizarUsuario(Ob.UsuarioDTO user)
        {
            try
            {
                IDataParameter[] parametros = new IDataParameter[5];
                parametros[0] = new SqlParameter("id", SqlDbType.SmallInt);
                parametros[0].Value = user.Id;
                parametros[1] = new SqlParameter("Nombre", SqlDbType.VarChar);
                parametros[1].Value = user.Nombre;
                parametros[2] = new SqlParameter("Usuario", SqlDbType.VarChar);
                parametros[2].Value = user.User;
                parametros[3] = new SqlParameter("Password", SqlDbType.VarChar);
                parametros[3].Value = user.Password;
                parametros[4] = new SqlParameter("Tipo", SqlDbType.VarChar);
                parametros[4].Value = user.Tipo;


                return conexionbd.EjecutarSPSinRetorno("proActualizarUsuario", parametros);

            }
            catch (Exception)
            {

                throw;
            }
        }



        //////////////Cortes///////////
        public bool AgregarCorte(string Nombre, bool activo)
        {
            try
            {
                IDataParameter[] parametros = new IDataParameter[2];
                parametros[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                parametros[0].Value = Nombre;
                parametros[1] = new SqlParameter("Activo", SqlDbType.Bit);
                parametros[1].Value = activo;



                return conexionbd.EjecutarSPSinRetorno("proAgregarNombreCorte", parametros);

            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool ActualizarCorte(string Nombre, bool activo, int id)
        {
            try
            {
                IDataParameter[] parametros = new IDataParameter[3];
                parametros[0] = new SqlParameter("id", SqlDbType.Int);
                parametros[0].Value = id;
                parametros[1] = new SqlParameter("Nombre", SqlDbType.VarChar);
                parametros[1].Value = Nombre;
                parametros[2] = new SqlParameter("Activo", SqlDbType.Bit);
                parametros[2].Value = activo;



                return conexionbd.EjecutarSPSinRetorno("proActualizarNombreCorte", parametros);

            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool EliminarNombreCorte(int idCorte)
        {
            try
            {
                IDataParameter[] parametros = new IDataParameter[1];
                parametros[0] = new SqlParameter("id", SqlDbType.Int);
                parametros[0].Value = idCorte;

                return conexionbd.EjecutarSPSinRetorno("proEliminarNombreCorte", parametros);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<string> ObtenerCorte(int id)
        {
            List<string> NombreCorte = new List<string>();
            try
            {
                IDataParameter[] parametros = new IDataParameter[1];
                parametros[0] = new SqlParameter("id", SqlDbType.Int);
                parametros[0].Value = id;




                DataTable resultado = conexionbd.EjecutarSPResultSet("proObtenerNombreCorte", parametros);

                if (resultado != null)
                {

                    foreach (DataRow renglon in resultado.Rows)
                    {
                        NombreCorte.Add((string)renglon[0]);
                        if ((bool)renglon[1] == true)
                            NombreCorte.Add("true");
                        else
                            NombreCorte.Add("false");

                    }
                }
                return NombreCorte;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        //////////////Lugar entrega///////////
        public bool AgregarLugarEntrega(LugarEntregaDTO lugar)
        {
            try
            {
                IDataParameter[] parametros = new IDataParameter[4];
                parametros[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                parametros[0].Value = lugar.Nombre;
                parametros[1] = new SqlParameter("Direccion", SqlDbType.VarChar);
                parametros[1].Value = lugar.Direccion;
                parametros[2] = new SqlParameter("Telefono", SqlDbType.VarChar);
                parametros[2].Value = lugar.Telefono;
                parametros[3] = new SqlParameter("Activo", SqlDbType.Bit);
                parametros[3].Value = lugar.Activo;



                return conexionbd.EjecutarSPSinRetorno("proAgregarLugarEntrega", parametros);

            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool ActualizarLugarentrega(LugarEntregaDTO lugar)
        {
            try
            {
                IDataParameter[] parametros = new IDataParameter[5];
                parametros[0] = new SqlParameter("Id", SqlDbType.SmallInt);
                parametros[0].Value = lugar.Id;
                parametros[1] = new SqlParameter("Nombre", SqlDbType.VarChar);
                parametros[1].Value = lugar.Nombre;
                parametros[2] = new SqlParameter("Direccion", SqlDbType.VarChar);
                parametros[2].Value = lugar.Direccion;
                parametros[3] = new SqlParameter("Telefono", SqlDbType.VarChar);
                parametros[3].Value = lugar.Telefono;
                parametros[4] = new SqlParameter("Activo", SqlDbType.Bit);
                parametros[4].Value = lugar.Activo;



                return conexionbd.EjecutarSPSinRetorno("proActualizarLugares", parametros);

            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool EliminarLugar(int idCorte)
        {
            try
            {
                IDataParameter[] parametros = new IDataParameter[1];
                parametros[0] = new SqlParameter("Id", SqlDbType.Int);
                parametros[0].Value = idCorte;

                return conexionbd.EjecutarSPSinRetorno("proEliminaLugar", parametros);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public LugarEntregaDTO ObtenerLugar(int id)
        {
            LugarEntregaDTO Lugar = new LugarEntregaDTO();
            try
            {
                IDataParameter[] parametros = new IDataParameter[1];
                parametros[0] = new SqlParameter("Id", SqlDbType.Int);
                parametros[0].Value = id;

                DataTable resultado = conexionbd.EjecutarSPResultSet("proObtenerLugare", parametros);

                if (resultado != null)
                {

                    foreach (DataRow renglon in resultado.Rows)
                    {
                        Lugar.Id = (short)renglon[0];
                        Lugar.Nombre = (string)renglon[1];
                        Lugar.Direccion = (string)renglon[2];
                        Lugar.Telefono = (string)renglon[3];
                        Lugar.Activo = (bool)renglon[4];
                    }
                }
                return Lugar;

            }
            catch (Exception)
            {

                throw;
            }
        }

        //Procesos de Lavanderia//

        public bool AgregarProcesoLavanderia(LugarEntregaDTO lugar)
        {
            try
            {
                IDataParameter[] parametros = new IDataParameter[3];
                parametros[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                parametros[0].Value = lugar.Nombre;
                parametros[1] = new SqlParameter("Descripcion", SqlDbType.VarChar);
                parametros[1].Value = lugar.Direccion;
                parametros[2] = new SqlParameter("Activo", SqlDbType.Bit);
                parametros[2].Value = lugar.Activo;



                return conexionbd.EjecutarSPSinRetorno("AgregarProcesosLAvanderia", parametros);

            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool ActualizarProcesoDeLavanderia(LugarEntregaDTO lugar)
        {
            try
            {
                IDataParameter[] parametros = new IDataParameter[4];
                parametros[0] = new SqlParameter("Id", SqlDbType.SmallInt);
                parametros[0].Value = lugar.Id;
                parametros[1] = new SqlParameter("Nombre", SqlDbType.VarChar);
                parametros[1].Value = lugar.Nombre;
                parametros[2] = new SqlParameter("Descripcion", SqlDbType.VarChar);
                parametros[2].Value = lugar.Direccion;
                parametros[3] = new SqlParameter("Activo", SqlDbType.Bit);
                parametros[3].Value = lugar.Activo;



                return conexionbd.EjecutarSPSinRetorno("ActualizarProcesosLAvanderia", parametros);

            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool EliminarProcesoDeLavanderia(int id)
        {
            try
            {
                IDataParameter[] parametros = new IDataParameter[1];
                parametros[0] = new SqlParameter("Id", SqlDbType.Int);
                parametros[0].Value = id;

                return conexionbd.EjecutarSPSinRetorno("EliminarProcesosLAvanderia", parametros);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public LugarEntregaDTO ObtenerProcesodeLavanderia(int id)
        {
            LugarEntregaDTO Lugar = new LugarEntregaDTO();
            try
            {
                IDataParameter[] parametros = new IDataParameter[1];
                parametros[0] = new SqlParameter("Id", SqlDbType.Int);
                parametros[0].Value = id;

                DataTable resultado = conexionbd.EjecutarSPResultSet("proObtenerProcesosLAvanderia", parametros);

                if (resultado != null)
                {

                    foreach (DataRow renglon in resultado.Rows)
                    {
                        Lugar.Id = (short)renglon[0];
                        Lugar.Nombre = (string)renglon[1];
                        Lugar.Direccion = (string)renglon[2];
                        Lugar.Activo = (bool)renglon[3];

                    }
                }
                return Lugar;

            }
            catch (Exception)
            {

                throw;
            }
        }

        // bodegas ///
        public bool AgregarBodega(LugarEntregaDTO lugar)
        {
            try
            {
                IDataParameter[] parametros = new IDataParameter[3];
                parametros[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                parametros[0].Value = lugar.Nombre;
                parametros[1] = new SqlParameter("IdUsuario", SqlDbType.VarChar);
                parametros[1].Value = lugar.Idusuario;
                parametros[2] = new SqlParameter("Estado", SqlDbType.Bit);
                parametros[2].Value = lugar.Activo;



                return conexionbd.EjecutarSPSinRetorno("proAgregarBodega", parametros);

            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool ActualizarBodega(LugarEntregaDTO lugar)
        {
            try
            {
                IDataParameter[] parametros = new IDataParameter[4];
                parametros[0] = new SqlParameter("Id", SqlDbType.SmallInt);
                parametros[0].Value = lugar.Id;
                parametros[1] = new SqlParameter("Nombre", SqlDbType.VarChar);
                parametros[1].Value = lugar.Nombre;
                parametros[2] = new SqlParameter("IdUsuario", SqlDbType.VarChar);
                parametros[2].Value = lugar.Idusuario;
                parametros[3] = new SqlParameter("Estado", SqlDbType.Bit);
                parametros[3].Value = lugar.Activo;



                return conexionbd.EjecutarSPSinRetorno("proActualizarBodega", parametros);

            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool EliminarBodega(int id)
        {
            try
            {
                IDataParameter[] parametros = new IDataParameter[1];
                parametros[0] = new SqlParameter("Id", SqlDbType.Int);
                parametros[0].Value = id;

                return conexionbd.EjecutarSPSinRetorno("proEliminarBodega", parametros);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataTable ListaBodegas()
        {

            try
            {
                return conexionbd.EjecutarSPResultSet("proListaDeBodegas", null);

            }
            catch (Exception)
            {

                throw;
            }
        }
        public LugarEntregaDTO ObtenerBodega(int id)
        {
            LugarEntregaDTO Lugar = new LugarEntregaDTO();
            try
            {
                IDataParameter[] parametros = new IDataParameter[1];
                parametros[0] = new SqlParameter("id", SqlDbType.Int);
                parametros[0].Value = id;

                DataTable resultado = conexionbd.EjecutarSPResultSet("proObtenerBodega", parametros);

                if (resultado != null)
                {

                    foreach (DataRow renglon in resultado.Rows)
                    {
                        Lugar.Id = (short)renglon[0];
                        Lugar.Nombre = (string)renglon[1];
                        Lugar.Idusuario = (short)renglon[2];
                        Lugar.Activo = (bool)renglon[3];
                    }
                }
                return Lugar;

            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<UsuarioDTO> UsuariosActivos()
        {
            List<UsuarioDTO> Lugar = new List<UsuarioDTO>();
            try
            {

                DataTable resultado = conexionbd.EjecutarSPResultSet("proObtenerUsuarios", null);

                if (resultado != null)
                {

                    foreach (DataRow renglon in resultado.Rows)
                    {
                        Lugar.Add(new UsuarioDTO() { Id = (short)renglon[0], Nombre = (string)renglon[1] });
                    }
                }
                return Lugar;

            }
            catch (Exception)
            {

                throw;
            }
        }


        //tallas
        public bool AgregarTallas(LugarEntregaDTO lugar)
        {
            try
            {
                IDataParameter[] parametros = new IDataParameter[2];
                parametros[0] = new SqlParameter("Talla", SqlDbType.Float);
                parametros[0].Value = lugar.Nombre;

                parametros[1] = new SqlParameter("activo", SqlDbType.Bit);
                parametros[1].Value = lugar.Activo;



                return conexionbd.EjecutarSPSinRetorno("tallaAgregarTalla", parametros);

            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool ActualizarTallas(LugarEntregaDTO lugar)
        {
            try
            {
                IDataParameter[] parametros = new IDataParameter[3];
                parametros[0] = new SqlParameter("Id", SqlDbType.Int);
                parametros[0].Value = lugar.Id;
                parametros[1] = new SqlParameter("Talla", SqlDbType.Float);
                parametros[1].Value = lugar.Nombre;

                parametros[2] = new SqlParameter("activo", SqlDbType.Bit);
                parametros[2].Value = lugar.Activo;



                return conexionbd.EjecutarSPSinRetorno("proActualizarTallas", parametros);

            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool EliminarTalla(int id)
        {
            try
            {
                IDataParameter[] parametros = new IDataParameter[1];
                parametros[0] = new SqlParameter("Id", SqlDbType.Int);
                parametros[0].Value = id;

                return conexionbd.EjecutarSPSinRetorno("proEliminarTallas", parametros);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataTable ListaTallas()
        {

            try
            {
                return conexionbd.EjecutarSPResultSet("proListaTallas", null);

            }
            catch (Exception)
            {

                throw;
            }
        }
        public LugarEntregaDTO ObtenerTallas(int id)
        {
            LugarEntregaDTO Lugar = new LugarEntregaDTO();
            try
            {
                IDataParameter[] parametros = new IDataParameter[1];
                parametros[0] = new SqlParameter("Id", SqlDbType.Int);
                parametros[0].Value = id;

                DataTable resultado = conexionbd.EjecutarSPResultSet("proObtenerTalla", parametros);

                if (resultado != null)
                {

                    foreach (DataRow renglon in resultado.Rows)
                    {
                        Lugar.Id = Convert.ToInt16(renglon[0]);
                        Lugar.Talla = (Double)renglon[1];

                        Lugar.Activo = (bool)renglon[2];
                    }
                }
                return Lugar;

            }
            catch (Exception)
            {

                throw;
            }
        }

        //PRocesos
        public List<DetallesDTO> ObtenerListaDePrendas()
        {
            List<DetallesDTO> lista = new List<DetallesDTO>();

                     DataTable resultado = conexionbd.EjecutarSPResultSet("ObtenerListaDePrendas", null);

                if (resultado != null)
                {

                    foreach (DataRow renglon in resultado.Rows)
                    {
                    lista.Add(new DetallesDTO() {
                        Id = (short)renglon[0]
                    });
                    }
                }
                return lista;
        }

        public CorteDTO ProcesoCorte(short idPrenda)
        {
            CorteDTO lista = new CorteDTO();
            IDataParameter[] parametros = new IDataParameter[1];
            parametros[0] = new SqlParameter("IDPrenda", SqlDbType.SmallInt);
            parametros[0].Value = idPrenda;

            DataTable resultado = conexionbd.EjecutarSPResultSet("ObtenerCortePrenda", parametros);

            if (resultado != null)
            {

                foreach (DataRow renglon in resultado.Rows)
                {

                    lista.IdCorte = (string)renglon[1];
                    lista.Estado = (bool)renglon[7];
                   
                   
                }
            }
            return lista;
        }
        public BordadoDTO ProcesoBordado(short idPrenda)
        {
            BordadoDTO lista = new BordadoDTO();
            IDataParameter[] parametros = new IDataParameter[1];
            parametros[0] = new SqlParameter("IDPrenda", SqlDbType.SmallInt);
            parametros[0].Value = idPrenda;

            DataTable resultado = conexionbd.EjecutarSPResultSet("ObtenerBordadoPrenda", parametros);

            if (resultado != null)
            {

                foreach (DataRow renglon in resultado.Rows)
                {

                    lista.IdBordado = (string)renglon[1];
                    lista.Estado = (bool)renglon[9];


                }
            }
            return lista;
        }
        public MaquilaDTO ProcesoMaquila(short idPrenda)
        {
            MaquilaDTO lista = new MaquilaDTO();
            IDataParameter[] parametros = new IDataParameter[1];
            parametros[0] = new SqlParameter("IDPrenda", SqlDbType.SmallInt);
            parametros[0].Value = idPrenda;

            DataTable resultado = conexionbd.EjecutarSPResultSet("ObtenerMaquilaPrenda", parametros);

            if (resultado != null)
            {

                foreach (DataRow renglon in resultado.Rows)
                {

                    lista.IdMaquila = (string)renglon[1];
                    lista.Estado = (bool)renglon[8];


                }
            }
            return lista;
        }
        public LavanderiaDTO ProcesoLavanderia(short idPrenda)
        {
            LavanderiaDTO lista = new LavanderiaDTO();
            IDataParameter[] parametros = new IDataParameter[1];
            parametros[0] = new SqlParameter("IDPrenda", SqlDbType.SmallInt);
            parametros[0].Value = idPrenda;

            DataTable resultado = conexionbd.EjecutarSPResultSet("ObtenerLavanderiaPrenda", parametros);

            if (resultado != null)
            {

                foreach (DataRow renglon in resultado.Rows)
                {

                    lista.IdLavanderia = (string)renglon[1];
                    lista.Estado = (bool)renglon[7];


                }
            }
            return lista;
        }
        public TerminadoDTO ProcesoTerminado(short idPrenda)
        {
            TerminadoDTO lista = new TerminadoDTO();
            IDataParameter[] parametros = new IDataParameter[1];
            parametros[0] = new SqlParameter("IDPrenda", SqlDbType.SmallInt);
            parametros[0].Value = idPrenda;

            DataTable resultado = conexionbd.EjecutarSPResultSet("ObtenerTerminadoPrenda", parametros);

            if (resultado != null)
            {

                foreach (DataRow renglon in resultado.Rows)
                {

                    lista.IdTerminado = (string)renglon[1];
                    lista.Estado = (bool)renglon[7];


                }
            }
            return lista;
        }
    }
}
