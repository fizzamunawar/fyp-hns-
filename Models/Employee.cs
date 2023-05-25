namespace fyp_hunger_nd_spice_.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
    {
        [Key]
        [Column("Employee_id")]
        public int Employee_id { get; set; }

        [Required]
        [StringLength(100)]
        public string Employee_name { get; set; }
        [Required]
        [StringLength(100)]
        public string Employee_Role { get; set; }
        [Required]
        [StringLength(100)]
        public string Employee_Gender { get; set; } 
        [StringLength(100)]
        public string Employee_email { get; set; }

        [Required]

        [StringLength(11)]
        public string Employee_contact { get; set; }

        [StringLength(100)]
        public string Employee_address { get; set; }
    }
}
