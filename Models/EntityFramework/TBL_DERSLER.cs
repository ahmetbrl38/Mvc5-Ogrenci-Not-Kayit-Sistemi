//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcOkulYS.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBL_DERSLER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_DERSLER()
        {
            this.TBL_NOTLAR = new HashSet<TBL_NOTLAR>();
        }
    
        public byte DERSID { get; set; }
        public string DERSAD { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_NOTLAR> TBL_NOTLAR { get; set; }
    }
}
