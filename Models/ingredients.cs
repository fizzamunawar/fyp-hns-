namespace fyp_hunger_nd_spice_.Models
{
    using System;
    using System.Web;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ingrdients")]
    public partial class Ingredient
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ingredient()
        {
            Orderdetails = new HashSet<Orderdetail>();
        }
        [Key]
        public int ingredient_id { get; set; }
        
 
        [StringLength(50)]
        public string ingredient_name { get; set; }

        [StringLength(500)]
        public string ingredient_description { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ingredient_price { get; set; }

        [StringLength(500)]
        public string ingredient_pic { get; set; }
        [NotMapped]
        public HttpPostedFileBase Pro_pic { get; set; }
        [NotMapped]
        public HttpPostedFileBase ing { get; set; }

        public int? Cat_fid { get; set; }

        public virtual Cat Cat { get; set; }

        [NotMapped]
         
        public int pro_quant { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        public virtual ICollection<Orderdetail> Orderdetails { get; set; }

    }
}
 