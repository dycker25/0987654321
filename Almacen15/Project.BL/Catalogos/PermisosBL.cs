using Project.DLA;
using Project.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL
{
    public class PermisosBL
    {
        public PermisosBL()
        {

        }

        public short AgregarActualizarPermisos(Permiso permisos)
        {
            short resul = 0;
         
            try
            {
                PermisosDLA dla = new PermisosDLA();
                if (permisos.Id > 0)
                    resul = dla.ActualizarPermisos(permisos);
                else
                    resul = dla.AgregarPermisos(permisos);
                 
            }
            catch (Exception ex)
            {
                
                throw ex;
            }

            return resul;
        }

        public bool EliminarPermisos(short IdPermiso)
        {
            try
            {
                PermisosDLA dla = new PermisosDLA();
                return dla.EliminarPermisos(IdPermiso);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public Permiso ObtenerPermiso(short IdPermiso)
        {
            try
            {
                PermisosDLA dla = new PermisosDLA();
               return dla.ObtenerPermisos(IdPermiso);
            }
            catch (Exception)
            {
                
                throw;
            }

        }
    }
}
