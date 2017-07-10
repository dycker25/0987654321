using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace almacen_telar.controller  
{
    public class Login
    {
        private ConexionBD conexiondb;

        public ConexionBD Conexiondb
        {
            get { return conexiondb; }
            set { conexiondb = value; }
        }

        public Login()
        {
            if (conexiondb == null)
            {
                conexiondb = new ConexionBD();
            }
        }

        public List<Ob.UsuarioDTO> ObtenerUsuarios()
        {
            List<Ob.UsuarioDTO> examenes = new List<Ob.UsuarioDTO>();
            try
            {
                DataTable resultado = conexiondb.EjecutarSPResultSet("uspObtenerExamenes", null);

                foreach (DataRow renglon in resultado.Rows)
                {


                    examenes.Add(new Ob.UsuarioDTO()
                    {
                        Id = (short)renglon[0],
                        User = (string)renglon[1],
                        Nombre = (string)renglon[2],
                        Password = (string)renglon[3],
                       
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
            return examenes;
        }

        public Ob.UsuarioDTO ObtenerUsuario(int id)
        {
          Ob.UsuarioDTO Usuario = new Ob.UsuarioDTO();
            try
            {
                IDataParameter[] parametros = new IDataParameter[1];
                parametros[0] = new SqlParameter("id", SqlDbType.SmallInt);
                parametros[0].Value = id;

                DataTable resultado = conexiondb.EjecutarSPResultSet("proObtenerUSuario", parametros);

                if (resultado != null )
                {
                   
                    foreach (DataRow renglon in resultado.Rows)
                    {
                        Usuario.Id = (short)renglon[0];
                        Usuario.Nombre = (string)renglon[1];
                        Usuario.User = (string)renglon[2];
                        Usuario.Password = (string)renglon[3];
                        Usuario.Tipo = (string)renglon[4];
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
            return Usuario;
        }
        public Ob.UsuarioDTO ObtenerLogin(string user, string pas)
        {
            Ob.UsuarioDTO Usuario = new Ob.UsuarioDTO();

            bool usu = false;
          
                IDataParameter[] parametros = new IDataParameter[2];
                parametros[0] = new SqlParameter("Usuario", SqlDbType.VarChar);
                parametros[0].Value = user;
                parametros[1] = new SqlParameter("Password", SqlDbType.VarChar);
                parametros[1].Value = pas;
                DataTable resultado = conexiondb.EjecutarSPResultSet("proObtenerLogin", parametros);

                if (resultado != null)
                {

                    foreach (DataRow renglon in resultado.Rows)
                    {
                        Usuario.Id = (short)renglon[0];
                        Usuario.Nombre = (string)renglon[1];
                        Usuario.User = (string)renglon[2];
                        Usuario.Password = (string)renglon[3];
                        Usuario.Tipo = (string)renglon[4];
                    }
                }

           
         
            return Usuario;
        }

       
        

    }
}
