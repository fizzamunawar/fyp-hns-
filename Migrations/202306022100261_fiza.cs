namespace fyp_hunger_nd_spice_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fiza : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Customer_id = c.Int(nullable: false, identity: true),
                        Customer_name = c.String(nullable: false, maxLength: 100),
                        Customer_email = c.String(nullable: false, maxLength: 100),
                        Customer_password = c.String(nullable: false, maxLength: 100),
                        Customer_contact = c.String(maxLength: 11),
                        Customer_address = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Customer_id);
            
            CreateTable(
                "dbo.Feedback",
                c => new
                    {
                        Feedback_id = c.Int(nullable: false, identity: true),
                        Feedback_Detail = c.String(nullable: false, maxLength: 100),
                        Feedback_email = c.String(nullable: false, maxLength: 100),
                        Feedback_contact = c.String(nullable: false, maxLength: 11),
                        Feedback_address = c.String(maxLength: 100),
                        Customer_fid = c.Int(),
                        Customer_Customer_id = c.Int(),
                    })
                .PrimaryKey(t => t.Feedback_id)
                .ForeignKey("dbo.Customer", t => t.Customer_Customer_id)
                .Index(t => t.Customer_Customer_id);
            
            AddColumn("dbo.order", "Customer_fid", c => c.Int());
            CreateIndex("dbo.order", "Customer_fid");
            AddForeignKey("dbo.order", "Customer_fid", "dbo.Customer", "Customer_id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.order", "Customer_fid", "dbo.Customer");
            DropForeignKey("dbo.Feedback", "Customer_Customer_id", "dbo.Customer");
            DropIndex("dbo.Feedback", new[] { "Customer_Customer_id" });
            DropIndex("dbo.order", new[] { "Customer_fid" });
            DropColumn("dbo.order", "Customer_fid");
            DropTable("dbo.Feedback");
            DropTable("dbo.Customer");
        }
    }
}
