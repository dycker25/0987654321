using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace almacen_telar.Ob
{
    public class BordadoDTO
    {
        private short id;

        public short Id
        {
            get { return id; }
            set { id = value; }
        }

        private string idBordado;

        public string IdBordado
        {
            get { return idBordado; }
            set { idBordado = value; }
        }

        private int numeroPiezas;

        public int NumeroPiezas
        {
            get { return numeroPiezas; }
            set { numeroPiezas = value; }
        }

        private int numeroPuntadas;

        public int NumeroPuntadas
        {
            get { return numeroPuntadas; }
            set { numeroPuntadas = value; }
        }

        private string parteBordad;

        public string ParteBordada
        {
            get { return parteBordad; }
            set { parteBordad = value; }
        }

        private DateTime fechaInicio;

        public DateTime FechaInicio
        {
            get { return fechaInicio; }
            set { fechaInicio = value; }
        }

        private DateTime? fechaTerminado;

        public DateTime? FechaTerminado
        {
            get { return fechaTerminado; }
            set { fechaTerminado = value; }
        }

        private short idPrenda;

        public short IdPrenda
        {
            get { return idPrenda; }
            set { idPrenda = value; }
        }

        private short idCorte;

        public short IdCorte
        {
            get { return idCorte; }
            set { idCorte = value; }
        }

        private short idUsuario;

        public short IdUsuario
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







    }
}
