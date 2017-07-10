using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace almacen_telar.controller
{
    public class DiseñoCon
    {
        private ConexionBD conexionbd;

        public ConexionBD Conexionbd
        {
            get { return conexionbd; }
            set { conexionbd = value; }
        }
        
        public DiseñoCon()
        {
            if (Conexionbd == null)
            {
                Conexionbd = new ConexionBD();
            }
        }

        public List<Ob.DiseñoDTO> ObtenerListaDiseñosActivos()
        {
            List<Ob.DiseñoDTO> Di = new List<Ob.DiseñoDTO>();
            try
            {
              
                //IDataParameter[] parametros = new IDataParameter[1];
                //parametros[0] = new SqlParameter("id", SqlDbType.SmallInt);
                //parametros[0].Value = idcorte;

                DataTable resultado = conexionbd.EjecutarSPResultSet("proObtenerListaDiseñoActivos", null);

                foreach (DataRow renglon in resultado.Rows)
                {
                    Di.Add(new Ob.DiseñoDTO() { 
                    
                    Id = (short)renglon[0],
                    IdDiseño = (string)renglon[1],
                    Corte = (string)renglon[2],
                    Modelo=(string)renglon[3],
                    FechaAprovacion = (DateTime)renglon[4],
                    IdUsuario  = (short)renglon[5],
                    Activo = (bool)renglon[6],
                    });


                    
                }


            }
            catch (Exception)
            {
                
                throw;
            }
            finally
            {
                GC.Collect();
            }
            return Di;
        }
        public DataTable ObtenerListaDiseños()
        {
            List<Ob.DiseñoDTO> Di = new List<Ob.DiseñoDTO>();
            try
            {

                return conexionbd.EjecutarSPResultSet("proObtenerListaDiseños", null);

            

            }
            catch (Exception)
            {

                throw;
            }
         
        }

        public Ob.DiseñoDTO ObtenerDiseño(short id)
        {
            Ob.DiseñoDTO Di = new Ob.DiseñoDTO();
            try
            {

                IDataParameter[] parametros = new IDataParameter[1];
                parametros[0] = new SqlParameter("id", SqlDbType.SmallInt);
                parametros[0].Value = id;

                DataTable resultado = conexionbd.EjecutarSPResultSet("proObtenerDiseño", parametros);

                foreach (DataRow renglon in resultado.Rows)
                {
                    
                        Di.Id = (short)renglon[0];
                        Di.IdDiseño = (string)renglon[1];
                        Di.Corte = (string)renglon[2];
                        Di.Modelo = (string)renglon[3];
                        Di.FechaAprovacion = (DateTime)renglon[4];
                        Di.IdUsuario = (short)renglon[5];
                        Di.Activo = (bool)renglon[6];
                   



                }


            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                GC.Collect();
            }
            return Di;
        }

        public bool AgregarDiseño(Ob.DiseñoDTO di)
        {
            try
            {

                IDataParameter[] parametros = new IDataParameter[6];
                parametros[0] = new SqlParameter("IdDiseño", SqlDbType.VarChar);
                parametros[0].Value = di.IdDiseño;
                parametros[1] = new SqlParameter("Corte", SqlDbType.VarChar);
                parametros[1].Value = di.Corte;
                parametros[2] = new SqlParameter("Modelo", SqlDbType.VarChar);
                parametros[2].Value = di.Modelo;
                parametros[3] = new SqlParameter("FechaAprovado", SqlDbType.DateTime);
                parametros[3].Value = di.FechaAprovacion;
                parametros[4] = new SqlParameter("IdUsuario", SqlDbType.SmallInt);
                parametros[4].Value = di.IdUsuario;
                parametros[5] = new SqlParameter("Estado", SqlDbType.Bit);
                parametros[5].Value = di.Activo;

                return conexionbd.EjecutarSPSinRetorno("proAgregarDiseño", parametros);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public bool ActualizarDiseño(Ob.DiseñoDTO di)
        {
            try
            {

                IDataParameter[] parametros = new IDataParameter[7];
                parametros[0] = new SqlParameter("id", SqlDbType.VarChar);
                parametros[0].Value = di.Id;
                parametros[1] = new SqlParameter("IdDiseño", SqlDbType.VarChar);
                parametros[1].Value = di.IdDiseño;
                parametros[2] = new SqlParameter("Corte", SqlDbType.VarChar);
                parametros[2].Value = di.Corte;
                parametros[3] = new SqlParameter("Modelo", SqlDbType.VarChar);
                parametros[3].Value = di.Modelo;
                parametros[4] = new SqlParameter("FechaAprovado", SqlDbType.DateTime);
                parametros[4].Value = di.FechaAprovacion;
                parametros[5] = new SqlParameter("IdUsuario", SqlDbType.SmallInt);
                parametros[5].Value = di.IdUsuario;
                parametros[6] = new SqlParameter("Estado", SqlDbType.Bit);
                parametros[6].Value = di.Activo;

                return conexionbd.EjecutarSPSinRetorno("proActualizarDiseño", parametros);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool EliminarDiseño(short di)
        {
            try
            {

                IDataParameter[] parametros = new IDataParameter[1];
                parametros[0] = new SqlParameter("id", SqlDbType.SmallInt);
                parametros[0].Value = di;


                return conexionbd.EjecutarSPSinRetorno("proEliminarDiseño", parametros);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
