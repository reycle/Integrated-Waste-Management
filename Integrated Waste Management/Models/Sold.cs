//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Integrated_Waste_Management.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sold
    {
        public int SaleID { get; set; }
        public string RecyclableType { get; set; }
        public string categories { get; set; }
        public Nullable<System.DateTime> SaleDate { get; set; }
        public Nullable<decimal> WeightPounds { get; set; }
        public string BuyerName { get; set; }
        public Nullable<decimal> RevenueGenerated { get; set; }

        public List<string> RecyclableTypes { get; set; }
        public List<string> CategorysL { get; set; }
    }
}
