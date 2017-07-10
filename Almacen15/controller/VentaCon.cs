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
    public class VentaCon
    {
        private ConexionBD conexionbd;

        public ConexionBD Conexionbd
        {
            get { return conexionbd; }
            set { conexionbd = value; }
        }


        public VentaCon()
        {
            if (Conexionbd == null)
            {
                Conexionbd = new ConexionBD();
            }
        }
        public List<TallaDTO> ObtenerListaDeTallasPorId(string IdDiseño, short IdBodega)
        {
            List<TallaDTO> lista = new List<TallaDTO>();

            IDataParameter[] parametros = new IDataParameter[2];

            parametros[0] = new SqlParameter("IdBodega", SqlDbType.SmallInt);
            parametros[0].Value = IdBodega;
            parametros[1] = new SqlParameter("IdDiseño", SqlDbType.VarChar);
            parametros[1].Value = IdDiseño;

            DataTable resultado = Conexionbd.EjecutarSPResultSet("ObtenerTallasPorIdDiseño", parametros);
            
                   
                    if (resultado != null)
                    {
                        foreach (DataRow item in resultado.Rows)
                        {

                            lista.Add(new TallaDTO() {
                                Id=(int)item[0],
                                Talla=(double)item[1]
                            });


                        }
              
            }

            return lista;
        }

        public bool ConsultaSiExiste(string IdDiseño, short IdBodega)
        {
            bool lista = false;

            IDataParameter[] parametros = new IDataParameter[2];

            parametros[0] = new SqlParameter("IdBodega", SqlDbType.SmallInt);
            parametros[0].Value = IdBodega;
            parametros[1] = new SqlParameter("IdDiseño", SqlDbType.VarChar);
            parametros[1].Value = IdDiseño;

            DataTable resultado = Conexionbd.EjecutarSPResultSet("ConsultaSiExisteDiseñoEnBodega", parametros);


            if (resultado != null)
            {
                foreach (DataRow item in resultado.Rows)
                {

                    
                    if (int.Parse(item[0].ToString()) > 0)
                    {
                        lista = true;
                    }
                     


                }

            }

            return lista;
        }

        public DataTable ListaPantalones( short IdBodega)
        {
           

            IDataParameter[] parametros = new IDataParameter[1];

            parametros[0] = new SqlParameter("IdBodega", SqlDbType.SmallInt);
            parametros[0].Value = IdBodega;
     

            return Conexionbd.EjecutarSPResultSet("ListaPantalonesVenta", parametros);


        }

        public DataTable ObtenerListaVentas()
        {
            return Conexionbd.EjecutarSPResultSet("ObtenerVentas", null);

        }
        public VentaDTO ObtenerVenta(short IdVenta)
        {
            VentaDTO venta = new VentaDTO();
            IDataParameter[] parametros = new IDataParameter[1];
            parametros[0] = new SqlParameter("IdVenta",SqlDbType.SmallInt );
            parametros[0].Value = IdVenta;
            DataTable resul = Conexionbd.EjecutarSPResultSet("ventaObtenerVenta", parametros);

            if (resul != null)
            {
                foreach (DataRow item in resul.Rows)
                {
                    venta.Id = (short)item[0];
                    venta.FechaEntrega = Convert.ToDateTime( item[1]);
                    venta.PienzasEntregadas = (int)item[2];
                    venta.PiezasDevueltas = (int)item[3];
                    
                }
 
            }


            return venta;
        }

        public List<DetalleVentaDTO> ObtenerVentaDetalles(short IdVenta)
        {
            List<DetalleVentaDTO> venta = new List<DetalleVentaDTO>();
            IDataParameter[] parametros = new IDataParameter[1];
            parametros[0] = new SqlParameter("IdVenta", SqlDbType.SmallInt);
            parametros[0].Value = IdVenta;
            DataTable resul = Conexionbd.EjecutarSPResultSet("ventaObtenerVentaDetalles", parametros);

            if (resul != null)
            {
                foreach (DataRow item in resul.Rows)
                {
                    venta.Add(new DetalleVentaDTO()
                    {
                        Id = (short)item[0],
                       Codigo = (string)item[1],
                       Talla = (double)item[2],
                       Cantidad = (int)item[3],
                    });
                  
                }

            }


            return venta;
        }
        public short AgregarVenta(VentaDTO venta)
        {
            short lista = 0;

            IDataParameter[] parametros = new IDataParameter[3];

            parametros[0] = new SqlParameter("FechaEntrega", SqlDbType.DateTime);
            parametros[0].Value = DateTime.Now;
            parametros[1] = new SqlParameter("PiezasEntregas", SqlDbType.Int);
            parametros[1].Value = venta.PienzasEntregadas;
            parametros[2] = new SqlParameter("PiezasVendidas", SqlDbType.Int);
            parametros[2].Value = venta.PiezasVendidas;



            if (Conexionbd.EjecutarSPSinRetorno("CrearVenta", parametros))
                {

                DataTable resultado = Conexionbd.EjecutarSPResultSet("ObtenerIdVenta", null);
                if (resultado != null)
                {
                    foreach (DataRow item in resultado.Rows)
                    {
                        lista = (short)item[0];
                    }

                }
            }

            return lista;
        }

        public bool AgregarDetallesVenta(DetalleVentaDTO detalles)
        {
            
                IDataParameter[] parametros = new IDataParameter[4];

            parametros[0] = new SqlParameter("Codigo", SqlDbType.VarChar);
            parametros[0].Value = detalles.Codigo;
            parametros[1] = new SqlParameter("Talla", SqlDbType.Float);
            parametros[1].Value = detalles.Talla;
            parametros[2] = new SqlParameter("Cantidad", SqlDbType.Int);
            parametros[2].Value = detalles.Cantidad;
            parametros[3] = new SqlParameter("IdVenta", SqlDbType.SmallInt);
            parametros[3].Value = detalles.IdVenta;



            return Conexionbd.EjecutarSPSinRetorno("AgregarDetallesVentas", parametros);
        }
        public bool ActualizarCantidades(DetalleVentaDTO detalles,short IdBodega)
        {

            IDataParameter[] parametros = new IDataParameter[4];

            parametros[0] = new SqlParameter("IdBodega", SqlDbType.SmallInt);
            parametros[0].Value = IdBodega;
            parametros[1] = new SqlParameter("IdDiseño", SqlDbType.VarChar);
            parametros[1].Value = detalles.Codigo;
            parametros[2] = new SqlParameter("IdTalla", SqlDbType.Int);
            parametros[2].Value = ObtenerIDTalla(detalles.Talla);
            parametros[3] = new SqlParameter("Cantidad", SqlDbType.Int);
            parametros[3].Value =  CantiadDePRenda(IdBodega, detalles.Codigo, ObtenerIDTalla(detalles.Talla))- detalles.Cantidad;



            return Conexionbd.EjecutarSPSinRetorno("ActualizarCantidades", parametros);
        }
        public bool ActualizarCantidadesDevueltas(DetalleVentaDTO detalles, short IdBodega)
        {

            IDataParameter[] parametros = new IDataParameter[4];

            parametros[0] = new SqlParameter("IdBodega", SqlDbType.SmallInt);
            parametros[0].Value = IdBodega;
            parametros[1] = new SqlParameter("IdDiseño", SqlDbType.VarChar);
            parametros[1].Value = detalles.Codigo;
            parametros[2] = new SqlParameter("IdTalla", SqlDbType.Int);
            parametros[2].Value = ObtenerIDTalla(detalles.Talla);
            parametros[3] = new SqlParameter("Cantidad", SqlDbType.Int);
            parametros[3].Value = CantiadDePRenda(IdBodega, detalles.Codigo, ObtenerIDTalla(detalles.Talla)) + detalles.Cantidad;



            return Conexionbd.EjecutarSPSinRetorno("ActualizarCantidades", parametros);
        }

        public int CantiadDePRenda(short IdBodega,string IdDiseño,int IdTalla)
        {
            int lista = 0;

            IDataParameter[] parametros = new IDataParameter[3];

            parametros[0] = new SqlParameter("IdBodega", SqlDbType.SmallInt);
            parametros[0].Value = IdBodega;
            parametros[1] = new SqlParameter("IdDiseño", SqlDbType.VarChar);
            parametros[1].Value = IdDiseño;
            parametros[2] = new SqlParameter("IdTalla", SqlDbType.Int);
            parametros[2].Value = IdTalla;

                DataTable resultado = Conexionbd.EjecutarSPResultSet("cantidaDePantalon", parametros);
                if (resultado != null)
                {
                    foreach (DataRow item in resultado.Rows)
                    {
                        lista = (int)item[0];
                    }

                }

            return lista;


        }


        private int ObtenerIDTalla(double Talla)
        {
             int lista = 0;

            IDataParameter[] parametros = new IDataParameter[1];

            parametros[0] = new SqlParameter("Talla", SqlDbType.Float);
            parametros[0].Value = Talla;
           

                DataTable resultado = Conexionbd.EjecutarSPResultSet("ObtenerIDTalla", parametros);
                if (resultado != null)
                {
                    foreach (DataRow item in resultado.Rows)
                    {
                        lista = (int)item[0];
                    }

                }

            return lista;
        }

        public bool ActualizarVenta(VentaDTO venta)
        {
            IDataParameter[] parametros = new IDataParameter[4];

            parametros[0] = new SqlParameter("IdVenta", SqlDbType.SmallInt);
            parametros[0].Value = venta.Id;
            parametros[1] = new SqlParameter("PiezasEntregas", SqlDbType.Int);
            parametros[1].Value = venta.PienzasEntregadas;
            parametros[2] = new SqlParameter("PiezasVendidas", SqlDbType.Int);
            parametros[2].Value = venta.PiezasVendidas;
            parametros[3] = new SqlParameter("PiezasDevueltas", SqlDbType.Int);
            parametros[3].Value = venta.PiezasDevueltas;



            return Conexionbd.EjecutarSPSinRetorno("actualizarventa", parametros);
 
        }
    }
}
