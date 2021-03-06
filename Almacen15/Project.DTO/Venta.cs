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
    
    public partial class Venta
    {
        public Venta()
        {
            this.DetalleVentas = new HashSet<DetalleVenta>();
        }
    
        public short Id { get; set; }
        public System.DateTime FechaEntrega { get; set; }
        public int PiezasEntregas { get; set; }
        public int PiezasVendidas { get; set; }
        public Nullable<int> PiezasDevueltas { get; set; }
        public short IdCliente { get; set; }
        public short IdUsuario { get; set; }
    
        public virtual ICollection<DetalleVenta> DetalleVentas { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Vendedor Vendedor { get; set; }
    }
}
