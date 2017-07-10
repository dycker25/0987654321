using Project.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DLA.Catalogos
{
    public class AlmacenDLA
    {
        public bool AgregarBodega(Bodega Bodega)
        {
            bool resul = false;
            using (AlmacenEntities context = new AlmacenEntities())
            {
                context.Bodegas.Add(Bodega);
                context.SaveChanges();
                resul = true;

            }
            return resul;
        }

        public bool ActualizarBodega(Bodega Bodega)
        {
           bool resul = false;
           using (AlmacenEntities context = new AlmacenEntities())
           {
              Bodega BodegaAct = context.Bodegas.Where(e => e.Id == Bodega.Id).FirstOrDefault();
              BodegaAct.Nombre = Bodega.Nombre;
              BodegaAct.IdUsuario = Bodega.IdUsuario;
              BodegaAct.Estado = Bodega.Estado;
              context.Bodegas.Attach(BodegaAct);
              context.Entry(BodegaAct).State = System.Data.Entity.EntityState.Modified;
              context.SaveChanges();
              resul = true;

           }

           return resul;
        }

        public bool EliminarBodega(short id)
        {
            bool resul = false;
            using (AlmacenEntities context = new AlmacenEntities())
            {
                Bodega Bodega = context.Bodegas.Where(e => e.Id == id).FirstOrDefault();
                context.Bodegas.Remove(Bodega);
                context.SaveChanges();
                resul = true;

            }
            return resul;
        }
       
        public List<Bodega> ListaBodegas()
        {
            using (AlmacenEntities context = new AlmacenEntities())
            {

                return context.Bodegas.Include("Usuario").OrderBy(e => e.Nombre).ToList();


            }
        }
        public Bodega ObtenerBodega(short id)
        {
            using (AlmacenEntities context = new AlmacenEntities())
            {

                return context.Bodegas.Where(e => e.Id == id).FirstOrDefault();


            }
        }
    }
}
