using Project.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DLA.Procesos
{
   public  class proBordadoDLA
    {
        public bool AgregarBordado(Bordado bordado)
        {
            bool resul = false;
            using (AlmacenEntities context = new AlmacenEntities())
            {
                context.Bordadoes.Add(bordado);
                context.SaveChanges();
                resul = true;

            }
            return resul;
        }
        public bool EliminarBordado(short id)
        {
            bool resul = false;
            using (AlmacenEntities context = new AlmacenEntities())
            {
                Bordado bordado = context.Bordadoes.Where(e => e.Id == id).FirstOrDefault();
                context.Bordadoes.Remove(bordado);
                context.SaveChanges();
                resul = true;

            }
            return resul;
        }
        public bool ActualizarBordado(Bordado bordado)
        {
            bool resul = false;
            using (AlmacenEntities context = new AlmacenEntities())
            {
                Bordado BordadoAct = context.Bordadoes.Where(e => e.Id == bordado.Id).FirstOrDefault();



                context.Bordadoes.Attach(BordadoAct);
                context.SaveChanges();
                resul = true;

            }

            return resul;
        }

        public List<Bordado> ListaBordados()
        {
            using (AlmacenEntities context = new AlmacenEntities())
            {

                return context.Bordadoes.Include("IdBordado").OrderBy(e => e.IdBordado).ToList();


            }
        }
        public Bordado ObtenerBordado(short id)
        {
            using (AlmacenEntities context = new AlmacenEntities())
            {

                return context.Bordadoes.Where(e => e.Id == id).FirstOrDefault();


            }
        }
    }
}
