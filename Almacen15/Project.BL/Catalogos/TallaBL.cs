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
    public class TallaBL
    {
        public bool AgregarActualizarTalla(Talla Talla)
        {

            try
            {
                TallaDLA dla = new TallaDLA();
                if (Talla.Id > 0)
                    return dla.ActualizarTalla(Talla);
                else
                    return dla.AgregarTalla(Talla);
            }
            catch (Exception)
            {

                throw;
            }
        }

       public bool Eliminartallas(short IdTalla)
        {
           try
           {
              TallaDLA dla = new TallaDLA();
              return dla.EliminarTalla(IdTalla);
           }
           catch (Exception)
           {
              throw;
           }
        }


        public Talla ObtenerTalla(short id)
        {
            try
            {
                TallaDLA dla = new TallaDLA();
                return dla.ObtenerTalla(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Talla> ListaTallas()
        {
            try
            {
                TallaDLA dla = new TallaDLA();
                return dla.ListaTallas();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Talla> ListaTallasActivas()
        {
            try
            {
                TallaDLA dla = new TallaDLA();
                return dla.ListaTallasActivas();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
