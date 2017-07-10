using Project.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DLA.Catalogos
{
   public  class LugaresDLA
    {

        public bool AgregarLugarEntrega(LugarEntrega lugarEntrega)
        {
            bool resul = false;
            using (AlmacenEntities context = new AlmacenEntities())
            {
                context.LugarEntregas.Add(lugarEntrega);
                context.SaveChanges();
                resul = true;

            }
            return resul;
        }
        public bool EliminarLugarEntrega(short id)
        {
            bool resul = false;
            using (AlmacenEntities context = new AlmacenEntities())
            {

                LugarEntrega LugarEntrega = context.LugarEntregas.Where(e => e.Id == id).FirstOrDefault();
                context.LugarEntregas.Remove(LugarEntrega);
                context.SaveChanges();
                resul = true;

            }
            return resul;
        }
        public bool ActualizarLugarEntrega(LugarEntrega lugarEntrega)
        {
            bool resul = false;
            using (AlmacenEntities context = new AlmacenEntities())
            {
                LugarEntrega LugarEntregaAct = context.LugarEntregas.Where(e => e.Id == lugarEntrega.Id).FirstOrDefault();



                context.LugarEntregas.Attach(LugarEntregaAct);
                context.SaveChanges();
                resul = true;

            }

            return resul;
        }

        public List<LugarEntrega> ListaLugarEntregas()
        {
            using (AlmacenEntities context = new AlmacenEntities())
            {

                return context.LugarEntregas.OrderBy(e => e.Nombre).ToList();


            }
        }
        public LugarEntrega ObtenerLugarEntrega(short id)
        {
            using (AlmacenEntities context = new AlmacenEntities())
            {

                return context.LugarEntregas.Where(e => e.Id == id).FirstOrDefault();


            }
        }
    }
}
