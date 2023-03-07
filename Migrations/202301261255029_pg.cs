namespace fyp_hunger_nd_spice_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pg : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.product", "product2_Products_id", "dbo.product");
            DropIndex("dbo.product", new[] { "product2_Products_id" });
            AlterColumn("dbo.admin", "Admin_address", c => c.String(maxLength: 100));
            AlterColumn("dbo.Category", "Cusinie_name", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.product", "product2_Products_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.product", "product2_Products_id", c => c.Int(nullable: false));
            AlterColumn("dbo.Category", "Cusinie_name", c => c.String(nullable: false, maxLength: 100, fixedLength: true));
            AlterColumn("dbo.admin", "Admin_address", c => c.String(maxLength: 100, fixedLength: true));
            CreateIndex("dbo.product", "product2_Products_id");
            AddForeignKey("dbo.product", "product2_Products_id", "dbo.product", "Products_id");
        }
    }
}
