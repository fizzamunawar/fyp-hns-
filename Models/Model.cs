using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace fyp_hunger_nd_spice_.Models
{
    public partial class Model : DbContext
    {
        public Model()
            : base("name=Model1")
        {
        }

        public virtual DbSet<admin> admins { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<product> products { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Orderdetail> Orderdetails { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Category>()
                .HasMany(e => e.products)
                .WithOptional(e => e.Category)
                .HasForeignKey(e => e.category_fid);

           
            modelBuilder.Entity<Order>()
                .HasMany(e => e.Orderdetails)
                .WithOptional(e => e.Order)
                .HasForeignKey(e => e.Order_Fid);

            modelBuilder.Entity<Orderdetail>()
                .Property(e =>e.price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<product>()
                .HasMany(e => e.Orderdetails)
                .WithOptional(e => e.product)
                .HasForeignKey(e => e.Product_fid);

        }
    }
}
