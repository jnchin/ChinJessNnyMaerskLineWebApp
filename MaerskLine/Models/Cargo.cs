//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MaerskLine.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cargo
    {
        public string CargoID { get; set; }
        public string Type { get; set; }
        public string Weight { get; set; }
        public string CustID { get; set; }
        public string WarehouseID { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual Warehouse Warehouse { get; set; }
    }
}
