using Project.DLA;
using Project.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL
{
    public class UsuarioBL
    {
        public UsuarioBL()
        {

        }

        public List<Usuario> ListaUsuarios()
        {
            try
            {
                UsuarioDLA dla = new UsuarioDLA();
                return dla.ListaUsuarios();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Usuario ObtenerUduario(short IdUsuario)
        {
            try
            {
                UsuarioDLA dla = new UsuarioDLA();

                return dla.ObtenerUsuario(IdUsuario);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool AgregarActualizarUsuario(Usuario usuario)
        {
            bool resul = false;

            try
            {
                UsuarioDLA dla = new UsuarioDLA();

                if (usuario.Id > 0)
                {
                    resul = dla.ActualizarUsuario(usuario);

                }
                else
                {
                    resul = dla.AgregarUsuario(usuario);

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return resul;
        }

        public bool EliminarUsuario(short IdUsuario) 
        {
            try
            {
                UsuarioDLA dla = new UsuarioDLA();
                return dla.EliminarUsuario(IdUsuario);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public Usuario Login(string usuario, string contraseña)
        {
            Usuario usuarioA = new Usuario(); 
            try
            {
                UsuarioDLA dla = new UsuarioDLA();
                usuarioA = dla.ObtenerUsuarioToUsuario(usuario);
                if (usuarioA != null && usuarioA.contrasena == contraseña)
                {
                    return usuarioA;

                }
                else
                    return usuarioA= null;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
