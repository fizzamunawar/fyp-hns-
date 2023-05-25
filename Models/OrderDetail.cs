namespace fyp_hunger_nd_spice_.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Orderdetail")]
    public partial class Orderdetail
    {
        [Key]
        public int Order_detail_id { get; set; }

        public int? Order_Fid { get; set; }

        public int? Product_fid { get; set; }
        public int? ingredients_fid { get; set; } 

        [Column(TypeName = "numeric")]
        public decimal? price { get; set; }

        public int? Quantity { get; set; }

        public virtual Order Order { get; set; }

        public virtual product product { get; set; }
        public virtual Ingredient Ingredient { get; set; }

    }
}
