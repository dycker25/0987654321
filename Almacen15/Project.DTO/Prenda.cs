//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project.DTO
{
    using System;
    using System.Collections.Generic;
    
    public partial class Prenda
    {
        public Prenda()
        {
            this.Bordadoes = new HashSet<Bordado>();
            this.Cortes = new HashSet<Corte>();
            this.Detalles = new HashSet<Detalle>();
            this.Lavanderias = new HashSet<Lavanderia>();
            this.Maquilas = new HashSet<Maquila>();
            this.Terminadoes = new HashSet<Terminado>();
        }
    
        public short Id { get; set; }
        public short IdDiseño { get; set; }
    
        public virtual ICollection<Bordado> Bordadoes { get; set; }
        public virtual ICollection<Corte> Cortes { get; set; }
        public virtual ICollection<Detalle> Detalles { get; set; }
        public virtual ICollection<Lavanderia> Lavanderias { get; set; }
        public virtual ICollection<Maquila> Maquilas { get; set; }
        public virtual ICollection<Terminado> Terminadoes { get; set; }
    }
}