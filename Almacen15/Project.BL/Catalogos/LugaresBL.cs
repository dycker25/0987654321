using Project.DLA.Catalogos;
using Project.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Catalogos
{
   public class LugaresBL
    {
        public bool AgregarActualizarLugar(LugarEntrega lugarEntrega)
        {

            try
            {
                LugaresDLA dla = new LugaresDLA();
                if (lugarEntrega.Id > 0)
                    return dla.ActualizarLugarEntrega(lugarEntrega);
                else
                    return dla.AgregarLugarEntrega(lugarEntrega);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public LugarEntrega ObtenerLugarEntrega(short id)
        {
            try
            {
                LugaresDLA dla = new LugaresDLA();
                return dla.ObtenerLugarEntrega(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<LugarEntrega> ListaLugarEntregas()
        {
            try
            {
                LugaresDLA dla = new LugaresDLA();
                return dla.ListaLugarEntregas();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool EliminarLugar(short IdLugar)
        {
           try
           {
              LugaresDLA dla = new LugaresDLA();
              return dla.EliminarLugarEntrega(IdLugar);
           }
           catch (Exception)
           {
              throw;
           }
        }
    }
}
