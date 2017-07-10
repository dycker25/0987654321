using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace almacen_telar.Ob
{
     public class DiseñoDTO
    {
        private short id;

        public short Id
        {
            get { return id; }
            set { id = value; }
        }

        private string idDiseño;

        public string IdDiseño
        {
            get { return idDiseño; }
            set { idDiseño = value; }
        }
        

        private string corte;

        public string Corte
        {
            get { return corte; }
            set { corte = value; }
        }

        private string modelo;

        public string Modelo
        {
            get { return modelo; }
            set { modelo = value; }
        }

        private DateTime? fechaAprovacion;

        public DateTime? FechaAprovacion
        {
            get { return fechaAprovacion; }
            set { fechaAprovacion = value; }
        }

        private short idUsuario;

        public short IdUsuario
        {
            get { return idUsuario; }
            set { idUsuario = value; }
        }

        private string nomreUsuario;

        public string NombreUsuario
        {
            get { return nomreUsuario; }
            set { nomreUsuario = value; }
        }
        
        private bool activo;

        public bool Activo
        {
            get { return activo; }
            set { activo = value; }
        }
        

        
        
        
        
    }
}
