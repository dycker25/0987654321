using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace almacen_telar.Ob
{
    public class LugarEntregaDTO
    {
        public short Id { get; set; }

        public string Nombre { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public bool Activo { get; set; }

        //adicinal 
        public short Idusuario { get; set; }
        public Double Talla { get; set; }
    }
}
