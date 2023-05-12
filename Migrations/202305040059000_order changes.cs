namespace fyp_hunger_nd_spice_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderchanges : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orderdetail",
                c => new
                    {
                        Order_detail_id = c.Int(nullable: false, identity: true),
                        Order_Fid = c.Int(),
                        Product_fid = c.Int(),
                        price = c.Decimal(precision: 18, scale: 0, storeType: "numeric"),
                        Quantity = c.Int(),
                    })
                .PrimaryKey(t => t.Order_detail_id)
                .ForeignKey("dbo.order", t => t.Order_Fid)
                .ForeignKey("dbo.product", t => t.Product_fid)
                .Index(t => t.Order_Fid)
                .Index(t => t.Product_fid);
            
            CreateTable(
                "dbo.order",
                c => new
                    {
                        Order_ID = c.Int(nullable: false, identity: true),
                        Order_date = c.DateTime(),
                        Order_status = c.String(maxLength: 50, fixedLength: true),
                        Order_type = c.String(nullable: false, maxLength: 50),
                        Order_Name = c.String(nullable: false, maxLength: 50),
                        Order_Email = c.String(maxLength: 50),
                        Order_Contact = c.String(nullable: false, maxLength: 50),
                        Order_Address = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Order_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orderdetail", "Product_fid", "dbo.product");
            DropForeignKey("dbo.Orderdetail", "Order_Fid", "dbo.order");
            DropIndex("dbo.Orderdetail", new[] { "Product_fid" });
            DropIndex("dbo.Orderdetail", new[] { "Order_Fid" });
            DropTable("dbo.order");
            DropTable("dbo.Orderdetail");
        }
    }
}
