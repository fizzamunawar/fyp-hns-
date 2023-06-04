namespace fyp_hunger_nd_spice_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fizza1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orderdetail", "cost", c => c.Decimal(precision: 18, scale: 2, storeType: "numeric"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orderdetail", "cost");
        }
    }
}
