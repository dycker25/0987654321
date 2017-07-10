using Project.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DLA.Procesos
{
   public class proCorteDLA
    {
        public bool AgregarCorte(Corte corte)
        {
            bool resul = false;
            using (AlmacenEntities context = new AlmacenEntities())
            {
                context.Cortes.Add(corte);
                context.SaveChanges();
                resul = true;

            }
            return resul;
        }
        public bool EliminarCorte(short id)
        {
            bool resul = false;
            using (AlmacenEntities context = new AlmacenEntities())
            {
                Corte corte = context.Cortes.Where(e => e.Id == id).FirstOrDefault();
                context.Cortes.Remove(corte);
                context.SaveChanges();
                resul = true;

            }
            return resul;
        }
        public bool ActualizarCorte(Corte corte)
        {
            bool resul = false;
            using (AlmacenEntities context = new AlmacenEntities())
            {
                Corte CorteAct = context.Cortes.Where(e => e.Id == corte.Id).FirstOrDefault();



                context.Cortes.Attach(CorteAct);
                context.SaveChanges();
                resul = true;

            }

            return resul;
        }

        public List<Corte> ListaCortes()
        {
            using (AlmacenEntities context = new AlmacenEntities())
            {

                return context.Cortes.Include("Prenda").OrderBy(e => e.IdCorte).ToList();


            }
        }
        public Corte ObtenerCorte(short id)
        {
            using (AlmacenEntities context = new AlmacenEntities())
            {

                return context.Cortes.Where(e => e.Id == id).FirstOrDefault();


            }
        }
    }
}
