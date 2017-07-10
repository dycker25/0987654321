using Project.DLA.Catalogos;
using Project.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Catalogos
{
   public class AlmacenBL
    {
        public bool AgregarActualizarBodega(Bodega Bodega)
        {

            try
            {
                AlmacenDLA dla = new AlmacenDLA();
                if (Bodega.Id > 0)
                    return dla.ActualizarBodega(Bodega);
                else
                    return dla.AgregarBodega(Bodega);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public Bodega ObtenerBodega(short id)
        {
            try
            {
                AlmacenDLA dla = new AlmacenDLA();
                return dla.ObtenerBodega(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Bodega> ListaBodegas()
        {
            try
            {
                AlmacenDLA dla = new AlmacenDLA();
                return dla.ListaBodegas();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool EliminarBodegas(short IdBodega)
        {
           try
           {
              AlmacenDLA dla = new AlmacenDLA();
              return dla.EliminarBodega(IdBodega);

           }
           catch(Exception)
           {
              throw;
           }
        }

       
    }
}
