using Project.DLA.DetallesProcesos;
using Project.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.DetallesProcesos
{
  public  class detallesPrendaBL
    {

        public bool AgregarActualizarDetallePrenda(Detalle detallePrenda)
        {
            try
            {
                DetallePrendaDLA bl = new DetallePrendaDLA();
                if (detallePrenda.Id > 0)
                 return    bl.ActualizarDetallePrenda(detallePrenda);
                else
                    return bl.AgregarDetallePrenda(detallePrenda);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
