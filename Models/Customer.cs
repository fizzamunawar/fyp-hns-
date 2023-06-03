namespace fyp_hunger_nd_spice_.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class customer
    {
        public customer()
        { Order = new HashSet<Order>();
          Feedback = new HashSet<Feedback>();
        }

        [Key]
        [Column("Customer_id")]
        public int Customer_id { get; set; }

        [Required]
        [StringLength(100)]
        public string Customer_name { get; set; }
     
     
        [Required]
        [StringLength(100)]
        public string Customer_email { get; set; }

        [Required]
        [StringLength(100)]
        public string Customer_password { get; set; }

        [StringLength(11)]
        public string Customer_contact { get; set; }

        [StringLength(100)]
        public string Customer_address { get; set; }
        public virtual ICollection<Order> Order { get; set; }
        public virtual ICollection<Feedback> Feedback { get; set; }
    }
}
