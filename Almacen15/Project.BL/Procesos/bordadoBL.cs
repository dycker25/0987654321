using Project.DLA.Procesos;
using Project.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Procesos
{
    class bordadoBL
    {
        public bool AgregarActualizarLugar(Bordado bordado)
        {

            try
            {
                proBordadoDLA dla = new proBordadoDLA();
                if (bordado.Id > 0)
                    return dla.ActualizarBordado(bordado);
                else
                    return dla.AgregarBordado(bordado);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Bordado ObtenerBordado(short id)
        {
            try
            {
                proBordadoDLA dla = new proBordadoDLA();
                return dla.ObtenerBordado(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Bordado> ListaBordados()
        {
            try
            {
                proBordadoDLA dla = new proBordadoDLA();
                return dla.ListaBordados();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
