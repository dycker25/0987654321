using Project.DLA.Procesos;
using Project.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Procesos
{
    public class corteBL
    {
        public bool AgregarActualizarCorte(Corte corte)
        {

            try
            {
                proCorteDLA dla = new proCorteDLA();
                if (corte.Id > 0)
                    return dla.ActualizarCorte(corte);
                else
                    return dla.AgregarCorte(corte);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Corte ObtenerCorte(short id)
        {
            try
            {
                proCorteDLA dla = new proCorteDLA();
                return dla.ObtenerCorte(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool EliminarCorte(short id)
        {
            try
            {
                proCorteDLA dla = new proCorteDLA();
                
                return dla.EliminarCorte(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Corte> ListaCortes()
        {
            try
            {
                proCorteDLA dla = new proCorteDLA();
                return dla.ListaCortes();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Corte> ListaCortesEnproceso()
        {
            try
            {
                proCorteDLA dla = new proCorteDLA();
                return dla.ListaCortes();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
