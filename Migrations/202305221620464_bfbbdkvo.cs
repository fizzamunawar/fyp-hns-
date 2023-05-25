namespace fyp_hunger_nd_spice_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bfbbdkvo : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employee", "Employee_email", c => c.String(maxLength: 100));
            AlterColumn("dbo.Employee", "Employee_Gender", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employee", "Employee_Gender", c => c.String(maxLength: 100));
            AlterColumn("dbo.Employee", "Employee_email", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
