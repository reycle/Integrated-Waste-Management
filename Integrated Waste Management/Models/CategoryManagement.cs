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
    
    public partial class CategoryManagement
    {
        public int WasteTypeID { get; set; }
        public string WasteTypeName { get; set; }
        public string Category { get; set; }
        public Nullable<decimal> WeightPounds { get; set; }
        public Nullable<System.DateTime> DateTime { get; set; }

        public List<string> WasteTypeNames { get; set; }
        public List<string> Categories { get; set; }
    }
}
