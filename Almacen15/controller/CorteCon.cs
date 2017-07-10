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
    public class CorteCon
    {
        private ConexionBD conexionbd;
        /// <summary>
        /// crea la conexion se produce escribiendo profful y dos veces tab y se modifica los valores
        /// no puedes solo copiar y pegar pero si poner igual los valores como esta
        /// </summary>
        public ConexionBD Conexionbd 
        {
            get { return conexionbd; }
            set { conexionbd = value; }
        }
        /// <summary>
        /// realiza la conexion a la cllase de conexion
        /// este se produce escribirndo cort y dos veces tab
        /// </summary>
        public CorteCon()
        {
            if (conexionbd == null)
            {
                conexionbd = new ConexionBD();
            }
        }
        /// <summary>
        /// Obtiene un listado de todos los proceso que se estan trabajando 
        /// los procesos que ya se terminaron ya no aparecen
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable ObtenerListaCorte()
        {
          
           
            try
            {
                return conexionbd.EjecutarSPResultSet("corteListaCortesEnProceso", null);

                

            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        public DataTable ListaTallas()
        {
            
            DataTable resultado;
            try
            {
                resultado = conexionbd.EjecutarSPResultSet("proListaTallasActivas", null);

            

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
            return resultado;
        }
       
       
        /// <summary>
        /// Actualiza el proceso a terminado y no volvera a parecer en la lista de corte
        /// </summary>
        /// <param name="corte"></param>
        /// <returns></returns>
        public bool ActualizarCorteTerminado(Ob.CorteDTO corte)
        {
            try
            {
                IDataParameter[] parametros = new IDataParameter[3];
                parametros[0] = new SqlParameter("id", SqlDbType.VarChar);
                parametros[0].Value = corte.Id;
                parametros[1] = new SqlParameter("FechaEntrega", SqlDbType.DateTime);
                parametros[1].Value = corte.FechaEntrega;
                parametros[2] = new SqlParameter("Estado", SqlDbType.Bit);
                parametros[2].Value = corte.Estado;


                return conexionbd.EjecutarSPSinRetorno("ActualizarCorteTerminado", parametros);

            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// acttrualiza el corte por medio del usuario administrador
        /// </summary>
        /// <param name="corte"></param>
        /// <returns></returns>
     
        /// <summary>
        /// elimina el corte
        /// </summary>
        /// <param name="idCorte"></param>
        /// <returns></returns>
        public bool EliminarCorte(short idCorte)
        {
            try
            {
                IDataParameter[] parametros = new IDataParameter[1];
                parametros[0] = new SqlParameter("id", SqlDbType.SmallInt);
                parametros[0].Value = idCorte;

                return conexionbd.EjecutarSPSinRetorno("proEliminarCorteProceso", parametros);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// obtiene el proceso a modificar
        /// </summary>
        /// <param name="idcorte"></param>
        /// <returns></returns>
     
        public bool ObtenerCorteID(string idcorte)
        {
            bool resultad = true;
            try
            {

                IDataParameter[] parametros = new IDataParameter[1];
                parametros[0] = new SqlParameter("idCorte", SqlDbType.VarChar);
                parametros[0].Value = idcorte;

                DataTable resultado = conexionbd.EjecutarSPResultSet("corteExixtenciaDelIdCorte", parametros);
                ResultadDTO re = new ResultadDTO();
                foreach (DataRow renglon in resultado.Rows)
                {

                  
                    if (Convert.ToInt32( renglon[0] )> 0)
                    {
                        resultad = false;
                    }
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
            return resultad;

        }

        public int NumeroCorte()
        {
            int ID = 0;
            try
            {

                DataTable resultado = conexionbd.EjecutarSPResultSet("IDCorte", null);
                
                foreach (DataRow renglon in resultado.Rows)
                {
                    if (renglon[0].ToString() != "")
                  ID= Convert.ToInt32( renglon[0]);
                }

                return ID;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        ///Cambios///
        ///

        public short CrarPrenda(int IdDiseño)
        {
            try
            {
                short IdPrenda = 0;

                IDataParameter[] parametros = new IDataParameter[1];

                parametros[0] = new SqlParameter("IdDiseño", SqlDbType.SmallInt);
                parametros[0].Value = IdDiseño;


                if (conexionbd.EjecutarSPSinRetorno("prendaAgregarPrenda", parametros))
                {
                    DataTable resulta = conexionbd.EjecutarSPResultSet("IDPrenda", null);
                    foreach (DataRow item in resulta.Rows)
                    {
                        IdPrenda = (short)item[0];
                    }
                        
                }


                return IdPrenda;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool CrarDetallesDePrenda(List<DetallesDTO> ListaDetalles ,short IdPrenda)
        {
            bool resul = false;

            try
            {
               
                foreach (DetallesDTO item in ListaDetalles)
                {
                    IDataParameter[] parametros = new IDataParameter[3];

                    parametros[0] = new SqlParameter("IdPrenda", SqlDbType.SmallInt);
                    parametros[0].Value = IdPrenda;
                    parametros[1] = new SqlParameter("IdTalla", SqlDbType.Int);
                    parametros[1].Value = item.IdTallas;
                    parametros[2] = new SqlParameter("Cantidad", SqlDbType.Int);
                    parametros[2].Value = item.Cantidad;



                     conexionbd.EjecutarSPSinRetorno("detalleAgregarDetalle", parametros);
                    resul = true;
                }
                
            }
            catch (Exception ex)
            {
                resul = false;
                
            }
            return resul;
        }

        public bool AgregarCorte(CorteDTO corte)
        {
            try
            {
                IDataParameter[] parametros = new IDataParameter[6];

                parametros[0] = new SqlParameter("IdCorte", SqlDbType.VarChar);
                parametros[0].Value = corte.IdCorte;
                parametros[1] = new SqlParameter("FechaEntrada", SqlDbType.DateTime);
                parametros[1].Value = corte.FechaEntrada;
                parametros[2] = new SqlParameter("Piezas", SqlDbType.Int);
                parametros[2].Value = corte.Piezas;
                parametros[3] = new SqlParameter("IdPrenda", SqlDbType.SmallInt);
                parametros[3].Value = corte.IdPrenda;
                parametros[4] = new SqlParameter("IdUsuario", SqlDbType.SmallInt);
                parametros[4].Value = corte.IdUsuario;
                parametros[5] = new SqlParameter("Estado", SqlDbType.Bit);
                parametros[5].Value = corte.Estado;


                return conexionbd.EjecutarSPSinRetorno("corteAgregarCorte", parametros);

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public CorteDTO ObtenerCorteProceso(int idcorte)
        {
            Ob.CorteDTO corte = new Ob.CorteDTO();
            try
            {

                IDataParameter[] parametros = new IDataParameter[1];
                parametros[0] = new SqlParameter("id", SqlDbType.SmallInt);
                parametros[0].Value = idcorte;

                DataTable resultado = conexionbd.EjecutarSPResultSet("corteObtenerCorte", parametros);

                foreach (DataRow renglon in resultado.Rows)
                {

                    corte.Id = (short)renglon[0];
                    corte.IdCorte = (string)renglon[1];
                    corte.Piezas = (int)renglon[2];
                    corte.prendaIdDiseño = Convert.ToInt32( renglon[3]);
                    corte.IdPrenda = Convert.ToInt32(renglon[4]);



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
            return corte;

        }

        public double ObtenerTalla(int idTalla)
        {
            double talla = 0;
            try
            {

                IDataParameter[] parametros = new IDataParameter[1];
                parametros[0] = new SqlParameter("IdTalla", SqlDbType.Int);
                parametros[0].Value = idTalla;

                DataTable resultado = conexionbd.EjecutarSPResultSet("corteObtenerTallanombre", parametros);

                foreach (DataRow renglon in resultado.Rows)
                {

                    talla = (double)renglon[0];
                    



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
            return talla;

        }

        public bool ActualizarCorte(CorteDTO corte)
        {
            try
            {
                bool resul = false;
                IDataParameter[] parametros = new IDataParameter[2];
                parametros[0] = new SqlParameter("id", SqlDbType.SmallInt);
                parametros[0].Value = corte.Id;
                parametros[1] = new SqlParameter("idCorte", SqlDbType.VarChar);
                parametros[1].Value = corte.IdCorte;

                if (conexionbd.EjecutarSPSinRetorno("corteActualizarCorte", parametros))
                {
                    IDataParameter[] parametros1 = new IDataParameter[2];
                    parametros1[0] = new SqlParameter("id", SqlDbType.SmallInt);
                    parametros1[0].Value = corte.Id;
                    parametros1[1] = new SqlParameter("IdDiseño", SqlDbType.SmallInt);
                    parametros1[1].Value = corte.prendaIdDiseño;
                    if (conexionbd.EjecutarSPSinRetorno("prendaActualizarPrenda", parametros1))
                    {
                        resul = true;
                    }
                }
                return resul;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public int ObtenerCantidadPiezasCorte(short ID)
        {

            int resul = 0;
            try
            {
                IDataParameter[] parametros = new IDataParameter[1];
                parametros[0] = new SqlParameter("IdPrenda", SqlDbType.VarChar);
                parametros[0].Value = ID;
                DataTable resultado = conexionbd.EjecutarSPResultSet("corteObtenerCantidadPiezasDeCorte", parametros);

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
