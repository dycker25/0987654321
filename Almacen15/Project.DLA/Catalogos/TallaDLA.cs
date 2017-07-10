using Project.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DLA.Catalogos
{
  public  class TallaDLA
    {
        public bool AgregarTalla(Talla talla)
        {
            bool resul = false;
            using (AlmacenEntities context = new AlmacenEntities())
            {
                context.Tallas.Add(talla);
                context.SaveChanges();
                resul = true;

            }
            return resul;
        }
        public bool EliminarTalla(short id)
        {
            bool resul = false;
            using (AlmacenEntities context = new AlmacenEntities())
            {
                Talla talla = context.Tallas.Where(e => e.Id == id).FirstOrDefault();
                context.Tallas.Remove(talla);
                context.SaveChanges();
                resul = true;

            }
            return resul;
        }
        public bool ActualizarTalla(Talla talla)
        {
            bool resul = false;
            using (AlmacenEntities context = new AlmacenEntities())
            {
                Talla tallaAct = context.Tallas.Where(e => e.Id == talla.Id).FirstOrDefault();
                tallaAct.Talla1 = talla.Talla1;
                tallaAct.activo = talla.activo;

                context.Tallas.Attach(tallaAct);
                context.Entry(tallaAct).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                resul = true;

            }

            return resul;
        }

        public List<Talla> ListaTallas()
        {
            using (AlmacenEntities context = new AlmacenEntities())
            {

                return context.Tallas.OrderBy(e => e.Talla1).ToList();


            }
        }

        public List<Talla> ListaTallasActivas()
        {
            using (AlmacenEntities context = new AlmacenEntities())
            {

                return context.Tallas.OrderBy(e => e.Talla1).Where(q => q.activo == true).ToList();


            }
        }
        public Talla ObtenerTalla(short id)
        {
            using (AlmacenEntities context = new AlmacenEntities())
            {

                return context.Tallas.Where(e => e.Id == id).FirstOrDefault();


            }
        }
    }
}
