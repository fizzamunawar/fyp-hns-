namespace fyp_hunger_nd_spice_.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("order")]
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            Orderdetails = new HashSet<Orderdetail>();
        }

        [Key]
        public int Order_ID { get; set; }

        public DateTime? Order_date { get; set; }

       

        [Required]
        [StringLength(50)]
        public string Order_type { get; set; }
        [Required]
        [StringLength(50)]
        public string Order_status{ get; set; }

        [Required]
        [StringLength(50)]
        public string Order_Name { get; set; }

        [StringLength(50)]
        public string Order_Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Order_Contact { get; set; }

        [Required]
        [StringLength(100)]
        public string Order_Address { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orderdetail> Orderdetails { get; set; }
    }
}
