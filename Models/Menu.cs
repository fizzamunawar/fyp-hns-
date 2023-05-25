namespace fyp_hunger_nd_spice_.Models
{
    using System;
    using System.Web;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    public class Menu
    {
        public List<Category> cat { get; set; }
        public List<product> pro { get; set; }
        public List<Ingredient> ingr { get; set; }
        public List<Cat> cate { get; set; }
    }
}