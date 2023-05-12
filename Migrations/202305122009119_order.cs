namespace fyp_hunger_nd_spice_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class order : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.order", "Order_status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.order", "Order_status", c => c.String(maxLength: 50, fixedLength: true));
        }
    }
}
