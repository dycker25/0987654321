using Project.DLA.DetallesProcesos;
using Project.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Catalogos
{
  public  class PrendaBL
    {
        public List<Prenda> ListaPredas()
        {
            try
            {
                PrendaDLA dla = new  PrendaDLA();
                return dla.ListaPrenda();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Prenda ObtenerPrenda(short IdPreda)
        {
            try
            {
                PrendaDLA dla = new PrendaDLA();

                return dla.ObtenerPrenda(IdPreda);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public short AgregarActualizarPreda(Prenda preda)
        {
            try
            {
                PrendaDLA dla = new PrendaDLA();

                if (preda.Id > 0)
                {
                    return dla.ActualizarPrenda(preda);

                }
                else
                {
                    return  dla.AgregarePrenda(preda);

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

           
        }

        public bool EliminarPreda(short IdPreda)
        {
            try
            {
                PrendaDLA dla = new PrendaDLA();
                return dla.EliminarPrenda(IdPreda);
            }
            catch (Exception)
            {

                throw;
            }
        }

        
    }
}
