using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace almacen_telar.Ob
{
    public class VentaDTO
    {
        public short Id { get; set; }
        public DateTime FechaEntrega { get; set; }
        public int PienzasEntregadas { get; set; }
        public int PiezasVendidas { get; set; }
        public int PiezasDevueltas { get; set; }
    }
}
