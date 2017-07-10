using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace almacen_telar.controller
{
    public class MaquilaCon
    {
        private ConexionBD conexionbd;

        public ConexionBD Conexionbd
        {
            get { return conexionbd; }
            set { conexionbd = value; }
        }
        
        public MaquilaCon()
        {
            if (Conexionbd == null)
            {
                Conexionbd = new ConexionBD();
            }
        }


        public bool AgregarMaquila(Ob.MaquilaDTO maquila)
        {
            try
            {
                
                IDataParameter[] parametros = new IDataParameter[7];

                parametros[0] = new SqlParameter("IdMaquila", SqlDbType.VarChar);
                parametros[0].Value = maquila.IdMaquila;
                parametros[1] = new SqlParameter("FechaResepcion", SqlDbType.DateTime);
                parametros[1].Value = maquila.FechaEntrada;
                parametros[2] = new SqlParameter("Cantidad", SqlDbType.Int);
                parametros[2].Value = maquila.Cantidad;
                parametros[3] = new SqlParameter("IdLugarEntrega", SqlDbType.SmallInt);
                parametros[3].Value = maquila.IdLugarEntrega;
                parametros[4] = new SqlParameter("IdUsuario ", SqlDbType.SmallInt);
                parametros[4].Value = maquila.IdUsuario;
                parametros[5] = new SqlParameter("IdPrenda", SqlDbType.SmallInt);
                parametros[5].Value = maquila.IdBordado;
                parametros[6] = new SqlParameter("Estado", SqlDbType.Bit);
                parametros[6].Value = maquila.Estado;
           


                return conexionbd.EjecutarSPSinRetorno("maquilaAgregarMaquila", parametros);
            }
            catch (Exception)
            {
                
                throw;
            }
 
        }
        public bool ActualizarMaquila(Ob.MaquilaDTO maquila)
        {
            try
            {

                IDataParameter[] parametros = new IDataParameter[7];

                parametros[0] = new SqlParameter("IdMaquila", SqlDbType.VarChar);
                parametros[0].Value = maquila.IdMaquila;
                parametros[1] = new SqlParameter("FechaResepcion", SqlDbType.DateTime);
                parametros[1].Value = maquila.FechaEntrada;
                parametros[2] = new SqlParameter("Cantidad", SqlDbType.Int);
                parametros[2].Value = maquila.Cantidad;
                parametros[3] = new SqlParameter("IdLugarEntrega", SqlDbType.SmallInt);
                parametros[3].Value = maquila.IdLugarEntrega;
                parametros[4] = new SqlParameter("IdUsuario ", SqlDbType.SmallInt);
                parametros[4].Value = maquila.IdUsuario;
                parametros[5] = new SqlParameter("IdPrenda", SqlDbType.SmallInt);
                parametros[5].Value = maquila.IdBordado;
                parametros[6] = new SqlParameter("Estado", SqlDbType.Bit);
                parametros[6].Value = maquila.Estado;



                return conexionbd.EjecutarSPSinRetorno("maquilaActualizaMaquila", parametros);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<Ob.BordadoDTO> ListaBordadesAMaquila()
        {
            List<Ob.BordadoDTO> bordados = new List<Ob.BordadoDTO>();
            try
            {
                DataTable resultado = conexionbd.EjecutarSPResultSet("bordadosBordadosTerminadosAMaquila", null);

                foreach (DataRow renglon in resultado.Rows)
                {
                    bordados.Add(new Ob.BordadoDTO()
                    {

                        Id = (short)renglon[0],
                        IdBordado = (string)renglon[1],

                    });

                  }
                return bordados;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public bool ObtenerMaquilaID(string idmaquila)
        {
            bool resul = true;
            try
            {

                IDataParameter[] parametros = new IDataParameter[1];

                parametros[0] = new SqlParameter("IdMaquila", SqlDbType.VarChar);
                parametros[0].Value = idmaquila;




                DataTable resultado = conexionbd.EjecutarSPResultSet("proObtenerMaquilaID", parametros);
                foreach (DataRow renglon in resultado.Rows)
                {
                    if (Convert.ToInt32(renglon[0]) > 0)
                    {
                        resul = false;
                    }
                }
                return resul;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public Ob.MaquilaDTO ObtenerMaquilaProceso(short idmaquila)
        {
            Ob.MaquilaDTO maqui = new Ob.MaquilaDTO();
            try
            {

                IDataParameter[] parametros = new IDataParameter[1];

                parametros[0] = new SqlParameter("Id", SqlDbType.SmallInt);
                parametros[0].Value = idmaquila;




                DataTable resultado = conexionbd.EjecutarSPResultSet("maquilaObtenerMaquila", parametros);
                foreach (DataRow renglon in resultado.Rows)
                {
                    maqui.Id = (short)renglon[0];
                    maqui.IdMaquila = (string)renglon[1];
                    maqui.IdBordado = (short)renglon[9];
                    maqui.IdLugarEntrega = (short)renglon[5];
                    maqui.IdPrenda = (short)renglon[7];
                }
                return maqui;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public bool EliminaeMaquilaProceso(short idmaquila)
        {
           
            try
            {

                IDataParameter[] parametros = new IDataParameter[1];

                parametros[0] = new SqlParameter("Id", SqlDbType.SmallInt);
                parametros[0].Value = idmaquila;




                return conexionbd.EjecutarSPSinRetorno("proEliminarMAquilaProceso", parametros);
               
            }
            catch (Exception)
            {

                throw;
            }

        }
        public List<Ob.BordadoDTO> ListaLugaresEntrega()
        {
            List<Ob.BordadoDTO> bordados = new List<Ob.BordadoDTO>();
            try
            {
                DataTable resultado = conexionbd.EjecutarSPResultSet("proListaLugaresMaquilaActivos", null);

                foreach (DataRow renglon in resultado.Rows)
                {
                    bordados.Add(new Ob.BordadoDTO()
                    {

                        Id = (short)renglon[0],
                        IdBordado = (string)renglon[1],

                    });

                }
                return bordados;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public DataTable ListaPorcesoMaquilaSinTerminar()
        {
            
            try
            {

            return   conexionbd.EjecutarSPResultSet("maquilaListaProcesoMaquilaSinTErminar", null);
             }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool ActualizarMaquilaProcesoTerminado(Ob.MaquilaDTO maquila)
        {
            try
            {

                IDataParameter[] parametros = new IDataParameter[5];
                parametros[0] = new SqlParameter("id", SqlDbType.VarChar);
                parametros[0].Value = maquila.Id;
                parametros[1] = new SqlParameter("FechaEntrega", SqlDbType.DateTime);
                parametros[1].Value = maquila.FechaEntrega;
                parametros[2] = new SqlParameter("Cantidad", SqlDbType.Int);
                parametros[2].Value = maquila.Cantidad;
                parametros[3] = new SqlParameter("IdUsuario ", SqlDbType.SmallInt);
                parametros[3].Value = maquila.IdUsuario;
                parametros[4] = new SqlParameter("Estado", SqlDbType.Bit);
                parametros[4].Value = maquila.Estado;



                return conexionbd.EjecutarSPSinRetorno("ActualizarMaquiladoTerminado", parametros);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public int NumeroMaquila()
        {
            int ID = 0;
            try
            {

                DataTable resultado = conexionbd.EjecutarSPResultSet("IDMaquila", null);

                foreach (DataRow renglon in resultado.Rows)
                {
                    if(renglon[0].ToString() != "")
                    ID = Convert.ToInt32(renglon[0]);
                }

                return ID;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int ObtenerCantidadPiezasMaquila(short ID)
        {

            int resul = 0;
            try
            {
                IDataParameter[] parametros = new IDataParameter[1];
                parametros[0] = new SqlParameter("IdPrenda", SqlDbType.SmallInt);
                parametros[0].Value = ID;
                DataTable resultado = conexionbd.EjecutarSPResultSet("bordadoObtenerCantidadPiezasDeMaquila", parametros);

                foreach (DataRow renglon in resultado.Rows)
                {

                    resul = (int)renglon[0];

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            //borra
            finally
            {
                GC.Collect();
            }
            return resul;
        }

    }
}
