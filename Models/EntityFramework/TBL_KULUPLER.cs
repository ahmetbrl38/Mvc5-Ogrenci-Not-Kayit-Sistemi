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
    
    public partial class TBL_KULUPLER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_KULUPLER()
        {
            this.TBL_OGRENCILER = new HashSet<TBL_OGRENCILER>();
        }
    
        public byte KULUPID { get; set; }
        public string KULUPAD { get; set; }
        public Nullable<short> KULUPKONTENJAN { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_OGRENCILER> TBL_OGRENCILER { get; set; }
    }
}
