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
    
    public partial class BodegaPantalon
    {
        public short Id { get; set; }
        public short IdPantalon { get; set; }
        public short IdBodega { get; set; }
    
        public virtual Bodega Bodega { get; set; }
        public virtual Pantalon Pantalon { get; set; }
    }
}
