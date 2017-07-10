using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace almacen_telar.controller
{
    public class BordadoCon
    {
        private ConexionBD conexionbd;

        public ConexionBD Conexionbd
        {
            get { return conexionbd; }
            set { conexionbd = value; }
        }


        public BordadoCon()
        {
            if (Conexionbd == null)
            {
                Conexionbd = new ConexionBD();
            }
        }

        public bool AgregarBordado( Ob.BordadoDTO bordado)
        {
            try
            {
                IDataParameter[] parametros = new IDataParameter[8];

                parametros[0] = new SqlParameter("IdBordado", SqlDbType.VarChar);
                parametros[0].Value = bordado.IdBordado;
                parametros[1] = new SqlParameter("NumeroPiezas", SqlDbType.Int);
                parametros[1].Value = bordado.NumeroPiezas;
                parametros[2] = new SqlParameter("NumeroPuntadas", SqlDbType.Int);
                parametros[2].Value = bordado.NumeroPuntadas;
                parametros[3] = new SqlParameter("ParteBordada", SqlDbType.VarChar);
                parametros[3].Value = bordado.ParteBordada;
                parametros[4] = new SqlParameter("FechaInicio ", SqlDbType.DateTime);
                parametros[4].Value = bordado.FechaInicio;
                parametros[5] = new SqlParameter("IdPrenda", SqlDbType.SmallInt);
                parametros[5].Value = bordado.IdPrenda;
                parametros[6] = new SqlParameter("IdUsuario", SqlDbType.SmallInt);
                parametros[6].Value = bordado.IdUsuario;
                parametros[7] = new SqlParameter("Estado", SqlDbType.Bit);
                parametros[7].Value = bordado.Estado;


                return conexionbd.EjecutarSPSinRetorno("bordadoAgregarBordado", parametros);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        //public bool EliminarBordado(Ob.Bordado bordado)
        //     public bool ListaBordadoInactivos(Ob.Bordado bordado)

        public bool ActualizarBordado(Ob.BordadoDTO bordado)
        {
            try
            {
                IDataParameter[] parametros = new IDataParameter[9];
                parametros[0] = new SqlParameter("id", SqlDbType.VarChar);
                parametros[0].Value = bordado.Id;
                parametros[1] = new SqlParameter("IdBordado", SqlDbType.VarChar);
                parametros[1].Value = bordado.IdBordado;
                parametros[2] = new SqlParameter("NumeroPiezas", SqlDbType.Int);
                parametros[2].Value = bordado.NumeroPiezas;
                parametros[3] = new SqlParameter("NumeroPuntadas", SqlDbType.Int);
                parametros[3].Value = bordado.NumeroPuntadas;
                parametros[4] = new SqlParameter("ParteBordada", SqlDbType.VarChar);
                parametros[4].Value = bordado.ParteBordada;
                parametros[5] = new SqlParameter("FechaInicio ", SqlDbType.DateTime);
                parametros[5].Value = bordado.FechaInicio;
                parametros[6] = new SqlParameter("IdPrenda", SqlDbType.SmallInt);
                parametros[6].Value = bordado.IdPrenda;
                parametros[7] = new SqlParameter("IdUsuario", SqlDbType.SmallInt);
                parametros[7].Value = bordado.IdUsuario;
                parametros[8] = new SqlParameter("Estado", SqlDbType.SmallInt);
                parametros[8].Value = bordado.Estado;


                return conexionbd.EjecutarSPSinRetorno("bodegaActualizarBordado", parametros);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public bool ActualizarBordadoTerminado(Ob.BordadoDTO bordado)
        {
            try
            {
                IDataParameter[] parametros = new IDataParameter[4];
                parametros[0] = new SqlParameter("Id", SqlDbType.SmallInt);
                parametros[0].Value = bordado.Id;
                parametros[1] = new SqlParameter("NumeroPiezas", SqlDbType.Int);
                parametros[1].Value = bordado.NumeroPiezas;
                parametros[2] = new SqlParameter("FechaTerminado ", SqlDbType.DateTime);
                parametros[2].Value = bordado.FechaTerminado;
                parametros[3] = new SqlParameter("Estado", SqlDbType.Bit);
                parametros[3].Value = bordado.Estado;



                return conexionbd.EjecutarSPSinRetorno("proProcesoTerminadoBordado", parametros);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public DataTable ObtenerListaBordadosInactivos()
        {
            
            DataTable resultado;
            try
            {
                resultado = conexionbd.EjecutarSPResultSet("bordadosListaBordadosInactivos", null);

                

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

        public List<Ob.CorteDTO> ObtenerListaCortesParaBordados()
        {

            List<Ob.CorteDTO> cortes = new List<Ob.CorteDTO>();
            try
            {
               DataTable resultado = conexionbd.EjecutarSPResultSet("corteListaCortesEnEspera", null);

                foreach (DataRow renglon in resultado.Rows)
                {
                    cortes.Add(new Ob.CorteDTO()
                    {

                        Id = (short)renglon[0],
                        IdCorte = (string)renglon[1],
                       
                    });



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
            return cortes;
        }

        public Ob.BordadoDTO ObtenerBordado(short ID)
        {

            Ob.BordadoDTO bordado = new Ob.BordadoDTO();
            try
            {
                IDataParameter[] parametros = new IDataParameter[1];
                parametros[0] = new SqlParameter("Id", SqlDbType.SmallInt);
                parametros[0].Value = ID;
                DataTable resultado = conexionbd.EjecutarSPResultSet("bordadoObtenerBordado", parametros);

                foreach (DataRow renglon in resultado.Rows)
                {
                   

                        bordado.Id = (short)renglon[0];
                        bordado.IdBordado = (string)renglon[1];
                        bordado.NumeroPiezas = (int)renglon[2];
                        bordado.NumeroPuntadas = (int)renglon[3];
                        bordado.ParteBordada = (string)renglon[4];
                        bordado.FechaInicio = (DateTime)renglon[5];
                       // bordado.FechaTerminado = (DateTime)renglon[6];
                        bordado.IdPrenda = (short)renglon[7];
                        bordado.IdUsuario = (short)renglon[8];
                        bordado.Estado = (bool)renglon[9];
                    






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
            return bordado;
        }
        public bool ObtenerBordadoID(string ID)
        {

            bool resul = true;
            try
            {
                IDataParameter[] parametros = new IDataParameter[1];
                parametros[0] = new SqlParameter("idBordado", SqlDbType.VarChar);
                parametros[0].Value = ID;
                DataTable resultado = conexionbd.EjecutarSPResultSet("proObtenerBodadoID", parametros);

                foreach (DataRow renglon in resultado.Rows)
                {
                    if (Convert.ToInt32(renglon[0]) > 0)
                    {
                        resul = false;
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
            return resul;
        }

    


        public bool EliminarBordado(short idbordado)
        {
            try
            {
                IDataParameter[] parametros = new IDataParameter[1];
                parametros[0] = new SqlParameter("Id", SqlDbType.SmallInt);
                parametros[0].Value = idbordado;

                return conexionbd.EjecutarSPSinRetorno("proEliminarBordado", parametros);

            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public int NumeroBordado()
        {
            int ID = 0;
            try
            {

                DataTable resultado = conexionbd.EjecutarSPResultSet("IDBordado", null);

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

        public int ObtenerCantidadPiezasBordado(short ID)
        {

            int resul = 0;
            try
            {
                IDataParameter[] parametros = new IDataParameter[1];
                parametros[0] = new SqlParameter("IdPrenda", SqlDbType.SmallInt);
                parametros[0].Value = ID;
                DataTable resultado = conexionbd.EjecutarSPResultSet("bordadoObtenerCantidadPiezasDeNordado", parametros);

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
