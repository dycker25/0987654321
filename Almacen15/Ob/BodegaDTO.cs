using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace almacen_telar.Ob
{
    public class BodegaDTO
    {
        public short Id { get; set; }
        public string Nombre { get; set; }
        public short IdUsuario { get; set; }
        public bool Estado { get; set; }
    }
}
