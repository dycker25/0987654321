using Project.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DLA.Catalogos
{
   public class ProcesosLavanderiaDLA
    {
        public bool AgregarProceso(Proceso proceso)
        {
            bool resul = false;
            using (AlmacenEntities context = new AlmacenEntities())
            {
                context.Procesoes.Add(proceso);
                context.SaveChanges();
                resul = true;

            }
            return resul;
        }
        public bool EliminarProceso(short id)
        {
            bool resul = false;
            using (AlmacenEntities context = new AlmacenEntities())
            {
                Proceso proceso = context.Procesoes.Where(e => e.Id == id).FirstOrDefault();
                context.Procesoes.Remove(proceso);
                context.SaveChanges();
                resul = true;

            }
            return resul;
        }
        public bool ActualizarProceso(Proceso proceso)
        {
            bool resul = false;
            using (AlmacenEntities context = new AlmacenEntities())
            {
                Proceso ProcesoAct = context.Procesoes.Where(e => e.Id == proceso.Id).FirstOrDefault();

                ProcesoAct.Nombre = proceso.Nombre;
                ProcesoAct.Descripcion = proceso.Descripcion;
                ProcesoAct.Activo = proceso.Activo;
                context.Procesoes.Attach(ProcesoAct);
                context.Entry(ProcesoAct).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                resul = true;

            }

            return resul;
        }

        public List<Proceso> ListaProcesos()
        {
            using (AlmacenEntities context = new AlmacenEntities())
            {

                return context.Procesoes.OrderBy(e => e.Descripcion).ToList();


            }
        }
        public Proceso ObtenerProceso(short id)
        {
            using (AlmacenEntities context = new AlmacenEntities())
            {

                return context.Procesoes.Where(e => e.Id == id).FirstOrDefault();


            }
        }
    }
}
