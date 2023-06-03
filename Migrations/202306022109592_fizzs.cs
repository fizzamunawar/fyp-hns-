namespace fyp_hunger_nd_spice_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fizzs : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Feedback", "Customer_fid");
            RenameColumn(table: "dbo.Feedback", name: "Customer_Customer_id", newName: "Customer_fid");
            RenameIndex(table: "dbo.Feedback", name: "IX_Customer_Customer_id", newName: "IX_Customer_fid");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Feedback", name: "IX_Customer_fid", newName: "IX_Customer_Customer_id");
            RenameColumn(table: "dbo.Feedback", name: "Customer_fid", newName: "Customer_Customer_id");
            AddColumn("dbo.Feedback", "Customer_fid", c => c.Int());
        }
    }
}
