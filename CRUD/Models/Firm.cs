//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRUD.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Firm
    {
        public byte id { get; set; }
        public string Name { get; set; }
        public string GSTNO { get; set; }
        public string NTN { get; set; }
        public string Part1 { get; set; }
        public string Part2 { get; set; }
        public string Address { get; set; }
        public string ACTYPE { get; set; }
        public byte[] ts { get; set; }
        public string DBTYPE { get; set; }
        public string uName { get; set; }
        public Nullable<bool> isTaxable { get; set; }
    }
}
