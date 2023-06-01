namespace fyp_hunger_nd_spice_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ctyi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employee", "Employee_pic", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employee", "Employee_pic");
        }
    }
}
