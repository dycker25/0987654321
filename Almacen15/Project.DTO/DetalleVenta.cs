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
    
    public partial class DetalleVenta
    {
        public short Id { get; set; }
        public string Codigo { get; set; }
        public double Talla { get; set; }
        public int Cantidad { get; set; }
        public short IdVenta { get; set; }
    
        public virtual Venta Venta { get; set; }
    }
}