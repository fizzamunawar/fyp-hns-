namespace fyp_hunger_nd_spice_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bss : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer", "ResetCode", c => c.String(maxLength: 11));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customer", "ResetCode");
        }
    }
}
