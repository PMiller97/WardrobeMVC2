//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WardrobeMVC2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bottom
    {
        public int BottomID { get; set; }
        public string BottomName { get; set; }
        public string BottomPhoto { get; set; }
        public string BottomColor { get; set; }
        public string BottomSeason { get; set; }
        public string BottomOccasion { get; set; }
        public int BottomTypeID { get; set; }
    
        public virtual BottomType BottomType { get; set; }
    }
}
