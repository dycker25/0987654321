using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace almacen_telar.Ob
{
    public class MaquilaDTO
    {
        public short Id { get; set; }
        public string   IdMaquila { get; set; }

        public DateTime FechaEntrada { get; set; }

        public DateTime FechaEntrega { get; set; }

        public int Cantidad { get; set; }

        public short IdLugarEntrega { get; set; }

        public short IdUsuario { get; set; }

        public short IdBordado { get; set; }

        public bool Estado { get; set; }

        public short IdPrenda { get; set; }
    }
}
