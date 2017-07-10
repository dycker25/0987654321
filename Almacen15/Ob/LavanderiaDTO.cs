using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace almacen_telar.Ob
{
    public class LavanderiaDTO
    {
        public short Id { get; set; }
        public string IdLavanderia { get; set; }
        public DateTime FechaRecepcion { get; set; }
        public DateTime FechaEntrega { get; set; }
        public int  NumeroPiezas { get; set; }
        public short IdProceso { get; set; }
        public short IdMaquila { get; set; }
        public bool Estado { get; set; }

        public short IdUsuario { get; set; }
        public short IdPrenda { get; set; }
    }
}
