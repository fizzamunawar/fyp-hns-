namespace fyp_hunger_nd_spice_.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Feedback")]
    public partial class Feedback
    {
        [Key]
        [Column("Feedback_id")]
        public int Feedback_id { get; set; }


        [Required]
        [StringLength(100)]
        public string Feedback_Detail { get; set; }

        [Required]
        [StringLength(100)]
        public string Feedback_email { get; set; }

        [Required]
       

        [StringLength(11)]
        public string Feedback_contact { get; set; }

        [StringLength(100)]
        public string Feedback_address { get; set; }
        
        public int? Customer_fid { get; set; }
        public virtual customer Customer { get; set; }
    }
}
