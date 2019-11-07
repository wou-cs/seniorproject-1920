namespace Standups2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SUPMeeting
    {
        public int ID { get; set; }

        public DateTime SubmissionDate { get; set; }

        public int SUPUserID { get; set; }

        [Required]
        [StringLength(1000)]
        public string Completed { get; set; }

        [Required]
        [StringLength(1000)]
        public string Planning { get; set; }

        [Required]
        [StringLength(1000)]
        public string Obstacles { get; set; }

        public virtual SUPUser SUPUser { get; set; }
    }
}
