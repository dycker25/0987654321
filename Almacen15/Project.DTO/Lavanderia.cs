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
    
    public partial class Lavanderia
    {
        public short Id { get; set; }
        public string IdLavanderia { get; set; }
        public System.DateTime FechaRecepcion { get; set; }
        public Nullable<System.DateTime> FechaEntrega { get; set; }
        public int NumeroPiezas { get; set; }
        public short IdProceso { get; set; }
        public short IdPrenda { get; set; }
        public bool Estado { get; set; }
        public short IdUsuario { get; set; }
    
        public virtual Proceso Proceso { get; set; }
        public virtual Prenda Prenda { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}