using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace almacen_telar.Ob
{
    public class DetalleVentaDTO
    {
        public short Id { get; set; }

        public string Codigo { get; set; }

        public double Talla { get; set; }

        public int IdTalla { get; set; }

        public int Cantidad { get; set; }

        public short IdVenta { get; set; }
    }
}
