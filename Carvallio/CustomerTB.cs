//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Carvallio
{
    using System;
    using System.Collections.Generic;
    
    public partial class CustomerTB
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CustomerTB()
        {
            this.InsuranceTBs = new HashSet<InsuranceTB>();
        }
    
        public int ID { get; set; }
        public int Owner_Id { get; set; }
        public string Plate_Number { get; set; }
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
    
        public virtual UserTB UserTB { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InsuranceTB> InsuranceTBs { get; set; }
    }
}
