using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace almacen_telar.Ob
{
    public class DetallesDTO
    {
        public short Id { get; set; }

        public short IdPrenda { get; set; }

     
        public short IdTallas { get; set; }

        public int Cantidad { get; set; }
    }
}
