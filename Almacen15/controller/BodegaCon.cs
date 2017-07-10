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
    public class BodegaCon
    {
        private ConexionBD conexiobd;

        public ConexionBD Conexiobd
        {
            get { return conexiobd; }
            set { conexiobd = value; }
        }

        public BodegaCon()
        {
            if (Conexiobd == null)
            {
                Conexiobd = new ConexionBD();
            }
        }

        public DataTable ListaDeprendas()
        {
            try
            {
                return Conexiobd.EjecutarSPResultSet("ListaPrendas", null);

            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public DataTable ListaResivido()
        {
            try
            {
                return Conexiobd.EjecutarSPResultSet("PatalonesEnBodega", null);

            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public List<ResultadDTO> ListaProcesoTerminado()
        {
            try
            {
                List<ResultadDTO> lista = new List<ResultadDTO>();

                DataTable resltado= Conexiobd.EjecutarSPResultSet("ListaProcesoTerminadosListos", null);
                if (resltado != null)
                {
                    foreach (DataRow item in resltado.Rows)
                    {
                        lista.Add(new ResultadDTO() {
                            Id = (short)item[0],
                            Descripcion = (string)item[1]
                        });

                    }

                }
                return lista;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public List<ResultadDTO> ListaBodegasActivas()
        {
            try
            {
                List<ResultadDTO> lista = new List<ResultadDTO>();

                DataTable resltado = Conexiobd.EjecutarSPResultSet("ListaBodegasActivas", null);
                if (resltado != null)
                {
                    foreach (DataRow item in resltado.Rows)
                    {
                        lista.Add(new ResultadDTO()
                        {
                            Id = (short)item[0],
                            Descripcion = (string)item[1]
                        });

                    }

                }
                return lista;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public bool AgregarRecibidos(short IdTerminado, short IdBodega, short IdUsuario)
        {
            try
            {
                IDataParameter[] parametros = new IDataParameter[4];

                parametros[0] = new SqlParameter("IdTerminado", SqlDbType.SmallInt);
                parametros[0].Value = IdTerminado;
                parametros[1] = new SqlParameter("IdBodega", SqlDbType.SmallInt);
                parametros[1].Value = IdBodega;
                parametros[2] = new SqlParameter("Fecha", SqlDbType.DateTime);
                parametros[2].Value = DateTime.Now;
                parametros[3] = new SqlParameter("IdUsuario", SqlDbType.SmallInt);
                parametros[3].Value = IdUsuario;
                

                return Conexiobd.EjecutarSPSinRetorno("AgregarRecibidos", parametros);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool AgregarPantalon(TerminadoDTO ter, short IdBodega)
        {
            try
            {
                bool resul = false;
                short idPantalon = 0;
                IDataParameter[] parametros = new IDataParameter[3];

                parametros[0] = new SqlParameter("IdTalla", SqlDbType.VarChar);
                parametros[0].Value = ter.Talla;
                parametros[1] = new SqlParameter("IdDiseño", SqlDbType.Int);
                parametros[1].Value = ter.IdDiseño;
                parametros[2] = new SqlParameter("Cantidad", SqlDbType.SmallInt);
                parametros[2].Value = ter.NumeroPiezas;



                if (Conexiobd.EjecutarSPSinRetorno("AgregarPantalon", parametros))
                {
                    DataTable valor = Conexiobd.EjecutarSPResultSet("ObtenerIdPantalon", null);
                    foreach (DataRow item in valor.Rows)
                    {
                        idPantalon = (short)item[0];
                    }

                    if (idPantalon > 0)
                    {
                        IDataParameter[] parametros1 = new IDataParameter[2];

                        parametros1[0] = new SqlParameter("IdBodega", SqlDbType.SmallInt);
                        parametros1[0].Value = IdBodega;
                        parametros1[1] = new SqlParameter("IdPantalon", SqlDbType.SmallInt);
                        parametros1[1].Value = idPantalon;




                        if (Conexiobd.EjecutarSPSinRetorno("AgregarPantalonBodega", parametros1))
                        {
                            resul = true;
                        }
                    }
                    
                }
                return resul;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool AgregarPrendaBodega( short IDBodega, short IDPrenda)
        {
            try
            {
                IDataParameter[] parametros = new IDataParameter[2];

                parametros[0] = new SqlParameter("IdPrenda", SqlDbType.SmallInt);
                parametros[0].Value = IDPrenda;
                parametros[1] = new SqlParameter("IdBodega", SqlDbType.SmallInt);
                parametros[1].Value = IDBodega;
                


                return Conexiobd.EjecutarSPSinRetorno("AgregarPrendaBodega", parametros);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public short IdPrenda()
        {
            try
            {
                short Id = 0;

                DataTable resltado = Conexiobd.EjecutarSPResultSet("IDPrenda", null);
                if (resltado != null)
                {
                    foreach (DataRow item in resltado.Rows)
                    {

                        Id = (short)item[0];


                    }
                }
                return Id;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public int IdTalla(double talla)
        {
            try
            {
                int Id = 0;
                IDataParameter[] parametros = new IDataParameter[1];

                parametros[0] = new SqlParameter("talla", SqlDbType.Float);
                parametros[0].Value = talla;

                DataTable resltado = Conexiobd.EjecutarSPResultSet("IDTallas", parametros);
                if (resltado != null)
                {
                    foreach (DataRow item in resltado.Rows)
                    {

                        Id = (int)item[0];


                    }
                }
                return Id;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<TerminadoDTO> DetallesDeTerminado(short IdTerminado)
        {
            try
            {
                List<TerminadoDTO> listaterminado = new List<TerminadoDTO>();
                TerminadoDTO objeto = new TerminadoDTO();

                IDataParameter[] parametros = new IDataParameter[1];
                parametros[0] = new SqlParameter("Id", SqlDbType.SmallInt);
                parametros[0].Value = IdTerminado;


                DataTable resltado = Conexiobd.EjecutarSPResultSet("DatosPrendaTerminada", parametros);

                if (resltado != null)
                {
                    foreach (DataRow item in resltado.Rows)
                    {

                        objeto.Id = (short)item[0];
                        objeto.IdDiseño = (short)item[8];
                        objeto.IdPrenda = (short)item[5];
                    }
                }

                if (objeto != null)
                {
                    IDataParameter[] parametros1 = new IDataParameter[1];

                    parametros1[0] = new SqlParameter("IdPrenda", SqlDbType.SmallInt);
                    parametros1[0].Value = objeto.IdPrenda;
                   

                    DataTable resltado1 = Conexiobd.EjecutarSPResultSet("ObtenerDetallesPrenda", parametros1);

                    foreach (DataRow item in resltado1.Rows)
                    {
                        listaterminado.Add(new TerminadoDTO() {
                            
                            Talla =Convert.ToInt16( item[2]),
                            IdDiseño =objeto.IdDiseño,
                            NumeroPiezas= (int)item[3]
                        });
                    }
                }

                return listaterminado;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public short BuscarPrendaExistente(TerminadoDTO dto ,short IdBodega)
        {
            short resul = 0;
            IDataParameter[] parametros = new IDataParameter[3];

            parametros[0] = new SqlParameter("IdTalla", SqlDbType.SmallInt);
            parametros[0].Value = dto.Talla;
            parametros[1] = new SqlParameter("IdDiseño", SqlDbType.SmallInt);
            parametros[1].Value = dto.IdDiseño;
            parametros[2] = new SqlParameter("IdBodega", SqlDbType.SmallInt);
            parametros[2].Value = IdBodega;
            

            DataTable resltado = Conexiobd.EjecutarSPResultSet("BuscarPrendaExistente", parametros);
            if (resltado != null)
            {
                foreach (DataRow item in resltado.Rows)
                {
                    
                    resul = (short)item[0];
                   

                }
            }
            return resul;
        }

        public int CantidadDePiezasDelPantalon(short IdPantalon, short IdBodega)
        {
            int resul = 0;
            IDataParameter[] parametros = new IDataParameter[2];

            parametros[0] = new SqlParameter("IdPantalon", SqlDbType.SmallInt);
            parametros[0].Value = IdPantalon;
            parametros[1] = new SqlParameter("IdBodega", SqlDbType.SmallInt);
            parametros[1].Value = IdBodega;



            DataTable resltado = Conexiobd.EjecutarSPResultSet("ObtenerCantidadPiezasPAntalon", parametros);
            if (resltado != null)
            {
                foreach (DataRow item in resltado.Rows)
                {

                    resul = (int)item[0];


                }
            }
            return resul;
        }

        public bool ActualizarPantalon(TerminadoDTO terminado, short IdBodega,short IdPantalon)
        {
            bool resul = false;
            IDataParameter[] parametros = new IDataParameter[3];

            parametros[0] = new SqlParameter("IdPantalon", SqlDbType.SmallInt);
            parametros[0].Value = IdPantalon;
            parametros[1] = new SqlParameter("IdBodega", SqlDbType.SmallInt);
            parametros[1].Value = IdBodega;
            parametros[2] = new SqlParameter("Cantidad", SqlDbType.Int);
            parametros[2].Value = terminado.NumeroPiezas + CantidadDePiezasDelPantalon(IdPantalon, IdBodega);


            if (Conexiobd.EjecutarSPSinRetorno("ActualizarCantidadPantalon ", parametros))
            {
                // ya lo hace
                //   IDataParameter[] parametros1 = new IDataParameter[2];

                //parametros1[0] = new SqlParameter("IdTerminado", SqlDbType.SmallInt);
                //parametros1[0].Value = Idterminad;
                //parametros1[0] = new SqlParameter("IdBodega", SqlDbType.SmallInt);
                //parametros1[0].Value = IDBOdega;
                //parametros1[0] = new SqlParameter("Fecha", SqlDbType.DateTime);
                //parametros1[0].Value = DateTime.Now;
                //parametros1[0] = new SqlParameter("IdUsuario", SqlDbType.SmallInt);
                //parametros1[0].Value = idUsuario;
                //Conexiobd.EjecutarSPSinRetorno("", parametros);
                //if (Conexiobd.EjecutarSPSinRetorno("EnlasarTerminadoBodega", parametros1))
                //{
                resul = true;
                //}
            }
            return resul;
        }
    }
}
