using System;
using Project.DTO;
using Project.DLA;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL
{
  public  class DiseñoBL
    {
      public DiseñoBL()
      {

      }
      public bool AgregarActualizarDiseño(Diseño diseño )
      {
          
          try
          {
              DiseñoDLA dla = new DiseñoDLA();
              if (diseño.Id > 0)
                return  dla.ActualizarDiseño(diseño);
              else
                return  dla.AgregarDiseño(diseño);
          }
          catch (Exception)
          {
              
              throw;
          }
      }

      public Diseño ObtenerDiseño(short id)
      {
          try
          {
              DiseñoDLA dla = new DiseñoDLA();
             return dla.ObtenerDiseño(id);
          }
          catch (Exception)
          {
              
              throw;
          }
      }

      public List<Diseño> ListaDiseños()
      {
          try
          {
              DiseñoDLA dla = new DiseñoDLA();
              return dla.ListaDiseños();
          }
          catch (Exception)
          {

              throw;
          }
      }
        public List<Diseño> ListaDiseñosActivos()
        {
            try
            {
                DiseñoDLA dla = new DiseñoDLA();
                return dla.ListaDiseñosActivos();
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
