using System.Data.Entity;

namespace fyp_hunger_nd_spice_.Models
{
    public partial class Model : DbContext
    {
        public Model()
            : base("name=Model1")
        {
        }

        public virtual DbSet<admin> admins { get; set; } 
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<product> products { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Orderdetail> Orderdetails { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set; } 
        public virtual DbSet<customer> Customers { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Cat> Cats { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Category>()
                .HasMany(e => e.products)
                .WithOptional(e => e.Category)
                .HasForeignKey(e => e.category_fid);
            modelBuilder.Entity<Cat>()
                .HasMany(e => e.Ingredients)
                .WithOptional(e => e.Cat)
                .HasForeignKey(e => e.Cat_fid);


            modelBuilder.Entity<Order>()
                .HasMany(e => e.Orderdetails)
                .WithOptional(e => e.Order)
                .HasForeignKey(e => e.Order_Fid);

            modelBuilder.Entity<customer>()
                .HasMany(e => e.Order)
                .WithOptional(e => e.Customer)
                .HasForeignKey(e => e.Customer_fid);
            modelBuilder.Entity<customer>()
                .HasMany(e => e.Feedback)
                .WithOptional(e => e.Customer)
                .HasForeignKey(e => e.Customer_fid);

            modelBuilder.Entity<Orderdetail>()
                .Property(e => e.price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<product>()
                .HasMany(e => e.Orderdetails)
                .WithOptional(e => e.product)
                .HasForeignKey(e => e.Product_fid);
            modelBuilder.Entity<Ingredient>()
              .HasMany(e => e.Orderdetails)
              .WithOptional(e => e.Ingredient)
              .HasForeignKey(e => e.ingredients_fid);
        }

       
    }
}
