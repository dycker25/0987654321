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
    
    public partial class Talla
    {
        public Talla()
        {
            this.Pantalons = new HashSet<Pantalon>();
        }
    
        public int Id { get; set; }
        public double Talla1 { get; set; }
        public bool activo { get; set; }
    
        public virtual ICollection<Pantalon> Pantalons { get; set; }
    }
}
