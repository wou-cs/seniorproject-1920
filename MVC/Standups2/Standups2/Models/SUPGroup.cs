namespace Standups2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SUPGroup
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SUPGroup()
        {
            SUPUsers = new HashSet<SUPUser>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Motto { get; set; }

        public int? SUPAdvisorID { get; set; }

        public int SUPAcademicYearID { get; set; }

        public virtual SUPAcademicYear SUPAcademicYear { get; set; }

        public virtual SUPAdvisor SUPAdvisor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SUPUser> SUPUsers { get; set; }
    }
}
