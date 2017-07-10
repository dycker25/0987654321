using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace almacen_telar.Ob
{
    public class CorteDTO
    {
        private short id;

        public short Id 
        {
            get { return id; }
            set { id = value; }
        }

        private string idCorte;

        public string IdCorte
        {
            get { return idCorte; }
            set { idCorte = value; }
        }
        

        private DateTime fechaEntrada;

        public DateTime FechaEntrada
        {
            get { return fechaEntrada; }
            set { fechaEntrada = value; }
        }

        private DateTime fechaEntrega;

        public DateTime FechaEntrega
        {
            get { return fechaEntrega; }
            set { fechaEntrega = value; }
        }

        private int piezas;

        public int Piezas
        {
            get { return piezas; }
            set { piezas = value; }
        }
        private double talla;

          
        
        private int idPrenda;

        public int IdPrenda
        {
            get { return idPrenda; }
            set { idPrenda = value; }
        }


        public int prendaIdDiseño { get; set; }

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

        private string nombreCorte;

        public string NombreCorte
        {
            get { return nombreCorte; }
            set { nombreCorte = value; }
        }


        private string nombreModelo;

        public string NombreModelo
        {
            get { return nombreModelo; }
            set { nombreModelo = value; }
        }

        private string nombreUsuario;

        public string NombreUsuario
        {
            get { return nombreUsuario; }
            set { nombreUsuario = value; }
        }

        public int Total { get; set; }
    }
}
