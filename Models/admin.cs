namespace fyp_hunger_nd_spice_.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("admin")]
    public partial class admin
    {
        [Key]
        [Column("Admin_id")]
        public int Admin_id { get; set; }

        [Required]
        [StringLength(100)]
        public string Admin_name { get; set; }
        [Required]
        [StringLength(100)]
        public string Admin_Role { get; set; }
        [Required]
        [StringLength(100)]
        public string Admin_email { get; set; }

        [Required]
        [StringLength(100)]
        public string Admin_password { get; set; }

        [StringLength(11)]
        public string Admin_contact { get; set; }

        [StringLength(100)]
        public string Admin_address { get; set; }
    }
}
