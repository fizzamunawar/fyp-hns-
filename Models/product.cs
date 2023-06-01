namespace fyp_hunger_nd_spice_.Models
{
    using System;
    using System.Web;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("product")]
    public partial class product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public product()
        {
            Orderdetails = new HashSet<Orderdetail>();
        }
        [Key]
        public int Products_id { get; set; }
 
        [StringLength(50)]
        public string Products_name { get; set; }

        [StringLength(500)]
        public string Products_description { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? cost { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Products_price { get; set; }

        [StringLength(500)]
        public string Products_pic { get; set; }
        [NotMapped]
        public HttpPostedFileBase Pro { get; set; }

        public int? category_fid { get; set; }

        public virtual Category Category { get; set; }

        [NotMapped]
        
        public int pro_quan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        public virtual ICollection<Orderdetail> Orderdetails { get; set; }

    }
}
 