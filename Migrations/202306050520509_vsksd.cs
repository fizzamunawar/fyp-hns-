namespace fyp_hunger_nd_spice_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vsksd : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customer", "Customer_contact", c => c.String(nullable: false, maxLength: 11));
            AlterColumn("dbo.Customer", "Customer_address", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customer", "Customer_address", c => c.String(maxLength: 100));
            AlterColumn("dbo.Customer", "Customer_contact", c => c.String(maxLength: 11));
        }
    }
}
