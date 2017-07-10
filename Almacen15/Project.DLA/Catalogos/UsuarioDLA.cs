using Project.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DLA
{
    public class UsuarioDLA
    {
        public UsuarioDLA()
        {

        }

        public bool AgregarUsuario(Usuario usuario)
        {
            bool resul = false;
            using(AlmacenEntities context = new AlmacenEntities())
            {
                context.Usuarios.Add(usuario);
                context.SaveChanges();
                resul = true;

            }

            return resul;
        }
        public bool EliminarUsuario(short id)
        {
            bool resul = false;
            using (AlmacenEntities context = new AlmacenEntities())
            {
                Usuario usuario = context.Usuarios.Where(e => e.Id == id).FirstOrDefault();
                context.Usuarios.Remove(usuario);
                context.SaveChanges();
                resul = true;

            }
            return resul;
        }
        public bool ActualizarUsuario(Usuario usuario)
        {
            bool resul = false;
            using (AlmacenEntities context = new AlmacenEntities())
            {
                Usuario usuarioAct = context.Usuarios.Where(e => e.Id == usuario.Id).FirstOrDefault();


                usuarioAct.Nombre = usuario.Nombre;
                usuarioAct.Usuario1 = usuario.Usuario1;
                usuarioAct.contrasena = usuario.contrasena;
                usuarioAct.Activo = usuario.Activo;
                
                context.Usuarios.Attach(usuarioAct);
                context.Entry(usuarioAct).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                resul = true;

            }
            return resul;
        }

        public List<Usuario> ListaUsuarios()
        {
            using (AlmacenEntities context = new AlmacenEntities())
            {
                context.Configuration.LazyLoadingEnabled = false;
                return context.Usuarios.Include("Permiso").OrderBy(e => e.Nombre).ToList();
               

            }
        }
        public Usuario ObtenerUsuario(short id)
        {
            using (AlmacenEntities context = new AlmacenEntities())
            {

                return context.Usuarios.Where(e => e.Id == id).FirstOrDefault();


            }
        }


        public Usuario ObtenerUsuarioToUsuario(string usuario)
        {
            using (AlmacenEntities context = new AlmacenEntities())
            {
                context.Configuration.LazyLoadingEnabled = false;


                return context.Usuarios.Include("Permiso").Where(e => e.Usuario1 == usuario).FirstOrDefault();
                
                 
            }
        }
    }
}
