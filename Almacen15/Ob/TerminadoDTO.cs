using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace almacen_telar.Ob
{
   public class TerminadoDTO
   {
      private short id;

      public short Id
      {
         get { return id; }
         set { id = value; }
         
      }

      private string idTerminado;

      public string IdTerminado
      {
         get { return idTerminado; }
         set { idTerminado = value; }

      }

      private DateTime fedcharesepcion;

      public DateTime FdechaResepcion
      {
         get { return fedcharesepcion; }
         set { fedcharesepcion = value; }

      }

      private DateTime fechaEntrega;

      public DateTime FechaEntrega
      {
         get { return fechaEntrega; }
         set { fechaEntrega = value; }
      }

      private int numeroPiezas;

      public int NumeroPiezas
      {
         get { return numeroPiezas; }
         set { numeroPiezas = value; }
      }

      private short idLavaderia;

      public short IdLavanderia
      {
         get { return idLavaderia; }
         set { idLavaderia = value; }
      }

      private int idUsuario;

      public int IdUsuario
      {
         get { return idUsuario; }
         set { idUsuario = value; }
      }

      private bool estado;

      public bool Estado
      {
         get { return estado; }
         set { estado = value; }
      }


        //adicionales 

        public short IdDiseño { get; set; }
        public short Talla { get; set; }
        public short IdPrenda { get; set; }


    }
}
