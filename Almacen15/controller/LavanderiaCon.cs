using almacen_telar.Ob;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace almacen_telar.controller
{
    class LavanderiaCon
    {
        private ConexionBD conexionbd;

        public ConexionBD Conexionbd
        {
            get { return conexionbd; }
            set { conexionbd = value; }
        }

        public LavanderiaCon()
        {
            if (Conexionbd==null)
            {
                Conexionbd = new ConexionBD();
            }
        }

        public bool AgregarLavanteria(LavanderiaDTO lav)
        {
            try
            {

                IDataParameter[] parametros = new IDataParameter[7];

                parametros[0] = new SqlParameter("IdLavanderia", SqlDbType.VarChar);
                parametros[0].Value = lav.IdLavanderia;
                parametros[1] = new SqlParameter("FechaRecepcion", SqlDbType.DateTime);
                parametros[1].Value = lav.FechaRecepcion;
                parametros[2] = new SqlParameter("NumeroPiezas", SqlDbType.Int);
                parametros[2].Value = lav.NumeroPiezas;
                parametros[3] = new SqlParameter("IdProceso", SqlDbType.SmallInt);
                parametros[3].Value = lav.IdProceso;
                parametros[4] = new SqlParameter("IdPrenda", SqlDbType.SmallInt);
                parametros[4].Value = lav.IdMaquila;
                parametros[5] = new SqlParameter("Estado", SqlDbType.Bit);
                parametros[5].Value = lav.Estado;
                parametros[6] = new SqlParameter("IdUsuario", SqlDbType.SmallInt);
                parametros[6].Value = lav.IdUsuario;

                return conexionbd.EjecutarSPSinRetorno("lavanderiaAgregarLavanderia", parametros);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public bool ActualizarLavanteria(LavanderiaDTO lav)
        {
            try
            {

                IDataParameter[] parametros = new IDataParameter[5];


                parametros[0] = new SqlParameter("Id", SqlDbType.VarChar);
                parametros[0].Value = lav.Id;
                parametros[1] = new SqlParameter("IdLavanderia", SqlDbType.VarChar);
                parametros[1].Value = lav.IdLavanderia;
              
                parametros[2] = new SqlParameter("NumeroPiezas", SqlDbType.Int);
                parametros[2].Value = lav.NumeroPiezas;
                parametros[3] = new SqlParameter("IdProceso", SqlDbType.SmallInt);
                parametros[3].Value = lav.IdProceso;
                parametros[4] = new SqlParameter("IdMaquila ", SqlDbType.SmallInt);
                parametros[4].Value = lav.IdMaquila;


                return conexionbd.EjecutarSPSinRetorno("proActualizarProcesoLavanderia", parametros);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public bool EliminarLavanteria(short lav)
        {
            try
            {

                IDataParameter[] parametros = new IDataParameter[1];


                parametros[0] = new SqlParameter("Id", SqlDbType.VarChar);
                parametros[0].Value = lav;
               return conexionbd.EjecutarSPSinRetorno("proEliminarLavanderia", parametros);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public DataTable ListaPorcesoLavanderiaSinTerminar()
        {

            try
            {

                return conexionbd.EjecutarSPResultSet("lavanderiaListaLavanderiaInactivos", null);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<LavanderiaDTO> ListaProcesos()
        {
            List<LavanderiaDTO> procesos = new List<LavanderiaDTO>();
            try
            {
                DataTable resultado = conexionbd.EjecutarSPResultSet("proListaDeProcesos", null);

                foreach (DataRow renglon in resultado.Rows)
                {
                    procesos.Add(new LavanderiaDTO()
                    {

                        Id = (short)renglon[0],
                        IdLavanderia = (string)renglon[1],

                    });

                }
                return procesos;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public List<LavanderiaDTO> ListaProcesosMaquilaSinTerminar()
        {
            List<LavanderiaDTO> maquila = new List<LavanderiaDTO>();
            try
            {
                DataTable resultado = conexionbd.EjecutarSPResultSet("proMaquilaEnEspera", null);

                foreach (DataRow renglon in resultado.Rows)
                {
                    maquila.Add(new LavanderiaDTO()
                    {

                        Id = (short)renglon[0],
                        IdLavanderia = (string)renglon[1],

                    });

                }
                return maquila;
            }
            catch (Exception ex)
            {

                throw;
            }
        }



        public bool ProcesoTerminadoLavandria(LavanderiaDTO lav)
        {
            try
            {

                IDataParameter[] parametros = new IDataParameter[5];

                parametros[0] = new SqlParameter("Id", SqlDbType.SmallInt);
                parametros[0].Value = lav.Id;
                parametros[1] = new SqlParameter("FechaEntrega", SqlDbType.DateTime);
                parametros[1].Value = lav.FechaEntrega;
                parametros[2] = new SqlParameter("NumeroPiezas", SqlDbType.Int);
                parametros[2].Value = lav.NumeroPiezas;
                parametros[3] = new SqlParameter("Estado", SqlDbType.Bit);
                parametros[3].Value = lav.Estado;
                parametros[4] = new SqlParameter("IdUsuario", SqlDbType.SmallInt);
                parametros[4].Value = lav.IdUsuario;

                return conexionbd.EjecutarSPSinRetorno("porProcesoLavanderiaTerminado", parametros);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public LavanderiaDTO ObtenerLavanderia(short lav)
        {
            LavanderiaDTO lavanderia = new LavanderiaDTO();
            try
            {
                IDataParameter[] parametros = new IDataParameter[1];

                parametros[0] = new SqlParameter("Id", SqlDbType.SmallInt);
                parametros[0].Value = lav;
                DataTable resultado = conexionbd.EjecutarSPResultSet("lavanderiaObtenerLavanderia", parametros);

                foreach (DataRow renglon in resultado.Rows)
                {

                    lavanderia.Id = (short)renglon[0];
                    lavanderia.IdLavanderia = (string)renglon[1];
                    lavanderia.IdProceso = (short)renglon[5];
                    lavanderia.IdMaquila = (short)renglon[9];
                    lavanderia.IdPrenda = (short)renglon[6];



                }
                return lavanderia;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool ObtenerLavanderiaID(string lav)
        {
           bool resul = true;
            try
            {
                IDataParameter[] parametros = new IDataParameter[1];

                parametros[0] = new SqlParameter("Id", SqlDbType.VarChar);
                parametros[0].Value = lav;
                DataTable resultado = conexionbd.EjecutarSPResultSet("proObtenerLavanderiaID", parametros);

                foreach (DataRow renglon in resultado.Rows)
                {

                   if(Convert.ToInt32(renglon[0])>0)
                   {
                       resul = false;
                   }
                 

                }
                return resul;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public int NumeroLavanderia()
        {
            int ID = 0;
            try
            {

                DataTable resultado = conexionbd.EjecutarSPResultSet("IdLavandera", null);

                foreach (DataRow renglon in resultado.Rows)
                {
                    if (renglon[0].ToString() != "")
                        ID = Convert.ToInt32(renglon[0]);
                }

                return ID;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int ObtenerCantidadPiezasLavanderia(short ID)
        {

            int resul = 0;
            try
            {
                IDataParameter[] parametros = new IDataParameter[1];
                parametros[0] = new SqlParameter("IdPrenda", SqlDbType.SmallInt);
                parametros[0].Value = ID;
                DataTable resultado = conexionbd.EjecutarSPResultSet("bordadoObtenerCantidadPiezasDeLavanderia", parametros);

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
