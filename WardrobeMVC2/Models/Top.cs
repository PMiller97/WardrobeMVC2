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
    
    public partial class Top
    {
        public int TopID { get; set; }
        public string TopName { get; set; }
        public string TopPhoto { get; set; }
        public string TopColor { get; set; }
        public string TopSeason { get; set; }
        public string TopOccasion { get; set; }
        public int TopTypeID { get; set; }
    
        public virtual TopType TopType { get; set; }
    }
}
