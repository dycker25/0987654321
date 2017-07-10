using Project.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DLA.DetallesProcesos
{
   public class DetallePrendaDLA
    {

        public bool AgregarDetallePrenda(Detalle Detalle)
        {
            bool resul = false;
            using (AlmacenEntities context = new AlmacenEntities())
            {
                context.Detalles.Add(Detalle);
                context.SaveChanges();
                resul = true;

            }
            return resul;
        }
        public bool EliminarDetallePrenda(short id)
        {
            bool resul = false;
            using (AlmacenEntities context = new AlmacenEntities())
            {
                Detalle Detalle = context.Detalles.Where(e => e.Id == id).FirstOrDefault();
                context.Detalles.Remove(Detalle);
                context.SaveChanges();
                resul = true;

            }
            return resul;
        }
        public bool ActualizarDetallePrenda(Detalle Detalle)
        {
            bool resul = false;
            using (AlmacenEntities context = new AlmacenEntities())
            {
                Detalle DetalleAct = context.Detalles.Where(e => e.Id == Detalle.Id).FirstOrDefault();



                context.Detalles.Attach(DetalleAct);
                context.SaveChanges();
                resul = true;

            }

            return resul;
        }

       
        public Detalle ObtenerDetalle(short id)
        {
            using (AlmacenEntities context = new AlmacenEntities())
            {

                return context.Detalles.Where(e => e.Id == id).FirstOrDefault();


            }
        }
    }
}
