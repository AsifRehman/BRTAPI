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
    
    public partial class tbl_PartyType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_PartyType()
        {
            this.tbl_Party = new HashSet<tbl_Party>();
        }
    
        public int PartyTypeID { get; set; }
        public string PartyType { get; set; }
        public string UPartyType { get; set; }
        public int PartyCategID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Party> tbl_Party { get; set; }
        public virtual tbl_PartyCateg tbl_PartyCateg { get; set; }
    }
}
