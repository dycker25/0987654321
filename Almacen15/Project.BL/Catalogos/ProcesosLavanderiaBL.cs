using Project.DLA;
using Project.DLA.Catalogos;
using Project.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Catalogos
{
   public  class ProcesosLavanderiaBL
    {
        public bool AgregarActualizarProceso(Proceso Proceso)
        {


            try
            {
                ProcesosLavanderiaDLA dla = new ProcesosLavanderiaDLA();
                if (Proceso.Id > 0)
                    return dla.ActualizarProceso(Proceso);
                else
                    return dla.AgregarProceso(Proceso);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool EliminarProcesoLavan(short IdProceso)
        {
           try
           {
              ProcesosLavanderiaDLA dla = new ProcesosLavanderiaDLA();
              return dla.EliminarProceso(IdProceso);
           }
           catch(Exception)
           {
              throw;
           }
        }


        public Proceso ObtenerProceso(short id)
        {
            try
            {
                ProcesosLavanderiaDLA dla = new ProcesosLavanderiaDLA();
                return dla.ObtenerProceso(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Proceso> ListaProcesos()
        {
            try
            {
                ProcesosLavanderiaDLA dla = new ProcesosLavanderiaDLA();
                return dla.ListaProcesos();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
