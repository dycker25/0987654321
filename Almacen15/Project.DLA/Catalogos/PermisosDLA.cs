using Project.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DLA
{
   public class PermisosDLA
    {
       public PermisosDLA()
       {

       }

       public short AgregarPermisos(Permiso permiso)
       {
          short resul = 0;
           using (AlmacenEntities context = new AlmacenEntities())
           {
               context.Permisoes.Add(permiso);
               context.SaveChanges();
               resul = permiso.Id;

           }

           return resul;
       }
       public bool EliminarPermisos(short Id)
       {
           bool resul = false;
           using (AlmacenEntities context = new AlmacenEntities())
           {
               
               Permiso permiso = context.Permisoes.Where(q => q.Id == Id).FirstOrDefault();
               context.Permisoes.Remove(permiso);
               
               context.SaveChanges();
               resul = true;

           }
           return resul;
       }
       public short ActualizarPermisos(Permiso permiso)
       {
           short resul = 0;
           using (AlmacenEntities context = new AlmacenEntities())
           {
               Permiso permisosAct = context.Permisoes.Where(e => e.Id == permiso.Id).FirstOrDefault();

               permisosAct.Admin = permiso.Admin;
               permisosAct.Corte = permiso.Corte;
               permisosAct.Bordado = permiso.Bordado;
               permisosAct.Maquila = permiso.Maquila;
               permisosAct.Lavanderia = permiso.Lavanderia;
               permisosAct.Terminado = permiso.Terminado;
               permisosAct.Almacen = permiso.Almacen;
               permisosAct.Venta = permiso.Venta;
        /*falta algunas configuraciones*/
               
               context.Permisoes.Attach(permisosAct);
               context.Entry(permisosAct).State = System.Data.Entity.EntityState.Modified;
               context.SaveChanges();
               resul = permiso.Id;

           }
           return resul;
       }

       public Permiso ObtenerPermisos(short IdPermiso)
       {
           Permiso _permiso = null;
           using (AlmacenEntities context = new AlmacenEntities())
           {

               _permiso = context.Permisoes.Where(q => q.Id == IdPermiso).FirstOrDefault();
               

           }
           return _permiso;
       }
    }
}
