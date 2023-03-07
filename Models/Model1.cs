using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace fyp_hunger_nd_spice_.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<admin> admins { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<product> products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Category>()
                .HasMany(e => e.products)
                .WithOptional(e => e.Category)
                .HasForeignKey(e => e.category_fid);

        }
    }
}
