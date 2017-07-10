using Project.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Catalogos
{
  public  class PrendaDLA
    {

        public short AgregarePrenda(Prenda prenda)
        {
            short resul = 0;
            using (AlmacenEntities context = new AlmacenEntities())
            {
                context.Prendas.Add(prenda);
                context.SaveChanges();
                resul = prenda.Id;

            }
            return resul;
        }
        public bool EliminarPrenda(short id)
        {
            bool resul = false;
            using (AlmacenEntities context = new AlmacenEntities())
            {
                Prenda prenda = context.Prendas.Where(e => e.Id == id).FirstOrDefault();
                context.Prendas.Remove(prenda);
                context.SaveChanges();
                resul = true;

            }
            return resul;
        }
        public short ActualizarPrenda(Prenda prenda)
        {
            short resul = 0;
            using (AlmacenEntities context = new AlmacenEntities())
            {
                Prenda prendaAct = context.Prendas.Where(e => e.Id == prenda.Id).FirstOrDefault();



                context.Prendas.Attach(prendaAct);
                context.SaveChanges();
                resul = prenda.Id;

            }

            return resul;
        }


        public Prenda ObtenerPrenda(short id)
        {
            using (AlmacenEntities context = new AlmacenEntities())
            {

                return context.Prendas.Where(e => e.Id == id).FirstOrDefault();


            }
        }
        public List<Prenda> ListaPrenda()
        {

            using (AlmacenEntities context = new AlmacenEntities())
            {

                return context.Prendas.ToList();


            }
        }
    }
}
