using Project.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DLA
{
   public class DiseñoDLA
    {
       public DiseñoDLA()
       {

       }

       public bool AgregarDiseño(Diseño diseño)
       {
           bool resul = false;
           using (AlmacenEntities context = new AlmacenEntities())
           {
               context.Diseño.Add(diseño);
               context.SaveChanges();
               resul = true;

           }
           return resul;
       }
       public bool EliminarDiseño(short id)
       {
           bool resul = false;
           using (AlmacenEntities context = new AlmacenEntities())
           {
               Diseño diseño = context.Diseño.Where(e => e.Id == id).FirstOrDefault();
               context.Diseño.Remove(diseño);
               context.SaveChanges();
               resul = true;

           }
           return resul;
       }
       public bool ActualizarDiseño(Diseño diseño)
       {
          bool resul = false;
           using (AlmacenEntities context = new AlmacenEntities())
           {
               Diseño diseñoAct = context.Diseño.Where(e => e.Id == diseño.Id).FirstOrDefault();


               
               context.Diseño.Attach(diseñoAct);
               context.SaveChanges();
               resul = true;

           }

           return resul;
       }

       public List<Diseño> ListaDiseños()
       {
           using (AlmacenEntities context = new AlmacenEntities())
           {

               return context.Diseño.Include("Usuario").OrderBy(e => e.Codigo).ToList();


           }
       }
        public List<Diseño> ListaDiseñosActivos()
        {
            using (AlmacenEntities context = new AlmacenEntities())
            {

                return context.Diseño.OrderBy(e => e.Codigo).Where(q => q.Activo == true).ToList();


            }
        }
        public Diseño ObtenerDiseño(short id)
       {
           using (AlmacenEntities context = new AlmacenEntities())
           {

               return context.Diseño.Where(e => e.Id == id).FirstOrDefault();


           }
       }
    }
}
