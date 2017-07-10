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
    public  class TerminadoCon
    {
        private ConexionBD conexionbd;

        public ConexionBD Conexiodb
        {
            get { return conexionbd; }
            set { conexionbd = value; }
        }
        
        public TerminadoCon()
        {
            if (Conexiodb == null)
            {
                Conexiodb = new ConexionBD();
            }
        }

        public DataTable ObtenerListaProcesoTerminado()
        {
            try
            {
              
                    return conexionbd.EjecutarSPResultSet("terminadoListaTerminadoInactivos", null);
                    
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        public List<ResultadDTO> ObtenerListaProcesoLavanderiaTerminado()
        {
            try
            {
                List<ResultadDTO> lista = new List<ResultadDTO>();
                DataTable resulta= conexionbd.EjecutarSPResultSet("lavanderiaListaLavanderiaTerminado", null);
                foreach (DataRow renglon in resulta.Rows)
                {
                    lista.Add(new ResultadDTO()
                    {
                        Id = (short)renglon[0],
                        Descripcion = (string)renglon[1]

                    });

                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public TerminadoDTO ObtenerTerminado(short id)
        {
            try
            {
               TerminadoDTO resul = new TerminadoDTO();
                IDataParameter[] parametros = new IDataParameter[1];
                parametros[0] = new SqlParameter("id", SqlDbType.VarChar);
                parametros[0].Value = id;


                DataTable resulta = conexionbd.EjecutarSPResultSet("terminadoObtenerTerminado", parametros);
                foreach (DataRow renglon in resulta.Rows)
                {
                    if (Convert.ToInt32(renglon[0]) > 0)
                    {
                        resul.Id=(short)renglon[0];
                        resul.IdTerminado=(string)renglon[1];
                        resul.IdLavanderia = (short)renglon[8];
                       resul.IdPrenda = (short)renglon[5];
                    }

                }

                return resul;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool ObtenerTerminadoID(string id)
        {
            try
            {
                bool resul = true;
                IDataParameter[] parametros = new IDataParameter[1];
                parametros[0] = new SqlParameter("idTerminado", SqlDbType.VarChar);
                parametros[0].Value = id;


                DataTable resulta = conexionbd.EjecutarSPResultSet("proObtenerTerminadoID", parametros);
                foreach (DataRow renglon in resulta.Rows)
                {
                    if (Convert.ToInt32(renglon[0]) > 0)
                    {
                        resul = false;
                    }

                }

                return resul;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool AgregarTerminado(TerminadoDTO terminado)
        {
            try
            {
                IDataParameter[] parametros = new IDataParameter[6];

                parametros[0] = new SqlParameter("IdTerminado", SqlDbType.VarChar);
                parametros[0].Value = terminado.IdTerminado;
                parametros[1] = new SqlParameter("FdechaResepcion", SqlDbType.DateTime);
                parametros[1].Value = terminado.FdechaResepcion;
                parametros[2] = new SqlParameter("NumeroPiezas", SqlDbType.Int);
                parametros[2].Value = terminado.NumeroPiezas;
                parametros[3] = new SqlParameter("IdPrenda", SqlDbType.SmallInt);
                parametros[3].Value = terminado.IdLavanderia;
                parametros[4] = new SqlParameter("IdUsuario ", SqlDbType.SmallInt);
                parametros[4].Value = terminado.IdUsuario;
                parametros[5] = new SqlParameter("Estado", SqlDbType.Bit);
                parametros[5].Value = terminado.Estado;
     


                return conexionbd.EjecutarSPSinRetorno("terminadoAgregarTerminado", parametros);

            }
            catch (Exception ex)
            {

                throw;
            }
        }
       
             public bool ActualizarTerminado(TerminadoDTO terminado)
        {
            try
            {
                IDataParameter[] parametros = new IDataParameter[7];

                parametros[0] = new SqlParameter("id", SqlDbType.SmallInt);
                parametros[0].Value = terminado.Id;
                parametros[1] = new SqlParameter("IdTerminado", SqlDbType.VarChar);
                parametros[1].Value = terminado.IdTerminado;
                parametros[2] = new SqlParameter("FdechaResepcion", SqlDbType.DateTime);
                parametros[2].Value = terminado.FdechaResepcion;
                parametros[3] = new SqlParameter("NumeroPiezas", SqlDbType.Int);
                parametros[3].Value = terminado.NumeroPiezas;
                parametros[4] = new SqlParameter("IdPrenda", SqlDbType.SmallInt);
                parametros[4].Value = terminado.IdLavanderia;
                parametros[5] = new SqlParameter("IdUsuario ", SqlDbType.SmallInt);
                parametros[5].Value = terminado.IdUsuario;
                parametros[6] = new SqlParameter("Estado", SqlDbType.Bit);
                parametros[6].Value = terminado.Estado;



                return conexionbd.EjecutarSPSinRetorno("terminadoActualizarTerminado", parametros);

            }
            catch (Exception ex)
            {

                throw;
            }
        }

             public bool ActualizarTerminadoPreceso(TerminadoDTO terminado)
             {
                 try
                 {
                     IDataParameter[] parametros = new IDataParameter[5];

                     parametros[0] = new SqlParameter("id", SqlDbType.SmallInt);
                     parametros[0].Value = terminado.Id;
                     parametros[1] = new SqlParameter("FechaEntrega", SqlDbType.DateTime);
                     parametros[1].Value = terminado.FechaEntrega;
                     parametros[2] = new SqlParameter("NumeroPiezas", SqlDbType.Int);
                     parametros[2].Value = terminado.NumeroPiezas;
                    parametros[3] = new SqlParameter("IdUsuario ", SqlDbType.SmallInt);
                     parametros[3].Value = terminado.IdUsuario;
                     parametros[4] = new SqlParameter("Estado", SqlDbType.Bit);
                     parametros[4].Value = terminado.Estado;



                     return conexionbd.EjecutarSPSinRetorno("proActualizarProcesoTerminado", parametros);

                 }
                 catch (Exception ex)
                 {

                     throw;
                 }
             }

             public bool EliminarTerminado(short idTerminado)
             {
                 try
                 {
                     IDataParameter[] parametros = new IDataParameter[1];
                     parametros[0] = new SqlParameter("id", SqlDbType.SmallInt);
                     parametros[0].Value = idTerminado;

                     return conexionbd.EjecutarSPSinRetorno("prEliminarTerminado", parametros);

                 }
                 catch (Exception ex)
                 {

                     throw ex;
                 }
             }

             public int NumeroTerminado()
             {
                 int ID = 0;
                 try
                 {

                     DataTable resultado = conexionbd.EjecutarSPResultSet("IdTerminado", null);

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
    }
}
