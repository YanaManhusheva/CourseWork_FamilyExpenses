//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FamilyExpensesCourseWork.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class cFamilyRole
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cFamilyRole()
        {
            this.cFamilyMembers = new HashSet<cFamilyMember>();
        }
    
        public int Id { get; set; }
        public string Role { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cFamilyMember> cFamilyMembers { get; set; }
    }
}
